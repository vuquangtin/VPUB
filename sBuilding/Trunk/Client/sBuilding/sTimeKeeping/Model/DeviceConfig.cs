using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sTimeKeeping.Model
{
    /// <summary>
    /// Cau hinh thiet bi nao duoc cham cong
    /// </summary>
    [DataContract]
    public class DeviceConfig
    {
        [DataMember]
        public long deviceConfigId { get; set; }

        [DataMember]
        public long deviceDoorId { get; set; }

        [DataMember]
        public String ip { get; set; }
        [DataMember]
        public String deviceName { get; set; }
        [DataMember]
        public long orgId { get; set; }
        [DataMember]
        public String deviceDescription { get; set; }
        
        [DataMember]
        public bool deviceTimeKeeping { get; set; }

    }
}
