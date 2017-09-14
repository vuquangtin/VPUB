using System.Runtime.Serialization;

namespace sTimeKeeping.Model {
    [DataContract]
    public class ChipPersonalizationCustom {
        [DataMember]
        public long memberId { get; set; }
        [DataMember]
        public string serialNumber { get; set; }
    }
}
