using System;
using System.Runtime.Serialization;

namespace CampusModel.Model
{
    [DataContract]
    public class UserDto
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public bool IsRoot { get; set; }

        [DataMember]
        public long? GroupId { get; set; }

        [DataMember]
        public string GroupName { get; set; }

        [DataMember]
        public int Status { get; set; }

        [DataMember]
        public bool IsTeacher { get; set; }

        [DataMember]
        public PersonalInfoDto PersonalInfo { get; set; }
    }
}