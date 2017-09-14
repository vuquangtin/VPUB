using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReaderManager.Enum;
using sWorldModel.TransportData;

namespace ReaderManager.Model
{
    public class WriteDataSectorObject
    {
        public byte Sector { get; set; }
        public byte[] Key { get; set; }
        public WRITE_MODE Mode { get; set; }

        public WriteDataSectorObject( byte sector, byte[] key, WRITE_MODE mode)
        {
            Sector = sector;
            Key = key;
            this.Mode = mode;
        }
    }
}
