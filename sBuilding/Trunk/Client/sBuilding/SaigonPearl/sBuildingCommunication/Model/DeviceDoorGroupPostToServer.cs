using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sBuildingCommunication.Model
{
    [DataContract]
    public class DeviceDoorGroupPostToServer
    {
        [DataMember]
        public List<long> lstIdGroupBeforeCheck { get; set; }
        [DataMember]
        public List<long> lstIdGroupAfterCheck { get; set; }
    }
}
