using CommonControls;
using CommonHelper.Constants;
using CommonHelper.Utils;
using JavaCommunication.Factory;
using Microsoft.Practices.CompositeUI;
using sTimeKeeping.Constants;
using sTimeKeeping.Factory;
using sTimeKeeping.Model;
using sWorldModel;
using sWorldModel.Exceptions;
using sWorldModel.Filters;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Resources;
using System.ServiceModel;
using System.Windows.Forms;

namespace sTimeKeeping.WorkItems
{
    /// <summary>
    /// class FormMemberOfSubOrg : CommonControls.Custom.CommonDialog
    /// </summary>
    public partial class FormMemberOfSubOrg : CommonControls.Custom.CommonDialog
    {
        #region Properties

        // Properties
        private const int SetMaxWightTxtName = 323;
        public const byte ModeAdding = 1;
        public const byte ModeDeleting = 2;

        // ResourceManager
        private ResourceManager rm;

        // OperatingMode
        private byte OperatingMode;
        private long eventId;

        //orgId dung de them vao bang timeconfig du lieu duoc gui tu usercontroll qua
        private long orgId;
        private long subOrgId;

        // BackgroundWorker
        private BackgroundWorker bgwAddEventMemberList;
        private BackgroundWorker bgwDeleteEventMemberList;

        // date
        private DataTable dtbMemberList;
        private DateTime date;

        private bool isLoadMember = false;
        private List<long> meberListIdDelete;

        // workItem
        private TimeKeepingComponentWorkItem workItem;
        [ServiceDependency]
        public TimeKeepingComponentWorkItem WorkItem
        {
            set { workItem = value; }
        }

        // storageService
        private ILocalStorageService storageService;
        public ILocalStorageService StorageService
        {
            get
            {
                if (storageService == null)
                {
                    storageService = workItem.Services.Get<ILocalStorageService>();
                }
                return storageService;
            }
        }

        #endregion

        #region initialize and register

        /// <summary>
        /// contructor FormMemberOfSubOrg
        /// </summary>
        /// <param name="operationMode"></param>
        /// <param name="orgId"></param>
        /// <param name="subOrgId"></param>
        /// <param name="eventId"></param>
        public FormMemberOfSubOrg(byte operationMode, long orgId, long subOrgId, long eventId)
        {
            // init
            InitializeComponent();
            InitDataTableMember();
            RegisterEvent();

            // gan gia tri
            this.subOrgId = subOrgId;
            this.eventId = eventId;
            this.orgId = orgId;
            this.OperatingMode = operationMode;
        }

        /// <summary>
        /// đăng ký sự kiện
        /// </summary>
        private void RegisterEvent()
        {
            // gan su kien
            btnAccept.Click += OnButtonConfirmClicked;
            btnCancel.Click += OnButtonCancelClicked;
            initializeBgWorker();
        }

        /// <summary>
        /// initializeBgWorker
        /// </summary>
        private void initializeBgWorker()
        {
            // Add EventMember
            bgwAddEventMemberList = new BackgroundWorker();
            bgwAddEventMemberList.WorkerSupportsCancellation = true;
            bgwAddEventMemberList.DoWork += bgwAddEventMemberList_DoWork;
            bgwAddEventMemberList.RunWorkerCompleted += bgwAddEventMemberList_RunWorkerCompleted;

            // Delete Event Member
            bgwDeleteEventMemberList = new BackgroundWorker();
            bgwDeleteEventMemberList.WorkerSupportsCancellation = true;
            bgwDeleteEventMemberList.DoWork += bgwDeleteEventMemberList_DoWork;
            bgwDeleteEventMemberList.RunWorkerCompleted += bgwDeleteEventMemberList_RunWorkerCompleted;
        }

        /// <summary>
        /// Initialize Control
        /// </summary>
        /// <param name="orgId"></param>
        /// <param name="subOrgId"></param>
        private void InitializeControl(long orgId, long subOrgId)
        {
            List<MemberCustomerDTO> memberlist = null;

            // ModeAdding
            if (OperatingMode == ModeAdding)
            {
                memberlist = GetMemberList(orgId, subOrgId);
            }

            // ModeDeleting
            if (OperatingMode == ModeDeleting)
            {
                memberlist = GetMemberList(eventId);
            }

            // InitializeDataTable
            InitializeDataTable(memberlist);
        }

        /// <summary>
        /// InitDataTableTimeConfig
        /// </summary>
        private void InitDataTableMember()
        {
            dtbMemberList = new DataTable();
            dtbMemberList.Columns.Add(colId.DataPropertyName);
            dtbMemberList.Columns.Add(colEventMemberId.DataPropertyName);
            dtbMemberList.Columns.Add(colCode.DataPropertyName);
            dtbMemberList.Columns.Add(colName.DataPropertyName);
            dtbMemberList.Columns.Add(colPhone.DataPropertyName);
            dtbMemberList.Columns.Add(colCmnd.DataPropertyName);
            dtbMemberList.Columns.Add(colEmail.DataPropertyName);
            dgvMemberListEvent.DataSource = dtbMemberList;
        }

        /// <summary>
        /// InitializeDataTable
        /// </summary>
        private void InitializeDataTable(List<MemberCustomerDTO> memberlist)
        {
            // eventMemberId
            long eventMemberId = -1;

            // Clear
            dtbMemberList.Clear();

            // duyet
            foreach (MemberCustomerDTO member in memberlist)
            {
                // kiem tra Title
                if (member.Member.Title == ConstantsValue.TITLE_BAO_CHI)
                        continue;

                //neu thanh vien chua co the thi khong hien thi len bang
                //if(null == member.PersoCard)
                //{
                //    continue;
                //}

                // NewRow
                DataRow row = dtbMemberList.NewRow();
                row.BeginEdit();

                // gia tri 
                row[colId.DataPropertyName] = member.Member.Id;
                row[colCode.DataPropertyName] = member.Member.Code;
                row[colName.DataPropertyName] = member.Member.LastName + " " + member.Member.FirstName;
                row[colPhone.DataPropertyName] = member.Member.PhoneNo;
                row[colCmnd.DataPropertyName] = member.Member.IdentityCard;
                row[colEmail.DataPropertyName] = member.Member.Email;

                // kiem tra member co thuoc su kien khong
                eventMemberId = isConstantMember(member.Member.Id);

                // neu khac -1
                if (eventMemberId != -1)
                {
                    // gan cho cot colEventMemberId
                    row[colEventMemberId.DataPropertyName] = eventMemberId;
                }

                row.EndEdit();

                // Add
                dtbMemberList.Rows.Add(row);
            }
        }

        /// <summary>
        /// InitEventMemberList
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        private List<EventMember> InitEventMemberList()
        {
            List<EventMember> listEventMember = new List<EventMember>();
            EventMember evMember = new EventMember();
            DataGridViewSelectedRowCollection list = dgvMemberListEvent.SelectedRows;

            // kiem tra size cua list
            if (list.Count < 1)
            {
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "NotRowSelected"));
                return null;
            }
            else
            {
                // for tren SelectedRows
                foreach (DataGridViewRow row in list)
                {
                    evMember = new EventMember();
                    string evMemberId = row.Cells[colEventMemberId.DataPropertyName].Value.ToString();

                    // neu String.Empty == evMemberId => member này da co trong su kien
                    if (String.Empty == evMemberId)
                    {
                        evMember.eventId = eventId;
                        evMember.memberId = long.Parse(row.Cells[colId.DataPropertyName].Value.ToString());
                        evMember.memberName = row.Cells[colName.DataPropertyName].Value.ToString();

                        // add
                        listEventMember.Add(evMember);
                    }
                }
            }
            return listEventMember;
        }

        #endregion

        #region support event

        /// <summary>
        /// kiem tra member co thuoc su kien khong
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns> eventmemberid cua member do</returns>
        private long isConstantMember(long memberId)
        {
            List<EventMember> list = LoadEventMember(eventId);
            long result = -1;

            // duyet list
            foreach (EventMember evMember in list)
            {
                // neu id nhan vao trung id cua evMember
                if (evMember.memberId == memberId)
                {
                    result = evMember.eventmemberId;
                }
            }
            return result;
        }

        /// <summary>
        /// to member filter 
        /// </summary>
        /// <returns></returns>
        private MemberFilter ToMemberFilter()
        {
            MemberFilter memberFilter = new MemberFilter();
            
            // kiem tra tbxCode co empty ko
            if (tbxCode.Text.Trim() != String.Empty)
            {
                memberFilter.FilterByMemberName = true;

                memberFilter.MemberName = tbxCode.Text;
            }
            return memberFilter;
        }

        /// <summary>
        /// ToListLongEventMember: tao list long member dung de xoa 1 list member
        /// </summary>
        /// <returns></returns>
        private List<long> ToListLongEventMember()
        {
            List<long> listEventMemberId = null;

            // lay ra DataGridViewSelectedRowCollection duoc chon
            DataGridViewSelectedRowCollection list = dgvMemberListEvent.SelectedRows;

            // kiem tra size cua list
            if (list.Count < 1)
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "NotRowSelected"));
            else
            {
                listEventMemberId = new List<long>();
                meberListIdDelete = new List<long>();

                // for tren list SelectedRows 
                foreach (DataGridViewRow row in list)
                {
                    // add EventMeberId
                    long evmemId = (long.Parse(row.Cells[colEventMemberId.DataPropertyName].Value.ToString()));
                    listEventMemberId.Add(evmemId); 

                    // add member id
                    evmemId = (long.Parse(row.Cells[colId.DataPropertyName].Value.ToString()));
                    meberListIdDelete.Add(evmemId);
                }
            }
            return listEventMemberId;
        }

        /// <summary>
        /// Hide the form
        /// </summary>
        private void Hided()
        {
            Hide();
        }

        #endregion

        #region bgWorker

        /// <summary>
        /// bgwAddEventMemberList_DoWork
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwAddEventMemberList_DoWork(object sender, DoWorkEventArgs e)
        {
            int result = -1;
            List<EventMember> eventMemberList;
            try
            {
                // InitEventMemberList
                eventMemberList = InitEventMemberList();

                // kiem tra eventMemberList
                if(null != eventMemberList && eventMemberList.Count != 0){

                    //truoc khi insert xuong database, kiem tra danh sach member xem co nguoi nao trung lich hop hay khong?
                    List<Member> list = checkEventConflict(eventMemberList, eventId);

                    // kiem tra list
                    if (null != list && list.Count > 0)
                    {
                        string listMemberShow = string.Empty;

                        // lay full ho ten nguoi trung lich
                        for (int i = 0; i < list.Count; i++ )
                        {
                            listMemberShow += list[i].LastName + " " + list[i].FirstName + " ,";
                        }

                        // danh sach nguoi trung lich duoc hien thi
                        listMemberShow = listMemberShow.Substring(0, listMemberShow.Length - 1);
                        MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "conflictEvent") + ": " + listMemberShow);
                    }

                //ham nay insert eventmember xuong databases
               result = TimeKeepingEventFactory.Instance.GetChannel().insertListEventMember(storageService.CurrentSessionId, eventMemberList);
                }
                e.Result = result;
            }
            catch (TimeoutException)
            {
                // show TimeoutException 
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                // show FaultException
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
            }
            catch (FaultException ex)
            {
                // FaultException
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "FaultExceptionMessage")
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
            }
            catch (CommunicationException)
            {
                // CommunicationException
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "CommunicationExceptionMessage"));
            }
        }

        /// <summary>
        /// bgwAddEventMemberList_RunWorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwAddEventMemberList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // kiem tra e.cancel
            if (e.Cancelled)
            {
                return;
            }

            // kiem tra e.result == null
            if ((int)e.Result == 0)
            {
                List<long> idList = new List<long>();
                Event eventObj = OnLoadEvent(eventId);

                // tao List EventMember de Add
                List<EventMember> eventMemberList = InitEventMemberList();

                // tao list id member de update lai tinh toan lai status cua ngay 
                foreach (EventMember evLong in eventMemberList)
                {
                    // add vao idList
                    idList.Add(evLong.memberId);
                }
                    //ham dung de tinh toan lai status cua ngay 
                TimeKeepingFactory.Instance.GetChannel().insertOrUpdateMonthlyReport(storageService.CurrentSessionId,
                             date.ToString("yyyy-MM-dd"), date.ToString("yyyy-MM-dd"), idList);

                //MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "InsertSuccess"));
                Hided();
            }
            else
            {
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "InsertFailed"));
            }
        }

        /// <summary>
        /// bgwDeleteEventMemberList_DoWork
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwDeleteEventMemberList_DoWork(object sender, DoWorkEventArgs e)
        {
            //  tao list long member dung de xoa 1 list member
            List<long> eventMeberListIdDelete = ToListLongEventMember();
            int result = -1;
            try
            {
                // delete
                result = TimeKeepingEventFactory.Instance.GetChannel().deleteEventMemberList(storageService.CurrentSessionId, eventMeberListIdDelete);
            }
            catch (TimeoutException)
            {
                // show TimeoutException 
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                // show FaultException
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
            }
            catch (FaultException ex)
            {
                // FaultException
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "FaultExceptionMessage")
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
            }
            catch (CommunicationException)
            {
                // CommunicationException
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "CommunicationExceptionMessage"));
            }
            finally
            {
                e.Result = result;
            }
        }

        /// <summary>
        /// bgwDeleteEventMemberList_RunWorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwDeleteEventMemberList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // e.Cancelled
            if (e.Cancelled)
            {
                return;
            }

            // e.Result == 0
            if ((int)e.Result == 0)
            {
                Event eventObj = OnLoadEvent(eventId);

                //ham dung de tinh toan lai status cua ngay 
                TimeKeepingFactory.Instance.GetChannel().insertOrUpdateMonthlyReport(storageService.CurrentSessionId,
                             date.ToString("yyyy-MM-dd"), date.ToString("yyyy-MM-dd"), meberListIdDelete);
               // MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "InsertSuccess"));
                Hided();
            }
            else
            {
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "InsertFailed"));
            }
        }

        #endregion

        #region load data from server

        /// <summary>
        /// load event_member dua vao event id
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        private List<EventMember> LoadEventMember(long eventId)
        {
            List<EventMember> list = new List<EventMember>();

            // kiem tra eventId > 0
            if (eventId > 0)
            {
                try
                {
                    // getEventMemberListByEventId
                    list = TimeKeepingEventFactory.Instance.GetChannel().getEventMemberListByEventId(StorageService.CurrentSessionId, eventId);
                }
                catch (TimeoutException)
                {
                    // show TimeoutException 
                    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
                    this.Hide();
                }
                catch (FaultException<WcfServiceFault> ex)
                {
                    // show FaultException
                    MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                    this.Hide();
                }
                catch (FaultException ex)
                {
                    // FaultException
                    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "FaultExceptionMessage")
                            + Environment.NewLine + Environment.NewLine
                            + ex.Message);
                    this.Hide();
                }
                catch (CommunicationException)
                {
                    // CommunicationException
                    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "CommunicationExceptionMessage"));
                    this.Hide();
                }
            }
            return list;
        }

        /// <summary>
        /// Load member dua vao memberId
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        private Member LoadMember(long memberId)
        {
            Member member = new Member();

            // kiem tra memberId
            if (memberId > 0)
            {
                try
                {
                    // GetMemberById
                    member = OrganizationFactory.Instance.GetChannel().GetMemberById(StorageService.CurrentSessionId, memberId);
                }
                catch (TimeoutException)
                {
                    // show TimeoutException 
                    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
                    this.Hide();
                }
                catch (FaultException<WcfServiceFault> ex)
                {
                    // show FaultException
                    MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                    this.Hide();
                }
                catch (FaultException ex)
                {
                    // FaultException
                    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "FaultExceptionMessage")
                            + Environment.NewLine + Environment.NewLine
                            + ex.Message);
                    this.Hide();
                }
                catch (CommunicationException)
                {
                    // CommunicationException
                    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "CommunicationExceptionMessage"));
                    this.Hide();
                }
            }
            return member;
        }

        /// <summary>
        /// load sub org by suborgid
        /// </summary>
        /// <param name="subOrgId"></param>
        /// <returns></returns>
        private SubOrganization GetSubOrgList(long subOrgId)
        {
            SubOrganization subOrg = new SubOrganization();
            try
            {
                // GetSubOrgById
                subOrg = OrganizationFactory.Instance.GetChannel().GetSubOrgById(StorageService.CurrentSessionId, subOrgId);
            }
            catch (TimeoutException)
            {
                // TimeoutException
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                // WcfServiceFault
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
            }
            catch (FaultException ex)
            {
                // FaultException
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "FaultExceptionMessage")
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
            }
            catch (CommunicationException)
            {
                // CommunicationException
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "CommunicationExceptionMessage"));
            }
            return subOrg;
        }

        /// <summary>
        /// get list member
        /// </summary>
        /// <returns></returns>
        private List<MemberCustomerDTO> GetMemberList(long orgId, long subOrgId)
        {
            MemberFilter filter = new MemberFilter();
            // neu sudung button load member
            if (isLoadMember)
                filter = ToMemberFilter();

            List<MemberCustomerDTO> list = new List<MemberCustomerDTO>();
            try
            {
                // GetMemberList
                list = OrganizationFactory.Instance.GetChannel().GetMemberList(StorageService.CurrentSessionId, orgId, subOrgId, filter);
            }
            catch (TimeoutException)
            {
                // TimeoutException
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                // WcfServiceFault
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
            }
            catch (FaultException ex)
            {
                // FaultException
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "FaultExceptionMessage")
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
            }
            catch (CommunicationException)
            {
                // CommunicationException
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "CommunicationExceptionMessage"));
            }
            return list;
        }

        /// <summary>
        /// ham loc ra cac MemberCustomerDTO co trong su kien 
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        private List<MemberCustomerDTO> GetMemberList(long eventId)
        {
            // khai bao
            List<EventMember> listEventMember = LoadEventMember(eventId);
            List<MemberCustomerDTO> listMember = GetMemberList(orgId, subOrgId);
            List<MemberCustomerDTO> listMemberResult = new List<MemberCustomerDTO>();

            // duyet tren listMember
            foreach (MemberCustomerDTO member in listMember)
            {
                // neu member co thuoc su kien do khong 
                // neu thuoc su kien thi add vao list: listMemberResult
                if (isConstantMember(member.Member.Id) != -1)
                {
                    // add vao listMemberResult
                    listMemberResult.Add(member);
                }
            }
            return listMemberResult;

        }
        #endregion

        #region event 

        /// <summary>
        /// OnButtonConfirmClicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonConfirmClicked(object sender, EventArgs e)
        {
            // kiem tra OperatingMode 
            switch (OperatingMode)
            {
                // neu la ModeAdding thuc hien add member
                case ModeAdding:
                    AddEventMemberList();
                    break;

                // neu la ModeDeleting thuc hien xoa member
                case ModeDeleting:
                    DeleteEventMemberList();
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// AddEventMemberList
        /// </summary>
        private void AddEventMemberList()
        {
            // run bgwAddEventMemberList
            if (!bgwAddEventMemberList.IsBusy)
            {
                bgwAddEventMemberList.RunWorkerAsync();
            }
        }
        /// <summary>
        /// DeleteEventMemberList
        /// </summary>
        private void DeleteEventMemberList()
        {
            // run bgwDeleteEventMemberList
            if (!bgwDeleteEventMemberList.IsBusy)
            {
                bgwDeleteEventMemberList.RunWorkerAsync();
            }
        }
             
        /// <summary>
        /// OnButtonCancelClicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonCancelClicked(object sender, EventArgs e)
        {
            // hide
            Hide();
        }

        #endregion

        /// <summary>
        /// FormMemberOfSubOrg_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMemberOfSubOrg_Load(object sender, EventArgs e)
        {
            InitializeControl(orgId, subOrgId);

            // neu OperatingMode == ModeAdding
            // hien chuot phai Add
            // an chuot phai Delete
            if (OperatingMode == ModeAdding)
            {
                lblInfoAdd.Visible = true;
                lblInfoDelete.Visible = false;
            }

            // neu OperatingMode == ModeDeleting
            // an chuot phai Add
            // hien chuot phai Delete
            if (OperatingMode == ModeDeleting)
            {
                lblInfoAdd.Visible = false;
                lblInfoDelete.Visible = true;
            }

            // set rm
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);

            // set label
            setAllLabel();

            // date
            Event eventObj = OnLoadEvent(eventId);
            date = DateTime.Parse(eventObj.dateIn);
        }

        /// <summary>
        /// load event
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private Event OnLoadEvent(long id)
        {
            Event timeEvent = null;
            try
            {
                // getEventById
                timeEvent = TimeKeepingEventFactory.Instance.GetChannel().getEventById(StorageService.CurrentSessionId, id);
            }
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
            }
            catch (FaultException ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "FaultExceptionMessage")
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
            }
            catch (CommunicationException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "CommunicationExceptionMessage"));
            }
            return timeEvent;
        }

        #region init for languages

        /// <summary>
        /// setAllLabel
        /// </summary>
        private void setAllLabel()
        {
            this.colCode.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colCode.Name);
            this.colName.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colName.Name);
            this.colPhone.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPhone.Name);
            this.colCmnd.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colCmnd.Name);
            this.colEmail.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colEmail.Name);

            // MaxLength cua tbxCode
            this.tbxCode.MaxLength = ConstantsValue.MAX_LENGTH_TEXT_BOX_VAR_CHAR;
        }
        #endregion

        /// <summary>
        /// kiem tra trung su kien 
        /// </summary>
        /// <param name="listEventMember"></param>
        /// <param name="eventId"></param>
        /// <returns></returns>
        private List<Member> checkEventConflict(List<EventMember> listEventMember, long eventId)
        {
            int size = listEventMember.Count;
            List<long> listId = new List<long>();

            // tu listEventMember tao thanh list member id 
            for (int i = 0; i < size; i++)
            {
                listId.Add(listEventMember[i].memberId);
            }
            return TimeKeepingEventFactory.Instance.GetChannel().checkConflictEvent(
                storageService.CurrentSessionId, listId, eventId, date.ToString("yyyy-MM-dd"));
        }

        /// <summary>
        /// tbxCode_TextChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxCode_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dtbMemberList);
            string strData = FormatCharacterSearch.CheckValue(tbxCode.Text.Trim());
            dv.RowFilter = string.Format("colName LIKE'%{0}%'", strData);

            // gan DataSource
            dgvMemberListEvent.DataSource = dv;
        }


    }
}
