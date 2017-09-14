using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;


namespace sMeetingComponent.Model.CustomObj.InfoJournalistObj
{
    [DataContract]
    public class MeetingInfoJournalistObj
    {
        public MeetingInfoJournalistObj()
        { }
        //thông tin ngày giờ trạng thái của cuộc họp
        [DataMember]
        public AttendMeetingJournalist attendMeetingJournalist { get; set; }

        //thông tin nhà báo
        [DataMember]
        public Journalist journalist { get; set; }

        //280417 
        //[DataMember]
        //public Member journalist { get; set; }

        // To chuc cua nha bao
        [DataMember]
        public long orgId { get; set; }

        [DataMember]
        public String orgName { get; set; }
        //end 280417

        // danh sach cuoc hop duoc moi
        [DataMember]
        public List<EventMeeting> meetingInviteds { get; set; }
        // danh sach cuoc cuoc hop khong duoc moi
        [DataMember]
        public List<EventMeeting> meetingNotInviteds { get; set; }



    }
}

