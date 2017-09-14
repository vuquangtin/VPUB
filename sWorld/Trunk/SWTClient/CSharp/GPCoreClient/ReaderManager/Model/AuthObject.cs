using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReaderManager.Model
{
    // Object Key cho các hàm liên quan key trong các hiện thực của Interface IReader
    public class AuthObject
    {
        public AuthObject(byte sector, byte[] key, bool isKeyA)
        {
            this.sector = sector;
            this.isKeyA = isKeyA;
            this.Key = key;
        }
        public byte sector { get; set; }
        public bool isKeyA { get; set; }
        public byte[] Key { get; set; }

    }

   
}
