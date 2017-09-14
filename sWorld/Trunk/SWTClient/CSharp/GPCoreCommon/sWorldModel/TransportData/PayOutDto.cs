using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sWorldModel.TransportData
{
    /// <summary>
    /// Thực hiện quy trinh trừ tiền gồm 2 giai đoạn:
    /// 1. Ghi Log Client yêu cầu trừ tiền
    /// 2. Ghi Log Client đã trừ tiền vào thẻ thành công
    /// </summary>
    [DataContract]
    public class PayOutDto
    {
        [DataMember]
        public long Id { get; set; }

        /// <summary>
        /// 1. Ghi Log Client yêu cầu trừ tiền => filde NULL
        /// 2. Ghi Log Client đã trừ tiền vào thẻ thành công sẽ 
        /// lưu Id của Log Client gửi yêu cầu trừ tiền
        /// </summary>
        [DataMember]
        public long PayOutParentId { get; set; }
        [DataMember]
        public long PartnerId { get; set; }
        [DataMember]
        public long MemberId { get; set; }

        /// <summary>
        /// Địa chỉ IP của máy trạm thực hiện giao dịch
        /// </summary>
        [DataMember]
        public string UnitCode { get; set; }
        [DataMember]
        public string SerialNumber { get; set; }


        

        
        [DataMember]
        public long AppId { get; set; }

        /// <summary>
        /// Số tiền được trừ trong thẻ
        /// </summary>
        [DataMember]
        public long Amount { get; set; }
        [DataMember]
        public string PayOutDate { get; set; }

        /// <summary>
        /// Username thực hiện yêu cầu trừ tiền
        /// </summary>
        [DataMember]
        public string Owner { get; set; }

        /// <summary>
        /// Dữ liệu được ghi vào sector 12 của thẻ
        /// </summary>
        [DataMember]
        public string DataWriteToCard { get; set; }
        [DataMember]
        public string KeyB { get; set; }

        /// <summary>
        /// Mã xác nhận của bên thứ 3 (VD: ngân hàng)
        /// </summary>
        [DataMember]
        public string VerificationCode { get; set; }

        /// <summary>
        /// 0: Successful
        /// 1: Processing
        /// 3: LockMoneyCard
        /// </summary>
        [DataMember]
        public int Status { get; set; }
    }
}
