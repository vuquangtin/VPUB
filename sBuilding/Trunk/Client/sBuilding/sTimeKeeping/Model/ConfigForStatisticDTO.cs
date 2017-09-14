using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sTimeKeeping.Model
{
    /// <summary>
    /// ConfigForStatisticDTO : gom List Event & sessionWorking
    /// </summary>
     [DataContract]
    public class ConfigForStatisticDTO
    {
         [DataMember]
         public List<Event> eventList { get; set; }
         [DataMember]
         public String sessionWorking { get; set; }
    }
}
