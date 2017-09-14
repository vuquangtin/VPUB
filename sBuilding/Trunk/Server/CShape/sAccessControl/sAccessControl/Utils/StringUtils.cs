using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sAccessControl.Utils
{
    public static class StringUtils
    {
        public static string Int32ToHexString(int number)
        {
            return number.ToString("X");
        }

        public static int HexStringToInt32(string hex)
        {
            return Convert.ToInt32(hex, 16);
        }

        public static string ByteArrayToHexString(byte[] bytes)
        {
            StringBuilder hex = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes)
                hex.AppendFormat("{0:X2}", b);
            return hex.ToString().ToUpper();
        }

        public static byte[] HexStringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        /// <summary>
        /// Kiểm tra 2 chuỗi có bằng nhau hay không, xử lý cả trường hợp null.
        /// </summary>
        /// <param name="x">Chuỗi thứ nhất</param>
        /// <param name="y">Chuỗi thứ hai</param>
        /// <returns>
        /// True nếu cả 2 đều null.
        /// False nếu chỉ 1 trong 2 là null.
        /// Kết quả của hàm Equals nếu cả 2 đều không null.
        /// </returns>
        public static bool AreEqual(string x, string y)
        {
            return AreEqual(x, y, StringComparison.CurrentCulture);
        }

        /// <summary>
        /// Kiểm tra 2 chuỗi có bằng nhau hay không, xử lý cả trường hợp null.
        /// </summary>
        /// <param name="x">Chuỗi thứ nhất</param>
        /// <param name="y">Chuỗi thứ hai</param>
        /// <param name="comparisionType">Kiểu so sánh 2 chuỗi</param>
        /// <returns>
        /// True nếu cả 2 đều null.
        /// False nếu chỉ 1 trong 2 là null.
        /// Kết quả của hàm Equals nếu cả 2 đều không null.
        /// </returns>
        public static bool AreEqual(string x, string y, StringComparison comparisionType)
        {
            if (string.IsNullOrEmpty(x))
            {
                return string.IsNullOrEmpty(y);
            }
            else
            {
                return string.Equals(x, y, comparisionType);
            }
        }

        public static string Reverse(string s)
        {
            if (s == null)
            {
                return null;
            }
            if (s.Length == 0)
            {
                return string.Empty;
            }

            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
