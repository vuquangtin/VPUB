using JavaCommunication;
using JavaCommunication.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sTimeKeeping.JavaComunication
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

        public List<Shift> GetShiftListByYear(string session, String year)
        {
            string parameters = Utilites.Instance.Paramater(session, year);
            List<Shift> result = GetDataFromServer(session, MethodNames.GET_DOOR_OUT_YEAR, parameters, new List<Shift>().GetType()) as List<Shift>;
            if (null == result) throw new Exception();

            return result;
        }

        public List<Shift> GetShiftListByMonth(string session, String year, String month)
        {
            string parameters = Utilites.Instance.Paramater(session, year, month);
            List<Shift> result = GetDataFromServer(session, MethodNames.GET_DOOR_OUT_MONTH, parameters, new List<Shift>().GetType()) as List<Shift>;
            if (null == result) throw new Exception();

            return result;
        }

        public List<Shift> GetShiftListByDay(string session, String date, String serial, String deviceId)
        {
            string parameters = Utilites.Instance.Paramater(session, date, serial, deviceId);
            List<Shift> result = GetDataFromServer(session, MethodNames.GET_DOOR_OUT_DAY, parameters, new List<Shift>().GetType()) as List<Shift>;
            if (null == result) throw new Exception();

            return result;
        }
    }
}
