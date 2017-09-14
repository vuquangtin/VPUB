using System;
using System.Runtime.Serialization;


namespace sMeetingComponent.Model.CustomObj.PersonHaveBarcode
{
    [DataContract]
    public class DetailInfoOnlyPersonObj
    {
        public DetailInfoOnlyPersonObj()
        {
        }
        // danh sach khach duoc moi
        [DataMember]
        public int id{ get; set; }
        // meeting
        [DataMember]
        public int meetingId { get; set; }
        [DataMember]
        public String meetingname { get; set; }
        [DataMember]
        public string startTime { get; set; }
        [DataMember]
        public String note { get; set; }
        // partker
        [DataMember]
        public int partakerId { get; set; }
        [DataMember]
        public String partakerName { get; set; }
        [DataMember]
        public String position { get; set; }
        // don vi to chuc
        [DataMember]
        public int organizationMeetingId { get; set; }
        [DataMember]
        public String organizationMeetingName { get; set; }
        // don vi tham du
        [DataMember]
        public int organizationAttendId { get; set; }
        [DataMember]
        public String organizationAttendName { get; set; }
        // meeting invitation
        [DataMember]
        public int meetingInvitationId { get; set; }
    }
}
