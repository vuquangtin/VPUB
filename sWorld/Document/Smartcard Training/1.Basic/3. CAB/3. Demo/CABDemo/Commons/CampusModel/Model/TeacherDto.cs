using System;
using System.Runtime.Serialization;

namespace CampusModel.Model
{
    [DataContract]
    public class TeacherDto
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public string Degree { get; set; }

        [DataMember]
        public string Position { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public bool? IsWorking { get; set; }

        [DataMember]
        public bool? IsWorkingAbroad { get; set; }

        [DataMember]
        public string ContractType { get; set; }

        [DataMember]
        public DateTime? ContractEndDate { get; set; }

        [DataMember]
        public DateTime? ContractStartDate { get; set; }

        [DataMember]
        public bool Personalized { get; set; }

        [DataMember]
        public PersonalInfoDto PersonalInfo { get; set; }

        [DataMember]
        public DateTime Revision { get; set; }

        [DataMember]
        public string HashCode { get; set; }

        [DataMember]
        public string ScaleOfSalary { get; set; }

        public string GetFullName()
        {
            return PersonalInfo != null ? PersonalInfo.GetFullName() : string.Empty;
        }
    }
}