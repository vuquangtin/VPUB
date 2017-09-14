using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sWorldModel.TransportData
{
    [DataContract]
    public class OrgCustomerDto
    {
        [DataMember]
        public long OrgId { get; set; }
        [DataMember]
        public long parentOrgId { get; set; }
        
        [DataMember]
        public string OrgCode { get; set; }

        [DataMember]
        public string OrgShortName { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Issuer { get; set; }

        [DataMember]
        public List<SubOrgCustomerDTO> SubOrgList { get; set; }
    }
}
