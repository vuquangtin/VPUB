using System;
using System.Runtime.Serialization;

namespace sWorldModel.TransportData
{
    [DataContract]
    public class Personalization
    {
        [DataMember]
        public long ChipPersoId { get; set; }

        [DataMember]
        public long CardChipId { get; set; }

        [DataMember]
        public Member Member { get; set; }

        [DataMember]
        public string SerialNumber { get; set; }

        [DataMember]
        public string PersoDate { get; set; }

        [DataMember]
        public string ExpirationDate { get; set; }

        [DataMember]
        public string CreatedBy { get; set; }

        [DataMember]
        public string CreatedOn { get; set; } //Date

        [DataMember]
        public string ModifiedBy { get; set; }

        [DataMember]
        public string ModifiedOn { get; set; } //Date

        [DataMember]
        public int LogicalStatus { get; set; }

        [DataMember]
        public int PhysicalStatus { get; set; }

        [DataMember]
        public string Temp1 { get; set; }

        [DataMember]
        public string Notes { get; set; }

        [DataMember]
        public int Status { get; set; }
    }
}
