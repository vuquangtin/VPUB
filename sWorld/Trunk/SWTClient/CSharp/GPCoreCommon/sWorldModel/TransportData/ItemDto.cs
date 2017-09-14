using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sWorldModel.TransportData
{
    [DataContract]
     public partial class ItemDto
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public long GroupId { get; set; }
        
        [DataMember]
        public double Price { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public String StartDate { get; set; }

        [DataMember]
        public String EndDate { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int Status { get; set; }

        [DataMember]
        public int SnysDataNumber { get; set; }

        [DataMember]
        public String SnysDate { get; set; }

    }
}
