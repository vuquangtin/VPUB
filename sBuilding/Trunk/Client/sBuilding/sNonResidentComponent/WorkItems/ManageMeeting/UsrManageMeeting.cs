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
using System.Globalization;
using System.Windows.Forms;
using System.Drawing;
using sNonResidentComponent.Constants;
using sNonResidenComponent.WorkItems;
using sNonResidentComponent.Factory;
using sNonResidentComponent.Model.CustomObj;
using JavaCommunication;
using ClientModel.Model;
using ClientModel.Utils;
using System.IO;
using sMeetingComponent.Constants;
using sExcelExportComponent.ClientModel.Enums;
using sMeetingComponent.Model;
using sNonResidentComponent.Model.Old;
using sNonResidenComponent.WorkItems.ManageMeeting;

namespace sNonResidentComponent.WorkItems.ManageMeeting
{
    public partial class UsrManageMeeting : CommonUserControl
    {
        #region Properties
        public string sysFormatDate;

        int take = Enums.TAKE;
        int sum = 0;

        private DateTime dateFroms;
        private DateTime dateTos;
        private int currentPageIndex = 1;
        private const int hiddenFilterBoxHeight = 1;
        private int startupFilterBoxHeight;

        public long meetingId = 0;
        public bool statusMeetingNonresident = false;
        public string listPartakerNonresident = "";
        private DataTable dtbEventMeetingListObjList;
        private DataTable table4Export = null;

        List<EventMeeting> eventMeetingListObj;
        EventMeeting eventMeetingInfo;
        private NonResidentMeetingObj nonResidentMeetingObj;
        private BackgroundWorker loadEventMeetingListObjList;
        private BackgroundWorker bgwLoadOrganizationList;
        private BackgroundWorker bgwDeleteEventMeeting;

        public List<OrganizationMg> organizationListCbx;
        long organizationMeetingId = -1;
        String nameMeeting = "all";
        String updating = "updating";

        private NonResidentComponentWorkItem workItem;
        private ResourceManager rm;
        public DialogPostAction PostAction { get; private set; }
        [ServiceDependency]
        public NonResidentComponentWorkItem WorkItem
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

        public static String formatDateTime()
        {
            DateTimeFormatInfo dtfi = CultureInfo.CreateSpecificCulture("fr-FR").DateTimeFormat;
            String dateTimeFormat = dtfi.ShortDatePattern;
            return dateTimeFormat;
        }

        #region Contructors
        public UsrManageMeeting()
        {
            InitializeComponent();
            InitDataTableeventMeetingListObjList();

            sysFormatDate = UsrManageMeeting.formatDateTime();

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
        /// RegisterEvent
        /// đăng ký sự kiện
        /// </summary>
        private void RegisterEvent()
        {
            CreateBackgroundWorkerEvent();
            btnShowHide.Click += btnShowHide_Clicked;
            btnReload.Click += OnButtonReloadClicked;
            dgvAttendMeetingStatisticList.MouseDown += dgvAttendMeetingStatisticLists_MouseDown;
            dgvAttendMeetingStatisticList.CellClick += dgvAttendMeetingStatisticLists_Clicked;
            txtMeetingNameSearchs.TextChanged += txtMeetingNameSearchs_TextChanged;
            btnAddMeeting.Click += OnButtonAddMeeting_Clicked;
            btnUpdateMeeting.Click += OnButtongUpdateMeeting_clicked;
            btnCancel.Click += OnButtonCancelMeeting_clicked;
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
            this.btnAddMeeting.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnAddMeeting.Name);
            this.btnUpdateMeeting.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnUpdateMeeting.Name);
            this.btnCancel.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnCancel.Name);
            this.mniUpdateInfoMeeting.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.mniUpdateInfoMeeting.Name);
            this.mniInfoAttendMeeting.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.mniInfoAttendMeeting.Name);
            this.mniDeleteMeeting.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.mniDeleteMeeting.Name);
            this.mniUpdateInfoMeeting.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.mniUpdateInfoMeeting.Name);
            this.mniInfoAttendMeeting.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.mniInfoAttendMeeting.Name);
            this.mniDeleteMeeting.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.mniDeleteMeeting.Name);
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

        #region LoadEventMeetingListObjList : kiểm tra thông tin trước khi gửi yêu cầu load thông tin meeting
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
        /// ValidateData
        /// kiểm tra điều kiện lọc từ ngày đến ngày
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
                //  MessageBoxManager.ShowErrorMessageBox(this, String.Format(MessageValidate.GetMessage(rm, "smsValidateDate"), MessageValidate.GetMessage(rm, "lblStartTime"), MessageValidate.GetMessage(rm, "lblEndTime")))));
                UploadStatusBar();
                // MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "smsFilterDateSmeeting"));
                return false;
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

            //12 MANAGE : Lấy danh sách thông tin cuộc họp
            loadEventMeetingListObjList = new BackgroundWorker();
            loadEventMeetingListObjList.WorkerSupportsCancellation = true;
            loadEventMeetingListObjList.DoWork += OnLoadEventMeetingListObjWorkerDoWork;
            loadEventMeetingListObjList.RunWorkerCompleted += OnLoadEventMeetingListObjWorkerCompleted;

            //13 DELETE : HỦY cuộc họp
            bgwDeleteEventMeeting = new BackgroundWorker();
            bgwDeleteEventMeeting.WorkerSupportsCancellation = true;
            bgwDeleteEventMeeting.DoWork += DeleteEventMeetingWorkerDoWork;
            bgwDeleteEventMeeting.RunWorkerCompleted += DeleteEventMeetingRunWorkerCompleted;
        }

        #region Gửi yêu cầu lấy thông tin đơn vị tổ chức
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
                e.Result = OrganizationMgFactory.Instance.GetChannel().getOrganization(storageService.CurrentSessionId);
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
                OrganizationMg organizationMeetingItem = new OrganizationMg();
                string All = MessageValidate.GetMessage(rm, "All");
                organizationMeetingItem.name = All;
                organizationMeetingItem.id = -1;
                organizationListCbx = new List<OrganizationMg>();
                organizationListCbx.Add(organizationMeetingItem);
                //20170304 #Bug Fix- My Nguyen Start

                List<OrganizationMg> result = (List<OrganizationMg>)e.Result;

                //kiểm tra có null hay không
                if (result != null)
                {
                    if (result.Count != 0)
                    {
                        //các cơ quan tổ chức cuộc hopj
                        foreach (OrganizationMg o in result)
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

        #region Gửi yêu cầu xóa cuộc hop
        /// <summary>
        /// DeleteEventMeeting
        /// </summary>
        private void DeleteEventMeeting()
        {
            if (MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetMessage(rm, "smsQuestionYesNoDeleteMeeting")) == System.Windows.Forms.DialogResult.Yes)
            {
                if (!bgwDeleteEventMeeting.IsBusy)
                {
                    bgwDeleteEventMeeting.RunWorkerAsync();
                }
            }
        }

        /// <summary>
        /// DeleteEventMeetingWorkerDoWork
        /// delete meeting other
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteEventMeetingWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = (int)Status.SUCCESS == MeetingEventFactory.Instance.GetChannel().deleteEventMeeting(storageService.CurrentSessionId, meetingId);
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
            }
        }
        /// <summary>
        /// DeleteEventMeetingRunWorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteEventMeetingRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "smsErrorDeleteMeeting"));
                return;
            }
            if ((bool)e.Result)
            {
                //   MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "smsSuccessDeleteMeeting"));
                PostAction = DialogPostAction.SUCCESS;
                OnButtonReloadClicked(sender, e);
            }
            else
            {
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "smsErrorDeleteMeeting"));
                return;
            }
        }
        #endregion

        #region Load danh sách cuộc họp
        /// <summary>
        /// LoadEventMeetingListObjAtPage
        /// Load list meeting based on (start, end, dateFrom, dateTo, organizationMeetingId, nameMeeting);
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public NonResidentMeetingObj LoadEventMeetingListObjAtPage(int start, int end)
        {
            //string theDateIn = dtpDateIn.Value.ToString("yyyy-MM-dd");
            //string theDateIn2 = dtpDateIn2.Value.ToString("yyyy-MM-dd");
            NonResidentMeetingObj nonResidentMeetingObjnew = new NonResidentMeetingObj();

            String dateFrom = dateFroms.ToString("yyyy-MM-dd 00:00:00");
            String dateTo = dateTos.ToString("yyyy-MM-dd 00:00:00");

            try
            {
                nonResidentMeetingObjnew = MeetingEventFactory.Instance.GetChannel().getEventMeetingListByDateAndOrgIDAndMeetingName(StorageService.CurrentSessionId, start, end, dateFrom, dateTo, organizationMeetingId, nameMeeting);
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
            //}
            return nonResidentMeetingObjnew;
        }
        #endregion

        #region Gửi yêu cầu lấy thông tin cuộc họp
        /// <summary>
        ///  get meeting list based on from Date to date
        ///  OnLoadEventMeetingListObjWorkerDoWork
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadEventMeetingListObjWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            //string theDateIn = dtpDateIn.Value.ToString("yyyy-MM-dd");
            //string theDateIn2 = dtpDateIn2.Value.ToString("yyyy-MM-dd");
            int totalRecords = 0;
            int skip = 0;
            currentPageIndex = 1;
            nonResidentMeetingObj = LoadEventMeetingListObjAtPage(skip, take);
            List<EventMeeting> result = new List<EventMeeting>();
            try
            {
                e.Result = nonResidentMeetingObj;
            }
            catch (Exception ex) { }
            finally
            {
                if (nonResidentMeetingObj != null)
                {
                    //phân trang
                    sum = totalRecords = Convert.ToInt32(nonResidentMeetingObj.sum);
                    result = nonResidentMeetingObj.nonResidentMeetings;

                    eventMeetingListObj = result;
                    pagerPanel1.ShowNumberOfRecords(totalRecords, result != null ? result.Count : 0, take, currentPageIndex);
                    pagerPanel1.UpdatePagingLinks(totalRecords, take, currentPageIndex);
                }
                e.Result = result;
            }
        }

        /// <summary>
        /// không cho phân trang thi vẫn còn hiển thị thanh link, và không cho xuất exccel
        /// Change statusbar : message not data
        /// </summary>
        private void UploadStatusBar()
        {
            btnUpdateMeeting.Enabled = btnCancel.Enabled =
                btnExportToExcel.Enabled = false;
            pagerPanel1.ShowMessage(MessageValidate.GetMessage(rm, "lblMessageNotData"));
            pagerPanel1.UpdatePagingLinks(0, 1, 0);
        }

        /// <summary>
        ///  change status bar: have pagepanel , but not data
        ///  cho phân trang thi vẫn còn hiển thị thanh link, và cho xuất exccel
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
            //20170304 #Bug Fix- My Nguyen Start
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
            //20170304 #Bug Fix- My Nguyen End

        }
        #endregion

        #region HIển thị thông tin các cuộc họp nội bộ
        /// <summary>
        /// show info dmeeting list
        /// </summary>
        /// <param name="result"></param>
        public void LoadEventMeetingListObjListdata(List<EventMeeting> result)
        {

            // String dateTimeFormat = formatDateTime();
            //string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;

            int index = 0;
            eventMeetingListObj = result;
            dtbEventMeetingListObjList.Clear();

            for (int i = 0; i < result.Count; i++)
            {
                if (result[i].nonresident)
                {
                    DataRow row = dtbEventMeetingListObjList.NewRow();
                    row.BeginEdit();
                    index = index + 1;
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
            }
            if (dgvAttendMeetingStatisticList.Rows.Count > 0)
            {
                //20170304 #Bug Fix- My Nguyen Start
                //có dữ liệu moi hiene thị nút xóa , sua
                //btnUpdateMeeting.Enabled = btnCancel.Enabled = 
                // SetEnableds(false); //v2
                SetEnableds(true);//v3

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
        [CommandHandler(NonResidentCommandName.ShowManageMeeting)]
        public void ShowManageCardNonResidentMainHandler(object s, EventArgs e)
        {
            UsrManageMeeting uc = workItem.Items.Get<UsrManageMeeting>(NonResidentCommandName.MenuManageMeetingItem);
            if (uc == null)
            {
                uc = workItem.Items.AddNew<UsrManageMeeting>(NonResidentCommandName.MenuManageMeetingItem);
            }
            else if (uc.IsDisposed)
            {
                workItem.Items.Remove(uc);
                uc = workItem.Items.AddNew<UsrManageMeeting>(NonResidentCommandName.MenuManageMeetingItem);
            }

            workItem.Workspaces[WorkspaceName.MainWorkspace].Show(uc);
            uc.Parent.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(uc.rm, MenuNames.MenuManageMeetingItem);
        }
        #endregion

        #region  Event's 
        /// <summary>
        /// click btn show hide
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

                    //if (dgvAttendMeetingStatisticList.SelectedRows.Contains(dgvAttendMeetingStatisticList.Rows[e.RowIndex]))
                    //{
                    int colListPersonClickIndex = dgvAttendMeetingStatisticList.Columns[colListPerson.Name].Index;
                    //12
                    if (e.ColumnIndex == colListPersonClickIndex)
                        showInfoPartaker(sender, e);
                    else
                    {
                        ////20170307 #Bug Fix- My Nguyen Start
                        ////nếu là cuộc họp tự thêm mới cho chỉnh sửa, xóa
                        //bool check = true;
                        //try
                        //{
                        //    check = Convert.ToBoolean(dgvAttendMeetingStatisticList.Rows[rowIndex].Cells[colStatusNonResident.Name].Value);
                        //}
                        //catch (Exception exc) { }

                        //if (check)
                        //{
                        //    //btnUpdateMeeting.Enabled = true;
                        //    //btnCancel.Enabled = true;
                        // SetEnableds(true);
                        //}
                        //else
                        //{
                        //    SetEnableds(false);
                        //    //btnUpdateMeeting.Enabled = false;
                        //    //btnCancel.Enabled = false;
                        //}
                        ////20170307 #Bug Fix- My Nguyen End
                        ////}
                    }
                }
            }
        }

        /// <summary>
        /// click show list partaker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void showInfoPartaker(object sender, EventArgs e)
        {
            btnInfo_Click();
            if ((listPartakerNonresident.Equals("[]")) || (listPartakerNonresident.Equals("")))
            {
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "SmsNotInforAttendMeeting"));
                statusMeetingNonresident = false;

            }
            else
            {
                FrmPartakerList frmPartakerList = new FrmPartakerList(eventMeetingInfo, listPartakerNonresident);
                workItem.SmartParts.Add(frmPartakerList);
                frmPartakerList.ShowDialog();
                //có thể để bắt buộc phải tắt
                workItem.SmartParts.Remove(frmPartakerList);
                frmPartakerList.Dispose();
                statusMeetingNonresident = false;
            }

        }

        /// <summary>
        /// click info
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
                    statusMeetingNonresident = check;
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
        /// mouses down dgv
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

                            ////20170307 #Bug Fix- My Nguyen Start
                            ////nếu là cuộc họp tự thêm mới cho chỉnh sửa, xóa
                            //bool check = true;
                            //try
                            //{
                            //    check = Convert.ToBoolean(dgvAttendMeetingStatisticList.Rows[info.RowIndex].Cells[colStatusNonResident.Name].Value);
                            //}
                            //catch (Exception exc) { }
                            //if (check)
                            //{
                            //    // mniUpdateInfoMeeting.Enabled = true;
                            //    // mniDeleteMeeting.Enabled = true;
                            //SetEnableds(true);
                            //}
                            //else
                            //{
                            //    SetEnableds(false);
                            //    //   mniUpdateInfoMeeting.Enabled = false;
                            //    // mniDeleteMeeting.Enabled = false;
                            //}
                            ////20170307 #Bug Fix- My Nguyen End
                        }
                    }
                    Rectangle r = dgvAttendMeetingStatisticList.GetCellDisplayRectangle(info.ColumnIndex, info.RowIndex, true);
                    cmsPersoRecord.Show((Control)sender, e.X, e.Y);
                }
            }
        }

        /// <summary>
        /// set showhide btn delete, btn update
        /// </summary>
        /// <param name="status"></param>
        private void SetEnableds(bool status)
        {
            mniUpdateInfoMeeting.Enabled = status;
            mniDeleteMeeting.Enabled = status;
            btnUpdateMeeting.Enabled = status;
            btnCancel.Enabled = status;
        }

        /// <summary>
        /// click btn add
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonAddMeeting_Clicked(object sender, EventArgs e)
        {
            FrmAddMeeting frmUpdateNonResident = new FrmAddMeeting();
            workItem.SmartParts.Add(frmUpdateNonResident);
            frmUpdateNonResident.ShowDialog();
            //workItem.SmartParts.Remove(frmUpdateNonResident);
            //frmUpdateNonResident.Dispose();
            OnButtonReloadClicked(sender, e);
        }

        /// <summary>
        /// click btn update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtongUpdateMeeting_clicked(object sender, EventArgs e)
        {
            //btnInfo_Click(sender, e);
            btnInfo_Click();
            if (statusMeetingNonresident == true)
            {
                FrmUpdateMeeting frmUpdateNonResident = new FrmUpdateMeeting(meetingId);
                workItem.SmartParts.Add(frmUpdateNonResident);
                frmUpdateNonResident.ShowDialog();
                //workItem.SmartParts.Remove(frmUpdateNonResident);
                //frmUpdateNonResident.Dispose();
                statusMeetingNonresident = false;
                OnButtonReloadClicked(sender, e);
            }
            else
            {
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "smsErrorUpdateInfoMeetingNon"));
            }
        }

        /// <summary>
        /// click btn cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonCancelMeeting_clicked(object sender, EventArgs e)
        {
            btnInfo_Click();

            if (statusMeetingNonresident == true)
            {
                DeleteEventMeeting();
                statusMeetingNonresident = false;
            }
            else
            {
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "smsErrorDeleteMeetingNon"));
            }
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
                OrganizationMg organizationMeetingClick = (OrganizationMg)cbxNameOrgSearch.SelectedItem;
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
            SetEnableds(false);//v3
            LoadEventMeetingListObjList();
        }

        public void AutoRefreshWhenChangeTab() {
            try {
                OrganizationMg organizationMeetingClick = (OrganizationMg) cbxNameOrgSearch.SelectedItem;
                organizationMeetingId = organizationMeetingClick.id;
            } catch (Exception er) {
                organizationMeetingId = -1;
            }
            nameMeeting = txtMeetingNameSearchs.Text.ToString();
            if (nameMeeting.Equals("")) {
                nameMeeting = "all";
            }
            SetEnableds(false);//v3
            LoadEventMeetingListObjList();
        }

        /// <summary>
        /// pagerPanel_LinkLabelClicked
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

            NonResidentMeetingObj nonResidentMeetingObjnew = LoadEventMeetingListObjAtPage(skip, take);
            if (nonResidentMeetingObjnew != null)
            {
                List<EventMeeting> result = nonResidentMeetingObjnew.nonResidentMeetings;
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
        /// search name meeting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMeetingNameSearchs_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataView dv = new DataView(dtbEventMeetingListObjList);
                //20170307 #Bug Fix- My Nguyen Start
                string data = FormatCharacterSearch.CheckValue(txtMeetingNameSearchs.Text.Trim());
                dv.RowFilter = string.Format("MeetingName LIKE '%{0}%'", data);
                dgvAttendMeetingStatisticList.DataSource = dv;

                int record = dgvAttendMeetingStatisticList.Rows.Count;
                if (record > 0)
                {
                    SetEnableds(true);//v3
                    pagerPanel1.ShowNumberOfRecords(sum, record, take, currentPageIndex);
                }
                else
                {
                    SetEnableds(false);//v3
                    UploadStatusBarHavePagePanel();
                }
                //20170307 #Bug Fix- My Nguyen End
            }
            catch (Exception ex)
            {
                //dgvAttendMeetingStatisticList.DataSource = new DataView();
            }
        }

        #endregion

        #region Chuẩn bị dữ liệu xuất file excel
        //20170304 #Bug Fix- My Nguyen Start
        /// <summary>
        /// lay du dlieu tu server cho export data
        /// </summary>
        /// <param name="totalpage">tong so trang</param>
        /// <returns></returns>
        private void GetDataFOrExport()
        {
            // query lan dau de lay du lieu va so luong records
            NonResidentMeetingObj nonResidentMeetingObjnew = new NonResidentMeetingObj();

            String dateFrom = dateFroms.ToString("yyyy-MM-dd 00:00:00");
            String dateTo = dateTos.ToString("yyyy-MM-dd 00:00:00");

            try
            {
                int start = 0;
                int end = take;
                nonResidentMeetingObjnew = MeetingEventFactory.Instance.GetChannel().getEventMeetingListByDateAndOrgIDAndMeetingName(StorageService.CurrentSessionId, start, end, dateFrom, dateTo, organizationMeetingId, "all");
            }
            catch (Exception ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
            }

            //   CommonDataGridView dataExport = new CommonDataGridView();
            if (nonResidentMeetingObjnew != null)
            {

                // add data lan dau tien
                PrepareDataToExport(nonResidentMeetingObjnew.nonResidentMeetings);

                //phân trang
                int totalRecords = Convert.ToInt32(nonResidentMeetingObjnew.sum);

                //lay them du lieu neu khong du vi tong so record lon hon so take (take = 20) trong 1 trang
                if (totalRecords > take)
                {
                    int numberPage = (totalRecords / take) + ((totalRecords % take > 0) ? 1 : 0);
                    for (int i = 1; i < numberPage; i++)
                    {
                        int start = i * take;
                        int end = take;
                        nonResidentMeetingObjnew = MeetingEventFactory.Instance.GetChannel().getEventMeetingListByDateAndOrgIDAndMeetingName(StorageService.CurrentSessionId, start, end, dateFrom, dateTo, organizationMeetingId, "all");
                        PrepareDataToExport(nonResidentMeetingObjnew.nonResidentMeetings);
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
                //////row.BeginEdit();
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
                string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;

                row[colDateTime.DataPropertyName] = startDate.ToString(sysFormat);
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
        /// click export excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            String organizationMeetingName = "";
            long organizationMeetingid = -1;
            try
            {
                OrganizationMg organizationMeetingClick = (OrganizationMg)cbxNameOrgSearch.SelectedItem;
                organizationMeetingName = organizationMeetingClick.name;

                organizationMeetingid = organizationMeetingClick.id;
            }
            catch (Exception ex) { }
            if (organizationMeetingid == -1)
                organizationMeetingName = "";

            //  String name = MessageValidate.GetMessage(rm, "lblRightAreaTitleListAttendaceNonNew") + "_" + organizationMeetingName.ToString() + "_" + dateFroms.ToString("dd-MM-yyyy") + "_" + dateTos.ToString("dd-MM-yyyy");
            String name = MessageValidate.GetMessage(rm, "lblRightAreaTitleListAttendaceNonNew") + "_" + dateFroms.ToString("dd-MM-yyyy") + "_" + dateTos.ToString("dd-MM-yyyy");

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
                    String lblRightAreaTitleListAttendaceNonNew = MessageValidate.GetMessage(rm, "lblRightAreaTitleListAttendaceNonNew");
                    GemboxUtils.Instance.AddHeader(lblRightAreaTitleListAttendaceNonNew == null ? string.Empty : lblRightAreaTitleListAttendaceNonNew);
                    int index = 3;
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

                    try
                    {
                        GemboxUtils.Instance.Save();
                    }
                    catch (IOException x)
                    {
                        MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "fileExcelOpen"));
                    }
                    //end
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
