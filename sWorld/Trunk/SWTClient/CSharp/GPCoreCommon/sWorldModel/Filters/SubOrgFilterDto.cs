using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sWorldModel.Filters
{
    [DataContract]
    public class SubOrgFilterDto
    {
        [DataMember]
        public string ListParamsType { get; set; }
        [DataMember]
        public string ListParamsValue { get; set; }

        [DataMember]
        public string Status { get; set; }
    }
}
