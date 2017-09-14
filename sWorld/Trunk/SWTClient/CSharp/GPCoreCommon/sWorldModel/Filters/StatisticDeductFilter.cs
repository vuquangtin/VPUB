﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sWorldModel.Filters
{
      [DataContract]
    public class StatisticDeductFilter
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
        public bool FilterBystatisticPayOutDate { get; set; }
        [DataMember]
        public StatisticPayInDate statisticPayOutDate { get; set; }
    }
}
