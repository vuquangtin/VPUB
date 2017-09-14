using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace CommonHelper.Constants
{
   public static class FormatCharacterSearch
    {
        public static string CheckValue(string value)
        {
            StringBuilder sBuilder = new StringBuilder(value);

            string pattern = @"([-\]\[<>\?\*\\\""/\|\~\(\)\#/=><+\%&\^\'])";

            Regex expression = new Regex(pattern);

            if (expression.IsMatch(value))
            {
                //format
                sBuilder.Replace(@"'", @"''");//my

                sBuilder.Replace(@"[", @"[[]");
                sBuilder.Replace(@"*", @"[*]");
                sBuilder.Replace(@"%", @"[%]");
                //end format

                //sBuilder.Replace(@"\", @"\\");//1
                //sBuilder.Replace("]", @"\]");//2

                //sBuilder.Insert(0, "[");//3
                //sBuilder.Append("]");//4
            }
            return sBuilder.ToString();
        }
    }
}
