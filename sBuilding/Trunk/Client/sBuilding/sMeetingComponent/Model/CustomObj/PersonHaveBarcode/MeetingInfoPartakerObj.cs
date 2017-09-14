using System.Runtime.Serialization;

//author TaiMai
namespace sMeetingComponent.Model.CustomObj.PersonHaveBarcode
{
    [DataContract]
    public class MeetingInfoPartakerObj
    {
        public MeetingInfoPartakerObj()
        {
        }
        //v1.0
        //[DataMember]
        //public EventMeeting meeting { get; set; }
        ////[DataMember]
        ////public Room room { get; set; }
        //////đơn vị tổ chức cuộc họp
        ////[DataMember]
        ////public OrganizationMeeting organizationMeeting { get; set; }
        //[DataMember]
        //public List<Partaker> partakers { get; set; }
        ////đơn vị tổ chức đx mời
        //[DataMember]
        //public OrganizationMeeting organizationAttend { get; set; }

        //v2
        [DataMember]
        public DetailInfoOnlyPersonObj detailInfoOnlyPerson { get; set; }

        // danh sach khach duoc moi
        //[DataMember]
        //public List<Partaker> partakers { get; set; }
    }
}
