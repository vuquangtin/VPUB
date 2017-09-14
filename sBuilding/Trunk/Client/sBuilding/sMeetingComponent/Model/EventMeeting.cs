using System;
using System.Runtime.Serialization;


namespace sMeetingComponent.Model
{
    [DataContract]
    public class EventMeeting
    {
        [DataMember]
        public long id { get; set; }
        [DataMember]
        public String name { get; set; }
        [DataMember]
        public long organizationMeetingId { get; set; }
        [DataMember]
        public String organizationMeetingName { get; set; }
        [DataMember]
        public long roomId { get; set; }
        [DataMember]
        public String roomName { get; set; }
        [DataMember]
        public long number { get; set; }
        [DataMember]
        public String startTime { get; set; }
        [DataMember]
        public String endTime { get; set; }
        [DataMember]
        public String description { get; set; }
        [DataMember]
        public String listNonResident { get; set; }

        //là danh sách những người tham dự xử lí giống otherparker
        //cách xử lí list thành json String
        //danh sách người tham dự được thêm vào sau chuyển về json để lưu xuống database
        //String jsonPartaker = JsonConvert.SerializeObject(partakerOtherListCheck);
        //attendMeeting.otherPartaker = jsonPartaker;
        //cách xử lí json string thành list
        //List<Partaker> deserializedProduct = JsonConvert.DeserializeObject<List<Partaker>>(jsonPartaker);

        [DataMember]
        public String note { get; set; }
        [DataMember]
        public bool nonresident { get; set; }// cuoc hop co phai cua khach vang lai khong

        ////20170306 #Bug Fix- My Nguyen Start
        ////thêm đối tượng để map dữ liệu
        //// truong luu id tren LCT gui qua
        //[DataMember]
        //public long neocoreId { get; set; }
        //// tinh trang cuoc hop: thay doi khi ben kia xoa cuoc hop
        //[DataMember]
        //public bool neocoreStatus { get; set; }
        ////20170306 #Bug Fix- My Nguyen End

        ////20170325 #Bug Fix- My Nguyen Start
        [DataMember]
        public long meetingCode { get; set; }//mã thư mời của bên thứ 3 gửi qua
        [DataMember]
        public bool meetingCodeStatus { get; set; }
        //tình trạng của cuộc họp còn sử dụng không
        ////20170325 #Bug Fix- My Nguyen End

        //270317 thêm thuộc tính để biết cuộc họp có cho nhà báo vào không
        [DataMember]
        public bool journalist { get; set; }
        //270317 end
    }
}
