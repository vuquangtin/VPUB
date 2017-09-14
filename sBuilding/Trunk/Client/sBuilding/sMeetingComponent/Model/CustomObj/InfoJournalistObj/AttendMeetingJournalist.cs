using System.Runtime.Serialization;


namespace sMeetingComponent.Model.CustomObj.InfoJournalistObj
{
    [DataContract]
    public class AttendMeetingJournalist
    {
        public AttendMeetingJournalist()
        { }
        //nhà báo, báo chí
        [DataMember]
        public string serialNumber { get; set; }
        [DataMember]
        public long OrgId { get; set; }
        [DataMember]
        public string orgJournalistName { get; set; }
        [DataMember]
        public string LowerFullName { get; set; }

        //cuộc họp
        [DataMember]
        public long meetingId { get; set; }
        [DataMember]
        public string meetingName { get; set; }
        [DataMember]
        public long organizationMeetingId { get; set; }
        [DataMember]
        public string orgMeetingName { get; set; }

        //không sử dụng nửa
        [DataMember]
        public long meetingOtherId { get; set; }
        [DataMember]
        public string meetingOtherName { get; set; }
        //end

        [DataMember]
        public string note { get; set; }
        [DataMember]
        public string inputTime { get; set; }
        [DataMember]
        public string outputTime { get; set; }

        [DataMember]
        public bool status { get; set; }
        [DataMember]
        public int numberOfParticipants { get; set; }//số cuộc họp được mời
        [DataMember]
        public int numberMeetingAdd { get; set; }//số cuộc họp được thêm vào
    }
}
