using System;
using System.Runtime.Serialization;

namespace CampusModel.Model
{
    [DataContract]
    public class CardDto
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public int PhysicalStatus { get; set; }

        [DataMember]
        public int LogicalStatus { get; set; }

        [DataMember]
        public bool Personalized { get; set; }

        [DataMember]
        public string SerialNumberHex { get; set; }

        [DataMember]
        public int Type { get; set; }

        [DataMember]
        public DateTime ImportedOn { get; set; }

        [DataMember]
        public long HmkId { get; set; }

        [DataMember]
        public byte HmkAlias { get; set; }

        [DataMember]
        public long DmkId { get; set; }

        [DataMember]
        public byte DmkAlias { get; set; }
    }
}