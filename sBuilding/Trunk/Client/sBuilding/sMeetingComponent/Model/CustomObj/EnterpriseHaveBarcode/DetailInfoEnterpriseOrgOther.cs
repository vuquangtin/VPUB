using System.Runtime.Serialization;

namespace sMeetingComponent.Model.CustomObj.EnterpriseHaveBarcode
{
    [DataContract]
    public class DetailInfoEnterpriseOrgOther
    {
        public DetailInfoEnterpriseOrgOther()
        {
        }
        // danh sach khach duoc moi
        [DataMember]
        public long meetingId { get; set; }
        [DataMember]
        public string meetingname { get; set; }
        [DataMember]
        public string startTime { get; set; }
        [DataMember]
        public string note { get; set; }

        // don vi to chuc
        [DataMember]
        public long organizationMeetingId { get; set; }
        [DataMember]
        public string organizationMeetingName { get; set; }

        // don vi tham du
        [DataMember]
        public long organizationAttendId { get; set; }
        [DataMember]
        public string organizationAttendName { get; set; }
        [DataMember]
        public string organizationAttendCode { get; set; }
    }
}
