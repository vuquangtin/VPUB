using sAccessControl.Enums;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace sAccessControl.View
{
    internal class UsrDeviceStatus : UserControl
    {
        private DeviceState currentState = DeviceState.NotUsed;

        private readonly Color NotUsedForeColor = Color.Gray;
        private readonly Color IncorrectConfigColor = Color.Gray;
        private readonly Color ConnectingForeColor = Color.FromArgb(64, 64, 64);
        private readonly Color ConnectedForeColor = Color.FromArgb(0, 128, 0);
        private readonly Color DisconnectedForeColor = Color.FromArgb(192, 0, 0);
        private Button btnDisconnect;
        private Panel panel1;
        private Button btnConnect;
        private Label lblMessage;
        private readonly Color PausedForeColor = Color.FromArgb(192, 64, 0);

        [Category("Appearance")]
        public DeviceState State
        {
            get
            {
                return currentState;
            }
            set
            {
                currentState = value;
                UpdateView();
            }
        }

        public event EventHandler ItemConnectClicked;
        public event EventHandler ItemDisconnectClicked;

        public UsrDeviceStatus()
        {
            InitializeComponent();

            UpdateView();

            btnConnect.Click += (s, e) =>
                {
                    if (ItemConnectClicked != null)
                    {
                        ItemConnectClicked(this, EventArgs.Empty);
                    }
                };

            btnDisconnect.Click += (s, e) =>
                {
                    if (ItemDisconnectClicked != null)
                    {
                        ItemDisconnectClicked(this, EventArgs.Empty);
                    }
                };
        }

        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(145, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(5, 25);
            this.panel1.TabIndex = 1;
            // 
            // lblMessage
            // 
            this.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblMessage.Location = new System.Drawing.Point(0, 0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(120, 25);
            this.lblMessage.TabIndex = 3;
            this.lblMessage.Text = "Không sử dụng";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnPlay
            // 
            this.btnConnect.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnConnect.Enabled = false;
            this.btnConnect.Image = global::sAccessControl.Properties.Resources.Play_16x16;
            this.btnConnect.Location = new System.Drawing.Point(120, 0);
            this.btnConnect.Name = "btnPlay";
            this.btnConnect.Size = new System.Drawing.Size(25, 25);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.UseVisualStyleBackColor = true;
            // 
            // btnPause
            // 
            this.btnDisconnect.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Image = global::sAccessControl.Properties.Resources.Pause_16x16;
            this.btnDisconnect.Location = new System.Drawing.Point(150, 0);
            this.btnDisconnect.Name = "btnPause";
            this.btnDisconnect.Size = new System.Drawing.Size(25, 25);
            this.btnDisconnect.TabIndex = 0;
            this.btnDisconnect.UseVisualStyleBackColor = true;
            // 
            // DeviceStatusLabel
            // 
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnDisconnect);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(146, 32);
            this.Name = "DeviceStatusLabel";
            this.Size = new System.Drawing.Size(175, 25);
            this.ResumeLayout(false);

        }

        private void UpdateView()
        {
            //if (!IsHandleCreated)
            //{
            //    return;
            //}

            if (InvokeRequired)
            {
                Invoke(new Action(UpdateView));
                return;
            }

            switch(currentState)
            {
                case DeviceState.Connecting:
                    lblMessage.Text = "Đang kết nối...";
                    lblMessage.ForeColor = ConnectingForeColor;
                    btnConnect.Enabled = false;
                    btnDisconnect.Enabled = false;
                    break;

                case DeviceState.Connected:
                    lblMessage.Text = "Đã kết nối";
                    lblMessage.ForeColor = ConnectedForeColor;
                    btnConnect.Enabled = false;
                    btnDisconnect.Enabled = true;
                    break;

                case DeviceState.Disconnected:
                    lblMessage.Text = "Mất kết nối";
                    lblMessage.ForeColor = DisconnectedForeColor;
                    btnConnect.Enabled = true;
                    btnDisconnect.Enabled = false;
                    break;

                case DeviceState.DisconnectedByUser:
                    lblMessage.Text = "Tạm ngưng";
                    lblMessage.ForeColor = PausedForeColor;
                    btnConnect.Enabled = true;
                    btnDisconnect.Enabled = false;
                    break;

                case DeviceState.IncorrectConfig:
                    lblMessage.Text = "Cấu hình sai";
                    lblMessage.ForeColor = IncorrectConfigColor;
                    btnConnect.Enabled = btnDisconnect.Enabled = false;
                    break;

                default:
                    lblMessage.Text = "Không sử dụng";
                    lblMessage.ForeColor = NotUsedForeColor;
                    btnConnect.Enabled = btnDisconnect.Enabled = false;
                    break;
            }
        }
    }
}