using CommonControls.Custom;
using System;
using System.Configuration;
using System.Drawing;
using System.Threading;

namespace sNonResidentComponent.WorkItems
{
    internal partial class UsrNotification : CommonUserControl
    {
        private System.Windows.Forms.Timer timer = null;

        private readonly Color SucceedColor = Color.FromArgb(0, 128, 0);    // Green
        private readonly Color FailedColor = Color.FromArgb(255, 0, 0);     // Red

        private readonly Font LargeSizeFont = null;
        private readonly Font SmallSizeFont = null;

        public UsrNotification()
        {
            InitializeComponent();

            LargeSizeFont = new Font(this.Font.Name, 20.25f);
            SmallSizeFont = new Font(this.Font.Name, 12f);

            timer = new System.Windows.Forms.Timer();

           

            timer.Interval = SetTime();
            timer.Tick += timer_Tick;
        }

        public int SetTime()
        {
            #region settime
            string timerStr = "";
            int timerInt = 3000;
            try
            {
                timerStr = ConfigurationManager.AppSettings["timer"];
            }
            catch (Exception ex)
            {
            }
            if (timerStr != null)
            {

                if (timerStr.Equals(""))
                {
                    timerInt = 3000;
                }
                else
                {
                    timerInt = Convert.ToInt32(timerStr);
                }
            }
            return timerInt;

            #endregion
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

            switch(type)
            {
                case NotificationType.Failed:
                    this.BackColor = FailedColor;
                    break;
                case NotificationType.Succeed:
                    this.BackColor = SucceedColor;
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
    }
}