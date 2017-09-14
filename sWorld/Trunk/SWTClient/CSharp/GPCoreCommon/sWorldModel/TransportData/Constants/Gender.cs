using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sWorldModel.TransportData.Constants
{
    public enum Gender : int
    {
        Male = 1,
        Female = 2,
        Other = 3
    }

    public static class GenderExtMethod
    {
        public static List<Gender> GetCardTypeList()
        {
            return Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
        }

        public static Gender ToGender(int intValue)
        {
            return (Gender)intValue;
        }

        public static string GetName(this Gender type)
        {
            switch (type)
            {
                case Gender.Male:
                    return "Nam";
                case Gender.Female:
                    return "Nữ";
                case Gender.Other:
                    return "Other";
                default:
                    return "N/A";
            }
        }
    }
}
