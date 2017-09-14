using System;
using System.Runtime.Serialization;

namespace CampusModel.Model
{
    [DataContract]
    public class LoginHistoryDto
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public DateTime LoginTime { get; set; }

        [DataMember]
        public bool LoginResult { get; set; }

        [DataMember]
        public int FailedCode { get; set; }
    }
}
