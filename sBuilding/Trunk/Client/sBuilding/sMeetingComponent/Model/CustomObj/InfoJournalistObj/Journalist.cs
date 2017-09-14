using System.Runtime.Serialization;


namespace sMeetingComponent.Model.CustomObj.InfoJournalistObj
{
    [DataContract]
    public class Journalist
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public string serialNumber { get; set; }
        [DataMember]
        public long OrgId { get; set; }
        [DataMember]
        public string OrgName { get; set; }
        [DataMember]
        public string LowerFullName { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Position { get; set; }
        [DataMember]
        public string PhoneNo { get; set; }
        [DataMember]
        public string BirthDate { get; set; }
        [DataMember]
        public string IdentityCard { get; set; }

        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
    }
}
