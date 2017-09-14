using CampusModel.Model;
using System.Runtime.Serialization;

namespace CampusModel.Filters
{
    [DataContract]
    public class IntegratingLogFilterDto
    {
        [DataMember]
        public bool FilterByUserName { get; set; }
        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public bool FilterByIntegratingTime { get; set; }
        [DataMember]
        public TimePeriodDto IntegratingTimePeriod { get; set; }

        [DataMember]
        public bool FilterByResult { get; set; }
        [DataMember]
        public bool IntegratingSuccess { get; set; }

        [DataMember]
        public bool FilterByChangedType { get; set; }
        [DataMember]
        public string ChangedType { get; set; }
    }
}
