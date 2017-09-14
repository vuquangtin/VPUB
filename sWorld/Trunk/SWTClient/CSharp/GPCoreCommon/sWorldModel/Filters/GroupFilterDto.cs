using System.Runtime.Serialization;

namespace sWorldModel.Filters
{
    [DataContract]
    public class GroupFilterDto
    {
        [DataMember]
        public bool FilterByName { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}
