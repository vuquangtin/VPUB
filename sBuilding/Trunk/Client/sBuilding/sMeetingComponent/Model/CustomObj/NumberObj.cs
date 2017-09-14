using System;
using System.Runtime.Serialization;


namespace sMeetingComponent.Model.CustomObj
{
    [DataContract]
    public class NumberObj
    {
        public NumberObj() { }
        [DataMember]
        public int value { get; set; }
    }
}
