using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JavaCommunication.Common
{
    public class CommunicationApplication : CommunicationCommon
    {
        private static CommunicationApplication instance = new CommunicationApplication();
        public static CommunicationApplication Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CommunicationApplication();
                }
                return instance;
            }
        }
        public CommunicationApplication() { }

        protected override void BaseURL()
        {
            base.BaseURL();
            _baseUrl += @"app";
        }

        public List<App> GetAppDataList(string session, long orgId, long subOrgId)
        {
            string parameters = Utilites.Instance.Paramater(session, orgId, subOrgId);
            List<App> result = GetDataFromServer(session, MethodNames.GET_APP_DATA_LIST, parameters, new List<App>().GetType()) as List<App>;
            if (null == result) throw new Exception();

            return result;
        }

        public App GetAppById(string session, long appId)
        {
            string parameters = Utilites.Instance.Paramater(session, appId);
            App result = GetDataFromServer(session, MethodNames.GET_APP_BY_ID, parameters, new App().GetType()) as App;
            if (null == result) throw new Exception();

            return result;
        }

        public int InsertApp(string session, App app)
        {
            string parameters = Utilites.Instance.Paramater(session);
            return PostDataFromServer(session, MethodNames.INSERT_APP, parameters, app);
        }

        public int UpdateApp(string session, App app)
        {
            string parameters = Utilites.Instance.Paramater(session);
            return PostDataFromServer(session, MethodNames.UPDATE_APP, parameters, app);
        }

        public int DeleteApp(string session, long appId)
        {
            string parameters = Utilites.Instance.Paramater(session, appId);
            return GetDataFromServer(session, MethodNames.DELETEAPP, parameters);
        }
    }
}
