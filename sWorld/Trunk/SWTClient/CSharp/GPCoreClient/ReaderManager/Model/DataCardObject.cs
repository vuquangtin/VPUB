using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReaderManager.Model
{
    public class DataCardObject
    {
        /// <summary>
        /// định nghĩa các event 
        /// </summary>
        public const int TAG_DETECTED = 0;
        public const int TAG_REMOVED = 1;
        public const int READER_NOT_PRESENT = 2;
        public const int READER_UNPLUGGED = 3;
        public const int READER_PLUGGED = 4;
   

        //1/7/2016 them contrustor (ten)
        //thêm eventType để xác định loại event
        public DataCardObject(int cardType, byte[] serialNumber)
        {
            this.cardType = cardType;
            this.serialNumber = serialNumber;
        }

        // contructor nhận vào eventType để phân biệt event, msg để hiển thị
        public DataCardObject()
        {
            this.eventType = eventType;
           
        }

        public int cardType { get; set; }
        public byte[] serialNumber { get; set; }
        public int eventType { get; set; }


    }
}
