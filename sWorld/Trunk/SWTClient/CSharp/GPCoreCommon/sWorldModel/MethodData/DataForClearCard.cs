using sWorldModel.Model;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace sWorldModel.MethodData
{
    [DataContract]
    public class DataForClearCard
    {
        [DataMember]
        public byte[] CurrentHeaderKeyB { get; set; }

        //[DataMember]
        //public Dictionary<byte, KeyUpdateSetDto> DataSectorKeyUpdateSets { get; set; }
    }
}
