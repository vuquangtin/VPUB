using sWorldModel.Model;
using System.Collections.Generic;
using System.Runtime.Serialization;
using sWorldModel.TransportData;

namespace sWorldModel.MethodData
{
    [DataContract]
    public class DataForImportCard
    {
        [DataMember]
        public byte HMK_ALIAS { get; set; }

        [DataMember]
        public byte DMKA_ALIAS { get; set; }

        [DataMember]
        public byte DMKB_ALIAS { get; set; }

        [DataMember]
        public byte PVK_ALIAS { get; set; }

        /// <summary>
        /// Collection dạng: sector number - key pair
        /// Đối với các sector từ 0 đến 3, key pair chỉ chứa key B
        /// </summary>
        [DataMember]
        public Dictionary<byte, SectorKeyPairDTO> ListSectorKeyPair { get; set; }

        [DataMember]
        public byte[] License { get; set; }

        public byte[] GetHeaderDataBytes()
        {
            byte[] result = new byte[48];
            result[0] = HMK_ALIAS;
            result[1] = DMKA_ALIAS;
            result[2] = DMKB_ALIAS;
            result[3] = PVK_ALIAS;
            return result;
        }
    }
}
