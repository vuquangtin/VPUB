using System;
using System.Runtime.Serialization;

namespace CampusModel.Filters
{
    [DataContract]
    public class SampleFilter
    {
        [DataMember]
        public bool FilterByRegistrationDate { get; set; }

        [DataMember]
        public DateTime RegistrationFromDate { get; set; }

        [DataMember]
        public DateTime RegistrationToDate { get; set; }

        [DataMember]
        public bool FilterByStatus { get; set; }

        [DataMember]
        public bool IsBanned { get; set; }
    }
}
