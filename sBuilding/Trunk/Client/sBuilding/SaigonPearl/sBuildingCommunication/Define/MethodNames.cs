using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sBuildingCommunication.Define
{
    public class MethodNames
    {
        public static readonly String GET_ROLE_LIST = @"GetRoleList";
        public static readonly String GET_DEVICEDOOR_GROUP_LIST = @"GetDeviceDoorGroupList";
        public static readonly String INSERT_DEVICE_DOOR_GROUP = @"InsertDeviceDoorGroup";
        public static readonly String UPDATE_DEVICE_DOOR_GROUP = @"UpdateDeviceDoorGroup";
        public static readonly String GET_DOOR_OUT_GROUP_BY_ID = @"GetDeviceDoorGroupById";
        public static readonly String DELETE_DEVICE_DOOR_GROUP = @"DeleteDoorGroupList";
        public static readonly String GET_DEVICE_DOORLIST_BY_GROUP_ID = @"GetDeviceDoorListByGroupId";
        public static readonly String GET_DEVICE_DOORLIST = @"GetDeviceDoorList";
    }
}
