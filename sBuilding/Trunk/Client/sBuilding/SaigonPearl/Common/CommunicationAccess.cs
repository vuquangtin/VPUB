using JavaCommunication;
using sBuildingCommunication.Define;
using sBuildingCommunication.Model;
using sWorldModel.Filters;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;

namespace sBuildingCommunication.Common
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

        public List<DeviceDoorGroupDeviceDoorDTO> GetDeviceDoorListByGroupId(string session, long groupId)
        {
            string parameters = Utilites.Instance.Paramater(session, groupId);
            List<DeviceDoorGroupDeviceDoorDTO> result = GetDataFromServer(session, MethodName.GET_DEVICE_DOORLIST_BY_GROUP_ID, parameters, new List<DeviceDoorGroupDeviceDoorDTO>().GetType()) as List<DeviceDoorGroupDeviceDoorDTO>;
            if (null == result) throw new Exception();

            return result;
        }
        public List<DeviceDoor> GetDeviceDoorList(string session)
        {
            string parameters = Utilites.Instance.Paramater(session);
            List<DeviceDoor> result = GetDataFromServer(session, MethodName.GET_DEVICE_DOORLIST, parameters, new List<DeviceDoor>().GetType()) as List<DeviceDoor>;
            if (null == result) throw new Exception();

            return result;
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

            return result;
        }

        public DoorOut GetDoorOutById(string session, long deviceId)
        {
            string parameters = Utilites.Instance.Paramater(session, deviceId);
            DoorOut result = GetDataFromServer(session, MethodNames.GET_DOOR_OUT_BY_ID, parameters, new DoorOut().GetType()) as DoorOut;
            if (null == result) throw new Exception();

            return result;
        }
        public List<DeviceDoorGroup> GetDeviceDoorGroupList(string session)
        {
            string parameters = Utilites.Instance.Paramater(session);
            List<DeviceDoorGroup> result = GetDataFromServer(session, MethodName.GET_DEVICEDOOR_GROUP_LIST, parameters, new List<DeviceDoorGroup>().GetType()) as List<DeviceDoorGroup>;
            if (null == result) throw new Exception();

            return result;
        }

        public DeviceDoorGroup InsertDeviceDoorGroup(string session, DeviceDoorGroup deviceDoor)
        {
            string parameters = Utilites.Instance.Paramater(session);
            DeviceDoorGroup result = PostDataToServerObject(session, MethodName.INSERT_DEVICE_DOOR_GROUP, parameters, deviceDoor, new DeviceDoorGroup().GetType()) as DeviceDoorGroup;
            if (null == result) throw new Exception();
            return result;
        }
        public int UpdateDeviceDoorGroup(string session, DeviceDoorGroup deviceDoor)
        {
            string parameters = Utilites.Instance.Paramater(session);
            return PostDataFromServer(session, MethodName.UPDATE_DEVICE_DOOR_GROUP, parameters, deviceDoor);
        }
        public DeviceDoorGroup GetDeviceDoorGroupById(string session, long deviceDoorGroupId)
        {
            string parameters = Utilites.Instance.Paramater(session, deviceDoorGroupId);
            DeviceDoorGroup result = GetDataFromServer(session, MethodName.GET_DEVICEDOOR_GROUP_BY_ID, parameters, new DeviceDoorGroup().GetType()) as DeviceDoorGroup;
            if (null == result) throw new Exception();

            return result;
        }
        public int RemoveDeviceDoorGroup(string session, long deviceDoorGroupId)
        {
            string parameters = Utilites.Instance.Paramater(session, deviceDoorGroupId);
            return GetDataFromServer(session, MethodName.DELETE_DEVICE_DOOR_GROUP, parameters);
        }
        public int InsertListDeviceDoorByGroupId(string session, long deviceDoorGroupId, List<DeviceDoorGroupDeviceDoorDTO> deviceDoorIdList)
        {
            string parameters = Utilites.Instance.Paramater(session, deviceDoorGroupId);
            return PostDataFromServer(session, MethodName.INSERT_LIST_DEVICEDOOR_BY_GROUPID, parameters, deviceDoorIdList);
        }
        public int deleteListDeviceDoorByGroupId(string session,List<long> deviceDoorIdList)
        {
            string parameters = Utilites.Instance.Paramater(session);
            return PostDataFromServer(session, MethodName.DELETE_LIST_DEVICEDOOR_BY_GROUPID, parameters, deviceDoorIdList);
        }
        public int UpdateListDeviceDoorByGroupId(string session, long deviceDoorGroupId, List<DeviceDoorGroupDeviceDoorDTO> deviceDoorIdList)
        {
            string parameters = Utilites.Instance.Paramater(session, deviceDoorGroupId);
            return PostDataFromServer(session, MethodName.UPDATE_LIST_DEVICEDOOR_BY_GROUPID, parameters, deviceDoorIdList);
        }
        
        public List<DeviceDoorGroupDeviceDoorDTO> GetDeviceDoorGroupDeviceList(string session)
        {
            string parameters = Utilites.Instance.Paramater(session);
            List<DeviceDoorGroupDeviceDoorDTO> result = GetDataFromServer(session, MethodName.GET_DEVICEDOOR_GROUP_DEVICEDOOR_LIST, parameters, new List<DeviceDoorGroupDeviceDoorDTO>().GetType()) as List<DeviceDoorGroupDeviceDoorDTO>;
            return result;
        }
        /// phan nay danh cho nhom nguoi dung
        public List<RoleDTO> GetRoleList(string session)
        {
            string parameters = Utilites.Instance.Paramater(session);
            List<RoleDTO> result = GetDataFromServer(session, MethodName.GET_ROLE_LIST, parameters, new List<RoleDTO>().GetType()) as List<RoleDTO>;
            if (null == result) throw new Exception();

            return result;
        }

        public RoleDTO InsertRole(string session, RoleDTO role)
        {
            string parameters = Utilites.Instance.Paramater(session);
            RoleDTO result = PostDataToServerObject(session, MethodName.INSERT_ROLE, parameters, role, new RoleDTO().GetType()) as RoleDTO;
            if (null == result) throw new Exception();
            return result;
        }
        public int UpdateRole(string session, RoleDTO role)
        {
            string parameters = Utilites.Instance.Paramater(session);
            return PostDataFromServer(session, MethodName.UPDATE_ROLE, parameters, role);
        }
        public RoleDTO GetRoleById(string session, long roleId)
        {
            string parameters = Utilites.Instance.Paramater(session, roleId);
            RoleDTO result = GetDataFromServer(session, MethodName.GET_ROLE_BY_ID, parameters, new RoleDTO().GetType()) as RoleDTO;
            if (null == result) throw new Exception();

            return result;
        }
        public int RemoveRole(string session, long roleId)
        {
            string parameters = Utilites.Instance.Paramater(session, roleId);
            return GetDataFromServer(session, MethodName.DELETE_ROLE, parameters);
        }
        public int InsertListChipPersionNalizationByRoleId(string session, long deviceDoorGroupId, List<RoleChipPersionalDTO> memberId)
        {
            string parameters = Utilites.Instance.Paramater(session, deviceDoorGroupId);
            return PostDataFromServer(session, MethodName.INSERT_PERSONALIZATION_BY_ROLEID, parameters, memberId);
        }
        public List<RoleChipPersonalizationDTO> getListRoleChipPersonalization(string session)
        {
            string parameters = Utilites.Instance.Paramater(session);
            List<RoleChipPersonalizationDTO> result = GetDataFromServer(session, MethodName.GET_PERSONALIZATION_LIST, parameters, new List<RoleChipPersonalizationDTO>().GetType()) as List<RoleChipPersonalizationDTO>;
            if (null == result) throw new Exception();

            return result;
        }
        public List<Member> getMemberList(string session)
        {
            string parameters = Utilites.Instance.Paramater(session);
            List<Member> result = GetDataFromServer(session, MethodName.GET_ALL_MEMBER, parameters, new List<Member>().GetType()) as List<Member>;
            if (null == result) throw new Exception();
            return result;
        }
        public List<Member> getMemberBySubOrgId(string session,long subOrgId)
        {
            string parameters = Utilites.Instance.Paramater(session,subOrgId);
            List<Member> result = GetDataFromServer(session, MethodName.GET_MEMBER_BY_SUBORG_ID, parameters, new List<Member>().GetType()) as List<Member>;
            if (null == result) throw new Exception();

            return result;
        }
        public List<RoleChipPersonalizationCustomDTO> GetPersonalizationByRoleId(string session, long roleId)
        {
            string parameters = Utilites.Instance.Paramater(session, roleId);
            List<RoleChipPersonalizationCustomDTO> result = GetDataFromServer(session, MethodName.GET_PERSONALIZATION_BY_ROLE_ID, parameters, new List<RoleChipPersonalizationCustomDTO>().GetType()) as List<RoleChipPersonalizationCustomDTO>;
            if (null == result) throw new Exception();

            return result;
        }
        public int deleteListRoleChipPersional(string session, List<long> lstIdRoleChipPersional)
        {
            string parameters = Utilites.Instance.Paramater(session);
            return PostDataFromServer(session, MethodName.DELETE_LIST_MEMBER_FROM_GROUP, parameters, lstIdRoleChipPersional);
          
        }
        public int insertRoleDeviceDoorGroup(string session,long roleId, List<DeviceDoorGroup> lstDeviceDoorGroupDTO)
        {
            string parameters = Utilites.Instance.Paramater(session,roleId);
            return PostDataFromServer(session, MethodName.INSERT_ROLE_DEVICE_DOORGROUP, parameters, lstDeviceDoorGroupDTO);

        }
        public List<RoleDeviceDoorGroup> GetDeviceDoorGroupListByRoleId(string session, long roleId)
        {
            string parameters = Utilites.Instance.Paramater(session, roleId);
            List<RoleDeviceDoorGroup> result = GetDataFromServer(session, MethodName.GET_DEVICEDOOR_GROUP_LIST_BY_ROLEID, parameters, new List<RoleDeviceDoorGroup>().GetType()) as List<RoleDeviceDoorGroup>;
            if (null == result) throw new Exception();

            return result;
        }
        public int deleteRoleDeviceDoorGroupList(string session, List<long> lstId)
        {
            string parameters = Utilites.Instance.Paramater(session);
            return PostDataFromServer(session, MethodName.DELETE_ROLE_DEVICE_DOOR_GROUP, parameters, lstId);

        }
        
    }
}