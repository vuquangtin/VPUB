using System.Runtime.Serialization;
using sWorldModel.Model;

namespace sWorldModel.Filters
{
    [DataContract]
    public class MemberFilter
    {
        [DataMember]
        public bool FilterByMemberName { get; set; }
        [DataMember]
        public string MemberName { get; set; }
        [DataMember]
        public bool FilterByCode { get; set; }
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public bool FilterByActive { get; set; }
        [DataMember]
        public bool Active { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string Title { get; set; }
    }
}
