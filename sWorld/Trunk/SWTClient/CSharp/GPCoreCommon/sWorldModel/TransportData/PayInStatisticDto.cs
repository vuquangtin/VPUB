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
    public partial class PayInStatisticDto
    {
        [DataMember]
        public long Id{ get; set; }

        /*
         * <summary> Id của Log Request </summary>
         */
        [DataMember]
        public long PayInParentId;

        /*
         * <summary> Khi thưc hiện quy trình tất toán mới lưu SettlementId, Mục đích để quản lý quy trình tất toán </summary>
         */
        [DataMember]
        public long SettlementId{ get; set; }
        [DataMember]
        public long PartnerId{ get; set; }
        [DataMember]
        public long MemberId{ get; set; }

        /* 
         * <summary> Địa chỉ IP của máy trạm thực hiện giao dịch </summary>
         */
        [DataMember]
        public String IpAddress{ get; set; }
        [DataMember]
        public String SerialNumber{ get; set; }

        /*
         * <summary> Số tiền được nạp vào thẻ </summary>
         */
        [DataMember]
        public double Amount{ get; set; }
        [DataMember]
        public String PayInDate{ get; set; }

        /*
         * <summary> Username thực hiện yêu cầu nạp tiền </summary>
         */
        [DataMember]
        public String Owner{ get; set; }

        /*
         * <summary> Dữ liệu được ghi vào sector 11 của thẻ (dữ liệu này đã được mã hóa) </summary>
         */
        [DataMember]
        public String DataWriteToCard{ get; set; }

        /*
         * <summary> KeyB của sector 11 </summary>
         */
        [DataMember]
        public String KeyB{ get; set; }

        /*
         * <summary> Mã xác thực của bên thứ 3 (VD: ngân hàng) </summary>
         */
        [DataMember]
        public String VerificationCode{ get; set; }

        /*
         * <summary> Lưu số lần đồng bộ dữ liệu </summary>
         */
        [DataMember]
        public int SnysDataNumber{ get; set; }

        /*
         * <summary> 0: Successful 1: Processing 3: LockMoneyCard </summary>
         */
        [DataMember]
        public int Status{ get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string SnysDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public String FirstName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public String LastName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public String FullName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public List<lockmoneycard> lstLockCard { get; set; }


    }
}
