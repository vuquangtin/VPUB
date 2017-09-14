using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sTimeKeeping.Model
{
    [DataContract]
    public class TimeKeepingAcessDTO
    {
        [DataMember]
        public int memberId { get; set; }
        [DataMember]
        public int deviceDoorId { get; set; }
    }
}
