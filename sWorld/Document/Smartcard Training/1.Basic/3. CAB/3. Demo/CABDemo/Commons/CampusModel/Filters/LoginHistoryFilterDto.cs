using CampusModel.Model;
using System;
using System.Runtime.Serialization;

namespace CampusModel.Filters
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
    }
}
