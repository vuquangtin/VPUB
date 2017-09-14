using System.Runtime.Serialization;

namespace sWorldModel.TransportData {
    [DataContract]
    public class MoveMemberSubOrg {
        [DataMember]
        public long memberID { get; set; }
        [DataMember]
        public bool isLeft { get; set; }
    }
}
