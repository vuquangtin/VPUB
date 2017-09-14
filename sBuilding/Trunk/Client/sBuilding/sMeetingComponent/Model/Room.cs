using System;
using System.Runtime.Serialization;


namespace sMeetingComponent.Model
{
    [DataContract]
    public class Room
    {
        public Room() { }
        [DataMember]
        public long id { get; set; }
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string description { get; set; }
        [DataMember]
        public long referenceId { get; set; }
        [DataMember]
        public int number { get; set; }
    }
}
