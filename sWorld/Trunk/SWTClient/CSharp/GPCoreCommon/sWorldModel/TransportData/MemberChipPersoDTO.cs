namespace sWorldModel.TransportData
{
    //<ChinhNguyen>
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class MemberCustomerDTO
    {
        [DataMember]
        public Member Member { get; set; }

        [DataMember]
        public PersoCardCustomerDTO PersoCard { get; set; }

        [DataMember]
        private MemberRelativeDto Relative { get; set; }
    }
}
