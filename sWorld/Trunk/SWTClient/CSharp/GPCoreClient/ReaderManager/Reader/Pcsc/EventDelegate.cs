using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReaderManager.Pcsc
{
    public delegate void DisconnectedHandler();
    public delegate void TagDetectedHandler(byte[] cardId);
    public delegate void TagDetectedEventHandler(int tagType, byte[] serialNumber);
}
