using System;
using System.Data;
using Microsoft.Practices.CompositeUI.Commands;
using CommonHelper.Constants;
using CommonHelper.Utils;
using CommonControls;
using sWorldModel.Exceptions;
using CommonControls.Custom;
using System.Resources;
using Microsoft.Practices.CompositeUI;
using sWorldModel;
using System.ServiceModel;
using System.ComponentModel;
using System.Linq;
using System.Collections.Generic;
using CommonHelper.Config;
using System.Windows.Forms;
using System.Drawing;
using sMeetingComponent.Constants;
using sMeetingComponent.Model;
using sMeetingComponent.Factory;
using sMeetingComponent.Model.CustomObj;
using ClientModel.Model;
using ClientModel.Utils;
using System.IO;
using sExcelExportComponent.ClientModel.Enums;


namespace sMeetingComponent.WorkItems.ScheduleMeeting
{
    public partial class UsrScheduleMeeting : CommonUserControl
    {
        #region Properties
        public string sysFormatDate;

        int take = LocalSettings.Instance.RecordsPerPage;
        int sum = 0;

        private DateTime dateFroms;
        private DateTime dateTos;
        private int currentPageIndex = 1;
        private const int hiddenFilterBoxHeight = 1;
        private int startupFilterBoxHeight;

        public long meetingId = 0;
        public string listPartakerNonresident = "";
        private DataTable dtbEventMeetingListObjList;
        private DataTable table4Export = null;
        List<EventMeeting> eventMeetingListObj;
        EventMeeting eventMeetingInfo;

        private EventMeetingObj EventMeetingObj;
        private BackgroundWorker loadEventMeetingListObjList;
        private BackgroundWorker bgwLoadOrganizationList;

        public List<OrganizationMeeting> organizationListCbx;
        long organizationMeetingId = -1;
        String nameMeeting = "all";
        String updating = "updating";

        private MeetingComponentWorkItem workItem;
        private ResourceManager rm;
        public DialogPostAction PostAction { get; private set; }
        [ServiceDependency]
        public MeetingComponentWorkItem WorkItem
        {
            set { workItem = value; }
        }
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

        #region Contructors
        public UsrScheduleMeeting()
        {
            InitializeComponent();
            InitDataTableeventMeetingListObjList();

            sysFormatDate = UsrListMeeting.formatDateTime();

            RegisterEvent();
        }
        #endregion

        /// <summary>
        /// InitDataTableeventMeetingListObjList
        /// </summary>
        private void InitDataTableeventMeetingListObjList()
        {

            dtbEventMeetingListObjList = new DataTable();
            dtbEventMeetingListObjList.Columns.Add(colSTT.DataPropertyName);
            dtbEventMeetingListObjList.Columns.Add(colOrgMeetingId.DataPropertyName);
            dtbEventMeetingListObjList.Columns.Add(colOrganizationMeetingName.DataPropertyName);
            dtbEventMeetingListObjList.Columns.Add(colMeetingId.DataPropertyName);
            dtbEventMeetingListObjList.Columns.Add(colMeetingName.DataPropertyName);
            dtbEventMeetingListObjList.Columns.Add(colStatusNonResident.DataPropertyName);
            dtbEventMeetingListObjList.Columns.Add(colDateTime.DataPropertyName);
            dtbEventMeetingListObjList.Columns.Add(colStartTime.DataPropertyName);
            dtbEventMeetingListObjList.Columns.Add(colEndTime.DataPropertyName);
            dtbEventMeetingListObjList.Columns.Add(colRoomId.DataPropertyName);
            dtbEventMeetingListObjList.Columns.Add(colRoom.DataPropertyName);
            dtbEventMeetingListObjList.Columns.Add(colNote.DataPropertyName);
            dtbEventMeetingListObjList.Columns.Add(colInfoMeeting.DataPropertyName);
            dgvAttendMeetingStatisticList.DataSource = dtbEventMeetingListObjList;

            //20170304 #Bug Fix- My Nguyen Start
            // for export
            table4Export = new DataTable();

            table4Export.Columns.Add(colSTT.DataPropertyName);
            table4Export.Columns.Add(colOrgMeetingId.DataPropertyName);
            table4Export.Columns.Add(colOrganizationMeetingName.DataPropertyName);
            table4Export.Columns.Add(colMeetingId.DataPropertyName);
            table4Export.Columns.Add(colMeetingName.DataPropertyName);
            //cuộc họp thêm vào là textbox chứ không phải checkbox giống hiển thị
            table4Export.Columns.Add(colStatusNonResident.DataPropertyName);
            table4Export.Columns.Add(colDateTime.DataPropertyName);
            table4Export.Columns.Add(colStartTime.DataPropertyName);
            table4Export.Columns.Add(colEndTime.DataPropertyName);
            table4Export.Columns.Add(colRoomId.DataPropertyName);
            table4Export.Columns.Add(colRoom.DataPropertyName);
            table4Export.Columns.Add(colNote.DataPropertyName);
            table4Export.Columns.Add(colInfoMeeting.DataPropertyName);

            dataGridview4Export.DataSource = table4Export;
            //20170304 #Bug Fix- My Nguyen End
        }

        /// <summary>
        /// đăng ký sự kiện
        /// RegisterEvent
        /// </summary>
        private void RegisterEvent()
        {
            CreateBackgroundWorkerEvent();
            btnShowHide.Click += btnShowHide_Clicked;
            btnReload.Click += OnButtonReloadClicked;
            dgvAttendMeetingStatisticList.MouseDown += dgvAttendMeetingStatisticLists_MouseDown;
            dgvAttendMeetingStatisticList.CellClick += dgvAttendMeetingStatisticLists_Clicked;
            txtMeetingNameSearchs.TextChanged += txtMeetingNameSearchs_TextChanged;
            // btnAddMeeting.Click += OnButtonAddMeeting_Clicked;
            btnUpdateMeeting.Click += OnButtongUpdateMeeting_clicked;
            btnExportToExcel.Click += btnExportToExcel_Click;
            pagerPanel1.LinkLabelClicked += pagerPanel_LinkLabelClicked;
            Load += OnFormLoad;
        }

        /// <summary>
        /// OnFormLoad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFormLoad(object sender, EventArgs e)
        {
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            pagerPanel1.StorageService = storageService;
            pagerPanel1.LoadLanguage();

            SetLanguages();
            LoadOrganizationList();
            startupFilterBoxHeight = pnlFilterBox.Height;

            LoadEventMeetingListObjList();
            dateFroms = this.dtpDateIn.Value.Date;
            dateTos = this.dtpDateIn2.Value.Date;
        }

        #region language
        /// <summary>
        /// SetLanguages
        /// </summary>
        private void SetLanguages()
        {
            this.colSTT.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colSTT.Name);
            this.colOrgMeetingId.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOrgMeetingId.Name);
            this.colOrganizationMeetingName.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOrganizationMeetingName.Name);
            this.colMeetingId.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colMeetingId.Name);
            this.colMeetingName.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colMeetingName.Name);
            this.colDateTime.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colDateTime.Name);
            this.colStartTime.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colStartTime.Name);
            this.colEndTime.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colEndTime.Name);
            this.colRoom.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colRoom.Name);
            this.colRoomId.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colRoomId.Name);
            this.colListPerson.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colListPerson.Name);
            this.colNote.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNote.Name);
            this.colStatusNonResident.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colStatusNonResident.Name);
            this.colInfoMeeting.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colInfoMeeting.Name);

            //
            this.dataGridViewTextBoxColumn2.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colSTT.Name);
            this.dataGridViewTextBoxColumn3.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOrganizationMeetingName.Name);
            this.dataGridViewTextBoxColumn5.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colMeetingName.Name);
            this.dataGridViewCheckBoxColumn1.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colStatusNonResident.Name);
            this.dataGridViewTextBoxColumn6.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colDateTime.Name);
            this.dataGridViewTextBoxColumn7.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colStartTime.Name);
            this.dataGridViewTextBoxColumn8.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colEndTime.Name);
            this.dataGridViewTextBoxColumn10.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colRoom.Name);
            this.dataGridViewTextBoxColumn11.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNote.Name);
            //

            this.btnShowHide.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnShowHide.Name);
            this.btnExportToExcel.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnExportToExcel.Name);
            this.btnReload.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnReload.Name);
            this.btnUpdateMeeting.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnUpdateMeeting.Name);
            this.mniUpdateInfoMeeting.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.mniUpdateInfoMeeting.Name);
            this.mniInfoAttendMeeting.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.mniInfoAttendMeeting.Name);
            this.mniUpdateInfoMeeting.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.mniUpdateInfoMeeting.Name);
            this.mniInfoAttendMeeting.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.mniInfoAttendMeeting.Name);
            string updatestr = MessageValidate.GetMessage(rm, "updating");
            if (updatestr != null)
            {
                updating = updatestr;

                if (updating.Equals("") || updating.Equals("LanguagesError"))
                {
                    updating = "updating";
                }
            }
        }
        #endregion

        #region bgWorker
        /// <summary>
        /// CreateBackgroundWorkerEvent
        /// </summary>
        private void CreateBackgroundWorkerEvent()
        {
            bgwLoadOrganizationList = new BackgroundWorker();
            bgwLoadOrganizationList.WorkerSupportsCancellation = true;
            bgwLoadOrganizationList.DoWork += LoadOrganizationListWorkerDoWork;
            bgwLoadOrganizationList.RunWorkerCompleted += LoadOrganizationListRunWorkerCompleted;

            //20: QUẢN lí thông tin cuộc họp theo điều kiện lọc
            loadEventMeetingListObjList = new BackgroundWorker();
            loadEventMeetingListObjList.WorkerSupportsCancellation = true;
            loadEventMeetingListObjList.DoWork += OnLoadEventMeetingListObjWorkerDoWork;
            loadEventMeetingListObjList.RunWorkerCompleted += OnLoadEventMeetingListObjWorkerCompleted;
        }

        #region Gửi yêu cầu lấy thông tin đơn vị tổ chức cuộc họp
        /// <summary>
        /// LoadOrganizationList
        /// </summary>
        private void LoadOrganizationList()
        {
            if (!bgwLoadOrganizationList.IsBusy)
            {
                bgwLoadOrganizationList.RunWorkerAsync();
            }
        }

        /// <summary>
        /// LoadOrganizationListWorkerDoWork
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadOrganizationListWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = OrganizationMeetingFactory.Instance.GetChannel().getOrganization(storageService.CurrentSessionId);
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
        /// LoadOrganizationListRunWorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadOrganizationListRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            //if (e.Result == null)
            //{
            //    //MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "smsNotFilter"));
            //    return;
            //}
            else
            {
                OrganizationMeeting organizationMeetingItem = new OrganizationMeeting();
                string All = MessageValidate.GetMessage(rm, "All");
                organizationMeetingItem.name = All;
                organizationMeetingItem.id = -1;
                //personAttendObjItem.meetingName = "-Tất cả-";
                //personAttendObjItem.meetingId = -1;
                organizationListCbx = new List<OrganizationMeeting>();
                organizationListCbx.Add(organizationMeetingItem);
                //20170304 #Bug Fix- My Nguyen Start

                List<OrganizationMeeting> result = (List<OrganizationMeeting>)e.Result;

                //kiểm tra có null hay không
                if (result != null)
                {
                    if (result.Count != 0)
                    {
                        //các cơ quan tổ chức cuộc hopj
                        foreach (OrganizationMeeting o in result)
                        {
                            if (o.typeOrg == OrgEnum.ORG_SUB_ORG || o.typeOrg == OrgEnum.ORG_ORG)
                            {
                                organizationListCbx.Add(o);
                            }
                        }
                        //  organizationListCbx.AddRange(result);
                    }
                }
                cbxNameOrgSearch.Enabled = true;
                cbxNameOrgSearch.DataSource = organizationListCbx.ToList();
                cbxNameOrgSearch.ValueMember = "id";
                cbxNameOrgSearch.DisplayMember = "name";//hiển thị
                cbxNameOrgSearch.SelectedIndex = 0;
            }
        }
        #endregion

        #region LoadEventMeetingListObjAtPage Load danh sách cuộc họp
        /// <summary>
        /// load list meeting based on  (start, end, dateFrom, dateTo, organizationMeetingId, nameMeeting);
        /// namemeeting : default = "all"
        ///  load danh sách cuộc họp dựa vào
        ///  orgid : -1 : id
        ///  namemeeting hiện tại mặc định all
        ///  chứ không phụ thuộc nhập tên gì
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public EventMeetingObj LoadEventMeetingListObjAtPage(int start, int end)
        {
            EventMeetingObj EventMeetingObjnew = new EventMeetingObj();

            String dateFrom = dateFroms.ToString("yyyy-MM-dd 00:00:00");
            String dateTo = dateTos.ToString("yyyy-MM-dd 00:00:00");

            try
            {
                EventMeetingObjnew = MeetingEventFactory.Instance.GetChannel().getEventMeetingListByDateAndOrgIDAndMeetingName(StorageService.CurrentSessionId, start, end, dateFrom, dateTo, organizationMeetingId, nameMeeting);
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
            return EventMeetingObjnew;
        }
        #endregion

        #region Gửi yêu cầu lấy thông tin danh sách cuộc họp
        /// <summary>
        /// LoadEventMeetingListObjList
        /// </summary>
        private void LoadEventMeetingListObjList()
        {
            if (ValidateData())
            {
                if (!loadEventMeetingListObjList.IsBusy)
                {
                    dtbEventMeetingListObjList.Rows.Clear();
                    pagerPanel1.ShowMessage(MessageValidate.GetMessage(rm, "smsLoading"));
                    loadEventMeetingListObjList.RunWorkerAsync();
                }
            }
            else
            {
                dtbEventMeetingListObjList.Rows.Clear();
            }
        }

        /// <summary>
        /// kiểm tra điều kiện lọc từ ngày đến ngày
        /// ValidateData
        /// </summary>
        /// <returns></returns>
        private bool ValidateData()
        {
            dateFroms = this.dtpDateIn.Value.Date;
            dateTos = this.dtpDateIn2.Value.Date;
            int result = DateTime.Compare(dateFroms, dateTos);
            if (result < 0)
                return true;
            else if (result == 0)
                return true;
            else
            {
                UploadStatusBar();
                return false;
            }
        }

        /// <summary>
        ///  get meeting list based on from Date to date
        ///  OnLoadEventMeetingListObjWorkerDoWork
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadEventMeetingListObjWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            int totalRecords = 0;
            int skip = 0;
            currentPageIndex = 1;
            EventMeetingObj = LoadEventMeetingListObjAtPage(skip, take);
            List<EventMeeting> result = new List<EventMeeting>();
            try
            {
                e.Result = EventMeetingObj;
            }
            catch (Exception ex) { }
            finally
            {
                if (EventMeetingObj != null)
                {
                    //phân trang
                    sum = totalRecords = Convert.ToInt32(EventMeetingObj.sum);

                    //290317 hiển thị những cuộc họp có san
                    result = EventMeetingObj.meetings;
                    eventMeetingListObj = result;
                    pagerPanel1.ShowNumberOfRecords(totalRecords, result != null ? result.Count : 0, take, currentPageIndex);
                    pagerPanel1.UpdatePagingLinks(totalRecords, take, currentPageIndex);
                }
                e.Result = result;
            }
        }

        /// <summary>
        /// UploadStatusBar
        ///  Change statusbar : message not data
        /// </summary>
        private void UploadStatusBar()
        {
            btnUpdateMeeting.Enabled = btnExportToExcel.Enabled = false;
            pagerPanel1.ShowMessage(MessageValidate.GetMessage(rm, "lblMessageNotData"));
            pagerPanel1.UpdatePagingLinks(0, 1, 0);
        }

        /// <summary>
        /// change status bar: have pagepanel , but not data
        /// cho phân trang thi vẫn còn hiển thị thanh link, và cho xuất exccel
        /// </summary>
        private void UploadStatusBarHavePagePanel()
        {
            pagerPanel1.ShowMessage(MessageValidate.GetMessage(rm, "lblMessageNotData"));
        }

        /// <summary>
        /// OnLoadEventMeetingListObjWorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadEventMeetingListObjWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (e.Cancelled)
            {
                UploadStatusBar();
                return;
            }
            if (e.Result == null)
            {
                UploadStatusBar();
                return;
            }
            List<EventMeeting> result = (List<EventMeeting>)e.Result;
            if (result.Count != 0)
            {
                LoadEventMeetingListObjListdata(result);
            }
            else
            {
                UploadStatusBar();
                return;
            }
        }
        #endregion

        #region Hiển thông tin danh sách cuộc họp
        /// <summary>
        /// show info meeting list
        /// </summary>
        /// <param name="result"></param>
        public void LoadEventMeetingListObjListdata(List<EventMeeting> result)
        {
            int index = 0;
            eventMeetingListObj = result;
            dtbEventMeetingListObjList.Clear();

            for (int i = 0; i < result.Count; i++)
            {
                DataRow row = dtbEventMeetingListObjList.NewRow();
                row.BeginEdit();
                index = i + 1;
                row[colSTT.DataPropertyName] = index;

                row[colOrgMeetingId.DataPropertyName] = result[i].organizationMeetingId;
                row[colOrganizationMeetingName.DataPropertyName] = result[i].organizationMeetingName;
                row[colMeetingId.DataPropertyName] = result[i].id;
                row[colMeetingName.DataPropertyName] = result[i].name;
                row[colStatusNonResident.DataPropertyName] = result[i].nonresident;

                row[colRoomId.DataPropertyName] = result[i].roomId;
                row[colRoom.DataPropertyName] = result[i].roomName;
                row[colNote.DataPropertyName] = result[i].note;
                row[colInfoMeeting.DataPropertyName] = result[i].listNonResident;

                DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                DateTime startDate = start.AddMilliseconds(Convert.ToUInt64(result[i].startTime)).ToLocalTime();
                DateTime endDate = start.AddMilliseconds(Convert.ToUInt64(result[i].endTime)).ToLocalTime();
                DateTime datedefault = new DateTime(1971, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                int compareDateEnd = DateTime.Compare(endDate, datedefault);

                row[colDateTime.DataPropertyName] = startDate.ToString(sysFormatDate);
                row[colStartTime.DataPropertyName] = startDate.ToString("HH:mm");

                if (compareDateEnd == 0)
                {
                    row[colEndTime.DataPropertyName] = updating;
                }
                else
                {
                    row[colEndTime.DataPropertyName] = endDate.ToString("HH:mm");
                }
                row.EndEdit();
                dtbEventMeetingListObjList.Rows.Add(row);
            }

            if (dgvAttendMeetingStatisticList.Rows.Count > 0)
            {
                //20170304 #Bug Fix- My Nguyen Start
                //có dữ liệu moi hien thị nút xóa , sua
                btnUpdateMeeting.Enabled = true;
                btnExportToExcel.Enabled = true;
                //20170304 #Bug Fix- My Nguyen End
                //focur the first row in table
                dgvAttendMeetingStatisticList.Rows[0].Selected = true;
            }
            else
            {
                UploadStatusBarHavePagePanel();
            }
        }
        #endregion

        #endregion

        #region CAB events
        [CommandHandler(MeetingCommandName.ShowMeetingItemScheduleAMeeting)]
        public void ShowMeetingStatisticsMainHandler(object s, EventArgs e)
        {
            UsrScheduleMeeting uc = workItem.Items.Get<UsrScheduleMeeting>(MeetingCommandName.MenuMeetingItemScheduleAMeeting);
            if (uc == null)
            {
                uc = workItem.Items.AddNew<UsrScheduleMeeting>(MeetingCommandName.MenuMeetingItemScheduleAMeeting);
            }
            else if (uc.IsDisposed)
            {
                workItem.Items.Remove(uc);
                uc = workItem.Items.AddNew<UsrScheduleMeeting>(MeetingCommandName.MenuMeetingItemScheduleAMeeting);
            }
            workItem.Workspaces[WorkspaceName.MainWorkspace].Show(uc);
            uc.Parent.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(uc.rm, MenuNames.MenuMeetingItemScheduleAMeeting);
        }
        #endregion

        #region  Event's 
        /// <summary>
        /// click btnshowhide
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowHide_Clicked(object sender, EventArgs e)
        {
            if (pnlFilterBox.Height > hiddenFilterBoxHeight)
            {
                pnlFilterBox.Height = hiddenFilterBoxHeight;
                btnShowHide.Text = btnShowHide.ToolTipText = MessageValidate.GetMessage(rm, "showSearchBox");
                btnShowHide.ToolTipText = MessageValidate.GetMessage(rm, "showSearchBox");
                btnShowHide.Image = global::CommonControls.Properties.Resources.ArrowDown_16x16;
            }
            else
            {
                pnlFilterBox.Height = startupFilterBoxHeight;
                btnShowHide.Text = btnShowHide.ToolTipText = MessageValidate.GetMessage(rm, "hiddenSearchBox");
                btnShowHide.ToolTipText = MessageValidate.GetMessage(rm, "hiddenSearchBox");
                btnShowHide.Image = global::CommonControls.Properties.Resources.ArrowUp_16x16;
            }
        }

        /// <summary>
        /// click dgv 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvAttendMeetingStatisticLists_Clicked(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex != -1)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {

                    int colInfoClicked = dgvAttendMeetingStatisticList.Columns[colListPerson.Name].Index;
                    //12
                    if (e.ColumnIndex == colInfoClicked)
                        showInfoPartaker(sender, e);
                }
            }
        }

        /// <summary>
        /// NOT USED
        /// show info partaker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void showInfoPartaker(object sender, EventArgs e)
        {
            btnInfo_Click();
            if ((listPartakerNonresident.Equals("[]")) || (listPartakerNonresident.Equals("")))
            {
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "SmsNotInforAttendMeeting"));

            }
            else
            {
                FrmPartakerList frmPartakerList = new FrmPartakerList(eventMeetingInfo, listPartakerNonresident);
                workItem.SmartParts.Add(frmPartakerList);
                frmPartakerList.ShowDialog();
                //có thể để bắt buộc phải tắt
                workItem.SmartParts.Remove(frmPartakerList);
                frmPartakerList.Dispose();
            }
        }

        /// <summary>
        /// click btn info
        /// </summary>
        public void btnInfo_Click()
        {
            eventMeetingInfo = new EventMeeting();
            // Get selected rows
            var selectedRows = dgvAttendMeetingStatisticList.SelectedRows;
            int rowsCount = selectedRows.Count;
            if (rowsCount == 0)
            {
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessSelect(rm, "smsPleaseClickChooseInfo"));
                return;
            }
            else
            {
                try
                {
                    String meetingIdStr = selectedRows[0].Cells[colMeetingId.Name].Value.ToString();
                    meetingId = Convert.ToInt64(meetingIdStr);
                    bool check = Convert.ToBoolean(selectedRows[0].Cells[colStatusNonResident.Name].Value);
                    listPartakerNonresident = selectedRows[0].Cells[colInfoMeeting.Name].Value.ToString();

                    //get info
                    for (int i = 0; i < eventMeetingListObj.Count; i++)
                    {
                        if (eventMeetingListObj[i].id == meetingId)
                        {
                            eventMeetingInfo = eventMeetingListObj[i];
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "smsPleaseClickChooseInfo"));
                }
            }
        }

        /// <summary>
        /// mousedown dgv
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvAttendMeetingStatisticLists_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo info = dgvAttendMeetingStatisticList.HitTest(e.X, e.Y);
                if (info.RowIndex != -1)
                {
                    if (info.RowIndex >= 0 && info.ColumnIndex >= 0)
                    {

                        if (!dgvAttendMeetingStatisticList.SelectedRows.Contains(dgvAttendMeetingStatisticList.Rows[info.RowIndex]))
                        {
                            foreach (DataGridViewRow row in dgvAttendMeetingStatisticList.SelectedRows)
                            {
                                row.Selected = false;
                            }

                            dgvAttendMeetingStatisticList.Rows[info.RowIndex].Selected = true;


                        }
                    }
                    Rectangle r = dgvAttendMeetingStatisticList.GetCellDisplayRectangle(info.ColumnIndex, info.RowIndex, true);
                    cmsPersoRecord.Show((Control)sender, e.X, e.Y);
                }
            }
        }

        /// <summary>
        /// click btn update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtongUpdateMeeting_clicked(object sender, EventArgs e)
        {
            btnInfo_Click();
            //v1 không hien thi thanh phan tham du
            FrmUpdateTimeMeeting frmUpdateNonResident = new FrmUpdateTimeMeeting(meetingId);
            //v2 hien thi thanh phan tham du
            //  FrmUpdateScheduleMeeting frmUpdateNonResident = new FrmUpdateScheduleMeeting(meetingId);
            workItem.SmartParts.Add(frmUpdateNonResident);
            frmUpdateNonResident.ShowDialog();
            OnButtonReloadClicked(sender, e);
        }

        /// <summary>
        /// click btn reload
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonReloadClicked(object sender, EventArgs e)
        {
            try
            {
                OrganizationMeeting organizationMeetingClick = (OrganizationMeeting)cbxNameOrgSearch.SelectedItem;
                organizationMeetingId = organizationMeetingClick.id;
            }
            catch (Exception er)
            {
                organizationMeetingId = -1;
            }
            nameMeeting = txtMeetingNameSearchs.Text.ToString();
            if (nameMeeting.Equals(""))
            {
                nameMeeting = "all";
            }
            LoadEventMeetingListObjList();
        }

        /// <summary>
        /// click pagerpanel
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void pagerPanel_LinkLabelClicked(object s, LinkLabelClickedArgs e)
        {
            int i;
            if (e.LabelText.Equals(PagerPanel.LabelBackText))
            {
                currentPageIndex -= 1;
            }
            else if (e.LabelText.Equals(PagerPanel.LabelNextText))
            {
                currentPageIndex += 1;
            }
            else if (int.TryParse(e.LabelText, out i))
            {
                currentPageIndex = i;
            }
            else
            {
                return;
            }
            dtbEventMeetingListObjList.Rows.Clear();
            int skip = (currentPageIndex - 1) * take;
            int totalRecords = 0;

            EventMeetingObj EventMeetingObjnew = LoadEventMeetingListObjAtPage(skip, take);
            if (EventMeetingObjnew != null)
            {
                List<EventMeeting> result = EventMeetingObjnew.meetings;
                LoadEventMeetingListObjListdata(result);
                totalRecords = Convert.ToInt32(sum);
                pagerPanel1.ShowNumberOfRecords(totalRecords, result != null ? result.Count : 0, take, currentPageIndex);
                pagerPanel1.UpdatePagingLinks(totalRecords, take, currentPageIndex);
            }
            else
            {
                UploadStatusBarHavePagePanel();
                return;
            }
        }

        /// <summary>
        /// search namemeeting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMeetingNameSearchs_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataView dv = new DataView(dtbEventMeetingListObjList);

                //20170307 #Bug Fix- My Nguyen Start
                //FormatCharacter formatCharacter = new FormatCharacter();
                //string data = formatCharacter.CheckValue(txtMeetingNameSearchs.Text.Trim());

                string data = FormatCharacterSearch.CheckValue(txtMeetingNameSearchs.Text.Trim());


                dv.RowFilter = string.Format("MeetingName LIKE '%{0}%'", data);
                dgvAttendMeetingStatisticList.DataSource = dv;

                int record = dgvAttendMeetingStatisticList.Rows.Count;
                if (record > 0)
                {
                    pagerPanel1.ShowNumberOfRecords(sum, record, take, currentPageIndex);
                }
                else
                {
                    UploadStatusBarHavePagePanel();
                }
                //20170307 #Bug Fix- My Nguyen End
            }
            catch (Exception ex)
            {
            }
        }
        #endregion

        #region Chuẩn bị danh sách xuất file excel
        //20170304 #Bug Fix- My Nguyen Start
        /// <summary>
        /// lay du dlieu tu server cho export data
        /// </summary>
        /// <param name="totalpage">tong so trang</param>
        /// <returns></returns>
        private void GetDataFOrExport()
        {
            // query lan dau de lay du lieu va so luong records
            EventMeetingObj EventMeetingObjnew = new EventMeetingObj();

            String dateFrom = dateFroms.ToString("yyyy-MM-dd 00:00:00");
            String dateTo = dateTos.ToString("yyyy-MM-dd 00:00:00");

            try
            {
                int start = 0;
                int end = take;
                EventMeetingObjnew = MeetingEventFactory.Instance.GetChannel().getEventMeetingListByDateAndOrgIDAndMeetingName(StorageService.CurrentSessionId, start, end, dateFrom, dateTo, organizationMeetingId, "all");
            }
            catch (Exception ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
            }

            if (EventMeetingObjnew != null)
            {
                if (EventMeetingObjnew.meetings != null)
                    // add data lan dau tien
                    PrepareDataToExport(EventMeetingObjnew.meetings);

                //phân trang
                int totalRecords = Convert.ToInt32(EventMeetingObjnew.sum);

                //lay them du lieu neu khong du vi tong so record lon hon so take (take = 20) trong 1 trang
                if (totalRecords > take)
                {
                    int numberPage = (totalRecords / take) + ((totalRecords % take > 0) ? 1 : 0);
                    for (int i = 1; i < numberPage; i++)
                    {
                        //int start = i * take + 1;
                        int start = i * take;
                        int end = take;
                        EventMeetingObjnew = MeetingEventFactory.Instance.GetChannel().getEventMeetingListByDateAndOrgIDAndMeetingName(StorageService.CurrentSessionId, start, end, dateFrom, dateTo, organizationMeetingId, "all");
                        if (EventMeetingObjnew != null)
                            if (EventMeetingObjnew.meetings != null)
                                PrepareDataToExport(EventMeetingObjnew.meetings);
                    }
                }
            }
        }

        /// <summary>
        ///  add du lieu vao datagridview
        /// </summary>
        /// <param name="datagridview"></param>
        /// <param name="data"></param>
        private void PrepareDataToExport(List<EventMeeting> result)
        {
            int index = table4Export.Rows.Count;
            for (int i = 0; i < result.Count; i++)
            {
                DataRow row = table4Export.NewRow();
                row.BeginEdit();
                index += 1;
                row[colSTT.DataPropertyName] = index;

                row[colOrgMeetingId.DataPropertyName] = result[i].organizationMeetingId;
                row[colOrganizationMeetingName.DataPropertyName] = result[i].organizationMeetingName;
                row[colMeetingId.DataPropertyName] = result[i].id;
                row[colMeetingName.DataPropertyName] = result[i].name;
                //nếu cuộc họp được thêm vào thì có 
                if (result[i].nonresident)
                {
                    row[colStatusNonResident.DataPropertyName] = "Có";
                }
                else
                    row[colStatusNonResident.DataPropertyName] = "Không";
                //   row[colStatusNonResident.DataPropertyName] = result[i].nonresident;
                //end

                row[colRoomId.DataPropertyName] = result[i].roomId;
                row[colRoom.DataPropertyName] = result[i].roomName;
                row[colNote.DataPropertyName] = result[i].note;
                row[colInfoMeeting.DataPropertyName] = result[i].listNonResident;

                DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                DateTime startDate = start.AddMilliseconds(Convert.ToUInt64(result[i].startTime)).ToLocalTime();
                DateTime endDate = start.AddMilliseconds(Convert.ToUInt64(result[i].endTime)).ToLocalTime();
                DateTime datedefault = new DateTime(1971, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                int compareDateEnd = DateTime.Compare(endDate, datedefault);

                row[colDateTime.DataPropertyName] = startDate.ToString(sysFormatDate);
                row[colStartTime.DataPropertyName] = startDate.ToString("HH:mm");

                if (compareDateEnd == 0)
                {
                    row[colEndTime.DataPropertyName] = updating;
                }
                else
                {
                    row[colEndTime.DataPropertyName] = endDate.ToString("HH:mm");
                }
                row.EndEdit();
                table4Export.Rows.Add(row);
            }
        }
        //20170304 #Bug Fix  - My Nguyen End

        /// <summary>
        /// btn export 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            String organizationMeetingName = "";
            long organizationMeetingid = -1;
            try
            {
                OrganizationMeeting organizationMeetingClick = (OrganizationMeeting)cbxNameOrgSearch.SelectedItem;
                organizationMeetingName = organizationMeetingClick.name;

                organizationMeetingid = organizationMeetingClick.id;
            }
            catch (Exception ex) { }
            if (organizationMeetingid == -1)
                organizationMeetingName = "";
            String name = MessageValidate.GetMessage(rm, "lblRightAreaTitleScheduleMeeting") + "_" + dateFroms.ToString("dd-MM-yyyy") + "_" + dateTos.ToString("dd-MM-yyyy");
            //  String name = MessageValidate.GetMessage(rm, "lblRightAreaTitleScheduleMeeting") + "_" + organizationMeetingName.ToString() + "_" + dateFroms.ToString("dd-MM-yyyy") + "_" + dateTos.ToString("dd-MM-yyyy");
            string filePath = ControlExtMethods.ShowSaveFileDialog(MessageValidate.GetMessage(rm, "smsChooseFileExport"), name, CategorizeExcel.Categorize);
            if (filePath != null)
            {
                try
                {
                    // show du lieu truoc do trong table
                    table4Export.Rows.Clear();
                    // tao du lieu moi
                    GetDataFOrExport();
                    //export excel
                    ConfigExportFileModel configExportFile = new ConfigExportFileModel();
                    configExportFile.FilePath = filePath;
                    if (organizationMeetingid == -1)
                    {
                        GemboxUtils.Instance.ExportDataGridToFileCustom(dataGridview4Export, configExportFile, 4);//tua de, xuat file

                    }
                    else
                        GemboxUtils.Instance.ExportDataGridToFileCustom(dataGridview4Export, configExportFile, 5);//tua de, xuat file

                    GemboxUtils.Instance.ExportDataGridToFile(dataGridview4Export.Rows.Count);//tua de, xuat file
                    GemboxUtils.Instance.AutoFix();

                    //custom
                    //export general information
                    String lblRightAreaTitleScheduleMeeting = MessageValidate.GetMessage(rm, "lblRightAreaTitleScheduleMeeting");
                    GemboxUtils.Instance.AddHeader(lblRightAreaTitleScheduleMeeting == null ? string.Empty : lblRightAreaTitleScheduleMeeting);
                    int index = ConstantsEnum.positionIndexCol;
                    String value = "";
                    if (organizationMeetingid != -1)
                    {
                        String lblGoverningOrganization = MessageValidate.GetMessage(rm, "lblGoverningOrganization");
                        value = (lblGoverningOrganization == null ? string.Empty : lblGoverningOrganization) + " " + (organizationMeetingName == null ? string.Empty : organizationMeetingName);
                        GemboxUtils.Instance.AddCellCustom(index, 0, value == null ? string.Empty : value);
                        value = "";
                        index++;
                    }

                    String cbxFilterByDate = MessageValidate.GetMessage(rm, "cbxFilterByDate");
                    String lblTo = MessageValidate.GetMessage(rm, "lblTo");
                    String filterday = dateFroms.ToString("dd-MM-yyyy");
                    String filterday2 = dateTos.ToString("dd-MM-yyyy");
                    String fitler = cbxFilterByDate + " " + filterday;
                    String fitler2 = lblTo + " " + filterday2;

                    value = (fitler == null ? string.Empty : fitler) + " " + (fitler2 == null ? string.Empty : fitler2);
                    GemboxUtils.Instance.AddCellCustom(index, 0, value == null ? string.Empty : value);
                    value = "";
                    //end custom
                    index++;
                    GemboxUtils.Instance.AddCellCustom(index, 0, "");
                    index = ConstantsEnum.positionIndexCol;

                    try
                    {
                        GemboxUtils.Instance.Save();
                    }
                    catch (IOException x)
                    {
                        MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "fileExcelOpen"));
                    }
                }
                catch (Exception ex)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, ex.Message);
                    return;
                }
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "smsLinkFile") + filePath);
            }
        }
        #endregion

    }
}
