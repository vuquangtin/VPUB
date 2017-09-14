using System;
using System.Runtime.Serialization;
using sWorldModel.Model;

namespace sWorldModel.Filters
{
    [DataContract]
    public class CardFilterDto
    {
        [DataMember]
        public bool FilterByPhysicalStatus { get; set; }
        [DataMember]
        public int PhysicalStatus { get; set; }

        [DataMember]
        public bool FilterByPersoStatus { get; set; }
        [DataMember]
        public bool Personalized { get; set; }

        [DataMember]
        public bool FilterByCardType { get; set; }
        [DataMember]
        public int CardType { get; set; }

        [DataMember]
        public int Start { get; set; }

        [DataMember]
        public int Count { get; set; }
    }
}