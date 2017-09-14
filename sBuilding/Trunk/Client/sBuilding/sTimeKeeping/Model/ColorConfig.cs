using System.Runtime.Serialization;

namespace sTimeKeeping.Model {
    // Cấu hình màu sắc cho các ngày, sự kiện
    [DataContract]
    public class  ColorConfig {
        [DataMember]
        public long colorConfigId { get; set; }

        [DataMember]
        public long colorConfigNameId { get; set; }

        [DataMember]
        public long colorId { get; set; }

        [DataMember]
        public long orgId { get; set; }
    }
}
