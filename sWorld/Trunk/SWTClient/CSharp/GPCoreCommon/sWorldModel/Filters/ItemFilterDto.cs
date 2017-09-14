using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sWorldModel.Filters
{
     [DataContract]
    public class ItemFilterDto
    {
          [DataMember]
          public bool FilterByName { get; set; }
          [DataMember]
          public String Name { get; set; }

          [DataMember]
          public bool FilterByPrice { get; set; }
          [DataMember]
          public double Price { get; set; }

          [DataMember]
          public bool FilterBystatisticItemDate { get; set; }
          [DataMember]
          public StatisticPayInDate statisticItemDate { get; set; }
    }
}
