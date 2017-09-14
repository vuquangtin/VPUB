using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace sBuildingCommunication.Model
{
    [DataContract]
    public class RoleDevice
    {
        [DataMember]
        public long RoleId { get; set; }
        [DataMember]
        public long RoleName { get; set; }

        [DataMember]
        public long DeviceId { get; set; }
        [DataMember]
        public long DeviceName { get; set; }

    }
}
