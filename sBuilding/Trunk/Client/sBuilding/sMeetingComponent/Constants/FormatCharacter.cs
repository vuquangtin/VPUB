using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace sMeetingComponent.Constants
{
    public class FormatCharacter
    {
        public FormatCharacter() { }

        //20170307 #Bug Fix- My Nguyen Start
        /// <summary>
        /// REPLACE CHAR SPECIAL
        /// lai ky tu tim kiem truoc khi loc
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string CheckValue(string value)
        {
            StringBuilder sBuilder = new StringBuilder(value);

            string pattern = @"([-\]\[<>\?\*\\\""/\|\~\(\)\#/=><+\%&\^\'])";
            //String specialChars2 = "[`~!@#$%^&*()_+[\\]\\\\;\',./{}|:\"<>?]";
            //string pattern2 = @"([-\]\[<>\?\*\\\""/\|\~\(\)\#/=><+\%&\^\'])";

            Regex expression = new Regex(pattern);

            if (expression.IsMatch(value))
            {
                // ~!@#$%^&*()_+{}|:"<>?`[]\;',./
                // dac biet khac %* ][\
                // [[]

                //format
                sBuilder.Replace(@"'", @"''");
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
        //20170307 #Bug Fix- My Nguyen End

        // String s = "[[]";
        // dv.RowFilter = string.Format("MeetingName LIKE'%{0}%'", s);
    }
}
