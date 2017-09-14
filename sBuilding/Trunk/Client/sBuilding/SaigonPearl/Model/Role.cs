using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace sBuildingCommunication.Model
{
    [DataContract]
    public class Role
    {
        [DataMember]
        public long RoleId { get; set; }

        [DataMember]
        public long Name { get; set; }
        [DataMember]
        public long DesCription { get; set; }

    }
}
