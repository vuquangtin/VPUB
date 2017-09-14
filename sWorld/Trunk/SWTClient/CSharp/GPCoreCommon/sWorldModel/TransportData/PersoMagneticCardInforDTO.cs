namespace sWorldModel.TransportData
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class PersoMagneticCardInforDTO
    {
        [DataMember]
        public long masterid {get; set;}

        [DataMember]
        public long partnerid {get; set;}

        [DataMember]
        public string mastercode { get; set; }

        [DataMember]
        public string partnercode { get; set; }

        [DataMember]
        public string prefix { get; set; }

        [DataMember]
        public int isdefault { get; set; }

        [DataMember]
        public int count { get; set; }
        
        [DataMember]
        public string ExpiredTime { get; set; }

        [DataMember]
        public List<MemberDataExcelDto> listperso { get; set; }
    }
}
