using System.Runtime.Serialization;

namespace sTimeKeeping.Model {
    [DataContract]
    public class MemberCustom {
        [DataMember]
        public long memberId { get; set; }
        [DataMember]
        public string memberCode { get; set; }
        [DataMember]
        public string subOrg { get; set; }
        [DataMember]
        public string firstName { get; set; }
        [DataMember]
        public string lastName { get; set; }
        [DataMember]
        public string position { get; set; }
        [DataMember]
        public string idCardNumber { get; set; }

        public string GetFullName() {
            return lastName + " " + firstName;
        }
    }
}
