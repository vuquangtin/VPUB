using System;
using System.Runtime.Serialization;

namespace sMeetingComponent.Model.CustomObj.PersonNotBarcode
{
    [DataContract]
    public class PersonNotBarcode
    {
        public PersonNotBarcode()
        { }
        [DataMember]
        public long id { get; set; }
        [DataMember]
        public String name { get; set; }
        [DataMember]
        public String orgName { get; set; }
        [DataMember]
        public String position { get; set; }
        [DataMember]
        public String identityCard { get; set; }
        [DataMember]
        public String phonenumber { get; set; }
    }
}
