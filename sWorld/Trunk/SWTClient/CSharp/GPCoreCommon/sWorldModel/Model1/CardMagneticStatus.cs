using System;
using System.Collections.Generic;
using System.Linq;

namespace sWorldModel.Model
{
    public enum CardPhysicalStatus : int
    {
        Normal = 1,
        Broken = 1 << 1,
        Lost = 1 << 2,
        Lock = 1 <<3,
        Cancel = 1 <<4,
        Expired = 1 << 5,
    }

    public enum CardLogicalStatus : int
    {
        Printed = 1,
        NoPrinted = 1 << 1,
        Actived = 1 << 2,
        DeActived = 1 << 3,
    }

    public static class CardStatusExtMethod
    {
        public static List<CardPhysicalStatus> GetCardPhysicalStatusList()
        {
            return Enum.GetValues(typeof(CardPhysicalStatus)).Cast<CardPhysicalStatus>().ToList();
        }
        
        public static CardPhysicalStatus ToPhysicalStatus(int intValue)
        {
            return (CardPhysicalStatus)intValue;
        }

        public static string GetName(this CardPhysicalStatus status)
        {
            switch(status)
            {
                case CardPhysicalStatus.Normal:
                    return "Bình thường";
                case CardPhysicalStatus.Broken:
                    return "Bị hư";
                case CardPhysicalStatus.Lost:
                    return "Bị mất";
                case CardPhysicalStatus.Lock:
                    return "Bị khóa";
                case CardPhysicalStatus.Cancel:
                    return "Bị hủy";
                case CardPhysicalStatus.Expired:
                    return "Hết hạn";   
                default:
                    return "N/A";
            }
        }

        public static List<CardLogicalStatus> GetCardLogicalStatusList()
        {
            return Enum.GetValues(typeof(CardLogicalStatus)).Cast<CardLogicalStatus>().ToList();
        }

        public static CardLogicalStatus ToLogicalStatus(int intValue)
        {
            return (CardLogicalStatus)intValue;
        }

        public static string GetName(this CardLogicalStatus status)
        {
            switch (status)
            {
                case CardLogicalStatus.Printed:
                    return "Đã in";
                case CardLogicalStatus.NoPrinted:
                    return "Chưa in";
                case CardLogicalStatus.Actived:
                    return "Kích hoạt";
                case CardLogicalStatus.DeActived:
                    return "Chưa kích hoạt";
                default:
                    return "N/A";
            }
        }
    }
}

