using sWorldModel.TransportData;
using System;
using System.Runtime.Serialization;

namespace sWorldModel.Filters
{
    [DataContract]
    public class PersoChipFilter
    {
        [DataMember]
        public bool FilterByMemberName { get; set; }
        [DataMember]
        public string MemberName { get; set; }

        [DataMember]
        public bool FilterByMemberCode { get; set; }
        [DataMember]
        public string MemberCode { get; set; }

        [DataMember]
        public bool FilterByPersoStatus { get; set; }
        [DataMember]
        public int PersoStatus { get; set; }

        [DataMember]
        public bool FilterByPersoDate { get; set; }
        [DataMember]
        public TimePeriodDto PersoDatePeriod { get; set; }

        [DataMember]
        public bool FilterRecordNeedToUpdate { get; set; }

        [DataMember]
        public bool ExcludeCanceledPerso { get; set; }

        [DataMember]
        public int Start { get; set; }

        [DataMember]
        public int Count { get; set; }

        [DataMember]
        public string Status { get; set; }
       
    }
}