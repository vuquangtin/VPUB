using System.Collections.Generic;
using System.Runtime.Serialization;

namespace sWorldModel.TransportData
{
    [DataContract]
    public class GroupCustomerDto
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public List<PolicySworld> PolicySworlds { get; set; }
    }
}