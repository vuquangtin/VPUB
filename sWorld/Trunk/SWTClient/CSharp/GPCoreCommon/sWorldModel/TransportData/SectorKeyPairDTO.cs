using System.Runtime.Serialization;

namespace sWorldModel.TransportData
{
    [DataContract]
    public class SectorKeyPairDTO
    {
        [DataMember]
        public string KeyA { get; set; }

        [DataMember]
        public string KeyB { get; set; }
    }
}
