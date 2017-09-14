using System.Runtime.Serialization;


namespace sMeetingComponent.Model.CustomObj.JournalistObjForStatictis
{

    [DataContract]
    public class JournalistAttendStatistic
    {
        public JournalistAttendStatistic()
        { }
        [DataMember]
        public long id { get; set; }
        [DataMember]
        public long meetingId { get; set; }
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
        [DataMember]
        public int numberJournalist { get; set; }
    }
}
