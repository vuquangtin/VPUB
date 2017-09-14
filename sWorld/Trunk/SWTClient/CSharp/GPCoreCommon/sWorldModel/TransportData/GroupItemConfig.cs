using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sWorldModel.TransportData
{
    [DataContract]
    public partial class GroupItemConfig
    {
        [DataMember]
        public string groupName { get; set; }

        [DataMember]  
        public List<ItemDto>  lstItem { get; set; }
    }
}
