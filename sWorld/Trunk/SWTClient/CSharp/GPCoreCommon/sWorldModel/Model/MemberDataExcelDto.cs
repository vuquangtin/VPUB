namespace sWorldModel.Model
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class MemberDataExcelDto
    {
        #region Indexed Data

        public string SheetName { get; set; }

        public int RowIndex { get; set; }

        #endregion

        #region Imported Data

        [DataMember]
        public string FullName { get; set; }

        [DataMember]
        public string CompanyName { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }

        [DataMember]
        public string ExpiredTime { get; set; }

        #endregion

        #region Generated Data

        [DataMember]
        public string SerialNumber { get; set; }

        [DataMember]
        public string TrackData { get; set; }

        #endregion
    }
}