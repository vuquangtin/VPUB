using System;
using System.Runtime.Serialization;

namespace sMeetingComponent.Model.CustomObj.ContactForWorkObj
{
    [DataContract]
    public class SmeetingContactCount
    {
        public SmeetingContactCount()
        { }

        [DataMember]
        public long orgId { get; set; }
        [DataMember]
        public String orgName { get; set; }
        [DataMember]
        public long sum { get; set; }
    }
}
