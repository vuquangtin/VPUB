using System.Collections.Generic;
using System.Runtime.Serialization;

namespace sMeetingComponent.Model.CustomObj.PersonInfoForStatictis
{
    [DataContract]
    public class PersonAttendStatisticObj
    {
        public PersonAttendStatisticObj() { }
        [DataMember]
        public List<PersonAttendObj> personAttends { get; set; }
        [DataMember]
        public long sum { get; set; }
    }
}
