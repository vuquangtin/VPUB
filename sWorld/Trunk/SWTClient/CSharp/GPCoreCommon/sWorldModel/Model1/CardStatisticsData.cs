using System;
using System.Runtime.Serialization;

namespace sWorldModel.Model
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