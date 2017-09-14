using JavaCommunication;
using JavaCommunication.Factory;
using ParkingProcessComponent.View;
using sAccessControl.Config;
using sAccessControl.Contants;
using sAccessControl.Device.Camera;
using sAccessControl.Device.Reader;
using sAccessControl.Enums;
using sAccessControl.Utils;
using sAccessControl.View;
using sWorldModel.Exceptions;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonHelper.Utils;
using CommonHelper.Constants;
using SMSGaywate;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Text.RegularExpressions;

namespace sAccessControl
{
    public partial class MainForm : Form
    {
        #region Propertices

        private IVideoSource videoSource = null;
        private CameraPairConfigElement cameraConfigs;
        //private ReaderConfigElement readerConfigs;
        private IReader reader = null;
        private SessionDTO session = null;
        private string serialNumberStr = string.Empty;
        private byte[] serialCard;
        private DoorOut doorOut = null;
        private const int Success = 2;
        private const int Process = 1;
        private int Failed = -1;
        private string Password = string.Empty;

        private UsrNotification usrNotification = null;

        private BackgroundWorker bgwProcessCheckIn = null;
        private BackgroundWorker bgwLoadDeviceDoorList;

        private TreeNode rootNode;
        private TreeNode selectedDeviceNode;

        private List<DeviceDoor> DeviceDoorList;
        private string ipAddress = string.Empty;

        // The original font of tree nodes
        private Font startupNodeFont;

        //ReceiveMessages
        // Will hold the user name
        private string UserName = "Unknown";
        private StreamWriter swSender;
        private StreamReader srReceiver;
        private TcpClient tcpServer;
        // Needed to update the form with messages from another thread
        private delegate void UpdateLogCallback(string strMessage);
        // Needed to set the form to a "disconnected" state from another thread
        private delegate void CloseConnectionCallback(string strReason);
        private Thread thrMessaging;
        private IPAddress ipAddr;
        private bool Connected;

        #endregion

        #region Form events
        public MainForm(SessionDTO session, string password)
        {
            InitializeComponent();
            this.session = session;
            this.Password = password;
            InitNotification();
            RegisterCameraEvent();
            InitTreeList();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            cameraConfigs = AccessControlConfigSection.GetInstance().Camera;
            //readerConfigs = AccessControlConfigSection.GetInstance().Reader;
            //ClearSampleData();

            //PopulateConfigsToView();

            PlayVideoSourceOnCanvas(cameraCanvas);

            //ConnectReaderAndWaitForCard();
            LabelEmpty();
            ttlbUser.Text = session.UserName;

            //LoadDeviceList();

            // Khi debug nên comment đoạn code này vì nó sẽ
            // làm việc truy xuất code khi debug bị chậm đi
            //EnableKeyListener(true);

            Connect();
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            if (CommonControls.MessageBoxManager.ShowQuestionMessageBox(this, "Bạn có chắc muốn tắt chương trình không?") != DialogResult.Yes)
            {
                if (Connected == true)
                {
                    // Closes the connections, streams, etc.
                    Connected = false;
                    swSender.Close();
                    srReceiver.Close();
                    tcpServer.Close();
                }
                e.Cancel = true;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                cameraCanvas.Message = VideoSourceContants.DisconnectingMessage;
                StopVideoSourceInNewThread(videoSource, true);

                if (reader != null)
                {
                    reader.Disconnect();
                }

                if ((components != null))
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion Form events

        #region Register Event's

        public void RegisterCameraEvent()
        {
            cameraCanvas.StartRequested += cameraCanvas_StartRequested;
            cameraCanvas.StopRequested += cameraCanvas_StopRequested;

            //lblCameraState.ItemConnectClicked += cameraCanvas_StartRequested;
            //lblCameraState.ItemDisconnectClicked += cameraCanvas_StopRequested;

            //lblReaderState.ItemConnectClicked += lblReaderState_ItemConnectClicked;
            //lblReaderState.ItemDisconnectClicked += lblReaderState_ItemDisconnectClicked;

            //bgwProcessCheckIn = new BackgroundWorker();
            //bgwProcessCheckIn.DoWork += bgwProcessCheckIn_DoWork;
            //bgwProcessCheckIn.RunWorkerCompleted += bgwProcessCheckIn_RunWorkerCompleted;

            this.FormClosed += MainForm_FormClosed;

            //bgwLoadDeviceDoorList = new BackgroundWorker();
            //bgwLoadDeviceDoorList.WorkerSupportsCancellation = true;
            //bgwLoadDeviceDoorList.DoWork += bgwLoadDeviceDoorList_DoWork;
            //bgwLoadDeviceDoorList.RunWorkerCompleted += bgwLoadDeviceDoorList_RunWorkerCompleted;

            ////Tree View
            //trvDeviceList.AfterExpand += trvDeviceList_AfterExpand;
            //trvDeviceList.BeforeSelect += trvDeviceList_BeforeSelect;
            //trvDeviceList.AfterSelect += trvDeviceList_AfterSelect;

            // Assign startup value
            startupNodeFont = trvDeviceList.Font;
            this.FormClosing += OnFormClosing;

            tsbmLogout.Click += tsbmLogout_Click;
        }

        void tsbmLogout_Click(object sender, EventArgs e)
        {
            if (CommonControls.MessageBoxManager.ShowQuestionMessageBox(this, "Bạn có chắc muốn đăng xuất khỏi hệ thống không?") != DialogResult.Yes)
            {
                return;
            }
            try
            {
                Thread th = new Thread(() =>
                {
                    try
                    {
                        AuthenticationFactory.Instance.GetChannel().Logout(session.Token);
                    }
                    catch (TimeoutException) { }
                    catch (FaultException<WcfServiceFault>) { }
                    catch (FaultException) { }
                    catch (CommunicationException) { }
                });
                th.Start();
            }
            finally
            {
                // Show login dialog
                FrmLogin loginForm = new FrmLogin();
                loginForm.ResetToDefault();
                loginForm.Show();
                this.Hide();
            }
        }

        private void InitNotification()
        {
            usrNotification = new UsrNotification();
            usrNotification.Anchor = AnchorStyles.None;
            usrNotification.Visible = false;
            plMemberInfo.Controls.Add(usrNotification);
            usrNotification.Location = new Point(
                plMemberInfo.ClientSize.Width / 2 - usrNotification.Width / 2,
                plMemberInfo.ClientSize.Height / 2 - usrNotification.Height / 2);
            usrNotification.BringToFront();

            plMemberInfo.SizeChanged += pnlWorkingArea_SizeChanged;
        }

        #endregion

        /// <summary>
        /// Hàm sự kiện của from
        /// </summary>
        #region Event's

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pnlWorkingArea_SizeChanged(object sender, EventArgs e)
        {
            usrNotification.Location = new Point(
                plMemberInfo.ClientSize.Width / 2 - usrNotification.Width / 2,
                plMemberInfo.ClientSize.Height / 2 - usrNotification.Height / 2);
            usrNotification.BringToFront();
        }

        private void cameraCanvas_StartRequested(object sender, EventArgs e)
        {
            PlayVideoSourceOnCanvas(cameraCanvas);
        }

        private void cameraCanvas_StopRequested(object sender, EventArgs e)
        {
            videoSource.Stop();
            cameraCanvas.Message = VideoSourceContants.DisconnectedByUserMessage;
            //lblCameraState.State = DeviceState.DisconnectedByUser;
        }

        private void lblReaderState_ItemConnectClicked(object sender, EventArgs e)
        {
            //ConnectReaderAndWaitForCard();
        }

        private void lblReaderState_ItemDisconnectClicked(object sender, EventArgs e)
        {
            reader.Disconnect();
            //lblReaderState.State = DeviceState.DisconnectedByUser;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //ttlbTime.Text = DateTime.Now.ToString("HH:mm:ss");
           session = AuthenticationFactory.Instance.GetChannel().Login(session.UserName, Password);
        }

        //#region Device Door

        //void trvDeviceList_AfterSelect(object sender, TreeViewEventArgs e)
        //{
        //    TreeNode selectedNode = e.Node;
        //    TreeNode parentNode = new TreeNode();
        //    if (selectedNode != null)
        //    {
        //        parentNode = selectedNode.Parent;
        //        selectedNode.NodeFont = new Font(startupNodeFont, FontStyle.Bold);
        //        selectedNode.Text = selectedNode.Text;

        //        if (selectedDeviceNode != null && selectedNode == selectedDeviceNode)
        //        {
        //            return;
        //        }

        //        selectedDeviceNode = selectedNode;

        //        if (selectedDeviceNode.Level == 1)
        //        {
        //            long deviceId = Convert.ToInt64(selectedDeviceNode.Name);
        //            DeviceDoor device = DeviceDoorList.SingleOrDefault(p => p.Id == deviceId);
        //            if (device != null)
        //                ipAddress = device.Ip;
        //        }

        //        //currentPageIndex = 1;
        //    }
        //}

        //void trvDeviceList_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        //{
        //    //// If background worker is running -> restrict selecting another node
        //    //if (bgwLoadDoorOut.IsBusy)
        //    //{
        //    //    e.Cancel = true;
        //    //    return;
        //    //}

        //    // Change node font style to normal
        //    if (selectedDeviceNode != null)
        //    {
        //        selectedDeviceNode.NodeFont = new Font(startupNodeFont, FontStyle.Regular);
        //        selectedDeviceNode.Text = selectedDeviceNode.Text;
        //    }
        //}

        //void trvDeviceList_AfterExpand(object sender, TreeViewEventArgs e)
        //{
        //    //if (chkAutoCloseNode.Checked)
        //    //{
        //    //    foreach (TreeNode node in rootNode.Nodes)
        //    //    {
        //    //        if (node.IsExpanded && node != e.Node)
        //    //        {
        //    //            node.Collapse();
        //    //        }
        //    //    }
        //    //    trvDeviceList.SelectedNode = null;
        //    //}
        //}

        //void bgwLoadDeviceDoorList_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    List<DeviceDoor> result = null;
        //    try
        //    {
        //        e.Result = DeviceDoorList = AccessFactory.Instance.GetChannel().GetDeviceDoorList(session.Token);
        //    }
        //    catch (TimeoutException)
        //    {
        //        usrNotification.ShowMessage(NotificationType.Failed, CommonControls.CommonMessages.TimeOutExceptionMessage);
        //    }
        //    catch (FaultException<WcfServiceFault> ex)
        //    {
        //        usrNotification.ShowMessage(NotificationType.Failed, ErrorCodes.GetErrorMessage(ex.Detail.Code));
        //    }
        //    catch (FaultException ex)
        //    {
        //        usrNotification.ShowMessage(NotificationType.Failed, CommonControls.CommonMessages.FaultExceptionMessage
        //                + Environment.NewLine + Environment.NewLine
        //                + ex.Message);
        //    }
        //    catch (CommunicationException)
        //    {
        //        usrNotification.ShowMessage(NotificationType.Failed, CommonControls.CommonMessages.CommunicationExceptionMessage);
        //    }
        //}

        //void bgwLoadDeviceDoorList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    if (e.Cancelled)
        //    {
        //        return;
        //    }
        //    if (e.Result == null)
        //    {
        //        return;
        //    }
        //    // Get result from DoWork method
        //    List<DeviceDoor> result = (List<DeviceDoor>)e.Result;
        //    foreach (DeviceDoor device in result)
        //    {
        //        TreeNode deviceNode = new TreeNode();
        //        deviceNode.Text = device.Name + " - " + device.Ip + ":" + device.Port;
        //        deviceNode.Name = Convert.ToString(device.Id);
        //        rootNode.Nodes.Add(deviceNode);
        //    }
        //}


        //#endregion

        #endregion


        #region Support Event's
        //Không sử dụng
        #region Camera methods

        private void PlayVideoSourceOnCanvas(UsrCameraCanvas canvas)
        {
            //if (cameraConfigs.Enable)
            //{
            //    SetupAndPlayVideoSource(ref videoSource, cameraCanvas, lblCameraState, (CameraConnectionType)cameraConfigs.CameraType, cameraConfigs.CameraAddress);
            //}
            //else
            //{
            //    canvas.Message = VideoSourceContants.NotConfiguredMessage;
            //    StopVideoSourceInNewThread(videoSource, false);
            //    lblCameraState.State = DeviceState.NotUsed;
            //}
        }

        private void SetupAndPlayVideoSource(ref IVideoSource videoSource, UsrCameraCanvas canvas, UsrDeviceStatus videoSourceLabel, CameraConnectionType conntype, string source)
        {
            if (videoSource == null || videoSource.IsDisposed)
            {
                videoSource = VideoSourceFactory.GetInstance().Register(conntype, source, canvas);
                if (videoSource == null)
                {
                    videoSourceLabel.State = DeviceState.IncorrectConfig;
                    return;
                }

                videoSource.Stopped += videoSource_Stopped;
                videoSource.Played += videoSource_Played;

                canvas.Message = VideoSourceContants.ConnectingMessage;
                videoSourceLabel.State = DeviceState.Connecting;

                PlayVideoSourceInNewThread(videoSource);
            }
            else
            {
                if (videoSource.ConnectionType != conntype)
                {
                    if (videoSource.IsPlaying)
                    {
                        videoSource.Stop();
                    }

                    videoSource = VideoSourceFactory.GetInstance().Register(conntype, source, canvas);
                    if (videoSource == null)
                    {
                        videoSourceLabel.State = DeviceState.IncorrectConfig;
                        return;
                    }

                    videoSource.Stopped += videoSource_Stopped;
                    videoSource.Played += videoSource_Played;

                    canvas.Message = VideoSourceContants.ConnectingMessage;
                    videoSourceLabel.State = DeviceState.Connecting;

                    PlayVideoSourceInNewThread(videoSource);
                }
                else if (!videoSource.Source.Equals(source))
                {
                    bool playing;
                    if (playing = videoSource.IsPlaying)
                    {
                        StopVideoSourceInNewThread(videoSource, true);
                    }

                    videoSource.Source = source;

                    if (playing)
                    {
                        canvas.Message = VideoSourceContants.ConnectingMessage;
                        videoSourceLabel.State = DeviceState.Connecting;

                        PlayVideoSourceInNewThread(videoSource);
                    }
                }
                else if (!videoSource.IsPlaying)
                {
                    canvas.Message = VideoSourceContants.ConnectingMessage;
                    videoSourceLabel.State = DeviceState.Connecting;

                    PlayVideoSourceInNewThread(videoSource);
                }
            }
        }

        private void PlayVideoSourceInNewThread(IVideoSource videoSource)
        {
            Thread th = new Thread(() => videoSource.Play());
            th.Start();
        }

        private void StopVideoSourceInNewThread(IVideoSource videoSource, bool join)
        {
            if (videoSource != null && !videoSource.IsDisposed)
            {
                Thread th = new Thread(() =>
                {
                    videoSource.Stop();
                });
                th.Start();
                if (join)
                {
                    th.Join();
                }
            }
        }

        private void DisposeVideoSourceInNewThread(IVideoSource videoSource, bool join)
        {
            if (videoSource != null || !videoSource.IsDisposed)
            {
                Thread th = new Thread(() =>
                {
                    videoSource.Dispose();
                });
                th.Start();
                if (join)
                {
                    th.Join();
                }
            }
        }

        //private CameraPairConfigElement GetCameraConfigs()
        //{
        //    switch (curVehicleType)
        //    {
        //        case (byte)VehicleType.Bicycle:
        //        case (byte)VehicleType.Motor:
        //        case (byte)VehicleType.Motor1:
        //        case (byte)VehicleType.Motor2:
        //            return curIsDirectionIn ? configs.CameraPairInMotor : configs.CameraPairOutMotor;

        //        case (byte)VehicleType.Car:
        //        case (byte)VehicleType.Car1:
        //        case (byte)VehicleType.Car2:
        //            return curIsDirectionIn ? configs.CameraPairInCar : configs.CameraPairOutCar;

        //        default:
        //            throw new Exception("Loại xe không được camera hỗ trợ!");
        //    }
        //}

        private void videoSource_Played(VideoSourceEventArgs e)
        {
            //if (!IsHandleCreated || IsDisposed)
            //{
            //    return;
            //}
            if (IsDisposed)
            {
                return;
            }
            if (InvokeRequired)
            {
                Invoke(new Action<VideoSourceEventArgs>(videoSource_Played), e);
                return;
            }

            if (e.CanvasHandle == cameraCanvas.Handle)
            {
                cameraCanvas.Message = VideoSourceContants.DataReceivingMessage;
                //lblCameraState.State = DeviceState.Connected;

                /* Thỉnh thoảng, sau khi hiển thị được hình camera lên canvas,
                 * các phần dư xung quanh có màu đen thay vì là back color mà
                 * mình đã set -> cần gọi hàm refresh
                 */
                cameraCanvas.Refresh();
            }
        }

        private void videoSource_Stopped(VideoSourceEventArgs e)
        {
            //if (!IsHandleCreated || IsDisposed)
            //{
            //    return;
            //}
            if (IsDisposed)
            {
                return;
            }
            if (InvokeRequired)
            {
                Invoke(new Action<VideoSourceEventArgs>(videoSource_Stopped), e);
                return;
            }

            if (e.CanvasHandle == cameraCanvas.Handle)
            {
                cameraCanvas.Message = VideoSourceContants.DisconnectedMessage;
                cameraCanvas.Invalidate();
                //lblCameraState.State = DeviceState.Disconnected;
                //tabControl1.SelectedTab = tpDeviceStatus;
            }
        }

        private void canvas_StopRequested(object sender, EventArgs e)
        {
            if (videoSource != null)
            {
                videoSource.Stop();
                cameraCanvas.Message = VideoSourceContants.DisconnectedByUserMessage;
                //lblCameraState.State = DeviceState.DisconnectedByUser;
            }
        }

        private void canvas_StartRequested(object sender, EventArgs e)
        {
            PlayVideoSourceOnCanvas(cameraCanvas);
        }

        #endregion Camera methods

        //#region Reader methods

        //private void ConnectReaderAndWaitForCard()
        //{
        //    lblReaderState.State = DeviceState.Connecting;

        //    // Khởi tạo (hoặc cập nhật) reader
        //    if (reader != null)
        //    {
        //        if (reader.Type == (ReaderType)readerConfigs.Type)
        //        {
        //            if (reader.Address != Convert.ToByte(readerConfigs.Address))
        //            {
        //                try
        //                {
        //                    reader.ChangeReaderAddress(Convert.ToByte(readerConfigs.Address));
        //                }
        //                catch (ReaderException)
        //                {
        //                    lblReaderState.State = DeviceState.Disconnected;
        //                    return;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            try
        //            {
        //                reader.Disconnect();
        //            }
        //            catch (ReaderException)
        //            {
        //                lblReaderState.State = DeviceState.Disconnected;
        //                return;
        //            }
        //            reader = ReaderFactory.GetInstance().Register((ReaderType)readerConfigs.Type, Convert.ToByte(readerConfigs.Address), readerConfigs.BeepOnTagDetected);
        //        }
        //    }
        //    else
        //    {
        //        reader = ReaderFactory.GetInstance().Register((ReaderType)readerConfigs.Type, Convert.ToByte(readerConfigs.Address), readerConfigs.BeepOnTagDetected);
        //    }

        //    // Connect đến reader đã tạo
        //    Thread th = new Thread(() =>
        //    {
        //        bool connected = false;
        //        try
        //        {
        //            connected = reader.Connect();
        //        }
        //        catch (ReaderException)
        //        {
        //            lblReaderState.State = DeviceState.Disconnected;
        //            return;
        //        }

        //        if (connected)
        //        {
        //            lblReaderState.State = DeviceState.Connected;
        //            reader.Disconnected += reader_Disconnected;
        //            reader.TagDetected += reader_TagDetected;
        //            reader.StartCardDetection();
        //        }
        //        else
        //        {
        //            lblReaderState.State = DeviceState.Disconnected;
        //        }
        //    });
        //    th.Start();
        //}

        //private void reader_TagDetected(byte[] cardId)
        //{
        //    // Chuyển cardId từ mảng byte sang kiểu uint
        //    //long cardIdUint = BitConverter.ToUInt32(cardId, 0);
        //    serialNumberStr = CommonHelper.Utils.StringUtils.ByteArrayToHexString(cardId);
        //    serialCard = cardId;

        //    Invoke(new Action<string>(StartAccessProcess), serialNumberStr);
        //}

        //private void reader_Disconnected()
        //{
        //    //if (!IsHandleCreated)
        //    //{
        //    //    return;
        //    //}
        //    if (InvokeRequired)
        //    {
        //        Invoke(new Action(reader_Disconnected));
        //        return;
        //    }

        //    lblReaderState.State = DeviceState.Disconnected;
        //    tabControl1.SelectedTab = tpDeviceStatus;
        //}

        //#endregion Reader methods

        /// <summary>
        /// các hàm hiển thị thông tin người tag thẻ
        /// </summary>
        #region Access processing

        //private void StartAccessProcess(string serialNumber)
        //{
        //    if (session == null || string.IsNullOrEmpty(session.Token))
        //    {
        //        usrNotification.ShowMessage(NotificationType.Failed, CommonMessages.LoginFail);
        //        return;
        //    }
        //    //if (selectedDeviceNode == null)
        //    //{
        //    //    usrNotification.ShowMessage(NotificationType.Failed, "VUI LÒNG CHỌN THIẾT BỊ!");
        //    //    return;
        //    //}
        //    //if (videoSource == null || !videoSource.IsPlaying)
        //    //{
        //    //    usrNotification.ShowMessage(NotificationType.Failed, VideoSourceContants.DisconnectedMessage.ToUpper());
        //    //    return;
        //    //}
        //    if (IsBusy())
        //    {
        //        return;
        //    }

        //    //validate card
        //    string MSG = string.Empty;
        //    byte[] licenseMaster, licensePartner;
        //    CheckLicenseCard checkLicense = new CheckLicenseCard(serialCard);
        //    if (reader.ReadLicense(CardConfigration.START_SECTOR_MASTER, CardConfigration.STOP_SECTOR_MASTER, out licenseMaster))
        //    {
        //        if (!checkLicense.RsaVerifiedLicenseMaster(licenseMaster, out MSG))
        //        {
        //            usrNotification.ShowMessage(NotificationType.Failed, StatusContants.CARD_LICENSE_FAIL);
        //            return;
        //        }
        //        else if (reader.ReadLicense(CardConfigration.START_SECTOR_PARTNER, CardConfigration.STOP_SECTOR_PARTNER, out licensePartner))
        //        {
        //            if (!licensePartner.Any(e => e > 0))
        //            {
        //                usrNotification.ShowMessage(NotificationType.Failed, StatusContants.NOT_PERSO_CARD);
        //                return;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        usrNotification.ShowMessage(NotificationType.Failed, StatusContants.CAN_READ_LICENSE_CARD);
        //        return;
        //    }


        //    usrNotification.ShowMessage(NotificationType.Failed, StatusContants.INPROCESS);
        //    bgwProcessCheckIn.RunWorkerAsync();
        //}

        //private void bgwProcessCheckIn_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    try
        //    {
        //        InsertAttendance();
        //    }
        //    catch (VideoSourceException ex)
        //    {
        //        Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, ex.Message)));
        //        return;
        //    }
        //}

        //private void bgwProcessCheckIn_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    try
        //    {
        //        if (doorOut.Id > 0)
        //        {
        //            LoadMember();

        //            if (doorOut.Status == Success)
        //            {
        //                usrNotification.ShowMessage(NotificationType.Succeed, StatusContants.SUCCESS_IN);
        //                lbStatus.BackColor = Color.Green;
        //                lbStatus.Text = StatusContants.SUCCESSED_IN;
        //            }
        //            else
        //            {
        //                usrNotification.ShowMessage(NotificationType.Succeed, StatusContants.SUCCESS_OUT);
        //                lbStatus.BackColor = Color.Teal;
        //                lbStatus.Text = StatusContants.SUCCESSED_OUT;
        //            }
        //        }
        //        else
        //        {
        //            usrNotification.ShowMessage(NotificationType.Failed, StatusContants.FAIL);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        usrNotification.ShowMessage(NotificationType.Failed, StatusContants.FAIL);
        //    }
        //}

        //private void InsertAttendance()
        //{
        //    if (string.IsNullOrEmpty(serialNumberStr))
        //        return;
        //    try
        //    {
        //        DateTime date = DateTime.Now;
        //        Image img = videoSource != null && videoSource.IsPlaying ? videoSource.TakeSnapshot() : null;
        //        doorOut = new DoorOut()
        //        {
        //            SerialNumber = serialNumberStr,
        //            ImageIn = img == null
        //               ? CommonHelper.Utils.ImageUtils.ImageToBase64(sAccessControl.Properties.Resources.NoImage)
        //               : CommonHelper.Utils.ImageUtils.ImageToBase64(img),
        //            DateIn = date.ToStringFormatDateFullServer(),
        //            ImageOut = img == null
        //            ? CommonHelper.Utils.ImageUtils.ImageToBase64(sAccessControl.Properties.Resources.NoImage)
        //            : CommonHelper.Utils.ImageUtils.ImageToBase64(img),
        //            DateOut = date.ToStringFormatDateFullServer(),
        //        };
        //        doorOut = AccessFactory.Instance.GetChannel().AccessProcess(session.Token, ipAddress, doorOut);
        //    }
        //    catch (TimeoutException)
        //    {
        //        usrNotification.ShowMessage(NotificationType.Failed, CommonControls.CommonMessages.TimeOutExceptionMessage);
        //    }
        //    catch (FaultException<WcfServiceFault> ex)
        //    {
        //        usrNotification.ShowMessage(NotificationType.Failed, ErrorCodes.GetErrorMessage(ex.Detail.Code));
        //    }
        //    catch (FaultException ex)
        //    {
        //        usrNotification.ShowMessage(NotificationType.Failed, CommonControls.CommonMessages.FaultExceptionMessage
        //                + Environment.NewLine + Environment.NewLine
        //                + ex.Message);
        //    }
        //    catch (CommunicationException)
        //    {
        //        usrNotification.ShowMessage(NotificationType.Failed, CommonControls.CommonMessages.CommunicationExceptionMessage);
        //    }
        //}

        private void LoadMember()
        {
            if (doorOut != null && doorOut.MemberId > 0)
            {
                Member memberCus = new Member();
                try
                {
                    memberCus = OrganizationFactory.Instance.GetChannel().GetMemberById(session.Token, doorOut.MemberId);
                }
                catch (TimeoutException)
                {
                    usrNotification.ShowMessage(NotificationType.Failed, CommonControls.CommonMessages.TimeOutExceptionMessage);
                }
                catch (FaultException<WcfServiceFault> ex)
                {
                    usrNotification.ShowMessage(NotificationType.Failed, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                }
                catch (FaultException ex)
                {
                    usrNotification.ShowMessage(NotificationType.Failed, CommonControls.CommonMessages.FaultExceptionMessage
                            + Environment.NewLine + Environment.NewLine
                            + ex.Message);
                }
                catch (CommunicationException)
                {
                    usrNotification.ShowMessage(NotificationType.Failed, CommonControls.CommonMessages.CommunicationExceptionMessage);
                }
                finally
                {
                    LabelEmpty();
                    SubOrganization subOrg = GetSubOrg(memberCus.SubOrgId);
                    LoadManagerCost(subOrg.suborgid);
                    lblCode.Text = memberCus.Code;
                    lblFullName.Text = memberCus.GetFullName();
                    //lblPosition.Text = memberCus.objMem.Position;
                    lblSubOrgName.Text = subOrg.names;
                    lbPhone.Text = memberCus.PhoneNo;
                    lbEmail.Text = memberCus.Email;

                    lblDate.Text = DateTime.Now.ToStringFormatDate();
                    lblTime.Text = DateTime.Now.ToString("hh:mm:ss");

                    switch (doorOut.Status) 
                    {
                        case Success:
                            usrNotification.ShowMessage(NotificationType.Succeed, StatusContants.SUCCESS_IN);
                            lbStatus.BackColor = Color.Green;
                            lbStatus.Text = StatusContants.SUCCESSED_IN;
                            break;
                        case Process:
                            usrNotification.ShowMessage(NotificationType.Succeed, StatusContants.SUCCESS_OUT);
                            lbStatus.BackColor = Color.Teal;
                            lbStatus.Text = StatusContants.SUCCESSED_OUT;
                            break;
                        default:
                            usrNotification.ShowMessage(NotificationType.Failed, StatusContants.FAIL);
                            lbStatus.BackColor = Color.Salmon;
                            lbStatus.Text = StatusContants.FAIL;
                            break;

                    }

                    //string phone = new String(memberCus.PhoneNo.Where(Char.IsDigit).ToArray());
                    //string sms = string.Format("Thành viên {0} {1} cổng vào lúc {2} {3}.",
                    //    memberCus.GetFullName(), doorOut.Status == Success ? "vào" : "ra",
                    //    DateTime.Now.ToStringFormatDate(), DateTime.Now.ToString("hh:mm:ss"));
                    //VHTSmsService.Instance.SendSMS(phone, sms);
                }
            }
        }

        private void LoadManagerCost(long subOrgId)
        {
            try
            {
                ManagerCostApartment mc = ManagerCostsFactory.Instance.GetChannel().GetManagerCostBySubOrgId(session.Token, subOrgId);
                if (mc != null)
                {
                    if (mc.PayManager > 0 || mc.PayWater > 0)
                    {
                        lbManagerCost.Text = mc.PayManager.ToString("N0");
                        lbWaterCost.Text = mc.PayWater.ToString("N0");
                        lbManagerCostOld.Text = mc.ManagerCostOld.ToString("N0");
                        lbDatePayment.Text = mc.DayPay;
                    }
                    else
                    {
                        lbManagerCost.Text =
                        lbWaterCost.Text = string.Empty;
                    }
                }
            }
            catch (TimeoutException)
            {
                usrNotification.ShowMessage(NotificationType.Failed, CommonControls.CommonMessages.TimeOutExceptionMessage);
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                usrNotification.ShowMessage(NotificationType.Failed, ErrorCodes.GetErrorMessage(ex.Detail.Code));
            }
            catch (FaultException ex)
            {
                usrNotification.ShowMessage(NotificationType.Failed, CommonControls.CommonMessages.FaultExceptionMessage
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
            }
            catch (CommunicationException)
            {
                usrNotification.ShowMessage(NotificationType.Failed, CommonControls.CommonMessages.CommunicationExceptionMessage);
            }
        }

        //private void LoadMemberRelative()
        //{
        //    if (attendance != null && attendance.MemberId > 0)
        //    {
        //        List<MemberRelativeDto> memberRelativeList = new List<MemberRelativeDto>();
        //        try
        //        {
        //            memberRelativeList = OrganizationFactory.Instance.GetChannel().GetMemberRelativeList(session.Token, attendance.MemberId);
        //        }
        //        catch (TimeoutException)
        //        {
        //            usrNotification.ShowMessage(NotificationType.Failed, CommonControls.CommonMessages.TimeOutExceptionMessage);
        //        }
        //        catch (FaultException<WcfServiceFault> ex)
        //        {
        //            usrNotification.ShowMessage(NotificationType.Failed, ErrorCodes.GetErrorMessage(ex.Detail.Code));
        //        }
        //        catch (FaultException ex)
        //        {
        //            usrNotification.ShowMessage(NotificationType.Failed, CommonControls.CommonMessages.FaultExceptionMessage
        //                    + Environment.NewLine + Environment.NewLine
        //                    + ex.Message);
        //        }
        //        catch (CommunicationException)
        //        {
        //            usrNotification.ShowMessage(NotificationType.Failed, CommonControls.CommonMessages.CommunicationExceptionMessage);
        //        }
        //        finally
        //        {
        //            List<string> imageList = memberRelativeList.Select(mr => mr.ImgRelative).ToList();
        //            switch (imageList.Count)
        //            {
        //                case 1:
        //                    picContact1.Image = CommonHelper.Utils.ImageUtils.Base64ToImage(imageList[0]);
        //                    picContact2.Image = sAccessControl.Properties.Resources.NoImage;
        //                    picContact3.Image = sAccessControl.Properties.Resources.NoImage;
        //                    picContact4.Image = sAccessControl.Properties.Resources.NoImage;
        //                    break;
        //                case 2:
        //                    picContact1.Image = CommonHelper.Utils.ImageUtils.Base64ToImage(imageList[0]);
        //                    picContact2.Image = CommonHelper.Utils.ImageUtils.Base64ToImage(imageList[1]);
        //                    picContact3.Image = sAccessControl.Properties.Resources.NoImage;
        //                    picContact4.Image = sAccessControl.Properties.Resources.NoImage;
        //                    break;
        //                case 3:
        //                    picContact1.Image = CommonHelper.Utils.ImageUtils.Base64ToImage(imageList[0]);
        //                    picContact2.Image = CommonHelper.Utils.ImageUtils.Base64ToImage(imageList[1]);
        //                    picContact3.Image = CommonHelper.Utils.ImageUtils.Base64ToImage(imageList[2]);
        //                    picContact4.Image = sAccessControl.Properties.Resources.NoImage;
        //                    break;
        //                case 4:
        //                    picContact1.Image = CommonHelper.Utils.ImageUtils.Base64ToImage(imageList[0]);
        //                    picContact2.Image = CommonHelper.Utils.ImageUtils.Base64ToImage(imageList[1]);
        //                    picContact3.Image = CommonHelper.Utils.ImageUtils.Base64ToImage(imageList[2]);
        //                    picContact4.Image = CommonHelper.Utils.ImageUtils.Base64ToImage(imageList[3]);
        //                    break;
        //            }

        //            //foreach(MemberRelativeDto memberRelative in memberRelativeList)
        //            //{
        //            //    string phone = new String(memberRelative.Phone.Where(Char.IsDigit).ToArray());
        //            //    string sms = string.Format("Học sinh {0} {1} cổng vào lúc {2} {3}.",
        //            //        memberRelative.FullName, attendance.Status == Success ? "vào" : "ra",
        //            //        DateTime.Now.ToStringFormatDate(), DateTime.Now.ToString("hh:mm:ss"));
        //            //    VHTSmsService.Instance.SendSmsToListPhone(phone, sms);
        //            //}
        //        }
        //    }
        //}

        private void LabelEmpty()
        {
            lblCode.Text =
            lblFullName.Text =
            lblSubOrgName.Text =
            lblDate.Text =
            lblTime.Text =
            lbManagerCost.Text =
            lbWaterCost.Text =
            lbManagerCostOld.Text =
            lbPhone.Text =
            lbEmail.Text =
            lbDatePayment.Text =
            lbStatus.Text = "---";
            lbStatus.BackColor = Color.White;
        }

        private SubOrganization GetSubOrg(long subOrgId)
        {
            SubOrganization subOrg = new SubOrganization();
            try
            {
                subOrg = OrganizationFactory.Instance.GetChannel().GetSubOrgById(session.Token, subOrgId);
            }
            catch (TimeoutException)
            {
                usrNotification.ShowMessage(NotificationType.Failed, CommonControls.CommonMessages.TimeOutExceptionMessage);
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                usrNotification.ShowMessage(NotificationType.Failed, ErrorCodes.GetErrorMessage(ex.Detail.Code));
            }
            catch (FaultException ex)
            {
                usrNotification.ShowMessage(NotificationType.Failed, CommonControls.CommonMessages.FaultExceptionMessage
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
            }
            catch (CommunicationException)
            {
                usrNotification.ShowMessage(NotificationType.Failed, CommonControls.CommonMessages.CommunicationExceptionMessage);
            }
            return subOrg;
        }

        private bool IsBusy()
        {
            return bgwProcessCheckIn.IsBusy;
        }

        #endregion Parking processing

        //Không xử dụng
        #region Device Door
        private void InitTreeList()
        {
            rootNode = new TreeNode();
            rootNode.Text = "Thiết bị";
            rootNode.Name = "-1";
            trvDeviceList.Nodes.Add(rootNode);
        }

        //private void LoadDeviceList()
        //{
        //    if (!bgwLoadDeviceDoorList.IsBusy)
        //    {
        //        rootNode.Nodes.Clear();
        //        bgwLoadDeviceDoorList.RunWorkerAsync();
        //    }
        //}

        #endregion

        #endregion

        /// <summary>
        /// Các hàm kết nối với server và nhận dữ liệu từ server
        /// </summary>
        #region ReceiveMessages

        private void Connect()
        {
            // If we are not currently connected but awaiting to connect
            if (Connected == false)
            {
                // Initialize the connection
                InitializeConnection();
            }
            else // We are connected, thus disconnect
            {
                CloseConnection("Disconnected at user's request.");
            }
        }

        private void InitializeConnection()
        {
            // Start a new TCP connections to the chat server
            try
            {
                tcpServer = new TcpClient(AccessMessageServiceConfigSection.Instance.Ip, Convert.ToInt32(AccessMessageServiceConfigSection.Instance.Port));
            }
            catch
            {
                MessageBox.Show(CommonMessages.CannotConectServer);
                return;
            }

            // Send the desired username to the server
            swSender = new StreamWriter(tcpServer.GetStream());
            swSender.WriteLine(sAccessControl.Utils.StringUtils.GetRandomString(8));
            swSender.Flush();

            // Helps us track whether we're connected or not
            Connected = true;

            // Start the thread for receiving messages and further communication
            thrMessaging = new Thread(new ThreadStart(ReceiveMessages));
            thrMessaging.Start();
        }

        private void ReceiveMessages()
        {
            // Receive the response from the server
            srReceiver = new StreamReader(tcpServer.GetStream());
            // If the first character of the response is 1, connection was successful
            string ConResponse = srReceiver.ReadLine();
            // If the first character is a 1, connection was successful
            if (ConResponse[0] == '1')
            {
                // Update the form to tell it we are now connected
                this.Invoke(new UpdateLogCallback(this.UpdateLog), new object[] { "Connected Successfully!" });
            }
            else // If the first character is not a 1 (probably a 0), the connection was unsuccessful
            {
                string Reason = "Not Connected: ";
                // Extract the reason out of the response message. The reason starts at the 3rd character
                Reason += ConResponse.Substring(2, ConResponse.Length - 2);
                // Update the form with the reason why we couldn't connect
                this.Invoke(new CloseConnectionCallback(this.CloseConnection), new object[] { Reason });
                // Exit the method
                return;
            }
            // While we are successfully connected, read incoming lines from the server
            while (Connected)
            {
                try
                {
                    // Show the messages in the log TextBox
                    this.Invoke(new UpdateLogCallback(this.UpdateLog), new object[] { srReceiver.ReadLine() });
                }
                catch (Exception ex)
                {
                    Connected = false;
                    MessageBox.Show(CommonMessages.CannotConectServer);
                }

               
            }
        }

        // This method is called from a different thread in order to update the log TextBox
        private void UpdateLog(string message)
        {
            if (null == message)
                return;

            string[] value = message.Split('-');
            if (Regex.IsMatch((value[0]),@"^\d+$"))
            {
                //Show thong tin member
                doorOut = new DoorOut() { 
                    MemberId = value.Length > 0 ? Convert.ToInt64(value[0]) : 0,
                    Status = value.Length > 1 ? Convert.ToInt32(value[1]) : Failed
                };
                LoadMember();
            }
        }

        // Closes a current connection
        private void CloseConnection(string Reason)
        {
            // Close the objects
            Connected = false;
            swSender.Close();
            srReceiver.Close();
            tcpServer.Close();
        }

        private string LocalIPAddress()
        {
            IPHostEntry host;
            string localIP = "";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.ToString();
                    break;
                }
            }
            return localIP;
        }

        #endregion
    }
}
