using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

//<ChinhNguyen>
namespace sWorldModel.TransportData
{
    [DataContract]
    public class PersoCardCustomerDTO
    {
        [DataMember]
        public long ChipPersoId { get; set; }

        [DataMember]
        public long CardChipId { get; set; }

        [DataMember]
        public string SerialNumber { get; set; }

        [DataMember]
        public string PersoDate { get; set; }

        [DataMember]
        public string ExpirationDate { get; set; }

        [DataMember]
        public int LogicalStatus { get; set; }

        [DataMember]
        public int PhysicalStatus { get; set; }

        [DataMember]
        public string Notes { get; set; }

        [DataMember]
        public int Status { get; set; }
    }
}
