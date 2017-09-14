using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sBuildingCommunication.Model
{
    /// <summary>
    /// class nay dung de map nhom nguoi dung va nguoi dung
    /// </summary>
    [DataContract]
    public class RoleChipPersonalizationDTO
    {
        [DataMember]
        public long roleChipPersonalizationId { get; set; }
        [DataMember]
        public long roleId { get; set; }
        [DataMember]
        public string serialNumber { get; set; }
        [DataMember]
        public long memberId { get; set; }
    }
}
