using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using sWorldModel.Model;
using Newtonsoft.Json.Linq;

namespace JavaCommunication
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

        public String Paramater()
        {
            return String.Empty;
        }

        //public String Paramater(String para1)
        //{
        //    return String.Format(@"{0}", para1);
        //}

        //public String Paramater(String para1, String para2)
        //{
        //    return String.Format(@"{0}/{1}", para1, para2);
        //}

        //public String Paramater(String para1, String para2, String para3)
        //{
        //    return String.Format(@"{0}/{1}/{2}", para1, para2, para3);
        //}

        //public String Paramater(String para1, String para2, String para3, String para4)
        //{
        //    return String.Format(@"{0}/{1}/{2}/{3}", para1, para2, para3, para4);
        //}

        //public String Paramater(String para1, String para2, String para3, String para4, String para5)
        //{
        //    return String.Format(@"{0}/{1}/{2}/{3}/{4}", para1, para2, para3, para4, para5);
        //}

        public String Paramater(params object[] list)
        {
            StringBuilder builder = new StringBuilder();
            foreach (object obj in list)
            {
                if (null == obj)
                    continue;

                builder.AppendFormat("/" + obj.ToString());
            }

            return builder.ToString();
        }

        public Object ParObject(params Object[] obj1)
        {
            List<Object> result = new List<Object>();
            result.AddRange(obj1);
            return result;
        }

        //public Object ParObject(Object obj1, Object obj2)
        //{
        //    return new List<Object>() { obj1, obj2 };
        //}

        //public Object ParObject(Object obj1, Object obj2, Object obj3)
        //{
        //    return new List<Object>() { obj1, obj2, obj3 };
        //}

        //public Object ParObject(Object obj1, Object obj2, Object obj3, Object obj4)
        //{
        //    return new List<Object>() { obj1, obj2, obj3, obj4 };
        //}

        //public Object ParObject(Object obj1, Object obj2, Object obj3, Object obj4, Object obj5)
        //{
        //    return new List<Object>() { obj1, obj2, obj3, obj4, obj5 };
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseurl"></param>
        /// <param name="method"></param>
        /// <param name="parone"></param>
        /// <param name="partwo"></param>
        /// <returns></returns>
        public String Url(String baseurl, String method, String parone, String partwo)
        {
            return String.Format(@"{0}/{1}/{2}{3}", baseurl, method, parone, partwo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseurl"></param>
        /// <param name="method"></param>
        /// <param name="parone"></param>
        /// <returns></returns>
        public String Url(String baseurl, String method, String parone)
        {
            return String.Format(@"{0}/{1}{2}", baseurl, method, parone);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="baseurl"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public String Url(String baseurl, String method)
        {
            return String.Format(@"{0}/{1}", baseurl, method);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public String Url()
        {

            return null;
        }

        //public Object GetDataFromServerByUrlTest(String session, String url)
        //{
        //    RestClient client = new RestClient(url);
        //    RestRequest request = new RestRequest(Method.GET);
        //    request.AddCookie(StrConst.SESSIONID, session);
        //    request.AddHeader("Content-type", "application/json; charset=utf-8");
        //    request.RequestFormat = DataFormat.Json;
        //    RestResponse response = (RestResponse)client.Execute(request);

        //    Object result = null;
        //    switch (response.StatusCode)
        //    {
        //        case HttpStatusCode.OK:
        //            var temp = JsonConvert.DeserializeObject(response.Content, new ResultObject().GetType()) as ResultObject;
        //            if (null != temp)
        //            {
        //                MasterInfoDTO aaa = new MasterInfoDTO();
        //                aaa.MasterId = 1;
        //                aaa.Name = "asdfasdf";
        //                aaa.OrgShortName = "ggg";
        //                aaa.key = "dddd";
        //                aaa.code = "asdfasdf";

        //                List<CardTypeDTO> bbb = new List<CardTypeDTO>();
        //                CardTypeDTO ccc = new CardTypeDTO();
        //                ccc.cardTypeID = 1;
        //                ccc.cardHigh = "11111";
        //                ccc.cardLow = "000";
        //                ccc.cardTypeName = "121";
        //                ccc.pinLength = 3;
        //                ccc.prefix  ="2222";
        //                bbb.Add(ccc);


        //                aaa.cardtypes = bbb;


        //                 String strb = JsonConvert.SerializeObject(aaa);


        //                 result = JsonConvert.DeserializeObject(temp.obj.ToString(), new MasterInfoDTO().GetType()) as MasterInfoDTO;
        //                //String str = JsonConvert.SerializeObject(temp.obj);
        //                //var results = JsonConvert.DeserializeObject<dynamic>(temp.obj.ToString());
                        
        //                System.Web.Script.Serialization.JavaScriptSerializer jsSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        //                MasterInfoDTO photos = jsSerializer.Deserialize<MasterInfoDTO>(temp.obj.ToString());

        //            }
        //            break;
        //        case HttpStatusCode.InternalServerError:
        //            break;
        //        case HttpStatusCode.BadRequest:
        //            break;
        //    }
        //    return result;
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public Object GetDataFromServerByUrl(String session, String url, Type type)
        {
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest(Method.GET);
            request.AddCookie(StrConst.SESSIONID, session);
            request.AddHeader("Content-type", "application/json; charset=utf-8");
            request.RequestFormat = DataFormat.Json;
            RestResponse response = (RestResponse)client.Execute(request);

            Object result = null;
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    var temp = JsonConvert.DeserializeObject(response.Content, new ResultObject().GetType()) as ResultObject;
                    if (null != temp && temp.obj != null)
                    {
                       result =  JsonConvert.DeserializeObject(temp.obj.ToString(), type);
                    }
                    break;
                case HttpStatusCode.InternalServerError:
                    break;
                case HttpStatusCode.BadRequest:
                    break;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public int GetDataFromServerByUrl(String session, String url, Boolean isGetObject = false)
        {
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest(Method.GET);
            request.AddCookie(StrConst.SESSIONID, session);
            request.AddHeader("Content-type", "application/json; charset=utf-8");
            request.RequestFormat = DataFormat.Json;
            RestResponse response = (RestResponse)client.Execute(request);

            int result = -1;
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:

                    var temp = JsonConvert.DeserializeObject(response.Content, new ResultObject().GetType()) as ResultObject;
                    result = Convert.ToInt32(temp.Status);
                    if(isGetObject)
                        result = Convert.ToInt32(temp.obj);
                    break;
                case HttpStatusCode.InternalServerError:
                    break;
                case HttpStatusCode.BadRequest:
                    break;
                default:
                    break;
            }
            return result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public int PostDataFromServerByUrl(String session, String url, Object obj)
        {
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest(Method.POST);
            request.AddCookie(StrConst.SESSIONID, session);
            request.AddHeader("Content-type", "application/json; charset=utf-8");
            request.RequestFormat = DataFormat.Json;

            String data = JsonConvert.SerializeObject(obj);
            request.AddBody(data);


            RestResponse response = (RestResponse)client.Execute(request);

            int result = -1;
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:

                    var temp = JsonConvert.DeserializeObject(response.Content, new ResultObject().GetType()) as ResultObject;
                    result = Convert.ToInt32(temp.Status);
                    break;
                case HttpStatusCode.InternalServerError:
                    break;
                case HttpStatusCode.BadRequest:
                    break;
                default:
                    break;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public Object PostDataToServerByUrl(String session, String url, Object obj, Type type)
        {
            RestClient client = new RestClient(url);
            RestRequest request = new RestRequest(Method.POST);
            request.AddCookie(StrConst.SESSIONID, session);
            request.AddHeader("Content-type", "application/json; charset=utf-8");
            request.RequestFormat = DataFormat.Json;

            String data = JsonConvert.SerializeObject(obj);
            request.AddBody(data);


            RestResponse response = (RestResponse)client.Execute(request);
            Object result = null;

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:

                    var temp = JsonConvert.DeserializeObject(response.Content, new ResultObject().GetType()) as ResultObject;
                    if (null != temp && null != temp.obj )
                    {
                        result = JsonConvert.DeserializeObject(temp.obj.ToString(), type);
                    }
                    break;
                case HttpStatusCode.InternalServerError:
                    break;
                case HttpStatusCode.BadRequest:
                    break;
                default:
                    break;
            }
            return result;
        }

        public Object CheckResource(ResultObject obj, ref  String msg)
        {
            Object result = null;
            switch (obj.Status)
            {
                case Status.SUCCESS:
                    result = obj.obj;
                    break;
                case Status.CANCEL:
                    msg = "awfawefwea";
                    break;
            }
            
            return result;
        }



    }
}
