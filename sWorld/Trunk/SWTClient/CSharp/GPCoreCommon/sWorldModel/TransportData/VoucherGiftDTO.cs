using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace sWorldModel.TransportData
{
    [DataContract]
    public partial class VoucherGift
    {
        [DataMember]
        public long id { get; set; }

        [DataMember]
	    public long orgId  { get; set; }

        [DataMember]
	    public String area  { get; set; }

        [DataMember]
	    public int gender  { get; set; }

        [DataMember]
        public String dateBegin { get; set; }

        [DataMember]
        public String dateEnd { get; set; }

        [DataMember]
        public String dateBeginJoin { get; set; }

        [DataMember]
	    public String type  { get; set; }

        [DataMember]
	    public String title { get; set; }

        [DataMember]
	    public String description { get; set; }

        [DataMember]
	    public int status { get; set; }
    }
}
