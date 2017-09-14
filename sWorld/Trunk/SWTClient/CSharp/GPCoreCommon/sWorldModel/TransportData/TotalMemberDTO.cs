using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sWorldModel.TransportData
{
     [DataContract]
    public class TotalMemberDTO
    {
          [DataMember]
         public long totalMember { get; set; }
    }
}
