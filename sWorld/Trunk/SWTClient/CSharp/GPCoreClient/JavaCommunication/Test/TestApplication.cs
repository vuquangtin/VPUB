using JavaCommunication;
using sWorldModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sWorldModel.TransportData;

namespace JavaCommunication.Java
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

        public List<AMSAppDto> GetAppList(string session) 
        {
            return new List<AMSAppDto>();
        }

        public AMSAppDto GetTeacherProfileApp(string session)
        {
            return new AMSAppDto();
        }

        public AMSAppDto AddApp(string session, string appName, string appDescription, KeyDTO newAppMasterKey, byte startSectorNumber, byte maxSectorUsed)
        {
            return new AMSAppDto();
        }
    }
}
