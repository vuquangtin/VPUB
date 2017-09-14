using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReaderManager.Model
{
    public class ListKey
    {

        public ListKey(byte SectorStart, byte SectorStop, List<KeyDTO> KeyList)
        {
            this.SectorStart = SectorStart;
            this.SectorStop = SectorStop;
            this.KeyList = KeyList;
        }

        public byte SectorStart { get; set; }


        public byte SectorStop { get; set; }


        public List<KeyDTO> KeyList { get; set; }



    }
}
