using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ReaderManager.Contants;
using System.Threading;
using ReaderManager.Model;
using CommonHelper.Config;
using ReaderManager.Enum;
using ReaderManager.Pcsc;

namespace ReaderManager.View
{
    public partial class UrsReaderTag : UserControl
    {
        #region Properties

        private System.Windows.Forms.Timer timer = null;
        public IReader reader { get; set; }

        public event TagDetectedHandler TagDetected;

        #endregion
        public UrsReaderTag()
        {
            InitializeComponent();
            this.Font = DefaultStyle.PanelFont;
            this.Padding = new Padding(5, 5, 5, 5);
            this.BackColor = DefaultStyle.PanelBackColor;
            this.Dock = DockStyle.Fill;

            btnConnect.Click += btnConnect_Click;
            btnDisconnect.Click += btnDisconnect_Click;

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 3000;
            timer.Tick += timer_Tick;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateView(DeviceState.Disconnected);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            ShowNotificationEmpty();
            timer.Stop();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            ConnectReaderAndWaitForCard();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            if (reader != null)
            {
                reader.Disconnect();
                UpdateView(DeviceState.Disconnected);
            }
        }

        #region Reader event's

        public void Start()
        {
            if (!btnConnect.Enabled)
                return;
            Stop();
            ConnectReaderAndWaitForCard();
        }

        public void Stop()
        {
            if (reader != null)
            {
                //remove event
                reader.Disconnected -= reader_Disconnected;
                reader.TagDetected -= reader_TagDetected;

                reader.Disconnect();
                reader = null;
                UpdateView(DeviceState.Disconnected);
            }
        }

        private void ConnectReaderAndWaitForCard()
        {
            UpdateView(DeviceState.Connecting);

            // Khởi tạo (hoặc cập nhật) reader
            if (reader != null)
            {
                if (reader.Type == (ReaderType)ReaderSettings.Instance.Type)
                {
                    if (reader.Address != Convert.ToByte(ReaderSettings.Instance.Address))
                    {
                        try
                        {
                            reader.ChangeReaderAddress(Convert.ToByte(ReaderSettings.Instance.Address));
                        }
                        catch (ReaderException)
                        {
                            UpdateView(DeviceState.Disconnected);
                            return;
                        }
                    }
                }
                else
                {
                    try
                    {
                        reader.Disconnect();
                    }
                    catch (ReaderException)
                    {
                        UpdateView(DeviceState.Disconnected);
                        return;
                    }
                    reader = ReaderFactory.GetInstance().Register((ReaderType)ReaderSettings.Instance.Type, Convert.ToByte(ReaderSettings.Instance.Address), ReaderSettings.Instance.BeepOnTagDetected);
                }
            }
            else
            {
                reader = ReaderFactory.GetInstance().Register((ReaderType)ReaderSettings.Instance.Type, Convert.ToByte(ReaderSettings.Instance.Address), ReaderSettings.Instance.BeepOnTagDetected);
            }

            bool connected = false;
            try
            {
                connected = reader.Connect();
            }
            catch (ReaderException)
            {
                UpdateView(DeviceState.Disconnected);
                return;
            }

            if (connected)
            {
                UpdateView(DeviceState.Connected);
                reader.Disconnected += reader_Disconnected;
                reader.TagDetected += reader_TagDetected;
                reader.StartCardDetection();
            }
            else
            {
                UpdateView(DeviceState.Disconnected);
            }
        }

        private void reader_TagDetected(byte[] cardId)
        {
            // Chuyển cardId từ mảng byte sang kiểu uint
            //long cardIdUint = BitConverter.ToUInt32(cardId, 0);
            //SerialNumber = CommonHelper.Utils.StringUtils.ByteArrayToHexString(cardId);

            ShowNotificationWarning(MessageReaderContants.Processing);

            if (TagDetected != null)
            {
                // Raise event
                TagDetected(cardId);
            }
        }

        private void reader_Disconnected()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(reader_Disconnected));
                return;
            }

            UpdateView(DeviceState.Disconnected);
        }

        #endregion

        #region Reader support's

        public void ShowNotificationSuccess(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(ShowNotificationSuccess), message);
                return;
            }

            Monitor.Enter(this);
            if (timer.Enabled)
                timer.Stop();

            lbMessage.Text = message.ToUpper();
            lbMessage.BackColor = DefaultStyle.NotificationSucceedColor;
            lbMessage.Font = DefaultStyle.NotificationFont;

            if (reader != null)
                reader.Beep(1);

            timer.Start();
            Monitor.Exit(this);
        }

        public void ShowNotificationSuccess()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(ShowNotificationSuccess));
                return;
            }
            Monitor.Enter(this);
            if (timer.Enabled)
                timer.Stop();

            lbMessage.Text = MessageReaderContants.Successed.ToUpper();
            lbMessage.BackColor = DefaultStyle.NotificationSucceedColor;
            lbMessage.Font = DefaultStyle.NotificationFont;

            if (reader != null)
                reader.Beep(1);

            timer.Start();
            Monitor.Exit(this);
        }

        public void ShowNotificationSuccessIn()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(ShowNotificationSuccessIn));
                return;
            }

            Monitor.Enter(this);
            if (timer.Enabled)
                timer.Stop();

            lbMessage.Text = MessageReaderContants.SuccessedIn.ToUpper();
            lbMessage.BackColor = DefaultStyle.NotificationSucceedColor;
            lbMessage.Font = DefaultStyle.NotificationFont;

            if (reader != null)
                reader.Beep(1);

            timer.Start();
            Monitor.Exit(this);
        }

        public void ShowNotificationSuccessOut()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(ShowNotificationSuccessOut));
                return;
            }

            Monitor.Enter(this);
            if (timer.Enabled)
                timer.Stop();

            lbMessage.Text = MessageReaderContants.SuccessedOut.ToUpper();
            lbMessage.BackColor = DefaultStyle.NotificationSucceedColor;
            lbMessage.Font = DefaultStyle.NotificationFont;

            if (reader != null)
                reader.Beep(1);

            timer.Start();
            Monitor.Exit(this);
        }

        public void ShowNotificationFail(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(ShowNotificationFail), message);
                return;
            }

            Monitor.Enter(this);
            if (timer.Enabled)
                timer.Stop();

            lbMessage.Text = message.ToUpper();
            lbMessage.BackColor = DefaultStyle.NotificationFailedColor;
            lbMessage.Font = DefaultStyle.NotificationFont;

            if (reader != null)
                reader.Beep(2);

            timer.Start();
            Monitor.Exit(this);
        }

        public void ShowNotificationFail()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(ShowNotificationFail));
                return;
            }

            Monitor.Enter(this);
            if (timer.Enabled)
                timer.Stop();

            lbMessage.Text = MessageReaderContants.Failed.ToUpper();
            lbMessage.BackColor = DefaultStyle.NotificationFailedColor;
            lbMessage.Font = DefaultStyle.NotificationFont;

            if (reader != null)
                reader.Beep(2);

            timer.Start();
            Monitor.Exit(this);
        }

        public void ShowNotificationWarning(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(ShowNotificationWarning), message);
                return;
            }

            Monitor.Enter(this);
            if (timer.Enabled)
                timer.Stop();

            lbMessage.Text = message.ToUpper();
            lbMessage.BackColor = DefaultStyle.NotificationWarningColor;
            lbMessage.Font = DefaultStyle.NotificationFont;

            timer.Start();
            Monitor.Exit(this);
        }

        public void ShowNotificationEmpty()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(ShowNotificationEmpty));
                return;
            }

            Monitor.Enter(this);
            if (timer.Enabled)
                timer.Stop();

            lbMessage.Text = string.Empty;
            lbMessage.BackColor = DefaultStyle.NotificationWarningColor;
            lbMessage.Font = DefaultStyle.NotificationFont;

            timer.Start();
            Monitor.Exit(this);
        }

        private void UpdateView(DeviceState currentState)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<DeviceState>(UpdateView), currentState);
                return;
            }

            String readerName = ReaderTypeExt.GetName((ReaderType)ReaderSettings.Instance.Type);
            switch (currentState)
            {
                case DeviceState.Connecting:
                    ShowNotificationWarning(MessageReaderContants.Connecting);
                    lbReaderName.Text = readerName + " - " + MessageReaderContants.Connecting;
                    btnConnect.Enabled = false;
                    btnDisconnect.Enabled = false;
                    break;

                case DeviceState.Connected:
                    ShowNotificationWarning(MessageReaderContants.WaitingTag);
                    lbReaderName.Text = readerName + " - " + MessageReaderContants.Connected;
                    btnConnect.Enabled = false;
                    btnDisconnect.Enabled = true;
                    break;

                case DeviceState.Disconnected:
                    ShowNotificationWarning(MessageReaderContants.Disconnected);
                    lbReaderName.Text = readerName + " - " + MessageReaderContants.Disconnected;
                    btnConnect.Enabled = true;
                    btnDisconnect.Enabled = false;
                    break;

                case DeviceState.DisconnectedByUser:
                    ShowNotificationWarning(MessageReaderContants.DisconnectedByUser);
                    lbReaderName.Text = readerName + " - " + MessageReaderContants.DisconnectedByUser;
                    btnConnect.Enabled = true;
                    btnDisconnect.Enabled = false;
                    break;

                case DeviceState.IncorrectConfig:
                    ShowNotificationWarning(MessageReaderContants.IncorrectConfig);
                    lbReaderName.Text = readerName + " - " + MessageReaderContants.IncorrectConfig;
                    btnConnect.Enabled = btnDisconnect.Enabled = false;
                    break;

                default:
                    ShowNotificationWarning(MessageReaderContants.NotUsed);
                    lbReaderName.Text = readerName + " - " + MessageReaderContants.NotUsed;
                    btnConnect.Enabled = btnDisconnect.Enabled = false;
                    break;
            }
        }

        #endregion
    }
}
