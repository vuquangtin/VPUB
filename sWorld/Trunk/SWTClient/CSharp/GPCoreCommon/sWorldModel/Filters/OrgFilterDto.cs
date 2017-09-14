using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sWorldModel.Filters
{
    [DataContract]
    public class OrgFilterDto
    {
        [DataMember]
        public bool FilterByOrgName { get; set; }
        [DataMember]
        public string OrgName { get; set; }

        [DataMember]
        public bool FilterByOrgCode { get; set; }
        [DataMember]
        public string OrgCode { get; set; }
    }
}
