using System.Runtime.Serialization;

namespace CampusModel.Integrating
{
    [DataContract]
    public class ALL_BO_MON : IntegratingTable
    {
        [DataMember]
        public string MS_BM { get; set; }

        [DataMember]
        public string TEN_BM { get; set; }

        [DataMember]
        public string TEN_TIENG_ANH { get; set; }

        [DataMember]
        public string MS_KHOA { get; set; }

        public override string ToString()
        {
            return (MS_BM == null ? string.Empty : MS_BM) 
                + (TEN_BM == null ? string.Empty : TEN_BM)
                + (TEN_TIENG_ANH == null ? string.Empty : TEN_TIENG_ANH) 
                + (MS_KHOA == null ? string.Empty : MS_KHOA);
        }
    }
}
