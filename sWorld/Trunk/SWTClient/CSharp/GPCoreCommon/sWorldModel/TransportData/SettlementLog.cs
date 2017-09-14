using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sWorldModel.TransportData
{
    [DataContract]
    public class SettlementLog
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public long PayId { get; set; }
        [DataMember]
        public long AmountDifference { get; set; }
        [DataMember]
        public string SettlementDate { get; set; }
        [DataMember]
        public string SettlementBy { get; set; }
        /// <summary>
        /// 0: Successful
        /// 1: Processing
        /// </summary>
        [DataMember]
        public int Status { get; set; }
    }
}
