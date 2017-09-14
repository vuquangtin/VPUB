using System;
using System.Runtime.Serialization;


namespace sMeetingComponent.Model.CustomObj.PersonHaveBarcode
{
    [DataContract]
    public class EventAttendMeeting
    {
        public EventAttendMeeting()
        {
        }
        [DataMember]
        public long id { get; set; }

        [DataMember]
        public String meetingBarcode { get; set; }
        [DataMember]
        public long meetingId { get; set; }
        [DataMember]
        public String meetingName { get; set; }
        // don vi to chuc cuoc hop
        [DataMember]
        public long organizationMeetingId { get; set; }
        [DataMember]
        public String organizationMeetingName { get; set; }

        [DataMember]
        public long partakerId { get; set; }
        [DataMember]
        public String partakerName { get; set; }
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
        public bool invited { get; set; }//được  thêm vào mới thì là false, được mời chính thức là true
        [DataMember]
        public bool status { get; set; }// ghi nhận flase, cho vào là true
    }
}
