using System;
using System.Runtime.Serialization;

namespace CampusModel.Model
{
    [DataContract]
    public class SessionDto
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public DateTime IssuedTime { get; set; }

        [DataMember]
        public DateTime ExpiredTime { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public long UserId { get; set; }

        [DataMember]
        public bool IsRoot { get; set; }

        [DataMember]
        public long? GroupId { get; set; }
    }
}
