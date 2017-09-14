using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sWorldModel.Filters
{
    [DataContract]
    public class StatisticPayInDate
    {
        [DataMember]
        public bool FilterByDateIn { get; set; }
        [DataMember]
        public String DateIn { get; set; }

        [DataMember]
        public bool FilterByDateOut { get; set; }
        [DataMember]
        public String DateOut { get; set; }
    }
}
