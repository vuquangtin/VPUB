using JavaCommunication.Common;
using sWorldCommunication.Interface;
using sWorldModel.Filters;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sWorldCommunication;

namespace JavaCommunication.Java
{
    public class JavaAccess : IAccess
    {
        private static JavaAccess instance = new JavaAccess();
        public static JavaAccess Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JavaAccess();
                }
                return instance;
            }
        }
        private JavaAccess()
        {
        }


        public DeviceDoor GetDeviceDoorById(string session, long deviceDoorId)
        {
            return CommunicationDevice.Instance.GetDeviceDoorById(session, deviceDoorId);
        }

        public DeviceDoor InsertDeviceDoor(string session, DeviceDoor deviceDoor)
        {
            return CommunicationDevice.Instance.InsertDeviceDoor(session, deviceDoor);
        }

        public int UpdateDeviceDoor(string session, DeviceDoor deviceDoor)
        {
            return CommunicationDevice.Instance.UpdateDeviceDoor(session, deviceDoor);
        }

        public int DeleteDeviceDoor(string session, long deviceDoorId)
        {
            return CommunicationDevice.Instance.DeleteDeviceDoor(session, deviceDoorId);
        }

        public List<DeviceDoor> GetDeviceDoorList(string session)
        {
            return CommunicationDevice.Instance.GetDeviceDoorList(session);
        }

        public DoorOut AccessProcess(string session, string ipAddress, DoorOut doorOut)
        {
            return CommunicationAccess.Instance.AccessProcess(session, ipAddress, doorOut);
        }

        public sWorldConfig GetAccessConfig(string session)
        {
            return CommunicationAccess.Instance.GetAccessConfig(session);
        }

        public sWorldConfig UpdateAccessConfig(string session, sWorldConfig config)
        {
            return CommunicationAccess.Instance.UpdateAccessConfig(session, config);
        }

        public List<DoorOut> GetDoorOutList(string session, DoorOutFilterDto filter)
        {
            return CommunicationAccess.Instance.GetDoorOutList(session, filter);
        }

        public DoorOut GetDoorOutById(string session, long doorOutId)
        {
            return CommunicationAccess.Instance.GetDoorOutById(session, doorOutId);
        }

    }
}
