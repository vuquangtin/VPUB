using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sWorldModel.TransportData;

namespace ReaderManager.Model
{
    public class ReadDataObject
    {
        public byte StartSector { get; set; }
        public byte StopSector { get; set; }
        public List<KeyDTO> Keys { get; set; }
        public ReadDataObject(byte start_sector, byte stop_sector, List<KeyDTO> list_key)
        {
            this.StartSector = start_sector;
            this.StopSector = stop_sector;
            this.Keys = list_key;
        }
    }
}
