using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sTimeKeeping.Model
{
     [DataContract]
    public class UserTimeConfig
    {
          [DataMember]
         public long id { get; set; }
          [DataMember]
         public long orgId { get; set; }
          [DataMember]
         public long memberId { get; set; }
          [DataMember]
         public int dayOfWeek { get; set; }
          [DataMember]
         public string sessionWorking { get; set; }

    }
}
