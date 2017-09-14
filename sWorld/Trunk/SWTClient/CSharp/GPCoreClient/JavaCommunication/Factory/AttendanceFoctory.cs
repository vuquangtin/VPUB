using CommonHelper.Config;
using JavaCommunication.Java;
using sWorldCommunication.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JavaCommunication.Factory
{
    public class AttendanceFoctory
    {
        private static AttendanceFoctory instance = new AttendanceFoctory();
        public static AttendanceFoctory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AttendanceFoctory();
                }
                return instance;
            }
        }
        private AttendanceFoctory()
        {

        }

        public IAttendance GetChannel()
        {
            switch (SystemSettings.Instance.TypeComm)
            {
                case TYPECOMM.TEST:
                    //return TestApplication.Instance;
                    return null;
                case TYPECOMM.JAVA:
                    return JavaAttendance.Instance;
                default:
                    return JavaAttendance.Instance;
            }
        }
    }
}
