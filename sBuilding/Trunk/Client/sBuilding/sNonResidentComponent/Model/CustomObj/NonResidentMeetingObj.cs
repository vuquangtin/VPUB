using sMeetingComponent.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sNonResidentComponent.Model.CustomObj
{
    [DataContract]
    public class NonResidentMeetingObj
    {
        public NonResidentMeetingObj() { }
        [DataMember]
        public List<EventMeeting> nonResidentMeetings { get; set; }
        [DataMember]
        public long sum { get; set; }
    }
}
