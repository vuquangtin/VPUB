using System.Runtime.Serialization;

namespace sWorldModel.Model
{
    [DataContract]
    public class AppMetadataDto
    {
        [DataMember]
        public byte AppAlias { get; set; }

        [DataMember]
        public byte KeyAlias { get; set; }

        [DataMember]
        public byte StartSectorNumber { get; set; }

        [DataMember]
        public byte MaxSectorUsed { get; set; }

        public byte[] GetAppMetadataBytes()
        {
            byte[] appData = new byte[5];
            appData[0] = AppAlias;
            appData[1] = KeyAlias;
            appData[2] = StartSectorNumber;
            appData[3] = MaxSectorUsed;
            appData[4] = 0;
            return appData;
        }
    }
}
