using System.Runtime.Serialization;

namespace CampusModel.Model
{
    [DataContract]
    public class KeyUpdateSetDto
    {
        [DataMember]
        public byte[] CurrentKeyB { get; set; }

        [DataMember]
        public byte[] NewKeyA { get; set; }

        [DataMember]
        public byte[] NewKeyB { get; set; }
    }
}
