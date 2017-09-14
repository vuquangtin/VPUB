using CampusModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace CampusModel.MethodData
{
    [DataContract]
    public class DataForUpdateCard
    {
        [DataMember]
        public byte[] TeacherData { get; set; }

        [DataMember]
        public Dictionary<byte, byte[]> ListAppSectorKeyB { get; set; }
    }
}
