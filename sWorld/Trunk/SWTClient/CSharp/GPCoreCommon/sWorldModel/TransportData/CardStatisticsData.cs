using System;
using System.Runtime.Serialization;

namespace sWorldModel.TransportData
{
    [DataContract]
    public class CardStatisticsData
    {
        [DataMember]
        public int Status { get; set; }

        [DataMember]
        public int Amount { get; set; }
    }
}