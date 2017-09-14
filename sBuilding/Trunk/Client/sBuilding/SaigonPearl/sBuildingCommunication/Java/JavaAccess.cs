using sBuildingCommunication.Common;
using sBuildingCommunication.Interface;
using sBuildingCommunication.Model;
using sWorldModel.Filters;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sBuildingCommunication.Java
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
  

        public List<DeviceDoor> GetDeviceDoorList(string session)
        {
            return CommunicationAccess.Instance.GetDeviceDoorList(session);
        }

        public List<DeviceDoor> GetDeviceDoorListByGroupId(string session, long groupId)
        {
            return CommunicationAccess.Instance.GetDeviceDoorListByGroupId(session, groupId);
        }

        public DoorOut AccessProcess(string session, int mode, string ipAddress, DoorOut doorOut)
        {
            return CommunicationAccess.Instance.AccessProcess(session, mode, ipAddress, doorOut);
        }

        public sWorldConfig GetAccessConfig(string session)
        {
            return CommunicationAccess.Instance.GetAccessConfig(session);
        }

        public sWorldConfig UpdateAccessConfig(string session, sWorldModel.TransportData.sWorldConfig config)
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
        public List<DeviceDoorGroup> GetDeviceDoorGroupList(string session)
        {
            return CommunicationAccess.Instance.GetDeviceDoorGroupList(session);
        }

        public DeviceDoorGroup InsertDeviceDoorGroup(string session, DeviceDoorGroup deviceDoor)
        {
            return CommunicationAccess.Instance.InsertDeviceDoorGroup(session, deviceDoor);
        }
        public int UpdateDeviceDoorGroup(string session, DeviceDoorGroup deviceDoor)
        {
            return CommunicationAccess.Instance.UpdateDeviceDoorGroup(session, deviceDoor);
        }
        public DeviceDoorGroup GetDeviceDoorGroupById(string session, long deviceDoorGroupId)
        {
            return CommunicationAccess.Instance.GetDeviceDoorGroupById(session, deviceDoorGroupId);
        }
        public int RemoveDeviceDoorGroup(string session, long deviceDoorGroupId)
        {
            return CommunicationAccess.Instance.RemoveDeviceDoorGroup(session, deviceDoorGroupId);
        }
        public int InsertListDeviceDoorByGroupId(string session, long deviceDoorGroupId, DeviceDoorPostToServer deviceDoorPostToServer)
        {
            return CommunicationAccess.Instance.InsertListDeviceDoorByGroupId(session, deviceDoorGroupId, deviceDoorPostToServer);
        }
        public int DeleteListDeviceDoorByGroupId(string session, List<long> deviceId)
        {
            return CommunicationAccess.Instance.deleteListDeviceDoorByGroupId(session, deviceId);
        }
        public int UpdateListDeviceDoorByGroupId(string session, long deviceDoorGroupId, List<DeviceDoorGroupDeviceDoorDTO> device)
        {
            return CommunicationAccess.Instance.UpdateListDeviceDoorByGroupId(session, deviceDoorGroupId, device);
        }

        public List<DeviceDoorGroupDeviceDoorDTO> GetDeviceDoorGroupDeviceList(string session)
        {
            return CommunicationAccess.Instance.GetDeviceDoorGroupDeviceList(session);
        }
        // phan nay danh cho group nguoi dung

        public List<RoleDTO> GetRoleList(string session)
        {
            return CommunicationAccess.Instance.GetRoleList(session);
        }

        public RoleDTO InsertRole(string session, RoleDTO role)
        {
            return CommunicationAccess.Instance.InsertRole(session, role);
        }
        public int UpdateRole(string session, RoleDTO role)
        {
            return CommunicationAccess.Instance.UpdateRole(session, role);
        }
        public RoleDTO GetRoleById(string session, long roleId)
        {
            return CommunicationAccess.Instance.GetRoleById(session, roleId);
        }
        public int RemoveRole(string session, long roleId)
        {
            return CommunicationAccess.Instance.RemoveRole(session, roleId);
        }
        public int InsertListChipPersionNalizationByRoleId(string session, long roleId, List<RoleChipPersionalDTO> memBerId)
        {
            return CommunicationAccess.Instance.InsertListChipPersionNalizationByRoleId(session, roleId, memBerId);
        }
        public List<RoleChipPersonalizationDTO> GetRoleChipPersonalization(string session)
        {
            return CommunicationAccess.Instance.getListRoleChipPersonalization(session);
        }
        public List<Member> GetMemberList(string session)
        {
            return CommunicationAccess.Instance.getMemberList(session);
        }
        public List<RoleChipPersonalizationCustomDTO> GetListMemberByListSuborgId(string session, List<long> subOrgId,long groupId)
        {
            return CommunicationAccess.Instance.getMemberBySubOrgId(session, subOrgId, groupId);
        }
        public List<RoleChipPersonalizationCustomDTO> GetPersonalizationByRoleId(string session, long roleId)
        {
            return CommunicationAccess.Instance.GetPersonalizationByRoleId(session, roleId);
        }
        public int DeleteListRoleChipPersional(string session, List<long> lstIdRoleChipPersional)
        {
            return CommunicationAccess.Instance.deleteListRoleChipPersional(session, lstIdRoleChipPersional);
        }

        public int InsertRoleDeviceDoorGroup(string session, long roleId, DeviceDoorGroupPostToServer lstDeviceDoorGroupDTO)
        {
            return CommunicationAccess.Instance.InsertRoleDeviceDoorGroup(session, roleId, lstDeviceDoorGroupDTO);
        }

        public List<DeviceDoorGroup> GetDeviceDoorGroupListByRoleId(string session, long roleId)
        {
            return CommunicationAccess.Instance.GetDeviceDoorGroupListByRoleId(session, roleId);
        }
        public int DeleteRoleDeviceDoorGroupList(string session, List<long> lstId)
        {
            return CommunicationAccess.Instance.deleteRoleDeviceDoorGroupList(session, lstId);
        }
    }

}
