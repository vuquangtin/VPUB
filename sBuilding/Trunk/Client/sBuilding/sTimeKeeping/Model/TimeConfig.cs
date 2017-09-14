using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sTimeKeeping.Model
{
    [DataContract]
    public class TimeConfig
    {
        [DataMember]
        public long timeConfigId { get; set; }
        [DataMember]
        public long orgId { get; set; }
        [DataMember]
        public int dayOfWeek { get; set; }
        [DataMember]
        public String sessionWorking { get; set; }



    }
}
