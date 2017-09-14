using System;
using System.Runtime.Serialization;

namespace CampusModel.Integrating
{
    [DataContract]
    public class ALL_CBCNV : IntegratingTable
    {
        [DataMember]
        public string SHCC { get; set; }

        [DataMember]
        public string MS_BM { get;set; }

        [DataMember]
        public bool? NGHI { get; set; }

        [DataMember]
        public bool? IS_NNGOAI { get; set; }

        [DataMember]
        public string LOAI { get; set; }

        [DataMember]
        public DateTime? HD_KY_DEN { get; set; }

        [DataMember]
        public string HO { get; set; }

        [DataMember]
        public string TEN { get; set; }

        [DataMember]
        public char PHAI { get; set; }

        [DataMember]
        public string CHUC_DANH { get; set; }

        [DataMember]
        public string TRINH_DO { get; set; }

        [DataMember]
        public string MS_CVU { get; set; }

        [DataMember]
        public string NGACH { get; set; }

        public override string ToString()
        {
            return (SHCC == null ? string.Empty : SHCC)
                + (MS_BM == null ? string.Empty : MS_BM)
                + NGHI.ToString()
                + IS_NNGOAI.ToString()
                + (LOAI == null ? string.Empty : LOAI)
                + HD_KY_DEN.ToString()
                + (HO == null ? string.Empty : HO)
                + (TEN == null ? string.Empty : TEN)
                + PHAI.ToString()
                + (CHUC_DANH == null ? string.Empty : CHUC_DANH)
                + (TRINH_DO == null ? string.Empty : TRINH_DO)
                + (MS_CVU == null ? string.Empty : MS_CVU)
                + (NGACH == null ? string.Empty : NGACH);
        }
    }
}
