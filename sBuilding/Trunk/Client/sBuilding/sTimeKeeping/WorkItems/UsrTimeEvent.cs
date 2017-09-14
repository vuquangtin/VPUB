using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using Microsoft.Practices.CompositeUI;
using sWorldModel;
using CommonHelper.Utils;
using CommonHelper.Constants;
using Microsoft.Practices.CompositeUI.Commands;
using sTimeKeeping.Constants;
using sTimeKeeping.Model;
using sWorldModel.TransportData;
using CommonHelper.Config;
using CommonControls;
using JavaCommunication.Factory;
using sWorldModel.Exceptions;
using System.ServiceModel;
using sTimeKeeping.Factory;
using sWorldModel.Filters;
using System.Windows.Forms.VisualStyles;
using sTimeKeeping.WorkItems.EventIntegratingExcel;

namespace sTimeKeeping.WorkItems
{
    /// <summary>
    /// class UsrTimeEvent : UserControl
    /// </summary>
    public partial class UsrTimeEvent : UserControl
    {

        #region properties

        //current event id 
        public static long currentEventId = 0;

        //load list member
        private BackgroundWorker bgwLoadOrgList;
        private BackgroundWorker bgwListLoadEvent;
        private BackgroundWorker bgwDeleteEvent;
        private BackgroundWorker bgwLoadForm;

        private DataTable dtbEventList;
        private int currentPageIndex = 1;

        // Selected tree node; cache it to do some effect in UI
        private Font startupNodeFont;
        private TreeNode selectedOrgNode;
        private TreeNode rootNode;
        private List<EventDTO> listEvent;
        private long currentorgId;
        private long currentsubOrgId;
        private ResourceManager rm;
        private String treeSelectId;
        private String parentTreeSelectId;
        private long modeLoadAddOrEdit;
        private List<long> eventIdDeleteList;

        //danh cho xoa su kien
        private List<List<long>> idListDelete = new List<List<long>>();
        private List<Event> eventObjListDelete = new List<Event>();

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
        /// UsrTimeEvent contructor
        /// </summary>
        public UsrTimeEvent()
        {
            InitializeComponent();
            RegisterEvent();
            InitDataTableTimeConfig();
        }
        #endregion

        #region Form events

        /// <summary>
        /// Đăng ký sự kiện
        /// </summary>
        private void RegisterEvent()
        {
            // Tree View
            trvOrganizations.BeforeSelect += trvOrganizations_BeforeSelect;
            trvOrganizations.AfterSelect += trvOrganizations_AfterSelect;

            // Load Tree View
            bgwLoadOrgList = new BackgroundWorker();
            bgwLoadOrgList.WorkerSupportsCancellation = true;
            bgwLoadOrgList.DoWork += bgwLoadOrgList_DoWork;
            bgwLoadOrgList.RunWorkerCompleted += bgwLoadOrgList_RunWorkerCompleted;

            // Load timconfiglist by orgId
            bgwListLoadEvent = new BackgroundWorker();
            bgwListLoadEvent.WorkerSupportsCancellation = true;
            bgwListLoadEvent.DoWork += bgwEventList_DoWork;
            bgwListLoadEvent.RunWorkerCompleted += bgwEventList_RunWorkerCompleted;

            // Delete event
            bgwDeleteEvent = new BackgroundWorker();
            bgwDeleteEvent.WorkerSupportsCancellation = true;
            bgwDeleteEvent.DoWork += bgwDeleteEvent_DoWork;
            bgwDeleteEvent.RunWorkerCompleted += bgwDeleteEvent_RunWorkerCompleted;

            // Load form
            bgwLoadForm = new BackgroundWorker();
            bgwLoadForm.WorkerSupportsCancellation = true;
            bgwLoadForm.DoWork += bgwLoadForm_DoWork;
            bgwLoadForm.RunWorkerCompleted += bgwLoadForm_RunWorkerCompleted;

            // Add - Update - Deleted event
            menuAdd.Click += btnAddEvent_Click;
            menuEdit.Click += btnUpdateEvent_Click;
            menuDelete.Click += btnDeleteEvent_Click;
            menuReload.Click += btnReload_Click;
            dgvEvent.MouseDown += dgvEvents_MouseDown;
            dgvEvent.CellClick += dtbEventList_CellClick;
            tbxCode.TextChanged += tbxCode_TextChanged;

            btnRefreshOrg.Click += (s, e) => LoadOrgList();
            startupNodeFont = trvOrganizations.Font;
        }

        /// <summary>
        /// Override hàm onFormLoad 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            InitTreeList();
            LoadOrgList();

            // set label
            setAllLabel();
            pagerPanel1.StorageService = storageService;
            pagerPanel1.LoadLanguage();
        }

        #region init for languages
        /// <summary>
        /// setAllLabel
        /// </summary>
        private void setAllLabel()
        {
            this.menuAdd.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.menuAdd.Name);
            this.menuEdit.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.menuEdit.Name);
            this.menuDelete.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.menuDelete.Name);
            this.menuReload.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.mniReloadCards.Name);
            this.btnRefreshOrg.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.mniReloadCards.Name);
            this.colDetail.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colDetail.Name);
            this.colDescription.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colDescription.Name);
            this.colNumberHour.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNumberHour.Name);
            this.colTimebegin.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colTimebegin.Name);
            this.colMember.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colMember.Name);
            this.colEventName.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colEventName.Name);
            this.mniDeleteMemEvent.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.mniDeleteMemEvent.Name);
            this.mniAddMemevent.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.mniAddMemevent.Name);

            this.tbxCode.MaxLength = ConstantsValue.MAX_LENGTH_TEXT_BOX_VAR_CHAR;
        }
        #endregion
        #endregion

        #region tree

        /// <summary>
        /// Khởi tạo tree
        /// </summary>
        private void InitTreeList()
        {
            rootNode = new TreeNode();
            rootNode.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "All");
            rootNode.Name = "-1";
            trvOrganizations.Nodes.Add(rootNode);
        }

        /// <summary>
        /// Ham nay load danh sach cac to chuc vao tree, ham nay duoc load sau khi usercontroll duoc load
        /// </summary>
        private void LoadOrgList()
        {
            //set currrent event id
            currentEventId = 0;

            // run bgwLoadOrgList
            if (!bgwLoadOrgList.IsBusy)
            {
                dtbEventList.Rows.Clear();
                rootNode.Nodes.Clear();
                bgwLoadOrgList.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Ham nay dung de load danh sach timeconfig
        /// </summary>
        private void LoadEventList(string orgId, string subOrgId = "-1")
        {
            //20170305 Bug #748 [sTimeKeeping] Dang ky su kien _ Function - Trang Vo Start
            DateTime date = dtpDateEnd.Value;
            date = date.AddHours(-date.Hour + 23);
            if (date < dtpDateBegin.Value)
            {
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "DateValidate"));
            }
            else
            {
                //20170305 Bug #748 [sTimeKeeping] Dang ky su kien _ Function - Trang Vo End
                //chuyen doi orgid va suborgid tu string sang long
                this.currentorgId = Int64.Parse(orgId);
                if (subOrgId != "-1")
                    this.currentsubOrgId = long.Parse(subOrgId);
                else
                    this.currentsubOrgId = -1;

                if (!bgwListLoadEvent.IsBusy)
                {
                    dtbEventList.Rows.Clear();
                    bgwListLoadEvent.RunWorkerAsync();
                }

            }

        }

        /// <summary>
        /// set current event id
        /// </summary>
        private void setCurrentEventId()
        {
            if (currentEventId == 0)
                dgvEvent.Rows[0].Selected = true;
            else
            {
                long eventId = -1;

                // duyet
                foreach (DataGridViewRow row in dgvEvent.Rows)
                {
                    eventId = long.Parse(row.Cells[0].Value.ToString());
                    if (eventId == currentEventId)
                    {
                        dgvEvent.Rows[0].Selected = false;
                        row.Selected = true;
                    }
                }
            }
        }
        #endregion

        #region bgWorker

        /// <summary>
        /// bgwLoadOrgList_DoWork
        /// load danh sach org
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwLoadOrgList_DoWork(object sender, DoWorkEventArgs e)
        {
            List<OrgCustomerDto> result = null;

            // filter khong xet du lieu, dung mac dinh
            OrgFilterDto filter = new OrgFilterDto();
            try
            {
                // kiem tra org co duoc hien thi hay khong
                if (!((SystemSettings.Instance.OrgCode).Equals("") || (SystemSettings.Instance.OrgCode).Equals("ALL")))
                {
                    filter.OrgCode = SystemSettings.Instance.OrgCode;
                    filter.FilterByOrgCode = true;
                }

                // GetOrgList
                result = OrganizationFactory.Instance.GetChannel().GetOrgList(storageService.CurrentSessionId, filter);
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
        /// bgwLoadOrgList_RunWorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwLoadOrgList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }

            // Get result from DoWork method
            List<OrgCustomerDto> result = (List<OrgCustomerDto>)e.Result;

            // Neu result != null, load danh sach to chuc và danh sach to chuc con vao tree
            if (result != null)
            {
                foreach (OrgCustomerDto org in result)
                {
                    if (!org.Issuer.Equals(SystemSettings.Instance.Master))
                    {
                        TreeNode Node = new TreeNode();
                        Node.Text = org.Name;
                        Node.Name = Convert.ToString(org.OrgId);

                        // khong load suborg theo yeu cau moi ngay 27/09/2016

                        //if (org.SubOrgList != null)
                        //{
                        //    foreach (SubOrgCustomerDTO subOrg in org.SubOrgList)
                        //    {
                        //        TreeNode subOrgNode = new TreeNode();
                        //        subOrgNode.Text = subOrg.Name;
                        //        subOrgNode.Name = Convert.ToString(subOrg.SubOrgId);
                        //        Node.Nodes.Add(subOrgNode);
                        //    }
                        //}
                        rootNode.Nodes.Add(Node);
                    }
                }
                trvOrganizations.Sort();
                rootNode.Expand();
                dtbEventList.Clear();
            }
        }

        /// <summary>
        /// bgwEventList_DoWork
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwEventList_DoWork(object sender, DoWorkEventArgs e)
        {
            List<EventDTO> result = null;
            int totalRecords = 0;
            int take = LocalSettings.Instance.RecordsPerPage;
            int skip = 0;
            currentPageIndex = 1;
            try
            {
                // tao eventfilter
                EventFilter filter = setFilter();

                //ham lay ve list event
                //neu currentsubOrgId == -1: load danh sach event dua vao orgid
                //neu currentsubOrgId != -1: load danh sach event dua vao orgid va suborg
                if (currentsubOrgId == -1)
                    result = listEvent = TimeKeepingEventFactory.Instance.GetChannel().getEventListByOrgId(StorageService.CurrentSessionId, filter, currentorgId);
                else
                    result = listEvent = TimeKeepingEventFactory.Instance.GetChannel().getEventListBySubOrgId(StorageService.CurrentSessionId, filter, currentorgId, currentsubOrgId);
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
                List<EventDTO> resultCompact = null;

                //kiem tra result != null && result.Count != 0
                if (result != null && result.Count != 0)
                    resultCompact = createLisTEventDTO(result);

                // kiem tra resultCompact != null
                if (resultCompact != null)
                {
                    result = resultCompact.Skip(skip).Take(take).ToList();
                    totalRecords = resultCompact.Count;

                    // set label
                    pagerPanel1.ShowNumberOfRecords(totalRecords, result != null ? result.Count : 0, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                    pagerPanel1.UpdatePagingLinks(totalRecords, LocalSettings.Instance.RecordsPerPage, currentPageIndex);
                }
                e.Result = resultCompact;
            }
        }

        /// <summary>
        /// bgwEventList_RunWorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwEventList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                //20170306 Bug #750 [sTimeKeeping] Dang ky su kien _ Function - Trang Vo Start
                this.menuEdit.Enabled = this.menuDelete.Enabled = false;
                //20170306 Bug #750 [sTimeKeeping] Dang ky su kien _ Function - Trang Vo End
                return;
            }
            if (e.Result == null)
            {
                //20170306 Bug #750 [sTimeKeeping] Dang ky su kien _ Function - Trang Vo Start
                this.menuEdit.Enabled = this.menuDelete.Enabled = false;
                //20170306 Bug #750 [sTimeKeeping] Dang ky su kien _ Function - Trang Vo End
                return;
            }
            // Get result from DoWork method
            List<EventDTO> result = (List<EventDTO>)e.Result;
            LoadListTimeConfigToDataGirdView(result);
        }

        /// <summary>
        /// bgwDeleteEvent_DoWork
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwDeleteEvent_DoWork(object sender, DoWorkEventArgs e)
        {
            int result = -1;
            try
            {
                // tao list id cua cac event can xoa
                eventIdDeleteList = toListEventDelete();

                if (null != eventIdDeleteList && eventIdDeleteList.Count != 0)
                {
                    eventObjListDelete = new List<Event>();
                    idListDelete = new List<List<long>>();
                    foreach (long eventId in eventIdDeleteList)
                    {
                        Event eventObj = OnLoadEvent(eventId);
                        eventObjListDelete.Add(eventObj);

                        // tao list eventmember
                        List<EventMember> eventMemberList = LoadEventMember(eventId);
                        List<long> idList = new List<long>();
                        foreach (EventMember evLong in eventMemberList)
                        {
                            idList.Add(evLong.memberId);
                        }

                        // tao list de update status cua tinh toan cham cong cho thang 
                        idListDelete.Add(idList);
                    }

                    //ham xoa list event
                    e.Result = result = TimeKeepingEventFactory.Instance.GetChannel().deleteEventList(StorageService.CurrentSessionId, eventIdDeleteList);
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
        /// bgwDeleteEvent_RunWorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwDeleteEvent_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // e.cancel
            if (e.Cancelled)
            {
                return;
            }

            // e null
            if (e.Result == null)
            {
                return;
            }

            // e == 0
            if ((Int32)e.Result == 0)
            {
                int size = eventObjListDelete.Count;
                for (int i = 0; i < size; i++)
                {
                    DateTime date = DateTime.Parse(eventObjListDelete[i].dateIn);

                    //ham dung de tinh toan lai status cua ngay 
                    TimeKeepingFactory.Instance.GetChannel().insertOrUpdateMonthlyReport(storageService.CurrentSessionId,
                                 date.ToString("yyyy-MM-dd"), date.ToString("yyyy-MM-dd"), idListDelete[i]);
                    //MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "DeleteSuccess"));
                }
            }
            else
            {
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "DeleteFail"));
            }
            reloadTimeEvent();
        }

        /// <summary>
        /// bgwLoadForm_DoWork
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwLoadForm_DoWork(object sender, DoWorkEventArgs e)
        {
            pagerPanel1.ShowMessage(MessageValidate.GetMessage(rm, "lblLoading"));
        }

        /// <summary>
        /// bgwLoadForm_RunWorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgwLoadForm_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // load Form Add Or Edit Or Detail
            loadFormAddOrEditOrDetail(modeLoadAddOrEdit);
            pagerPanel1.ShowMessage("");
        }
        #endregion

        #region load data vao form

        /// <summary>
        /// InitDataTableTimeConfig
        /// </summary>
        private void InitDataTableTimeConfig()
        {
            dtbEventList = new DataTable();
            dtbEventList.Columns.Add(colEventId.DataPropertyName);
            dtbEventList.Columns.Add(colEventMemberId.DataPropertyName);
            dtbEventList.Columns.Add(colEventName.DataPropertyName);
            dtbEventList.Columns.Add(colDate.DataPropertyName);
            dtbEventList.Columns.Add(colTimebegin.DataPropertyName);
            dtbEventList.Columns.Add(colMember.DataPropertyName);
            dtbEventList.Columns.Add(colNumberHour.DataPropertyName);
            dtbEventList.Columns.Add(colDescription.DataPropertyName);
            dgvEvent.DataSource = dtbEventList;
        }

        /// <summary>
        /// Load du lieu vao data table
        /// </summary>
        /// <param name="orgId"></param>
        private void LoadListTimeConfigToDataGirdView(List<EventDTO> listEvent)
        {
            if (null != listEvent && listEvent.Count != 0)
            {
                for (int i = 0; i < listEvent.Count; i++)
                {
                    DataRow row = dtbEventList.NewRow();
                    row.BeginEdit();
                    row[colEventId.DataPropertyName] = listEvent[i].eventObj.eventId;
                    row[colEventName.DataPropertyName] = listEvent[i].eventObj.eventName;
                    string date = (listEvent[i].eventObj.dateIn).Substring(0, 10);
                    string y = date.Substring(0, 4);
                    string m = date.Substring(5, 2);
                    string d = date.Substring(8, 2);
                    row[colDate.DataPropertyName] = date.Substring(8, 2) + "/" + date.Substring(5, 2) + "/" + date.Substring(0, 4);
                    row[colTimebegin.DataPropertyName] = listEvent[i].eventObj.hourEventBegin;
                    row[colNumberHour.DataPropertyName] = listEvent[i].eventObj.hourEventKeeping;
                    row[colDescription.DataPropertyName] = listEvent[i].eventObj.description;

                    // neu su kien co danh sach member => add eventmemberId
                    if (null != listEvent[i].eventMemberObj)
                    {
                        row[colEventMemberId.DataPropertyName] = listEvent[i].eventMemberObj.eventmemberId;
                        row[colMember.DataPropertyName] = listEvent[i].eventMemberObj.memberName;
                    }
                    row.EndEdit();
                    dtbEventList.Rows.Add(row);
                }
                setCurrentEventId();
            }

            //20170306 Bug #750 [sTimeKeeping] Dang ky su kien _ Function - Trang Vo Start
            if (listEvent.Count > 0)
                this.menuEdit.Enabled = this.menuDelete.Enabled = true;
            //20170306 Bug #750 [sTimeKeeping] Dang ky su kien _ Function - Trang Vo End
        }

        /// <summary>
        /// create LisT Event DTO
        /// </summary>
        /// <param name="eventDTOList"></param>
        /// <returns></returns>
        private List<EventDTO> createLisTEventDTO(List<EventDTO> eventDTOList)
        {
            // result la list event hien thi tren table
            List<EventDTO> result = new List<EventDTO>();
            long preEventId = -1;

            // gan bien preEventId: giu lai index cua event truoc
            if (null != listEvent && listEvent.Count != 0)
            {
                result.Add(eventDTOList[0]);
                preEventId = listEvent[0].eventObj.eventId;
            }

            // neu su kien trung nhau, khong add vao result
            foreach (EventDTO events in listEvent)
            {
                long eventIdTmp = events.eventObj.eventId;
                if (eventIdTmp != preEventId)
                {
                    preEventId = eventIdTmp;
                    result.Add(events);
                }
            }
            return result;
        }

        /// <summary>
        /// Set cac gia tri vao cho event filter
        /// </summary>
        /// <returns></returns>
        private EventFilter setFilter()
        {
            EventFilter filter = new EventFilter();
            filter.filterByDateBegin = true;
            filter.dateBegin = dtpDateBegin.Text;
            filter.filterByDateEnd = true;
            filter.dateEnd = dtpDateEnd.Text;

            // kiem tra tbxCode Empty
            if (tbxCode.Text.Trim() != String.Empty)
            {
                filter.filterByEventName = true;
                filter.eventName = tbxCode.Text.Trim();
            }
            return filter;
        }

        /// <summary>
        /// Set an hoac hien cac button add va update
        /// </summary>
        private void SetShowOrHideUpdateOrg(bool checkUpdate)
        {
            menuAdd.Enabled = menuReload.Enabled = menuSync.Enabled = checkUpdate;
            this.menuEdit.Enabled = this.menuDelete.Enabled = false;
        }
        #endregion

        #region load data tu server

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
                    // load event
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
            if (eventId > 0)
            {
                try
                {
                    // LoadEventMember
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
        /// toListEventDelete: list eventid can xoa
        /// </summary>
        /// <returns></returns>
        private List<long> toListEventDelete()
        {
            List<long> listResult = null;
            if (dgvEvent.SelectedRows.Count == 0)
            {
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "NotRowSelected"));
            }
            if (dgvEvent.SelectedRows.Count > 0)
            {
                long eventId = -1;
                listResult = new List<long>();

                // add eventId
                foreach (DataGridViewRow row in dgvEvent.SelectedRows)
                {
                    eventId = long.Parse(row.Cells[0].Value.ToString());
                    listResult.Add(eventId);
                }
            }

            return listResult;
        }

        #endregion

        #region cac su kien

        /// <summary>
        /// trvOrganizations_BeforeSelect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvOrganizations_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            // If background worker is running -> restrict selecting another node
            if (bgwLoadOrgList.IsBusy)
            {
                e.Cancel = true;
                return;
            }

            // Change node font style to normal
            if (selectedOrgNode != null)
            {
                selectedOrgNode.NodeFont = new Font(startupNodeFont, FontStyle.Regular);
                selectedOrgNode.Text = selectedOrgNode.Text;
            }
        }
        /// <summary>
        /// trvOrganizations_AfterSelect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void trvOrganizations_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //20170305 Bug #746 [sTimeKeeping] Dang ky su kien _ Layout - Trang Vo Start
            SetShowOrHideUpdateOrg(false);
            //20170305 Bug #746 [sTimeKeeping] Dang ky su kien _ Layout - Trang Vo End

            TreeNode selectedNode = e.Node;
            TreeNode parentNode = new TreeNode();
            if (selectedNode != null)
            {
                parentNode = selectedNode.Parent;
                selectedNode.NodeFont = new Font(startupNodeFont, FontStyle.Bold);
                selectedNode.Text = selectedNode.Text;
                if (selectedOrgNode != null && selectedNode == selectedOrgNode)
                {
                    return;
                }
                selectedOrgNode = selectedNode;
                treeSelectId = selectedNode.Name;

                // neu Level == 1: load event theo org
                if (selectedOrgNode.Level == 1)
                {
                    //20170305 Bug #746 [sTimeKeeping] Dang ky su kien _ Layout - Trang Vo Start
                    SetShowOrHideUpdateOrg(true);
                    //20170305 Bug #746 [sTimeKeeping] Dang ky su kien _ Layout - Trang Vo End
                    LoadEventList(treeSelectId);
                }

                // neu Level == 2: load event theo org va suborg
                if (selectedOrgNode.Level == 2)
                {
                    //20170305 Bug #746 [sTimeKeeping] Dang ky su kien _ Layout - Trang Vo Start
                    SetShowOrHideUpdateOrg(true);
                    //20170305 Bug #746 [sTimeKeeping] Dang ky su kien _ Layout - Trang Vo End
                    parentTreeSelectId = selectedNode.Parent.Name;
                    LoadEventList(parentNode.Name, treeSelectId);
                }
                currentPageIndex = 1;
            }
        }

        /// <summary>
        /// Ham nay dung de them mot event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        ///
        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            if (selectedOrgNode.Level == 0)
                return;

            // cho bien modeLoadAddOrEdit = -1;
            modeLoadAddOrEdit = -1;
            if (!bgwLoadForm.IsBusy)
            {
                bgwLoadForm.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Ham nay dung de update mot event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateEvent_Click(object sender, EventArgs e)
        {
            if (null != dgvEvent.Rows && dgvEvent.Rows.Count != 0)
            {
                currentEventId = long.Parse(dgvEvent.SelectedRows[0].Cells[0].Value.ToString());

                if (dgvEvent.SelectedRows.Count == 0)
                {
                    // neu khong chon dong nao => thong bao loi
                    MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "NotRowSelected"));
                    return;
                }
                if (dgvEvent.SelectedRows.Count == 1)
                {
                    // 1 lan chi update 1 su kien
                    long eventId = long.Parse(dgvEvent.SelectedRows[0].Cells[0].Value.ToString());
                    modeLoadAddOrEdit = eventId;
                    if (!bgwLoadForm.IsBusy)
                    {
                        bgwLoadForm.RunWorkerAsync();
                    }
                }
                if (dgvEvent.SelectedRows.Count > 1)
                {
                    // neu chon hon 1 dong => thong bao loi
                    MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "CountOfRowNotOne"));
                    return;
                }
            }
        }

        /// <summary>
        /// menuDelete_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteEvent_Click(object sender, EventArgs e)
        {
            if (null != dgvEvent.Rows && dgvEvent.Rows.Count != 0)
            {
                if (MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetMessage(rm, "DeleteEventWarn")) == System.Windows.Forms.DialogResult.Yes)
                {
                    // lay eventid hien tai
                    currentEventId = long.Parse(dgvEvent.SelectedRows[0].Cells[0].Value.ToString());
                    if (!bgwDeleteEvent.IsBusy)
                    {
                        bgwDeleteEvent.RunWorkerAsync();
                    }
                }
            }
        }

        /// <summary>
        /// Ham nay bat su kien chuot phai
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvEvents_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo info = dgvEvent.HitTest(e.X, e.Y);
                if (info.RowIndex != -1)
                {

                    // kiem tra info.RowIndex >= 0 && info.ColumnIndex >= 0
                    if (info.RowIndex >= 0 && info.ColumnIndex >= 0)
                    {
                        if (!dgvEvent.SelectedRows.Contains(dgvEvent.Rows[info.RowIndex]))
                        {

                            // duyet dgvEvent.SelectedRows
                            foreach (DataGridViewRow row in dgvEvent.SelectedRows)
                            {
                                row.Selected = false;
                            }
                            dgvEvent.Rows[info.RowIndex].Selected = true;
                        }
                    }

                    // Show cmsMemberRecord
                    Rectangle r = dgvEvent.GetCellDisplayRectangle(info.ColumnIndex, info.RowIndex, true);
                    cmsMemberRecord.Show((Control)sender, e.X, e.Y);
                }
            }
        }

        /// <summary> 
        /// // set up su kien cho button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtbEventList_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //20170305 Bug #746 [sTimeKeeping] Dang ky su kien _ Layout - Trang Vo Start
            if (e.RowIndex >= 0)
            {
                //20170305 Bug #746 [sTimeKeeping] Dang ky su kien _ Layout - Trang Vo End

                // neu Column duoc chon la Column Xem chi tiet => hien thi form Xem chi tiet
                if (e.ColumnIndex == dgvEvent.Columns[colDetail.DataPropertyName].Index)
                {
                    foreach (DataGridViewRow row in dgvEvent.SelectedRows)
                    {
                        row.Selected = false;
                    }

                    dgvEvent.Rows[e.RowIndex].Selected = true;
                    long eventId = long.Parse(dgvEvent.SelectedRows[0].Cells[0].Value.ToString());
                    currentEventId = eventId;

                    // load Form Add Or Edit Or Detail
                    loadFormAddOrEditOrDetail(eventId, true);
                }
            }
        }

        /// <summary>
        /// btnReload_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReload_Click(object sender, EventArgs e)
        {
            reloadTimeEvent();
        }

        /// <summary>
        /// tbxCode_TextChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxCode_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dtbEventList);
            string strData = FormatCharacterSearch.CheckValue(tbxCode.Text.Trim());
            dv.RowFilter = string.Format("colEventName LIKE'%{0}%'", strData);
            dgvEvent.DataSource = dv;
            if (dv.Count <= 0)
                this.menuEdit.Enabled = this.menuDelete.Enabled = false;
            else
                this.menuEdit.Enabled = this.menuDelete.Enabled = true;
        }

        /// <summary>
        /// btnReloadOrgEvent_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReloadOrgEvent_Click(object sender, EventArgs e)
        {
            LoadOrgList();
            SetShowOrHideUpdateOrg(false);
        }

        /// <summary>
        /// xoa trang va load lai bang su kien
        /// </summary>
        private void reloadTimeEvent()
        {
            dtbEventList.Clear();
            if (selectedOrgNode.Level == 1)
                LoadEventList(treeSelectId);
            if (selectedOrgNode.Level == 2)
                LoadEventList(parentTreeSelectId, treeSelectId);
        }

        /// <summary>
        /// mniAddMemevent_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mniAddMemevent_Click(object sender, EventArgs e)
        {
            if (dgvEvent.SelectedRows.Count == 0)
            {
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "NotRowSelected"));
                return;
            }
            if (dgvEvent.SelectedRows.Count == 1)
            {
                // khi add member vao event => chi add member vao  1 event moi 1 lan
                currentEventId = long.Parse(dgvEvent.SelectedRows[0].Cells[0].Value.ToString());
                ShowFormMemberOfSubOrg(FormMemberOfSubOrg.ModeAdding);
            }
            if (dgvEvent.SelectedRows.Count > 1)
            {
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "CountOfRowNotOne"));
                return;
            }
        }

        /// <summary>
        /// mniDeleteMemEvent_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mniDeleteMemEvent_Click(object sender, EventArgs e)
        {
            if (dgvEvent.SelectedRows.Count == 0)
            {
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "NotRowSelected"));
                return;
            }
            if (dgvEvent.SelectedRows.Count == 1)
            {
                // khi xoa member khoi su kien => chi xoa member cua 1 su kien moi 1 lan
                currentEventId = long.Parse(dgvEvent.SelectedRows[0].Cells[0].Value.ToString());
                ShowFormMemberOfSubOrg(FormMemberOfSubOrg.ModeDeleting);
            }
            if (dgvEvent.SelectedRows.Count > 1)
            {
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "CountOfRowNotOne"));
                return;
            }
        }

        /// <summary>
        /// Show Form Member Of SubOrg
        /// </summary>
        /// <param name="mode"></param>
        private void ShowFormMemberOfSubOrg(byte mode)
        {
            FormMemberOfSubOrg frm = null;
            if (selectedOrgNode.Level == 0)
            {
                // Level == 0: khong thuc hien
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "NotSeleteSubOrg"));
                return;
            }
            pagerPanel1.ShowMessage(MessageValidate.GetMessage(rm, "lblLoading"));
            if (selectedOrgNode.Level == 1)
            {
                // Level == 1: show form dua vao mode, suborg = -1
                long eventId = long.Parse(dgvEvent.SelectedRows[0].Cells[0].Value.ToString());
                frm = new FormMemberOfSubOrg(mode, long.Parse(treeSelectId), -1, eventId);
            }
            if (selectedOrgNode.Level == 2)
            {
                // Level == 2: show form dua vao mode, org va suborg
                long eventId = long.Parse(dgvEvent.SelectedRows[0].Cells[0].Value.ToString());
                frm = new FormMemberOfSubOrg(mode, long.Parse(parentTreeSelectId), long.Parse(treeSelectId), eventId);
            }
            workItem.SmartParts.Add(frm);
            frm.ShowDialog();
            workItem.SmartParts.Remove(frm);
            frm.Hide();
            reloadTimeEvent();
            if (dgvEvent.SelectedRows.Count > 1)
            {
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "CountOfRowNotOne"));
                return;
            }
        }

        #endregion

        /// <summary>
        /// load Form Add Or Edit Or Detail
        /// </summary>
        /// <param name="configId"></param>
        private void loadFormAddOrEditOrDetail(long eventId, bool isModeDetail = false)
        {
            if (selectedOrgNode.Level != 0)
            {
                long orgId = -1;
                long subOrgId = -1;
                if (selectedOrgNode.Level == 1)
                {
                    // Level == 1, tim orgId
                    orgId = Convert.ToInt32(selectedOrgNode.Name);
                }
                if (selectedOrgNode.Level == 2)
                {
                    // Level == 2, tim orgId va subOrgId
                    orgId = Convert.ToInt32(selectedOrgNode.Parent.Name);
                    subOrgId = Convert.ToInt32(selectedOrgNode.Name);
                }
                if (orgId != -1)
                {
                    // load form voi orgId va subOrgId
                    FrmTimeEvent frmEvent = null;
                    if (isModeDetail)
                    {
                        // hien thi form Xem chi tiet
                        frmEvent = new FrmTimeEvent(FrmTimeEvent.ModeDetail, orgId, subOrgId, eventId);
                    }
                    else
                    {
                        if (-1 == eventId)
                        {
                            // hien thi form Add
                            frmEvent = new FrmTimeEvent(FrmTimeEvent.ModeAdding, orgId, subOrgId, eventId);
                        }
                        else
                        {
                            // hienthi form Update
                            frmEvent = new FrmTimeEvent(FrmTimeEvent.ModeUpdating, orgId, subOrgId, eventId);
                        }
                    }
                    workItem.SmartParts.Add(frmEvent);
                    frmEvent.ShowDialog();
                    workItem.SmartParts.Remove(frmEvent);
                    frmEvent.Hide();

                    // reloadTimeEvent
                    reloadTimeEvent();
                }
            }
            else
            {
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "chooseOrg"));
                return;
            }
        }

        #region CAB events
        /// <summary>
        /// ShowCardMgtMainHandler
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        [CommandHandler(TimeCommandName.ShowTimeEvent)]
        public void ShowCardMgtMainHandler(object s, EventArgs e)
        {
            UsrTimeEvent ucEvent = workItem.Items.Get<UsrTimeEvent>(DefineName.TimeEvent);
            if (ucEvent == null)
            {
                ucEvent = workItem.Items.AddNew<UsrTimeEvent>(DefineName.TimeEvent);
            }
            else if (ucEvent.IsDisposed)
            {
                workItem.Items.Remove(ucEvent);
                ucEvent = workItem.Items.AddNew<UsrTimeEvent>(DefineName.TimeEvent);
            }

            workItem.Workspaces[WorkspaceName.MainWorkspace].Show(ucEvent);
            ucEvent.Parent.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, DefineName.MenuTimeEvent);
        }
        #endregion

        /// <summary>
        /// import danh sách sự kiện trong một tháng của một phòng ban
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuSync_Click(object sender, EventArgs e)
        {
            long OrgId = Convert.ToInt64(treeSelectId);

            //tao danh sach org cua to chuc
            SubOrgFilterDto subOrgFilter = new SubOrgFilterDto();

            //gan du lieu vao 
            //Organization orgObject = OrganizationFactory.Instance.GetChannel().GetOrgById(storageService.CurrentSessionId, OrgId);
            //OrgCustomerDto orgObject = OrganizationFactory.Instance.GetChannel().GetOrgList(storageService.CurrentSessionId, );
            List<SubOrgCustomerDTO> listSubOrg = OrganizationFactory.Instance.GetChannel().GetSubOrgList(
                storageService.CurrentSessionId, OrgId, subOrgFilter);

            FrmEventConnectionConfig frmConnConfig = new FrmEventConnectionConfig(OrgId, listSubOrg, rm);
            frmConnConfig.ShowDialog();

            if (frmConnConfig.DialogResult == DialogResult.OK)
            {
                // show FrmEventReadExcelData
                FrmEventReadExcelData frmReadData = new FrmEventReadExcelData();
                workItem.SmartParts.Add(frmReadData);
                frmReadData.FilePath = frmConnConfig.FilePath;

                frmReadData.OrgId = frmConnConfig.OrgId;
                frmReadData.SubOrgId = frmConnConfig.SubOrgId;
                frmReadData.colEventNameIndex = frmConnConfig.EventNameIndex;

                frmReadData.colHourBeginIndex = frmConnConfig.HourBeginIndex;

                frmReadData.colDateIndex = frmConnConfig.DateIndex;
                frmReadData.colHourKeepingIndex = frmConnConfig.HourKeepingIndex;
                frmReadData.colDescriptionIndex = frmConnConfig.DescriptionIndex;
                frmReadData.colMemberNameIndex = frmConnConfig.MemberNameIndex;
                frmReadData.colMemberCodeIndex = frmConnConfig.MemberCodeIndex;
                frmReadData.firstRowIndex = frmConnConfig.FirstRowIndex;
                frmReadData.rm = rm;
                frmReadData.ShowDialog();

                frmReadData.Dispose();
                workItem.SmartParts.Remove(frmReadData);
            }

            frmConnConfig.Dispose();
            workItem.SmartParts.Remove(frmConnConfig);

            //LoadMemberList();
        }

    }
}
