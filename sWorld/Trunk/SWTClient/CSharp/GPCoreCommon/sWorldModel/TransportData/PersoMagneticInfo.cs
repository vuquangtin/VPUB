using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sWorldModel.TransportData
{
    [DataContract]
    public class PersoMagneticInfo
    {
        [DataMember]
        public DateTime? BirthDate { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string Gender { get; set; }

        [DataMember]
        public DateTime? IdCardIssuedDate { get; set; }

        [DataMember]
        public string IdCardIssuedPlace { get; set; }

        [DataMember]
        public string IdCardNo { get; set; }

        [DataMember]
        public string ImagePath { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Nationality { get; set; }

        [DataMember]
        public string PermanentAddress { get; set; }

        [DataMember]
        public string PhoneNo { get; set; }

        [DataMember]
        public string TemporaryAddress { get; set; }

        public string GetFullName()
        {
            string firstName = FirstName == null ? string.Empty : FirstName;
            string lastName = LastName == null ? string.Empty : LastName;
            return string.Format("{0} {1}", lastName, firstName);
        }
    }
}
