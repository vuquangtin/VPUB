using JavaCommunication.Common;
using sWorldCommunication;
using sWorldCommunication.Interface;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JavaCommunication.Java
{
   public class JavaTimeKeeping : ITimeKeeping
    {
        private static JavaTimeKeeping instance = new JavaTimeKeeping();
        public static JavaTimeKeeping Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JavaTimeKeeping();
                }
                return instance;
            }
        }
        private JavaTimeKeeping()
        {
        }

         public List<DoorOut> GetDoorOutListByYear(string session, String year){
             return CommunicationTimeKeeping.Instance.GetDoorOutListByYear(session, year);
         }
         public List<DoorOut> GetDoorOutListByMonth(string session, String year, String month){
             return CommunicationTimeKeeping.Instance.GetDoorOutListByMonth(session, year, month);
         }
         public List<DoorOut> GetDoorOutListByDay(string session, String date, String serial, String deviceId)
         {
             return CommunicationTimeKeeping.Instance.GetDoorOutListByDay(session, date, serial, deviceId);
         }
    }
}
