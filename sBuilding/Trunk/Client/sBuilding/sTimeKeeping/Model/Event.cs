using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sTimeKeeping.Model
{
      [DataContract]
    public class Event
    {
           [DataMember]
           public long eventId { get; set; }
           [DataMember]
           public string eventName { get; set; }
           [DataMember]
           public string dateIn { get; set; }
            [DataMember]
            public long orgId { get; set; }
           [DataMember]
           public long subOrgId { get; set; }
           [DataMember]
           public string hourEventBegin { get; set; }
           [DataMember]
           public int hourEventKeeping { get; set; }
           [DataMember]
           public string description { get; set; }
    }
}
