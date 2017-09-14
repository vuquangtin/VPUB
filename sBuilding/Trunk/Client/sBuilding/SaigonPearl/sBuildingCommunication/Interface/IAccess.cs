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
        
        List<DeviceDoor> GetDeviceDoorListByGroupId(string session, long groupId);
        DoorOut AccessProcess(string session, int mode,string ipAddress, DoorOut doorOut);
        sWorldModel.TransportData.sWorldConfig GetAccessConfig(string session);
        sWorldModel.TransportData.sWorldConfig UpdateAccessConfig(string session, sWorldModel.TransportData.sWorldConfig config);
        List<DoorOut> GetDoorOutList(string session, DoorOutFilterDto filter);
        DoorOut GetDoorOutById(string session, long doorOutId);

        // phan nay danh cho quan ly group device
        List<DeviceDoorGroup> GetDeviceDoorGroupList(string session);
        DeviceDoorGroup InsertDeviceDoorGroup(string session, DeviceDoorGroup deviceDoor);
        int UpdateDeviceDoorGroup(string session, DeviceDoorGroup deviceDoor);
        DeviceDoorGroup GetDeviceDoorGroupById(string session, long deviceDoorGroupId);
        int RemoveDeviceDoorGroup(string session, long deviceDoorGroupId);
        int InsertListDeviceDoorByGroupId(string session, long deviceDoorGroupId, DeviceDoorPostToServer deviceDoorPostToServer);
        int DeleteListDeviceDoorByGroupId(string session,List<long> deviceDoorIdList);
        int UpdateListDeviceDoorByGroupId(string session, long deviceDoorGroupId, List<DeviceDoorGroupDeviceDoorDTO> deviceDoorIdList);
        List<DeviceDoorGroupDeviceDoorDTO> GetDeviceDoorGroupDeviceList(string session);
        // phan nay danh cho group nguoi dung
        List<RoleDTO> GetRoleList(string session);
        RoleDTO InsertRole(string session, RoleDTO role);
        int UpdateRole(string session, RoleDTO role);
        RoleDTO GetRoleById(string session, long deviceRoleId);
        int RemoveRole(string session, long deviceRoleId);
        int InsertListChipPersionNalizationByRoleId(string session, long deviceDoorGroupId, List<RoleChipPersionalDTO> memberId);
        List<RoleChipPersonalizationDTO> GetRoleChipPersonalization(string session);

        List<Member> GetMemberList(string session);

        List<RoleChipPersonalizationCustomDTO> GetListMemberByListSuborgId(string session, List<long> subOrgId,long groupId);
        List<RoleChipPersonalizationCustomDTO> GetPersonalizationByRoleId(string session, long roleId);
        int DeleteListRoleChipPersional(string session, List<long> lstId);

        int InsertRoleDeviceDoorGroup(string session, long roleId, DeviceDoorGroupPostToServer lstDeviceDoorGroup);

        List<DeviceDoorGroup> GetDeviceDoorGroupListByRoleId(string session, long roleId);
        int DeleteRoleDeviceDoorGroupList(string session, List<long> lstId); 
    }
}
