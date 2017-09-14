namespace sWorldModel.TransportData
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class PreGenerateData
    {
        [DataMember]
        public int AlgorithmSerial { get; set; }

        [DataMember]
        public int BeginNumber { get; set; }

        [DataMember]
        public string FullName { get; set; }    // default

        [DataMember]
        public string CompanyName { get; set; } // default

        [DataMember]
        public string PhoneNumber { get; set; } // default

    }
}
