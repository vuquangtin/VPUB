using System.Runtime.Serialization;


namespace sMeetingComponent.Model.CustomObj.PersonInfoForStatictis
{

    [DataContract]
    public class PersonAttendObj
    {
        public PersonAttendObj()
        { }
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
        public long sumPeopleAttendInvited { get; set; }//so nguoi duoc moi
        [DataMember]
        public int numberPeopleAttendInvited { get; set; }//nguoi duoc moi ma tham du
        [DataMember]
        public int numberPeopleAdded { get; set; }
        [DataMember]
        public int numberJournalist { get; set; }
        //thống kê số lượng KHÁCH VÃNG LAI
        [DataMember]
        public int numberNonresident { get; set; }
    }
}

