using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace sTimeKeeping.Model
{
    [DataContract]
    public class  Shift
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public long orgId { get; set; }
        [DataMember]
        public string subOrgId { get; set; }
        [DataMember]
        public string dateIn { get; set; }
        [DataMember]
        public long deviceDoorId { get; set; }
        [DataMember]
        public string deviceDoorIp { get; set; }
        [DataMember]
        public string imageIn { get; set; }
        [DataMember]
        public long memberId { get; set; }
        [DataMember]
        public string serialNumber { get; set; }
        
    }
}
