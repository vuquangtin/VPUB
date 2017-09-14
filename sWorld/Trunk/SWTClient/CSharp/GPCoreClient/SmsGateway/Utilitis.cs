using RestSharp;
using SMSGaywate.HttpRequest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace SMSGaywate
{
    public class Utilites
    {
        private Utilites() { }
        private static readonly Utilites instance = new Utilites();
        public static Utilites Instance
        {
            get
            {
                return instance;
            }
        }
        public String Paramater(params object[] list)
        {
            StringBuilder builder = new StringBuilder();
            foreach (object obj in list)
            {
                builder.AppendFormat("&" + obj.ToString());
            }

            return builder.ToString().Remove(0,1);
        }


        /// <summary>
        /// Tao url de call service sms
        /// </summary>
        /// <param name="baseUrl">url sms service</param>
        /// <param name="method">function name</param>
        /// <param name="para">paramater of function</param>
        /// <returns></returns>
        public String Url(String baseUrl, String method, String parone)
        {
            return String.Format(@"{0}{1}?{2}", baseUrl, method, parone);
        }

        /// <summary>
        /// Tao url de call service sms
        /// </summary>
        /// <param name="baseUrl">url sms service</param>
        /// <param name="method">function name</param>
        /// <returns></returns>
        public String Url(String baseUrl, String method)
        {
            return String.Format(@"{0}{1}", baseUrl, method);
        }

        public int GetDataFromServerByUrl(String url, Dictionary<string, string> paras)
        {
            HttpHandler handler = new HttpHandler();
            HttpWebResponse response = handler.Get(url, paras);
            return ReadResponse(response);
        }
        static int ReadResponse(HttpWebResponse response)
        {
            string result = string.Empty;
            XmlDocument xml = new XmlDocument();

            var stream = response.GetResponseStream();
            var reader = new StreamReader(stream);

            xml.LoadXml(reader.ReadToEnd());
            result = xml.DocumentElement.InnerText;

            return Convert.ToInt32(result);
        }
    }
}
