using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace sMeetingComponent.Model.CustomObj.JournalistObjForStatictis
{

    [DataContract]
    public class JournalistAttendStatisticDetailObj
    {
        public JournalistAttendStatisticDetailObj()
        { }
        [DataMember]
        public List<JournalistAttendStatisticDetail> attendStatisticDetails { get; set; }
        [DataMember]
        public long sum { get; set; }
    }
}
