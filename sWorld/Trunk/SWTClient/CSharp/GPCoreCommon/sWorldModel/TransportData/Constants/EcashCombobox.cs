using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sWorldModel.TransportData
{
    //public enum Gender : int
    //{
    //    Other = 1,
    //    Male = 2,
    //    Female = 3,
    //}

    public enum TypeCard : int
    {
        Voucher = 4,
        Gift = 5,
    }

    public enum Location : int
    {
        HoChiMinh = 6,
        HaNoi = 7,
    }

    public static class VoucherCombobox
    {
        //public static List<Gender> GetGenderList()
        //{
        //    return Enum.GetValues(typeof(Gender)).Cast<Gender>().ToList();
        //}
        //public static Gender ToGenderStatus(int intValue)
        //{
        //    return (Gender)intValue;
        //}
        //public static string GetName(this Gender status)
        //{
        //    switch (status)
        //    {
        //        case Gender.Other:
        //            return "Khác";
        //        case Gender.Male:
        //            return "Nam";
        //        case Gender.Female:
        //            return "Nữ";
        //        default:
        //            return "N/A";
        //    }
        //}


        public static List<TypeCard> GetVoucherList()
        {
            return Enum.GetValues(typeof(TypeCard)).Cast<TypeCard>().ToList();
        }
        public static TypeCard ToTypeCardStatus(int intValue)
        {
            return (TypeCard)intValue;
        }
        public static string GetName(this TypeCard status)
        {
            switch (status)
            {
                case TypeCard.Voucher:
                    return "Voucher";
                case TypeCard.Gift:
                    return "Gift";
                default:
                    return "N/A";
            }
        }


        public static List<Location> GetLocationList()
        {
            return Enum.GetValues(typeof(Location)).Cast<Location>().ToList();
        }
        public static Location ToLocationStatus(int intValue)
        {
            return (Location)intValue;
        }
        public static string GetName(this Location status)
        {
            switch (status)
            {
                case Location.HoChiMinh:
                    return "TP Hồ Chí Minh";
                case Location.HaNoi:
                    return "Hà Nội";
                default:
                    return "N/A";
            }
        }
    }

}