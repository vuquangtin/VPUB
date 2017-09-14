using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using RestSharp;
using CommonHelper.Config;

namespace JavaCommunication.Common
{
    public class CommunicationCommon
    {
        protected CommunicationCommon()
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
            return SystemSettings.Instance.JavaWebService;
        }

        /// <summary>
        /// get data from server with parameters 
        /// </summary>
        /// <param name="method">name of method</param>
        /// <param name="parameters">parameters</param>
        /// <param name="type">type object return from server</param>
        /// <returns></returns>
        public virtual Object GetDataFromServer(String session, String method, String parameters, Type type)
        {
            String url = Utilites.Instance.Url(_baseUrl, method, parameters);
            return Utilites.Instance.GetDataFromServerByUrl(session, url, type);
        }
        
        //public virtual Object GetDataFromServerTest(String method, String parameters)
        //{
        //    String url = Utilites.Instance.Url(_baseUrl, method, parameters);
        //    return Utilites.Instance.GetDataFromServerByUrlTest(session, url);
        //}

        public virtual int GetDataFromServer(String session, String method, String parameters)
        {
            String url = Utilites.Instance.Url(_baseUrl, method, parameters);
            return Utilites.Instance.GetDataFromServerByUrl(session, url);
        }

        public virtual int GetDataObjectFromServer(String session, String method, String parameters)
        {
            String url = Utilites.Instance.Url(_baseUrl, method, parameters);
            return Utilites.Instance.GetDataFromServerByUrl(session, url, true);
        }

        public virtual int PostDataFromServer(String session, String method, String parameters,Object obj)
        {
            String url = Utilites.Instance.Url(_baseUrl, method, parameters);
            return Utilites.Instance.PostDataFromServerByUrl(session, url, obj);
        }

        /// <summary>
        /// post data to server
        /// </summary>
        /// <param name="method">name of method </param>
        /// <param name="obj"> data post to server</param>
        /// <param name="type"> type object return from server</param>
        /// <returns></returns>
        public virtual Object PostDataToServerObject(String session, String method, Object obj, Type type)
        {
            String url = Utilites.Instance.Url(_baseUrl, method);
            return Utilites.Instance.PostDataToServerByUrl(session, url, obj, type);
        }

        /// <summary>
        /// Kiểm tra url
        /// </summary>
        /// <param name="method">name of method</param>
        /// <param name="parameters"></param>
        /// <param name="objects"></param>
        /// <param name="type">type object return from server</param>
        /// <returns></returns>
        public virtual Object PostDataToServerObject(String session, String method, String parameters, Object objects, Type type)
        {
            String url = Utilites.Instance.Url(_baseUrl, method, parameters);
            return Utilites.Instance.PostDataToServerByUrl(session, url, objects, type);
        }
    }
}
