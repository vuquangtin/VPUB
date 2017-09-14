using CameraComponent;
using CameraComponent.Model;
using CameraComponent.View;
using CommonControls;
using CommonControls.Custom;
using CommonHelper.Constants;
using CommonHelper.Utils;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.Commands;
using sTimeKeeping.Constants;
using sTimeKeeping.Factory;
using sTimeKeeping.Model;
using sWorldModel;
using sWorldModel.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Resources;
using System.ServiceModel;
using System.Threading;
using System.Windows.Forms;

namespace sTimeKeeping.WorkItems {
    public partial class UsrTimeKeepingWithoutCard : CommonUserControl {
        #region Properties
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        // List Member
        List<ChipPersonalizationCustom> listChipPers;
        List<MemberCustom> listMember;
        MemberCustom memberCustomObj;
        List<string> listMemberCode; // danh sách mã thành viên
        List<string> listMemberIDCardNo; // danh sách cmnd thành viên
        long memberId;
        string serialNumber;

        // Keyboard
        bool isKeyboardShow = false;

        // Camera
        private IVideoSource vdFace = null;

        private BackgroundWorker bgwGetListChipPers, bgwGetListMember;

        private ResourceManager rm;
        private TimeKeepingComponentWorkItem workItem;
        [ServiceDependency]
        public TimeKeepingComponentWorkItem WorkItem {
            set { workItem = value; }
        }

        private ILocalStorageService storageService;
        public ILocalStorageService StorageService {
            get {
                if (storageService == null) {
                    storageService = workItem.Services.Get<ILocalStorageService>();
                }
                return storageService;
            }
        }
        #endregion

        #region Contructors
        protected override CreateParams CreateParams {
            get {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= 0x08000000;
                return createParams;
            }
        }

        public UsrTimeKeepingWithoutCard() {
            InitializeComponent();
            registerEvent();
        }

        private void registerEvent() {
            #region Keyboard
            btnQ.Click += btnQ_Click;
            btnW.Click += btnW_Click;
            btnE.Click += btnE_Click;
            btnR.Click += btnR_Click;
            btnT.Click += btnT_Click;
            btnY.Click += btnY_Click;
            btnU.Click += btnU_Click;
            btnI.Click += btnI_Click;
            btnO.Click += btnO_Click;
            btnP.Click += btnP_Click;
            btnA.Click += btnA_Click;
            btnS.Click += btnS_Click;
            btnD.Click += btnD_Click;
            btnF.Click += btnF_Click;
            btnG.Click += btnG_Click;
            btnH.Click += btnH_Click;
            btnJ.Click += btnJ_Click;
            btnK.Click += btnK_Click;
            btnL.Click += btnL_Click;
            btnZ.Click += btnZ_Click;
            btnX.Click += btnX_Click;
            btnC.Click += btnC_Click;
            btnV.Click += btnV_Click;
            btnB.Click += btnB_Click;
            btnN.Click += btnN_Click;
            btnM.Click += btnM_Click;
            btnDel.Click += btnDel_Click;
            btnDelAll.Click += btnDelAll_Click;
            btnUnderscore.Click += btnUnderscore_Click;
            btnSpace.Click += btnSpace_Click;
            btnHyphen.Click += btnHyphen_Click;
            btn1.Click += btn1_Click;
            btn2.Click += btn2_Click;
            btn3.Click += btn3_Click;
            btn4.Click += btn4_Click;
            btn5.Click += btn5_Click;
            btn6.Click += btn6_Click;
            btn7.Click += btn7_Click;
            btn8.Click += btn8_Click;
            btn9.Click += btn9_Click;
            btn0.Click += btn0_Click;
            btnDecimal.Click += btnDecimal_Click;
            #endregion

            // Backgroundworker Get List Chip Personalization
            bgwGetListChipPers = new BackgroundWorker();
            bgwGetListChipPers.WorkerSupportsCancellation = true;
            bgwGetListChipPers.DoWork += bgwGetListChipPers_DoWork;
            bgwGetListChipPers.RunWorkerCompleted += bgwGetListChipPers_RunWorkerCompleted;

            // Backgroundworker Get List Member
            bgwGetListMember = new BackgroundWorker();
            bgwGetListMember.WorkerSupportsCancellation = true;
            bgwGetListMember.DoWork += bgwGetListMember_DoWork;
            bgwGetListMember.RunWorkerCompleted += bgwGetListMember_RunWorkerCompleted;

            // TextBox Member code
            tbxMemberCode.TextChanged += tbxMemberCode_TextChanged;
            tbxMemberCode.KeyDown += tbxMemberCode_KeyDown;

            // Camera
            uccFace.StartRequested += uccFace_StartRequested;
            uccFace.StopRequested += uccFace_StopRequested;

            // Button
            btnTimeKeeping.Click += btnTimeKeeping_Click;
            btnShowHideKeyboard.Click += btnShowHideKeyboard_Click;
            btnRefreshData.Click += btnRefreshData_Click;

            // Timer
            timer.Tick += new EventHandler(timer_Tick);

            // Set max length
            tbxMemberCode.MaxLength = ConstantsValue.MAX_LENGTH_TEXT_BOX_VAR_CHAR;
        }

        protected override void OnLoad(EventArgs e) {
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);

            // Set Language cho Form
            setLanguage();

            // Get List Chip Personalization and List Member from database
            getListChipPers();
            getListMember();

            // Load Camera
            PlayVideoSourceOnUCC(uccFace);
        }
        #endregion

        #region Set Language
        private void setLanguage() {
            btnRefreshData.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, btnRefreshData.Name);
            btnRefreshData.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, btnRefreshData.Name);
            btnShowHideKeyboard.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, btnShowHideKeyboard.Name);
            btnShowHideKeyboard.ToolTipText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, btnShowHideKeyboard.Name);
            btnTimeKeeping.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, btnTimeKeeping.Name);
            lblHeaderDepartment.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblHeaderDepartment.Name);
            lblHeaderFullName.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblHeaderFullName.Name);
            lblHeaderMemberCode.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblHeaderMemberCode.Name);
            lblHeaderPosition.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblHeaderPosition.Name);
            lblInputMemberCode.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblInputMemberCode.Name);
            lblTitleTKWithoutCard.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblTitleTKWithoutCard.Name);
        }
        #endregion

        #region Button's Events
        #region Keyboard
        private void btnQ_Click(object sender, EventArgs e) {
            buttonPress(btnQ.Text);
        }
        private void btnW_Click(object sender, EventArgs e) {
            buttonPress(btnW.Text);
        }

        private void btnE_Click(object sender, EventArgs e) {
            buttonPress(btnE.Text);
        }

        private void btnR_Click(object sender, EventArgs e) {
            buttonPress(btnR.Text);
        }

        private void btnT_Click(object sender, EventArgs e) {
            buttonPress(btnT.Text);
        }

        private void btnY_Click(object sender, EventArgs e) {
            buttonPress(btnY.Text);
        }

        private void btnU_Click(object sender, EventArgs e) {
            buttonPress(btnU.Text);
        }

        private void btnI_Click(object sender, EventArgs e) {
            buttonPress(btnI.Text);
        }

        private void btnO_Click(object sender, EventArgs e) {
            buttonPress(btnO.Text);
        }

        private void btnP_Click(object sender, EventArgs e) {
            buttonPress(btnP.Text);
        }

        private void btnA_Click(object sender, EventArgs e) {
            buttonPress(btnA.Text);
        }

        private void btnS_Click(object sender, EventArgs e) {
            buttonPress(btnS.Text);
        }

        private void btnD_Click(object sender, EventArgs e) {
            buttonPress(btnD.Text);
        }

        private void btnF_Click(object sender, EventArgs e) {
            buttonPress(btnF.Text);
        }

        private void btnG_Click(object sender, EventArgs e) {
            buttonPress(btnG.Text);
        }

        private void btnH_Click(object sender, EventArgs e) {
            buttonPress(btnH.Text);
        }

        private void btnJ_Click(object sender, EventArgs e) {
            buttonPress(btnJ.Text);
        }

        private void btnK_Click(object sender, EventArgs e) {
            buttonPress(btnK.Text);
        }

        private void btnL_Click(object sender, EventArgs e) {
            buttonPress(btnL.Text);
        }

        private void btnZ_Click(object sender, EventArgs e) {
            buttonPress(btnZ.Text);
        }

        private void btnX_Click(object sender, EventArgs e) {
            buttonPress(btnX.Text);
        }

        private void btnC_Click(object sender, EventArgs e) {
            buttonPress(btnC.Text);
        }

        private void btnV_Click(object sender, EventArgs e) {
            buttonPress(btnV.Text);
        }

        private void btnB_Click(object sender, EventArgs e) {
            buttonPress(btnB.Text);
        }

        private void btnN_Click(object sender, EventArgs e) {
            buttonPress(btnN.Text);
        }

        private void btnM_Click(object sender, EventArgs e) {
            buttonPress(btnM.Text);
        }

        private void btnDel_Click(object sender, EventArgs e) {
            buttonPress("{BACKSPACE}");
        }

        private void btnDelAll_Click(object sender, EventArgs e) {
            tbxMemberCode.Text = String.Empty;
            tbxMemberCode.Focus();
        }

        private void btnUnderscore_Click(object sender, EventArgs e) {
            buttonPress(btnUnderscore.Text);
        }

        private void btnSpace_Click(object sender, EventArgs e) {
            buttonPress(" ");
        }

        private void btnHyphen_Click(object sender, EventArgs e) {
            buttonPress(btnHyphen.Text);
        }

        private void btn1_Click(object sender, EventArgs e) {
            buttonPress(btn1.Text);
        }

        private void btn2_Click(object sender, EventArgs e) {
            buttonPress(btn2.Text);
        }

        private void btn3_Click(object sender, EventArgs e) {
            buttonPress(btn3.Text);
        }

        private void btn4_Click(object sender, EventArgs e) {
            buttonPress(btn4.Text);
        }

        private void btn5_Click(object sender, EventArgs e) {
            buttonPress(btn5.Text);
        }

        private void btn6_Click(object sender, EventArgs e) {
            buttonPress(btn6.Text);
        }

        private void btn7_Click(object sender, EventArgs e) {
            buttonPress(btn7.Text);
        }

        private void btn8_Click(object sender, EventArgs e) {
            buttonPress(btn8.Text);
        }

        private void btn9_Click(object sender, EventArgs e) {
            buttonPress(btn9.Text);
        }

        private void btn0_Click(object sender, EventArgs e) {
            buttonPress(btn0.Text);
        }

        private void btnDecimal_Click(object sender, EventArgs e) {
            buttonPress(btnDecimal.Text);
        }
        #endregion

        private void btnTimeKeeping_Click(object sender, EventArgs e) {
            startTimeKeeping();
            tbxMemberCode.Focus();
        }

        private void btnRefreshData_Click(object sender, EventArgs e) {
            // Get lại List Chip Personalization and List Member from database
            getListChipPers();
            getListMember();
            tbxMemberCode.Text = String.Empty;
            tbxMemberCode.Focus();
        }

        private void btnShowHideKeyboard_Click(object sender, EventArgs e) {
            if (!isKeyboardShow) {
                pnlBelow.Visible = true; // Hiện keyboard lên
                // Canh giữa màn hình cho keyboard
                pnlKeyboard.Location = new Point((pnlBelow.Size.Width - pnlKeyboard.Size.Width) / 2,
                    (pnlBelow.Size.Height - pnlKeyboard.Size.Height) / 2);
                // Canh lại kích thước keyboard
                setupKeyboardSize();
                isKeyboardShow = true;
            } else {
                pnlBelow.Visible = false;
                isKeyboardShow = false;
            }
        }
        #endregion

        #region Button Event's Support
        /// <summary>
        /// Method gọi chấm công xuống database
        /// </summary>
        private void startTimeKeeping() {
            getMemberIdAndSerialNumber();

            if (null != serialNumber) {
                TimeKeepingImage timeKeepingImage = new TimeKeepingImage();
                Shift tempShift = new Shift();

                tempShift.deviceDoorId = 0;
                tempShift.deviceDoorIp = getLocalIPAddress();
                tempShift.memberId = memberId;
                tempShift.serialNumber = serialNumber;

                // Insert shift rồi lấy lại để có shiftId
                Shift shift = insertShift(tempShift);
                // Chụp hình
                Image image = TakeSnapShot();

                timeKeepingImage.image = ImageUtils.ImageToBase64(image);

                int imgResult = insertShiftImage(shift.Id, timeKeepingImage);

                // Chấm công thành công
                if (null != shift && imgResult == 0) {
                    tbxMemberCode.Text = String.Empty;
                    setTimeKeepingResultSuccess();
                } else {
                    setTimeKeepingResultFailure();
                }
            } else {
                setTimeKeepingResultFailure();
            }

            lblTimeKeepingResult.Show();
            serialNumber = null;
            timer.Interval = 1000;
            timer.Start();
        }

        /// <summary>
        /// Method cho từng nút nhấn
        /// </summary>
        /// <param name="s"></param>
        private void buttonPress(string s) {
            tbxMemberCode.Select();
            SendKeys.Send(s);
        }

        /// <summary>
        /// Method lấy danh sách chip personalization
        /// </summary>
        private void getListChipPers() {
            if (!bgwGetListChipPers.IsBusy) {
                bgwGetListChipPers.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Method lấy danh sách nhân viên
        /// </summary>
        private void getListMember() {
            if (!bgwGetListMember.IsBusy) {
                bgwGetListMember.RunWorkerAsync();
            }
        }
        #endregion

        #region Events
        public Shift insertShift(Shift shift) {
            return TimeKeepingShiftFactory.Instance.GetChannel().insertShift(StorageService.CurrentSessionId, shift);
        }

        public int insertShiftImage(long id, TimeKeepingImage image) {
            return TimeKeepingShiftFactory.Instance.GetChannel().insertShiftImage(StorageService.CurrentSessionId, id, image);
        }

        /// <summary>
        /// Method nhận thay đổi của textbox mã nhân viên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxMemberCode_TextChanged(object sender, EventArgs e) {
            // Nếu không có dữ liệu thì disable nút timekeeping và xóa các label
            if (lblValueFullName.Text != String.Empty) {
                clearMemberInfo();
                disOrEnableButtonTimeKeeping(false);
            }

            memberCustomObj = new MemberCustom();

            if (tbxMemberCode.Text != String.Empty) {
                // Lambda
                foreach (var p in listMember.Where(p =>
                (p.memberCode.ToUpper() == tbxMemberCode.Text) || (p.idCardNumber == tbxMemberCode.Text))) {
                    // Gán vào member obj chung để sử dụng
                    memberCustomObj = p;

                    lblValueFullName.Text = p.GetFullName();
                    lblValueMemberCode.Text = p.memberCode;
                    lblValuePosition.Text = p.position;
                    lblValueDepartment.Text = p.subOrg;

                    // Enable timekeeping button nếu có dữ liệu
                    disOrEnableButtonTimeKeeping(true);
                    break;
                }

                //// LINQ
                //foreach (var v in from p in listMember
                //                  where p.Code == tbxMemberCode.Text
                //                  select new { p.FirstName, p.Position }) {
                //    lblFullName.Text = v.FirstName;
                //    break;
                //}
            }
        }

        /// <summary>
        /// Method nhận ký tự đánh ở ô mã nhân viên, khi nhấn enter thì chấm công luôn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxMemberCode_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter && btnTimeKeeping.Enabled == true) {
                startTimeKeeping();
            }
        }

        /// <summary>
        /// Method xóa dữ liệu ở các label thông tin nhân viên
        /// </summary>
        private void clearMemberInfo() {
            lblValueFullName.Text = lblValueMemberCode.Text = lblValuePosition.Text =
                lblValueDepartment.Text = String.Empty;
        }

        /// <summary>
        /// Method Enable or Disable button time keeping
        /// </summary>
        /// <param name="check"></param>
        private void disOrEnableButtonTimeKeeping(bool check) {
            btnTimeKeeping.Enabled = check;
        }

        /// <summary>
        /// Method lấy ip local của máy tính
        /// </summary>
        /// <returns></returns>
        public string getLocalIPAddress() {
            IPHostEntry host;
            string localIP = "192.168.1.xxx";

            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList) {
                if (ip.AddressFamily == AddressFamily.InterNetwork) {
                    localIP = ip.ToString();
                    break;
                }
            }

            return localIP;
        }

        /// <summary>
        /// Method lấy memberId và dựa vào memberId để tìm serialNumber
        /// </summary>
        private void getMemberIdAndSerialNumber() {
            // get memberId
            memberId = memberCustomObj.memberId;

            // get serial number
            foreach (var p in listChipPers.Where(p => (p.memberId == memberId))) {
                serialNumber = p.serialNumber;
                break;
            }
        }

        /// <summary>
        /// Method set label result thành công
        /// </summary>
        private void setTimeKeepingResultSuccess() {
            lblTimeKeepingResult.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblTimeKeepingResult.Name + "_Successful");
            lblTimeKeepingResult.BackColor = Color.Green;
            tbxMemberCode.Select();
        }

        /// <summary>
        /// Method set label result thất bại
        /// </summary>
        private void setTimeKeepingResultFailure() {
            lblTimeKeepingResult.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblTimeKeepingResult.Name + "_Failed");
            lblTimeKeepingResult.BackColor = Color.Red;
            tbxMemberCode.SelectAll();
        }

        /// <summary>
        /// Method finish handle timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e) {
            lblTimeKeepingResult.Hide();
            timer.Stop();
        }
        #endregion

        #region Camera
        private void uccFace_StopRequested(object sender, EventArgs e) {
            vdFace.Stop();
            uccFace.Message = VideoSourceContants.DisconnectedByUserMessage;
        }

        private void uccFace_StartRequested(object sender, EventArgs e) {
            PlayVideoSourceOnUCC(uccFace);
        }

        private void PlayVideoSourceOnUCC(UsrCameraCanvas ucc) {
            string source = "";

            try {
                source = ConfigurationManager.AppSettings["camera_address_timekeeping"];
            } catch (Exception ex) {
                // lỗi chưa cấu hình đường dẫn camera_address_nonresident trong file app_config
            }

            SetupAndPlayVideoSource(ref vdFace, ucc, CameraConnectionType.NetworkCameraViaRtsp, source);

        }

        private void SetupAndPlayVideoSource(ref IVideoSource videoSource, UsrCameraCanvas ucc, CameraConnectionType conntype, string source) {
            if (videoSource == null || videoSource.IsDisposed) {
                videoSource = VideoSourceFactory.GetInstance().Register(conntype, source, ucc);
                if (videoSource == null) {
                    // lỗi
                    return;
                }
                videoSource.Stopped += videoSource_Stopped;
                videoSource.Played += videoSource_Played;
                ucc.Message = VideoSourceContants.ConnectingMessage;
                PlayVideoSourceInNewThread(videoSource);
            } else {
                if (videoSource.ConnectionType != conntype) {
                    if (videoSource.IsPlaying) {
                        videoSource.Stop();
                    }
                    videoSource = VideoSourceFactory.GetInstance().Register(conntype, source, ucc);
                    if (videoSource == null) {
                        // lỗi
                        return;
                    }
                    videoSource.Stopped += videoSource_Stopped;
                    videoSource.Played += videoSource_Played;
                    ucc.Message = VideoSourceContants.ConnectingMessage;
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
                    ucc.Message = VideoSourceContants.ConnectingMessage;

                    PlayVideoSourceInNewThread(videoSource);
                } else if (!videoSource.IsPlaying) {
                    ucc.Message = VideoSourceContants.ConnectingMessage;
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
            uccFace.Message = VideoSourceContants.DisconnectedMessage;
            uccFace.Invalidate();
        }

        private void videoSource_Played(VideoSourceEventArgs e) {
            if (!IsHandleCreated || IsDisposed) {
                return;
            }
            if (InvokeRequired) {
                Invoke(new Action<VideoSourceEventArgs>(videoSource_Played), e);
                return;
            }
            uccFace.Message = VideoSourceContants.DataReceivingMessage;

            /* Thỉnh thoảng, sau khi hiển thị được hình camera lên canvas,
             * các phần dư xung quanh có màu đen thay vì là back color mà
             * mình đã set -> cần gọi hàm refresh
             */
            uccFace.Refresh();
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

        private Image TakeSnapShot() {
            if (vdFace == null || !vdFace.IsPlaying) {
                // camera không hoạt động
                return null;
            }

            Image faceImage = vdFace.TakeSnapshot();

            return faceImage;
        }
        #endregion

        #region Setup Keyboard Size
        private void setupKeyboardSize() {
            #region Row 1
            // Chia đều độ rộng cho 13 nút
            btnQ.Width = btnW.Width = btnE.Width = btnR.Width = btnT.Width =
                btnY.Width = btnU.Width = btnI.Width = btnO.Width = btnP.Width =
                btn7.Width = btn8.Width = btn9.Width = pnlKBRow1.Width / 13;
            #endregion

            #region Row 2
            // Chia đều độ rộng cho 13 nút
            btnA.Width = btnS.Width = btnD.Width = btnF.Width = btnG.Width =
                btnH.Width = btnJ.Width = btnK.Width = btnL.Width =
                btn4.Width = btn5.Width = btn6.Width = pnlKBRow2.Width / 13;
            // 2 panel ở 2 bên bằng 1 nửa của các nút khác
            pnlKBLeftSpace.Width = pnlKBRightSpace.Width = pnlKBRow2.Width / 26;
            #endregion

            #region Row 3
            // Chia đều độ rộng cho 13 nút
            btnZ.Width = btnX.Width = btnC.Width = btnV.Width =
                btnB.Width = btnN.Width = btnM.Width =
                btn1.Width = btn2.Width = btn3.Width = pnlKBRow3.Width / 13;
            // Nút xóa bằng 3/2 các nút phím
            btnDelAll.Width = btnDel.Width = 3 * pnlKBRow3.Width / 26;

            // Set size icon 2 nút xóa
            // Bằng một nửa chiều cao của nút (chia 2)
            // Tỉ lệ là icon hình vuông nên width height icon = nhau
            var imageDel = new Bitmap(btnDel.Image, new Size(btnDel.Height / 2, btnDel.Height / 2));
            btnDel.Image = imageDel;
            var imageDelAll = new Bitmap(btnDelAll.Image, new Size(btnDelAll.Height / 2, btnDelAll.Height / 2));
            btnDelAll.Image = imageDelAll;
            #endregion

            #region Row 4
            // Nút spacebar độ dài bằng 7 lần các nút phím
            btnSpace.Width = 7 * pnlKBRow4.Width / 13;
            btnDecimal.Width = pnlKBRow4.Width / 13;
            // Số 0 bằng 2 phím nút cộng lên
            btn0.Width = 2 * pnlKBRow4.Width / 13;
            // Nút gạch bằng 3/2 các nút phím
            btnUnderscore.Width = btnHyphen.Width = 3 * pnlKBRow4.Width / 26;

            // Set size icon nút space
            // Bằng một nửa chiều cao của nút (chia 2)
            // Tỉ lệ là icon hình vuông nên width height icon = nhau
            var imageSpace = new Bitmap(btnSpace.Image, new Size(btnSpace.Height / 2, btnSpace.Height / 2));
            btnSpace.Image = imageSpace;
            #endregion
        }
        #endregion

        #region Background Worker
        #region Get List Chip Personalization
        private void bgwGetListChipPers_DoWork(object sender, DoWorkEventArgs e) {
            List<ChipPersonalizationCustom> result = new List<ChipPersonalizationCustom>();

            try {
                result = TimeKeepingFormTimeKeepingFactory.Instance.GetChannel().getListChipPersonalizationCustom(StorageService.CurrentSessionId);
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
                e.Result = result;
            }
        }

        private void bgwGetListChipPers_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Cancelled) {
                return;
            }
            if (e.Result == null) {
                return;
            }

            // Lấy danh sách chip personalization từ DoWork
            listChipPers = new List<ChipPersonalizationCustom>();
            listChipPers = (List<ChipPersonalizationCustom>) e.Result;
        }
        #endregion

        #region Get List Member
        private void bgwGetListMember_DoWork(object sender, DoWorkEventArgs e) {
            List<MemberCustom> result = new List<MemberCustom>();

            try {
                result = TimeKeepingFormTimeKeepingFactory.Instance.GetChannel().getListMemberCustom(StorageService.CurrentSessionId);
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
                e.Result = result;
            }
        }

        private void bgwGetListMember_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Cancelled) {
                return;
            }
            if (e.Result == null) {
                return;
            }

            // Lấy danh sách member từ DoWork
            listMember = new List<MemberCustom>();
            listMember = (List<MemberCustom>) e.Result;
            listMemberCode = new List<string>();
            listMemberIDCardNo = new List<string>();

            foreach (MemberCustom member in listMember) {
                listMemberCode.Add(member.memberCode.ToUpper());
                listMemberIDCardNo.Add(member.idCardNumber);
            }

            // Gán gợi ý cho tbx mã thành viên
            // Gợi ý mã thành viên mà cmnd thành viên
            tbxMemberCode.AutoCompleteCustomSource.AddRange(listMemberCode.ToArray());
            tbxMemberCode.AutoCompleteCustomSource.AddRange(listMemberIDCardNo.ToArray());
        }
        #endregion
        #endregion

        #region CAB events
        [CommandHandler(TimeCommandName.ShowTimeKeepingWithoutCard)]
        public void ShowTimeKeepingWithoutCardMgtMainHandler(object s, EventArgs e) {
            UsrTimeKeepingWithoutCard uTKWithoutCard = workItem.Items.Get<UsrTimeKeepingWithoutCard>(DefineName.TimeKeepingWithoutCard);
            if (null == uTKWithoutCard) {
                uTKWithoutCard = workItem.Items.AddNew<UsrTimeKeepingWithoutCard>(DefineName.TimeKeepingWithoutCard);
            } else if (uTKWithoutCard.IsDisposed) {
                workItem.Items.Remove(uTKWithoutCard);
                uTKWithoutCard = workItem.Items.AddNew<UsrTimeKeepingWithoutCard>(DefineName.TimeKeepingWithoutCard);
            }

            workItem.Workspaces[WorkspaceName.MainWorkspace].Show(uTKWithoutCard);
            uTKWithoutCard.Parent.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, DefineName.MenuTimeKeepingWithoutCard);
        }
        #endregion
    }
}
