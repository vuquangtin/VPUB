using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReaderManager.Enum;
using sWorldModel.TransportData;

namespace ReaderManager.Model
{
    public class WriteDataObject
    {
        public byte StartSector { get; set; }
        public byte StopSector { get; set; }
        public List<KeyDTO> Keys { get; set; }
        public WRITE_MODE Mode { get; set; }
        public DataToWriteCardDTO WriteObject { get; set; } 

        public WriteDataObject(DataToWriteCardDTO obj, WRITE_MODE mode)
        {
            this.WriteObject = obj;
            this.Mode = mode;
        }

        public WriteDataObject(byte start_sector, byte stop_sector, List<KeyDTO> list_key, WRITE_MODE mode)
        {
            this.StartSector = start_sector;
            this.StopSector = stop_sector;
            this.Keys = list_key;
            this.Mode = mode;
        }

        public WriteDataObject(byte start_sector, byte stop_sector, List<KeyDTO> list_key)
        {
            this.StartSector = start_sector;
            this.StopSector = stop_sector;
            this.Keys = list_key;
        }
    }
}
