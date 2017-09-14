using System;
using System.Runtime.Serialization;
using sWorldModel.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sWorldModel.Filters
{
    [DataContract]
    public class VoucherGiftFilterDto
    {
        [DataMember]
        public bool FilterByTitle { get; set; }
        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public bool FilterByTypeCard { get; set; }
        [DataMember]
        public string TypeCard { get; set; }

        [DataMember]
        public bool FilterByLocation { get; set; }
        [DataMember]
        public string Location { get; set; }

    }
}
