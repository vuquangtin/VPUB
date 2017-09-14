using System.Runtime.Serialization;
using CampusModel.Model;

namespace CampusModel.Filters
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
    }
}
