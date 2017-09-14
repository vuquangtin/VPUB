using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReaderManager.Enum;
using sWorldModel.TransportData;

namespace ReaderManager.Model
{
    public class ActionObject
    {
        public ACTION_MODE Mode { get; set; }
        public Dictionary<byte, byte[]> Sectors;
        public int DataSize { get; set; }

        public ActionObject(Dictionary<byte, byte[]> sectors, ACTION_MODE mode)
        {
            this.Sectors = sectors;
            this.Mode = mode;
        }

        public ActionObject(Dictionary<byte, byte[]> sectors, int datasize, ACTION_MODE mode)
        {
            this.Sectors = sectors;
            this.Mode = mode;
            DataSize = datasize;
        }
    }
}
