using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sTimeKeeping.JavaComunication
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

        public List<Shift> GetDoorOutListByYear(string session, String year)
        {
            return CommunicationTimeKeeping.Instance.GetShiftListByYear(session, year);
        }
        public List<Shift> GetDoorOutListByMonth(string session, String year, String month)
        {
            return CommunicationTimeKeeping.Instance.GetShiftListByMonth(session, year, month);
        }
        public List<Shift> GetDoorOutListByDay(string session, String date, String serial, String deviceId)
        {
            return CommunicationTimeKeeping.Instance.GetShiftListByDay(session, date, serial, deviceId);
        }
    }
}
