using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CampusModel.Model
{
    [DataContract]
    public class GroupFunctionDto
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public List<long> Functions { get; set; }
    }
}