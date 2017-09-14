using sWorldModel.Filters;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sWorldCommunication
{
    public interface IAccess
    {
        DeviceDoor GetDeviceDoorById(string session, long deviceDoorId);

        DeviceDoor InsertDeviceDoor(string session, DeviceDoor deviceDoor);

        int UpdateDeviceDoor(string session, DeviceDoor deviceDoor);
        int DeleteDeviceDoor(string session, long deviceDoorId);
        //List<DeviceDoor> GetDeviceDoorList(string session,long orgId,long subOrgId);
        List<DeviceDoor> GetDeviceDoorList(string session);

        DoorOut AccessProcess(string session, string ipAddress, DoorOut doorOut);
        sWorldConfig GetAccessConfig(string session);
        sWorldConfig UpdateAccessConfig(string session, sWorldConfig config);
        List<DoorOut> GetDoorOutList(string session, DoorOutFilterDto filter);
        DoorOut GetDoorOutById(string session, long doorOutId);

        //int PostListDevice(string session,long subOrgId, List<long> lstIdDoor);
    }
}
