using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace SMSGaywate.HttpRequest
{
    public class HttpHandler
    {
        private RequestBuilder builder;

        public event EventHandler<GenericEventArgs<HttpWebResponse>> RequestCompleted;

        public void Post(string uri, Dictionary<string, string> parameters)
        {
            builder = new PostRequestBuilder();
            var request = builder.BuildRequest(uri, parameters);

            //Wait for request to return before exiting
            ProcessRequest(request);
        }

        public void PostAsync(string uri, Dictionary<string, string> parameters)
        {
            builder = new PostRequestBuilder();
            var request = builder.BuildRequest(uri, parameters);

            //Don't bother waiting - if it is there, it is there
            Task.Factory.StartNew(() => ProcessRequest(request));
        }

        public HttpWebResponse Get(string uri)
        {
            builder = new RequestBuilder();
            var request = builder.BuildRequest(uri);

            return ProcessRequest(request);
        }

        public void GetAsync(string uri)
        {
            builder = new RequestBuilder();
            var request = builder.BuildRequest(uri);

            Task.Factory.StartNew(() => ProcessRequest(request));
        }

        public HttpWebResponse Get(string uri, Dictionary<string, string> parameters)
        {
            builder = new RequestBuilder();
            var request = builder.BuildRequest(uri, parameters);

            return ProcessRequest(request);
        }

        public void GetAsync(string uri, Dictionary<string, string> parameters)
        {
            builder = new RequestBuilder();
            var request = builder.BuildRequest(uri, parameters);

            Task.Factory.StartNew(() => ProcessRequest(request));
        }

        private HttpWebResponse ProcessRequest(HttpWebRequest request)
        {
            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                OnRequestCompleted(response);
                return response;
            }
            catch (Exception ex)
            {
                var exception = new ApplicationException(String.Format("Request failed for Url: {0}", request.RequestUri), ex);
                throw exception;
            }
        }

        protected void OnRequestCompleted(HttpWebResponse response)
        {
            if (null != RequestCompleted)
                RequestCompleted(this, new GenericEventArgs<HttpWebResponse>(response));
        }
    }
}
