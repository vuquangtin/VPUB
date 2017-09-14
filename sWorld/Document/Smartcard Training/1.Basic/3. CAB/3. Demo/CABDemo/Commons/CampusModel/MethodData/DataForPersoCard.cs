using CampusModel.Model;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CampusModel.MethodData
{
    [DataContract]
    public class DataForPersoCard
    {
        [DataMember]
        public byte[] HeaderKeyB { get; set; }

        [DataMember]
        public AppMetadataDto TeacherAppMetadata { get; set; }

        [DataMember]
        public byte[] TeacherData { get; set; }

        [DataMember]
        public Dictionary<byte, KeyUpdateSetDto> AppSectorKeyUpdateSets { get; set; }
    }
}
