using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sNonResidentComponent.Model.CustomObj.Statistic
{
    [DataContract]
    public class NonResidentStatisticObj
    {
        public NonResidentStatisticObj() { }
        [DataMember]
        public List<NonResidentStatistic> nonResidentStatistics { get; set; }
        [DataMember]
        public long sum { get; set; }
    }
}
