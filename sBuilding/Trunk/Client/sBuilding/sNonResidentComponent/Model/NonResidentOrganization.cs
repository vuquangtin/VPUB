using System.Runtime.Serialization;

namespace sNonResidentComponent.Model {
    [DataContract]
    public class NonResidentOrganization {
        [DataMember]
        public long nonOrgId { get; set; }

        [DataMember]
        public long nonOrgRefId { get; set; }

        [DataMember]
        public string nonOrgName { get; set; }

        [DataMember]
        public int isPeople { get; set; }

        [DataMember]
        public string orgCode { get; set; }
    }
}
