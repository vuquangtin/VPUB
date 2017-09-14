using System;
using System.Runtime.Serialization;


namespace sMeetingComponent.Model
{
    [DataContract]
    public class OrganizationMeeting
    {
        public OrganizationMeeting() { }
        [DataMember]
        public long id { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public long referenceId { get; set; }
        [DataMember]
        public int typeOrg { get; set; }//true: tổ chức cuộc họp, nội bộ . false: bên ngoài
    }
}
