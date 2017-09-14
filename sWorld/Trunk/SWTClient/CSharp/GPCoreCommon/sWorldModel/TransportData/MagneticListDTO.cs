using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace sWorldModel.TransportData
{
    [DataContract]
    public class MagneticListDTO
    {        
        [DataMember]
        public long CardMagneticId { get; set; }

         [DataMember]
        public long MemberId { get; set; }

         [DataMember]
        public string FullName { get; set; }

         [DataMember]
         public string OrgName { get; set; }

         [DataMember]
         public string SubOrgName { get; set; }

         [DataMember]
        public string CompayName { get; set; }

         [DataMember]
        public string PhoneNumber { get; set; }

        [DataMember]
        public string SerialCard { get; set; }

        [DataMember]
        public string TrackData { get; set; }

        [DataMember]
        public string PinCodeNew { get; set; }

        [DataMember]
        public string ActiveCodeNew { get; set; }

        [DataMember]
        public string PersoDate { get; set; }

        [DataMember]
        public string ExpirationDate { get; set; }

        [DataMember]
        public int LogicalStatus { get; set; }

        [DataMember]
        public int PhysicalStatus { get; set; }

        [DataMember]
        public string Notes { get; set; }

        [DataMember]
        public int Status { get; set; }
    }
}


