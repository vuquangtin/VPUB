using System.Runtime.Serialization;

namespace CampusModel.Integrating
{
    [DataContract]
    public class ALL_CHUC_VU : IntegratingTable
    {
        [DataMember]
        public string MS_CVU { get; set; }

        [DataMember]
        public string CHUC_VU { get; set; }

        [DataMember]
        public string Ghi_chu { get; set; }

        public override string ToString()
        {
            return (MS_CVU == null ? string.Empty : MS_CVU)
                + (CHUC_VU == null ? string.Empty : CHUC_VU)
                + (Ghi_chu == null ? string.Empty : Ghi_chu);
        }
    }
}
