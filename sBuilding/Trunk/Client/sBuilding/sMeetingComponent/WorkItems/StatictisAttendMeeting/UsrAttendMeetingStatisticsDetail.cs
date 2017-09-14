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
using sMeetingComponent.Model.CustomObj.PersonInfoForStatictis;

namespace sMeetingComponent.WorkItems.StatictisAttendMeeting
{
    public partial class UsrAttendMeetingStatisticsDetail : CommonUserControl
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
        private long orgId = -1;

        private DataTable dtbPersonAttendDetailList;
        PersonAttendDetailObj personAttendDetailObj;

        private List<PersonAttendDetail> personAttendDetaillist;

        private DataTable table4Export = null;

        private BackgroundWorker loadPersonAttendDetailList;
        private BackgroundWorker bgwLoadOrganizationList;
        private BackgroundWorker bgwLoadMeetingList;
        List<PersonAttendObj> personAttendObjList;
        List<PersonAttendObj> personAttendObjListCbx;

        public List<OrganizationMeeting> organizationList;
        public List<OrganizationMeeting> organizationListCbx;

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
        public UsrAttendMeetingStatisticsDetail()
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

            dtbPersonAttendDetailList.Columns.Add(colPositionPartaker.DataPropertyName);

            dtbPersonAttendDetailList.Columns.Add(colOrgPartaker.DataPropertyName);
            dtbPersonAttendDetailList.Columns.Add(colNameAttendMeeting.DataPropertyName);
            dtbPersonAttendDetailList.Columns.Add(colPeopleAdded.DataPropertyName);
            dtbPersonAttendDetailList.Columns.Add(colJournalist.DataPropertyName);
            dtbPersonAttendDetailList.Columns.Add(colNote.DataPropertyName);
            dtbPersonAttendDetailList.Columns.Add(colInputTime.DataPropertyName);
            dtbPersonAttendDetailList.Columns.Add(colOutputTime.DataPropertyName);

            dtbPersonAttendDetailList.Columns.Add(colIsNonResident.DataPropertyName);
            dtbPersonAttendDetailList.Columns.Add(colIdentityCard.DataPropertyName);
            dtbPersonAttendDetailList.Columns.Add(colPhone.DataPropertyName);

            dtbPersonAttendDetailList.Columns.Add(colCheck.DataPropertyName);

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

            table4Export.Columns.Add(colPositionPartaker.DataPropertyName);

            table4Export.Columns.Add(colOrgPartaker.DataPropertyName);
            table4Export.Columns.Add(colNameAttendMeeting.DataPropertyName);
            table4Export.Columns.Add(colPeopleAdded.DataPropertyName);
            table4Export.Columns.Add(colJournalist.DataPropertyName);
            table4Export.Columns.Add(colNote.DataPropertyName);
            table4Export.Columns.Add(colInputTime.DataPropertyName);

            table4Export.Columns.Add(colIsNonResidentEx.DataPropertyName);
            table4Export.Columns.Add(colIdentityCardEx.DataPropertyName);
            table4Export.Columns.Add(colPhoneEx.DataPropertyName);

            table4Export.Columns.Add(colOutputTime.DataPropertyName);

            table4Export.Columns.Add(colCheckEx.DataPropertyName);

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

            this.colIsNonResident.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colIsNonResident.Name);
            this.colIdentityCard.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colIdentityCard.Name);
            this.colPhone.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPhone.Name);

            this.colNote.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNote.Name);
            this.colCheck.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colCheck.Name);

            //20170307 #Bug Fix- My Nguyen start
            this.dataGridViewTextBoxColumn1.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOrderNum.Name);
            this.dataGridViewTextBoxColumn3.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colMeetingName.Name);
            this.dataGridViewTextBoxColumn4.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOrganizationMeetingName.Name);
            this.dataGridViewTextBoxColumn5.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colStartTime.Name);
            this.dataGridViewTextBoxColumn6.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colEndTime.Name);

            this.colPositionPartakerEx.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPositionPartaker.Name);

            this.dataGridViewTextBoxColumn8.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOrgPartaker.Name);
            this.dataGridViewTextBoxColumn7.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNameAttendMeeting.Name);
            this.dataGridViewCheckBoxColumn1.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPeopleAdded.Name);
            this.dataGridViewCheckBoxColumn2.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colJournalist.Name);
            this.dataGridViewTextBoxColumn9.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colDateTime.Name);
            this.dataGridViewTextBoxColumn10.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colInputTime.Name);
            this.dataGridViewTextBoxColumn11.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOutputTime.Name);

            this.colIsNonResidentEx.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colIsNonResident.Name);
            this.colIdentityCardEx.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colIdentityCard.Name);
            this.colPhoneEx.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPhone.Name);

            this.colCheckEx.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colCheck.Name);

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

        #region LoadPersonAttendDetailList
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
        #endregion

        #region bgWorker
        /// <summary>
        /// /CreateBackgroundWorkerEvent
        /// </summary>
        private void CreateBackgroundWorkerEvent()
        {
            bgwLoadOrganizationList = new BackgroundWorker();
            bgwLoadOrganizationList.WorkerSupportsCancellation = true;
            bgwLoadOrganizationList.DoWork += LoadOrganizationListWorkerDoWork;
            bgwLoadOrganizationList.RunWorkerCompleted += LoadOrganizationListRunWorkerCompleted;

            //13:LẤY THÔNG TIN CHI TIẾT CUỘC HỌP và số lượng người tham dự họp
            bgwLoadMeetingList = new BackgroundWorker();
            bgwLoadMeetingList.WorkerSupportsCancellation = true;
            bgwLoadMeetingList.DoWork += OnLoadMeetingWorkerDoWork;
            bgwLoadMeetingList.RunWorkerCompleted += OnLoadMeetingWorkerCompleted;

            //14: THống kê CHI TIẾT HỘI HỌP : LẤy thông tin chi tiết người tham dự họp
            loadPersonAttendDetailList = new BackgroundWorker();
            loadPersonAttendDetailList.WorkerSupportsCancellation = true;
            loadPersonAttendDetailList.DoWork += OnLoadPersonAttendDetailWorkerDoWork;
            loadPersonAttendDetailList.RunWorkerCompleted += OnLoadPersonAttendDetailWorkerCompleted;
        }
        #endregion

        #region Khi chọn 1 dòng thông tin đơn vị : Gửi yêu cầu load danh sách cuộc họp thuộc đơn vị (conbobox meeting)
        /// <summary>
        /// click cbx org
        /// khi chọn 1 đơn vị cụ thể 
        /// thì sẽ load lại thông tin các cuộc họp thuộc đơn vị được lựa chọn
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

                cbxMeetingNameSearchs.Enabled = false;
                this.cbxMeetingNameSearchs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;

                cbxMeetingNameSearchs.DataSource = null;
                cbxMeetingNameSearchs.DataSource = personAttendObjListCbx.ToList();
                cbxMeetingNameSearchs.Text = "";
                meetingId = -1;
                ClearControlInfoMeeting();
                return;
            }
            else
            {
                List<PersonAttendObj> result = (List<PersonAttendObj>)e.Result;
                if (result.Count != 0)
                {
                    cbxMeetingNameSearchs.Enabled = true;
                    //cbx dưới dạng list thì không thể nhấn chữ vào được cbx
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
        /// clear dữ liệu cuộc họp
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

            txtnumberNonresidentAttend.Text = string.Empty;

            txtTotal.Text = string.Empty;
        }
        #endregion

        #region Khi chọn 1 dòng tên cuộc họp: hiển thị thông tin cuộc họp
        /// <summary>
        /// click cbx meeting
        /// khi chọn 1 dòng tên cuộc họp 
        /// kiểm tra xem có idmeeting
        /// nếu có: hiển thị thông tin
        /// nếu không: clear dữ liệu của thông tin cuộc họp trước về rỗng
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
        /// load info number person attend meeting
        /// load thông tin cuộc họp dựa vào meetingid
        /// </summary>
        /// <param name="meetingId"></param>
        private void LoadlInfoEventMeeting(long meetingId)
        {
            //  List<Partaker> jsonListPartaker = new List<Partaker>();
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

                        txtnumberPeopleInvited.Text = personAttendObjList[i].sumPeopleAttendInvited.ToString();//được mời
                        txtnumberPeopleAttendInvited.Text = personAttendObjList[i].numberPeopleAttendInvited.ToString();//được mời mà tham dự
                        txtnumberPeopleAdded.Text = personAttendObjList[i].numberPeopleAdded.ToString();//thêm vào
                        txtnumberJournalist.Text = personAttendObjList[i].numberJournalist.ToString();//nhà báo
                        txtnumberNonresidentAttend.Text = personAttendObjList[i].numberNonresident.ToString();//khách vãng lai

                        int total = personAttendObjList[i].numberPeopleAttendInvited + personAttendObjList[i].numberPeopleAdded + personAttendObjList[i].numberJournalist + personAttendObjList[i].numberNonresident;


                        txtTotal.Text = total.ToString();

                    }
                    catch (Exception e)
                    {
                        ClearControlInfoMeeting();
                    }
                }
            }
        }
        #endregion

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

        #region Lấy danh sách người tham dự theo điều kiện
        /// <summary>
        /// Load detail info person attend meeting based on (start, end, dateFrom, dateTo, orgId, meetingId);
        /// load dữ liệu theo phân trang
        /// load danh sách người tham dự dựa vào các thông số
        /// vị trí bắt đầu; số record cần lấy, giờ bắt đầu, giờ kết thúc, orgId, meetingID
        /// orgid ? -1 : id 
        /// -1 là lấy tất cả
        /// meetingId ? -1 : id
        /// -1 là lấy tất cả các cuộc họp theo idorg
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public PersonAttendDetailObj LoadPersonAttendDetailAtPage(int start, int end)
        {
            String dateFrom = dateFroms.ToString("yyyy-MM-dd 00:00:00");
            String dateTo = dateTos.ToString("yyyy-MM-dd 00:00:00");

            PersonAttendDetailObj personAttendDetailObjnew = new PersonAttendDetailObj();
            try
            {
                personAttendDetailObjnew = AttendMeetingStatisticFactory.Instance.GetChannel().getListPersonAttendDetailByDateAndOrgIdAndMeetingId(StorageService.CurrentSessionId, start, end, dateFrom, dateTo, orgId, meetingId);
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

        #region Gửi yêu cầu lấy thông tin chi tiết người tham dự
        /// <summary>
        ///  OnLoadPersonAttendDetailWorkerDoWork
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
            List<PersonAttendDetail> result = new List<PersonAttendDetail>();

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
                    sum = totalRecords = Convert.ToInt32(personAttendDetailObj.sum);


                    if (personAttendDetailObj.personAttendDetails != null)
                        result = personAttendDetailObj.personAttendDetails;

                    //thông tin khách vãng lai tham dự họp
                    if (personAttendDetailObj.nonresidentDetails != null)
                    {

                        result.AddRange(FrmInfoAttendMeetingStatistics.AddListNonresident(personAttendDetailObj.nonresidentDetails));
                    }
                    //end thông tin khách vãng lai tham dự họp


                    pagerPanel1.ShowNumberOfRecords(totalRecords, result != null ? result.Count : 0, take, currentPageIndex);
                    pagerPanel1.UpdatePagingLinks(totalRecords, take, currentPageIndex);
                }
                e.Result = result;
            }
        }

        /// <summary>
        /// không có dữ liệu thì ko cho excel được xuất, không hiển thị số trang
        /// </summary>
        private void UploadStatusBar()
        {
            btnExportToExcel.Enabled = false;
            pagerPanel1.ShowMessage(MessageValidate.GetMessage(rm, "lblMessageNotData"));
            pagerPanel1.UpdatePagingLinks(0, 1, 0);
        }

        /// <summary>
        ///  //cho phân trang thi vẫn còn hiển thị thanh link, và cho xuất exccel
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
                List<PersonAttendDetail> result = (List<PersonAttendDetail>)e.Result;

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

        #region Hiển thị thông tin chi tiết người tham dự
        /// <summary>
        /// show info person attendmeeting
        /// </summary>
        /// <param name="result"></param>
        public void LoadPersonAttendDetailListdata(List<PersonAttendDetail> result)
        {
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            int index = 0;
            dtbPersonAttendDetailList.Clear();
            for (int i = 0; i < result.Count; i++)
            {
                DataRow row = dtbPersonAttendDetailList.NewRow();
                row.BeginEdit();
                index = i + 1;
                row[colOrderNum.DataPropertyName] = index;

                //thong tin cuoc hop chưa thêm vào
                DateTime startDatemeeting = start.AddMilliseconds(Convert.ToUInt64(result[i].inputTime)).ToLocalTime();
                DateTime endDatemeeting = start.AddMilliseconds(Convert.ToUInt64(result[i].outputTime)).ToLocalTime();
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
                //row[colPositionPartaker.DataPropertyName] = "CV";
                row[colPositionPartaker.DataPropertyName] = result[i].partakerPosition;

                row[colOrgPartaker.DataPropertyName] = result[i].organizationAttendName;
                row[colNameAttendMeeting.DataPropertyName] = result[i].partakerName;

                row[colJournalist.DataPropertyName] = result[i].journalist;

                row[colIsNonResident.DataPropertyName] = result[i].isNonresident;
                row[colIdentityCard.DataPropertyName] = result[i].identityCard;
                row[colPhone.DataPropertyName] = result[i].phonenumber;

                row[colPeopleAdded.DataPropertyName] = result[i].add;

                row[colNote.DataPropertyName] = result[i].note;
                // row[colCheck.DataPropertyName] = true;
                row[colCheck.DataPropertyName] = result[i].status;

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
        #endregion

        #region CAB events
        [CommandHandler(MeetingCommandName.ShowMeetingItemStatisticDetail)]
        public void ShowMeetingStatisticsDetailMainHandler(object s, EventArgs e)
        {
            UsrAttendMeetingStatisticsDetail uc = workItem.Items.Get<UsrAttendMeetingStatisticsDetail>(MeetingCommandName.MenuMeetingItemStatisticDetail);
            if (uc == null)
            {
                uc = workItem.Items.AddNew<UsrAttendMeetingStatisticsDetail>(MeetingCommandName.MenuMeetingItemStatisticDetail);
            }
            else if (uc.IsDisposed)
            {
                workItem.Items.Remove(uc);
                uc = workItem.Items.AddNew<UsrAttendMeetingStatisticsDetail>(MeetingCommandName.MenuMeetingItemStatisticDetail);
            }

            workItem.Workspaces[WorkspaceName.MainWorkspace].Show(uc);
            uc.Parent.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(uc.rm, MenuNames.MenuMeetingItemStatisticDetail);
        }
        #endregion

        #region  Event's 
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

            PersonAttendDetailObj personAttendDetailObjnew = LoadPersonAttendDetailAtPage(skip, take);
            if (personAttendDetailObjnew != null)
            {

                List<PersonAttendDetail> result = new List<PersonAttendDetail>();
                if (personAttendDetailObjnew.personAttendDetails != null)
                    result = personAttendDetailObjnew.personAttendDetails;

                //thông tin khách vãng lai tham dự họp
                if (personAttendDetailObjnew.nonresidentDetails != null)
                {

                    result.AddRange(FrmInfoAttendMeetingStatistics.AddListNonresident(personAttendDetailObjnew.nonresidentDetails));
                }
                //end thông tin khách vãng lai tham dự họp

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
        /// search name
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

        #region Excel export : chuẩn bị dữ liệu
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
            PersonAttendDetailObj personAttendDetailObjnew = new PersonAttendDetailObj();
            try
            {
                int start = 0;
                int end = take;
                personAttendDetailObjnew = AttendMeetingStatisticFactory.Instance.GetChannel().getListPersonAttendDetailByDateAndOrgIdAndMeetingId(StorageService.CurrentSessionId, start, end, dateFrom, dateTo, orgId, meetingId);
            }
            catch (Exception ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
            }

            CommonDataGridView dataExport = new CommonDataGridView();
            if (personAttendDetailObjnew != null)
            {

                //thông tin khách vãng lai tham dự họp
                personAttendDetaillist = new List<PersonAttendDetail>();

                if (personAttendDetailObjnew.personAttendDetails != null)
                    personAttendDetaillist = personAttendDetailObjnew.personAttendDetails;

                //personAttendDetaillistNonresident = new List<PersonAttendDetail>();

                if (personAttendDetailObjnew.nonresidentDetails != null)
                {

                    personAttendDetaillist.AddRange(FrmInfoAttendMeetingStatistics.AddListNonresident(personAttendDetailObjnew.nonresidentDetails));
                }
                //end thông tin khách vãng lai tham dự họp

                // add data lan dau tien
                PrepareDataToExport(personAttendDetaillist);

                //phân trang
                int totalRecords = Convert.ToInt32(personAttendDetailObjnew.sum);

                //lay them du lieu neu khong du vi tong so record lon hon so take (take = 20) trong 1 trang
                if (totalRecords > take)
                {
                    int numberPage = (totalRecords / take) + ((totalRecords % take > 0) ? 1 : 0);
                    for (int i = 1; i < numberPage; i++)
                    {
                        int start = i * take;
                        int end = take;
                        personAttendDetailObjnew = AttendMeetingStatisticFactory.Instance.GetChannel().getListPersonAttendDetailByDateAndOrgIdAndMeetingId(StorageService.CurrentSessionId, start, end, dateFrom, dateTo, orgId, meetingId);
                        if (personAttendDetailObjnew != null)
                        {
                            //thông tin khách vãng lai tham dự họp
                            personAttendDetaillist = new List<PersonAttendDetail>();

                            if (personAttendDetailObjnew.personAttendDetails != null)
                                personAttendDetaillist = personAttendDetailObjnew.personAttendDetails;


                            if (personAttendDetailObjnew.nonresidentDetails != null)
                            {

                                personAttendDetaillist.AddRange(FrmInfoAttendMeetingStatistics.AddListNonresident(personAttendDetailObjnew.nonresidentDetails));
                            }
                            //end thông tin khách vãng lai tham dự họp

                            // add data lan dau tien
                            PrepareDataToExport(personAttendDetaillist);
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
        private void PrepareDataToExport(List<PersonAttendDetail> result)
        {
            int index = table4Export.Rows.Count;

            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            for (int i = 0; i < result.Count; i++)
            {
                DataRow row = table4Export.NewRow();
                row.BeginEdit();
                index += 1;
                row[colOrderNum.DataPropertyName] = index;

                //thong tin cuoc hop chưa thêm vào
                DateTime startDatemeeting = start.AddMilliseconds(Convert.ToUInt64(result[i].inputTime)).ToLocalTime();
                DateTime endDatemeeting = start.AddMilliseconds(Convert.ToUInt64(result[i].outputTime)).ToLocalTime();
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
                //row[colPositionPartaker.DataPropertyName] = "CV";
                row[colPositionPartaker.DataPropertyName] = result[i].partakerPosition;

                row[colOrgPartaker.DataPropertyName] = result[i].organizationAttendName;
                row[colNameAttendMeeting.DataPropertyName] = result[i].partakerName;

                row[colJournalist.DataPropertyName] = result[i].journalist;

                row[colIsNonResident.DataPropertyName] = result[i].isNonresident;
                row[colIdentityCard.DataPropertyName] = result[i].identityCard;
                row[colPhone.DataPropertyName] = result[i].phonenumber;

                row[colPeopleAdded.DataPropertyName] = result[i].add;

                row[colNote.DataPropertyName] = result[i].note;

                //  row[colCheck.DataPropertyName] = true;
                row[colCheck.DataPropertyName] = result[i].status;

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

        #region Xác định vị trí bắt đầu của bảng dữ liệu khi xuất file excel
        /// <summary>
        /// CheckRecordStart for export excel
        /// có 3 trường họp: 
        /// in tất cả thông tin : orgid =-1
        /// có 1 đơn vị cụ thể, nhưng không chọn cuộc họp cụ thể
        ///có 1 đơn vị cụ thể, có chọn 1 cuộc họp cụ thể
        /// </summary>
        /// <param name="isall"></param>
        /// <param name="ismeeting"></param>
        /// <returns></returns>
        public int CheckRecordStart(bool isall, bool ismeeting)
        {
            //export general information
            int indexrecord = 7;//3
            if (isall)
            {
                indexrecord = 8;//4
                //có tên cuộc họp
                if (ismeeting)
                {
                    indexrecord = 14;//10
                }

            }
            return indexrecord;
        }
        #endregion

        /// <summary>
        /// click export
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
            //String name = MessageValidate.GetMessage(rm, "lblRightAreaTitleListAttendaceDetail") + "_" + organizationMeetingName.ToString() + "_" + nameMeetingStr.ToString() + "_" + dateFroms.ToString("dd-MM-yyyy") + "_" + dateTos.ToString("dd-MM-yyyy");
            String name = MessageValidate.GetMessage(rm, "lblRightAreaTitleListAttendaceDetail") + "_" + dateFroms.ToString("dd-MM-yyyy") + "_" + dateTos.ToString("dd-MM-yyyy");

            string filePath = ControlExtMethods.ShowSaveFileDialog(MessageValidate.GetMessage(rm, "smsChooseFileExport"), name, CategorizeExcel.Categorize);
            if (filePath != null)
            {
                try
                {

                    // show du lieu truoc do trong table
                    table4Export.Rows.Clear();
                    // tao du lieu moi
                    GetDataFOrExport();

                    //cách 2
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
                    GemboxUtils.Instance.SetPortrait(true);

                    GemboxUtils.Instance.ExportDataGridToFileCustom(dataGridview4Export, configExportFile, recordStart);//tua de, xuat file
                    GemboxUtils.Instance.AutoFixA4();
                    GemboxUtils.Instance.ExportDataGridToFile(dataGridview4Export.Rows.Count);//tua de, xuat file
                    GemboxUtils.Instance.AutoFitAdvancedColIndex(5);

                    int widthA4 = configExportFile.GetSizePageA4Width();
                    WidthA4Percent withA4Percent = new WidthA4Percent(widthA4);

                    //int widthCol = withA4Percent.GetWidth9();
                    //GemboxUtils.Instance.SetWidthColIndex(3, widthCol);

                    int widthColOrg = withA4Percent.SetWidth(WidthA4Percent.size20);
                    GemboxUtils.Instance.SetWidthColIndex(2, widthColOrg);
                    GemboxUtils.Instance.SetWidthColIndex(3, widthColOrg);

                    int widthColAttend = withA4Percent.SetWidth(WidthA4Percent.size8);
                    GemboxUtils.Instance.SetWidthColIndex(4, widthColAttend);


                    GemboxUtils.Instance.AutoFixWidthColIndexEnd(1, configExportFile.GetSizePageA4Width());

                    #region xác định vị trí bắt đầu bảng dữ liệu

                    //custom
                    GemboxUtils.Instance.AddTemplateHeader();

                    //export general information
                    String lblRightAreaTitleListAttendaceDetail = MessageValidate.GetMessage(rm, "lblRightAreaTitleListAttendaceDetail");
                    GemboxUtils.Instance.AddHeader(lblRightAreaTitleListAttendaceDetail == null ? string.Empty : lblRightAreaTitleListAttendaceDetail);

                    //int index = ConstantsEnum.positionIndexCol;
                    int index = ConstantsEnum.Instance.positionIndexForPrint;

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
                            String lblnumberPeopleInvited = MessageValidate.GetMessage(rm, "lblnumberPeopleInvitedFull");

                          //  value = (lblnumberPeopleInvited == null ? string.Empty : lblnumberPeopleInvited) + " "
                              //  + (txtnumberPeopleInvited.Text == null ? string.Empty : txtnumberPeopleInvited.Text.ToString());

                            int sumRegisterWeb = (txtnumberPeopleInvited.Text == null ? 0 : Convert.ToInt32(txtnumberPeopleInvited.Text.ToString()));
                            int sumRegisterClient = (txtnumberPeopleAdded.Text == null ? 0 : Convert.ToInt32(txtnumberPeopleAdded.Text.ToString()));

                            value = (lblnumberPeopleInvited == null ? string.Empty : lblnumberPeopleInvited) + " " + (sumRegisterWeb + sumRegisterClient);

                            GemboxUtils.Instance.AddCellCustom(index, 0, value == null ? string.Empty : value);
                            value = ""; index++;

                            //String lblnumberPeopleAdded = MessageValidate.GetMessage(rm, "lblnumberPeopleAdded");
                            //value = (lblnumberPeopleAdded == null ? string.Empty : lblnumberPeopleAdded) + " "
                            //   + (txtnumberPeopleAdded.Text == null ? string.Empty : txtnumberPeopleAdded.Text.ToString());
                            //GemboxUtils.Instance.AddCellCustom(index, 0, value == null ? string.Empty : value);
                            //value = ""; index++;

                            //String lblnumberPeopleAttendInvited = MessageValidate.GetMessage(rm, "lblnumberPeopleAttendInvited");
                            //value = (lblnumberPeopleAttendInvited == null ? string.Empty : lblnumberPeopleAttendInvited) + " "
                            //    + (txtnumberPeopleAttendInvited.Text == null ? string.Empty : txtnumberPeopleAttendInvited.Text.ToString());
                            //GemboxUtils.Instance.AddCellCustom(index, 0, value == null ? string.Empty : value);
                            //value = ""; index++;

                            String lblnumberJournalist = MessageValidate.GetMessage(rm, "lblnumberJournalistFull");
                            value = (lblnumberJournalist == null ? string.Empty : lblnumberJournalist) + " "
                                + (txtnumberJournalist.Text == null ? string.Empty : txtnumberJournalist.Text.ToString());
                            GemboxUtils.Instance.AddCellCustom(index, 0, value == null ? string.Empty : value);
                            value = ""; index++;

                            //String lblnumberNonresidentAttend = MessageValidate.GetMessage(rm, "lblnumberNonresidentAttend");
                            //value = (lblnumberNonresidentAttend == null ? string.Empty : lblnumberNonresidentAttend) + " "
                            //     + (txtnumberNonresidentAttend.Text == null ? string.Empty : txtnumberNonresidentAttend.Text.ToString());
                            //GemboxUtils.Instance.AddCellCustom(index, 0, value == null ? string.Empty : value);
                            //value = ""; index++;

                            String lblnumberTotal = MessageValidate.GetMessage(rm, "lblnumberTotalFull");
                            value = (lblnumberTotal == null ? string.Empty : lblnumberTotal) + " "
                                 + (txtTotal.Text == null ? string.Empty : txtTotal.Text.ToString());
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
                    GemboxUtils.Instance.SetPortrait(false);

                    MessageBoxManager.ShowErrorMessageBox(this, ex.Message);
                    return;
                }
                GemboxUtils.Instance.SetPortrait(false);

                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "smsLinkFile") + filePath);
            }
        }
        #endregion
    }
}
