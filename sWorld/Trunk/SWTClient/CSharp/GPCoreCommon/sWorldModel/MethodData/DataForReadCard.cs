using sWorldModel.Model;
using sWorldModel.TransportData;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace sWorldModel.MethodData
{
    [DataContract]
    public class DataForReadCard
    {
        [DataMember]
        public long MemberId { get; set; }

        [DataMember]
        public string FullName { get; set; }

        [DataMember]
        public string BirthDate { get; set; }

        [DataMember]
        public string PhoneNo { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public List<int> AppIds { get; set; }
    }
}
