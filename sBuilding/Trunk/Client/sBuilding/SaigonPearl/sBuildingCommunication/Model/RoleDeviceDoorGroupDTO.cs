using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sBuildingCommunication.Model
{
    /// <summary>
    /// Class nay dung de map group device va group nguoi dung
    /// </summary>
    [DataContract]
    public class RoleDeviceDoorGroupDTO
    {
        [DataMember]
        public long roleDeviceDoorGroupId { get; set; }

        [DataMember]
        public long roleId { get; set; }

        [DataMember]
        public long deviceDoorGroupId { get; set; }
    }
}
