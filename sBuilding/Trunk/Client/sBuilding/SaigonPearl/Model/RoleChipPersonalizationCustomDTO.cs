using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sBuildingCommunication.Model
{
    [DataContract]
    public class RoleChipPersonalizationCustomDTO
    {
        [DataMember]
        public long roleChipPersonalizationId { get; set; }
        [DataMember]
        public Member member { get; set; }



    }
}
