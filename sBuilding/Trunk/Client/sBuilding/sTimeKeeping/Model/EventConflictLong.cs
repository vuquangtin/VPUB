using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sTimeKeeping.Model
{
    [DataContract]
    public class EventConflictLong
    {
        [DataMember]
        long memberId { get; set; }
    }
}
