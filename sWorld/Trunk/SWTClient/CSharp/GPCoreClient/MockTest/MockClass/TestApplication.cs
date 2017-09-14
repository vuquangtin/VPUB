using MockTest.Data;
using sWorldModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sWorldModel.TransportData;
using sWorldCommunication;

namespace MockTest.MockClass
{
    public class TestApplication : IApplication
    {
        private static TestApplication instance = new TestApplication();
        public static TestApplication Instance
        {
            get {
                if (instance == null){
                    instance = new TestApplication();
                }
                return instance;
            }
        }
        private TestApplication()
        {
        }

        public List<App> GetAppDataList(string session, long orgId, long subOrgId)
        {
            return HardCode.Instance.GetAppDataList();
        }

        public App GetAppById(string session, long appId)
        {
            return new App();
        }

        public int InsertApp(string session, App app) 
        {
            return (int)Status.SUCCESS;
        }

        public int UpdateApp(string session, App app)
        {
            return (int)Status.SUCCESS;
        }

        public int DeleteApp(string session, long appId)
        {
            return (int)Status.SUCCESS;
        }
    }
}
