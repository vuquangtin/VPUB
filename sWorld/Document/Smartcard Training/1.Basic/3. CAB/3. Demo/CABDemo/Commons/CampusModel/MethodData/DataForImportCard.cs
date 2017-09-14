using CampusModel.Model;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CampusModel.MethodData
{
    [DataContract]
    public class DataForImportCard
    {
        [DataMember]
        public byte HmkAlias { get; set; }

        [DataMember]
        public byte DmkAlias { get; set; }

        [DataMember]
        public byte[] HeaderKeyB { get; set; }

        [DataMember]
        public Dictionary<byte, KeyPairDto> DataSectorKeyPairs { get; set; }

        public byte[] GetHeaderDataBytes()
        {
            byte[] result = new byte[48];
            result[0] = HmkAlias;
            result[1] = DmkAlias;
            return result;
        }
    }
}
