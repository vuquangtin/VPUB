using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sWorldModel.Filters
{
    [DataContract]
    public class ConfigApartmentFilterDto
    {
        [DataMember]
        public bool FilterByName { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}
