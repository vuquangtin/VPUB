using System;
using System.Collections.Generic;
using System.Runtime.Serialization;


namespace sMeetingComponent.Model.CustomObj.ContactForWorkObj
{
    [DataContract]
    public class SmeetingContactStatisticDetailObj
    {
        public SmeetingContactStatisticDetailObj()
        { }

        [DataMember]
        public List<SmeetingContactStatistic> contactStatisticDetails { get; set; }
        [DataMember]
        public long sum { get; set; }
    }
}