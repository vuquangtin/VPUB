using System;
using System.Collections.Generic;
using System.Linq;
using sWorldModel.Model;
using System.Runtime.Serialization;
using System.Text;

namespace sWorldModel.Filters
{
    [DataContract]
    public class EcashConfigFilterDto
    {

        [DataMember]
        public bool FilterByName { get; set; }
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public bool FilterByAmount { get; set; }
        [DataMember]
        public double Amount { get; set; }


        [DataMember]
        public bool FilterBystatisticPayInDate { get; set; }
        [DataMember]
        public StatisticPayInDate statisticPayInDate { get; set; }

        //[DataMember]
        //public bool FilterByStartDate { get; set; }
        //[DataMember]
        //public DateTime StartDate { get; set; }

    }
}
