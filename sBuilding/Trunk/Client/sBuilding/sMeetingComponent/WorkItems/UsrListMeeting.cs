using System;
using System.Collections.Generic;
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
using ReaderManager;
using CardChipService;
using ReaderManager.Pcsc;
using System.Drawing;
using ReaderManager.Model;
using CommonHelper.Config;
using System.Linq;
using sMeetingComponent.Model.CustomObj;
using System.Globalization;
using sMeetingComponent.Model.CustomObj.InfoJournalistObj;
using sMeetingComponent.WorkItems.InvitationHaveBarcode;
using System.Windows.Forms;

namespace sMeetingComponent.WorkItems
{
    public partial class UsrListMeeting : CommonUserControl
    {
        #region Properties
        //fixbug bat tat dau doc the khi mo 3 man hinh kiem soat
        private bool isAdd_ActionDataHandler_For_cardChipManager = false;

        public string sysFormatDate;
        int take = LocalSettings.Instance.RecordsPerPage;

        //phan lien quan den the
        private ReaderFactory factory;
        private IReader readerLib = null;
        private bool processing = false;
        private ICardChipManager cardChipManager;
        //

        // User control này không thuộc nhóm overlay do khi nó hiện ra
        private UsrNotification usrNotification = null;
        private ConfigTime configTime;
        private int time = 0;
        private int previousMinutes = 0;
        //

        public static int status = 0;
        private string barcode = "";
        private string cardchip = "";

        private static int NOT_EXIST_BARCODE = 1;//thư mời không tồn tại trong hệ thống
        private static int UPDATE_BARCODE = 2;//cho vào, hiển thị thông tin
        private static int ALREADY_EXIST_BARCODE = 3;//thẻ đã được dùng // vẫn cho vào tiếp tục
        private static int BARCODE_ENTERPRISE = 4; //barcode cho doanh nghiêp, barcode không qua web sinh ra, mà bên thứ 3 gửi qua

        private DataTable dtbMeetingList;
        private int currentPageIndex = 1;
        private BackgroundWorker loadMeetingObjList;
        private BackgroundWorker bgwCheckInOutUpdateAttendMeeting;
        private BackgroundWorker bgwCheckInOutUpdateAttendMeetingJournalist;
        private List<EventMeeting> meetingObjList;

        //kiểm tra thông tin thẻ
        Journalist journalistByCardChip;
        public bool checkInfoCard = false;

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

        /// <summary>
        /// formatDateTime
        /// format : fr-FR dd//MM/yyyy
        /// </summary>
        /// <returns></returns>
        public static String formatDateTime()
        {
            DateTimeFormatInfo dtfi = CultureInfo.CreateSpecificCulture("fr-FR").DateTimeFormat;
            String dateTimeFormat = dtfi.ShortDatePattern;
            return dateTimeFormat;
        }

        #region Contructors
        /// <summary>
        /// UsrListMeeting
        /// </summary>
        public UsrListMeeting()
        {
            InitializeComponent();
            InitDataTableMeetingList();

            sysFormatDate = UsrListMeeting.formatDateTime();

            RegisterEvent();

            //phan lien quan den the
            RegisterEventCardChip();

            #region usrNotification
            configTime = new ConfigTime();
            time = configTime.SetTime();

            usrNotification = new UsrNotification();
            usrNotification.Anchor = AnchorStyles.None;
            usrNotification.Visible = false;
            panel1.Controls.Add(usrNotification);
            usrNotification.Location = new Point(
                panel1.ClientSize.Width / 2 - usrNotification.Width / 2,
                panel1.ClientSize.Height / 2 - usrNotification.Height / 2);
            usrNotification.BringToFront();

            previousMinutes = configTime.GetPreviousMinutes();
            #endregion

            txtBarCodeFocus();
        }
        #endregion

        /// <summary>
        /// InitDataTableMeetingList
        /// tạo datatable lưu dữ liệu
        /// </summary>
        private void InitDataTableMeetingList()
        {
            dtbMeetingList = new DataTable();
            dtbMeetingList.Columns.Add(colOrderNum.DataPropertyName);
            dtbMeetingList.Columns.Add(colNameMeeting.DataPropertyName);
            dtbMeetingList.Columns.Add(colOrganizationMeeting.DataPropertyName);
            dtbMeetingList.Columns.Add(colDateTime.DataPropertyName);
            dtbMeetingList.Columns.Add(colStartTime.DataPropertyName);
            dtbMeetingList.Columns.Add(colEndTime.DataPropertyName);
            dtbMeetingList.Columns.Add(colRoom.DataPropertyName);
            dtbMeetingList.Columns.Add(colNumberPeopleInvation.DataPropertyName);
            dtbMeetingList.Columns.Add(colDescription.DataPropertyName);
            dtbMeetingList.Columns.Add(colJournalist.DataPropertyName);

            dgvMeetingList.DataSource = dtbMeetingList;
        }

        /// <summary>
        /// RegisterEvent
        /// đăng ký sự kiện
        /// </summary>
        private void RegisterEvent()
        {
            CreateBackgroundWorkerEvent();
            dgvMeetingList.Click += dgvMeetingListClicked;
            pagerPanel1.LinkLabelClicked += pagerPanel_LinkLabelClicked;
            txtBarcode.KeyDown += txtBarcode_KeyDown;
            btnAddMeetingNotCard.Click += btnAddMeetingNotCard_Click;
            btnReloadListMeeting.Click += btnReloadListMeeting_Click;
            Load += OnFormLoad;

            rbtnAutoCheck.Click += rbtnAutoCheck_Click;
            rbtnManualCheck.Click += rbtnManualCheck_Click;
        }

        /// <summary>
        /// RegisterEventCardChip
        /// //đăng ký sự kiện cardchip
        /// </summary>
        private void RegisterEventCardChip()
        {
            factory = ReaderFactory.GetInstance();
            readerLib = new PcscReader();
            cardChipManager = new CardChipManager();
            btnListDevices.Click += OnButtonListDevicesClicked;
            btnPause.Click += OnButtonPauseClicked;
            btnStart.Click += OnButtonStartClicked;
        }
        /// <summary>
        /// OnFormLoad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFormLoad(object sender, EventArgs e)
        {
            DoListDevices();

            txtBarCodeFocus();

            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            pagerPanel1.StorageService = storageService;
            pagerPanel1.LoadLanguage();
            SetLanguages();
            LoadlMeetingObjList();
            txtBarCodeFocus();

        }

        #region Language

        /// <summary>
        /// SetLanguages
        /// </summary>
        private void SetLanguages()
        {
            this.colOrderNum.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOrderNum.Name);
            this.colNameMeeting.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNameMeeting.Name);
            this.colOrganizationMeeting.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colOrganizationMeeting.Name);
            this.colDateTime.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colDateTime.Name);
            this.colStartTime.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colStartTime.Name);
            this.colEndTime.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colEndTime.Name);
            this.colRoom.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colRoom.Name);
            this.colNumberPeopleInvation.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colNumberPeopleInvation.Name);
            this.colDescription.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colDescription.Name);
            this.colJournalist.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.colJournalist.Name);

            rbtnAutoCheck.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, rbtnAutoCheck.Name);
            rbtnManualCheck.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, rbtnManualCheck.Name);
        }
        #endregion

        #region Xác định trạng thái thao tác như thế nào để hiển thị thông bao phu hợp
        /// <summary>
        /// Set Value to show Status suitable
        /// set lại giá trị để hiển thị thông báo phù hợp
        /// </summary>
        /// <param name="statusId"></param>
        public static void SetIndexStatus(int statusId)
        {
            status = statusId;
        }

        /// <summary>
        /// SHow message based on value index
        /// dự vào SetIndexStatus để kiểm tra và hiển thị thông báo
        /// </summary>
        public void ShowStatus()
        {
            if (status == 1)
            {
                Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Succeed, MessageValidate.GetMessage(rm, "SmsSuccessDoor"))));
                status = 0;
                //thư mời
                //   Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Succeed, MessageValidate.GetMessage(rm, "smsSuccessPersonal"))));
                //thẻ
                //   Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Succeed, MessageValidate.GetMessage(rm, "SmsSuccessMeetingCard"))));
            }
            else if (status == 2)
            {
                Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "smsErrorDoor"))));
                status = 0;
                //thư mời
                //  Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "smsErrorInsertPersonal"))));
                //thẻ
                //  MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "smsErrorInsertMeetingCard"));
            }
        }
        #endregion

        #region bgWorker
        /// <summary>
        /// CreateBackgroundWorkerEvent
        /// </summary>
        private void CreateBackgroundWorkerEvent()
        {
            //1. lấy danh sách cuộc họp trong ngày hôm nay
            loadMeetingObjList = new BackgroundWorker();
            loadMeetingObjList.WorkerSupportsCancellation = true;
            loadMeetingObjList.DoWork += OnLoadMeetingObjWorkerDoWork;
            loadMeetingObjList.RunWorkerCompleted += OnLoadMeetingObjWorkerCompleted;

            //2. kiểm tra xem thư mời họp này có thông tin không
            bgwCheckInOutUpdateAttendMeeting = new BackgroundWorker();
            bgwCheckInOutUpdateAttendMeeting.WorkerSupportsCancellation = true;
            bgwCheckInOutUpdateAttendMeeting.DoWork += CheckInOutUpdateAttendMeetingWorkerDoWork;
            bgwCheckInOutUpdateAttendMeeting.RunWorkerCompleted += CheckInOutUpdateAttendMeetingWorkerCompleted;

            //3. kiểm tra xem thẻ CBCC quét vào hôm nay có tham dự cuộc họp nào không (cập nhật thời gian) , (xem thông tin thẻ)
            bgwCheckInOutUpdateAttendMeetingJournalist = new BackgroundWorker();
            bgwCheckInOutUpdateAttendMeetingJournalist.WorkerSupportsCancellation = true;
            bgwCheckInOutUpdateAttendMeetingJournalist.DoWork += CheckInOutUpdateAttendMeetingJournalistWorkerDoWork;
            bgwCheckInOutUpdateAttendMeetingJournalist.RunWorkerCompleted += CheckInOutUpdateAttendMeetingJournalistRunWorkerCompleted;
        }

        /// <summary>
        /// LoadlMeetingObjList
        /// </summary>
        private void LoadlMeetingObjList()
        {
            if (!loadMeetingObjList.IsBusy)
            {
                dtbMeetingList.Rows.Clear();
                pagerPanel1.ShowMessage(MessageValidate.GetMessage(rm, "lblIsLoading"));
                loadMeetingObjList.RunWorkerAsync();
            }
        }

        /// <summary>
        /// CheckInOutUpdateAttendMeeting
        /// </summary>
        private void CheckInOutUpdateAttendMeeting()
        {
            if (!bgwCheckInOutUpdateAttendMeeting.IsBusy)
            {
                bgwCheckInOutUpdateAttendMeeting.RunWorkerAsync();
            }
        }

        /// <summary>
        /// CheckInOutUpdateAttendMeetingJournalist
        /// </summary>
        private void CheckInOutUpdateAttendMeetingJournalist()
        {
            if (!bgwCheckInOutUpdateAttendMeetingJournalist.IsBusy)
            {
                bgwCheckInOutUpdateAttendMeetingJournalist.RunWorkerAsync();
            }
        }

        #region Gửi yêu cầu lấy thông tin cuộc họp trong ngày
        /// <summary>
        /// OnLoadMeetingObjWorkerDoWork
        /// lấy thông tin các cuộc họp diễn ra hôm nay
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadMeetingObjWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            //ngay hien tai
            DateTime dateTime = DateTime.UtcNow.Date;
            String dateStr = dateTime.ToString("yyyy-MM-dd");
            int totalRecords = 0;
            int skip = 0;
            currentPageIndex = 1;
            List<EventMeeting> result = new List<EventMeeting>();
            try
            {
                e.Result = meetingObjList = MeetingEventFactory.Instance.GetChannel().getEventMeetingListByDate(StorageService.CurrentSessionId, dateStr);
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
                if (meetingObjList != null)
                {
                    //lấy các cuộc họp không có cuộc họp nội bộ
                    //List<EventMeeting> tempListMeeting = new List<EventMeeting>();
                    //tempListMeeting = meetingObjList;
                    //meetingObjList = GetListNotNonresident(tempListMeeting);

                    meetingObjList = GetListNotNonresident(meetingObjList);

                    result = meetingObjList.Skip(skip).Take(take).ToList();
                    //end

                    totalRecords = meetingObjList.Count;
                    //phân trang
                    pagerPanel1.ShowNumberOfRecords(totalRecords, result != null ? result.Count : 0, take, currentPageIndex);
                    pagerPanel1.UpdatePagingLinks(totalRecords, take, currentPageIndex);
                }
                e.Result = result;
            }
        }

        /// <summary>
        /// Get List Meeting have invation (barecode, card)
        /// không phải cuộc họp nội bộ 
        /// </summary>
        /// <param name="listMeetingAll"></param>
        /// <returns></returns>
        public static List<EventMeeting> GetListNotNonresident(List<EventMeeting> listMeetingAll)
        {
            List<EventMeeting> listMeetingNotNonresident = new List<EventMeeting>();
            for (int i = 0; i < listMeetingAll.Count; i++)
            {
                if (!listMeetingAll[i].nonresident)
                {
                    listMeetingNotNonresident.Add(listMeetingAll[i]);
                }
            }
            return listMeetingNotNonresident;
        }

        /// <summary>
        /// Change statusbar : message not data
        /// nếu không có dữ liệu dgv thì hiển thị thông báo này
        /// </summary>
        private void UploadStatusBar()
        {
            pagerPanel1.ShowMessage(MessageValidate.GetMessage(rm, "lblMessageNotDataToDay"));
        }

        /// <summary>
        /// OnLoadMeetingObjWorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadMeetingObjWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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
                List<EventMeeting> result = (List<EventMeeting>)e.Result;
                if (result.Count != 0)
                {
                    LoadMeetingObjListdata(result);
                }
                else
                {
                    UploadStatusBar();
                }
            }
        }
        #endregion

        #region Kiểm tra barcode nhập vào tình trạng như thế nào
        /// <summary>
        /// CheckInOutUpdateAttendMeetingWorkerDoWork
        /// gọi hàm kiểm tra xem thư mời họp dự vào barcode : trạng thái như thế nào để thực hiện việc cho vào hoặc thông báo lỗi phù hợp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckInOutUpdateAttendMeetingWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = AttendMeetingFactory.Instance.GetChannel().checkInOutEventAttendMeeting(StorageService.CurrentSessionId, barcode);
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
        /// CheckInOutUpdateAttendMeetingWorkerCompleted
        ///   dự vào hàm lấy thông tin trạng thái của thư mời họp để thông báo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckInOutUpdateAttendMeetingWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "SmsNotConnectData"))));
                txtBarCodeFocus();
                return;
            }
            if (e.Result == null)
            {
                Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "SmsNotInforMeetingRetry"))));
                txtBarCodeFocus();
                return;
            }
            else
            {
                NumberObj numberObj = (NumberObj)e.Result;
                int checkBarcode = numberObj.value;

                //if (checkBarcode == UPDATE_BARCODE)
                //{
                //    Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Succeed, MessageValidate.GetMessage(rm, "SmsSuccess"))));
                //    PostAction = DialogPostAction.SUCCESS;
                //    txtBarCodeFocus();
                //    return;
                //}
                //else
                if (checkBarcode == UPDATE_BARCODE || checkBarcode == ALREADY_EXIST_BARCODE)
                {
                    readerLib.Disconnect(null);
                    FrmDetailInforBarcode frmDetailInfor = null;
                    if (rbtnAutoCheck.Checked) {
                        frmDetailInfor = new FrmDetailInforBarcode(FrmDetailInforBarcode.ModeBarcode, this.barcode, true);
                    } else {
                        frmDetailInfor = new FrmDetailInforBarcode(FrmDetailInforBarcode.ModeBarcode, this.barcode, false);
                    }
                    
                    workItem.SmartParts.Add(frmDetailInfor);
                    frmDetailInfor.ShowDialog();
                    workItem.SmartParts.Remove(frmDetailInfor);
                    frmDetailInfor.Hide();
                    // txtBarCodeFocus();
                    ShowStatus();
                    //030517
                    this.txtBarcode.Text = "";
                    this.txtBarcode.Text = string.Empty;
                    this.txtBarcode.Focus();
                    this.txtBarcode.Select();
                    txtBarCodeFocus();//030517
                                      //end 030517

                    //StartReader();
                }
                //barcode cho doanh nghiệp
                else if (checkBarcode == BARCODE_ENTERPRISE)
                {
                    readerLib.Disconnect(null);
                    FrmDetailInforBarcodeEnterprise frmDetailInfor = new FrmDetailInforBarcodeEnterprise(FrmDetailInforBarcodeEnterprise.ModeBarcode, this.barcode);
                    workItem.SmartParts.Add(frmDetailInfor);
                    frmDetailInfor.ShowDialog();
                    workItem.SmartParts.Remove(frmDetailInfor);
                    frmDetailInfor.Hide();
                    //  txtBarCodeFocus();
                    ShowStatus();
                    //030517
                    this.txtBarcode.Text = "";
                    this.txtBarcode.Text = string.Empty;
                    txtBarCodeFocus();//030517
                                      //end 030517
                }
                else if (checkBarcode == NOT_EXIST_BARCODE)
                {
                    Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "SmsNotHaveInvation"))));
                    //txtBarCodeFocus();
                    //030517
                    this.txtBarcode.Text = "";
                    this.txtBarcode.Text = string.Empty;
                    txtBarCodeFocus();//030517
                                      //end 030517
                    return;
                }
                //else if (checkBarcode == ALREADY_EXIST_BARCODE)
                //{
                //    Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "SmsInvationIsUsed"))));
                //    txtBarCodeFocus();
                //    return;
                //}
                else
                {
                    Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "SmsNotInforMeetingRetry"))));
                    txtBarCodeFocus();
                    return;
                }
            }
        }
        #endregion

        #region Kiểm tra thông tin thẻ nhập vào : serialnumber
        /// <summary>
        /// CheckInOutUpdateAttendMeetingJournalistWorkerDoWork
        /// kiểm tra xem  thẻ quét vào hôm nay có tham dự cuộc họp nào không
        /// gửi SERIALNUMBER và DATETIME: yyyy-MM-dd
        /// nếu có thì cập nhật thời gian ra
        /// nếu không thì hiển thị thông tin của thẻ và các cuộc họp hôm nay có thể tham dự
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckInOutUpdateAttendMeetingJournalistWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            String dateStr = dateTime.ToString("yyyy-MM-dd HH:mm");
            try
            {
                e.Result = JournalistFactory.Instance.GetChannel().checkInOutUpdateAttendMeetingJournalist(storageService.CurrentSessionId, cardchip, dateStr);
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
        /// CheckInOutUpdateAttendMeetingJournalistRunWorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckInOutUpdateAttendMeetingJournalistRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "SmsErrorUpdateTimeRetry"))));
                //030517
                this.txtBarcode.Text = "";
                this.txtBarcode.Text = string.Empty;
                txtBarCodeFocus();//030517
                //end 030517
                return;
            }
            //20170304 #Bug Fix- My Nguyen Start
            if (e.Result == null)
            {
                Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "SmsErrorUpdateTimeRetry"))));
                //030517
                this.txtBarcode.Text = "";
                this.txtBarcode.Text = string.Empty;
                txtBarCodeFocus();//030517
                //end 030517
            }
            else
            {
                NumberObj numberObj = (NumberObj)e.Result;
                //20170304 #Bug Fix- My Nguyen End
                int checkUpdateCardchip = numberObj.value;
                if (checkUpdateCardchip == 2)
                {
                    cardchip = "";
                    SwitchProcessingState();
                    Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Succeed, MessageValidate.GetMessage(rm, "SmsSuccess"))));
                    //PostAction = DialogPostAction.SUCCESS;
                    // this.txtBarcode.Text = "";

                    // this.txtBarcode.Text = string.Empty;

                    //030517
                    this.txtBarcode.Text = "";
                    this.txtBarcode.Text = string.Empty;
                    txtBarCodeFocus();
                    //end 030517
                    return;
                }
                else if (checkUpdateCardchip == 1)
                {
                    FrmDetailBySerialNumberInfo frmDetailInforByCardChip = new FrmDetailBySerialNumberInfo(FrmDetailBySerialNumberInfo.ModeCardChip, cardchip, false);
                    workItem.SmartParts.Add(frmDetailInforByCardChip);
                    frmDetailInforByCardChip.ShowDialog();
                    frmDetailInforByCardChip.Activate();
                    cardchip = "";
                    workItem.SmartParts.Remove(frmDetailInforByCardChip);
                    frmDetailInforByCardChip.Hide();
                    ShowStatus();
                    SwitchProcessingState();
                    //030517
                    this.txtBarcode.Text = "";
                    this.txtBarcode.Text = string.Empty;
                    txtBarCodeFocus();//030517
                                      //end 030517
                    checkInfoCard = false;
                    return;
                }
                else
                {
                    Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "SmsErrorUpdateTimeRetry"))));
                    //030517
                    this.txtBarcode.Text = "";
                    this.txtBarcode.Text = string.Empty;
                    txtBarCodeFocus();//030517
                                      //end 030517
                }
            }
        }
        #endregion

        #endregion

        #region Hiển thị hông tin các cuộc họp trong ngày
        /// <summary>
        /// LoadMeetingObjListdata
        /// show meeting list
        /// </summary>
        /// <param name="eMeeting"></param>
        private void LoadMeetingObjListdata(List<EventMeeting> eMeeting)
        {
            dtbMeetingList.Clear();

            int index = 0;
            for (int i = 0; i < eMeeting.Count; i++)
            {
                DataRow row = dtbMeetingList.NewRow();
                row.BeginEdit();
                DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                if (eMeeting[i].startTime != null && eMeeting[i].startTime != "")
                {
                    DateTime startDate = start.AddMilliseconds(Convert.ToUInt64(eMeeting[i].startTime)).ToLocalTime();

                    row[colDateTime.DataPropertyName] = startDate.ToString(sysFormatDate);
                    row[colStartTime.DataPropertyName] = startDate.ToString("HH:mm");
                }
                if (eMeeting[i].endTime != null && eMeeting[i].endTime != "")
                {
                    DateTime endDate = start.AddMilliseconds(Convert.ToUInt64(eMeeting[i].endTime)).ToLocalTime();
                    row[colEndTime.DataPropertyName] = endDate.ToString("HH:mm");
                }
                index = i + 1;
                row[colOrderNum.DataPropertyName] = index;

                row[colNameMeeting.DataPropertyName] = eMeeting[i].name;
                row[colOrganizationMeeting.DataPropertyName] = eMeeting[i].organizationMeetingName;

                row[colRoom.DataPropertyName] = eMeeting[i].roomName;
                row[colNumberPeopleInvation.DataPropertyName] = eMeeting[i].number;
                row[colDescription.DataPropertyName] = eMeeting[i].description;
                row[colJournalist.DataPropertyName] = eMeeting[i].journalist;

                row.EndEdit();
                dtbMeetingList.Rows.Add(row);
            }

            if (dgvMeetingList.Rows.Count > 0)
            {
                //focur the first row in table
                dgvMeetingList.Rows[0].Selected = true;
                //dgvMeetingList.ClearSelection();
            }
            else
            {
                UploadStatusBar();
            }
        }
        #endregion

        #region CAB events
        [CommandHandler(MeetingCommandName.ShowMeeting)]
        public void ShowMeetingMainHandler(object s, EventArgs e)
        {
            UsrListMeeting uc = workItem.Items.Get<UsrListMeeting>(MeetingCommandName.MenuMeetingItem);
            if (uc == null)
            {
                uc = workItem.Items.AddNew<UsrListMeeting>(MeetingCommandName.MenuMeetingItem);
            }
            else if (uc.IsDisposed)
            {
                workItem.Items.Remove(uc);
                uc = workItem.Items.AddNew<UsrListMeeting>(MeetingCommandName.MenuMeetingItem);
            }

            workItem.Workspaces[WorkspaceName.MainWorkspace].Show(uc);
            uc.Parent.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(uc.rm, MenuNames.MenuMeetingItem);
        }
        #endregion

        #region Event's Button
        /// <summary>
        /// btnReloadListMeeting_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReloadListMeeting_Click(object sender, EventArgs e)
        {
            LoadlMeetingObjList();
            txtBarCodeFocus();
        }

        public void AutoRefreshWhenChangeTab() {
            LoadlMeetingObjList();
            txtBarCodeFocus();
        }

        /// <summary>
        /// click btn register
        /// btnAddMeetingNotCard_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddMeetingNotCard_Click(object sender, EventArgs e)
        {
            RegisterForPersonNotHaveInvation();
        }

        /// <summary>
        /// RegisterForPersonNotHaveInvation
        /// </summary>
        public void RegisterForPersonNotHaveInvation()
        {
            //v3 cho người dùng đăng ký khi không có thông tin gì
            FrmDetailEmptyInfor frmDetailInforByCardChip = new FrmDetailEmptyInfor(FrmDetailEmptyInfor.ModeAddInfomation, cardchip);
            workItem.SmartParts.Add(frmDetailInforByCardChip);
            frmDetailInforByCardChip.ShowDialog();
            cardchip = "";
            workItem.SmartParts.Remove(frmDetailInforByCardChip);
            frmDetailInforByCardChip.Hide();
            ShowStatus();
            this.txtBarcode.Text = "";
            this.txtBarcode.Text = string.Empty;
            txtBarCodeFocus();


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
            dtbMeetingList.Rows.Clear();
            int skip = (currentPageIndex - 1) * take;
            //20170304 #Bug Fix content A - My Nguyen Start
            List<EventMeeting> result = meetingObjList.Skip(skip).Take(take).ToList();
            if (result != null)
            {
                if (result.Count != 0)
                {
                    LoadMeetingObjListdata(result);
                    pagerPanel1.ShowNumberOfRecords(meetingObjList.Count, result != null ? result.Count : 0, take, currentPageIndex);
                    pagerPanel1.UpdatePagingLinks(meetingObjList.Count, take, currentPageIndex);
                }
                else
                {
                    UploadStatusBar();
                }
            }
            else
            {
                UploadStatusBar();
            }
            txtBarCodeFocus();
            //20170304 #Bug Fix content A - My Nguyen End
        }

        /// <summary>
        /// click dgv
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvMeetingListClicked(object sender, EventArgs e)
        {
            txtBarCodeFocus();
        }

        /// <summary>
        /// always focus txtbarcode
        /// </summary>
        private void txtBarCodeFocus()
        {
            this.txtBarcode.Text = "";
            this.txtBarcode.Text = string.Empty;
            txtBarcode.Select();
        }

        /// <summary>
        /// register key f11, key up, key down
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (msg.WParam.ToInt32() == (int)Keys.F10)
            {//TRƯỜNG HỌP NÀY LỖI KHÔNG BIẾT ??
                txtBarCodeFocus(); return true;
            }

            //chưa xử lí được nút ALT
            //if (msg.WParam.ToInt32() == (int)Keys.Alt)
            //{//TRƯỜNG HỌP NÀY LỖI KHÔNG BIẾT ??
            //    txtBarCodeFocus(); return true;
            //}

            if (msg.WParam.ToInt32() == (int)Keys.F11)
            {
                RegisterForPersonNotHaveInvation();
                return true;
            }
            if (msg.WParam.ToInt32() == (int)Keys.Up)
            {
                moveUp(dgvMeetingList);
                txtBarCodeFocus();
                return true;
            }
            if (msg.WParam.ToInt32() == (int)Keys.Down)
            {
                moveDown(dgvMeetingList);
                txtBarCodeFocus();
                return true;

            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
            //            return false;
        }

        #region  not use Sự kiện KeyUp, KeyDown
        public static void moveUp(CommonDataGridView dgvMeetingList)
        {
            if (dgvMeetingList.RowCount > 0)
            {
                if (dgvMeetingList.SelectedRows.Count > 0)
                {
                    int rowCount = dgvMeetingList.Rows.Count;
                    int index = dgvMeetingList.SelectedCells[0].OwningRow.Index;

                    if (index == 0)
                    {
                        return;
                    }
                    dgvMeetingList.ClearSelection();
                    dgvMeetingList.Rows[index - 1].Selected = true;
                }
            }
        }
        public static void moveDown(CommonDataGridView dgvMeetingList)
        {
            if (dgvMeetingList.RowCount > 0)
            {
                if (dgvMeetingList.SelectedRows.Count > 0)
                {
                    int rowCount = dgvMeetingList.Rows.Count;
                    int index = dgvMeetingList.SelectedCells[0].OwningRow.Index;

                    if (index == (rowCount - 1)) // include the header row
                    {
                        return;
                    }
                    dgvMeetingList.ClearSelection();
                    dgvMeetingList.Rows[index + 1].Selected = true;
                }
            }
        }
        #endregion
        /// <summary>
        /// key down : txtbarcode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtBarcode.Text != "")
                {
                    this.barcode = txtBarcode.Text;
                    CheckInOutUpdateAttendMeeting();
                }
            }
        }

        private void rbtnAutoCheck_Click(object sender, EventArgs e) {
            txtBarCodeFocus();
        }

        private void rbtnManualCheck_Click(object sender, EventArgs e) {
            txtBarCodeFocus();
        }
        #endregion

        #region Event's CardChip

        public void StartReader()
        {
            if (cmbReaders.SelectedIndex == -1)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessSelect(rm, MessageValidate.Reader), MessageValidate.GetErrorTitle(rm));
                txtBarCodeFocus();
                return;
            }
            String selectedReader = cmbReaders.SelectedItem.ToString();
            if (String.Empty != selectedReader)
            {

                if (cardChipManager.WaitingCard(selectedReader))
                {
                    ChangeStatusMessage(MessageValidate.GetMessage(rm, "WaitingTag"));
                    SwitchRunningState(true);
                    if (!isAdd_ActionDataHandler_For_cardChipManager)
                    {
                        cardChipManager.ActionDataHandler += ActionData;
                        isAdd_ActionDataHandler_For_cardChipManager = true;
                    }
                }
            }
            else
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessSelect(rm, MessageValidate.Reader), MessageValidate.GetErrorTitle(rm));
                txtBarCodeFocus();
            }
        }

        private void OnButtonStartClicked(object sender, EventArgs e)
        {
            txtBarCodeFocus();

            StartReader();
        }

        private void ActionData(DataCardObject obj)
        {
            switch (obj.eventType)
            {
                case DataCardObject.TAG_DETECTED:
                    OnTagDetected(obj.cardType, obj.serialNumber);
                    break;
            }
        }

        private void OnButtonPauseClicked(object sender, EventArgs e)
        {
            PauseReader();
        }

        public void PauseReader()
        {
            if (null != readerLib)
            {
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

        private void OnButtonListDevicesClicked(object sender, EventArgs e)
        {
            DoListDevices();
            txtBarCodeFocus();
        }

        private void DoListDevices()
        {
            cmbReaders.DataSource = null;

            // find all card reader
            List<String> listReaders = factory.FindAllCardReader();
            if (listReaders != null && listReaders.Count > 0)
            {
                cmbReaders.DataSource = listReaders;
                cmbReaders.SelectedIndex = 0;
                // cardReaderId = (String)cmbReaders.SelectedValue;
            }
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBoxManager.ShowQuestionMessageBox(this, MessageValidate.GetMessStop(rm, MessageValidate.ReadData), MessageValidate.GetErrorTitle(rm)) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
            else
            {
                if (null != readerLib)
                {
                    readerLib.Disconnect(null);
                }
                //if (dataDialog != null && !dataDialog.IsDisposed)
                //{
                //    dataDialog.Dispose();
                //}
            }
        }

        private void ChangeStatusMessage(string msg)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(ChangeStatusMessage), msg);
                return;
            }
            lblStatus.Text = msg;
        }

        private void SwitchRunningState(bool running)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<bool>(SwitchRunningState), running);
                return;
            }
            cmbReaders.Enabled = btnStart.Enabled = btnListDevices.Enabled = !running;
            btnPause.Enabled = running;
        }

        private void SwitchProcessingState()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(SwitchProcessingState));
                return;
            }
            if (processing)
            {
                lblStatus.BackColor = this.BackColor;
                lblStatus.ForeColor = this.ForeColor;
                lblStatus.Text = MessageValidate.GetMessage(rm, "WaitingCard");
                processing = false;
            }
            else
            {
                processing = true;
                lblStatus.BackColor = SystemColors.Highlight;
                lblStatus.ForeColor = SystemColors.HighlightText;
                lblStatus.Text = MessageValidate.GetMessage(rm, "PerformActionOnCard");
                //     ReaderNotConnected
                //     Chưa kết nối với thiết bị đọc
            }
        }
        #endregion

        #region Reader library events CARDCHIP
        /// <summary>
        /// OnTagDetected
        /// step1.Check info card
        /// step2.CheckIn_For_sParking(cardType, serialNumber)
        /// -show message
        /// -CheckInOutUpdateAttendMeetingJournalist
        /// </summary>
        /// <param name="cardType"></param>
        /// <param name="serialNumber"></param>
        private void OnTagDetected(int cardType, byte[] serialNumber)
        {
            if (!processing)
            {
                SwitchProcessingState();
                string msg = string.Empty;

                // Chuyển cardId từ mảng byte sang kiểu uint
                string cardIdUint = StringUtils.ByteArrayToHexString(serialNumber);
                cardchip = cardIdUint;
                if (!"".Equals(cardIdUint))
                {
                    //lúc nào cũng ghi nhận vào văn phòng làm việc
                    CheckIn_For_sParking(cardType, serialNumber);

                    //xem thẻ đó có phải là thẻ trắng hay không
                    LoadMeetingJournalistObjForCheck();

                    //nếu là thẻ trắng thì hiển thị thông báo
                    if (checkInfoCard)
                    {
                        // thành công
                        Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Succeed, MessageValidate.GetMessage(rm, "SmsRecordWorking"))));

                        cardchip = "";
                        ShowStatus();
                        SwitchProcessingState();
                        this.txtBarcode.Text = "";
                        this.txtBarcode.Text = string.Empty;
                        checkInfoCard = false;
                    }

                    //nếu không thì tiếp tục kiểm tra xem có tham dự họp hay không
                    else
                    {
                        CheckInOutUpdateAttendMeetingJournalist();
                    }
                }
                else
                {
                    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "smsCardNotInfo"));
                    txtBarCodeFocus();
                }
            }
        }


        #endregion

        #region Function check in for sparking

        private void CheckIn_For_sParking(int cardType, byte[] serialNumber)
        {
            cardChipManager.SetFreesParking();
            //return true;
        }

        #endregion

        #region Kiểm tra thông tin thẻ để xác định loại thẻ là gì (thẻ trắng / thẻ có thông tin)
        /// <summary>
        /// LoadListMeetingJournalistObjCheck
        /// </summary>
        private void LoadMeetingJournalistObjForCheck()
        {
            try
            {
                journalistByCardChip = JournalistFactory.Instance.GetChannel().getJournalistByCardChip(storageService.CurrentSessionId, cardchip);
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
                //Journalist result = journalistByCardChip;
                if (journalistByCardChip != null)
                {
                    String name = journalistByCardChip.LowerFullName;
                    if (name == null || "".Equals(name))
                    {
                        checkInfoCard = true;
                    }
                    else
                    {
                        checkInfoCard = false;
                    }
                }
                else
                {
                    // 2017-05-08 Bug: vu.pham -- Start
                    // If there is no member => server return null 
                    // checkInfoCard = false;
                    checkInfoCard = true;
                    // 2017-05-08 Bug: vu.pham -- End
                }

            }
        }
        #endregion

        #region Bắt sự kiện focus vào txtbarcode

        /// <summary>
        /// click dgv
        /// luôn bắt sự kiện bắt ở nút txtbarcode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvMeetingList_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtBarCodeFocus();
        }
        private void cmbReaders_MouseHover(object sender, EventArgs e)
        {
            txtBarCodeFocus();
        }
        private void cmbReaders_SelectedValueChanged(object sender, EventArgs e)
        {
            txtBarCodeFocus();
        }
        private void cmbReaders_Leave(object sender, EventArgs e)
        {
            txtBarCodeFocus();
        }
        private void cmbReaders_MouseLeave(object sender, EventArgs e)
        {
            txtBarCodeFocus();
        }

        #endregion

    }
}
