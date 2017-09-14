using System;

namespace sWorldModel.Exceptions
{
    public static class sWorldExceptionUtils
    {
        /// <summary>
        /// Chuyển một đối tượng GPCoreException thành chuỗi với cấu trúc
        /// như sau:
        /// - 1 ký tự đầu: chiều dài của code
        /// - Phần tiếp theo: code của GPCoreException
        /// - Phần cuối: message của GPCoreException
        /// </summary>
        public static string Serialize(sWorldException ex)
        {
            string code = ex.Code.ToString();
            return string.Format("{0}{1}{2}", code.Length, code, ex.Message);
        }

        public static string Serialize(int code, string message)
        {
            string codeStr = code.ToString();
            return string.Format("{0}{1}{2}", codeStr.Length, codeStr, message);
        }

        /// <summary>
        /// Chuyển một chuỗi dữ liệu thành đối tượng GPCoreException
        /// </summary>
        public static sWorldException Deserialize(string str)
        {
            if (str == null)
            {
                throw new ArgumentException("Data is null");
            }
            if (str.Length == 0)
            {
                throw new ArgumentException("Data is empty");
            }
            int codeLength;
            if (!int.TryParse(str.Substring(0, 1), out codeLength))
            {
                throw new ArgumentException("Code length field is not a number");
            }

            int temp = codeLength + 1;
            string message;
            if (str.Length < temp)
            {
                throw new ArgumentException("Invalid data length");
            }
            else if (str.Length == temp)
            {
                message = string.Empty;
            }
            else
            {
                message = str.Substring(temp);
            }

            int code;
            if (!int.TryParse(str.Substring(1, codeLength), out code))
            {
                throw new ArgumentException("Code field is not a number");
            }
            return new sWorldException(code, message);
        }
    }
}
