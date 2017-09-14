using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sWorldModel.TransportData
{
    [DataContract]
    public class ConfigApartment
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public long NumberMonthPay { get; set; }

        [DataMember]
        public int Status { get; set; }
    }
}
