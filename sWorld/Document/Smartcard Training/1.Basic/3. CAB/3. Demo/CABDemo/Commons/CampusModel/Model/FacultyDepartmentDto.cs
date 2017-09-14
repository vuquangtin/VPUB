using System.Runtime.Serialization;
using System.Collections.Generic;
using System;

namespace CampusModel.Model
{
    [DataContract]
    public class FacultyDepartmentDto
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

        [DataMember]
        public List<DepartmentDto> ListOfDepartments { get; set; }
    }
}
