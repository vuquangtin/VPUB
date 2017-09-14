
namespace sWorldModel.TransportData
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class MasterInfoDTO
    {
        [DataMember]
        public int MasterId { get; set; }

        [DataMember]
        public String OrgShortName { get; set; }

        [DataMember]
        public String Name { get; set; }

        [DataMember]
        public KeyDTO key { get; set; }

        [DataMember]
        public String code { get; set; }

        [DataMember]
        public List<CardTypeDTO> cardtypes { get; set; }

    }
}
