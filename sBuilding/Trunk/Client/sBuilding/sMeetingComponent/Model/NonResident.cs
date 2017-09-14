using System;
using System.Runtime.Serialization;


namespace sMeetingComponent.Model {
    [DataContract]
    public class NonResident {
        public NonResident() { }
        [DataMember]
        public long id { get; set; }
        [DataMember]
        public String serialNumber { get; set; }
        [DataMember]
        public String name { get; set; }
        [DataMember]
        public String birthday { get; set; }
        [DataMember]
        public bool gender { get; set; }
        [DataMember]
        public String identityCard { get; set; }
        [DataMember]
        public String identityCardIssueDate { get; set; }
        [DataMember]
        public String identitycardIssue { get; set; }
        [DataMember]
        public String phonenumber { get; set; }
        [DataMember]
        public String temporaryAddress { get; set; }
        [DataMember]
        public String inputTime { get; set; }
        [DataMember]
        public String outputTime { get; set; }
        // den to chuc nao
        [DataMember]
        public long orgId { get; set; }
        [DataMember]
        public String orgName { get; set; }
        // den cuoc hop nao
        [DataMember]
        public long meetingId { get; set; }
        [DataMember]
        public String meetingName { get; set; }
        [DataMember]
        public String note { get; set; }
        [DataMember]
        public String nonResidentPosition { get; set; }
        [DataMember]
        public String nonResidentOrganization { get; set; }
        [DataMember]
        public int isPeople { get; set; }
        [DataMember]
        public long nonMemOrSubOrgId { get; set; }

        //truong phan biet có phai cho doanh nghiep vào hay khong
        [DataMember]
        public bool isOrgOther { get; set; }

        [DataMember]
        public bool status { get; set; }
    }
}

