﻿using System;
using System.Runtime.Serialization;
using sWorldModel.TransportData;

namespace sWorldModel.Model
{
    [DataContract]
    public class AppDto
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public byte Alias { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public KeyDTO MasterKey { get; set; }

        [DataMember]
        public byte StartSectorNumber { get; set; }

        [DataMember]
        public byte MaxSectorUsed { get; set; }
    }
}