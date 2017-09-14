using System.Runtime.Serialization;

namespace sTimeKeeping.Model {
    // Cấu hình chung
    [DataContract]
    public class GeneralConfig {
        [DataMember]
        public long generalConfigId { get; set; }

        [DataMember]
        public long orgId { get; set; }

        [DataMember]
        public string generalConfigJson { get; set; }
    }
}
