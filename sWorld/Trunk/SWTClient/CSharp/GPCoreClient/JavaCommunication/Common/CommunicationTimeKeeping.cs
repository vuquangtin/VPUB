using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JavaCommunication.Common
{
    class CommunicationTimeKeeping : CommunicationCommon
    {
        private static CommunicationTimeKeeping instance = new CommunicationTimeKeeping();

        public static CommunicationTimeKeeping Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new CommunicationTimeKeeping();
                }
                return instance;
            }
        }

        public CommunicationTimeKeeping() { }

        protected override void BaseURL()
        {
            base.BaseURL();
            _baseUrl += @"timeKeeping"; 
        }

        public List<DoorOut> GetDoorOutListByYear(string session, String year)
        {
            string parameters = Utilites.Instance.Paramater(session, year);
            List<DoorOut> result = GetDataFromServer(session, MethodNames.GET_DOOR_OUT_YEAR, parameters, new List<DoorOut>().GetType()) as List<DoorOut>;
            if (null == result) throw new Exception();

            return result;
        }

        public List<DoorOut> GetDoorOutListByMonth(string session, String year, String month)
        {
            string parameters = Utilites.Instance.Paramater(session, year, month);
            List<DoorOut> result = GetDataFromServer(session, MethodNames.GET_DOOR_OUT_MONTH, parameters, new List<DoorOut>().GetType()) as List<DoorOut>;
            if (null == result) throw new Exception();

            return result;
        }

        public List<DoorOut> GetDoorOutListByDay(string session, String date, String serial, String deviceId)
        {
            string parameters = Utilites.Instance.Paramater(session, date, serial, deviceId );
            List<DoorOut> result = GetDataFromServer(session, MethodNames.GET_DOOR_OUT_DAY, parameters, new List<DoorOut>().GetType()) as List<DoorOut>;
            if (null == result) throw new Exception();

            return result;
        }
    }
}
