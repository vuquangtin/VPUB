using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sWorldModel.TransportData
{
    [DataContract]
    public class MemberRelativeDto
    {
        [DataMember]
        public long Id{ get; set; }

        [DataMember]
        public long MemberId{ get; set; }

        [DataMember]
        public String FullName{ get; set; }

        [DataMember]
        public String Address{ get; set; }

        [DataMember]
        public String Phone{ get; set; }

        [DataMember]
        public String Email{ get; set; }

        [DataMember]
        public String Type{ get; set; }

        [DataMember]
        public String CreateAt{ get; set; }

        [DataMember]
        public String CreateBy{ get; set; }

        [DataMember]
        public String ModifyAt{ get; set; }

        [DataMember]
        public String ModifyBy{ get; set; }

        [DataMember]
        public int Status{ get; set; }

        [DataMember]
        public string ImgRelative { get; set; }
    }
}
