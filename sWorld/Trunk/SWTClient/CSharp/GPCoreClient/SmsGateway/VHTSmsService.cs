using CommonHelper.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMSGaywate
{
    public class VHTSmsService
    {
        /// <summary>
        /// When client send a message with length message > 160 characters then message will be split.
        /// 1 SMS : <= 160 characters
        /// 2 SMS: >= 161 and <= 306 characters
        ///  3 SMS: >= 307 and <= 459 character
        /// </summary>
        private static VHTSmsService instance = new VHTSmsService();
        public static VHTSmsService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new VHTSmsService();
                }
                return instance;
            }
        }

        protected VHTSmsService()
        {
            BaseURL();
        }
        protected String _baseUrl = String.Empty;
        protected virtual void BaseURL()
        {
            if (String.IsNullOrEmpty(_baseUrl))
                _baseUrl = ReadUrl();
        }

        private String ReadUrl()
        {
            return SmsSettings.Instance.SMSService;
        }

        public bool SendSMS(string phone, string sms)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>
                                {
                                    {"code", SmsSettings.Instance.CodeAPI},
                                    {"account", SmsSettings.Instance.Account},
                                    {"phone", phone},
                                    {"from", SmsSettings.Instance.From},
                                    {"sms", sms}
                                };
            String url = Utilites.Instance.Url(_baseUrl, VHTMethodName.SendSMS);
            return Utilites.Instance.GetDataFromServerByUrl(url, parameters) > 0;
        }

        /// <summary>
        /// Gửi tin nhắn với danh sách Phone
        /// </summary>
        /// <param name="code">Mã Code nhà cung cấp đầu số</param>
        /// <param name="account">Tài khoản nhà cung cấp</param>
        /// <param name="phoneList">Example: phone1,phone2,phone3</param>
        /// <param name="sender"></param>
        /// <param name="sms">Nội dung tin nhắn</param>
        /// <returns></returns>
        public bool SendSmsToListPhone(string phoneList, string sms)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>
                                {
                                    {"code", SmsSettings.Instance.CodeAPI},
                                    {"account", SmsSettings.Instance.Account},
                                    {"phones", phoneList},
                                    {"sender", SmsSettings.Instance.From},
                                    {"sms", sms}
                                };
            String url = Utilites.Instance.Url(_baseUrl, VHTMethodName.SendSmsToListPhone);
            return Utilites.Instance.GetDataFromServerByUrl(url, parameters) > 0;
        }
    }
}
