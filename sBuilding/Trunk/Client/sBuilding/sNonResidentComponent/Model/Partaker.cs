using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sNonResidentComponent.Model
{
    [DataContract]
    public class Partaker
    {
        public Partaker() { }
        [DataMember]
        public long id;
        [DataMember]
        public long cardChipId;
        [DataMember]
        public string name;
        [DataMember]
        public string position;
        [DataMember]
        public long orgId;
        [DataMember]
        public String orgname;
        [DataMember]
        public long referenceId;
    }
}
