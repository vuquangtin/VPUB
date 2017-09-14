using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sWorldModel.TransportData
{
    /// <summary>
    /// Class chứa các tất cả hình của một lượt gởi xe
    /// </summary>
    [DataContract]
    public class ImagesDto
    {
        [DataMember]
        public ImagePairDto Images { get; set; }

        [DataMember]
        public ImagePairDto ParkingOutImages { get; set; }
    }
}
