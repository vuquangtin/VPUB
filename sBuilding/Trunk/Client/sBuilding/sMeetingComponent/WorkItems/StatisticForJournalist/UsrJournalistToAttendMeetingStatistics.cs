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
using sMeetingComponent.Constants;
using sMeetingComponent.Model;
using sMeetingComponent.Factory;
using System.ServiceModel;
using System.ComponentModel;
using System.Linq;
using System.Collections.Generic;
using CommonHelper.Config;
using System.Windows.Forms;
using System.Drawing;
using ClientModel.Utils;
using ClientModel.Model;
using System.IO;
using sExcelExportComponent.ClientModel.Enums;
using sMeetingComponent.Model.CustomObj.JournalistObjForStatictis;

namespace sMeetingComponent.WorkItems.StatisticForJournalist
{
    public partial class UsrJournalistToAttendMeetingStatistics : CommonUserControl
    {

        #region Properties
        public string sysFormatDate;

        int take = Enums.TAKE;

        int sum = 0;

        private DateTime dateto;
        private DateTime dateTos;
        private int currentPageIndex = 1;
        private const int hiddenFilterBoxHeight = 1;
        private int startupFilterBoxHeight;
        public static long meetingId = long.MinValue;

        private DataTable dtbPersonAttendStatisticObjList;
        JournalistAttendStatisticObj personAttendStatisticObj;
        List<JournalistAttendStatistic> personAttendObjList;
        private DataTable table4Export = null;

        private BackgroundWorker loadPersonAttendStatisticObjList;
        private BackgroundWorker bgwLoadOrganizationList;
        public List<OrganizationMeeting> organizationList;
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
        /// <summary>
        /// UsrJournalistToAttendMeetingStatistics
        /// </summary>
        public UsrJournalistToAttendMeetingStatistics()
        {
            InitializeComponent();
            InitDataTablePersonAttendStatisticObjList();

            sysFormatDate = UsrListMeeting.formatDateTime();
            RegisterEvent();
        }
        #endregion

        /// <summary>
        /// InitDataTablePersonAttendStatisticObjList
        /// </summary>
        private void InitDataTablePersonAttendStatisticObjList()
        {
            dtbPersonAttendStatisticObjList = new DataTable();
            dtbPersonAttendStatisticObjList.Columns.Add(colSTT.DataPropertyName);
            dtbPersonAttendStatisticObjList.Columns.Add(colOrgMeetingId.DataPropertyName);
            dtbPersonAttendStatisticObjList.Columns.Add(colOrganizationMeetingName.DataPropertyName);
            dtbPersonAttendStatisticObjList.Columns.Add(colMeetingId.DataPropertyName);
            dtbPersonAttendStatisticObjList.Columns.Add(colMeetingName.DataPropertyName);
            dtbPersonAttendStatisticObjList.Columns.Add(colDateTime.DataPropertyName);
            dtbPersonAttendStatisticObjList.Columns.Add(colStartTime.DataPropertyName);
            dtbPersonAttendStatisticObjList.Columns.Add(colEndTime.DataPropertyName);
            dtbPersonAttendStatisticObjList.Columns.Add(colNumberPeopleAttend.DataPropertyName);
            dtbPersonAttendStatisticObjList.Columns.Add(colNumberAddPeopleAttend.DataPropertyName);
            dtbPersonAttendStatisticObjList.Columns.Add(colNumberJournalist.DataPropertyName);
            dtbPersonAttendStatisticObjList.Columns.Add(colNumberTotal.DataPropertyName);
            dtbPersonAttendStatisticObjList.Columns.Add(colNumberPeopleInvation.DataPropertyName);
            dgvAttendMeetingStatisticList.DataSource = dtbPersonAttendStatisticObjList;

            //20170304 #Bug Fix- My Nguyen Start
            // for export
            table4Export = new DataTable();

            table4Export.Columns.Add(colSTT.DataPropertyName);
            table4Export.Columns.Add(colOrgMeetingId.DataPropertyName);
            table4Export.Columns.Add(colOrganizationMeetingName.DataPropertyName);
            table4Export.Columns.Add(colMeetingId.DataPropertyName);
            table4Export.Columns.Add(colMeetingName.DataPropertyName);
            table4Export.Columns.Add(colDateTime.DataPropertyName);
            table4Export.Columns.Add(colStartTime.DataPropertyName);
            table4Export.Columns.Add(colEndTime.DataPropertyName);
            table4Export.Columns.Add(colNumberPeopleAttend.DataPropertyName);
            table4Export.Columns.Add(colNumberAddPeopleAttend.DataPropertyName);
            table4Export.Columns.Add(colNumberJournalist.DataPropertyName);
            table4Export.Columns.Add(colNumberTotal.DataPropertyName);
            table4Export.Columns.Add(colNumberPeopleInvation.DataPropertyName);

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
            startupFilterBoxHeight = pnlFilterBox.Height;
            pagerPanel1.LoadLanguage();

            SetLanguages();

            LoadOrganizationList();
            //20170304 #Bug Fix- My Nguyen Start
            LoadPersonAttendStatisticObjList();
            dateto = this.dtpDateIn.Value.Date;
            dateTos = this.dtpDateIn2.Value.Date;
            //20170304 #Bug Fix- My Nguyen End

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

            this.colNumberPeopleAttend.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNumberPeopleAttend.Name);
            this.colNumberAddPeopleAttend.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNumberAddPeopleAttend.Name);
            this.colNumberJournalist.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNumberJournalist.Name);
            this.colNumberTotal.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNumberTotal.Name);
            this.colNumberPeopleInvation.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNumberPeopleInvation.Name);

            this.colInfo.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colInfo.Name);

            //20170307 #Bug Fix- My Nguyen start
            this.dataGridViewTextBoxColumn2.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colSTT.Name);
            this.dataGridViewTextBoxColumn3.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOrganizationMeetingName.Name);
            this.dataGridViewTextBoxColumn5.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colMeetingName.Name);
            this.dataGridViewTextBoxColumn6.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colDateTime.Name);
            this.dataGridViewTextBoxColumn7.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colStartTime.Name);
            this.dataGridViewTextBoxColumn8.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colEndTime.Name);
            this.dataGridViewTextBoxColumn9.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNumberPeopleInvation.Name);
            this.dataGridViewTextBoxColumn10.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNumberPeopleAttend.Name);
            this.dataGridViewTextBoxColumn11.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNumberAddPeopleAttend.Name);
            this.dataGridViewTextBoxColumn12.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNumberJournalist.Name);
            this.dataGridViewTextBoxColumn13.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNumberTotal.Name);
            //20170307 #Bug Fix- My Nguyen End

            this.btnShowHide.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnShowHide.Name);

            this.btnExportToExcel.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnExportToExcel.Name);
            this.btnReload.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnReload.Name);

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

            //15. Thống kê BÁO CHÍ Lấy số lượng người tham dự họp
            loadPersonAttendStatisticObjList = new BackgroundWorker();
            loadPersonAttendStatisticObjList.WorkerSupportsCancellation = true;
            loadPersonAttendStatisticObjList.DoWork += OnLoadPersonAttendStatisticObjWorkerDoWork;
            loadPersonAttendStatisticObjList.RunWorkerCompleted += OnLoadPersonAttendStatisticObjWorkerCompleted;
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

        private void LoadOrganizationListWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = organizationList = OrganizationMeetingFactory.Instance.GetChannel().getOrganization(storageService.CurrentSessionId);
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
            //phai kiem tra truong hop khong load dx don vi
            if (e.Cancelled)
            {
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "SmsNotConnectData"));
                return;
            }
            //if (e.Result == null)
            //{
            //   // MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "smsNotFilter"));
            //    return;
            //}
            else
            {
                //đơn vị tổ chức lúc nào cũng hiển thị dòng tất cả
                //nên không kiểm tra null

                OrganizationMeeting organizationMeetingItem = new OrganizationMeeting();
                string All = MessageValidate.GetMessage(rm, "All");
                organizationMeetingItem.name = All;
                organizationMeetingItem.id = -1;
                //personAttendObjItem.meetingName = "-Tất cả-";
                //personAttendObjItem.meetingId = -1;
                organizationListCbx = new List<OrganizationMeeting>();
                organizationListCbx.Add(organizationMeetingItem);

                List<OrganizationMeeting> result = (List<OrganizationMeeting>)e.Result;
                if (result.Count != 0)
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        if (result[i].typeOrg == OrgEnum.ORG_SUB_ORG || result[i].typeOrg == OrgEnum.ORG_ORG)
                        {
                            organizationListCbx.Add(result[i]);
                        }
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

        #region LoadPersonAttendStatisticObjAtPage Load danh sách số lượng người đã tham dự cuộc họp của báo chí
        /// <summary>
        /// LoadPersonAttendStatisticObjAtPage
        /// Load list nummber journalist attend meeting based on  (start, end, dateFrom, dateTo, organizationMeetingId, nameMeeting);
        /// namemeeting (default = "all")
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public JournalistAttendStatisticObj LoadPersonAttendStatisticObjAtPage(int start, int end)
        {
            String dateFrom = dateto.ToString("yyyy-MM-dd 00:00:00");
            String dateTo = dateTos.ToString("yyyy-MM-dd 00:00:00");

            JournalistAttendStatisticObj personAttendStatisticObjnew = new JournalistAttendStatisticObj();
            try
            {
                personAttendStatisticObjnew = AttendMeetingStatisticFactory.Instance.GetChannel().getListAttendMeetingJournalistStatisticByDate(StorageService.CurrentSessionId, start, end, dateFrom, dateTo, organizationMeetingId, nameMeeting);
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
            return personAttendStatisticObjnew;
        }
        #endregion

        #region Gửi yêu cầu lấy thông tin người tham dự cuộc họp của báo chí
        /// <summary>
        /// LoadPersonAttendStatisticObjList
        /// </summary>
        private void LoadPersonAttendStatisticObjList()
        {
            if (ValidateData())
            {
                if (!loadPersonAttendStatisticObjList.IsBusy)
                {
                    dtbPersonAttendStatisticObjList.Rows.Clear();
                    pagerPanel1.ShowMessage(MessageValidate.GetMessage(rm, "smsLoading"));
                    loadPersonAttendStatisticObjList.RunWorkerAsync();
                }
            }
            else
            {
                dtbPersonAttendStatisticObjList.Rows.Clear();
            }
        }

        /// <summary>
        /// ValidateData
        /// kiểm tra điều kiện lọc từ ngày đến ngày
        /// </summary>
        /// <returns></returns>
        private bool ValidateData()
        {
            dateto = this.dtpDateIn.Value.Date;
            dateTos = this.dtpDateIn2.Value.Date;
            int result = DateTime.Compare(dateto, dateTos);
            if (result < 0)
                return true;
            else if (result == 0)
                return true;
            else
            {
                //20170304 #Bug Fix- My Nguyen Start
                //khoong hien thi tin nhan thong bao ma hien thi o thanh pannelpage
                UploadStatusBar();
                //20170304 #Bug Fix- My Nguyen End
                return false;
            }
        }

        /// <summary>
        ///  get attendmeeting list based on from Date to date
        ///  OnLoadPersonAttendStatisticObjWorkerDoWork
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadPersonAttendStatisticObjWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            int totalRecords = 0;
            int skip = 0;
            currentPageIndex = 1;
            List<JournalistAttendStatistic> result = new List<JournalistAttendStatistic>();

            try
            {
                e.Result = personAttendStatisticObj = LoadPersonAttendStatisticObjAtPage(skip, take);
            }
            catch (Exception ex) { }
            finally
            {
                if (personAttendStatisticObj != null)
                {
                    //phân trang
                    sum = totalRecords = Convert.ToInt32(personAttendStatisticObj.sum);

                    result = personAttendObjList = personAttendStatisticObj.journalistAttendStatistics;

                    //lấy thông tin nhà báo
                    //end

                    pagerPanel1.ShowNumberOfRecords(totalRecords, result != null ? result.Count : 0, take, currentPageIndex);
                    pagerPanel1.UpdatePagingLinks(totalRecords, take, currentPageIndex);
                }
                e.Result = result;
            }
        }
        //20170304 #Bug Fix- My Nguyen Start

        /// <summary>
        /// Change statusbar : message not data
        /// </summary>
        private void UploadStatusBar()
        {
            btnExportToExcel.Enabled = false;
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
        /// OnLoadPersonAttendStatisticObjWorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadPersonAttendStatisticObjWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
            else
            {
                List<JournalistAttendStatistic> result = (List<JournalistAttendStatistic>)e.Result;

                if (result.Count != 0)
                {
                    LoadPersonAttendStatisticObjListdata(result);
                }
                else
                {
                    UploadStatusBar();
                }
            }
        }
        //20170304 #Bug Fix- My Nguyen End
        #endregion

        #region Hiển thị thông tin người tham dự cuộc họp của báo chí
        /// <summary>
        /// show list info detail journalist attendmeeting 
        /// LoadPersonAttendStatisticObjListdata
        /// </summary>
        /// <param name="result"></param>
        public void LoadPersonAttendStatisticObjListdata(List<JournalistAttendStatistic> result)
        {
            int index = 0;
            dtbPersonAttendStatisticObjList.Clear();
            for (int i = 0; i < result.Count; i++)
            {
                DataRow row = dtbPersonAttendStatisticObjList.NewRow();
                row.BeginEdit();
                index = i + 1;
                row[colSTT.DataPropertyName] = index;

                DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                DateTime startDate = start.AddMilliseconds(Convert.ToUInt64(result[i].startTime)).ToLocalTime();
                DateTime endDate = start.AddMilliseconds(Convert.ToUInt64(result[i].endTime)).ToLocalTime();
                DateTime datedefault = new DateTime(1971, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                int compareDateEnd = DateTime.Compare(endDate, datedefault);
                row[colMeetingId.DataPropertyName] = result[i].meetingId;
                row[colMeetingName.DataPropertyName] = result[i].meetingName;

                row[colOrgMeetingId.DataPropertyName] = result[i].organizationMeetingId;
                row[colOrganizationMeetingName.DataPropertyName] = result[i].organizationMeetingName;

                //số lượng báo chí : số lượng được mời, số lượng tham dự
                row[colNumberJournalist.DataPropertyName] = result[i].numberJournalist;//số lương tham dự của nhà báo

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
                dtbPersonAttendStatisticObjList.Rows.Add(row);
            }
            if (dgvAttendMeetingStatisticList.Rows.Count > 0)
            {
                btnExportToExcel.Enabled = true;
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
        [CommandHandler(MeetingCommandName.ShowMeetingItemStatisticOfJournalist)]
        public void ShowMeetingStatisticOfJournalistMainHandler(object s, EventArgs e)
        {
            UsrJournalistToAttendMeetingStatistics uc = workItem.Items.Get<UsrJournalistToAttendMeetingStatistics>(MeetingCommandName.MenuMeetingItemStatisticOfJournalist);
            if (uc == null)
            {
                uc = workItem.Items.AddNew<UsrJournalistToAttendMeetingStatistics>(MeetingCommandName.MenuMeetingItemStatisticOfJournalist);
            }
            else if (uc.IsDisposed)
            {
                workItem.Items.Remove(uc);
                uc = workItem.Items.AddNew<UsrJournalistToAttendMeetingStatistics>(MeetingCommandName.MenuMeetingItemStatisticOfJournalist);
            }
            workItem.Workspaces[WorkspaceName.MainWorkspace].Show(uc);
            uc.Parent.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(uc.rm, MenuNames.MenuMeetingItemStatisticOfJournalist);
        }
        #endregion

        #region  Event's 
        /// <summary>
        /// btnShowHide_Clicked
        /// click btn showhide
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
            int colInfoClicked = dgvAttendMeetingStatisticList.Columns[colInfo.Name].Index;
            if (rowIndex != -1)
            {
                //13
                if (e.ColumnIndex == colInfoClicked)
                {
                    btnInfo_Click(sender, e);
                }
            }
        }

        /// <summary>
        /// click btn info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnInfo_Click(object sender, EventArgs e)
        {
            // Get selected rows
            var selectedRows = dgvAttendMeetingStatisticList.SelectedRows;
            int rowsCount = selectedRows.Count;
            if (rowsCount == 0)
            {
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessSelect(rm, "smsPleaseClickChooseInfo"), MessageValidate.GetErrorTitle(rm));
                return;
            }
            else
            {
                try
                {
                    JournalistAttendStatistic personAttendObjNew = new JournalistAttendStatistic();

                    String nameMeeting = selectedRows[0].Cells[colMeetingName.Name].Value.ToString();
                    String meetingIdStr = selectedRows[0].Cells[colMeetingId.Name].Value.ToString();
                    long meetingId = Convert.ToInt64(meetingIdStr);

                    for (int i = 0; i < personAttendObjList.Count; i++)
                    {
                        if (personAttendObjList[i].meetingId == meetingId)
                        {
                            personAttendObjNew = personAttendObjList[i];
                            break;
                        }
                    }
                    int total = 0;
                    try
                    {
                        total = personAttendObjNew.numberJournalist;//personAttendObjNew.numberJournalist + personAttendObjNew.numberPeopleAdded + personAttendObjNew.numberPeopleAttendInvited;
                    }
                    catch (Exception w) { }
                    if (total != 0)
                    {
                        //hien thi thong tin len from 
                        FrmJournalistInfoAttendMeetingStatistics dialog = new FrmJournalistInfoAttendMeetingStatistics(dateto, dateTos, meetingId, total, personAttendObjNew);
                        workItem.SmartParts.Add(dialog);
                        dialog.ShowDialog();
                        //workItem.SmartParts.Remove(dialog);
                        //dialog.Dispose();
                    }
                    else
                    {
                        MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "SmsNotInforAttendMeeting"));
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }
        /// <summary>
        /// mouse down dgv
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
            LoadPersonAttendStatisticObjList();
        }

        public void AutoRefreshWhenChangeTab() {
            try {
                OrganizationMeeting organizationMeetingClick = (OrganizationMeeting) cbxNameOrgSearch.SelectedItem;
                organizationMeetingId = organizationMeetingClick.id;
            } catch (Exception er) {
                organizationMeetingId = -1;
            }
            nameMeeting = txtMeetingNameSearchs.Text.ToString();
            if (nameMeeting.Equals("")) {
                nameMeeting = "all";
            }
            LoadPersonAttendStatisticObjList();
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
            dtbPersonAttendStatisticObjList.Rows.Clear();
            int skip = (currentPageIndex - 1) * take;
            int totalRecords = 0;

            JournalistAttendStatisticObj personAttendStatisticObjnew = LoadPersonAttendStatisticObjAtPage(skip, take);
            if (personAttendStatisticObjnew != null)
            {
                List<JournalistAttendStatistic> result = personAttendStatisticObjnew.journalistAttendStatistics;
                LoadPersonAttendStatisticObjListdata(result);

                personAttendObjList = result;
                totalRecords = Convert.ToInt32(sum);
                pagerPanel1.ShowNumberOfRecords(totalRecords, result != null ? result.Count : 0, take, currentPageIndex);
                pagerPanel1.UpdatePagingLinks(totalRecords, take, currentPageIndex);
            }
            else
            {
                UploadStatusBarHavePagePanel();
            }
        }

        /// <summary>
        /// search meeting name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMeetingNameSearchs_TextChanged(object sender, EventArgs e)
        {
            //20170304 #Bug Fix- My Nguyen Start
            try
            {
                DataView dv = new DataView(dtbPersonAttendStatisticObjList);
                //20170307 #Bug Fix- My Nguyen Start
                string data = FormatCharacterSearch.CheckValue(txtMeetingNameSearchs.Text.Trim());

                dv.RowFilter = string.Format("MeetingName LIKE'%{0}%'", data);

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
            //20170304 #Bug Fix- My Nguyen End

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
            String dateFrom = dateto.ToString("yyyy-MM-dd 00:00:00");
            String dateTo = dateTos.ToString("yyyy-MM-dd 00:00:00");

            // query lan dau de lay du lieu va so luong records
            JournalistAttendStatisticObj personAttendStatisticObjnew = new JournalistAttendStatisticObj();
            try
            {
                int start = 0;
                int end = take;

                personAttendStatisticObjnew = AttendMeetingStatisticFactory.Instance.GetChannel().getListAttendMeetingJournalistStatisticByDate(StorageService.CurrentSessionId, start, end, dateFrom, dateTo, organizationMeetingId, "all");
            }
            catch (Exception ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
            }

            if (personAttendStatisticObjnew != null)
            {
                if (personAttendStatisticObjnew.journalistAttendStatistics != null)
                {
                    // add data lan dau tien
                    PrepareDataToExport(personAttendStatisticObjnew.journalistAttendStatistics);
                }
                //phân trang
                int totalRecords = Convert.ToInt32(personAttendStatisticObj.sum);

                //lay them du lieu neu khong du vi tong so record lon hon so take (take = 20) trong 1 trang
                if (totalRecords > take)
                {
                    int numberPage = (totalRecords / take) + ((totalRecords % take > 0) ? 1 : 0);
                    for (int i = 1; i < numberPage; i++)
                    {
                        int start = i * take;
                        int end = take;
                        personAttendStatisticObjnew = AttendMeetingStatisticFactory.Instance.GetChannel().getListAttendMeetingJournalistStatisticByDate(StorageService.CurrentSessionId, start, end, dateFrom, dateTo, organizationMeetingId, "all");
                        if (personAttendStatisticObjnew != null)
                        {
                            if (personAttendStatisticObjnew.journalistAttendStatistics != null)
                            {
                                PrepareDataToExport(personAttendStatisticObjnew.journalistAttendStatistics);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        ///  add du lieu vao datagridview
        /// </summary>
        /// <param name="datagridview"></param>
        /// <param name="data"></param>
        private void PrepareDataToExport(List<JournalistAttendStatistic> result)
        {
            int index = table4Export.Rows.Count;
            for (int i = 0; i < result.Count; i++)
            {
                DataRow row = table4Export.NewRow();
                row.BeginEdit();
                index += 1;
                row[colSTT.DataPropertyName] = index;

                DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                DateTime startDate = start.AddMilliseconds(Convert.ToUInt64(result[i].startTime)).ToLocalTime();
                DateTime endDate = start.AddMilliseconds(Convert.ToUInt64(result[i].endTime)).ToLocalTime();
                DateTime datedefault = new DateTime(1971, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                int compareDateEnd = DateTime.Compare(endDate, datedefault);
                row[colMeetingId.DataPropertyName] = result[i].meetingId;
                row[colMeetingName.DataPropertyName] = result[i].meetingName;

                row[colOrgMeetingId.DataPropertyName] = result[i].organizationMeetingId;
                row[colOrganizationMeetingName.DataPropertyName] = result[i].organizationMeetingName;
                //số lượng báo chí : số lượng được mời, số lượng tham dự
                row[colNumberJournalist.DataPropertyName] = result[i].numberJournalist;//tham dự
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
        /// click export
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
                organizationMeetingid = organizationMeetingClick.id;
                organizationMeetingName = organizationMeetingClick.name;
            }
            catch (Exception ex) { }
            if (organizationMeetingid == -1)
                organizationMeetingName = "";
            //  String name = MessageValidate.GetMessage(rm, "lblRightAreaTitleListAttendaceOfJournalist") + "_" + organizationMeetingName + "_" + dateto.ToString("dd-MM-yyyy") + "_" + dateTos.ToString("dd-MM-yyyy");
            String name = MessageValidate.GetMessage(rm, "lblRightAreaTitleListAttendaceOfJournalist") + "_" + dateto.ToString("dd-MM-yyyy") + "_" + dateTos.ToString("dd-MM-yyyy");
            string filePath = ControlExtMethods.ShowSaveFileDialog(MessageValidate.GetMessage(rm, "smsChooseFileExport"), name, CategorizeExcel.Categorize);
            if (filePath != null)
            {
                try
                {
                    // show du lieu truoc do trong table
                    table4Export.Rows.Clear();
                    // tao du lieu moi
                    GetDataFOrExport();
                    //excel cach 2
                    ConfigExportFileModel configExportFile = new ConfigExportFileModel();
                    configExportFile.FilePath = filePath;
                    if (organizationMeetingid == -1)
                    {
                        GemboxUtils.Instance.ExportDataGridToFileCustom(dataGridview4Export, configExportFile, 4);//tua de, xuat file

                    }
                    else
                        GemboxUtils.Instance.ExportDataGridToFileCustom(dataGridview4Export, configExportFile, 5);//tua de, xuat file

                    GemboxUtils.Instance.AutoFixA4();
                    GemboxUtils.Instance.ExportDataGridToFile(dataGridview4Export.Rows.Count);
                    GemboxUtils.Instance.AutoFitAdvancedColIndex(3);
                    int widthA4 = configExportFile.GetSizePageA4Height();

                    WidthA4Percent withA4Percent = new WidthA4Percent(widthA4);
                    int widthCol = withA4Percent.GetWidth8();  //widthA4 * 8 / 100;
                    GemboxUtils.Instance.SetWidthColIndex(4, widthCol);//2300
                    GemboxUtils.Instance.SetWidthColIndex(5, widthCol);
                    GemboxUtils.Instance.SetWidthColIndex(6, widthCol);


                    GemboxUtils.Instance.AutoFixWidthColIndexEnd(2, configExportFile.GetSizePageA4Height());//21000:29700 SizePageA4Width = 21000;


                    //custom
                    //export general information
                    String lblRightAreaTitleListAttendaceOfJournalist = MessageValidate.GetMessage(rm, "lblRightAreaTitleListAttendaceOfJournalist");
                    GemboxUtils.Instance.AddHeader(lblRightAreaTitleListAttendaceOfJournalist == null ? string.Empty : lblRightAreaTitleListAttendaceOfJournalist);
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
                    String filterday = dateto.ToString("dd-MM-yyyy");
                    String filterday2 = dateTos.ToString("dd-MM-yyyy");
                    String fitler = cbxFilterByDate + " " + filterday;
                    String fitler2 = lblTo + " " + filterday2;

                    value = (fitler == null ? string.Empty : fitler) + " " + (fitler2 == null ? string.Empty : fitler2);
                    GemboxUtils.Instance.AddCellCustom(index, 0, value == null ? string.Empty : value);
                    value = "";
                    index++;

                    GemboxUtils.Instance.AddCellCustom(index, 0, value == null ? string.Empty : value);

                    index = ConstantsEnum.positionIndexCol;

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
        //20170304 #Bug Fix- My Nguyen eND
        #endregion

    }
}
