using System.Runtime.Serialization;

namespace sNonResidentComponent.Model {
    [DataContract]
    public class NonResidentSubOrganization {
        [DataMember]
        public long nonSubOrgId { get; set; }

        [DataMember]
        public long nonSubOrgRefId { get; set; }

        [DataMember]
        public long nonOrgId { get; set; }

        [DataMember]
        public string nonSubOrgName { get; set; }
    }
}
