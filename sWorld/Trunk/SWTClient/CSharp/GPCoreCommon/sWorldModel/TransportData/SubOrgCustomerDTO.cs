//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace sWorldModel.TransportData
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public partial class SubOrgCustomerDTO
    {

        [DataMember]
        public long SubOrgId { get; set; }

        [DataMember]
        public long OrgId { get; set; }

        [DataMember]
        public long parentOrgId { get; set; }
        [DataMember]
        public string OrgCode { get; set; }

        [DataMember]
        public string OrgShortName { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string SwtGroup { get; set; }
    }
}
