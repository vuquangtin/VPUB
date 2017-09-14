using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sBuildingCommunication.Define
{
    public class MethodName
    {
        // phan nay dung cho group device
        public static readonly String GET_DEVICEDOOR_GROUP_LIST = @"GetDeviceDoorGroupList";
        public static readonly String INSERT_DEVICE_DOOR_GROUP = @"InsertDeviceDoorGroup";
        public static readonly String UPDATE_DEVICE_DOOR_GROUP = @"UpdateDeviceDoorGroup";
        public static readonly String GET_DEVICEDOOR_GROUP_BY_ID = @"GetDeviceDoorGroupById";
        public static readonly String DELETE_DEVICE_DOOR_GROUP = @"DeleteDoorGroupList";
        public static readonly String GET_DEVICE_DOORLIST_BY_GROUP_ID = @"GetDeviceDoorListByGroupId";
        public static readonly String GET_DEVICE_DOORLIST = @"GetDeviceDoorList";
        public static readonly String INSERT_LIST_DEVICEDOOR_BY_GROUPID = @"InsertListDeviceDoorByGroupId";
        public static readonly String UPDATE_LIST_DEVICEDOOR_BY_GROUPID = @"UpdateListDeviceDoorByGroupId";
        public static readonly String DELETE_LIST_DEVICEDOOR_BY_GROUPID = @"DeleteListDeviceDoorByGroupId";
        public static readonly String GET_DEVICEDOOR_GROUP_DEVICEDOOR_LIST = @"";
        // phan nay danh cho group nguoi dung
        public static readonly String GET_PERSONALIZATION_LIST = @"GetPersonalizationList";
        public static readonly String GET_ROLE_LIST = @"GetRoleList";
        public static readonly String INSERT_ROLE = @"InsertRole";
        public static readonly String UPDATE_ROLE = @"UpdateRole";
        public static readonly String GET_ROLE_BY_ID = @"GetRoleById";
        public static readonly String DELETE_ROLE = @"DeleteRole";
        public static readonly String GET_PERSONALIZATION_BY_ROLE_ID = @"GetPersonalizationByRoleId";
        public static readonly String INSERT_PERSONALIZATION_BY_ROLEID = @"InsertPersonalizationByRoleId";
        public static readonly String GET_ALL_MEMBER = @"GetAllMember";
        public static readonly String GET_MEMBER_BY_SUBORG_ID = @" GetMemberBySubOrgId";
        public static readonly String DELETE_LIST_MEMBER_FROM_GROUP = @"DeleteListMemberFromGroup";
        public static readonly String INSERT_ROLE_DEVICE_DOORGROUP = @"InsertRoleDeviceDoorGroup";
        public static readonly String GET_DEVICEDOOR_GROUP_LIST_BY_ROLEID = @"GetDeviceDoorGroupListByRoleId";
        public static readonly String DELETE_ROLE_DEVICE_DOOR_GROUP = @"DeleteRoleDeviceDoorGroup";
    }

}
