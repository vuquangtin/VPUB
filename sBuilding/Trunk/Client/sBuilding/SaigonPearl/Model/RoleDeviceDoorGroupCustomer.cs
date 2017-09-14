using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sBuildingCommunication.Model
{
    [DataContract]
    public  class RoleDeviceDoorGroupCustomer
    {
        [DataMember]
        public DeviceDoorGroup deviceDoorGroupDTO { get; set; }

        [DataMember]
        public RoleDeviceDoorGroup roleDeviceDoorGroupDTO { get; set; }
    }
}
