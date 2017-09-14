using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sWorldModel.Model
{
    [DataContract]
    public class MemberCompactDto
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string FirstName { get; set; }

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
        public DateTime Revision { get; set; }

        [DataMember]
        public string ScaleOfSalary { get; set; }

        public string GetFullName()
        {
            return (LastName == null ? string.Empty : LastName)
                + (FirstName == null ? string.Empty : FirstName);
        }
    }
}
