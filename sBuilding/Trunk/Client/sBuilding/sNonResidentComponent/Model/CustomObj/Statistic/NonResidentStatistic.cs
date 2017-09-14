using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sNonResidentComponent.Model.CustomObj.Statistic
{
    [DataContract]
    public class NonResidentStatistic
    {
        public NonResidentStatistic() { }
        [DataMember]
        public long orgId { get; set; }
        [DataMember]
        public string orgName { get; set; }
        [DataMember]
        public long number { get; set; }
    }
}
