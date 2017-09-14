using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sBuildingCommunication.Model
{
    /// <summary>
    /// Bang nay dung de truy van khi nguoi dung tag the se vao day kiem tra
    /// </summary>
    [DataContract]
    public class PersonalizationDeviceDTO
    {
        [DataMember]
        public long personalizationDeviceId { get; set; }

        [DataMember]
        public long memberId { get; set; }

        [DataMember]
        public string serialNumber { get; set; }

        [DataMember]
        public long deviceId { get; set; }

        [DataMember]
        public long deviceIp { get; set; }
    }
}
