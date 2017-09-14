using ReaderManager.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReaderManager.Model
{
    public class HeaderObject
    {
        public ACTION_MODE Mode {get;set;}
        public HeaderObject(ACTION_MODE action)
        {
            this.Mode = action;
        }
        public HeaderObject(byte sector, byte[] key, byte[] data, bool userKeyA = true)
        {
            this.Sector = sector;
            this.Key = key;
            this.Data = data;
            this.IsKeyA = userKeyA;
        }
        
        public byte Sector { get; set; }
        public byte[] Key { get; set; }
        public bool IsKeyA { get; set; }
        public byte[] Data { get; set; }
    }
}
