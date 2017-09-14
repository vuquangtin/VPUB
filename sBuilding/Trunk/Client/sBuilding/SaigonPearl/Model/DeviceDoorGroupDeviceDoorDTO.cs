using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace sBuildingCommunication.Model
{
    [DataContract]
    public class DeviceDoorGroupDeviceDoorDTO
    {
        [DataMember]
        public long devicedoorgroupdeviceid { get; set; }
        [DataMember]
        public long deviceDoorId { get; set; }
        [DataMember]
        public string deviceDoorName { get; set; }
        [DataMember]
        public string ip { get; set; }

        [DataMember]
        public string deviceDoordesription { get; set; }
    }
}
