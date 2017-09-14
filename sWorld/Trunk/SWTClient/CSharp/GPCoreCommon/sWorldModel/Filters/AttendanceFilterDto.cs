using System;
using System.Runtime.Serialization;
using sWorldModel.Model;

namespace sWorldModel.Filters
{
    [DataContract]
    public class AttendanceFilterDto
    {
        [DataMember]
        public bool FilterBySerialNumber { get; set; }
        [DataMember]
        public string SerialNumber { get; set; }

        [DataMember]
        public bool FilterByMemberName { get; set; }
        [DataMember]
        public string MemberName { get; set; }

        [DataMember]
        public bool FilterByDateIn { get; set; }
        [DataMember]
        public String DateIn { get; set; }

        [DataMember]
        public bool FilterByDateOut { get; set; }
        [DataMember]
        public String DateOut { get; set; }

        [DataMember]
        public int Start { get; set; }

        [DataMember]
        public int Count { get; set; }
    }
}