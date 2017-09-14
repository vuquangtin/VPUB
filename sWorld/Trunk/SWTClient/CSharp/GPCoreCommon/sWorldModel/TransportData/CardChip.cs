namespace sWorldModel.TransportData
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class CardChipDto
    {
        [DataMember]
        public long CardChipId { get; set; }

        [DataMember]
        public long OrgMasterId { get; set; }

        [DataMember]
        public String OrgMasterCode { get; set; }

        [DataMember]
        public long OrgPartnerId { get; set; }

        [DataMember]
        public string SerialNumberHex { get; set; }

        [DataMember]
        public int TypeCard { get; set; }

        [DataMember]
        public string TypeCrypto { get; set; } // k biet

        [DataMember]
        public string CreatedOn{ get; set; }

        [DataMember]
        public int LogicalStatus { get; set; }

        [DataMember]
        public int PhysicalStatus { get; set; }

        [DataMember]
        public String licensemaster { get; set; }

        [DataMember]
        public int headerposision { get; set; }

        [DataMember]
        public bool Personalized { get; set; }
    }
}
