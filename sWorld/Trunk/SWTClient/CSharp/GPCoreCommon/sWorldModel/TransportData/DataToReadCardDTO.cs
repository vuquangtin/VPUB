namespace sWorldModel.TransportData
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class DataToReadCardDTO
    {
        [DataMember]
        public List<KeyDTO> KEY { get; set; }

        [DataMember]
        public byte Status { get; set; }

        [DataMember]
        public string LicenseServer { get; set; } // string has format hex

        public Dictionary<byte, SectorKeyPairDTO> DicSectorKeyPair = null;

        public void CreateDic()
        {
            if (DicSectorKeyPair == null)
            {
                DicSectorKeyPair = new Dictionary<byte, SectorKeyPairDTO>();
                byte index = 0;
                foreach (KeyDTO key in KEY)
                {
                    if(!DicSectorKeyPair.ContainsKey(key.Alias)){
                        DicSectorKeyPair.Add(key.Alias, key.Key);
                        index++;
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
