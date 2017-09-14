using sAccessControl.Common;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace ParkingProcessComponent.View
{
    internal partial class UsrNotification : CommonUserControl
    {
        private System.Windows.Forms.Timer timer = null;

        private readonly Color SucceedColor = Color.FromArgb(0, 128, 0);    // Green
        private readonly Color FailedColor = Color.FromArgb(255, 0, 0);     // Red
        private readonly Color WarningColor = Color.FromArgb(192, 192, 0);     // Yelow

        private readonly Font LargeSizeFont = null;
        private readonly Font SmallSizeFont = null;

        public UsrNotification()
        {
            InitializeComponent();

            LargeSizeFont = new Font(this.Font.Name, 20.25f);
            SmallSizeFont = new Font(this.Font.Name, 12f);

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 3000;
            timer.Tick += timer_Tick;
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (timer.Enabled)
                {
                    timer.Stop();
                }

                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.Visible = false;
            timer.Stop();
        }

        public void ShowMessage(NotificationType type, string message)
        {
            Monitor.Enter(this);

            if (timer.Enabled)
            {
                timer.Stop();
            }

            switch (type)
            {
                case NotificationType.Failed:
                    this.BackColor = FailedColor;
                    break;
                case NotificationType.Succeed:
                    this.BackColor = SucceedColor;
                    break;
                case NotificationType.Warning:
                    this.BackColor = WarningColor;
                    break;
                default:
                    break;
            }

            if (message.Length > 50)
            {
                if (label1.Font != SmallSizeFont)
                {
                    label1.Font = SmallSizeFont;
                }
            }
            else
            {
                if (label1.Font != LargeSizeFont)
                {
                    label1.Font = LargeSizeFont;
                }
            }
            label1.Text = message.ToUpper();
            this.Visible = true;

            timer.Start();

            Monitor.Exit(this);
        }
    }


    internal enum NotificationType
    {
        Succeed = 1,
        Failed = 2,
        Warning = 3,
    }
}