using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sTimeKeeping.Model
{
    [DataContract]
    public class DayOffImportObject
    {
        [DataMember]
        public long OrgId { get; set; }

        [DataMember]
        public long SubOrgId { get; set; }

        [DataMember]
        public string MemberCode { get; set; }

        [DataMember]
        public string MemberName { get; set; }

        [DataMember]
        public string DateOff { get; set; }

        [DataMember]
        public int TypeDayOff { get; set; }

        [DataMember]
        public string Note { get; set; }
    }
}
