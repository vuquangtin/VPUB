using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sTimeKeeping.Model
{
    [DataContract]
   public class EventFilter
    {
        [DataMember]
        public bool filterByMemberName { get; set; }

        [DataMember]
        public string memberName { get; set; }

        [DataMember]
        public bool filterByEventName { get; set; }

        [DataMember]
        public string eventName { get; set; }

        [DataMember]
        public bool filterByDateBegin { get; set; }

        [DataMember]
        public string dateBegin { get; set; }

        [DataMember]
        public bool filterByDateEnd { get; set; }

        [DataMember]
        public string dateEnd { get; set; }
    }
}
