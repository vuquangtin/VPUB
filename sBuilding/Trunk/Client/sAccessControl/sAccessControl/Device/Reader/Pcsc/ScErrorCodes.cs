using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sAccessControl.Device.Reader.Pcsc
{
    public class ScErrorCodes
    {
        public const int INVALID_ARGUMENT = 1000;
        public const int OPERATION_FAILED = 1001;
        public const int OUT_OF_SECTOR = 1002;
        public const int UNSUPPORTED_TAG_TYPE = 1003;

        public static string GetErrorMessage(int errorCode)
        {
            switch (errorCode)
            {
                case INVALID_ARGUMENT:
                    return "Dữ liệu đầu vào không hợp lệ";
                case OPERATION_FAILED:
                    return "Thực hiện lệnh không thành công";
                case OUT_OF_SECTOR:
                    return "Vị trí sector vượt quá số lượng sector của thẻ";
                case UNSUPPORTED_TAG_TYPE:
                    return "Loại thẻ này không được hỗ trợ";
                default:
                    return "N/A";
            }
        }
    }
}
