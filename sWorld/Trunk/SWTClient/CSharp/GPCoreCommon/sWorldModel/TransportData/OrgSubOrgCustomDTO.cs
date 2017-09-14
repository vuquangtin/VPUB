using System.Runtime.Serialization;

namespace sWorldModel.TransportData {
    [DataContract]
    public class OrgSubOrgCustomDTO {
        [DataMember]
        public long id { get; set; }

        [DataMember]
        public long parentId { get; set; }

        [DataMember]
        public string name { get; set; }
    }
}
