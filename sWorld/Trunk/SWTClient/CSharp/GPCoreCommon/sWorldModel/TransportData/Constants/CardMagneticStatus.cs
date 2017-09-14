using System;
using System.Collections.Generic;
using System.Linq;

namespace sWorldModel.TransportData
{
    public enum CardMagneticPhysicalStatus : int
    {
        Normal = 1,
        Broken = 2,
        Lost = 3,
    }

    public enum CardMagneticStatus : int
    {
        Actived = 9,
        DeActived = 10,
        Lock = 4,
        Cancel = 5,
        Expired = 6,
    }

    public enum CardMageneticPrintedStatus : int
    { 
        Printed = 7,
        NotPrinted = 8,
    }

    public static class CardMagneticStatusExtMethod
    {
        public static List<CardMagneticPhysicalStatus> GetCardPhysicalStatusList()
        {
            return Enum.GetValues(typeof(CardMagneticPhysicalStatus)).Cast<CardMagneticPhysicalStatus>().ToList();
        }

        public static CardMagneticPhysicalStatus ToPhysicalStatus(int intValue)
        {
            return (CardMagneticPhysicalStatus)intValue;
        }

        public static string GetName(this CardMagneticPhysicalStatus status)
        {
            switch(status)
            {
                case CardMagneticPhysicalStatus.Normal:
                    return "Bình thường";
                case CardMagneticPhysicalStatus.Broken:
                    return "Bị hư";
                case CardMagneticPhysicalStatus.Lost:
                    return "Bị mất";
                default:
                    return "N/A";
            }
        }

        public static List<CardMagneticStatus> GetCardStatusList()
        {
            return Enum.GetValues(typeof(CardMagneticStatus)).Cast<CardMagneticStatus>().ToList();
        }

        public static CardMagneticStatus ToStatus(int intValue)
        {
            return (CardMagneticStatus)intValue;
        }

        public static string GetName(this CardMagneticStatus status)
        {
            switch (status)
            {
                case CardMagneticStatus.Lock:
                    return "Khóa";
                case CardMagneticStatus.Cancel:
                    return "Hủy";
                case CardMagneticStatus.Expired:
                    return "Hết hạn";
                case CardMagneticStatus.Actived:
                    return "Kích hoạt";
                case CardMagneticStatus.DeActived:
                    return "Chưa kích hoạt";
                default:
                    return "N/A";
            }
        }

        public static List<CardMageneticPrintedStatus> GetCardPrintedStatusList()
        {
            return Enum.GetValues(typeof(CardMageneticPrintedStatus)).Cast<CardMageneticPrintedStatus>().ToList();
        }

        public static CardMageneticPrintedStatus ToPrintedStatus(int intValue)
        {
            return (CardMageneticPrintedStatus)intValue;
        }

        public static string GetName(this CardMageneticPrintedStatus status)
        {
            switch (status)
            { 
                case CardMageneticPrintedStatus.Printed:
                    return "Đã in";
                case CardMageneticPrintedStatus.NotPrinted:
                    return "Chưa in";
                default:
                    return "N/A";
            }
        
        }










    }
}

