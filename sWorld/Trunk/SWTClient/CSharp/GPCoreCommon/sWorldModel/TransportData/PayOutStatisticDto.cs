using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sWorldModel.TransportData
{
    /// <summary>
    /// Thực hiện quy trinh nạp tiền gồm 2 giai đoạn:
    /// 1. Ghi Log Client yêu cầu nạp tiền
    /// 2. Ghi Log Client đã nạp tiền vào thẻ thành công
    /// </summary>
    [DataContract]
    public partial class PayOutStatisticDto
    {
        [DataMember]
        public long Id{ get; set; }
        [DataMember]
        public long PartnerId{ get; set; }
        [DataMember]
        public long MemberId{ get; set; }
        [DataMember]
        public long AppId{ get; set; }
        [DataMember]
        public String UnitCode{ get; set; }
        [DataMember]
        public String SerialNumber{ get; set; }
        [DataMember]
        public double Amount{ get; set; }
        [DataMember]
        public String PayOutDate{ get; set; }
        [DataMember]
        public String Owner{ get; set; }
        [DataMember]
        public String DataWriteToCard{ get; set; }
        [DataMember]
        public String KeyB{ get; set; }
        [DataMember]
        public String VerificationCode{ get; set; }
        [DataMember]
        public int SnysDataNumber{ get; set; }
        [DataMember]
        public String SnysDate{ get; set; }
        [DataMember]
        public int Status{ get; set; }
        [DataMember]
        public String FirstName{ get; set; }
        [DataMember]
        public String LastName{ get; set; }
        [DataMember]
        public String FullName{ get; set; }
        [DataMember]
        public List<lockmoneycard> lstLockCard{ get; set; }
        [DataMember]
        private String ItemName { get; set; }
        [DataMember]
        private String Description { get; set; }
        [DataMember]
        private String GroupName { get; set; }
    }
}
