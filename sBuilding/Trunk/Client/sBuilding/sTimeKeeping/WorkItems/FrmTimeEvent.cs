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
using System.Drawing;
using System.Resources;
using System.ServiceModel;
using System.Windows.Forms;

namespace sTimeKeeping.WorkItems
{
    /// <summary>
    /// class FrmTimeEvent : CommonControls.Custom.CommonDialog
    /// </summary>
    public partial class FrmTimeEvent : CommonControls.Custom.CommonDialog
    {
        #region Properties

        // const
        public const byte ModeAdding = 1;
        public const byte ModeUpdating = 2;
        public const byte ModeDetail = 3;

        // Set MaxWight TxtName
        private const int SetMaxWightTxtName = 323;

        // Properties
        private byte OperatingMode;
        private long eventId;

        //orgId dung de them vao bang timeconfig du lieu duoc gui tu usercontroll qua
        private long orgId;
        private long subOrgId;

        private List<EventMember> eventMemberList = new List<EventMember>();
        private Event eventObject = null;
        private ResourceManager rm;
        private DataTable dtbMemberList;
        private bool isLoadMember = false;

        // BackgroundWorker
        private BackgroundWorker bgwAddEvent;
        private BackgroundWorker bgwUpdateEvent;
        private BackgroundWorker bgwAddEventMemberList;
        private BackgroundWorker bgwDeleteEventMemberList;

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

        /// <summary>
        /// contructor FrmTimeEvent
        /// </summary>
        /// <param name="operationMode"></param>
        /// <param name="orgId"></param>
        /// <param name="subOrgId"></param>
        /// <param name="eventId"></param>
        public FrmTimeEvent(byte operationMode, long orgId, long subOrgId, long eventId)
        {
            // init
            InitializeComponent();
            InitDataTableMember();
            RegisterEvent();

            // gan bien
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
            // Create BackgroundWorker Event
            CreateBackgroundWorkerEvent();

            // su kien co button
            btnAccept.Click += OnButtonConfirmClicked;
            btnClose.Click += OnButtonCancelClicked;
            btnReload.Click += OnButtonRefreshClicked;
        }
        #endregion

        #region initialization data

        /// <summary>
        /// setReadOnlyRow: set read only va set mau Orange cho cac member co ten trong su kien
        /// </summary>
        private void setReadOnlyRow()
        {
            DataGridViewRowCollection list = dgvMemberListEvent.Rows;

            //20170306 Bug #750 [sTimeKeeping] Them su kien_Function - Trang Vo Start
            // kiểm tra tổ chức có danh sách người chưa
            if (dgvMemberListEvent.RowCount > 0 && list.Count < 1)
                MessageBoxManager.ShowWarningMessageBox(this, MessageValidate.GetMessage(rm, "NotRowSelected"), false);
            //20170306 Bug #750 [sTimeKeeping] Them su kien_Function - Trang Vo End

            else
            {
                // for dgvMemberListEvent.Rows
                foreach (DataGridViewRow row in list)
                {
                    // neu Cells[colEventMemberId.DataPropertyName].Value co gia tri => member da co eventmember id => member co trong su kien
                    if (row.Cells[colEventMemberId.DataPropertyName].Value.ToString() != String.Empty)
                    {
                        row.Dispose();

                        // duyet tren Cells.Count
                        for (int i = 0; i < row.Cells.Count; i++)
                        {
                            row.Cells[i].Style.BackColor = System.Drawing.Color.Orange;// can tim mau: #9E9E9E
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Init Data To Control
        /// </summary>
        /// <param name="timeConfig"></param>
        private void InitDataToControl(long timeEventId)
        {
            if (timeEventId <= 0)
                eventObject = null;
            else
            {
                // load event Object
                eventObject = OnLoadEvent(timeEventId);

                //TODO set event Object cho cac truong hien thi
                tbxName.Text = eventObject.eventName + "";
                dtpDateIn.Text = eventObject.dateIn + "";
                txtHour.Text = eventObject.hourEventKeeping + "";
                tbxDescription.Text = eventObject.description;
                string[] time = eventObject.hourEventBegin.Split(':');
                numericHour.Value = int.Parse(time[0]);
                numericMinutes.Value = int.Parse(time[1]);

                // load eventmember vao table 
                loadMemberToTable(eventObject.eventId);
            }
        }
        /// <summary>
        /// load Member To Table
        /// </summary>
        /// <param name="eventId"></param>
        private void loadMemberToTable(long eventId)
        {
            // clear empty dtbMemberList
            dtbMemberList.Clear();

            // load member to table
            List<EventMember> emList = LoadEventMember(eventId);
            if (null != emList && emList.Count != 0)
            {
                long eventMemberId = -1;
                foreach (EventMember eMember in emList)
                {
                    Member member = LoadMember(eMember.memberId);

                    // new row 
                    DataRow row = dtbMemberList.NewRow();

                    // BeginEdit
                    row.BeginEdit();
                    row[colId.DataPropertyName] = member.Id;
                    row[colCode.DataPropertyName] = member.Code;
                    row[colName.DataPropertyName] = member.LastName + " " + member.FirstName;
                    row[colPhone.DataPropertyName] = member.PhoneNo;
                    row[colCmnd.DataPropertyName] = member.IdentityCard;
                    row[colEmail.DataPropertyName] = member.Email;

                    // kiem tra event member co la member thuoc su kien khong?
                    eventMemberId = isConstantMember(member.Id);

                    // neu eventMemberId != -1: member thuoc su kien => set gia  tri cho cot colEventMemberId
                    if (eventMemberId != -1)
                    {
                        row[colEventMemberId.DataPropertyName] = eventMemberId;
                    }

                    // EndEdit
                    row.EndEdit();

                    // Add
                    dtbMemberList.Rows.Add(row);
                }
                //focur the first row in table
                dgvMemberListEvent.Rows[0].Selected = true;
            }
        }

        /// <summary>
        /// Init Data Table TimeConfig
        /// </summary>
        private void InitDataTableMember()
        {
            // khi tao dtbMemberList
            dtbMemberList = new DataTable();
            dtbMemberList.Columns.Add(colId.DataPropertyName);
            dtbMemberList.Columns.Add(colEventMemberId.DataPropertyName);
            dtbMemberList.Columns.Add(colCode.DataPropertyName);
            dtbMemberList.Columns.Add(colName.DataPropertyName);
            dtbMemberList.Columns.Add(colPhone.DataPropertyName);
            dtbMemberList.Columns.Add(colCmnd.DataPropertyName);
            dtbMemberList.Columns.Add(colEmail.DataPropertyName);

            // gan DataSource
            dgvMemberListEvent.DataSource = dtbMemberList;
        }
        /// <summary>
        /// Initialize Data to Table
        /// </summary>
        private void InitializeDataTable(List<MemberCustomerDTO> memberlist)
        {
            // xoa bang truoc khi init
            dtbMemberList.Clear();
            if (memberlist != null && memberlist.Count != 0)
            {
                long eventMemberId = -1;
                foreach (MemberCustomerDTO member in memberlist)
                {
                    //neu thanh vien chua co the thi khong hien thi len bang
                    //if (null == member.PersoCard)
                    //{
                    //    continue;
                    //}

                    // khong hien bao chi
                    if (member.Member.Title == ConstantsValue.TITLE_BAO_CHI)
                        continue;

                    // tao new row
                    DataRow row = dtbMemberList.NewRow();

                    // BeginEdit
                    row.BeginEdit();
                    row[colId.DataPropertyName] = member.Member.Id;
                    row[colCode.DataPropertyName] = member.Member.Code;
                    row[colName.DataPropertyName] = member.Member.LastName + " " + member.Member.FirstName;
                    row[colPhone.DataPropertyName] = member.Member.PhoneNo;
                    row[colCmnd.DataPropertyName] = member.Member.IdentityCard;
                    row[colEmail.DataPropertyName] = member.Member.Email;

                    // kiem tra event member co la member thuoc su kien khong?
                    eventMemberId = isConstantMember(member.Member.Id);

                    // neu eventMemberId != -1: member thuoc su kien => set gia  tri cho cot colEventMemberId
                    if (eventMemberId != -1)
                    {
                        row[colEventMemberId.DataPropertyName] = eventMemberId;
                    }

                    // EndEdit
                    row.EndEdit();

                    // Add
                    dtbMemberList.Rows.Add(row);
                }

                //focur the first row in table
                dgvMemberListEvent.Rows[0].Selected = true;

            }
        }
        #endregion

        #region Buttons event

        /// <summary>
        /// On Button Confirm Clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonConfirmClicked(object sender, EventArgs e)
        {
            switch (OperatingMode)
            {
                // ModeAdding
                case ModeAdding:
                    AddTimeConfig();
                    break;

                // ModeUpdating
                case ModeUpdating:

                    // UpdateTimeConfig
                    UpdateTimeConfig();

                    break;
                default:
                    break;
            }

        }
        /// <summary>
        /// Add Time Config
        /// </summary>
        private void AddTimeConfig()
        {
            eventObject = ToEntity();
            // neu eventObjectList == null: khong chay bgWorker
            if (null == eventObject)
                return;

            if (MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetMessage(rm, "AddEventQues")) == System.Windows.Forms.DialogResult.Yes)
            {
                // run bgwAddEvent
                if (!bgwAddEvent.IsBusy)
                {
                    bgwAddEvent.RunWorkerAsync();
                }
            }
        }

        /// <summary>
        /// Update Time Config
        /// </summary>
        private void UpdateTimeConfig()
        {
            eventObject = ToEntity();
            // neu eventObjectList == null: khong chay bgWorker
            if (null == eventObject)
                return;
            if (MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetMessage(rm, "UpdateEventQues")) == System.Windows.Forms.DialogResult.Yes)
            {
                // run bgwUpdateEvent
                if (!bgwUpdateEvent.IsBusy)
                {
                    bgwUpdateEvent.RunWorkerAsync();
                }
            }
        }

        /// <summary>
        /// On Button Refresh Clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonRefreshClicked(object sender, EventArgs e)
        {
            ClearEmptyControl();
            //20170305 Bug #749 [sTimeKeeping] Them su kien_Layout - Trang Vo Start
            numericHour.Value = 8;
            //20170305 Bug #749 [sTimeKeeping] Them su kien_Layout - Trang Vo End
        }

        /// <summary>
        /// On Button Cancel Clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonCancelClicked(object sender, EventArgs e)
        {
            this.Hide();
        }

        #endregion

        #region Event's support

        /// <summary>
        /// tao doi tuong event luu xuong database
        /// </summary>
        /// <returns></returns>
        private Event ToEntity()
        {
            // khai bao
            string name = tbxName.Text;
            string date = dtpDateIn.Text;
            string hourBegin = numericHour.Value.ToString();
            string minuteBegin = numericMinutes.Value.ToString();
            string hourKeeping = txtHour.Text;

            // neu cac truong du lieu rong => thong bao cac truong khong duoc de trong
            if (!("" != name && "" != date && "" != hourBegin && "" != minuteBegin && "" != hourKeeping))
            {
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "NullValue"));
                return null;
            }
            Event eventConfig = new Event();

            // kiem tra eventId
            if (eventId > 0)
                eventConfig.eventId = eventId;

            // gan gia tri cho eventConfig
            // eventName
            eventConfig.eventName = name;

            // dateIn
            String strdatein = dtpDateIn.Value.Year + "-" + dtpDateIn.Value.Month + "-" + dtpDateIn.Value.Day;
            eventConfig.dateIn = strdatein;

            // hourEventBegin
            int minute = (int)numericMinutes.Value;
            int hour = (int)numericHour.Value;
            eventConfig.hourEventBegin = (hour < 10 ? "0" + hour : hour + String.Empty) + ":" + (minute < 10 ? "0" + minute : minute + String.Empty);
            
            // #
            eventConfig.orgId = orgId;
            eventConfig.subOrgId = subOrgId;
            eventConfig.hourEventKeeping = int.Parse(hourKeeping);
            eventConfig.description = tbxDescription.Text;

            return eventConfig;

        }
        /// <summary>
        /// to eventmember list
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        private List<EventMember> ToEventMember(long eventId)
        {
            List<EventMember> evmber = new List<EventMember>();
            DataGridViewSelectedRowCollection list = dgvMemberListEvent.SelectedRows;

            // neu count < 1 => khong co row nao duoc select
            //20170306 Bug #750 [sTimeKeeping] Them su kien_Function - Trang Vo Start
            // kiểm tra tổ chức có danh sách người chưa

            if (dgvMemberListEvent.RowCount > 0 && list.Count < 1)
                MessageBoxManager.ShowWarningMessageBox(this, MessageValidate.GetMessage(rm, "NotRowSelected"), false);
            //20170306 Bug #750 [sTimeKeeping] Them su kien_Function - Trang Vo End

            else
            {
                EventMember eventMember;

                // for tren SelectedRows, add eventmember vao evmber
                foreach (DataGridViewRow row in list)
                {
                    // set new eventMember
                    eventMember = new EventMember();
                    long memId = (Int64.Parse(row.Cells[colId.DataPropertyName].Value.ToString()));
                    eventMember.eventId = eventId;
                    eventMember.memberId = memId;
                    eventMember.memberName = row.Cells[colName.DataPropertyName].Value.ToString();

                    // add 
                    evmber.Add(eventMember);
                }
            }
            return evmber;
        }

        /// <summary>
        ///  reset data in form to default
        /// </summary>
        private void ClearEmptyControl()
        {
            tbxName.Text = String.Empty;
            dtpDateIn.Value = DateTime.Now;
            txtHour.Text = String.Empty;
            tbxDescription.Text = String.Empty;
            numericHour.Value = 0;
            numericMinutes.Value = 0;
        }
        /// <summary>
        /// enableControl
        /// </summary>
        private void enableControl()
        {
            tbxName.Enabled = false;
            dtpDateIn.Enabled = false;
            txtHour.Enabled = false;
            tbxDescription.Enabled = false;
            numericHour.Enabled = false;
            numericMinutes.Enabled = false;
            //dgvMemberListEvent.Enabled = false;
            label121.Visible = lblInfoAdd.Visible = false;
        }

        /// <summary>
        /// to member filter 
        /// </summary>
        /// <returns></returns>
        private MemberFilter ToMemberFilter()
        {
            MemberFilter memberFilter = new MemberFilter();
            if (tbxCode.Text.Trim() != String.Empty)
            {
                memberFilter.FilterByMemberName = true;
                memberFilter.MemberName = tbxCode.Text.Trim();
            }
            return memberFilter;
        }

        /// <summary>
        /// checkEventConflict: kiem tra trung su kien
        /// </summary>
        /// <param name="listEventMember"></param>
        /// <param name="eventId"></param>
        /// <returns></returns>
        private List<Member> checkEventConflict(List<EventMember> listEventMember, long eventId)
        {
            int size = listEventMember.Count;
            List<long> listId = new List<long>();
            // tao list member id
            for (int i = 0; i < size; i++)
            {
                // add 
                listId.Add(listEventMember[i].memberId);
            }
            return TimeKeepingEventFactory.Instance.GetChannel().checkConflictEvent(
                storageService.CurrentSessionId, listId, eventId, dtpDateIn.Value.ToString("yyyy-MM-dd"));
        }
        #endregion

        #region Load data of server

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

        /// <summary>
        /// load event_member dua vao event id
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        private List<EventMember> LoadEventMember(long eventId)
        {
            List<EventMember> list = new List<EventMember>();

            // eventId > 0
            if (eventId > 0)
            {
                try
                {
                    // get EventMember List By EventId
                    list = TimeKeepingEventFactory.Instance.GetChannel().getEventMemberListByEventId(StorageService.CurrentSessionId, eventId);
                }
                catch (TimeoutException)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
                    this.Hide();
                }
                catch (FaultException<WcfServiceFault> ex)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                    this.Hide();
                }
                catch (FaultException ex)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "FaultExceptionMessage")
                            + Environment.NewLine + Environment.NewLine
                            + ex.Message);
                    this.Hide();
                }
                catch (CommunicationException)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "CommunicationExceptionMessage"));
                    this.Hide();
                }
            }
            return list;
        }

        /// <summary>
        /// get list member dua vao orgid, suborgid
        /// </summary>
        /// <param name="subOrgId"></param>
        /// <returns></returns>
        private List<MemberCustomerDTO> GetMemberList(long orgId, long subOrgId)
        {
            MemberFilter filter = new MemberFilter();
            // neu su dung button load member
            if (isLoadMember)
                filter = ToMemberFilter();
            filter.Active = true;
            List<MemberCustomerDTO> list = new List<MemberCustomerDTO>();
            try
            {
                // Get Member List
                list = OrganizationFactory.Instance.GetChannel().GetMemberList(StorageService.CurrentSessionId, orgId, subOrgId, filter);
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
            if (memberId > 0)
            {
                try
                {
                    // Get Member By Id
                    member = OrganizationFactory.Instance.GetChannel().GetMemberById(StorageService.CurrentSessionId, memberId);
                }
                catch (TimeoutException)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
                    this.Hide();
                }
                catch (FaultException<WcfServiceFault> ex)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                    this.Hide();
                }
                catch (FaultException ex)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "FaultExceptionMessage")
                            + Environment.NewLine + Environment.NewLine
                            + ex.Message);
                    this.Hide();
                }
                catch (CommunicationException)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "CommunicationExceptionMessage"));
                    this.Hide();
                }
            }
            return member;
        }
        #endregion

        #region load

        /// <summary>
        /// FrmTimeEvent_Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmTimeEvent_Load(object sender, EventArgs e)
        {
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);

            //load data
            InitLabel();

            //load member khi add event
            if (OperatingMode == ModeAdding)
            {
                this.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "AddEventFrm");
                List<MemberCustomerDTO> memberlist = GetMemberList(orgId, subOrgId);
                InitializeDataTable(memberlist);

                // TextChanged
                tbxCode.TextChanged += tbxCode_TextChanged;
                //20170305 Bug #749 [sTimeKeeping] Them su kien_Layout - Trang Vo Start
                numericHour.Value = 8;
                //20170305 Bug #749 [sTimeKeeping] Them su kien_Layout - Trang Vo End

                // key down enter
                cmsMemberRecord.Enabled = false;
            }

            //load event khi update event 
            if (OperatingMode == ModeUpdating)
            {
                this.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "UpdateEventFrm");
                InitDataToControl(eventId);

                //visible button add & delete
                btnAddMemEvent.Visible = true;
                btnDelMemEvent.Visible = true;
                btnLoadUpdate.Visible = true;

                // TextChanged
                tbxCode.TextChanged += tbxCode_TextChanged;

                //su kien chuot phai
                initializeBgWorker();
                cmsMemberRecord.Enabled = true;
            }

            //load event va enable datatable khi view deltail
            if (OperatingMode == ModeDetail)
            {
                this.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "ViewEventFrm");
                InitDataToControl(eventId);
                enableControl();
                cmsMemberRecord.Enabled = false;
                tbxCode.Enabled = false;
                btnReload.Visible = btnAccept.Visible = false;

            }
        }
        /// <summary>
        /// init header text 
        /// </summary>
        private void InitLabel()
        {
            this.lblInfoAdd.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblInfoAdd.Name);
            this.colCode.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colCode.Name);
            this.colName.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colName.Name);
            this.colPhone.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPhone.Name);
            this.colCmnd.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colCmnd.Name);
            this.colEmail.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colEmail.Name);

            this.tbxName.MaxLength = ConstantsValue.MAX_LENGTH_TEXT_BOX_VAR_CHAR;
            this.txtHour.MaxLength = ConstantsValue.MAX_LENGTH_TEXT_BOX_VAR_CHAR;
            this.tbxCode.MaxLength = ConstantsValue.MAX_LENGTH_TEXT_BOX_VAR_CHAR;
            this.tbxDescription.MaxLength = ConstantsValue.MAX_LENGTH_TEXT_BOX_VAR_CHAR;
        }
        #endregion

        #region bgWorker
        /// <summary>
        ///  dang ky su kien cho bgWWorker
        /// </summary>
        private void CreateBackgroundWorkerEvent()
        {
            //add event
            bgwAddEvent = new BackgroundWorker();
            bgwAddEvent.WorkerSupportsCancellation = true;
            bgwAddEvent.DoWork += bgwAddEvent_DoWork;
            bgwAddEvent.RunWorkerCompleted += bgwAddEvent_RunWorkerCompleted;

            //update event
            bgwUpdateEvent = new BackgroundWorker();
            bgwUpdateEvent.WorkerSupportsCancellation = true;
            bgwUpdateEvent.DoWork += bgwUpdateEvent_DoWork;
            bgwUpdateEvent.RunWorkerCompleted += bgwUpdateEvent_RunWorkerCompleted;
        }
        /// <summary>
        /// bgwAddEvent_DoWork
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwAddEvent_DoWork(object sender, DoWorkEventArgs e)
        {
            Event result = null;
            try
            {
                 //20170306 Bug #750 [sTimeKeeping] Them su kien_Function - Trang Vo Start
            // kiểm tra tổ chức có danh sách người chưa và đã chọn người tham gia su kien chưa
                if (dgvMemberListEvent.RowCount > 0 && dgvMemberListEvent.SelectedRows.Count >= 1)
                {
                    //ham nay insert event va eventmember xuong databases
                    result = TimeKeepingEventFactory.Instance.GetChannel().insertEvent(storageService.CurrentSessionId, eventObject);
                    if (null != result)
                    {
                        List<EventMember> listEventMember = ToEventMember(result.eventId);

                        //truoc khi insert xuong database, kiem tra danh sach member xem co nguoi nao trung lich hop hay khong?
                        List<Member> list = checkEventConflict(listEventMember, result.eventId);
                        if (null != list && list.Count > 0)
                        {
                            //if(MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetMessage(rm, "AddEventQues")) == System.Windows.Forms.DialogResult.Yes
                            string listMemberShow = string.Empty;
                            for (int i = 0; i < list.Count; i++)
                            {
                                listMemberShow += list[i].LastName + " " + list[i].FirstName + " ,";
                            }
                            listMemberShow = listMemberShow.Substring(0, listMemberShow.Length - 1);
                            MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "conflictEvent") + ": " + listMemberShow);
                        }
                        e.Result = TimeKeepingEventFactory.Instance.GetChannel().insertListEventMember(storageService.CurrentSessionId, listEventMember);
                    }
                }else
                {
                    // show thông báo khi tổ chức chưa có danh sách người và chưa chọn người tham gia su kien 
                    if (dgvMemberListEvent.RowCount <= 0)
                    {
                        MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "NotExistMember"));
                    }
                    if (dgvMemberListEvent.SelectedRows.Count <= 0)
                    {
                        MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "NotRowSelected"));
                    }
                }
                //20170306 Bug #750 [sTimeKeeping] Them su kien_Function - Trang Vo End
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
        }

        /// <summary>
        /// bgwAddEvent_RunWorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwAddEvent_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled ||e.Result == null)
            {
                return;
            }
            if ((Int32)e.Result == 0)
            {
                List<long> idList = new List<long>();

                // tao listEventMember dua vao eventid 
                List<EventMember> listEventMember = ToEventMember(eventObject.eventId);
                foreach (EventMember evLong in listEventMember)
                {
                    idList.Add(evLong.memberId);
                }

                //ham dung de tinh toan lai status cua ngay 
                TimeKeepingFactory.Instance.GetChannel().insertOrUpdateMonthlyReport(storageService.CurrentSessionId,
                               dtpDateIn.Value.ToString("yyyy-MM-dd"), dtpDateIn.Value.ToString("yyyy-MM-dd"), idList);

                //MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "InsertSuccess"));
                Hided();
            }
            else
            {
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "InsertFail"));
            }
        }

        /// <summary>
        /// bgwUpdateEvent_DoWork
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwUpdateEvent_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                //20170306 Bug #750 [sTimeKeeping] Them su kien_Function - Trang Vo Start
                // kiểm tra tổ chức có danh sách người chưa và đã chọn người tham gia su kien chưa
                if (dgvMemberListEvent.RowCount > 0 && dgvMemberListEvent.SelectedRows.Count > 0)
                {

                    //ham nay update time event xuong databases
                    e.Result = TimeKeepingEventFactory.Instance.GetChannel().updateEvent(storageService.CurrentSessionId, eventObject);
                }
                else
                {
                    // show thông báo khi tổ chức chưa có danh sách người và chưa chọn người tham gia su kien 
                    if (dgvMemberListEvent.RowCount <= 0)
                    {
                        MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "NotExistMember"));
                    }
                    if (dgvMemberListEvent.SelectedRows.Count <= 0)
                    {
                        MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "NotRowSelected"));
                    }
                }
                //20170306 Bug #750 [sTimeKeeping] Them su kien_Function - Trang Vo End
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
        }

        /// <summary>
        /// bgwUpdateEvent_RunWorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwUpdateEvent_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled || null == e.Result)
            {
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "InsertFailed"));
                return;
                
            }
            if ((Int32)e.Result == 0)
            {
                List<long> idList = new List<long>();

                // tao List<EventMember> dua vao eventId
                List<EventMember> listEventMember = ToEventMember(eventObject.eventId);
                foreach (EventMember evLong in listEventMember)
                {
                    idList.Add(evLong.memberId);
                }

                //ham dung de tinh toan lai status cua ngay 
                TimeKeepingFactory.Instance.GetChannel().insertOrUpdateMonthlyReport(storageService.CurrentSessionId,
                               dtpDateIn.Value.ToString("yyyy-MM-dd"), dtpDateIn.Value.ToString("yyyy-MM-dd"), idList);
                //MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "InsertSuccess"));

                Hided();
            }
            else
            {
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "InsertFailed"));
            }
        }

        /// <summary>
        /// Hide the form
        /// </summary>
        private void Hided()
        {
            Hide();
        }

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
                // tao List<EventMember>
                eventMemberList = InitEventMemberList();
                if (null != eventMemberList && eventMemberList.Count != 0)
                {
                    //truoc khi insert xuong database, kiem tra danh sach member xem co nguoi nao trung lich hop hay khong?
                    List<Member> lists = checkEventConflict(eventMemberList, eventId);
                    if (null != lists && lists.Count > 0)
                    {
                        string listMemberShow = string.Empty;

                        // duyet list
                        for (int i = 0; i < lists.Count; i++)
                        {
                            listMemberShow += lists[i].LastName + " " + lists[i].FirstName + " ,";
                        }
                        listMemberShow = listMemberShow.Substring(0, listMemberShow.Length - 1);
                        MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "conflictEvent") + ": " + listMemberShow);
                    }

                    //ham nay insert eventmember xuong databases
                    result = TimeKeepingEventFactory.Instance.GetChannel().insertListEventMember(storageService.CurrentSessionId, eventMemberList);
                    e.Result = result;
                }
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
        }

        /// <summary>
        /// bgwAddEventMemberList_RunWorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwAddEventMemberList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if ((int)e.Result == 0)
            {
                List<long> idList = new List<long>();

                // tao List<EventMember> dua vao eventId
                List<EventMember> listEventMember = ToEventMember(eventObject.eventId);
                foreach (EventMember evLong in listEventMember)
                {
                    idList.Add(evLong.memberId);
                }

                //ham dung de tinh toan lai status cua ngay 
                TimeKeepingFactory.Instance.GetChannel().insertOrUpdateMonthlyReport(storageService.CurrentSessionId,
                               dtpDateIn.Value.ToString("yyyy-MM-dd"), dtpDateIn.Value.ToString("yyyy-MM-dd"), idList);
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
            // tao list long eventmemberid can xoa
            List<long> eventMemberListId = ToListLongEventMember();
            int result = -1;
            try
            {
                result = TimeKeepingEventFactory.Instance.GetChannel().deleteEventMemberList(storageService.CurrentSessionId, eventMemberListId);
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
            if (e.Cancelled)
            {
                return;
            }
            if ((int)e.Result == 0)
            {
                List<long> idList = new List<long>();

                // tao listEventMember dua vao eventid
                List<EventMember> listEventMember = ToEventMember(eventObject.eventId);
                foreach (EventMember evLong in listEventMember)
                {
                    idList.Add(evLong.memberId);
                }

                //ham dung de tinh toan lai status cua ngay 
                TimeKeepingFactory.Instance.GetChannel().insertOrUpdateMonthlyReport(storageService.CurrentSessionId,
                               dtpDateIn.Value.ToString("yyyy-MM-dd"), dtpDateIn.Value.ToString("yyyy-MM-dd"), idList);
                // MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "InsertSuccess"));

                Hided();
            }
            else
            {
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "InsertFailed"));
            }
        }

        #endregion

        #region cac event

        /// <summary>
        /// change data in table by TextChanged in tbxCode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxCode_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dtbMemberList);
            string strData = FormatCharacterSearch.CheckValue(tbxCode.Text.Trim());
            dv.RowFilter = string.Format("colName LIKE'%{0}%'", strData);
            dgvMemberListEvent.DataSource = dv;
        }

        /// <summary>
        /// initialize BgWorker for EventMember
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
        /// Ham nay bat su kien chuot phai
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvMemberListEvent_MouseDown(object sender, MouseEventArgs e)
        {
            // neu ton tai trong danh sach cac thanh vien cua su kien thi ko nhan chuot phai
            DataGridViewSelectedRowCollection list = dgvMemberListEvent.SelectedRows;
            //if (list.Count != 1)
            //    MessageBoxManager.ShowWarningMessageBox(this, TimeMessages.CountOfRowNotOne, false);
            //else
            //{

            // neu member khong phai la event member (member khong thuoc su kien)
            if (list[0].Cells[colEventMemberId.DataPropertyName].Value.ToString() == String.Empty)
            {
                if (e.Button == MouseButtons.Right)
                {
                    DataGridView.HitTestInfo info = dgvMemberListEvent.HitTest(e.X, e.Y);
                    if (info.RowIndex != -1)
                    {
                        if (info.RowIndex >= 0 && info.ColumnIndex >= 0)
                        {

                            // !dgvMemberListEvent.SelectedRows.Contains(dgvMemberListEvent.Rows[info.RowIndex]
                            if (!dgvMemberListEvent.SelectedRows.Contains(dgvMemberListEvent.Rows[info.RowIndex]))
                            {

                                // duyet SelectedRows
                                foreach (DataGridViewRow rows in dgvMemberListEvent.SelectedRows)
                                {
                                    rows.Selected = false;
                                }
                                dgvMemberListEvent.Rows[info.RowIndex].Selected = true;
                            }
                        }

                        // GetCellDisplayRectangle
                        Rectangle r = dgvMemberListEvent.GetCellDisplayRectangle(info.ColumnIndex, info.RowIndex, true);

                        // Show
                        cmsMemberRecord.Show((Control)sender, e.X, e.Y);
                    }
                }
            }
            //}
        }

        /// <summary>
        /// mniAddMemevent_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mniAddMemevent_Click(object sender, EventArgs e)
        {
            if (MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetMessage(rm, "AddMemberWarn")) == System.Windows.Forms.DialogResult.Yes)

                // run bgwAddEventMemberList
                if (!bgwAddEventMemberList.IsBusy)
                {
                    bgwAddEventMemberList.RunWorkerAsync();
                }
        }

        /// <summary>
        /// InitEventMemberList: tao EventMemberList 
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        private List<EventMember> InitEventMemberList()
        {
            List<EventMember> listEventMember = new List<EventMember>();
            EventMember evMember = new EventMember();
            DataGridViewSelectedRowCollection list = dgvMemberListEvent.SelectedRows;

            //20170306 Bug #750 [sTimeKeeping] Them su kien_Function - Trang Vo Start

            // kiểm tra tổ chức có danh sách người chưa
            if (dgvMemberListEvent.RowCount > 0 && list.Count < 1)
            {
                //20170306 Bug #750 [sTimeKeeping] Them su kien_Function - Trang Vo End

                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "NotRowSelected"));
                return null;
            }
            else
            {
                foreach (DataGridViewRow row in list)
                {
                    evMember = new EventMember();
                    string evMemberId = row.Cells[colEventMemberId.DataPropertyName].Value.ToString();

                    // neu member khong thuoc event thi add vao list
                    if (String.Empty == evMemberId)
                    {
                        evMember.eventId = eventId;
                        evMember.memberId = long.Parse(row.Cells[colId.DataPropertyName].Value.ToString());
                        evMember.memberName = row.Cells[colName.DataPropertyName].Value.ToString();
                        listEventMember.Add(evMember);
                    }
                }
            }
            return listEventMember;
        }

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
                // kiem tra va add vo result
                if (evMember.memberId == memberId)
                    result = evMember.eventmemberId;
            }
            return result;
        }

        /// <summary>
        /// To List Long Event Member
        /// </summary>
        /// <returns></returns>
        private List<long> ToListLongEventMember()
        {
            List<long> listEventMemberId = null;
            DataGridViewSelectedRowCollection list = dgvMemberListEvent.SelectedRows;

            //20170306 Bug #750 [sTimeKeeping] Them su kien_Function - Trang Vo Start

            // kiểm tra tổ chức có danh sách người chưa
            if (dgvMemberListEvent.RowCount > 0 && list.Count < 1)
            {
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "NotRowSelected"));
                //20170306 Bug #750 [sTimeKeeping] Them su kien_Function - Trang Vo End
            }
            else
            {
                listEventMemberId = new List<long>();
                string eventMemberId = String.Empty;

                // duyet list
                foreach (DataGridViewRow row in list)
                {
                    // add eventMemberId neu eventmember thuoc event
                    eventMemberId = row.Cells[colEventMemberId.DataPropertyName].Value.ToString();

                    // kiem tra eventMemberId != String.Empty
                    if (eventMemberId != String.Empty)
                    {
                        long evmemId = (long.Parse(eventMemberId));
                        listEventMemberId.Add(evmemId);
                    }
                }
            }
            return listEventMemberId;
        }

        /// <summary>
        /// btnAddMemEvent_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddMemEvent_Click(object sender, EventArgs e)
        {

            isLoadMember = true;
            mniAddMemevent.Enabled = true;

            // GetMemberList
            List<MemberCustomerDTO> memberlist = GetMemberList(orgId, subOrgId);

            // InitializeDataTable
            InitializeDataTable(memberlist);
            setReadOnlyRow();

            // su kien MouseDown
            dgvMemberListEvent.MouseDown += dgvMemberListEvent_MouseDown;
        }

        /// <summary>
        /// btnDelMemEvent_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelMemEvent_Click(object sender, EventArgs e)
        {
            //DataGridViewSelectedRowCollection list = dgvMemberListEvent.SelectedRows;
            //if (list.Count != 1)
            //    MessageBoxManager.ShowWarningMessageBox(this, TimeMessages.CountOfRowNotOne, false);
            //else
            //{
            if (MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetMessage(rm, "DeleteMemberWarn")) == System.Windows.Forms.DialogResult.Yes)
                if (!bgwDeleteEventMemberList.IsBusy)
                {
                    bgwDeleteEventMemberList.RunWorkerAsync();
                }
            //}

        }

        /// <summary>
        /// ham su kien quay lai danh sach nguoi tham gia su kien
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadUpdate_Click(object sender, EventArgs e)
        {
            loadMemberToTable(eventId);
        }

        #endregion
        //20170306 Bug #749 [sTimeKeeping] Them su kien_Layout - Trang Vo Start
        #region text of hour field

        /// <summary>
        /// txtHour_Leave
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtHour_Leave(object sender, EventArgs e)
        {
            TextChang();
        }

        /// <summary>
        /// TextChang
        /// </summary>
        private void TextChang()
        {
            string text = txtHour.Text.Trim();
            if (text != "")
                try
                {
                    int number = int.Parse(text);
                    if (number > 24)
                    {
                        txtHour.Text = string.Empty;
                        MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "ValidateHour"));
                    }
                }
                catch (Exception ex)
                {
                    txtHour.Text = string.Empty;
                    MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "NotParseHour"));
                }
        }

        private void txtPhoneNo_KeyPress(object sender, KeyPressEventArgs e)
        {
          //kí tự nhập vào phải là số hay ko
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
    }
        #endregion
    //20170306 Bug #749 [sTimeKeeping] Them su kien_Layout - Trang Vo End
}
