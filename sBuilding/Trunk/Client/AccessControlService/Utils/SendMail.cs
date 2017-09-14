using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace AccessControlService.Utils
{
    public class SendMail
    {
        private static SendMail instance = new SendMail();
        public static SendMail Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SendMail();
                }
                return instance;
            }
        }
        public SendMail() { }

        public void GuiThu(string diachigui, string matkhau, string diachinhan, string tieude, string noidung)
        {
            //using System.Net.Mail;  
            //using System.Net;  
            #region Tạo nội dung thư
            MailMessage mail = new MailMessage(diachigui, diachinhan, tieude, noidung);
            #endregion

            #region Cấu hình smtp
            SmtpClient smtp = new SmtpClient()
            {
                //Máy chủ smtp  
                Host = "smtp.gmail.com",
                //Cổng gửi thư  
                Port = 587,
                //Tài khoản Gmail  
                Credentials = new NetworkCredential(diachigui, matkhau),
                EnableSsl = true
            };
            #endregion

            #region Gửi thư
            smtp.Send(mail);
            #endregion
        }
    }
}
