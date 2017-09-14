using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sBuildingCommunication.Model
{
    /// <summary>
    /// Class nay dung de phan nhom nguoi dung
    /// </summary>
    [DataContract]
    public class RoleDTO
    {
        [DataMember]
        public long roleId { get; set; }
        [DataMember]
        public string name { get; set; }

        [DataMember]
        public string description { get; set; }
    }
}
