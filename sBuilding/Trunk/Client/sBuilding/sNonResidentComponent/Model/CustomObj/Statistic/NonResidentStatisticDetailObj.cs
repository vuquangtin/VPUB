using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sNonResidentComponent.Model.CustomObj.Statistic
{
    [DataContract]
    public class NonResidentStatisticDetailObj
    {
        public NonResidentStatisticDetailObj() { }
        [DataMember]
        public List<NonResidentObj> nonResidentObjs { get; set; }
        [DataMember]
        public long sum { get; set; }
    }
}
