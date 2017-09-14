using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace sMeetingComponent.Model.CustomObj.PersonInfoForStatictis
{
    [DataContract]
    public class PersonAttendDetailObj
    {
        public PersonAttendDetailObj()
        {}
        [DataMember]
        public List<PersonAttendDetail> personAttendDetails { get; set; }
        [DataMember]
        public List<NonResident> nonresidentDetails { get; set; } //thêm vào để xem danh sách khách vãng lai tham dự họp
        [DataMember]
        public long sum { get; set; }
    }
}
