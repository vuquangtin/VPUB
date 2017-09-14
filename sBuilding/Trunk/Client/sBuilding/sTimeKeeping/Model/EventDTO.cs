using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sTimeKeeping.Model
{
    [DataContract]
    public class EventDTO
    {
        [DataMember]
        public EventResultForGetEventDTO eventObj { get; set; }
        [DataMember]
        public EventMember eventMemberObj { get; set; }
    }
}
