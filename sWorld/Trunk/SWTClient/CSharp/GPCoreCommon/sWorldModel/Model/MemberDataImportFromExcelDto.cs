namespace sWorldModel.Model
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

 [DataContract]
    public class MemberDataImportFromExcelDto
    {
        #region Indexed Data
     
        public string SheetName { get; set; }

        public int RowIndex { get; set; }

        #endregion

        #region Imported Data Excel

        [DataMember]
        public string FullName { get; set; }

        [DataMember]
        public string PhoneNumber { get; set; }

        [DataMember]
        public string Birthday { get; set; }

        [DataMember]
        public string Gender { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Degree { get; set; }

        [DataMember]
        public string Postion { get; set; }

        [DataMember]
        public string PermanentAddress { get; set; }

        [DataMember]
        public string TemporaryAddress { get; set; }

        [DataMember]
        public string Nationality { get; set; }

        [DataMember]
        public string CompanyName { get; set; }

        #endregion

    }
}