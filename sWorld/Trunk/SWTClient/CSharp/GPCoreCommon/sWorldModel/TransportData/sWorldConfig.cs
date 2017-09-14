using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sWorldModel.TransportData
{
    [DataContract]
    public class sWorldConfig
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public String Name { get; set; }

        [DataMember]
        public String Value { get; set; }

        [DataMember]
        public String updateddate { get; set; }

        [DataMember]
        public int status { get; set; }
    }
}
