using System.Runtime.Serialization;

namespace CampusModel.Model
{
    [DataContract]
    public class GroupDto
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int Status { get; set; }
    }
}
