using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sTimeKeeping.Model
{
    [DataContract]
    public class TimeKeepingImage
    {
        [DataMember]
        public String image { get; set; }
    }
}
