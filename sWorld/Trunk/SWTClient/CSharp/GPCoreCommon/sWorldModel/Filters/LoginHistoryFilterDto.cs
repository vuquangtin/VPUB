using sWorldModel.TransportData;
using System;
using System.Runtime.Serialization;

namespace sWorldModel.Filters
{
    [DataContract]
    public class LoginHistoryFilterDto
    {
        [DataMember]
        public bool FilterByUserName { get; set; }
        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public bool FilterByLoginTime { get; set; }
        [DataMember]
        public TimePeriodDto LoginTimePeriod { get; set; }

        [DataMember]
        public bool FilterByLoginResult { get; set; }
        [DataMember]
        public bool LoginSuccess { get; set; }

        [DataMember]
        public int Start { get; set; }

        [DataMember]
        public int Count { get; set; }

        [DataMember]
        public string Status { get; set; }
    }
}
