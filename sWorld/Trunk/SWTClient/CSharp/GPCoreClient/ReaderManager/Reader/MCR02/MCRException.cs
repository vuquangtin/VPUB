using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace ReaderManager.Reader.MCR02
{
    /// <summary>
    /// Lớp bắt lỗi của MCR
    /// </summary>
    public class MCRException : Exception
    {
        public const string
          //Lỗi không gửi được cmd tới đầu đọc
          CANNOT_SEND_REPLY = "Cannot send reply message to card reader.",
          //Lỗi event chưa được follow.
          EVENT_NOT_FOLLOWED = "Cannot fire an null event";

        public MCRException(string message)
            : base(message)
        {
        }

        public MCRException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public MCRException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
