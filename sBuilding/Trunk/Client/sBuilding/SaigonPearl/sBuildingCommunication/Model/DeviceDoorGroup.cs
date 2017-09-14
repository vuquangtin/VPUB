using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace sBuildingCommunication.Model
{
    [DataContract]
    public class DeviceDoorGroup
    {
        [DataMember]
        public long deviceDoorGroupId { get; set; }

        [DataMember]
        public string deviceDoorGroupName { get; set; }
        [DataMember]
        public string description { get; set; }

        [DataMember]
        public string status { get; set; }
        [DataMember]
        public bool isSchedule { get; set; }

        [DataMember]
        public bool addGroupMember { get; set; }

    }
}
