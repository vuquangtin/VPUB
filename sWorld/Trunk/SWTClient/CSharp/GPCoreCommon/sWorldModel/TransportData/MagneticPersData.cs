namespace sWorldModel.TransportData
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class MagneticPersData
    {
        
        [DataMember]
        public int MagneticPersId { get; set; }

        [DataMember]
        public int CardMagneticId { get; set; }

        [DataMember]
        public int MemberId { get; set; }

        [DataMember]
        public String FullName { get; set; }

        [DataMember]
        public String CompanyName { get; set; }

        [DataMember]
        public String PhoneNumber { get; set; }

        [DataMember]
        public String ExpiredTime { get; set; }

        [DataMember]
        public String SerialNumber { get; set; }

        [DataMember]
        public String TrackData { get; set; }

        [DataMember]
        public string PersoDate { get; set; }

        [DataMember]
        public string PinCodeNew { get; set; }

        [DataMember]
        public string ActiveCodeNew { get; set; }

        [DataMember]
        public string Notes { get; set; }

    }
}
