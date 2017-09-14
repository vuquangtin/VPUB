using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sBuildingCommunication.Model
{
    [DataContract]
    public class RoleChipPersionalDTO
    {
        [DataMember]
        public long memberId { get; set; }

        [DataMember]
        public string serialNumber { get; set; }
    }
}
