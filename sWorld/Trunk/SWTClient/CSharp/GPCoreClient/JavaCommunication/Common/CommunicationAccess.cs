using sWorldModel.Filters;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JavaCommunication.Common
{
    public class CommunicationAccess : CommunicationCommon
    {
        private static CommunicationAccess instance = new CommunicationAccess();
        public static CommunicationAccess Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CommunicationAccess();
                }
                return instance;
            }
        }

        public CommunicationAccess() { }

        protected override void BaseURL()
        {
            base.BaseURL();
            _baseUrl += @"access";
        }
       
        public DoorOut AccessProcess(string session, string ipAddress, DoorOut doorOut)
        {
            string parameters = Utilites.Instance.Paramater(session, ipAddress);
            DoorOut result = PostDataToServerObject(session, MethodNames.ACCESS_PROCESS, parameters, doorOut, new DoorOut().GetType()) as DoorOut;
            if (null == result)
                return null;

            return result;
        }

        public sWorldConfig GetAccessConfig(string session)
        {
            string parameters = Utilites.Instance.Paramater(session);
            sWorldConfig result = GetDataFromServer(session, MethodNames.LOAD_ACCESS_CONFIG, parameters, new sWorldConfig().GetType()) as sWorldConfig;
            if (null == result) throw new Exception();

            return result;
        }

        public sWorldConfig UpdateAccessConfig(string session, sWorldConfig config)
        {
            string parameters = Utilites.Instance.Paramater(session);
            sWorldConfig result = PostDataToServerObject(session, MethodNames.UPDATE_ACCESS_CONFIG, parameters, config, new sWorldConfig().GetType()) as sWorldConfig;
            if (null == result) throw new Exception();

            return result;
        }

        public List<DoorOut> GetDoorOutList(string session, DoorOutFilterDto filter)
        {
            string parameters = Utilites.Instance.Paramater(session);
            List<DoorOut> result = PostDataToServerObject(session, MethodNames.GET_DOOR_OUT_LIST, parameters, filter, new List<DoorOut>().GetType()) as List<DoorOut>;
            if (null == result) throw new Exception();

            return result;
        }

        public DoorOut GetDoorOutById(string session, long deviceId)
        {
            string parameters = Utilites.Instance.Paramater(session, deviceId);
            DoorOut result = GetDataFromServer(session, MethodNames.GET_DOOR_OUT_BY_ID, parameters, new DoorOut().GetType()) as DoorOut;
            if (null == result) throw new Exception();

            return result;
        }
    }
}
