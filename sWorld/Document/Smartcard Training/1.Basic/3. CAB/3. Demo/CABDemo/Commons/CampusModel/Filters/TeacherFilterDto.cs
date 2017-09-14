using System.Runtime.Serialization;
using CampusModel.Model;

namespace CampusModel.Filters
{
    [DataContract]
    public class TeacherFilterDto
    {
        [DataMember]
        public bool FilterByTeacherName { get; set; }
        [DataMember]
        public string TeacherName { get; set; }

        [DataMember]
        public bool FilterByTeacherCode { get; set; }
        [DataMember]
        public string TeacherCode { get; set; }

        [DataMember]
        public bool FilterByPersoStatus { get; set; }
        [DataMember]
        public bool Personalized { get; set; }

        [DataMember]
        public bool FilterByFaculty { get; set; }
        [DataMember]
        public long FacultyId { get; set; }

        [DataMember]
        public bool FilterByDepartment { get; set; }
        [DataMember]
        public long DepartmentId { get; set; }

        [DataMember]
        public bool FilterByWorkingStatus { get; set; }
        [DataMember]
        public int WorkingStatus { get; set; }
    }
}
