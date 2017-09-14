using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sTimeKeeping.Model
{
    [DataContract]
    public class EventImportObject
    {
         [DataMember]
        public long OrgId { get; set; }
         [DataMember]
        public long SubOrgId { get; set; }
         [DataMember]
        public string EventName { get; set; }
         [DataMember]
        public string HourBegin { get; set; }
         [DataMember]
        public string Date { get; set; }
         [DataMember]
        public int HourKeeping { get; set; }
         [DataMember]
        public string Description { get; set; }
         [DataMember]
        public string MemberCode { get; set; }
         [DataMember]
        public string MemberName { get; set; }
    }
}
