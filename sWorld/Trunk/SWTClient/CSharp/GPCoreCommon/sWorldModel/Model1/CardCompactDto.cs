using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sWorldModel.Model
{
    [DataContract]
    public class CardCompactDto
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public int PhysicalStatus { get; set; }

        [DataMember]
        public int LogicalStatus { get; set; }

        [DataMember]
        public string SerialNumberHex { get; set; }

        [DataMember]
        public int Type { get; set; }
    }
}
