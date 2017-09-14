using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sWorldModel.TransportData
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class MemberDataImportExcelDTO
    {
        [DataMember]
        public long OrgId {get; set;}//partnerId

        [DataMember]
        public long SubOrgId { get; set; }

        [DataMember]
        public List<MemberDataImportFromExcelDto> MemberList { get; set; }
    }
}
