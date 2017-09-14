using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sWorldModel.TransportData
{
    [DataContract]
    public class DeviceDoor
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public String Name { get; set; }
        [DataMember]
        public long OrgId { get; set; }
        [DataMember]
        public long subOrgId { get; set; }
        [DataMember]
        public String Ip { get; set; }
        [DataMember]
        public String Port { get; set; }
        [DataMember]
        public bool Locked { get; set; }
        [DataMember]
        public String TimeOpen { get; set; }
        [DataMember]
        public String TimeClose { get; set; }
        [DataMember]
        public String CreateBy { get; set; }
        [DataMember]
        public String CreateAt { get; set; }
        [DataMember]
        public String ModifiedBy { get; set; }
        [DataMember]
        public String ModifiedAt { get; set; }
        [DataMember]
        public String Status { get; set; }
        [DataMember]
        public String Description { get; set; }
        [DataMember]
        public bool deviceTimekeeping { get; set; }

        [DataMember]
        public bool deviceOfGroup { get; set; }
    }
}
