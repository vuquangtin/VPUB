using System.Runtime.Serialization;
namespace sMeetingComponent.Model.CustomObj.PersonInfoForStatictis
{
    [DataContract]
    public class PersonAttendDetail
    {
        public PersonAttendDetail()
        { }
        [DataMember]
        public long organizationAttendId { get; set; }
        [DataMember]
        public string organizationAttendName { get; set; }
        [DataMember]
        public string partakerName { get; set; }

        //210417
        [DataMember]
        public string partakerPosition { get; set; }
        [DataMember]
        public bool status { get; set; }

        [DataMember]
        public bool add { get; set; }

        [DataMember]
        public bool journalist { get; set; }
        //ĐỔI TÊN ĐÚNG KHÔNG CHẠY ĐƯỢC
        // public bool isJournalist { get; set; }

        [DataMember]
        public string inputTime { get; set; }
        [DataMember]
        public string outputTime { get; set; }
        [DataMember]
        public string note { get; set; }

        // truong de thong ke tong the chi tiet : thông tin cuộc họp
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

        //trường khách vãng lai
        [DataMember]
        public bool isNonresident { get; set; }
        [DataMember]
        public string identityCard { get; set; }
        [DataMember]
        public string phonenumber { get; set; }

    }
}
