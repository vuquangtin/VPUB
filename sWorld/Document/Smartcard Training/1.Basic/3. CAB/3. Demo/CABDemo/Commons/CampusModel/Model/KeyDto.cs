using System.Runtime.Serialization;
using System.Text;

namespace CampusModel.Model
{
    [DataContract]
    public class KeyDto
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public byte Alias { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }
    }
}