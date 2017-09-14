using System.Runtime.Serialization;
using CampusModel.Model;

namespace CampusModel.Filters
{
    [DataContract]
    public class PersoFilterDto
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
        public bool FilterByDepartmentId { get; set; }
        [DataMember]
        public long DepartmentId { get; set; }

        [DataMember]
        public bool FilterByFacultyId { get; set; }
        [DataMember]
        public long FacultyId { get; set; }

        [DataMember]
        public bool FilterByPersoStatus { get; set; }
        [DataMember]
        public int PersoStatus { get; set; }

        [DataMember]
        public bool FilterByPersoDate { get; set; }
        [DataMember]
        public TimePeriodDto PersoDatePeriod { get; set; }

        [DataMember]
        public bool FilterRecordNeedToUpdate { get; set; }

        [DataMember]
        public bool ExcludeCanceledPerso { get; set; }
    }
}