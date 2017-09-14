using System;
using System.Runtime.Serialization;

namespace sMeetingComponent.Model
{
    [DataContract]
    public class PartakerObj
    {
        public PartakerObj() { }
        [DataMember]
        public long id { get; set; }
        [DataMember]
        public long cardChipId { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string position { get; set; }
        [DataMember]
        public long orgId { get; set; }
        [DataMember]
        public String orgname { get; set; }
        [DataMember]
        public long referenceId { get; set; }

        //270317 sửa đối tượng  
        //barcode cho người đi họp
        [DataMember]
        public String barcode { get; set; }
        [DataMember]
        public String email { get; set; }
        //[DataMember]
        //public long orgPartakerId { get; set; }
        //end 270317 sửa đối tượng  
    }
}
