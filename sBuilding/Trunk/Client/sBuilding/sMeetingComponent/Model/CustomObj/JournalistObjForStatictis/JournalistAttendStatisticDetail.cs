using System.Runtime.Serialization;


namespace sMeetingComponent.Model.CustomObj.JournalistObjForStatictis
{

    [DataContract]
    public class JournalistAttendStatisticDetail
    {
        public JournalistAttendStatisticDetail()
        { }
        [DataMember]
        public long id { get; set; }
        [DataMember]
        public long organizationAttendId { get; set; }
        [DataMember]
        public string organizationAttendName { get; set; }
        //210417
        [DataMember]
        public string partakerPosition { get; set; }

        [DataMember]
        public string partakerName { get; set; }
        [DataMember]
        public string inputTime { get; set; }
        [DataMember]
        public string outputTime { get; set; }
        [DataMember]
        public string note { get; set; }
        // truong thong ke tong the chi tiet : thông tin cuộc họp
        [DataMember]
        public string meetingName { get; set; }
        [DataMember]
        public long organizationMeetingId { get; set; }
        [DataMember]
        public string organizationMeetingName { get; set; }
        [DataMember]
        public string startTime { get; set; }
        [DataMember]
        public string endTime { get; set; }
    }
}
