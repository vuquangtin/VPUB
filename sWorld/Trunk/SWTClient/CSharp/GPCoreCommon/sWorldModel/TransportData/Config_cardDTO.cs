using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace sWorldModel.TransportData
{
    [DataContract]
    public partial class Config_card
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public String Name { get; set; }

        [DataMember]
        public double Amount { get; set; }

        [DataMember]
        public String StartDate { get; set; }

        [DataMember]
        public String EndDate { get; set; }

        [DataMember]
        public String Description { get; set; }

        [DataMember]
        public long OrgId { get; set; }

        [DataMember]
        public int Status { get; set; }
    }
}
