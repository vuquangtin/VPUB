using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sBuildingCommunication.Model
{
    [DataContract]
    public class DeviceDoorGroupCustomer
    {
        [DataMember]
        public long roleDeviceDoorGroupId { get; set; }
        [DataMember]
        public DeviceDoorGroup deviceDoorGroup { get; set; }

    } 
}
