using sBuildingCommunication.Model;
using sWorldModel.Filters;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sBuildingCommunication.Interface
{
    public interface IAccess
    {
        DeviceDoor GetDeviceDoorById(string session, long deviceDoorId);
        DeviceDoor InsertDeviceDoor(string session, DeviceDoor deviceDoor);
        int UpdateDeviceDoor(string session, DeviceDoor deviceDoor);
        int DeleteDeviceDoor(string session, long deviceDoorId);

        List<DeviceDoor> GetDeviceDoorList(string session);
        List<DeviceDoorGroupDeviceDoorDTO> GetDeviceDoorListByGroupId(string session, long groupId);
        DoorOut AccessProcess(string session, string ipAddress, DoorOut doorOut);
        sWorldConfig GetAccessConfig(string session);
        sWorldConfig UpdateAccessConfig(string session, sWorldConfig config);
        List<DoorOut> GetDoorOutList(string session, DoorOutFilterDto filter);
        DoorOut GetDoorOutById(string session, long doorOutId);

        // phan nay danh cho quan ly group device
        List<DeviceDoorGroup> GetDeviceDoorGroupList(string session);
        DeviceDoorGroup InsertDeviceDoorGroup(string session, DeviceDoorGroup deviceDoor);
        int UpdateDeviceDoorGroup(string session, DeviceDoorGroup deviceDoor);
        DeviceDoorGroup GetDeviceDoorGroupById(string session, long deviceDoorGroupId);
        int RemoveDeviceDoorGroup(string session, long deviceDoorGroupId);
        int InsertListDeviceDoorByGroupId(string session, long deviceDoorGroupId,List<DeviceDoorGroupDeviceDoorDTO> deviceDoorIdList);
        int deleteListDeviceDoorByGroupId(string session,List<long> deviceDoorIdList);
        int UpdateListDeviceDoorByGroupId(string session, long deviceDoorGroupId, List<DeviceDoorGroupDeviceDoorDTO> deviceDoorIdList);
        List<DeviceDoorGroupDeviceDoorDTO> GetDeviceDoorGroupDeviceList(string session);
        // phan nay danh cho group nguoi dung
        List<RoleDTO> GetRoleList(string session);
        RoleDTO InsertRole(string session, RoleDTO role);
        int UpdateRole(string session, RoleDTO role);
        RoleDTO GetRoleById(string session, long deviceRoleId);
        int RemoveRole(string session, long deviceRoleId);
        int InsertListChipPersionNalizationByRoleId(string session, long deviceDoorGroupId, List<RoleChipPersionalDTO> memberId);
        List<RoleChipPersonalizationDTO> getRoleChipPersonalization(string session);

        List<Member> getMemberList(string session);

        List<Member> getMemberBySuborgId(string session, long subOrgId);
        List<RoleChipPersonalizationCustomDTO> GetPersonalizationByRoleId(string session, long roleId);
        int deleteListRoleChipPersional(string session, List<long> lstId);

        int insertRoleDeviceDoorGroup(string session, long roleId, List<DeviceDoorGroup> lstDeviceDoorGroup);

        List<RoleDeviceDoorGroup> GetDeviceDoorGroupListByRoleId(string session, long roleId);
        int deleteRoleDeviceDoorGroupList(string session, List<long> lstId); 
    }
}
