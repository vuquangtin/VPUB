using System;
using System.Collections.Generic;
using System.Net;

namespace SMSGaywate.HttpRequest
{
    public class RequestBuilder
    {
        public HttpWebRequest BuildRequest(string uri)
        {
            var request = (HttpWebRequest)WebRequest.Create(uri);

            request.UserAgent =
                "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; WOW64; Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; InfoPath.2; .NET CLR 1.1.4322; .NET4.0C; .NET4.0E)";

            return request;
        }

        public virtual HttpWebRequest BuildRequest(string uri, Dictionary<string, string> parameters)
        {
            string query = CreateRequestString(parameters);
            string url = String.Format("{0}?{1}", uri, query);

            return BuildRequest(url);
        }

        protected string CreateRequestString(Dictionary<string, string> parameters)
        {
            return parameters.Join("&", "=");
        }
    }
}
