using System.Runtime.Serialization;

namespace sWorldModel.Integrating
{
    [DataContract]
    public class ALL_KHOA : IntegratingTable
    {
        [DataMember]
        public string MS_KHOA { get; set; }

        [DataMember]
        public string TEN_KHOA { get; set; }

        [DataMember]
        public string TEN_TIENG_ANH { get; set; }

        [DataMember]
        public string TEN_KHOA_TAT { get; set; }

        public override string ToString()
        {
            return (MS_KHOA == null ? string.Empty : MS_KHOA)
                + (TEN_KHOA == null ? string.Empty : TEN_KHOA)
                + (TEN_TIENG_ANH == null ? string.Empty : TEN_TIENG_ANH)
                + (TEN_KHOA_TAT == null ? string.Empty : TEN_KHOA_TAT);
        }
    }
}
