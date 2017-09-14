using CampusModel.Model;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CampusModel.MethodData
{
    [DataContract]
    public class DataForReadCard
    {
        [DataMember]
        public List<AppDto> ListAppsOnCard { get; set; }

        [DataMember]
        public Dictionary<byte, byte[]> TeacherAppKeyAList { get; set; }
    }
}
