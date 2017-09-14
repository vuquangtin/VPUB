using sMeetingComponent.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sNonResidentComponent.Model.CustomObj.Statistic
{
    [DataContract]
    public class NonResidentObj
    {
        public NonResidentObj() { }
        [DataMember]
        public NonResident nonResident { get; set; }
        //image
        [DataMember]
        public string dataImageFace { get; set; }
        //image cmnd
        [DataMember]
        public string dataImageIdentityCard { get; set; }

    }

}

