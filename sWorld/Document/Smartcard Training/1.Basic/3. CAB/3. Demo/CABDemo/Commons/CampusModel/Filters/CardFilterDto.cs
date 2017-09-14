using System;
using System.Runtime.Serialization;
using CampusModel.Model;

namespace CampusModel.Filters
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
        public bool FilterByOutOfDateKey { get; set; }
    }
}