using System.Runtime.Serialization;
using sWorldModel.Model;

namespace sWorldModel.Filters
{
    [DataContract]
    public class UserFilterDto
    {
        [DataMember]
        public bool FilterByUserStatus { get; set; }
        [DataMember]
        public int UserStatus { get; set; }

        [DataMember]
        public bool FilterByGroupId { get; set; }
        [DataMember]
        public long GroupId { get; set; }

        [DataMember]
        public int Start { get; set; }

        [DataMember]
        public int Count { get; set; }
    }
}
