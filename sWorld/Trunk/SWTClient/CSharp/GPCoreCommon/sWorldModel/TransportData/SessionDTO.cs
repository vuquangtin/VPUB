using System;
using System.Runtime.Serialization;

namespace sWorldModel.TransportData
{
    [DataContract]
    public class SessionDTO
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public long GroupId { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string Token { get; set; }

        [DataMember]
        public string datelogin { get; set; }

        [DataMember]
        public bool IsRoot { get; set; }

        [DataMember]
        public bool IsLogin { get; set; }
    }
}
