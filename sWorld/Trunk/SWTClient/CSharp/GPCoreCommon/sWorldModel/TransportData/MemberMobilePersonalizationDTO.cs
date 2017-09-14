using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace sWorldModel.TransportData
{    
    [DataContract]
    public class MemberMobilePersonalizationDTO
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public String LastName { get; set; }
        [DataMember]
        public String FirstName { get; set; }
        [DataMember]
        public int Gender { get; set; }
        [DataMember]
        public long memberid { get; set; } // id của người được cấp thẻ
        [DataMember]
        public long mobilecardid { get; set; } // id của thẻ được cấp. Id này có thể trùng nhau.
        [DataMember]
        public String serial { get; set; } // số của thẻ được cấp
        [DataMember]
        public String qrcode { get; set; } // số qr của thẻ được cấp
        [DataMember]
        public String barcode { get; set; } // số barcode của thẻ được cấp
        [DataMember]
        public String telephone { get; set; } // số của thẻ được cấp
        [DataMember]
        public String duration { get; set; } // thời gian có hiệu lực của thẻ. (Thời gian hết hạn)
        [DataMember]
        public String content { get; set; } // nội dung của thẻ. Theo một format nào đó. Sẽ được định nghĩa sau
        [DataMember]
        public String strimage { get; set; } // image danh cho thẻ lưu ở dạng base64
        [DataMember]
        public String typecard { get; set; } // loại thẻ (vd: thẻ quàn tặng, thẻ giảm giá, vourch-->Theo mã số hoặc theo tên gọi.
        [DataMember]
        public String card { get; set; } // loại thẻ (vd: thẻ quàn tặng, thẻ giảm giá, vourch-->Theo mã số hoặc theo tên gọi.
        [DataMember]
        public String pin { get; set; } // ping code
        [DataMember]
        public int status { get; set; } // Trạng thái của thẻ
    }
}
