using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace SMSGaywate.HttpRequest
{
    public class PostRequestBuilder : RequestBuilder
    {
        public override HttpWebRequest BuildRequest(string uri, Dictionary<string, string> parameters)
        {
            var request = BuildRequest(uri);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            string query = CreateRequestString(parameters);

            WritePostData(request, query);

            return request;
        }

        private void WritePostData(HttpWebRequest postRequest, string postString)
        {
            byte[] postBytes = Encoding.ASCII.GetBytes(postString);

            Stream postStream = postRequest.GetRequestStream();
            postStream.Write(postBytes, 0, postBytes.Length);
            postStream.Close();
        }
    }
}
