using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sMeetingComponent.Model.CustomObj.PersonNotBarcode
{
    [DataContract]
    public class PersonNotBarcodeObj
    {
        public PersonNotBarcodeObj()
        { }
        [DataMember]
        public string inputTime { get; set; }
        [DataMember]
        public string outputTime { get; set; }
        [DataMember]
        public long meetingId { get; set; }
        [DataMember]
        public String meetingName { get; set; }
        [DataMember]
        public String note { get; set; }
        [DataMember]
        public long organizationMeetingId { get; set; }
        [DataMember]
        public String organizationMeetingName { get; set; }
        [DataMember]
        public PersonNotBarcode personNotBarcode { get; set; }

        [DataMember]
        public bool status { get; set; }// ghi nhận flase, cho vào là true
    }
}
