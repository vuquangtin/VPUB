using sWorldModel.Model;
using sWorldModel.TransportData;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace sWorldModel.MethodData
{
    [DataContract]
    public class DataForPersoCard
    {

        [DataMember]
        public byte[] HeaderKeyB { get; set; }

        [DataMember]
        public App MemberAppMetadata { get; set; }

        [DataMember]
        public byte[] MemberData { get; set; }

        //[DataMember]
        //public Dictionary<byte, KeyUpdateSetDto> AppSectorKeyUpdateSets { get; set; }
    }
}
