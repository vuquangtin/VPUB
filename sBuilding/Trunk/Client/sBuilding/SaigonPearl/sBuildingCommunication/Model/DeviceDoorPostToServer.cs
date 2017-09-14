using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sBuildingCommunication.Model
{
    /// <summary>
    /// This class using to post to server two list 
    /// 1 user uncheck
    /// 2 user check
    /// </summary>
    [DataContract]
   public class DeviceDoorPostToServer
    {
        //list for delete
        [DataMember]
       public List<long> deviceBeforeSelect { get; set; }
        //list for add
        [DataMember]
        public List<DeviceDoorGroupDeviceDoorDTO> deviceAfterSelect { get; set; }
    }
}
