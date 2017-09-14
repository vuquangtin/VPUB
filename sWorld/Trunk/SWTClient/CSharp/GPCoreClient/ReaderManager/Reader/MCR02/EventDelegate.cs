using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReaderManager.Reader.MCR02
{
    public class EventDelegate
    {
        //event handler cho event tag thẻ ở đầu đọc
        public delegate void TagDetectedHandler(string UID, out string cmd);
    }
}
