using System;
using System.Collections.Generic;
using System.Runtime.Serialization;


namespace sMeetingComponent.Model.CustomObj.ContactForWorkObj
{
    [DataContract]
    public class SmeetingContactStatisticObj
    {
        public SmeetingContactStatisticObj()
        { }

        [DataMember]
        public List<SmeetingContactCount> contactStatistics { get; set; }
        [DataMember]
        public long sum { get; set; }
    }
}