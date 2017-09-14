using CameraComponent;
using CameraComponent.Model;
using CameraComponent.View;
using CommonControls;
using CommonHelper.Constants;
using CommonHelper.Utils;
using Microsoft.Practices.CompositeUI;
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
    public partial class FrmTimeKeeping : CommonControls.Custom.CommonDialog {
        #region Properties
        private const int PADDING = 6;
        private const string FONT = "Microsoft Sans Serif";

        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        int currentIndex;

        // List Member
        List<ChipPersonalizationCustom> listChipPers;
        List<MemberCustom> listMember;
        List<string> listMemberCode;
        long memberId;
        string serialNumber;

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

        public FrmTimeKeeping() {
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

            // Camera
            uccFace.StartRequested += uccFace_StartRequested;
            uccFace.StopRequested += uccFace_StopRequested;

            // Button Time keeping
            btnTimeKeeping.Click += btnTimeKeeping_Click;

            // Timer
            timer.Tick += new EventHandler(timer_Tick);

            // Set max length
            tbxMemberCode.MaxLength = ConstantsValue.MAX_LENGTH_TEXT_BOX_VAR_CHAR;
        }

        protected override void OnLoad(EventArgs e) {
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);

            // Set up size for control
            setupSizeAndFont();
            // Set Language cho Form
            setLanguage();

            // Get List Chip Personalization and List Member from database
            getListChipPers();
            getListMember();

            // Load Camera
            PlayVideoSourceOnUCC(uccFace);

            tbxMemberCode.Focus();
        }
        #endregion

        #region Set Language
        private void setLanguage() {
            btnTimeKeeping.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, btnTimeKeeping.Name);
            lblHeaderDepartment.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblHeaderDepartment.Name);
            lblHeaderFullName.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblHeaderFullName.Name);
            lblHeaderMemberCode.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblHeaderMemberCode.Name);
            lblHeaderPosition.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblHeaderPosition.Name);
            lblInputMemberCode.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblInputMemberCode.Name);
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
                    setTimeKeepingResultSuccess();
                } else {
                    setTimeKeepingResultFailure();
                }

                tbxMemberCode.Text = String.Empty;
                tbxMemberCode.Focus();
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
            tbxMemberCode.Focus();
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
        /// Method nhận thay đổ của textbox mã nhân viên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxMemberCode_TextChanged(object sender, EventArgs e) {
            // Nếu không có dữ liệu thì disable nút timekeeping và xóa các label
            if (lblValueFullName.Text != String.Empty) {
                clearMemberInfo();
                disOrEnableButtonTimeKeeping(false);
            }
            currentIndex = 0;

            if (tbxMemberCode.Text != String.Empty) {
                // Lambda
                foreach (var p in listMemberCode.Where(p => (p == tbxMemberCode.Text))) {
                    // Lấy vị trí của code đó để tìm member
                    currentIndex = listMemberCode.IndexOf(p);

                    lblValueFullName.Text = listMember[currentIndex].GetFullName();
                    lblValueMemberCode.Text = listMember[currentIndex].memberCode;
                    lblValuePosition.Text = listMember[currentIndex].position;
                    lblValueDepartment.Text = listMember[currentIndex].subOrg;

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
            memberId = listMember[currentIndex].memberId;

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
        }

        /// <summary>
        /// Method set label result thất bại
        /// </summary>
        private void setTimeKeepingResultFailure() {
            lblTimeKeepingResult.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblTimeKeepingResult.Name + "_Failed");
            lblTimeKeepingResult.BackColor = Color.Red;
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

        #region Setup Size and Font
        private void setupSizeAndFont() {
            #region Panel Work
            // Set chiều cao cho panel chính ở trên bằng một nửa chiều cao màn hình
            pnlInformation.Height = Convert.ToInt32(Height / 2);

            #region Font
            Font fontInfotmation = new Font(FONT, pnlWork.Height / 16);
            lblInputMemberCode.Font = tbxMemberCode.Font = fontInfotmation;

            fontInfotmation = new Font(FONT, pnlWork.Height / 14, FontStyle.Bold);
            lblTimeKeepingResult.Font = fontInfotmation;

            fontInfotmation = new Font(FONT, pnlWork.Height / 18);
            btnTimeKeeping.Font = fontInfotmation;

            #endregion
            // Set chiều rộng = chiều dài để ra hình vuông
            uccFace.Width = uccFace.Height;
            pnlWork.Width = pnlWork.Height;
            // Set chiều cao cho label kết quả chấm công
            lblTimeKeepingResult.Height = pnlWork.Height / 4;
            // Set chiều cao cho button chấm công
            btnTimeKeeping.Height = pnlWork.Height / 6;
            // Set chiều rộng ô nhập mã nhân viên
            // chiều rộng bằng chiều rộng của panel trừ đi padding ở 2 đầu
            tbxMemberCode.Width = pnlWork.Width - PADDING * 3;
            // Set vị trí ô nhập mã nhân viên ở giữa panel
            tbxMemberCode.Location = new Point((pnlWork.Width - tbxMemberCode.Width) / 2,
                                                              (pnlWork.Height - tbxMemberCode.Height) / 2);
            // Set vị trí label nhập mã nhân viên ở phía trên ô nhập mã nhân viên
            lblInputMemberCode.Location = new Point((pnlWork.Width - lblInputMemberCode.Width) / 2,
                                                              tbxMemberCode.Location.Y - tbxMemberCode.Height);
            #endregion

            #region Panel Keyboard
            // Set chiều cao cho từng hàng panel bàn phím bằng chiều cao của panel chia 4
            pnlKBRow1.Height = pnlKBRow2.Height =
                pnlKBRow3.Height = pnlKBRow4.Height = (pnlKeyboard.Height - PADDING * 2) / 4;

            #region Row 1
            btnQ.Height = btnW.Height = btnE.Height = btnR.Height = btnT.Height =
                btnY.Height = btnU.Height = btnI.Height = btnO.Height = btnP.Height =
                btn7.Height = btn8.Height = btn9.Height = pnlKBRow1.Height;

            btnQ.Width = btnW.Width = btnE.Width = btnR.Width = btnT.Width =
                btnY.Width = btnU.Width = btnI.Width = btnO.Width = btnP.Width =
                btn7.Width = btn8.Width = btn9.Width = pnlKBRow1.Width / 13;
            #endregion

            #region Row 2
            btnA.Height = btnS.Height = btnD.Height = btnF.Height = btnG.Height =
                btnH.Height = btnJ.Height = btnK.Height = btnL.Height =
                btn4.Height = btn5.Height = btn6.Height = pnlKBRow2.Height;
            pnlKBLeftSpace.Height = pnlKBRightSpace.Height = pnlKBRow2.Height;

            btnA.Width = btnS.Width = btnD.Width = btnF.Width = btnG.Width =
                btnH.Width = btnJ.Width = btnK.Width = btnL.Width =
                btn4.Width = btn5.Width = btn6.Width = pnlKBRow2.Width / 13;
            pnlKBLeftSpace.Width = pnlKBRightSpace.Width = pnlKBRow2.Width / 26;
            #endregion

            #region Row 3
            btnZ.Height = btnX.Height = btnC.Height = btnV.Height =
                btnB.Height = btnN.Height = btnM.Height =
                btn1.Height = btn2.Height = btn3.Height = pnlKBRow3.Height;
            btnDelAll.Height = btnDel.Height = pnlKBRow3.Height;

            btnZ.Width = btnX.Width = btnC.Width = btnV.Width =
                btnB.Width = btnN.Width = btnM.Width =
                btn1.Width = btn2.Width = btn3.Width = pnlKBRow3.Width / 13;
            btnDelAll.Width = btnDel.Width = 3 * pnlKBRow3.Width / 26;
            #endregion

            #region Row 4
            btnUnderscore.Height = btnSpace.Height = btnHyphen.Height =
                btn0.Height = btnDecimal.Height = pnlKBRow4.Height;

            btnSpace.Width = btnZ.Width + btnX.Width + btnC.Width + btnV.Width +
                btnB.Width + btnN.Width + btnM.Width;
            btnDecimal.Width = pnlKBRow4.Width / 13;
            btn0.Width = 2 * pnlKBRow4.Width / 13;
            btnUnderscore.Width = btnHyphen.Width = 3 * pnlKBRow4.Width / 26;
            #endregion

            #region Font
            Font fontKeyBoard = new Font(FONT, btnQ.Height / 4);

            #region Row 1
            btnQ.Font = btnW.Font = btnE.Font = btnR.Font = btnT.Font =
                btnY.Font = btnU.Font = btnI.Font = btnO.Font = btnP.Font =
                btn7.Font = btn8.Font = btn9.Font = fontKeyBoard;
            #endregion

            #region Row 2
            btnA.Font = btnS.Font = btnD.Font = btnF.Font = btnG.Font =
                btnH.Font = btnJ.Font = btnK.Font = btnL.Font =
                btn4.Font = btn5.Font = btn6.Font = fontKeyBoard;
            #endregion

            #region Row 3
            btnZ.Font = btnX.Font = btnC.Font = btnV.Font =
                btnB.Font = btnN.Font = btnM.Font =
                btn1.Font = btn2.Font = btn3.Font = fontKeyBoard;
            #endregion

            #region Row 4
            btnUnderscore.Font = btnHyphen.Font =
                btn0.Font = btnDecimal.Font = fontKeyBoard;
            #endregion
            #endregion
            #endregion

            #region Panel Member Information
            pnlMemberInfoLeft.Width = pnlMemberInfo.Width / 3 - PADDING;

            Size labelValueMaximumSize = new Size(pnlMemberInfoRight.Width - PADDING, 0);
            lblValueDepartment.MaximumSize = lblValueFullName.MaximumSize =
                lblValueMemberCode.MaximumSize = lblValuePosition.MaximumSize = labelValueMaximumSize;

            #region Font
            Font fontHeader = new Font(FONT, pnlMemberInfoLeft.Width / 10);
            Font fontValue = new Font(FONT, pnlMemberInfoLeft.Width / 8, FontStyle.Bold);

            lblHeaderDepartment.Font = lblHeaderFullName.Font =
                lblHeaderMemberCode.Font = lblHeaderPosition.Font = fontHeader;
            lblValueDepartment.Font = lblValueFullName.Font =
                lblValueMemberCode.Font = lblValuePosition.Font = fontValue;
            #endregion
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

            foreach (MemberCustom member in listMember) {
                listMemberCode.Add(member.memberCode.ToUpper());
            }
        }
        #endregion
        #endregion

        #region CAB events
        //[CommandHandler(TimeCommandName.ShowFormTimeKeeping)]
        //public void ShowTestForm(object s, EventArgs e) {
        //    FrmTimeKeeping fTest = workItem.Items.Get<FrmTimeKeeping>(DefineName.FormTimeKeeping);
        //    if (null == fTest) {
        //        fTest = workItem.Items.AddNew<FrmTimeKeeping>(DefineName.FormTimeKeeping);
        //    } else if (fTest.IsDisposed) {
        //        workItem.Items.Remove(fTest);
        //        fTest = workItem.Items.AddNew<FrmTimeKeeping>(DefineName.FormTimeKeeping);
        //    }

        //    fTest.Show();
        //}     // Đóng code để sau này có cần màn hình cảm ứng riêng
        #endregion
    }
}
