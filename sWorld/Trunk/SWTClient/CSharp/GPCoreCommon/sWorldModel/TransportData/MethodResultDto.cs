using System.Runtime.Serialization;

namespace sWorldModel.TransportData
{
    [DataContract]
    public class MethodResultDto
    {
        [DataMember]
        public string Subject { get; set; }

        [DataMember]
        public string Action { get; set; }

        [DataMember]
        public bool Result { get; set; }

        [DataMember]
        public string Detail { get; set; }
    }
}
