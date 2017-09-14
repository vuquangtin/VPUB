using System.Runtime.Serialization;

namespace CampusModel.Integrating
{
    [DataContract]
    public class ALL_NGACH : IntegratingTable
    {
        [DataMember]
        public string NGACH { get; set; }

        [DataMember]
        public string TEN_NGACH { get; set; }

        [DataMember]
        public string NHIEM_VU_DAM_TRACH { get; set; }

        public override string ToString()
        {
            return (NGACH == null ? string.Empty : NGACH)
                + (TEN_NGACH == null ? string.Empty : TEN_NGACH)
                + (NHIEM_VU_DAM_TRACH == null ? string.Empty : NHIEM_VU_DAM_TRACH);
        }
    }
}
