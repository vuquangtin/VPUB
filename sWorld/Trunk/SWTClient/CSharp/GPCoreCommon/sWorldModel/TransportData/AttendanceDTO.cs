
namespace sWorldModel.TransportData
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class Attendance
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public String SerialNumber { get; set; }

        [DataMember]
        public long MemberId { get; set; }

        [DataMember]
        public String DateIn { get; set; }

        [DataMember]
        public String DateOut { get; set; }

        [DataMember]
        public int Status { get; set; }

        [DataMember]
        public String ImgIn { get; set; }

        [DataMember]
        public String ImgOut { get; set; }
    }
}
