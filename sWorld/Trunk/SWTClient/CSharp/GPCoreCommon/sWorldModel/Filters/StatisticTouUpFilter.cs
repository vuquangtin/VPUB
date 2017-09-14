using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sWorldModel.Filters
{
      [DataContract]
    public class StatisticTouUpFilter
    {
        [DataMember]
        public bool FilterByAmount { get; set; }
        [DataMember]
        public double Amount { get; set; }

        [DataMember]

        public bool FilterBySerialNumber { get; set; }
        [DataMember]
        public string SerialNumber { get; set; }

        [DataMember]
        public bool FilterBystatisticPayInDate { get; set; }
        [DataMember]
        public StatisticPayInDate statisticPayInDate { get; set; }
    }
}
