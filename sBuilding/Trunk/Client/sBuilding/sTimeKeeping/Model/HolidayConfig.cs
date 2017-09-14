using System.Runtime.Serialization;

namespace sTimeKeeping.Model {
    // Cấu hình ngày lễ
    [DataContract]
    public class HolidayConfig {
        [DataMember]
        public long holidayId { get; set; }

        [DataMember]
        public string holidayName { get; set; }

        [DataMember]
        public string holidayStart { get; set; }

        [DataMember]
        public string holidayEnd { get; set; }

        [DataMember]
        public string holidayDescription { get; set; }

        [DataMember]
        public long orgId { get; set; }
    }
}
