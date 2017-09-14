using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JavaCommunication.Common
{
   public class CommunicationDevice : CommunicationCommon
    {
        private static CommunicationDevice instance = new CommunicationDevice();
        public static CommunicationDevice Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CommunicationDevice();
                }
                return instance;
            }
        }

        public CommunicationDevice() { }

        protected override void BaseURL()
        {
            base.BaseURL();
            _baseUrl += @"device";
        }

        public DeviceDoor GetDeviceDoorById(string session, long deviceDoorId)
        {
            string parameters = Utilites.Instance.Paramater(session, deviceDoorId);
            DeviceDoor result = GetDataFromServer(session, MethodNames.GET_DEVICE_DOOR_BY_ID, parameters, new DeviceDoor().GetType()) as DeviceDoor;
            if (null == result) throw new Exception();

            return result;
        }

        public DeviceDoor InsertDeviceDoor(string session, DeviceDoor deviceDoor)
        {
            string parameters = Utilites.Instance.Paramater(session);
            DeviceDoor result = PostDataToServerObject(session, MethodNames.INSERT_DEVICE_DOOR, parameters, deviceDoor, new DeviceDoor().GetType()) as DeviceDoor;
            if (null == result) throw new Exception();

            return result;
        }

        public int UpdateDeviceDoor(string session, DeviceDoor deviceDoor)
        {
            string parameters = Utilites.Instance.Paramater(session);
            return PostDataFromServer(session, MethodNames.UPDATE_DEVICE_DOOR, parameters, deviceDoor);
        }

        public int DeleteDeviceDoor(string session, long deviceDoorId)
        {
            string parameters = Utilites.Instance.Paramater(session, deviceDoorId);
            return GetDataFromServer(session, MethodNames.DELETE_DEVICE_DOOR, parameters);
        }

        public List<DeviceDoor> GetDeviceDoorList(string session)
        {
            string parameters = Utilites.Instance.Paramater(session);
            List<DeviceDoor> result = GetDataFromServer(session, MethodNames.GET_DEVICE_DOOR_LIST, parameters, new List<DeviceDoor>().GetType()) as List<DeviceDoor>;
            if (null == result) throw new Exception();

            return result;
        }
    }
}
