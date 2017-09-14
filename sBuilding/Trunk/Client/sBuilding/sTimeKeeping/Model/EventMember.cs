using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sTimeKeeping.Model
{
    [DataContract]
    public class EventMember
    {
        [DataMember]
        public long eventmemberId { get; set; }
        [DataMember]
        public long eventId { get; set; }
        [DataMember]
        public long memberId { get; set; }
        [DataMember]
        public string memberName { get; set; }
    }
}
