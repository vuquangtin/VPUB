using System.Collections.Generic;
using System.Runtime.Serialization;
using sWorldModel.MethodData;

namespace sWorldModel.TransportData
{
    [DataContract]
    public class ResultCheckCardDTO
    {
        [DataMember]
        public byte HMK_ALIAS { get; set; }

        [DataMember]
        public byte DMKA_ALIAS { get; set; }

        [DataMember]
        public byte DMKB_ALIAS { get; set; }

        [DataMember]
        public byte PVK_ALIAS { get; set; }

        [DataMember]
        public List<KeyDTO> KEY { get; set; }

        [DataMember]
        public int Status { get; set; }

        [DataMember]
        public string LicenseServer { get; set; } // string has format hex

        [DataMember]
        public string License { get; set; } // string has format hex

        // do not use
        public byte[] GetHeaderDataBytes()
        {
            byte[] result = new byte[4];
            result[0] = HMK_ALIAS;
            result[1] = DMKA_ALIAS;
            result[2] = DMKB_ALIAS;
            result[3] = PVK_ALIAS;
            return result;
        }

        private Dictionary<byte, SectorKeyPairDTO> DicSectorKeyPair = null;

        public void CreateDic()
        {
            if (DicSectorKeyPair == null)
            {
                DicSectorKeyPair = new Dictionary<byte, SectorKeyPairDTO>();
                foreach (KeyDTO key in KEY)
                {
                    DicSectorKeyPair.Add(key.Alias, key.Key);
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
