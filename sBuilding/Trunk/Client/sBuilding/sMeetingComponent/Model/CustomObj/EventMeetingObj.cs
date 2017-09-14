using System;
using System.Collections.Generic;
using System.Runtime.Serialization;


namespace sMeetingComponent.Model.CustomObj
{
    [DataContract]
    public class EventMeetingObj
    {
        public EventMeetingObj() { }
        [DataMember]
        public List<EventMeeting> meetings { get; set; }
        [DataMember]
        public long sum { get; set; }
    }
}
