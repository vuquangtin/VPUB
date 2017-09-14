using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sWorldModel.Integrating
{
    [DataContract]
    public abstract class IntegratingTable
    {
        [DataMember]
        public string HashCode { get; set; }
    }
}
