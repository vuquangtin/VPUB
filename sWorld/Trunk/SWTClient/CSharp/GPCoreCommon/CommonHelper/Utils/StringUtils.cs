using System;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace CommonHelper.Utils
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

        public static bool CheckPhoneNumber(string phone)
        {
            string number = @"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$";
            if (phone.Length > 0)
                return Regex.IsMatch(phone, number);
            else return false;
        }

        public static bool IsNumber(string inputvalue)
        {
            Regex isnumber = new Regex(@"^[0-9]+(\.[0-9]+)?$");
            return !isnumber.IsMatch(inputvalue);
        }

        public static bool CheckEmail(string email)
        {
            try
            {
                MailAddress value = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static byte[] GetBytes(string str)
        {
            System.Text.Encoding encoding = System.Text.Encoding.UTF8;
            byte[] bytes = encoding.GetBytes(str);
            return bytes;
        }

        public static string GetString(byte[] bytes)
        {
            System.Text.Encoding encoding = System.Text.Encoding.UTF8;
            string myString = new string(encoding.GetChars(bytes));
            return myString;
        }
    }
}
