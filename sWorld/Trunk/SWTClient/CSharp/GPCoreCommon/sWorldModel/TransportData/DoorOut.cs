using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sWorldModel.TransportData
{
    [DataContract]
    public class DoorOut
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public long SubOrgId{ get; set; }

        [DataMember]
        public long MemberId{ get; set; }

        [DataMember]
        public long CardId{ get; set; }

        [DataMember]
        public long DeviceDoorId{ get; set; }

        [DataMember]
        public String SerialNumber{ get; set; }

        [DataMember]
        public String DateIn{ get; set; }

        [DataMember]
        public String DateOut{ get; set; }

        [DataMember]
        public String ImageIn{ get; set; }

        [DataMember]
        public String ImageOut{ get; set; }

        [DataMember]
        public String CreateBy{ get; set; }

        [DataMember]
        public String CreateAt{ get; set; }

        [DataMember]
        public String ModifiedBy{ get; set; }

        [DataMember]
        public String ModifiedAt{ get; set; }

        [DataMember]
        public int Status{ get; set; }

    }
}
