using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonControls.Custom;
using Microsoft.Practices.CompositeUI.Commands;
using CommonHelper.Constants;
using CommonHelper.Utils;
using CommonControls;
using sWorldModel.Exceptions;
using System.Resources;
using Microsoft.Practices.CompositeUI;
using sWorldModel;
using System.ServiceModel;
using CommonHelper.Config;
using sNonResidentComponent.Model;
using sNonResidentComponent.Constants;
using JavaCommunication;
using sNonResidentComponent.Factory;
using sNonResidentComponent.Model.CustomObj;
using sNonResidenComponent.WorkItems;
using System.Globalization;
using ClientModel.Model;
using ClientModel.Utils;
using System.IO;
using sMeetingComponent.Constants;
using sExcelExportComponent.ClientModel.Enums;
using sNonResidentComponent.Model.Old;
using sNonResidentComponent.Model.CustomObj.Statistic;
using sNonResidentComponent.WorkItems.ManageMeeting;

namespace sNonResidentComponent.WorkItems.StatisticForNonresident {
    public partial class UsrNonResidentStatisticsDetail : CommonUserControl {
        #region Properties
        public string sysFormatDate;

        int take = Enums.TAKE;


        int sum = 0;

        private FrmShiftImage frm = new FrmShiftImage("", "");

        private DateTime dateFroms;
        private DateTime dateTos;
        String updating = "Updating";
        String cancelled = "Cancelled";

        private DataTable table4Export = null;

        List<NonResidentObj> nonResidentList;
        NonResidentStatisticDetailObj nonResidentStatisticDetailObj;
        private BackgroundWorker loadNonResidentStatistic;
        private BackgroundWorker bgwLoadNonResOrg, bgwLoadNonResSubOrg, bgwLoadNonResMember;

        private List<NonResidentOrganization> listNonResOrgCBX;
        List<NonResidenMemSubComboBox> listNonResMemSubOrgCBX;
        long nonOrgId;
        bool isPeople;
        long nonMemOrSubOrgId;

        private DataTable dtbNonResidentList;
        private int currentPageIndex = 1;
        private const int hiddenFilterBoxHeight = 1;
        private int startupFilterBoxHeight;

        private ResourceManager rm;
        private NonResidentComponentWorkItem workItem;
        public DialogPostAction PostAction { get; private set; }
        [ServiceDependency]
        public NonResidentComponentWorkItem WorkItem {
            set { workItem = value; }
        }
        private ILocalStorageService storageService;
        [ServiceDependency]
        public ILocalStorageService StorageService {
            get { return storageService; }
            set { storageService = value; }
        }
        #endregion

        #region Contructors
        public UsrNonResidentStatisticsDetail() {
            InitializeComponent();
            InitDataTableNonResidentList();
            sysFormatDate = UsrManageMeeting.formatDateTime();

            RegisterEvent();
        }
        #endregion
        /// <summary>
        /// InitDataTableNonResidentList
        /// </summary>
        private void InitDataTableNonResidentList() {
            dtbNonResidentList = new DataTable();
            dtbNonResidentList.Columns.Add(colOrderNum.DataPropertyName);
            dtbNonResidentList.Columns.Add(colToOrg.DataPropertyName);
            dtbNonResidentList.Columns.Add(colMeetingId.DataPropertyName);
            dtbNonResidentList.Columns.Add(colMeetingName.DataPropertyName);
            dtbNonResidentList.Columns.Add(colDate.DataPropertyName);
            dtbNonResidentList.Columns.Add(colInputTime.DataPropertyName);
            dtbNonResidentList.Columns.Add(colOutTime.DataPropertyName);
            dtbNonResidentList.Columns.Add(colFullName.DataPropertyName);

            dtbNonResidentList.Columns.Add(colPositionPartaker.DataPropertyName);
            dtbNonResidentList.Columns.Add(colOrgPartaker.DataPropertyName);

            dtbNonResidentList.Columns.Add(colBirthDate.DataPropertyName);
            dtbNonResidentList.Columns.Add(colIdentityCard.DataPropertyName);
            dtbNonResidentList.Columns.Add(colPhoneNo.DataPropertyName);
            dtbNonResidentList.Columns.Add(colAddress.DataPropertyName);
            dtbNonResidentList.Columns.Add(colPersoStatus.DataPropertyName);
            dtbNonResidentList.Columns.Add(colContactContent.DataPropertyName);
            dtbNonResidentList.Columns.Add(colImageFace.DataPropertyName);
            dtbNonResidentList.Columns.Add(colImageIdentityCard.DataPropertyName);
            dgvNonResident.DataSource = dtbNonResidentList;

            //20170304 #Bug Fix- My Nguyen Start
            // for export
            table4Export = new DataTable();

            table4Export.Columns.Add(colOrderNum.DataPropertyName);
            table4Export.Columns.Add(colToOrg.DataPropertyName);
            table4Export.Columns.Add(colMeetingId.DataPropertyName);
            table4Export.Columns.Add(colMeetingName.DataPropertyName);
            table4Export.Columns.Add(colDate.DataPropertyName);
            table4Export.Columns.Add(colInputTime.DataPropertyName);
            table4Export.Columns.Add(colOutTime.DataPropertyName);
            table4Export.Columns.Add(colFullName.DataPropertyName);

            table4Export.Columns.Add(colPositionPartaker.DataPropertyName);
            table4Export.Columns.Add(colOrgPartaker.DataPropertyName);

            table4Export.Columns.Add(colBirthDate.DataPropertyName);
            table4Export.Columns.Add(colIdentityCard.DataPropertyName);
            table4Export.Columns.Add(colPhoneNo.DataPropertyName);
            table4Export.Columns.Add(colAddress.DataPropertyName);
            table4Export.Columns.Add(colPersoStatus.DataPropertyName);
            table4Export.Columns.Add(colContactContent.DataPropertyName);
            table4Export.Columns.Add(colImageFace.DataPropertyName);
            table4Export.Columns.Add(colImageIdentityCard.DataPropertyName);

            dataGridview4Export.DataSource = table4Export;
            //20170304 #Bug Fix- My Nguyen End
        }

        /// <summary>
        /// RegisterEvent
        /// đăng ký sự kiện
        /// </summary>
        private void RegisterEvent() {
            CreateBackgroundWorkerEvent();
            dgvNonResident.MouseDown += dgvNonResident_MouseDown;
            btnReload.Click += OnButtonReloadClicked;
            btnExportToExcel.Click += btnExportToExcel_Click;
            btnShowHide.Click += btnShowHide_Clicked;
            txtMeetingNameSearchs.TextChanged += txtMeetingNameSearchs_TextChanged;
            txtNameSearch.TextChanged += txtNameSearch_TextChanged;
            pagerPanel.LinkLabelClicked += pagerPanel_LinkLabelClicked;
            dgvNonResident.CellClick += dgvNonResident_CellClick;
            cbxOrg.SelectedIndexChanged += cbxOrg_SelectedIndexChanged;
            Load += OnFormLoad;
        }

        /// <summary>
        /// OnFormLoad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFormLoad(object sender, EventArgs e) {
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            startupFilterBoxHeight = pnlFilterBox.Height;
            pagerPanel.StorageService = storageService;
            pagerPanel.LoadLanguage();
            SetLanguages();
            LoadNonResOrg();

            dateFroms = this.dtpDateIn.Value.Date;
            dateTos = this.dtpDateIn2.Value.Date;

        }

        #region language
        /// <summary>
        /// SetLanguages
        /// </summary>
        private void SetLanguages() {
            this.colOrderNum.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOrderNum.Name);
            this.colToOrg.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colToOrg.Name);
            this.colMeetingId.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colMeetingId.Name);
            this.colMeetingName.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colMeetingName.Name);
            this.colDate.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colDate.Name);
            this.colInputTime.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colInputTime.Name);
            this.colOutTime.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOutTime.Name);
            this.colFullName.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colFullName.Name);

            this.colPositionPartaker.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPositionPartaker.Name);
            this.colOrgPartaker.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOrgPartaker.Name);

            this.colBirthDate.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colBirthDate.Name);
            this.colIdentityCard.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colIdentityCard.Name);
            this.colPhoneNo.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPhoneNo.Name);
            this.colPersoStatus.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPersoStatus.Name);
            this.colAddress.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colAddress.Name);
            this.colContactContent.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colContactContent.Name);
            this.colViewImage.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colViewImage.Name);

            //
            this.dataGridViewTextBoxColumn1.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOrderNum.Name);
            this.dataGridViewTextBoxColumn2.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colFullName.Name);

            this.colPositionPartakerEx.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPositionPartaker.Name);
            this.colOrgPartakerEx.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOrgPartaker.Name);

            this.dataGridViewTextBoxColumn3.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colToOrg.Name);
            this.dataGridViewTextBoxColumn5.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colMeetingName.Name);
            this.dataGridViewTextBoxColumn6.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colDate.Name);
            this.dataGridViewTextBoxColumn7.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colInputTime.Name);
            this.dataGridViewTextBoxColumn8.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOutTime.Name);
            this.dataGridViewTextBoxColumn9.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colContactContent.Name);
            this.dataGridViewTextBoxColumn12.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colBirthDate.Name);
            this.dataGridViewTextBoxColumn13.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colIdentityCard.Name);
            this.dataGridViewTextBoxColumn14.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colPhoneNo.Name);
            this.dataGridViewTextBoxColumn15.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colAddress.Name);
            //

            this.btnShowHide.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnShowHide.Name);
            this.btnExportToExcel.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnExportToExcel.Name);
            this.btnReload.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnReload.Name);

            string updatestr = MessageValidate.GetMessage(rm, "updating");
            if (updatestr != null) {
                updating = updatestr;

                if (updating.Equals("") || updating.Equals("LanguagesError")) {
                    updating = "updating";
                }
            }
            string cancelledstr = MessageValidate.GetMessage(rm, "cancelled");
            if (cancelledstr != null) {
                cancelled = cancelledstr;

                if (cancelled.Equals("") || cancelled.Equals("LanguagesError")) {
                    cancelled = "Cancelled";
                }
            }

            // minh.nguyen
            lblFilterByMemSubOrgName.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblFilterByMemSubOrgName.Name);
        }
        #endregion

        #region LoadNonResidentStatisticList : kiểm tra trước tiên gửi yêu cầu lấy thông tin chi tiết khách vãng lai
        /// <summary>
        /// LoadNonResidentStatisticList
        /// </summary>
        private void LoadNonResidentStatisticList() {
            dateFroms = this.dtpDateIn.Value.Date;
            dateTos = this.dtpDateIn2.Value.Date;
            if (ValidateData(dateFroms, dateTos)) {
                if (!loadNonResidentStatistic.IsBusy) {
                    dtbNonResidentList.Rows.Clear();
                    pagerPanel.ShowMessage(MessageValidate.GetMessage(rm, "smsLoading"));
                    loadNonResidentStatistic.RunWorkerAsync();
                }
            } else {
                dtbNonResidentList.Rows.Clear();
            }
        }


        /// <summary>
        /// ValidateData
        ///  kiểm tra dữ liệu nhập vào form
        /// </summary>
        private bool ValidateData(DateTime dtIn, DateTime dtIn2) {
            int result = DateTime.Compare(dtIn, dtIn2);
            if (result < 0)
                return true;
            else if (result == 0)
                return true;
            else {
                UploadStatusBar();
                return false;
            }
        }

        #endregion

        #region bgWorker

        #region Gửi yêu cầu lấy danh sách đơn vị tổ chức
        /// <summary>
        /// CreateBackgroundWorkerEvent
        /// </summary>
        private void CreateBackgroundWorkerEvent() {
            //9: STATICTIS : THÓNG KÊ chi tiết thông tin khách vãng lai đến
            loadNonResidentStatistic = new BackgroundWorker();
            loadNonResidentStatistic.WorkerSupportsCancellation = true;
            loadNonResidentStatistic.DoWork += OnLoadNonResidentStatisticWorkerDoWork;
            loadNonResidentStatistic.RunWorkerCompleted += OnLoadNonResidentStatisticWorkerCompleted;

            // minh.nguyen
            bgwLoadNonResOrg = new BackgroundWorker();
            bgwLoadNonResOrg.WorkerSupportsCancellation = true;
            bgwLoadNonResOrg.DoWork += bgwLoadNonResOrg_DoWork;
            bgwLoadNonResOrg.RunWorkerCompleted += bgwLoadNonResOrg_RunWorkerCompleted;

            bgwLoadNonResSubOrg = new BackgroundWorker();
            bgwLoadNonResSubOrg.WorkerSupportsCancellation = true;
            bgwLoadNonResSubOrg.DoWork += bgwLoadNonResSubOrg_DoWork;
            bgwLoadNonResSubOrg.RunWorkerCompleted += bgwLoadNonResSubOrg_RunWorkerCompleted;

            bgwLoadNonResMember = new BackgroundWorker();
            bgwLoadNonResMember.WorkerSupportsCancellation = true;
            bgwLoadNonResMember.DoWork += bgwLoadNonResMember_DoWork;
            bgwLoadNonResMember.RunWorkerCompleted += bgwLoadNonResMember_RunWorkerCompleted;
        }

        #region  LoadNonResidentListAtPage : lấy danh sách chi tiết của khách vãng lai
        /// <summary>
        /// LoadNonResidentListAtPage
        /// load list detail info nonresident (start, end, theDateIn, theDateIn2, organizationMeetingId);
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public NonResidentStatisticDetailObj LoadNonResidentListAtPage(int start, int end) {
            string theDateIn = dtpDateIn.Value.ToString("yyyy-MM-dd");
            string theDateIn2 = dtpDateIn2.Value.ToString("yyyy-MM-dd");
            NonResidentStatisticDetailObj nonResidentStatisticDetailObjNew = new NonResidentStatisticDetailObj();
            try {
                if (isPeople) {
                    nonResidentStatisticDetailObjNew = NonResidentStatisticsFactory.Instance.GetChannel().getListNonresidentByDateAndOrgId(StorageService.CurrentSessionId, start, end, theDateIn, theDateIn2, nonOrgId, nonMemOrSubOrgId, 1);
                } else {
                    nonResidentStatisticDetailObjNew = NonResidentStatisticsFactory.Instance.GetChannel().getListNonresidentByDateAndOrgId(StorageService.CurrentSessionId, start, end, theDateIn, theDateIn2, nonOrgId, nonMemOrSubOrgId, 0);
                }
            } catch (TimeoutException) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
            } catch (FaultException<WcfServiceFault> ex) {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
            } catch (FaultException ex) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "FaultExceptionMessage")
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
            } catch (CommunicationException) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "CommunicationExceptionMessage"));
            }
            return nonResidentStatisticDetailObjNew;
        }
        #endregion

        #region Gửi yêu cầu lấy thông tin chi tiết khách vãng lai
        /// <summary>
        /// get nonresident list based on from date to date
        /// OnLoadNonResidentStatisticWorkerDoWork
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadNonResidentStatisticWorkerDoWork(object sender, DoWorkEventArgs e) {

            int totalRecords = 0;
            int skip = 0;
            currentPageIndex = 1;
            List<NonResidentObj> result = null;
            try {
                e.Result = nonResidentStatisticDetailObj = LoadNonResidentListAtPage(skip, take);
            } catch (Exception ex) { } finally {
                if (nonResidentStatisticDetailObj != null) {
                    sum = totalRecords = Convert.ToInt32(nonResidentStatisticDetailObj.sum);
                    nonResidentList = result = nonResidentStatisticDetailObj.nonResidentObjs;
                    pagerPanel.ShowNumberOfRecords(totalRecords, result != null ? result.Count : 0, take, currentPageIndex);
                    pagerPanel.UpdatePagingLinks(totalRecords, take, currentPageIndex);
                }
                e.Result = result;
            }
        }

        /// <summary>
        /// không cho phân trang thi vẫn còn hiển thị thanh link, và không cho xuất exccel
        /// Change statusbar : message not data
        /// </summary>
        private void UploadStatusBar() {
            btnExportToExcel.Enabled = false;
            pagerPanel.ShowMessage(MessageValidate.GetMessage(rm, "lblMessageNotData"));
            pagerPanel.UpdatePagingLinks(0, 1, 0);
        }

        /// <summary>
        ///  change status bar: have pagepanel , but not data
        ///  cho phân trang thi vẫn còn hiển thị thanh link, và cho xuất exccel
        /// </summary>
        private void UploadStatusBarHavePagePanel() {
            pagerPanel.ShowMessage(MessageValidate.GetMessage(rm, "lblMessageNotData"));
        }
        /// <summary>
        /// OnLoadNonResidentStatisticWorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadNonResidentStatisticWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Cancelled) {
                UploadStatusBar();
                return;
            }
            if (e.Result == null) {
                UploadStatusBar();
                return;
            } else {
                List<NonResidentObj> result = (List<NonResidentObj>) e.Result;
                if (result.Count != 0) {
                    LoadNonResidentStatisticListdata(result);
                } else {
                    UploadStatusBar();
                }
            }
        }
        #endregion
        #endregion

        // minh.nguyen
        #region Non Res Org
        private void bgwLoadNonResOrg_DoWork(object sender, DoWorkEventArgs e) {
            try {
                e.Result = NonResidentOrganizationFactory.Instance.GetChannel().GetListAllOrg(storageService.CurrentSessionId, SystemSettings.Instance.OrgCode);
            } catch (TimeoutException) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
            } catch (FaultException<WcfServiceFault> ex) {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
            } catch (FaultException ex) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "FaultExceptionMessage")
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
            } catch (CommunicationException) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "CommunicationExceptionMessage"));
            }
        }

        private void bgwLoadNonResOrg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Cancelled || e.Result == null) {
                return;
            }

            NonResidentOrganization nonResOrg = new NonResidentOrganization();
            string All = MessageValidate.GetMessage(rm, "All");
            nonResOrg.nonOrgName = All;
            nonResOrg.nonOrgId = -1;

            listNonResOrgCBX = new List<NonResidentOrganization>();
            listNonResOrgCBX.Add(nonResOrg);

            List<NonResidentOrganization> listNonResOrgTemp = new List<NonResidentOrganization>();
            listNonResOrgTemp = (List<NonResidentOrganization>) e.Result;
            // Load danh sách đơn vị phòng ban
            if (listNonResOrgTemp.Count > 0) {
                foreach (NonResidentOrganization nonResOrgTemp in listNonResOrgTemp) {
                    listNonResOrgCBX.Add(nonResOrgTemp);
                }
            }

            cbxOrg.DataSource = listNonResOrgCBX.ToList();
            cbxOrg.ValueMember = "nonOrgId";
            cbxOrg.DisplayMember = "nonOrgName";//hiển thị
            cbxOrg.SelectedIndex = 0;

            LoadNonResidentStatisticList();
        }
        #endregion

        #region Non Res SubOrg
        private void bgwLoadNonResSubOrg_DoWork(object sender, DoWorkEventArgs e) {
            try {
                e.Result = NonResidentSubOrganizationFactory.Instance.GetChannel().GetListAllSubOrg(storageService.CurrentSessionId, nonOrgId);
            } catch (TimeoutException) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
            } catch (FaultException<WcfServiceFault> ex) {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
            } catch (FaultException ex) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "FaultExceptionMessage")
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
            } catch (CommunicationException) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "CommunicationExceptionMessage"));
            }
        }

        private void bgwLoadNonResSubOrg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Cancelled || e.Result == null) {
                return;
            }

            NonResidentMemberSubOrg nonResMemSubOrg = new NonResidentMemberSubOrg();
            NonResidentSubOrganization nonResSubOrgTemp = new NonResidentSubOrganization();
            NonResidenMemSubComboBox nonResMemSubOrgCBXTemp = new NonResidenMemSubComboBox();

            string All = MessageValidate.GetMessage(rm, "All");
            nonResMemSubOrgCBXTemp.key = -1;
            nonResMemSubOrgCBXTemp.value = All;
            nonResMemSubOrgCBXTemp.nonResMemSubOrg = new NonResidentMemberSubOrg();

            listNonResMemSubOrgCBX = new List<NonResidenMemSubComboBox>();
            listNonResMemSubOrgCBX.Add(nonResMemSubOrgCBXTemp);

            List<NonResidentSubOrganization> nonResListAllSubOrg;
            nonResListAllSubOrg = (List<NonResidentSubOrganization>) e.Result;

            foreach (NonResidentSubOrganization nonResSubOrg in nonResListAllSubOrg) {
                NonResidentMemberSubOrg nonResMemSubOrgTemp = new NonResidentMemberSubOrg();
                nonResMemSubOrgTemp.nonResSubOrg = nonResSubOrg;
                nonResMemSubOrgTemp.isPeople = isPeople;

                NonResidenMemSubComboBox nonResMemSubOrgCBX = new NonResidenMemSubComboBox();
                nonResMemSubOrgCBX.key = nonResSubOrg.nonSubOrgId;
                nonResMemSubOrgCBX.value = nonResSubOrg.nonSubOrgName;
                nonResMemSubOrgCBX.nonResMemSubOrg = nonResMemSubOrgTemp;
                listNonResMemSubOrgCBX.Add(nonResMemSubOrgCBX);
            }


            cbxMemSubOrg.DataSource = listNonResMemSubOrgCBX.ToList();
            cbxMemSubOrg.ValueMember = "key";
            cbxMemSubOrg.DisplayMember = "value"; // hiển thị
            cbxMemSubOrg.SelectedIndex = 0;
        }
        #endregion

        #region Non Res Member
        private void bgwLoadNonResMember_DoWork(object sender, DoWorkEventArgs e) {
            try {
                e.Result = NonResidentMemberMapFactory.Instance.GetChannel().GetListAllMemMap(storageService.CurrentSessionId, nonOrgId);
            } catch (TimeoutException) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
            } catch (FaultException<WcfServiceFault> ex) {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
            } catch (FaultException ex) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "FaultExceptionMessage")
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
            } catch (CommunicationException) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "CommunicationExceptionMessage"));
            }
        }

        private void bgwLoadNonResMember_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Cancelled || e.Result == null) {
                return;
            }

            NonResidentMemberSubOrg nonResMemSubOrg = new NonResidentMemberSubOrg();
            NonResidentMemberMapCustom nonResMemMapCustomTemp = new NonResidentMemberMapCustom();
            NonResidenMemSubComboBox nonResMemSubOrgCBXTemp = new NonResidenMemSubComboBox();

            string All = MessageValidate.GetMessage(rm, "All");
            nonResMemSubOrgCBXTemp.key = -1;
            nonResMemSubOrgCBXTemp.value = All;
            nonResMemSubOrgCBXTemp.nonResMemSubOrg = new NonResidentMemberSubOrg();

            listNonResMemSubOrgCBX = new List<NonResidenMemSubComboBox>();
            listNonResMemSubOrgCBX.Add(nonResMemSubOrgCBXTemp);

            List<NonResidentMemberMapCustom> nonResListAllMemMapCustom;
            nonResListAllMemMapCustom = (List<NonResidentMemberMapCustom>) e.Result;

            foreach (NonResidentMemberMapCustom nonResMemMapCustom in nonResListAllMemMapCustom) {
                NonResidentMemberSubOrg nonResMemSubOrgTemp = new NonResidentMemberSubOrg();
                nonResMemSubOrgTemp.nonResMemMapCustom = nonResMemMapCustom;
                nonResMemSubOrgTemp.isPeople = isPeople;

                NonResidenMemSubComboBox nonResMemSubOrgCBX = new NonResidenMemSubComboBox();
                nonResMemSubOrgCBX.key = nonResMemMapCustom.nonResMemMap.nonMemMapId;
                nonResMemSubOrgCBX.value = nonResMemMapCustom.memberName;
                nonResMemSubOrgCBX.nonResMemSubOrg = nonResMemSubOrgTemp;
                listNonResMemSubOrgCBX.Add(nonResMemSubOrgCBX);
            }


            cbxMemSubOrg.DataSource = listNonResMemSubOrgCBX.ToList();
            cbxMemSubOrg.ValueMember = "key";
            cbxMemSubOrg.DisplayMember = "value"; // hiển thị
            cbxMemSubOrg.SelectedIndex = 0;
        }
        #endregion
        #endregion

        #region Hiển thị thông tin chi tiết khách vãng lai
        /// <summary>
        /// show nonresident list
        /// </summary>
        /// <param name="result"></param>
        public void LoadNonResidentStatisticListdata(List<NonResidentObj> result) {
            dtbNonResidentList.Clear();
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            int index = 0;
            for (int i = 0; i < result.Count; i++) {
                DataRow row = dtbNonResidentList.NewRow();
                row.BeginEdit();
                index = i + 1;
                row[colOrderNum.DataPropertyName] = index;

                row[colMeetingId.DataPropertyName] = result[i].nonResident.meetingId;
                row[colMeetingName.DataPropertyName] = result[i].nonResident.meetingName;
                row[colPhoneNo.DataPropertyName] = result[i].nonResident.phonenumber;
                // row[colAddress.DataPropertyName] = result[i].nonResident.temporaryAddress;
                row[colContactContent.DataPropertyName] = result[i].nonResident.note;

                //hinh
                if (result[i].dataImageFace != null) {
                    row[colImageFace.DataPropertyName] = result[i].dataImageFace;
                }
                if (result[i].dataImageIdentityCard != null) {
                    row[colImageIdentityCard.DataPropertyName] = result[i].dataImageIdentityCard;
                }
                row[colFullName.DataPropertyName] = result[i].nonResident.name;

                row[colPositionPartaker.DataPropertyName] = result[i].nonResident.nonResidentPosition;
                row[colOrgPartaker.DataPropertyName] = result[i].nonResident.nonResidentOrganization;

                row[colIdentityCard.DataPropertyName] = result[i].nonResident.identityCard;
                row[colToOrg.DataPropertyName] = result[i].nonResident.orgName;
                //if (result[i].nonResident.birthday != null && result[i].nonResident.birthday != "")
                //{
                //    DateTime birthday = start.AddMilliseconds(Convert.ToUInt64(result[i].nonResident.birthday)).ToLocalTime();
                //    string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                //    row[colBirthDate.DataPropertyName] = birthday.ToString(sysFormat);
                //}

                DateTime endDate = start.AddMilliseconds(Convert.ToUInt64(result[i].nonResident.outputTime)).ToLocalTime();
                DateTime datedefault = new DateTime(1971, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                DateTime datedefault2 = new DateTime(1972, 2, 2, 0, 0, 0, DateTimeKind.Utc);
                int compareDateEnd = DateTime.Compare(endDate, datedefault);
                int compareDateEnd2 = DateTime.Compare(endDate, datedefault2);
                if (compareDateEnd == 0) {
                    row[colOutTime.DataPropertyName] = updating;
                } else {
                    row[colOutTime.DataPropertyName] = endDate.ToString("HH:mm");
                }

                if (compareDateEnd2 == 0) {
                    row[colOutTime.DataPropertyName] = cancelled;
                }
                if (result[i].nonResident.serialNumber.Equals("00000000")) {
                    row[colPersoStatus.DataPropertyName] = cancelled;
                } else {
                    row[colPersoStatus.DataPropertyName] = updating;
                }

                if (result[i].nonResident.inputTime != null && result[i].nonResident.inputTime != "") {
                    DateTime inputtime = start.AddMilliseconds(Convert.ToUInt64(result[i].nonResident.inputTime)).ToLocalTime();
                    //  row[colPersoStatus.DataPropertyName] = "Đang hoạt động";
                    //  string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;

                    row[colDate.DataPropertyName] = inputtime.ToString(sysFormatDate);
                    row[colInputTime.DataPropertyName] = inputtime.ToString("HH:mm");
                }

                row.EndEdit();
                dtbNonResidentList.Rows.Add(row);
            }
            if (dgvNonResident.Rows.Count > 0) {
                btnExportToExcel.Enabled = true;
                //focur the first row in table
                dgvNonResident.Rows[0].Selected = true;
            } else {
                UploadStatusBarHavePagePanel();
            }

        }
        #endregion

        #region CAB events
        [CommandHandler(NonResidentCommandName.ShowNonResidentStatisticDetail)]
        public void ShowNonResidentStatisticDetailMainHandler(object s, EventArgs e) {
            UsrNonResidentStatisticsDetail uc = workItem.Items.Get<UsrNonResidentStatisticsDetail>(NonResidentCommandName.MenuNonResidentStatisticDetailItem);
            if (uc == null) {
                uc = workItem.Items.AddNew<UsrNonResidentStatisticsDetail>(NonResidentCommandName.MenuNonResidentStatisticDetailItem);
            } else if (uc.IsDisposed) {
                workItem.Items.Remove(uc);
                uc = workItem.Items.AddNew<UsrNonResidentStatisticsDetail>(NonResidentCommandName.MenuNonResidentStatisticDetailItem);
            }

            workItem.Workspaces[WorkspaceName.MainWorkspace].Show(uc);
            uc.Parent.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(uc.rm, MenuNames.MenuNonResidentStatisticDetailItem);
        }
        #endregion

        #region  Event's 
        /// <summary>
        /// click btn reload
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonReloadClicked(object sender, EventArgs e) {
            try {
                // Org
                NonResidentOrganization nonResOrg = (NonResidentOrganization) cbxOrg.SelectedItem;
                nonOrgId = nonResOrg.nonOrgId;
                if (nonResOrg.isPeople == 1) {
                    isPeople = true;
                } else {
                    isPeople = false;
                }

                // Member or SubOrg
                if (cbxMemSubOrg.Enabled) {
                    NonResidenMemSubComboBox nonResMemSubComboBox = (NonResidenMemSubComboBox) cbxMemSubOrg.SelectedItem;
                    if (nonResMemSubComboBox.key == -1) {
                        nonMemOrSubOrgId = -1;
                    } else {
                        if (isPeople) {
                            nonMemOrSubOrgId = nonResMemSubComboBox.nonResMemSubOrg.nonResMemMapCustom.nonResMemMap.nonMemMapId;
                        } else {
                            nonMemOrSubOrgId = nonResMemSubComboBox.nonResMemSubOrg.nonResSubOrg.nonSubOrgId;
                        }
                    }
                } else {
                    nonMemOrSubOrgId = -1;
                }
            } catch (Exception er) {
                nonOrgId = -1;
                nonMemOrSubOrgId = -1;
            }
            LoadNonResidentStatisticList();
        }

        public void AutoRefreshWhenChangeTab() {
            try {
                NonResidentOrganization nonResOrg = (NonResidentOrganization) cbxOrg.SelectedItem;
                nonOrgId = nonResOrg.nonOrgId;
            } catch (Exception er) {
                nonOrgId = -1;
            }
            LoadNonResidentStatisticList();
        }

        /// <summary>
        /// mousedown dgv
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvNonResident_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                DataGridView.HitTestInfo info = dgvNonResident.HitTest(e.X, e.Y);
                if (info.RowIndex != -1) {
                    if (info.RowIndex >= 0 && info.ColumnIndex >= 0) {
                        if (!dgvNonResident.SelectedRows.Contains(dgvNonResident.Rows[info.RowIndex])) {
                            foreach (DataGridViewRow row in dgvNonResident.SelectedRows) {
                                row.Selected = false;
                            }
                            dgvNonResident.Rows[info.RowIndex].Selected = true;
                        }
                    }
                    Rectangle r = dgvNonResident.GetCellDisplayRectangle(info.ColumnIndex, info.RowIndex, true);
                    cmsPersoRecord.Show((Control) sender, e.X, e.Y);
                }
            }
        }
        /// <summary>
        /// click dgv
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvNonResident_CellClick(object sender, DataGridViewCellEventArgs e) {
            workItem.SmartParts.Remove(frm);
            frm.Hide();
            int rowIndex = e.RowIndex;
            if (rowIndex != -1) {
                // Get selected rows
                var selectedRows = dgvNonResident.SelectedRows;
                
                int rowsCount = selectedRows.Count;
                int colViewImageClickIndex = dgvNonResident.Columns[colViewImage.Name].Index;
                if (rowsCount == 0) {
                    return;
                }
                //17
                else if (e.ColumnIndex == colViewImageClickIndex) {
                    try {
                        //lấy tên khách vãng lai cần hủy thẻ
                        String ImageFace = selectedRows[0].Cells[colImageFace.Name].Value.ToString();
                        String ImageIdentityCard = selectedRows[0].Cells[colImageIdentityCard.Name].Value.ToString();
                        try {
                            frm = new FrmShiftImage(ImageFace, ImageIdentityCard);
                        } catch (Exception ex) {
                            frm = new FrmShiftImage(ImageFace, ImageIdentityCard);
                        }
                        workItem.SmartParts.Add(frm);
                        int x = lblFilterByOrgName.Parent.Location.X + lblFilterByOrgName.Location.X;
                        int y = lblFilterByOrgName.Parent.Location.Y + lblFilterByOrgName.Parent.Height + 100;
                        frm.Location = new Point(x, y);
                        frm.Show();
                    } catch (Exception ex) {
                    }
                }
            }
        }

        private void dgvNonResidentMouseLeave(object sender, EventArgs e) {
            workItem.SmartParts.Remove(frm);
            frm.Hide();
        }

        /// <summary>
        /// click btn showhide
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowHide_Clicked(object sender, EventArgs e) {
            if (pnlFilterBox.Height > hiddenFilterBoxHeight) {
                pnlFilterBox.Height = hiddenFilterBoxHeight;
                btnShowHide.Text = btnShowHide.ToolTipText = MessageValidate.GetMessage(rm, "showSearchBox");
                btnShowHide.ToolTipText = MessageValidate.GetMessage(rm, "showSearchBox");
                btnShowHide.Image = global::CommonControls.Properties.Resources.ArrowDown_16x16;
            } else {
                pnlFilterBox.Height = startupFilterBoxHeight;
                btnShowHide.Text = btnShowHide.ToolTipText = MessageValidate.GetMessage(rm, "hiddenSearchBox");
                btnShowHide.ToolTipText = MessageValidate.GetMessage(rm, "hiddenSearchBox");
                btnShowHide.Image = global::CommonControls.Properties.Resources.ArrowUp_16x16;
            }
        }
        /// <summary>
        /// search name meeting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMeetingNameSearchs_TextChanged(object sender, EventArgs e) {
            String namesearch = txtMeetingNameSearchs.Text.Trim();
            if (namesearch.Equals("")) {
                dgvNonResident.DataSource = dtbNonResidentList;
            } else {
                try {
                    DataView dv = new DataView(dtbNonResidentList);

                    //20170307 #Bug Fix- My Nguyen Start
                    string data = FormatCharacterSearch.CheckValue(txtMeetingNameSearchs.Text.Trim());
                    dv.RowFilter = string.Format("MeetingName LIKE'%{0}%'", data);
                    dgvNonResident.DataSource = dv;

                    int record = dgvNonResident.Rows.Count;
                    if (record > 0) {
                        pagerPanel.ShowNumberOfRecords(sum, record, take, currentPageIndex);
                    } else {
                        UploadStatusBarHavePagePanel();
                    }
                    //20170307 #Bug Fix- My Nguyen End
                } catch (Exception ex) {
                    //dgvNonResident.DataSource = new DataView();
                }
            }
        }
        /// <summary>
        /// text change: name search
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtNameSearch_TextChanged(object sender, EventArgs e) {
            try {
                DataView dv = new DataView(dtbNonResidentList);

                //20170307 #Bug Fix- My Nguyen Start
                string data = FormatCharacterSearch.CheckValue(txtNameSearch.Text.Trim());
                dv.RowFilter = string.Format("FullName LIKE'%{0}%'", data);
                dgvNonResident.DataSource = dv;

                int record = dgvNonResident.Rows.Count;
                if (record > 0) {
                    pagerPanel.ShowNumberOfRecords(sum, record, take, currentPageIndex);
                } else {
                    UploadStatusBarHavePagePanel();
                }
                //20170307 #Bug Fix- My Nguyen End
            } catch (Exception ex) {
                //  dgvNonResident.DataSource = new DataView();
            }

        }
        /// <summary>
        /// click pagerPanel 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="e"></param>
        private void pagerPanel_LinkLabelClicked(object s, LinkLabelClickedArgs e) {
            int i;
            if (e.LabelText.Equals(PagerPanel.LabelBackText)) {
                currentPageIndex -= 1;
            } else if (e.LabelText.Equals(PagerPanel.LabelNextText)) {
                currentPageIndex += 1;
            } else if (int.TryParse(e.LabelText, out i)) {
                currentPageIndex = i;
            } else {
                return;
            }

            dtbNonResidentList.Rows.Clear();
            int skip = (currentPageIndex - 1) * take;

            NonResidentStatisticDetailObj nonResidentStatisticDetailObjNew = LoadNonResidentListAtPage(skip, take);
            if (nonResidentStatisticDetailObjNew != null) {
                List<NonResidentObj> result = nonResidentStatisticDetailObjNew.nonResidentObjs;
                LoadNonResidentStatisticListdata(result);
                pagerPanel.ShowNumberOfRecords(sum, result != null ? result.Count : 0, take, currentPageIndex);
                pagerPanel.UpdatePagingLinks(sum, take, currentPageIndex);
            } else {
                UploadStatusBarHavePagePanel();
            }
        }

        private void cbxOrg_SelectedIndexChanged(object sender, EventArgs e) {
            if (cbxOrg.SelectedIndex == 0) {
                nonOrgId = -1;
                listNonResMemSubOrgCBX = new List<NonResidenMemSubComboBox>();
                cbxMemSubOrg.DataSource = listNonResMemSubOrgCBX.ToList();
                cbxMemSubOrg.Enabled = false;
            } else {
                NonResidentOrganization nonResOrg = (NonResidentOrganization) cbxOrg.SelectedItem;
                nonOrgId = nonResOrg.nonOrgId;
                if (nonResOrg.isPeople == 1) {
                    isPeople = true;
                    LoadNonResMember();
                } else {
                    isPeople = false;
                    LoadNonResSubOrg();
                }
                cbxMemSubOrg.Enabled = true;
            }
        }

        // minh.nguyen
        private void LoadNonResOrg() {
            if (!bgwLoadNonResOrg.IsBusy) {
                bgwLoadNonResOrg.RunWorkerAsync();
            }
        }

        // minh.nguyen
        private void LoadNonResSubOrg() {
            if (!bgwLoadNonResSubOrg.IsBusy) {
                bgwLoadNonResSubOrg.RunWorkerAsync();
            }
        }

        // minh.nguyen
        private void LoadNonResMember() {
            if (!bgwLoadNonResMember.IsBusy) {
                bgwLoadNonResMember.RunWorkerAsync();
            }
        }
        #endregion

        #region Chuẩn bị dữ liệu xuất excel
        //20170304 #Bug Fix- My Nguyen Start
        /// <summary>
        /// lay du dlieu tu server cho export data
        /// </summary>
        /// <param name="totalpage">tong so trang</param>
        /// <returns></returns>
        private void GetDataFOrExport() {

            // query lan dau de lay du lieu va so luong records
            string theDateIn = dtpDateIn.Value.ToString("yyyy-MM-dd");
            string theDateIn2 = dtpDateIn2.Value.ToString("yyyy-MM-dd");
            NonResidentStatisticDetailObj nonResidentStatisticDetailObjNew = new NonResidentStatisticDetailObj();
            try {
                int start = 0;
                int end = take;
                nonResidentStatisticDetailObjNew = NonResidentStatisticsFactory.Instance.GetChannel().getListNonresidentByDateAndOrgId(StorageService.CurrentSessionId, start, end, theDateIn, theDateIn2, nonOrgId, nonMemOrSubOrgId, 1);
            } catch (Exception ex) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
            }

            if (nonResidentStatisticDetailObjNew != null) {

                // add data lan dau tien
                PrepareDataToExport(nonResidentStatisticDetailObjNew.nonResidentObjs);

                //phân trang
                int totalRecords = Convert.ToInt32(nonResidentStatisticDetailObjNew.sum);

                //lay them du lieu neu khong du vi tong so record lon hon so take (take = 20) trong 1 trang
                if (totalRecords > take) {
                    int numberPage = (totalRecords / take) + ((totalRecords % take > 0) ? 1 : 0);
                    for (int i = 1; i < numberPage; i++) {
                        int start = i * take;
                        int end = take;
                        nonResidentStatisticDetailObjNew = NonResidentStatisticsFactory.Instance.GetChannel().getListNonresidentByDateAndOrgId(StorageService.CurrentSessionId, start, end, theDateIn, theDateIn2, nonOrgId, nonMemOrSubOrgId, 1);
                        PrepareDataToExport(nonResidentStatisticDetailObjNew.nonResidentObjs);
                    }
                }

            }
        }

        /// <summary>
        ///  add du lieu vao datagridview
        /// </summary>
        /// <param name="datagridview"></param>
        /// <param name="data"></param>
        private void PrepareDataToExport(List<NonResidentObj> result) {
            int index = table4Export.Rows.Count;
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            for (int i = 0; i < result.Count; i++) {
                DataRow row = table4Export.NewRow();
                row.BeginEdit();
                index += 1;
                row[colOrderNum.DataPropertyName] = index;

                row[colMeetingId.DataPropertyName] = result[i].nonResident.meetingId;
                row[colMeetingName.DataPropertyName] = result[i].nonResident.meetingName;
                row[colPhoneNo.DataPropertyName] = result[i].nonResident.phonenumber;
                //  row[colAddress.DataPropertyName] = result[i].nonResident.temporaryAddress;
                row[colContactContent.DataPropertyName] = result[i].nonResident.note;

                //hinh
                if (result[i].dataImageFace != null) {
                    row[colImageFace.DataPropertyName] = result[i].dataImageFace;
                }
                if (result[i].dataImageIdentityCard != null) {
                    row[colImageIdentityCard.DataPropertyName] = result[i].dataImageIdentityCard;
                }
                row[colFullName.DataPropertyName] = result[i].nonResident.name;

                row[colPositionPartaker.DataPropertyName] = result[i].nonResident.nonResidentPosition;
                row[colOrgPartaker.DataPropertyName] = result[i].nonResident.nonResidentOrganization;

                row[colIdentityCard.DataPropertyName] = result[i].nonResident.identityCard;
                row[colToOrg.DataPropertyName] = result[i].nonResident.orgName;
                //if (result[i].nonResident.birthday != null && result[i].nonResident.birthday != "")
                //{
                //    DateTime birthday = start.AddMilliseconds(Convert.ToUInt64(result[i].nonResident.birthday)).ToLocalTime();
                //    string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                //    row[colBirthDate.DataPropertyName] = birthday.ToString(sysFormat);
                //}

                DateTime endDate = start.AddMilliseconds(Convert.ToUInt64(result[i].nonResident.outputTime)).ToLocalTime();
                DateTime datedefault = new DateTime(1971, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                DateTime datedefault2 = new DateTime(1972, 2, 2, 0, 0, 0, DateTimeKind.Utc);
                int compareDateEnd = DateTime.Compare(endDate, datedefault);
                int compareDateEnd2 = DateTime.Compare(endDate, datedefault2);
                if (compareDateEnd == 0) {
                    row[colOutTime.DataPropertyName] = updating;
                } else {
                    row[colOutTime.DataPropertyName] = endDate.ToString("HH:mm");
                }

                if (compareDateEnd2 == 0) {
                    row[colOutTime.DataPropertyName] = cancelled;
                }
                if (result[i].nonResident.serialNumber.Equals("00000000")) {
                    row[colPersoStatus.DataPropertyName] = cancelled;
                } else {
                    row[colPersoStatus.DataPropertyName] = updating;
                }

                if (result[i].nonResident.inputTime != null && result[i].nonResident.inputTime != "") {
                    DateTime inputtime = start.AddMilliseconds(Convert.ToUInt64(result[i].nonResident.inputTime)).ToLocalTime();
                    //  row[colPersoStatus.DataPropertyName] = "Đang hoạt động";
                    // string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;

                    row[colDate.DataPropertyName] = inputtime.ToString(sysFormatDate);
                    row[colInputTime.DataPropertyName] = inputtime.ToString("HH:mm");
                }

                row.EndEdit();
                table4Export.Rows.Add(row);
            }
        }
        //20170304 #Bug Fix  - My Nguyen End
        /// <summary>
        /// click btn export
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportToExcel_Click(object sender, EventArgs e) {
            String organizationMeetingName = "";
            long organizationMeetingid = -1;
            try {
                OrganizationMg organizationMeetingClick = (OrganizationMg) cbxOrg.SelectedItem;
                organizationMeetingName = organizationMeetingClick.name;
                organizationMeetingid = organizationMeetingClick.id;
            } catch (Exception ex) { }
            if (organizationMeetingid == -1)
                organizationMeetingName = "";

            // String name = MessageValidate.GetMessage(rm, "lbltititeStatisticDetailNonrisedentinout") + "_" + organizationMeetingName.ToString() + "_" + dateFroms.ToString("dd-MM-yyyy") + "_" + dateTos.ToString("dd-MM-yyyy");
            String name = MessageValidate.GetMessage(rm, "lbltititeStatisticDetailNonrisedentinout") + "_" + dateFroms.ToString("dd-MM-yyyy") + "_" + dateTos.ToString("dd-MM-yyyy");

            string filePath = ControlExtMethods.ShowSaveFileDialog(MessageValidate.GetMessage(rm, "smsChooseFileExport"), name, CategorizeExcel.Categorize);
            if (filePath != null) {
                try {
                    // show du lieu truoc do trong table
                    table4Export.Rows.Clear();
                    // tao du lieu moi
                    GetDataFOrExport();

                    //export excel
                    ConfigExportFileModel configExportFile = new ConfigExportFileModel();
                    configExportFile.FilePath = filePath;
                    if (organizationMeetingid == -1) {
                        GemboxUtils.Instance.ExportDataGridToFileCustom(dataGridview4Export, configExportFile, 4);//tua de, xuat file
                    } else
                        GemboxUtils.Instance.ExportDataGridToFileCustom(dataGridview4Export, configExportFile, 5);//tua de, xuat fileGemboxUtils.Instance.ExportDataGridToFile(dataGridview4Export.Rows.Count);//tua de, xuat file

                    GemboxUtils.Instance.ExportDataGridToFile(dataGridview4Export.Rows.Count);//tua de, xuat file
                    GemboxUtils.Instance.AutoFix();

                    //custom
                    //export general information
                    String lbltititeStatisticDetailNonrisedentinout = MessageValidate.GetMessage(rm, "lbltititeStatisticDetailNonrisedentinout");
                    GemboxUtils.Instance.AddHeader(lbltititeStatisticDetailNonrisedentinout == null ? string.Empty : lbltititeStatisticDetailNonrisedentinout);
                    int index = 3;
                    String value = "";
                    if (organizationMeetingid != -1) {
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

                    try {
                        GemboxUtils.Instance.Save();
                    } catch (IOException x) {
                        MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "fileExcelOpen"));
                    }
                    //end
                } catch (Exception ex) {
                    MessageBoxManager.ShowErrorMessageBox(this, ex.Message);
                    return;
                }
                MessageBoxManager.ShowInfoMessageBox(this, MessageValidate.GetMessage(rm, "smsLinkFile") + filePath);
            }
        }
        #endregion
    }
}
