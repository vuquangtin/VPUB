using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace CampusModel.Exceptions
{
    /// <summary>
    /// Biểu diễn đối tượng chứa dữ liệu lỗi từ server
    /// </summary>
    [DataContract]
    public class WcfServiceFault
    {
        /// <summary>
        /// Cho biết đối tượng cụ thể gây ra exception
        /// </summary>
        [DataMember]
        public string Source { get; set; }

        /// <summary>
        /// Mã lỗi
        /// </summary>
        [DataMember]
        public int Code { get; set; }

        /// <summary>
        /// Trả về thông báo lỗi. Hàm này chỉ nên được gọi bên 
        /// phía client vì server sẽ không chứa các file ngôn ngữ.
        /// </summary>
        /// <returns>Thông báo lỗi cụ thể</returns>
        public string GetErrorMessgae()
        {
            switch (Code)
            {
                default:
                    return "Lỗi không xác định";
            }
        }

        public static void Throw(int code, object target)
        {
            throw new FaultException<WcfServiceFault>(
                new WcfServiceFault
                {
                    Code = code,
                    Source = target.ToString(),
                });
        }
    }
}