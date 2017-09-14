using System;
using System.Collections.Generic;
using System.Runtime.Serialization;


namespace sMeetingComponent.Model.CustomObj.JournalistObjForStatictis
{
    [DataContract]
    public class JournalistAttendStatisticObj
    {
        public JournalistAttendStatisticObj()
        { }
        [DataMember]
        public List<JournalistAttendStatistic> journalistAttendStatistics { get; set; }
        [DataMember]
        public long sum { get; set; }
    }
}
