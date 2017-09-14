using System.Security.Cryptography;
using System.Text;
using System;

namespace CryptoHelper.Hashing
{
    public class Md5Helper
    {
        public static string Hash(string plainText, long loop)
        {
            if (plainText == null)
            {
                throw new ArgumentNullException("PlainText is null");
            }
            if (plainText.Length == 0)
            {
                return string.Empty;
            }
            using (MD5 md5 = MD5.Create())
            {
                byte[] bArray = Encoding.ASCII.GetBytes(plainText);
                while (loop-- > 0)
                {
                    bArray = md5.ComputeHash(bArray);
                }
                StringBuilder hex = new StringBuilder(bArray.Length * 2);
                foreach (byte b in bArray)
                {
                    hex.AppendFormat("{0:X2}", b);
                }
                return hex.ToString().ToUpper();
            }
        }
    }
}
