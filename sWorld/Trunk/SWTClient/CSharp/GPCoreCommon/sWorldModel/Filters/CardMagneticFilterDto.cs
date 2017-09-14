using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using sWorldModel.TransportData;

namespace sWorldModel.Filters
{

    [DataContract]
    public class CardMagneticFilterDto
    {
        //List<CMSCardmagneticDto> 
        [DataMember]
        public bool FilterByOrgMaster { get; set; }
        [DataMember]
        public long OrgMasterId { get; set; }

        [DataMember]
        public bool FilterByOrgPartner { get; set; }
        [DataMember]
        public long OrgPartnerId { get; set; }

        [DataMember]
        public bool FilterByCardType { get; set; }
        [DataMember]
        public string Prefix { get; set; }

        [DataMember]
        public bool FilterByCardStatus { get; set; }
        [DataMember]
        public int CardStatus { get; set; }

        [DataMember]
        public bool FilterByCardPhysicalStatus { get; set; }
        [DataMember]
        public int CardPhysicalStatus { get; set; }

        [DataMember]
        public bool FilterByCardPrintedStatus { get; set; }
        [DataMember]
        public int CardPrintedStatus { get; set; }

        [DataMember]
        public bool FilterByMemberName { get; set; }
        [DataMember]
        public string MemberName { get; set; }

        [DataMember]
        public bool FilterByPhoneNumber { get; set; }
        [DataMember]
        public string PhoneNumber { get; set; }

        [DataMember]
        public bool FilterByPersoDate { get; set; }
        [DataMember]
        public TimePeriodDto PersoDatePeriod { get; set; }

    }
}
