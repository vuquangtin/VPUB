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
    public partial class SubOrganization
    {

        [DataMember]
        public long suborgid { get; set; }

        [DataMember]
        public long orgid{ get; set; }
        [DataMember]
        public long parentOrgId { get; set; }

        [DataMember]
        public String orgcode{ get; set; }

        [DataMember]
        public String orgshortname{ get; set; }

        [DataMember]
        public String names{ get; set; }

        [DataMember]
        public String shortname{ get; set; }

        [DataMember]
        public String address{ get; set; }

        [DataMember]
        public String city{ get; set; }

        [DataMember]
        public String State{ get; set; }

        [DataMember]
        public String countrycode{ get; set; }

        [DataMember]
        public String zipcode{ get; set; }

        [DataMember]
        public String fax{ get; set; }

        [DataMember]
        public String email{ get; set; }

        [DataMember]
        public String phone{ get; set; }

        [DataMember]
        public String website{ get; set; }

        [DataMember]
        public String contactname{ get; set; }

        [DataMember]
        public String contactemail{ get; set; }

        [DataMember]
        public String contactphone{ get; set; }

        [DataMember]
        public String notes{ get; set; }

        [DataMember]
        public String settlementemail{ get; set; }

        [DataMember]
        public String createdby{ get; set; }

        [DataMember]
        public String createdon{ get; set; }

        [DataMember]
        public String modifiedby{ get; set; }

        [DataMember]
        public String modifiedon{ get; set; }

        [DataMember]
        public String transferDate { get; set; }

        [DataMember]
        public int status{ get; set; }

        [DataMember]
        public String SwtGroup{ get; set; }

    }
}
