using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sWorldModel.TransportData
{
    [DataContract]
    public class DataToWriteCardDTO
    {
        [DataMember]
        public List<KeyDTO> KEY { get; set; }

        [DataMember]
        public String Data { get; set; }

        [DataMember]
        public String Split { get; set; } // if split is not null then split data and write data in each sector

        [DataMember]
        public string LicenseServer { get; set; } // string has format hex

        public Dictionary<byte, SectorKeyPairDTO> DicSectorKeyPair = null;

        public void CreateDic()
        {
            if (DicSectorKeyPair == null)
            {
                DicSectorKeyPair = new Dictionary<byte, SectorKeyPairDTO>();
                foreach (KeyDTO key in KEY)
                {
                    if (!DicSectorKeyPair.ContainsKey(key.Alias))
                    {
                        DicSectorKeyPair.Add(key.Alias, key.Key);
                    }
                }
            }
        }

        public SectorKeyPairDTO ListSectorKeyPair(byte sector)
        {
            if (DicSectorKeyPair == null)
                CreateDic();

            if (DicSectorKeyPair.ContainsKey(sector))
                return DicSectorKeyPair[sector];

            return null;
        }

        public void RemoveSectorKeyPair(byte sector)
        {
            if (DicSectorKeyPair.ContainsKey(sector))
                DicSectorKeyPair.Remove(sector);

        }
    }
}
