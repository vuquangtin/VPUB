
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sWorldModel.TransportData
{

    [DataContract]
    public partial class lockmoneycard
    {
        [DataMember]
        public long Id { get; set; } 

        [DataMember]
         private long PayInId{ get; set; }

        [DataMember]
         private long PayOutId{ get; set; }

        [DataMember]
         private String SerialNumber{ get; set; }

         [DataMember]
         private String LockMoneyDate{ get; set; }

         [DataMember]
         private String Description{ get; set; }

         [DataMember]
         private int SnysDataNumber{ get; set; }

         [DataMember]
         private String SnysDate{ get; set; }

         [DataMember]
         private int Status{ get; set; }


    }
}
