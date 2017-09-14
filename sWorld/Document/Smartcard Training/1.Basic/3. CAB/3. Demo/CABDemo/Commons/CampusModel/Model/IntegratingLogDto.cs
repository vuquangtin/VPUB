using System.Runtime.Serialization;

namespace CampusModel.Model
{
    [DataContract]
    public class IntegratingLogDto
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public string ChangedTable { get; set; }

        [DataMember]
        public string Changes { get; set; }

        [DataMember]
        public string ChangedType { get; set; }

        [DataMember]
        public System.DateTime ChangedOn { get; set; }

        [DataMember]
        public string ChangedBy { get; set; }

        [DataMember]
        public bool Result { get; set; }

        [DataMember]
        public string Reason { get; set; }
    }
}
