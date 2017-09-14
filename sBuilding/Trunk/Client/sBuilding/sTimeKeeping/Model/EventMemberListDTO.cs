﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sTimeKeeping.Model
{
    [DataContract]
    public class EventMemberListDTO
    {
        [DataMember]
        public Event eventObj { get; set; }
        [DataMember]
        public List<EventMember> eventMemberListObj { get; set; }

    }
}