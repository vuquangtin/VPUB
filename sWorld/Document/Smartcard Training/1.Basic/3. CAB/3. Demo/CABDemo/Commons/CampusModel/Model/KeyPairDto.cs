using System.Runtime.Serialization;

namespace CampusModel.Model
{
    [DataContract]
    public class KeyPairDto
    {
        [DataMember]
        public byte[] KeyA { get; set; }

        [DataMember]
        public byte[] KeyB { get; set; }
    }
}
