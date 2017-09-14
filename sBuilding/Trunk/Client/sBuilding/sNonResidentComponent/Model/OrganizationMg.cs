using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sNonResidentComponent.Model.Old
{
    [DataContract]
    public class OrganizationMg
    {
        public OrganizationMg() { }
        [DataMember]
        public long id { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public long referenceId { get; set; }
        [DataMember]
        public int typeOrg { get; set; }
    }
}
