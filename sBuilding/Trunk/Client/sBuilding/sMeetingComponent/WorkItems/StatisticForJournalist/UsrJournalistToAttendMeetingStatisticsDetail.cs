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

using ClientModel.Model;
using ClientModel.Utils;
using System.IO;
using sExcelExportComponent.ClientModel.Enums;
using sMeetingComponent.Model.CustomObj.JournalistObjForStatictis;
using sMeetingComponent.Model.CustomObj.PersonInfoForStatictis;

namespace sMeetingComponent.WorkItems.StatisticForJournalist
{
    public partial class UsrJournalistToAttendMeetingStatisticsDetail : CommonUserControl
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
        String updating = "updating";

        public static long meetingId = -1;

        private DataTable dtbPersonAttendDetailList;
        JournalistAttendStatisticDetailObj personAttendDetailObj;
        List<JournalistAttendStatisticDetail> personAttendDetaillist;
        private DataTable table4Export = null;

        private long orgId = -1;
        private BackgroundWorker loadPersonAttendDetailList;
        private BackgroundWorker bgwLoadOrganizationList;
        private BackgroundWorker bgwLoadMeetingList;
        List<PersonAttendObj> personAttendObjList;
        List<PersonAttendObj> personAttendObjListCbx;

        public List<OrganizationMeeting> organizationList;
        public List<OrganizationMeeting> organizationListCbx;
        //long organizationMeetingId = 0;
        // String nameMeeting = "all";

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
        /// UsrJournalistToAttendMeetingStatisticsDetail
        /// </summary>
        public UsrJournalistToAttendMeetingStatisticsDetail()
        {
            InitializeComponent();
            InitDataTablePersonAttendDetailList();

            sysFormatDate = UsrListMeeting.formatDateTime();

            RegisterEvent();
        }
        #endregion

        /// <summary>
        /// InitDataTablePersonAttendDetailList
        /// </summary>
        private void InitDataTablePersonAttendDetailList()
        {
            dtbPersonAttendDetailList = new DataTable();
            dtbPersonAttendDetailList.Columns.Add(colMeetingId.DataPropertyName);
            dtbPersonAttendDetailList.Columns.Add(colMeetingName.DataPropertyName);
            dtbPersonAttendDetailList.Columns.Add(colOrganizationMeetingName.DataPropertyName);
            dtbPersonAttendDetailList.Columns.Add(colDateTime.DataPropertyName);
            dtbPersonAttendDetailList.Columns.Add(colStartTime.DataPropertyName);
            dtbPersonAttendDetailList.Columns.Add(colEndTime.DataPropertyName);
            dtbPersonAttendDetailList.Columns.Add(colOrderNum.DataPropertyName);
            dtbPersonAttendDetailList.Columns.Add(colOrgPartaker.DataPropertyName);

            dtbPersonAttendDetailList.Columns.Add(colPositionPartaker.DataPropertyName);
            
            dtbPersonAttendDetailList.Columns.Add(colNameAttendMeeting.DataPropertyName);
            dtbPersonAttendDetailList.Columns.Add(colPeopleAdded.DataPropertyName);
            dtbPersonAttendDetailList.Columns.Add(colJournalist.DataPropertyName);
            dtbPersonAttendDetailList.Columns.Add(colNote.DataPropertyName);
            dtbPersonAttendDetailList.Columns.Add(colInputTime.DataPropertyName);
            dtbPersonAttendDetailList.Columns.Add(colOutputTime.DataPropertyName);
            dgvPersonAttendDetail.DataSource = dtbPersonAttendDetailList;

            //20170304 #Bug Fix- My Nguyen Start
            // for export
            table4Export = new DataTable();
            table4Export.Columns.Add(colMeetingId.DataPropertyName);
            table4Export.Columns.Add(colMeetingName.DataPropertyName);
            table4Export.Columns.Add(colOrganizationMeetingName.DataPropertyName);
            table4Export.Columns.Add(colDateTime.DataPropertyName);
            table4Export.Columns.Add(colStartTime.DataPropertyName);
            table4Export.Columns.Add(colEndTime.DataPropertyName);
            table4Export.Columns.Add(colOrderNum.DataPropertyName);
            table4Export.Columns.Add(colOrgPartaker.DataPropertyName);

            table4Export.Columns.Add(colPositionPartaker.DataPropertyName);

            table4Export.Columns.Add(colNameAttendMeeting.DataPropertyName);
            table4Export.Columns.Add(colPeopleAdded.DataPropertyName);
            table4Export.Columns.Add(colJournalist.DataPropertyName);
            table4Export.Columns.Add(colNote.DataPropertyName);
            table4Export.Columns.Add(colInputTime.DataPropertyName);
            table4Export.Columns.Add(colOutputTime.DataPropertyName);

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
            txtNameSearch.TextChanged += txtNameSearchs_TextChanged;
            cbxNameOrgSearch.SelectedIndexChanged += cbxOrg_Clicked;
            cbxMeetingNameSearchs.SelectedIndexChanged += cbxNameMeeting_Clicked;
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
            //20170307 #Bug Fix- My Nguyen Start
            LoadPersonAttendDetailList();
            dateFroms = this.dtpDateIn.Value.Date;
            dateTos = this.dtpDateIn2.Value.Date;
            //20170307 #Bug Fix- My Nguyen End
            startupFilterBoxHeight = pnlFilterBox.Height;
        }

        #region language
        /// <summary>
        /// SetLanguages
        /// </summary>
        private void SetLanguages()
        {

            this.colMeetingId.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colMeetingId.Name);
            this.colMeetingName.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colMeetingName.Name);
            this.colOrganizationMeetingName.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOrganizationMeetingName.Name);

            this.colDateTime.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colDateTime.Name);
            this.colStartTime.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colStartTime.Name);
            this.colEndTime.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colEndTime.Name);

            this.colOrderNum.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOrderNum.Name);
            this.colPositionPartaker.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPositionPartaker.Name);

            this.colOrgPartaker.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOrgPartaker.Name);
            this.colNameAttendMeeting.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNameAttendMeeting.Name);

            this.colPeopleAdded.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPeopleAdded.Name);
            this.colJournalist.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colJournalist.Name);
            this.colDateTime.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colDateTime.Name);
            this.colInputTime.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colInputTime.Name);
            this.colOutputTime.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOutputTime.Name);
            this.colNote.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNote.Name);

            //20170307 #Bug Fix- My Nguyen start
            this.dataGridViewTextBoxColumn1.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOrderNum.Name);
            this.dataGridViewTextBoxColumn3.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colMeetingName.Name);
            this.dataGridViewTextBoxColumn4.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOrganizationMeetingName.Name);
            this.dataGridViewTextBoxColumn5.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colStartTime.Name);
            this.dataGridViewTextBoxColumn6.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colEndTime.Name);
            this.dataGridViewTextBoxColumn8.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOrgPartaker.Name);

            this.colPositionPartakerEx.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPositionPartaker.Name);

            this.dataGridViewTextBoxColumn7.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNameAttendMeeting.Name);
            this.dataGridViewCheckBoxColumn1.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPeopleAdded.Name);
            this.dataGridViewCheckBoxColumn2.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colJournalist.Name);
            this.dataGridViewTextBoxColumn9.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colDateTime.Name);
            this.dataGridViewTextBoxColumn10.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colInputTime.Name);
            this.dataGridViewTextBoxColumn11.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOutputTime.Name);
            this.dataGridViewTextBoxColumn12.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNote.Name);
            //20170307 #Bug Fix- My Nguyen end
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

            bgwLoadMeetingList = new BackgroundWorker();
            bgwLoadMeetingList.WorkerSupportsCancellation = true;
            bgwLoadMeetingList.DoWork += OnLoadMeetingWorkerDoWork;
            bgwLoadMeetingList.RunWorkerCompleted += OnLoadMeetingWorkerCompleted;

            //17: THống kê CHI TIẾT HỘI HỌP : LẤy thông tin chi tiết người tham dự họp của BÁO CHÍ
            loadPersonAttendDetailList = new BackgroundWorker();
            loadPersonAttendDetailList.WorkerSupportsCancellation = true;
            loadPersonAttendDetailList.DoWork += OnLoadPersonAttendDetailWorkerDoWork;
            loadPersonAttendDetailList.RunWorkerCompleted += OnLoadPersonAttendDetailWorkerCompleted;
        }

        #region Sự kiện click 1 đơn vị :  lấy thông tin cuộc họp liên quan đến orgid
        /// <summary>
        /// click cbx org
        /// TO GET list meeting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxOrg_Clicked(object sender, EventArgs e)
        {
            try
            {
                OrganizationMeeting organizationMeetingClick = (OrganizationMeeting)cbxNameOrgSearch.SelectedItem;
                orgId = organizationMeetingClick.id;
            }
            catch (Exception er)
            {
                orgId = -1;
            }

            LoadlEventMeetingListByOrgID();

        }
        private void LoadlEventMeetingListByOrgID()
        {
            if (ValidateData())
            {
                if (!bgwLoadMeetingList.IsBusy)
                {
                    bgwLoadMeetingList.RunWorkerAsync();
                }
            }
        }
        /// <summary>
        /// OnLoadMeetingWorkerDoWork
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadMeetingWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            String dateFrom = dateFroms.ToString("yyyy-MM-dd 00:00:00");
            String dateTo = dateTos.ToString("yyyy-MM-dd 00:00:00");
            try
            {
                e.Result = personAttendObjList = AttendMeetingStatisticFactory.Instance.GetChannel().getListAttendMeetingStatisticByDateAndOrgId(StorageService.CurrentSessionId, dateFrom, dateTo, orgId);
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
        /// OnLoadMeetingWorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadMeetingWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            PersonAttendObj personAttendObjItemOther = new PersonAttendObj();
            //personAttendObjItemOther.meetingName = "-Khác-";
            //personAttendObjItemOther.meetingId = 0;
            string All = MessageValidate.GetMessage(rm, "All");

            personAttendObjItemOther.meetingName = All;
            personAttendObjItemOther.meetingId = -1;

            personAttendObjListCbx = new List<PersonAttendObj>();
            personAttendObjListCbx.Add(personAttendObjItemOther);

            cbxMeetingNameSearchs.Enabled = false;
            this.cbxMeetingNameSearchs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;

            if (e.Cancelled)
            {
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "SmsNotConnectData"));
                return;
            }
            if (e.Result == null)
            {
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "SmsNotInforMeeting"));
                return;
            }
            else
            {
                List<PersonAttendObj> result = (List<PersonAttendObj>)e.Result;
                if (result.Count != 0)
                {
                    cbxMeetingNameSearchs.Enabled = true;
                    this.cbxMeetingNameSearchs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

                    personAttendObjListCbx.AddRange(result);
                    cbxMeetingNameSearchs.DataSource = personAttendObjListCbx.ToList();
                    cbxMeetingNameSearchs.ValueMember = "meetingId";
                    cbxMeetingNameSearchs.DisplayMember = "meetingName";//hiển thị
                    cbxMeetingNameSearchs.SelectedIndex = 0;
                }
                else
                {
                    cbxMeetingNameSearchs.Enabled = false;
                    this.cbxMeetingNameSearchs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;

                    cbxMeetingNameSearchs.DataSource = null;
                    cbxMeetingNameSearchs.DataSource = personAttendObjListCbx.ToList();
                    cbxMeetingNameSearchs.Text = "";
                    meetingId = -1;
                    ClearControlInfoMeeting();
                }
            }
        }

        /// <summary>
        /// ClearControlInfoMeeting
        /// Clear info meeting = null
        /// </summary>
        private void ClearControlInfoMeeting()
        {
            tbxOrgName.Text = string.Empty;
            txtNameMeeting.Text = string.Empty;

            txtDate.Text = string.Empty;
            txtdtpDateIn.Text = string.Empty;
            txtdtpDateIn2.Text = string.Empty;

            txtnumberJournalist.Text = string.Empty;
            txtnumberPeopleAdded.Text = string.Empty;
            txtnumberPeopleAttendInvited.Text = string.Empty;
            txtnumberPeopleInvited.Text = string.Empty;
            txtTotal.Text = string.Empty;
        }
        #endregion

        #region Sự kiện click chọn 1 cuộc họp : hiển thị thông tin người tham dự của cuộc họp 
        /// <summary>
        /// click cbx meeting
        /// TO GET Info meeting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxNameMeeting_Clicked(object sender, EventArgs e)
        {
            try
            {
                PersonAttendObj personAttendObjclick = (PersonAttendObj)cbxMeetingNameSearchs.SelectedItem;
                meetingId = personAttendObjclick.meetingId;
            }
            catch (Exception er)
            {
                meetingId = -1;
            }
            if (meetingId == -1)
            {
                ClearControlInfoMeeting();
                return;
            }
            else
            {
                LoadlInfoEventMeeting(meetingId);
            }
        }

        /// <summary>
        /// LoadlInfoEventMeeting
        /// Load info meeting and number attend meeting
        /// </summary>
        /// <param name="meetingId"></param>
        private void LoadlInfoEventMeeting(long meetingId)
        {
            for (int i = 0; i < personAttendObjList.Count; i++)
            {
                if (personAttendObjList[i].meetingId == meetingId)
                {

                    try
                    {
                        tbxOrgName.Text = personAttendObjList[i].organizationMeetingName;
                        txtNameMeeting.Text = personAttendObjList[i].meetingName;
                        DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                        DateTime startDate = start.AddMilliseconds(Convert.ToUInt64(personAttendObjList[i].startTime)).ToLocalTime();
                        DateTime endDate = start.AddMilliseconds(Convert.ToUInt64(personAttendObjList[i].endTime)).ToLocalTime();
                        DateTime datedefault = new DateTime(1971, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                        txtDate.Text = startDate.ToString(sysFormatDate);
                        txtdtpDateIn.Text = startDate.ToString("HH:mm");
                        txtdtpDateIn2.Text = endDate.ToString("HH:mm");

                        txtnumberPeopleAttendInvited.Text = personAttendObjList[i].numberJournalist.ToString();//tham du cua nha báo

                    }
                    catch (Exception e)
                    {
                        ClearControlInfoMeeting();
                    }

                }
            }
        }
        #endregion

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
                organizationListCbx = new List<OrganizationMeeting>();

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

        #region LoadPersonAttendDetailAtPage Load thông tin chi tiết danh sách người tham dự cuộc họp
        /// <summary>
        /// LoadPersonAttendDetailAtPage
        /// Load list detail info attend meeting based on (start, end, dateFrom, dateTo, orgId, meetingId);
        /// lấy dánh sách người tham dự dựa vào 
        /// vị trí bắt đầu, số lượng record cần hiển thị
        /// orgid ? -1 : id
        /// -1 hiển thị tất cả dữ liệu cuộc hợp 
        /// meetingid : -1 : id
        /// -1 hiển thị tất cả người tham dự tất cả các cuộc họp
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public JournalistAttendStatisticDetailObj LoadPersonAttendDetailAtPage(int start, int end)
        {
            String dateFrom = dateFroms.ToString("yyyy-MM-dd 00:00:00");
            String dateTo = dateTos.ToString("yyyy-MM-dd 00:00:00");

            JournalistAttendStatisticDetailObj personAttendDetailObjnew = new JournalistAttendStatisticDetailObj();
            try
            {
                personAttendDetailObjnew = AttendMeetingStatisticFactory.Instance.GetChannel().getListPersonAttendDetailJournalistByDateAndOrgIdAndMeetingId(StorageService.CurrentSessionId, start, end, dateFrom, dateTo, orgId, meetingId);
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
            return personAttendDetailObjnew;
        }
        #endregion

        #region Gửi yêu cầu lấy thông tin chi tiết người tham dự cuộc họp
        /// <summary>
        /// LoadPersonAttendDetailList
        /// </summary>
        private void LoadPersonAttendDetailList()
        {
            if (ValidateData())
            {
                if (!loadPersonAttendDetailList.IsBusy)
                {
                    dtbPersonAttendDetailList.Rows.Clear();
                    pagerPanel1.ShowMessage(MessageValidate.GetMessage(rm, "smsLoading"));
                    loadPersonAttendDetailList.RunWorkerAsync();
                }
            }
            else
            {
                dtbPersonAttendDetailList.Rows.Clear();
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
                //khoong hien thi tin nhan thong bao ma hien thi o thanh pannelpage
                UploadStatusBar();
                return false;
            }
        }

        /// <summary>
        /// OnLoadPersonAttendDetailWorkerDoWork
        ///  get list person detail attendmeeting based on from Date to date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadPersonAttendDetailWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            string theDateIn = dtpDateIn.Value.ToString("yyyy-MM-dd");
            string theDateIn2 = dtpDateIn2.Value.ToString("yyyy-MM-dd");
            int totalRecords = 0;
            int skip = 0;
            currentPageIndex = 1;
            List<JournalistAttendStatisticDetail> result = new List<JournalistAttendStatisticDetail>();

            try
            {
                e.Result = personAttendDetailObj = LoadPersonAttendDetailAtPage(skip, take);
            }
            catch (Exception ex) { }
            finally
            {
                if (personAttendDetailObj != null)
                {
                    //phân trang

                    //lấy thông tin nhà báo
                    if (personAttendDetailObj.attendStatisticDetails != null)
                    {
                        result = personAttendDetailObj.attendStatisticDetails;

                    }
                    // so luong bao chi tham du hop tong chua co so luong do
                    //sum = totalRecords = Convert.ToInt32(result.Count);
                    sum = totalRecords = Convert.ToInt32(personAttendDetailObj.sum);
                    //end

                    pagerPanel1.ShowNumberOfRecords(totalRecords, result != null ? result.Count : 0, take, currentPageIndex);
                    pagerPanel1.UpdatePagingLinks(totalRecords, take, currentPageIndex);

                }
                e.Result = result;
            }
        }

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
        /// OnLoadPersonAttendDetailWorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadPersonAttendDetailWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
                List<JournalistAttendStatisticDetail> result = (List<JournalistAttendStatisticDetail>)e.Result;

                if (result.Count != 0)
                {
                    LoadPersonAttendDetailListdata(result);
                }
                else
                {
                    UploadStatusBar();
                }
            }
        }
        #endregion

        #endregion

        /// <summary>
        /// show list info detail person attendmeeting
        /// LoadPersonAttendDetailListdata
        /// </summary>
        /// <param name="result"></param>
        public void LoadPersonAttendDetailListdata(List<JournalistAttendStatisticDetail> result)
        {
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            int index = 0;
            dtbPersonAttendDetailList.Clear();
            for (int i = 0; i < result.Count; i++)
            {
                //là nhà báo mới hiển thị
                DataRow row = dtbPersonAttendDetailList.NewRow();
                row.BeginEdit();
                index = index + 1;
                row[colOrderNum.DataPropertyName] = index;

                //thong tin cuoc hop chưa thêm vào
                DateTime startDatemeeting = start.AddMilliseconds(Convert.ToUInt64(result[i].startTime)).ToLocalTime();
                DateTime endDatemeeting = start.AddMilliseconds(Convert.ToUInt64(result[i].endTime)).ToLocalTime();
                DateTime datedefaultmeeting = new DateTime(1971, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                int compareDateEndmeeting = DateTime.Compare(endDatemeeting, datedefaultmeeting);

                row[colMeetingName.DataPropertyName] = result[i].meetingName;
                row[colOrganizationMeetingName.DataPropertyName] = result[i].organizationMeetingName;

                row[colDateTime.DataPropertyName] = startDatemeeting.ToString(sysFormatDate);

                row[colStartTime.DataPropertyName] = startDatemeeting.ToString("HH:mm");

                if (compareDateEndmeeting == 0)
                {
                    row[colEndTime.DataPropertyName] = updating;
                }
                else
                {
                    row[colEndTime.DataPropertyName] = endDatemeeting.ToString("HH:mm");
                }

                //thông tin ca nhân
                row[colOrgPartaker.DataPropertyName] = result[i].organizationAttendName;

                row[colPositionPartaker.DataPropertyName] = result[i].partakerPosition;

                row[colNameAttendMeeting.DataPropertyName] = result[i].partakerName;

                //row[colJournalist.DataPropertyName] = result[i].journalist;
                //row[colPeopleAdded.DataPropertyName] = result[i].add;

                row[colNote.DataPropertyName] = result[i].note;
                if (result[i].inputTime != null && result[i].inputTime != "")
                {
                    DateTime inputtime = start.AddMilliseconds(Convert.ToUInt64(result[i].inputTime)).ToLocalTime();
                    row[colInputTime.DataPropertyName] = inputtime.ToString("HH:mm");

                }
                if (result[i].outputTime != null && result[i].outputTime != "")
                {

                    DateTime endDate = start.AddMilliseconds(Convert.ToUInt64(result[i].outputTime)).ToLocalTime();
                    DateTime datedefault = new DateTime(1971, 1, 1, 0, 0, 0, DateTimeKind.Utc);

                    int compareDateEnd = DateTime.Compare(endDate, datedefault);

                    if (compareDateEnd == 0)
                    {
                        row[colOutputTime.DataPropertyName] = updating;
                    }
                    else
                    {
                        row[colOutputTime.DataPropertyName] = endDate.ToString("HH:mm");
                    }
                }
                row.EndEdit();
                dtbPersonAttendDetailList.Rows.Add(row);
            }
            if (dgvPersonAttendDetail.Rows.Count > 0)
            {
                btnExportToExcel.Enabled = true;

                //focur the first row in table
                dgvPersonAttendDetail.Rows[0].Selected = true;
            }
            else
            {
                UploadStatusBarHavePagePanel();
            }
        }

        #region CAB events
        [CommandHandler(MeetingCommandName.ShowMeetingItemStatisticDetailOfJournalist)]
        public void ShowMeetingStatisticsDetailOfJournalistMainHandler(object s, EventArgs e)
        {
            UsrJournalistToAttendMeetingStatisticsDetail uc = workItem.Items.Get<UsrJournalistToAttendMeetingStatisticsDetail>(MeetingCommandName.MenuMeetingItemStatisticDetailOfJournalist);
            if (uc == null)
            {
                uc = workItem.Items.AddNew<UsrJournalistToAttendMeetingStatisticsDetail>(MeetingCommandName.MenuMeetingItemStatisticDetailOfJournalist);
            }
            else if (uc.IsDisposed)
            {
                workItem.Items.Remove(uc);
                uc = workItem.Items.AddNew<UsrJournalistToAttendMeetingStatisticsDetail>(MeetingCommandName.MenuMeetingItemStatisticDetailOfJournalist);
            }

            workItem.Workspaces[WorkspaceName.MainWorkspace].Show(uc);
            uc.Parent.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(uc.rm, MenuNames.MenuMeetingItemStatisticDetailOfJournalist);
        }
        #endregion

        #region  Event's 
        /// <summary>
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
        /// click btn reload
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonReloadClicked(object sender, EventArgs e)
        {
            try
            {
                OrganizationMeeting organizationMeetingClick = (OrganizationMeeting)cbxNameOrgSearch.SelectedItem;
                orgId = organizationMeetingClick.id;
            }
            catch (Exception er)
            {
                orgId = -1;
            }
            //nameMeeting = txtNameSearch.Text.ToString();
            //if (nameMeeting.Equals(""))
            //{
            //    nameMeeting = "all";
            //}
            LoadPersonAttendDetailList();
        }

        public void AutoRefreshWhenChangeTab() {
            try {
                OrganizationMeeting organizationMeetingClick = (OrganizationMeeting) cbxNameOrgSearch.SelectedItem;
                orgId = organizationMeetingClick.id;
            } catch (Exception er) {
                orgId = -1;
            }
            //nameMeeting = txtNameSearch.Text.ToString();
            //if (nameMeeting.Equals(""))
            //{
            //    nameMeeting = "all";
            //}
            LoadPersonAttendDetailList();
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
            dtbPersonAttendDetailList.Rows.Clear();
            int skip = (currentPageIndex - 1) * take;
            int totalRecords = 0;

            JournalistAttendStatisticDetailObj personAttendDetailObjnew = LoadPersonAttendDetailAtPage(skip, take);
            if (personAttendDetailObjnew != null)
            {

                //lấy thông tin nhà báo
                List<JournalistAttendStatisticDetail> result = new List<JournalistAttendStatisticDetail>();
                if (personAttendDetailObjnew.attendStatisticDetails != null)
                    result = personAttendDetailObjnew.attendStatisticDetails;
                //end

                LoadPersonAttendDetailListdata(result);
                totalRecords = Convert.ToInt32(sum);
                pagerPanel1.ShowNumberOfRecords(totalRecords, result != null ? result.Count : 0, take, currentPageIndex);
                pagerPanel1.UpdatePagingLinks(totalRecords, take, currentPageIndex);
            }
            else
            {
                UploadStatusBarHavePagePanel();
            }
        }
        //20170304 #Bug Fix- My Nguyen Start

        /// <summary>
        /// search name meeting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNameSearchs_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataView dv = new DataView(dtbPersonAttendDetailList);
                //20170307 #Bug Fix- My Nguyen Start
                string data = FormatCharacterSearch.CheckValue(txtNameSearch.Text.Trim());

                dv.RowFilter = string.Format("NameAttendMeeting LIKE'%{0}%'", data);

                dgvPersonAttendDetail.DataSource = dv;

                int record = dgvPersonAttendDetail.Rows.Count;
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

        #region Chuẩn bị dữ liệu xuất file excel
        //20170304 #Bug Fix- My Nguyen Start
        /// <summary>
        /// lay du dlieu tu server cho export data
        /// </summary>
        /// <param name="totalpage">tong so trang</param>
        /// <returns></returns>
        private void GetDataFOrExport()
        {

            String dateFrom = dateFroms.ToString("yyyy-MM-dd 00:00:00");
            String dateTo = dateTos.ToString("yyyy-MM-dd 00:00:00");
            // query lan dau de lay du lieu va so luong records
            JournalistAttendStatisticDetailObj personAttendDetailObjnew = new JournalistAttendStatisticDetailObj();
            try
            {
                int start = 0;
                int end = take;
                personAttendDetailObjnew = AttendMeetingStatisticFactory.Instance.GetChannel().getListPersonAttendDetailJournalistByDateAndOrgIdAndMeetingId(StorageService.CurrentSessionId, start, end, dateFrom, dateTo, orgId, meetingId);
            }
            catch (Exception ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
            }

            CommonDataGridView dataExport = new CommonDataGridView();
            if (personAttendDetailObjnew != null)
            {
                //lấy thông tin nhà báo
                personAttendDetaillist = new List<JournalistAttendStatisticDetail>();
                if (personAttendDetailObjnew.attendStatisticDetails != null)
                    personAttendDetaillist = personAttendDetailObjnew.attendStatisticDetails;
                PrepareDataToExport(personAttendDetaillist);
                //end

                //phân trang
                int totalRecords = Convert.ToInt32(personAttendDetailObjnew.sum);

                //lay them du lieu neu khong du vi tong so record lon hon so take (take = 20) trong 1 trang
                if (totalRecords > take)
                {
                    int numberPage = (totalRecords / take) + ((totalRecords % take > 0) ? 1 : 0);
                    for (int i = 1; i < numberPage; i++)
                    {
                        //int start = i * take + 1;
                        int start = i * take;
                        int end = take;
                        personAttendDetailObjnew = AttendMeetingStatisticFactory.Instance.GetChannel().getListPersonAttendDetailJournalistByDateAndOrgIdAndMeetingId(StorageService.CurrentSessionId, start, end, dateFrom, dateTo, orgId, meetingId);
                        if (personAttendDetailObjnew != null)
                        {

                            //lấy thông tin nhà báo
                            personAttendDetaillist = new List<JournalistAttendStatisticDetail>();
                            if (personAttendDetailObjnew.attendStatisticDetails != null)
                                personAttendDetaillist = personAttendDetailObjnew.attendStatisticDetails;
                            PrepareDataToExport(personAttendDetaillist);
                            //end
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
        private void PrepareDataToExport(List<JournalistAttendStatisticDetail> result)
        {
            int index = table4Export.Rows.Count;

            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            for (int i = 0; i < result.Count; i++)
            {
                //là nhà báo mới hiển thị
                DataRow row = table4Export.NewRow();
                row.BeginEdit();
                index += 1;
                row[colOrderNum.DataPropertyName] = index;

                //thong tin cuoc hop chưa thêm vào
                DateTime startDatemeeting = start.AddMilliseconds(Convert.ToUInt64(result[i].startTime)).ToLocalTime();
                DateTime endDatemeeting = start.AddMilliseconds(Convert.ToUInt64(result[i].endTime)).ToLocalTime();
                DateTime datedefaultmeeting = new DateTime(1971, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                int compareDateEndmeeting = DateTime.Compare(endDatemeeting, datedefaultmeeting);

                row[colMeetingName.DataPropertyName] = result[i].meetingName;
                row[colOrganizationMeetingName.DataPropertyName] = result[i].organizationMeetingName;

                row[colDateTime.DataPropertyName] = startDatemeeting.ToString(sysFormatDate);

                row[colStartTime.DataPropertyName] = startDatemeeting.ToString("HH:mm");

                if (compareDateEndmeeting == 0)
                {
                    row[colEndTime.DataPropertyName] = updating;
                }
                else
                {
                    row[colEndTime.DataPropertyName] = endDatemeeting.ToString("HH:mm");
                }

                //thông tin ca nhân
                row[colOrgPartaker.DataPropertyName] = result[i].organizationAttendName;

                row[colPositionPartaker.DataPropertyName] = result[i].partakerPosition;

                row[colNameAttendMeeting.DataPropertyName] = result[i].partakerName;

                //row[colJournalist.DataPropertyName] = result[i].journalist;
                //row[colPeopleAdded.DataPropertyName] = result[i].add;

                row[colNote.DataPropertyName] = result[i].note;
                if (result[i].inputTime != null && result[i].inputTime != "")
                {
                    DateTime inputtime = start.AddMilliseconds(Convert.ToUInt64(result[i].inputTime)).ToLocalTime();
                    row[colInputTime.DataPropertyName] = inputtime.ToString("HH:mm");
                }
                if (result[i].outputTime != null && result[i].outputTime != "")
                {

                    DateTime endDate = start.AddMilliseconds(Convert.ToUInt64(result[i].outputTime)).ToLocalTime();
                    DateTime datedefault = new DateTime(1971, 1, 1, 0, 0, 0, DateTimeKind.Utc);

                    int compareDateEnd = DateTime.Compare(endDate, datedefault);

                    if (compareDateEnd == 0)
                    {
                        row[colOutputTime.DataPropertyName] = updating;
                    }
                    else
                    {
                        row[colOutputTime.DataPropertyName] = endDate.ToString("HH:mm");
                    }
                }
                row.EndEdit();

                table4Export.Rows.Add(row);
            }

        }

        #region xác định vị trí bảng dgv hiển thị
        /// <summary>
        /// check index start in file export
        /// </summary>
        /// <param name="isall"></param>
        /// <param name="ismeeting"></param>
        /// <returns></returns>
        public int CheckRecordStart(bool isall, bool ismeeting)
        {
            //export general information
            int indexrecord = 3;
            if (isall)
            {
                indexrecord = 4;
                //có tên cuộc họp
                if (ismeeting)
                {
                    indexrecord = 9;
                }

            }

            return indexrecord;
        }
        #endregion

        /// <summary>
        /// click btn export
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            OrganizationMeeting organizationMeetingClick = new OrganizationMeeting();
            String organizationMeetingName = "";
            try
            {
                organizationMeetingClick = (OrganizationMeeting)cbxNameOrgSearch.SelectedItem;
                organizationMeetingName = organizationMeetingClick.name;
            }
            catch (Exception xe)
            {
                organizationMeetingClick.id = -1;
            }

            PersonAttendObj nameMeeting = new PersonAttendObj();
            String nameMeetingStr = "";
            try
            {

                nameMeeting = (PersonAttendObj)cbxMeetingNameSearchs.SelectedItem;
                nameMeetingStr = nameMeeting.meetingName;
            }
            catch (Exception xe)
            {
                nameMeeting.meetingId = -1;
            }
            // String name = MessageValidate.GetMessage(rm, "lblRightAreaTitleListAttendaceDetailOfJournalist") + "_" + organizationMeetingName.ToString() + "_" + nameMeetingStr.ToString() + "_" + dateFroms.ToString("dd-MM-yyyy") + "_" + dateTos.ToString("dd-MM-yyyy");
            String name = MessageValidate.GetMessage(rm, "lblRightAreaTitleListAttendaceDetailOfJournalist") + "_" + dateFroms.ToString("dd-MM-yyyy") + "_" + dateTos.ToString("dd-MM-yyyy");

            string filePath = ControlExtMethods.ShowSaveFileDialog(MessageValidate.GetMessage(rm, "smsChooseFileExport"), name, CategorizeExcel.Categorize);
            if (filePath != null)
            {
                try
                {
                    // show du lieu truoc do trong table
                    table4Export.Rows.Clear();
                    // tao du lieu moi
                    GetDataFOrExport();

                    int recordStart = 3;
                    bool isall = false;
                    bool ismeeting = false;

                    if (organizationMeetingClick.id < 0)
                    { // tất cả đơn vi
                        isall = false;
                        ismeeting = false;
                        recordStart = CheckRecordStart(false, false);
                    }
                    else if (nameMeeting.meetingId < 0)
                    {
                        //có đơn vị không có cuộc họp
                        isall = true;
                        ismeeting = false;
                        recordStart = CheckRecordStart(true, false);
                    }
                    else
                    {   //có cả 2
                        isall = true;
                        ismeeting = true;
                        recordStart = CheckRecordStart(true, true);

                    }

                    ConfigExportFileModel configExportFile = new ConfigExportFileModel();
                    configExportFile.FilePath = filePath;
                    GemboxUtils.Instance.ExportDataGridToFileCustom(dataGridview4Export, configExportFile, recordStart);//tua de, xuat file
                    GemboxUtils.Instance.AutoFixA4();
                    GemboxUtils.Instance.ExportDataGridToFile(dataGridview4Export.Rows.Count);//tua de, xuat file

                    int widthA4 = configExportFile.GetSizePageA4Height();

                    WidthA4Percent withA4Percent = new WidthA4Percent(widthA4);
                    int widthCol = withA4Percent.GetWidth13();  //widthA4 * 8 / 100;
                    GemboxUtils.Instance.SetWidthColIndex(2, widthCol);//2300
                    GemboxUtils.Instance.AutoFixWidthColIndexEnd(1, configExportFile.GetSizePageA4Height());//dòng tên

                    #region xác định vị trí bắt đầu bảng dữ liệu

                    //custom
                    //export general information
                    String lblRightAreaTitleListAttendaceDetailOfJournalist = MessageValidate.GetMessage(rm, "lblRightAreaTitleListAttendaceDetailOfJournalist");
                    GemboxUtils.Instance.AddHeader(lblRightAreaTitleListAttendaceDetailOfJournalist == null ? string.Empty : lblRightAreaTitleListAttendaceDetailOfJournalist);
                    int index = ConstantsEnum.positionIndexCol;

                    //export general information
                    if (isall)
                    {
                        String lblGoverningOrganization = MessageValidate.GetMessage(rm, "lblGoverningOrganization");
                        String value = (lblGoverningOrganization == null ? string.Empty : lblGoverningOrganization) + " ";
                        OrganizationMeeting organizationMeetingClicknew = (OrganizationMeeting)cbxNameOrgSearch.SelectedItem;
                        String organizationMeetingNamenew = organizationMeetingClicknew.name;
                        if (organizationMeetingNamenew != "")
                        {
                            value += (organizationMeetingNamenew == null ? string.Empty : organizationMeetingNamenew.ToString());
                            GemboxUtils.Instance.AddCellCustom(index, 0, value == null ? string.Empty : value);
                        }
                        else
                        {
                            value += (tbxOrgName.Text == null ? string.Empty : tbxOrgName.Text.ToString());
                            GemboxUtils.Instance.AddCellCustom(index, 0, value == null ? string.Empty : value);
                        }
                        value = "";
                        index++;
                        //có tên cuộc họp
                        if (ismeeting)
                        {
                            String lblMeeting = MessageValidate.GetMessage(rm, "lblMeeting");
                            value = (lblMeeting == null ? string.Empty : lblMeeting) + " " + (txtNameMeeting.Text == null ? string.Empty : txtNameMeeting.Text.ToString());
                            GemboxUtils.Instance.AddCellCustom(index, 0, value == null ? string.Empty : value);
                            value = "";
                            index++;
                            String lblTime = MessageValidate.GetMessage(rm, "lblTime");
                            value = (lblTime == null ? string.Empty : lblTime) + " " + (txtDate.Text == null ? string.Empty : txtDate.Text.ToString());
                            GemboxUtils.Instance.AddCellCustom(index, 0, value == null ? string.Empty : value);
                            value = ""; index++;
                            String lblHour = MessageValidate.GetMessage(rm, "lblHour");
                            value = (lblHour == null ? string.Empty : lblHour) + " " + (txtdtpDateIn.Text == null ? string.Empty : txtdtpDateIn.Text.ToString());
                            String lblHourEnd = MessageValidate.GetMessage(rm, "lblHourEnd");
                            value += " " + (lblHourEnd == null ? string.Empty : lblHourEnd) + " " +
                               (txtdtpDateIn2.Text == null ? string.Empty : txtdtpDateIn2.Text.ToString());
                            GemboxUtils.Instance.AddCellCustom(index, 0, value == null ? string.Empty : value);
                            value = ""; index++;

                            String lblnumberPeopleAttendInvited = MessageValidate.GetMessage(rm, "lblnumberJournalist");
                            GemboxUtils.Instance.AddCellCustom(index, 0, lblnumberPeopleAttendInvited == null ? string.Empty : lblnumberPeopleAttendInvited);
                            GemboxUtils.Instance.AddCellCustom(index, 1, txtnumberPeopleAttendInvited.Text == null ? string.Empty : txtnumberPeopleAttendInvited.Text.ToString());
                            value = (lblnumberPeopleAttendInvited == null ? string.Empty : lblnumberPeopleAttendInvited) + " "
                                + (txtnumberPeopleAttendInvited.Text == null ? string.Empty : txtnumberPeopleAttendInvited.Text.ToString());
                            GemboxUtils.Instance.AddCellCustom(index, 0, value == null ? string.Empty : value);
                            value = ""; index++;
                        }
                    }
                    GemboxUtils.Instance.AddCellCustom(index, 0, "");

                    index = ConstantsEnum.positionIndexCol;

                    isall = false;
                    ismeeting = false;
                    #endregion

                    //end custom
                    try
                    {
                        GemboxUtils.Instance.Save();
                    }
                    catch (IOException xx)
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
