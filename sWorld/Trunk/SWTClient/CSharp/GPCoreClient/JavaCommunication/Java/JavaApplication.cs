using JavaCommunication;
using sWorldModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sWorldModel.TransportData;
using sWorldCommunication;
//using MockTest.Data;
using JavaCommunication.Common;

namespace JavaCommunication.Java
{
    public class JavaApplication : IApplication
    {
        private static JavaApplication instance = new JavaApplication();
        public static JavaApplication Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JavaApplication();
                }
                return instance;
            }
        }
        private JavaApplication()
        {
        }

        public List<App> GetAppDataList(string session, long orgId, long subOrgId)
        {
            return CommunicationApplication.Instance.GetAppDataList(session, orgId, subOrgId);
        }

        public App GetAppById(string session, long appId)
        {
            return CommunicationApplication.Instance.GetAppById(session, appId);
        }

        public int InsertApp(string session, App app)
        {
            return CommunicationApplication.Instance.InsertApp(session, app);
        }

        public int UpdateApp(string session, App app)
        {
            return CommunicationApplication.Instance.UpdateApp(session, app);
        }

        public int DeleteApp(string session, long appId)
        {
            return CommunicationApplication.Instance.DeleteApp(session, appId);
        }
    }
}
