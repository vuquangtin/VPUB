using System.Runtime.Serialization;

namespace sTimeKeeping.Model {
    // Cấu hình ngày nghỉ
    [DataContract]
    public class DayOffConfig {
        [DataMember]
        public long dayOffConfigId { get; set; }

        [DataMember]
        public long memberId { get; set; }

        [DataMember]
        public string date { get; set; }

        [DataMember]
        public int status { get; set; }

        [DataMember]
        public long subOrgId { get; set; }
    }
}
