using System.Runtime.Serialization;

namespace sNonResidentComponent.Model {
    [DataContract]
    public class NonResidentMemberMap {
        [DataMember]
        public long nonMemMapId { get; set; }

        [DataMember]
        public long nonOrgId { get; set; }

        [DataMember]
        public long nonMemMapRefId { get; set; }

        [DataMember]
        public long nonOrgSubOrgRefId { get; set; }
    }
}
