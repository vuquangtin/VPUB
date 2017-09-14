using System;
using System.Runtime.Serialization;

namespace sWorldModel.Model
{
    [DataContract]
    public class FacultyDto
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string NameInitials { get; set; }

        [DataMember]
        public string ForeignName { get; set; }

        [DataMember]
        public DateTime Revision { get; set; }

        [DataMember]
        public string HashCode { get; set; }
    }
}
