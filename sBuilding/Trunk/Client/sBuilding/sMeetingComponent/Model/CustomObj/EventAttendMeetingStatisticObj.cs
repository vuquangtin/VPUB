using sMeetingComponent.Model.CustomObj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sMeetingComponent.Model
{
    [DataContract]
    public class EventAttendMeetingStatisticObj
    {
        public EventAttendMeetingStatisticObj() { }
        [DataMember]
        public List<EventAttendMeeting> eventAttendMeetingStatistics { get; set; }
        [DataMember]
        public List<PersonAttendObj> personAttendObj { get; set; }
        [DataMember]
        public long sum { get; set; }
    }
}
