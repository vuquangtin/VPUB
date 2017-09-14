using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sTimeKeeping.Model
{
    [DataContract]
    public class ShiftFilterDto
    {
        [DataMember]
        public bool FilterBySerialNumber { get; set; }
        [DataMember]
        public string SerialNumber { get; set; }
        [DataMember]
        public bool FilterByMemberId { get; set; }
        [DataMember]
        public long MemberId { get; set; }
        [DataMember]
        public bool FilterByDeviceDoorId { get; set; }
        [DataMember]
        public long DeviceDoorId { get; set; }
        [DataMember]
        public bool FilterByDeviceDoorIp { get; set; }
        [DataMember]
        public string DeviceDoorIp { get; set; }
        [DataMember]
        public bool FilterByDateIn { get; set; }
        [DataMember]
        public string DateIn { get; set; }


    }
}
