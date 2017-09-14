using CommonHelper.Config;
using CommonHelper.Utils;
using JavaCommunication.Factory;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SMSGaywate
{
    public class SaveSession
    {
        private System.Windows.Forms.Timer timer = null;

        public string UserName { get; set; }
        public string Password { get; set; }
        public string session { get; set; }
        /// <summary>
        /// When client send a message with length message > 160 characters then message will be split.
        /// 1 SMS : <= 160 characters
        /// 2 SMS: >= 161 and <= 306 characters
        ///  3 SMS: >= 307 and <= 459 character
        /// </summary>
        private static SaveSession instance = new SaveSession();
        public static SaveSession Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SaveSession();
                }
                return instance;
            }
        }

        protected SaveSession()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 60000 * 10;
            timer.Tick += timer_Tick;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                SessionDTO user = AuthenticationFactory.Instance.GetChannel().Login(UserName, Password);
                if (session != null)
                {
                    session = user.Token;
                }
            }
            catch (Exception ex) 
            {
                
            }
        }

        public void Start() 
        {
            timer.Enabled = true;
            timer.Start();
        }
        public void Stop() 
        {
            if (timer.Enabled)
            {
                timer.Stop();
            }
        }

    }
}
