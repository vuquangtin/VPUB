
namespace sWorldModel.TransportData
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class CmsOrgCustomerDto
    {
        [DataMember]
        public long OrgId { get; set; }

        [DataMember]
        public string OrgCode { get; set; }

        [DataMember]
        public string OrgShortName { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public string Issuer { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string State { get; set; }

        [DataMember]
        public string CountryCode { get; set; }

        [DataMember]
        public string ZipCode { get; set; }

        [DataMember]
        public string Fax { get; set; }

        [DataMember]
        public string Phone { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string WebSite { get; set; }

        [DataMember]
        public string ContactName { get; set; }

        [DataMember]
        public string ContactEmail { get; set; }

        [DataMember]
        public string ContactPhone { get; set; }

        [DataMember]
        public string ContactMobile { get; set; }

        [DataMember]
        public string ContactFax { get; set; }

        [DataMember]
        public string Notes { get; set; }

        [DataMember]
        public string SettlementEmail { get; set; }

        [DataMember]
        public string SettlementFrequency { get; set; }

        [DataMember]
        public string Status { get; set; }
    }
}
