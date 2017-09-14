using CardChipService;
using CommonControls;
using CommonHelper.Constants;
using CommonHelper.Utils;
using Microsoft.Practices.CompositeUI;
using ReaderManager;
using ReaderManager.Model;
using ReaderManager.Pcsc;
using sNonResidentComponent.Factory;
using sWorldModel;
using sWorldModel.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Resources;
using System.ServiceModel;
using System.Windows.Forms;
using CameraComponent;
using CameraComponent.Model;
using CameraComponent.View;
using System.Threading;
using System.Configuration;
using CommonControls.Custom;
using sNonResidentComponent.Constants;
using Microsoft.Practices.CompositeUI.Commands;
using sNonResidenComponent.WorkItems;
using ScanComponent;
using ScanComponent.LibPlusTek;
using System.IO;
using System.Diagnostics;
using sMeetingComponent.Constants;
using sNonResidentComponent.Model.Old;
using sMeetingComponent.Model;
using sNonResidentComponent.Model.CustomObj.Statistic;
using sNonResidentComponent.Model.CustomObj;
using sNonResidentComponent.Model;
using CommonHelper.Config;

namespace sNonResidentComponent.WorkItems {
    public partial class UsrAddNonResident : CommonUserControl {

        #region Properties
        //fixbug bat tat dau doc the khi mo 3 man hinh kiem soat
        // fix #948
        //loi PauseReader, StartReader
        //giua 3 man hinh kiem soat

        private bool isAdd_ActionDataHandler_For_cardChipManager = false;

        //  private bool scanCard = true;

        private const string ORG_NAME_WORK_CONTACT = "-";
        private const string DATE_WORK_CONTACT = "-";
        private const string TIME_WORK_CONTACT = "-";

        //phan lien quan den the
        private ReaderFactory factory;
        private IReader readerLib = null;
        private bool processing = false;
        private ICardChipManager cardChipManager;
        private Image imgIDCard = null;

        private string cardchip = "";
        public string imageNonResident = "";
        public string imageIdentityCard = "";
        private DataTable dtbMeetingList;
        private DataTable dtbOrgList;
        private DataTable dtbMemberSubOrgList;
        int selectedMeetingRowIndex = -1;
        int lastSelectedMeetingRowIndex = -1;
        bool isWorkContact = false;

        private BackgroundWorker bgwLoadMeetingList;
        private BackgroundWorker bgwLoadNonResOrg, bgwLoadNonResSubOrg, bgwLoadNonResMember;
        private List<EventMeeting> eventmeetinglist;
        private List<NonResidentOrganization> listNonResOrgDGV;
        private List<NonResidentMemberSubOrg> listNonResMemSubOrgDGV;
        long nonOrgId;
        bool isPeople;
        long nonMemOrSubOrgId;
        public NonResidentObj OriginalNonResidentObj;
        private NonResidentObj AddOrUpdateNonResidentObj;
        public static int status = 0;

        // User control này thông báo tin nhắn tự động tắt theo thời gian
        private UsrNotification usrNotification = null;

        #region Camera and Scan
        private IVideoSource faceVideoSource = null;
        private ScanFactory scanFactory;
        #endregion

        private ResourceManager rm;
        public DialogPostAction PostAction { get; private set; }
        private NonResidentComponentWorkItem workItem;
        [ServiceDependency]
        public NonResidentComponentWorkItem WorkItem {
            set { workItem = value; }
        }

        private ILocalStorageService storageService;
        [ServiceDependency]
        public ILocalStorageService StorageService {
            get {
                if (storageService == null) {
                    storageService = workItem.Services.Get<ILocalStorageService>();
                }
                return storageService;
            }
            set { storageService = value; }
        }
        #endregion

        #region Contructors
        public UsrAddNonResident() {
            InitializeComponent();
            InitDataTableOrgList();
            InitDataTableMemberSubOrgList();
            InitDataTableMeetingList();
            RegisterEvent();
            //phan lien quan den the
            RegisterEventCardChip();

            #region Camera and  Scan
            faceCanvas.StartRequested += canvas_StartRequested;
            faceCanvas.StopRequested += canvas_StopRequested;

            usiIDCard.StartRequested += IDCardImage_StartRequested;
            usiIDCard.StopRequested += IDCardImage_StopRequested;
            #endregion

            #region usrNotification : hiển thị thông báo
            usrNotification = new UsrNotification();
            usrNotification.Anchor = AnchorStyles.None;
            usrNotification.Visible = false;
            pnlParent.Controls.Add(usrNotification);
            usrNotification.Location = new Point(
                pnlParent.ClientSize.Width / 2 - usrNotification.Width / 2,
                pnlParent.ClientSize.Height / 2 - usrNotification.Height / 2);
            usrNotification.BringToFront();
            #endregion

            tbxFullName.Select();
            dgvMeetingList.ClearSelection();
        }
        /// <summary>
        /// RegisterEvent
        /// </summary>
        private void RegisterEvent() {
            CreateBackgroundWorkerEvent();

            Load += OnFormLoad;

            dgvMeetingList.KeyPress += dgvMeetingList_KeyPress;
            dgvMeetingList.CellMouseClick += dgvMeetingList_CellMouseClick;
            dgvOrgList.KeyPress += dgvOrgList_KeyPress;
            dgvOrgList.SelectionChanged += dgvOrgList_SelectionChanged;
            btnRefresh.Click += btnRefresh_Click;
            btnRefreshMeetingList.Click += btnRefreshMeetingList_Click;
            tbxIdentityCard.KeyPress += tbxIdentityCard_KeyPress;
            tbxPhoneNumber.KeyPress += tbxPhoneNumber_KeyPress;
        }

        /// <summary>
        /// OnFormLoad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFormLoad(object sender, EventArgs e) {
            DoListDevices();

            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            this.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.Name);
            SetLanguages();

            #region Camera
            PlayVideoSourceOnCanvas(faceCanvas);
            SetupAndStartScanner();
            #endregion

            LoadlEventMeetingListByOrgID();

            SetupFontSizeDataGridView();
        }
        /// <summary>
        /// SetupFontSizeDataGridView
        /// </summary>
        private void SetupFontSizeDataGridView() {
            // Font size data
            dgvMeetingList.DefaultCellStyle = new DataGridViewCellStyle {
                Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0)
            };

            dgvOrgList.DefaultCellStyle = new DataGridViewCellStyle {
                Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0)
            };

            dgvMemberSubOrgList.DefaultCellStyle = new DataGridViewCellStyle {
                Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0)
            };

            // Font size header
            dgvMeetingList.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle {
                Font = new Font("Tahoma", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0)
            };

            dgvOrgList.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle {
                Font = new Font("Tahoma", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0)
            };

            dgvMemberSubOrgList.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle {
                Font = new Font("Tahoma", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0)
            };
        }
        /// <summary>
        /// RegisterEventCardChip
        /// </summary>
        private void RegisterEventCardChip() {
            factory = ReaderFactory.GetInstance();
            readerLib = new PcscReader();
            cardChipManager = new CardChipManager();

            btnListDevices.Click += OnButtonListDevicesClicked;
            btnPause.Click += OnButtonPauseClicked;
            btnStart.Click += OnButtonStartClicked;
        }
        /// <summary>
        /// CreateBackgroundWorkerEvent
        /// </summary>
        private void CreateBackgroundWorkerEvent() {
            // Smeeting 1.lấy thông tin cuộc họp trong ngày
            bgwLoadMeetingList = new BackgroundWorker();
            bgwLoadMeetingList.WorkerSupportsCancellation = true;
            bgwLoadMeetingList.DoWork += OnLoadMeetingWorkerDoWork;
            bgwLoadMeetingList.RunWorkerCompleted += OnLoadMeetingWorkerCompleted;

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
        #endregion

        #region Set Languages
        /// <summary>
        /// SetLanguages
        /// </summary>
        private void SetLanguages() {
            colCheck.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, colCheck.Name);
            colMeetingDate.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, colMeetingDate.Name);
            colMeetingName.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, colMeetingName.Name);
            colMemberSubOrgName.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, colMemberSubOrgName.Name);
            colMemberSubOrgNo.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, colMemberSubOrgNo.Name);
            colNo.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, colNo.Name);
            colOrg.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, colOrg.Name);
            colOrgName.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, colOrgName.Name);
            colOrgNo.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, colOrgNo.Name);
            colTimeStart.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, colTimeStart.Name);
            lblCheckCardChip.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblCheckCardChip.Name);
            lblPassport.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblPassport.Name);
            lblCompany.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblCompany.Name);
            lblFullName.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblFullName.Name);
            lblGender.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblGender.Name);
            lblGuide.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblGuide.Name);
            lblGuideCardCheck.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblGuideCardCheck.Name);
            lblNonresident.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblNonresident.Name);
            lblnonresidentIdentitycard.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblnonresidentIdentitycard.Name);
            lblOrgMeeting.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblOrgMeeting.Name);
            lblInfoNonResident.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblInfoNonResident.Name);
            lblMeetingInformation.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblMeetingInformation.Name);
            lblMemberSubOrg.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblMemberSubOrg.Name);
            lblPhoneNumber.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblPhoneNumber.Name);
            lblPosition.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblPosition.Name);
            lblStatus.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblStatus.Name);
            rbtfemale.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, rbtfemale.Name);
            rbtmale.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, rbtmale.Name);
        }
        #endregion

        #region Set DataGridView Meeting
        /// <summary>
        /// InitDataTableMeetingList
        /// </summary>
        private void InitDataTableMeetingList() {
            dtbMeetingList = new DataTable();

            dtbMeetingList.Columns.Add(colMeetingId.DataPropertyName);
            dtbMeetingList.Columns.Add(colNo.DataPropertyName);
            dtbMeetingList.Columns.Add(colOrg.DataPropertyName);
            dtbMeetingList.Columns.Add(colOrganizationId.DataPropertyName);
            dtbMeetingList.Columns.Add(colMeetingName.DataPropertyName);
            dtbMeetingList.Columns.Add(colMeetingDate.DataPropertyName);
            dtbMeetingList.Columns.Add(colTimeStart.DataPropertyName);
            dtbMeetingList.Columns.Add(colCheck.DataPropertyName);

            dgvMeetingList.DataSource = dtbMeetingList;
        }

        /// <summary>
        /// Load list Meeting get được từ server vào DataGridView
        /// </summary>
        /// <param name="listHoliday"></param>
        private void loadListMeetingToDataGridView() {
            int noNumber = 1;

            // List meeting
            foreach (EventMeeting meeting in eventmeetinglist) {
                DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                DateTime startDate = start.AddMilliseconds(Convert.ToUInt64(meeting.startTime)).ToLocalTime();
                DateTime endDate = start.AddMilliseconds(Convert.ToUInt64(meeting.endTime)).ToLocalTime();

                noNumber++;
                DataRow row = dtbMeetingList.NewRow();
                row.BeginEdit();

                // Add một dòng mới vào DataTable
                row[colMeetingId.DataPropertyName] = meeting.id;
                row[colNo.DataPropertyName] = noNumber;
                row[colOrg.DataPropertyName] = meeting.organizationMeetingName;
                row[colOrganizationId.DataPropertyName] = meeting.organizationMeetingId;
                row[colMeetingName.DataPropertyName] = meeting.name;
                row[colMeetingDate.DataPropertyName] = startDate.ToString("dd'/'MM'/'yyyy");
                row[colTimeStart.DataPropertyName] = startDate.ToString("HH:mm");
                row[colCheck.DataPropertyName] = false;

                row.EndEdit();
                dtbMeetingList.Rows.Add(row);
            }
        }
        #endregion

        #region Set DataGridView Org
        /// <summary>
        /// InitDataTableOrgList
        /// </summary>
        private void InitDataTableOrgList() {
            dtbOrgList = new DataTable();

            dtbOrgList.Columns.Add(colOrgId.DataPropertyName);
            dtbOrgList.Columns.Add(colOrgNo.DataPropertyName);
            dtbOrgList.Columns.Add(colOrgName.DataPropertyName);
            dtbOrgList.Columns.Add(colIsPeople.DataPropertyName);

            dgvOrgList.DataSource = dtbOrgList;
        }

        /// <summary>
        /// Load list liên hệ công tác get được từ server vào DataGridView
        /// </summary>
        private void loadListOrgToDataGridView() {
            int noNumber = 0;
            foreach (NonResidentOrganization nonResOrg in listNonResOrgDGV) {
                noNumber++;
                DataRow row = dtbOrgList.NewRow();
                row.BeginEdit();

                // Add một dòng mới vào DataTable
                row[colOrgId.DataPropertyName] = nonResOrg.nonOrgId;
                row[colOrgNo.DataPropertyName] = noNumber;
                row[colOrgName.DataPropertyName] = nonResOrg.nonOrgName;
                row[colIsPeople.DataPropertyName] = nonResOrg.isPeople;

                row.EndEdit();
                dtbOrgList.Rows.Add(row);
            }
        }
        #endregion

        #region Set DataGridView Member SubOrg
        /// <summary>
        /// InitDataTableMemberSubOrgList
        /// </summary>
        private void InitDataTableMemberSubOrgList() {
            dtbMemberSubOrgList = new DataTable();

            dtbMemberSubOrgList.Columns.Add(colMemberSubOrgId.DataPropertyName);
            dtbMemberSubOrgList.Columns.Add(colMemberSubOrgNo.DataPropertyName);
            dtbMemberSubOrgList.Columns.Add(colMemberSubOrgName.DataPropertyName);

            dgvMemberSubOrgList.DataSource = dtbMemberSubOrgList;
        }

        /// <summary>
        /// Load list member hoặc suborg get được từ server vào DataGridView
        /// </summary>
        private void loadListMemberSubOrgToDataGridView() {
            int noNumber = 0;
            foreach (NonResidentMemberSubOrg nonResMemSubOrg in listNonResMemSubOrgDGV) {
                noNumber++;
                DataRow row = dtbMemberSubOrgList.NewRow();
                row.BeginEdit();

                // Add một dòng mới vào DataTable
                if (nonResMemSubOrg.isPeople) {
                    row[colMemberSubOrgId.DataPropertyName] = nonResMemSubOrg.nonResMemMapCustom
                                                                             .nonResMemMap
                                                                             .nonMemMapId;
                    row[colMemberSubOrgNo.DataPropertyName] = noNumber;
                    row[colMemberSubOrgName.DataPropertyName] = nonResMemSubOrg.nonResMemMapCustom
                                                                               .memberName;
                } else {
                    row[colMemberSubOrgId.DataPropertyName] = nonResMemSubOrg.nonResSubOrg
                                                                             .nonSubOrgId;
                    row[colMemberSubOrgNo.DataPropertyName] = noNumber;
                    row[colMemberSubOrgName.DataPropertyName] = nonResMemSubOrg.nonResSubOrg
                                                                               .nonSubOrgName;
                }

                row.EndEdit();
                dtbMemberSubOrgList.Rows.Add(row);
            }
        }
        #endregion

        #region Events
        /// <summary>
        /// Set Value to show Status suitable
        /// set lại giá trị để hiển thị thông báo phù hợp
        /// </summary>
        /// <param name="statusId"></param>
        public static void getStatus(int statusId) {
            status = statusId;
        }
        /// <summary>
        /// SHow message based on value index
        /// dự vào SetIndexStatus để kiểm tra và hiển thị thông báo
        /// </summary>
        public void ShowStatus() {
            if (status == 1) {
                Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Succeed, MessageValidate.GetMessage(rm, "smsSuccessUpdateNonResident"))));
                status = 0;
            } else if (status == 2) {   //cập nhật thông tin
                Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Succeed, MessageValidate.GetMessage(rm, "smsSuccessUpdateInfoNonResident"))));
                status = 0;
            }
        }
        /// <summary>
        /// LoadlEventMeetingListByOrgID
        /// </summary>
        private void LoadlEventMeetingListByOrgID() {
            if (!bgwLoadMeetingList.IsBusy) {
                dtbMeetingList.Clear();
                dtbOrgList.Clear();
                dtbMemberSubOrgList.Clear();
                bgwLoadMeetingList.RunWorkerAsync();
            }
        }

        // minh.nguyen
        private void LoadNonResOrg() {
            if (!bgwLoadNonResOrg.IsBusy) {
                dtbOrgList.Rows.Clear();
                bgwLoadNonResOrg.RunWorkerAsync();
            }
        }

        // minh.nguyen
        private void LoadNonResSubOrg() {
            if (!bgwLoadNonResSubOrg.IsBusy) {
                dtbMemberSubOrgList.Rows.Clear();
                bgwLoadNonResSubOrg.RunWorkerAsync();
            }
        }

        // minh.nguyen
        private void LoadNonResMember() {
            if (!bgwLoadNonResMember.IsBusy) {
                dtbMemberSubOrgList.Rows.Clear();
                bgwLoadNonResMember.RunWorkerAsync();
            }
        }

        /// <summary>
        /// ToEntity
        /// tao doi tuong  luu xuong 
        /// </summary>
        /// <returns></returns>
        private NonResidentObj ToEntity() {
            NonResidentObj nonResidentObj = new NonResidentObj();
            //image
            nonResidentObj.dataImageFace = imageNonResident;
            nonResidentObj.dataImageIdentityCard = imageIdentityCard;
            NonResident nonResident = new NonResident();
            DateTime dtIn = DateTime.Now;
            string dtInStr = dtIn.ToString("yyyy-MM-dd HH:mm:ss");
            DateTime dateEnd = new DateTime(1971, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            string dtOutStr = dateEnd.ToString("yyyy-MM-dd HH:mm:ss");
            nonResident.serialNumber = cardchip;
            nonResident.name = tbxFullName.Text;
            nonResident.nonResidentOrganization = tbxCompany.Text;
            nonResident.nonResidentPosition = tbxPosition.Text;
            nonResident.gender = rbtmale.Checked ? true : rbtfemale.Checked ? false : true;
            nonResident.identityCard = tbxIdentityCard.Text.Trim();
            nonResident.phonenumber = tbxPhoneNumber.Text.Trim();
            nonResident.inputTime = dtInStr;
            nonResident.outputTime = dtOutStr;
            nonResident.note = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "workContact") + " với "
                + dgvMemberSubOrgList.Rows[dgvMemberSubOrgList.CurrentRow.Index].Cells[colMemberSubOrgName.Name].Value.ToString();

            nonResident.status = true;
            string nameOrg = "";
            //org
            try {
                if (dgvOrgList.Enabled && dgvMemberSubOrgList.Enabled) { // Khách vãng lai tới liên hệ công tác
                    nonResident.orgId = nonOrgId;
                    nonResident.orgName = dgvOrgList.Rows[dgvOrgList.CurrentRow.Index]
                        .Cells[colOrgName.Name].Value.ToString();
                    if (isPeople) {
                        nonResident.isPeople = 1;
                    } else {
                        nonResident.isPeople = 0;
                    }
                    nonMemOrSubOrgId = Convert.ToInt64(dgvMemberSubOrgList.Rows[dgvMemberSubOrgList.CurrentRow.Index]
                        .Cells[colMemberSubOrgId.Name].Value.ToString());
                    nonResident.nonMemOrSubOrgId = nonMemOrSubOrgId;

                    nameOrg = nonResident.orgName.ToString();
                } else { // Khách vãng lai đi họp
                    nonResident.orgId = Convert.ToInt64(dgvMeetingList.Rows[selectedMeetingRowIndex]
                        .Cells[colOrganizationId.Name].Value.ToString());
                    nonResident.orgName = dgvMeetingList.Rows[selectedMeetingRowIndex]
                        .Cells[colOrg.Name].Value.ToString();
                    nonResident.isPeople = -1;
                    nonResident.nonMemOrSubOrgId = -1;
                    //nameOrg = nonResident.orgName.ToString();
                }
            } catch (Exception e) { }

            //metting
            long meetingClickId = 0;
            String meetingClickName = "";
            try {
                meetingClickId = Convert.ToInt64(dgvMeetingList.Rows[selectedMeetingRowIndex].Cells[colMeetingId.Name].Value.ToString());
                meetingClickName = dgvMeetingList.Rows[selectedMeetingRowIndex].Cells[colMeetingName.Name].Value.ToString();
            } catch (Exception e) { }
            if (meetingClickId == -1) {
                nonResident.meetingId = meetingClickId;
                nonResident.meetingName = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "workContact") + " " + nameOrg;
            }
            if (meetingClickId > 0) {
                nonResident.meetingId = meetingClickId;
                nonResident.meetingName = meetingClickName;
            }
            //khong phai cho doanh nghiep vao
            nonResident.isOrgOther = false;

            nonResidentObj.nonResident = nonResident;
            return nonResidentObj;
        }
        /// <summary>
        /// ClearEmptyControl
        /// </summary>
        public void ClearEmptyControl() {
            if (InvokeRequired) {
                Invoke(new Action(ClearEmptyControl));
                return;
            }

            ResetUsrScanImage();
            if (null != scanFactory) {
                if (!scanFactory.isCameraStarted) {
                    usiIDCard.Message = ScanConstant.DISCONNECTED_MESSAGE;
                } else {
                    usiIDCard.Message = ScanConstant.CONNECTED_MESSAGE;
                }
                scanFactory.isPassport = false;
            }

            tbxFullName.Text = String.Empty;
            tbxCompany.Text = String.Empty;
            tbxPosition.Text = String.Empty;
            tbxIdentityCard.Text = String.Empty;
            tbxPhoneNumber.Text = String.Empty;
            rbtmale.Checked = false;
            rbtfemale.Checked = true;

            dtbMemberSubOrgList.Rows.Clear();
            dgvMemberSubOrgList.Enabled = false;
            dgvOrgList.TabStop = true;
            dgvOrgList.Select();
            dgvOrgList.CurrentCell = dgvOrgList.Rows[0].Cells[colOrgName.Name];

            // Đóng code để khỏi bị clear danh sách chọn liên hệ công tác thì có tag thẻ
            //isWorkContact = false;
            //dtbOrgList.Clear();
            //dgvOrgList.Enabled = false;
            //tbxReason.Enabled = false;
            //lblReason.Enabled = false;
            //dgvMeetingList.TabStop = true;
            //dgvMeetingList.Select();
            //dgvMeetingList.CurrentCell = dgvMeetingList.Rows[0].Cells[colMeetingName.Name];
            //if (selectedMeetingRowIndex != -1) {
            //dgvMeetingList.Rows[selectedMeetingRowIndex].Cells[colCheck.Name].Value = false;
            //lastSelectedMeetingRowIndex = selectedMeetingRowIndex = -1;
            //}
        }

        /// <summary>
        /// meetingListCheckToColumnCheckBox
        /// </summary>
        public void meetingListCheckToColumnCheckBox() {
            // Set checkbox
            selectedMeetingRowIndex = dgvMeetingList.CurrentRow.Index;
            dgvMeetingList.Rows[selectedMeetingRowIndex].Cells[colCheck.Name].Value = true;

            //nếu dòng hiện tại là "Liên hệ công tác"
            if (selectedMeetingRowIndex == 0) { // Nếu check vào liên hệ công tác
                if (isWorkContact) { // Nếu đã chọn liên hệ công tác rồi thì bỏ chọn
                    isWorkContact = false;
                } else {
                    isWorkContact = true;
                }
            } else {
                isWorkContact = false;
            }

            if (lastSelectedMeetingRowIndex == -1) { // Nếu chưa dòng nào chọn
                lastSelectedMeetingRowIndex = selectedMeetingRowIndex;
            } else if (lastSelectedMeetingRowIndex == selectedMeetingRowIndex) { // Nếu dòng hiện tại đang chọn đã check rồi
                dgvMeetingList.Rows[lastSelectedMeetingRowIndex].Cells[colCheck.Name].Value = false;
                lastSelectedMeetingRowIndex = selectedMeetingRowIndex = -1;

                dgvOrgList.Enabled = false;
                dgvMemberSubOrgList.Enabled = false;
            } else {
                dgvMeetingList.Rows[lastSelectedMeetingRowIndex].Cells[colCheck.Name].Value = false;
                lastSelectedMeetingRowIndex = selectedMeetingRowIndex;
            }

            // nếu dòng hiện tại là "Liên hệ công tác"
            if (Convert.ToInt32(dgvMeetingList.Rows[dgvMeetingList.CurrentRow.Index]
                .Cells[colNo.Name].Value.ToString()) == 1 && isWorkContact) {

                LoadNonResOrg();

                // Enabled vùng danh sách đơn vị
                dgvOrgList.Enabled = true;
                dgvOrgList.Select();
                dgvMeetingList.TabStop = false;
                dgvMemberSubOrgList.Enabled = false;
            } else {
                dtbOrgList.Clear();
                dtbMemberSubOrgList.Clear();
            }
        }

        /// <summary>
        /// keypress : only make-a-textbox-that-only-accepts-numbers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxIdentityCard_KeyPress(object sender, KeyPressEventArgs e) {
            //kí tự nhập vào phải là số hay ko
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        /// <summary>
        /// keypress : only make-a-textbox-that-only-accepts-numbers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxPhoneNumber_KeyPress(object sender, KeyPressEventArgs e) {
            //kí tự nhập vào phải là số hay ko
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        /// <summary>
        /// key press dgv
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvMeetingList_KeyPress(object sender, KeyPressEventArgs e) {
            // 32 là keychar spacebar
            if (e.KeyChar == 32 && dgvMeetingList.Focus()) {
                meetingListCheckToColumnCheckBox();
            } else if (e.KeyChar == 9) { // 9 là keychar tab
                if (selectedMeetingRowIndex != -1) {
                    dgvMeetingList.TabStop = false;
                    tbxFullName.Select();
                }
            }
        }
        /// <summary>
        /// keypress dgv org
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvOrgList_KeyPress(object sender, KeyPressEventArgs e) {
            // 32 là keychar spacebar
            if (e.KeyChar == 32 && dgvOrgList.Focused) {
                int selectedRow = dgvOrgList.CurrentRow.Index;
                nonOrgId = Convert.ToInt64(dgvOrgList.Rows[selectedRow]
                                           .Cells[colOrgId.Name].Value.ToString());
                if (Convert.ToInt64(dgvOrgList.Rows[selectedRow]
                                    .Cells[colIsPeople.Name].Value.ToString()) == 1) {
                    isPeople = true;
                    LoadNonResMember();
                } else {
                    isPeople = false;
                    LoadNonResSubOrg();
                }

                // Enabled vùng danh sách đơn vị và thành viên
                dgvMemberSubOrgList.Enabled = true;
                dgvMemberSubOrgList.Select();
                dgvOrgList.TabStop = false;
            }
        }

        private void dgvOrgList_SelectionChanged(object sender, EventArgs e) {
            dtbMemberSubOrgList.Rows.Clear();
        }

        /// <summary>
        /// click btn refesh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e) {
            ClearEmptyControl();
            AutoRefreshWhenChangeTab();
        }
        /// <summary>
        /// mouse click dgv
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvMeetingList_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e) {
            int checkBoxColumn = dgvMeetingList.Columns[colCheck.Name].Index;

            if (e.RowIndex > -1 && e.ColumnIndex == checkBoxColumn) {
                meetingListCheckToColumnCheckBox();
            }
        }
        /// <summary>
        /// click btn refesh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefreshMeetingList_Click(object sender, EventArgs e) {
            isWorkContact = false;
            if (selectedMeetingRowIndex != -1) {
                dgvMeetingList.Rows[selectedMeetingRowIndex].Cells[colCheck.Name].Value = false;
                lastSelectedMeetingRowIndex = selectedMeetingRowIndex = -1;
            }
            LoadlEventMeetingListByOrgID();
            dgvMeetingList.TabStop = true;
            dgvMeetingList.Select();
        }

        public void AutoRefreshWhenChangeTab() {
            isWorkContact = false;
            if (selectedMeetingRowIndex != -1) {
                dgvMeetingList.Rows[selectedMeetingRowIndex].Cells[colCheck.Name].Value = false;
                lastSelectedMeetingRowIndex = selectedMeetingRowIndex = -1;
            }
            LoadlEventMeetingListByOrgID();
        }
        #endregion

        #region Event's CardChip
        private void OnButtonStartClicked(object sender, EventArgs e) {
            StartReader();
        }

        private void ActionData(DataCardObject obj) {
            switch (obj.eventType) {
                case DataCardObject.TAG_DETECTED:
                    OnTagDetected(obj.cardType, obj.serialNumber);
                    break;
            }
        }

        public void StartReader() {
            if (cmbReaders.SelectedIndex == -1) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessSelect(rm, MessageValidate.Reader), MessageValidate.GetErrorTitle(rm));
                return;
            }
            String selectedReader = cmbReaders.SelectedItem.ToString();
            if (String.Empty != selectedReader) {

                if (cardChipManager.WaitingCard(selectedReader)) {
                    ChangeStatusMessage(MessageValidate.GetMessage(rm, "WaitingTag"));
                    SwitchRunningState(true);
                    if (!isAdd_ActionDataHandler_For_cardChipManager) {
                        cardChipManager.ActionDataHandler += ActionData;
                        isAdd_ActionDataHandler_For_cardChipManager = true;
                    }
                }
            } else {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessSelect(rm, MessageValidate.Reader), MessageValidate.GetErrorTitle(rm));
            }
        }
        private void OnButtonPauseClicked(object sender, EventArgs e) {
            PauseReader();
        }

        public void PauseReader() {
            if (null != readerLib) {
                readerLib.Disconnect(null);
            }
            //if (dataDialog != null && dataDialog.Visible)
            //{
            //    dataDialog.Hide();
            //}
            SwitchRunningState(false);
            ChangeStatusMessage(MessageValidate.GetMessage(rm, "ReaderNotConnected"));
            cardChipManager.Disconnect();
        }

        private void OnButtonListDevicesClicked(object sender, EventArgs e) {
            DoListDevices();
        }
        private void DoListDevices() {
            cmbReaders.DataSource = null;

            // find all card reader
            List<String> listReaders = factory.FindAllCardReader();
            if (listReaders != null && listReaders.Count > 0) {
                cmbReaders.DataSource = listReaders;
                cmbReaders.SelectedIndex = 0;
            }
        }

        private void ChangeStatusMessage(string msg) {
            if (InvokeRequired) {
                Invoke(new Action<string>(ChangeStatusMessage), msg);
                return;
            }
            lblStatus.Text = msg;
        }

        private void SwitchRunningState(bool running) {
            if (InvokeRequired) {
                Invoke(new Action<bool>(SwitchRunningState), running);
                return;
            }
            cmbReaders.Enabled = btnStart.Enabled = btnListDevices.Enabled = !running;
            btnPause.Enabled = running;
        }

        private void SwitchProcessingState() {
            if (InvokeRequired) {
                Invoke(new Action(SwitchProcessingState));
                return;
            }
            if (processing) {
                lblStatus.BackColor = this.BackColor;
                lblStatus.ForeColor = this.ForeColor;
                lblStatus.Text = MessageValidate.GetMessage(rm, "WaitingTag");
                processing = false;
            } else {
                processing = true;
                lblStatus.BackColor = SystemColors.Highlight;
                lblStatus.ForeColor = SystemColors.HighlightText;
                lblStatus.Text = MessageValidate.GetMessage(rm, "PerformActionOnCard");
            }
        }
        #endregion

        #region Reader library events CARDCHIP
        private void OnTagDetected(int cardType, byte[] serialNumber) {
            if (!processing) {
                SwitchProcessingState();
                string msg = string.Empty;
                // Chuyển cardId từ mảng byte sang kiểu uint
                string cardIdUint = StringUtils.ByteArrayToHexString(serialNumber);
                cardchip = cardIdUint;
                if (cardchip == "") {
                    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "smsCardNotInfo"));
                }
                // kiểm tra xem thẻ đó ngày hôm nay có vào chưa, gọi phương thức CheckInOutUpdateAttendMeetingJournalist();
                else {
                    CheckInOutNonResident();
                }

                #region check in for sparking
                if (CheckIn_For_sParking(cardType, serialNumber)) {
                    // thành công
                }
                #endregion

                //}
            }
        }
        #endregion

        #region Function check in for sparking
        private bool CheckIn_For_sParking(int cardType, byte[] serialNumber) {
            switch (cardType) {
                case (int) CARD_TYPE.DESFIRE_CARD:
                    cardChipManager.SetFreesParking();
                    break;
                default:
                    break;
            }

            return true;
        }

        #endregion

        #region Camera Face
        private void canvas_StopRequested(object sender, EventArgs e) {
            faceVideoSource.Stop();
            faceCanvas.Message = VideoSourceContants.DisconnectedByUserMessage;
        }

        private void canvas_StartRequested(object sender, EventArgs e) {
            PlayVideoSourceOnCanvas(faceCanvas);
        }

        private void PlayVideoSourceOnCanvas(UsrCameraCanvas canvas) {
            string source = "";
            try {
                source = ConfigurationManager.AppSettings["camera_address_nonresident"];
            } catch (Exception ex) {
                // lỗi chưa cấu hình đường dẫn camera_address_nonresident trong file app_config
            }

            SetupAndPlayVideoSource(ref faceVideoSource, faceCanvas, (CameraConnectionType) 1 /*NetworkCameraViaRTSP*/, source);

        }

        private void SetupAndPlayVideoSource(ref IVideoSource videoSource, UsrCameraCanvas canvas, CameraConnectionType conntype, string source) {
            if (videoSource == null || videoSource.IsDisposed) {
                videoSource = VideoSourceFactory.GetInstance().Register(conntype, source, canvas);
                if (videoSource == null) {
                    // lỗi
                    return;
                }
                videoSource.Stopped += videoSource_Stopped;
                videoSource.Played += videoSource_Played;
                canvas.Message = VideoSourceContants.ConnectingMessage;
                PlayVideoSourceInNewThread(videoSource);
            } else {
                if (videoSource.ConnectionType != conntype) {
                    if (videoSource.IsPlaying) {
                        videoSource.Stop();
                    }
                    videoSource = VideoSourceFactory.GetInstance().Register(conntype, source, canvas);
                    if (videoSource == null) {
                        // lỗi
                        return;
                    }
                    videoSource.Stopped += videoSource_Stopped;
                    videoSource.Played += videoSource_Played;
                    canvas.Message = VideoSourceContants.ConnectingMessage;
                    PlayVideoSourceInNewThread(videoSource);
                } else if (!videoSource.Source.Equals(source)) {
                    bool playing;
                    if (playing = videoSource.IsPlaying) {
                        StopVideoSourceInNewThread(videoSource, true);
                    }
                    videoSource.Source = source;
                    //if (playing)
                    //{
                    //    canvas.Message = VideoSourceContants.ConnectingMessage;
                    //    videoSourceLabel.State = DeviceState.Connecting;

                    //    PlayVideoSourceInNewThread(videoSource);
                    //}
                    canvas.Message = VideoSourceContants.ConnectingMessage;

                    PlayVideoSourceInNewThread(videoSource);
                } else if (!videoSource.IsPlaying) {
                    canvas.Message = VideoSourceContants.ConnectingMessage;
                    PlayVideoSourceInNewThread(videoSource);
                }
            }
        }
        private void videoSource_Stopped(VideoSourceEventArgs e) {
            if (!IsHandleCreated || IsDisposed) {
                return;
            }
            if (InvokeRequired) {
                Invoke(new Action<VideoSourceEventArgs>(videoSource_Stopped), e);
                return;
            }
            faceCanvas.Message = VideoSourceContants.DisconnectedMessage;
            faceCanvas.Invalidate();
        }
        private void videoSource_Played(VideoSourceEventArgs e) {
            if (!IsHandleCreated || IsDisposed) {
                return;
            }
            if (InvokeRequired) {
                Invoke(new Action<VideoSourceEventArgs>(videoSource_Played), e);
                return;
            }
            faceCanvas.Message = VideoSourceContants.DataReceivingMessage;

            /* Thỉnh thoảng, sau khi hiển thị được hình camera lên canvas,
             * các phần dư xung quanh có màu đen thay vì là back color mà
             * mình đã set -> cần gọi hàm refresh
             */
            faceCanvas.Refresh();
        }

        private void PlayVideoSourceInNewThread(IVideoSource videoSource) {
            Thread th = new Thread(() => videoSource.Play());
            th.Start();
        }

        private void StopVideoSourceInNewThread(IVideoSource videoSource, bool join) {
            if (videoSource != null && !videoSource.IsDisposed) {
                Thread th = new Thread(() => {
                    videoSource.Stop();
                });
                th.Start();
                if (join) {
                    th.Join();
                }
            }
        }
        private string TakeSnapShot() {
            string _Image = "";
            if (faceVideoSource == null || !faceVideoSource.IsPlaying) {
                // camera không hoạt động
                return "";
            } else {
                Image faceImage;
                try {
                    faceImage = faceVideoSource.TakeSnapshot();
                    _Image = ImageUtils.ImageToBase64(faceImage);
                } catch (Exception ex) {
                    // lỗi
                }
            }

            return _Image;
        }
        #endregion

        #region Scan Device
        /// <summary>
        /// Bắt sự kiện chuột phải chọn kết nối
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IDCardImage_StartRequested(object sender, EventArgs e) {
            ResetUsrScanImage();
            StartScanDevice();
        }

        /// <summary>
        /// Bắt sự kiện chuột phải chọn ngắt kết nối
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IDCardImage_StopRequested(object sender, EventArgs e) {
            if (scanFactory != null) {
                ResetUsrScanImage();
                StopScanDevice();
            }
        }

        /// <summary>
        /// Bắt đầu kết nối tới máy scan (load thư viện và đăng ký)
        /// </summary>
        private void SetupAndStartScanner() {
            scanFactory = ScanFactory.GetInstance();
            if (scanFactory != null) {
                if (scanFactory.GetScanDeviceList()) {
                    // Lấy được máy scan
                    scanFactory.EventStopHandler += scanFactory_EventStopHandler;
                    StartScanDevice();
                } else {
                    // Có gì đó bí ẩn rồi
                    return;
                }
            }
        }

        /// <summary>
        /// Kết nối tới máy scan
        /// </summary>
        public void StartScanDevice() {
            if (scanFactory != null) {
                scanFactory.SetupAll();

                if (!scanFactory.isCameraStarted) {
                    usiIDCard.Message = ScanConstant.DISCONNECTED_MESSAGE;
                } else {
                    usiIDCard.Message = ScanConstant.CONNECTED_MESSAGE;
                }
            }
        }

        /// <summary>
        /// Ngắt kết nối tạm thời, chưa giải phóng 
        /// </summary>
        public void StopScanDevice() {
            if (scanFactory != null) {
                scanFactory.StopScanDevice();
                usiIDCard.Message = ScanConstant.DISCONNECTED_BY_USER_MESSAGE;
            }
        }

        /// <summary>
        /// Ngắt kết nối hoàn toàn với máy scan
        /// </summary>
        public void CloseScanDevice() {
            if (scanFactory != null) {
                scanFactory.CloseScanDevice();
            }
        }

        /// <summary>
        /// Bắt sự kiện từ máy scan send qua đây
        /// </summary>
        /// <param name="strMessage"></param>
        public void scanFactory_EventStopHandler(string strMessage) {
            usiIDCard.Message = strMessage;
            ResetUsrScanImage();
            if (strMessage.Equals(ScanConstant.ACQUIRING_SUCCESS_MESSAGE)) {
                imgIDCard = LoadImageScanned();
                usiIDCard.Image = imgIDCard;
                usiIDCard.ShowImage = true;
            }
        }

        /// <summary>
        /// Get hình ảnh đã scan được từ folder temp
        /// </summary>
        /// <returns></returns>
        private Image LoadImageScanned() {
            string[] images = Directory.GetFiles(ScanConstant.NONRES_IMAGE_TEMP_PATH, "*" + ScanConstant.JPG_EXTENSIONS);

            if (images.Length > 1) {
                for (int i = 0; i < images.Length - 1; i++) {
                    File.Delete(images[i]);
                }
            }

            Bitmap tmpBmp = new Bitmap(images[images.Length - 1]);
            Image image = new Bitmap(tmpBmp);
            tmpBmp.Dispose(); // Free file để xóa

            // reset lại các trường khi có lượt scan mới
            tbxFullName.Text = String.Empty;
            tbxIdentityCard.Text = String.Empty;
            rbtfemale.Checked = true;

            if (scanFactory.isPassport) {
                // Nếu là Passport thì mới tách text
                ProcessStartInfo startInfo = new ProcessStartInfo(ScanConstant.TEXT_READER_APPLICATION_PATH);
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = true;
                //Lấy hình để tách text
                startInfo.Arguments = images[images.Length - 1];

                Process readText = Process.Start(startInfo);

                // Lấy tên file hình để tìm file txt
                string imageFileName = "";
                imageFileName = scanFactory.GetDataBySubString(images[images.Length - 1],
                                                               ScanConstant.NONRES_IMAGE_TEMP_PATH + "\\");
                imageFileName = imageFileName.Substring(0, imageFileName.Length - ScanConstant.JPG_EXTENSIONS.Length);
                Thread.Sleep(1200);
                string[] text = Directory.GetFiles(ScanConstant.NONRES_IMAGE_TEMP_PATH, imageFileName + ScanConstant.TXT_EXTENSIONS);

                if (text != null) {
                    if (text.Length > 0) {
                        readText.CloseMainWindow();
                        readText.Close();
                        InitData(text);
                    }

                    scanFactory.isPassport = false;
                }
            }

            return image;
        }

        /// <summary>
        /// Convert hình đã scan sang string để lưu xuống database
        /// </summary>
        /// <returns></returns>
        private string GetImageScanned() {
            string _Image = "";

            try {
                if (null != imgIDCard) {
                    _Image = ImageUtils.ImageToBase64(imgIDCard);
                }
            } catch (Exception ex) {
                // lỗi
            }

            return _Image;
        }

        /// <summary>
        /// Đọc dữ liệu đã tách và init vào textbox
        /// </summary>
        /// <param name="text"></param>
        private void InitData(string[] text) {
            string[] log = Directory.GetFiles(ScanConstant.NONRES_IMAGE_TEMP_PATH, ScanConstant.MRTDSREASER_STATUS_LOG_FILE);
            if (log != null && log.Length > 0) {
                string[] logLines = File.ReadAllLines(log[0]);
                if (logLines != null && logLines.Length > 0) {
                    if (logLines[1] != ScanConstant.REC_DATA_ERROR) {
                        string[] lines = File.ReadAllLines(text[0]);

                        // Init vào textbox
                        tbxFullName.Text = scanFactory.GetDataBySubString(lines[ScanConstant.FAMILY_NAME_LINE], ScanConstant.FAMILY_NAME) +
                            " " + scanFactory.GetDataBySubString(lines[ScanConstant.GIVEN_NAME_LINE], ScanConstant.GIVEN_NAME);
                        tbxIdentityCard.Text = scanFactory.GetDataBySubString(lines[ScanConstant.DOCUMENT_NUMBER_LINE], ScanConstant.DOCUMENT_NUMBER);
                        switch (scanFactory.GetDataBySubString(lines[ScanConstant.SEX_LINE], ScanConstant.SEX)) {
                            case "M":
                                rbtmale.Checked = true;
                                break;
                            case "F":
                                rbtfemale.Checked = true;
                                break;
                            default:
                                break;
                        }

                        File.Delete(text[0]);
                    }
                }
            }
        }

        /// <summary>
        /// Reset Image và Message trong UsrScanImage
        /// </summary>
        private void ResetUsrScanImage() {
            imgIDCard = null;
            usiIDCard.Image = imgIDCard;
            usiIDCard.ShowImage = false;
        }
        #endregion

        #region Background Worker
        /// <summary>
        /// OnLoadMeetingWorkerDoWork
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadMeetingWorkerDoWork(object sender, DoWorkEventArgs e) {
            try {
                DateTime date = DateTime.UtcNow.Date;
                e.Result = eventmeetinglist = sMeetingComponent.Factory.MeetingEventFactory
                    .Instance.GetChannel().getEventMeetingListByDate(StorageService.CurrentSessionId, date.ToString("yyyy-MM-dd"));
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

        /// <summary>
        /// OnLoadMeetingWorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadMeetingWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            // Lien he cong tac
            DataRow rowOther = dtbMeetingList.NewRow();
            rowOther.BeginEdit();

            // Add một dòng mới vào DataTable
            rowOther[colMeetingId.DataPropertyName] = -1;
            rowOther[colNo.DataPropertyName] = 1;
            rowOther[colOrg.DataPropertyName] = ORG_NAME_WORK_CONTACT;
            rowOther[colOrganizationId.DataPropertyName] = -1;
            rowOther[colMeetingName.DataPropertyName] = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, "workContact");
            rowOther[colMeetingDate.DataPropertyName] = DATE_WORK_CONTACT;
            rowOther[colTimeStart.DataPropertyName] = TIME_WORK_CONTACT;
            rowOther[colCheck.DataPropertyName] = false;

            rowOther.EndEdit();
            dtbMeetingList.Rows.Add(rowOther);

            if (e.Cancelled) {
                Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "SmsNotConnectData"))));
                return;
            }
            if (e.Result == null) {
                Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "SmsNotInforMeeting"))));
                return;
            } else {
                List<EventMeeting> result = (List<EventMeeting>) e.Result;
                if (result.Count > 0) {
                    loadListMeetingToDataGridView();

                    // Load danh sách họp xong thì mặc định check vào dòng liên hệ công tác
                    dgvMeetingList.CurrentCell = dgvMeetingList.Rows[0].Cells[colMeetingName.Name];
                    dgvMeetingList.Rows[0].Selected = true;
                    meetingListCheckToColumnCheckBox();
                } else {
                    // Load danh sách họp xong thì mặc định check vào dòng liên hệ công tác
                    dgvMeetingList.CurrentCell = dgvMeetingList.Rows[0].Cells[colMeetingName.Name];
                    dgvMeetingList.Rows[0].Selected = true;
                    meetingListCheckToColumnCheckBox();
                    return;
                }
            }
        }

        /// <summary>
        /// check info nonresident based on serialnumber
        /// 3.CHECK kiểm tra thông tin cửa thẻ khách vãng lai 
        /// </summary>
        private void CheckInOutNonResident() {
            try {
                //check serial in or out
                OriginalNonResidentObj = NonResidentFactory.Instance.GetChannel().checkInOutNonResidentBySerialnumber(storageService.CurrentSessionId, cardchip);
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
            } finally { //cho không bị lặp hiển thị?
                        //nếu không có thông tin thì hiển lưu thông tin cho thẻ đó
                if (OriginalNonResidentObj == null) {
                    if (dgvMeetingList.Rows.Count == 0) { // Không có cuộc họp
                        Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "smsErrorNullMeeting"))));
                    } else {
                        // Nếu đang chọn "Liên hệ công tác" nhưng chưa chọn đơn vị liên hệ
                        if (Convert.ToInt64(dgvMeetingList.Rows[dgvMeetingList.CurrentRow.Index]
                            .Cells[colMeetingId.Name].Value.ToString()) == -1 && (dgvOrgList.Enabled == false || dgvMemberSubOrgList.Enabled == false)) {
                            // Thông báo chưa chọn đơn vị liên hệ
                            Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "smsErrorNullOrganization"))));
                        } else if (selectedMeetingRowIndex == -1) {
                            // Thông báo chưa chọn cuộc họp
                            Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "smsErrorNullMeeting"))));
                        } else {
                            AddInforNonResident();
                            ClearEmptyControl();
                        }
                    }
                }
                //nếu có thông tin thì hiển thị thông tin khách vãng lai lên trên FrmUpdateNonResident
                else {
                    FrmUpdateNonResident frmUpdateNonResident = new FrmUpdateNonResident(OriginalNonResidentObj, false);
                    if (null != frmUpdateNonResident) {
                        workItem.SmartParts.Add(frmUpdateNonResident);
                        frmUpdateNonResident.ShowDialog();
                        workItem.SmartParts.Remove(frmUpdateNonResident);
                        ShowStatus();
                        ClearEmptyControl();
                        frmUpdateNonResident.Hide();
                    }
                }

                SwitchProcessingState();
            }
        }

        public bool CheckValueImage(String imageNonResident, String imageIdentityCard) {
            if (imageNonResident.Equals("") || imageIdentityCard.Equals("")) {

                if (MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetMessage(rm, "smsQuestionYesNoImageCamera")) == DialogResult.No) {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// insert nonresident
        /// 4.INSERT Lưu thông tin khách đến VPUB
        /// </summary>
        private void AddInforNonResident() {
            DateTime dtIn2 = DateTime.Now;
            if (InvokeRequired) {
                Invoke(new Action(AddInforNonResident));
                return;
            }
            imageNonResident = TakeSnapShot();
            imageIdentityCard = GetImageScanned(); // MINHTODO

            //kiem tra hinh anh truoc khi luu thong tin khách vãng lai
            //if ((!imageNonResident.Equals("") && !imageIdentityCard.Equals(""))

            //     || (imageNonResident.Equals("") && !imageIdentityCard.Equals("")
            //    && MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetMessage(rm, "smsQuestionYesNoImageCamera")) == DialogResult.Yes)

            //     || (!imageNonResident.Equals("") && imageIdentityCard.Equals("")
            //    && MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetMessage(rm, "smsQuestionYesNoImageCamera")) == DialogResult.Yes)

            //    || (imageNonResident.Equals("") && imageIdentityCard.Equals("")
            //    && MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetMessage(rm, "smsQuestionYesNoImageCamera")) == DialogResult.Yes))
            //{

            //fix
            if (CheckValueImage(imageNonResident, imageIdentityCard)) {
                AddOrUpdateNonResidentObj = ToEntity();
                try {
                    OriginalNonResidentObj = NonResidentFactory.Instance.GetChannel().insertNonResident(storageService.CurrentSessionId, AddOrUpdateNonResidentObj);
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
                } finally {
                    // CheckCard(true);
                    if (OriginalNonResidentObj != null) {
                        Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Succeed, MessageValidate.GetMessage(rm, "smsSuccessNonResident"))));
                        PostAction = DialogPostAction.SUCCESS;
                    } else {
                        Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "smsErrorInsertNonResident"))));
                    }
                }
            } else {
                Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "smsErrorInsertNonResident"))));
            }
        }

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

            listNonResOrgDGV = new List<NonResidentOrganization>();
            listNonResOrgDGV = (List<NonResidentOrganization>) e.Result;
            // Load danh sách đơn vị phòng ban
            if (listNonResOrgDGV.Count > 0) {
                loadListOrgToDataGridView();
            }
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

            listNonResMemSubOrgDGV = new List<NonResidentMemberSubOrg>();
            List<NonResidentSubOrganization> nonResListAllSubOrg;
            nonResListAllSubOrg = (List<NonResidentSubOrganization>) e.Result;

            foreach (NonResidentSubOrganization nonResSubOrg in nonResListAllSubOrg) {
                NonResidentMemberSubOrg nonResMemSubOrg = new NonResidentMemberSubOrg();
                nonResMemSubOrg.nonResSubOrg = nonResSubOrg;
                nonResMemSubOrg.isPeople = isPeople;
                listNonResMemSubOrgDGV.Add(nonResMemSubOrg);
            }

            // Load danh sách đơn vị phòng ban
            if (listNonResMemSubOrgDGV.Count > 0) {
                loadListMemberSubOrgToDataGridView();
            }
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

            listNonResMemSubOrgDGV = new List<NonResidentMemberSubOrg>();
            List<NonResidentMemberMapCustom> nonResListAllMemMapCustom;
            nonResListAllMemMapCustom = (List<NonResidentMemberMapCustom>) e.Result;

            foreach (NonResidentMemberMapCustom nonResMemMapCustom in nonResListAllMemMapCustom) {
                NonResidentMemberSubOrg nonResMemSubOrg = new NonResidentMemberSubOrg();
                nonResMemSubOrg.nonResMemMapCustom = nonResMemMapCustom;
                nonResMemSubOrg.isPeople = isPeople;
                listNonResMemSubOrgDGV.Add(nonResMemSubOrg);
            }

            // Load danh sách đơn vị phòng ban
            if (listNonResMemSubOrgDGV.Count > 0) {
                loadListMemberSubOrgToDataGridView();
            }
        }
        #endregion
        #endregion

        #region CAB events
        [CommandHandler(NonResidentCommandName.ShowNonResident)]
        public void ShowAddNonResidentMainHandler(object s, EventArgs e) {
            UsrAddNonResident uc = workItem.Items.Get<UsrAddNonResident>(NonResidentCommandName.MenuNonResidentItem);
            if (uc == null) {
                uc = workItem.Items.AddNew<UsrAddNonResident>(NonResidentCommandName.MenuNonResidentItem);
            } else if (uc.IsDisposed) {
                workItem.Items.Remove(uc);
                uc = workItem.Items.AddNew<UsrAddNonResident>(NonResidentCommandName.MenuNonResidentItem);
            }

            workItem.Workspaces[WorkspaceName.MainWorkspace].Show(uc);
            uc.Parent.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(uc.rm, MenuNames.MenuNonResidentItem);
        }
        #endregion
    }
}