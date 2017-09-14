using System;
using System.Runtime.Serialization;

namespace CampusModel.Model
{
    [DataContract]
    public class PersonalizationDto
    {
        [DataMember]
        public long PersoId { get; set; }

        [DataMember]
        public int PersoStatus { get; set; }

        [DataMember]
        public DateTime PersoDate { get; set; }

        [DataMember]
        public DateTime? ExpirationDate { get; set; }

        [DataMember]
        public string Notes { get; set; }

        [DataMember]
        public TeacherCompactDto Teacher { get; set; }

        [DataMember]
        public CardCompactDto Card { get; set; }
    }
}
