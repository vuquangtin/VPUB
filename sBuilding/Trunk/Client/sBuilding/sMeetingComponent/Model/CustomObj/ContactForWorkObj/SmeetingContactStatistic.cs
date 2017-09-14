using System;
using System.Runtime.Serialization;


namespace sMeetingComponent.Model.CustomObj.ContactForWorkObj
{
    [DataContract]
    public class SmeetingContactStatistic
    {
        public SmeetingContactStatistic()
        { }

        [DataMember]
        public long id { get; set; }
        // thong tin nguoi vao lien he
        [DataMember]
        public String partakerName { get; set; }
        [DataMember]
        public String position { get; set; }
        [DataMember]
        public String identityCard { get; set; }
        [DataMember]
        public String phonenumber { get; set; }
        // don vi to chuc cuoc hop
        [DataMember]
        public long organizationMeetingId { get; set; }
        [DataMember]
        public String organizationMeetingName { get; set; }
        // don vi duoc moi tham du cuoc hop
        [DataMember]
        public long organizationAttendId { get; set; }
        [DataMember]
        public String organizationAttendName { get; set; }
        [DataMember]
        public String note { get; set; }
        [DataMember]
        public String inputTime { get; set; }
        [DataMember]
        public String outputTime { get; set; }

        [DataMember]
        public bool status { get; set; }// ghi nhận flase, cho vào là true
    }
}

