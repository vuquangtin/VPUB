using System;
using System.Collections.Generic;
using System.Linq;

namespace CampusModel.Model
{
    public enum CardPhysicalStatus : int
    {
        Normal = 1,
        Broken = 1 << 1,
        Lost = 1 << 2,
    }

    public enum CardLogicalStatus : int
    {
        Activated = 1 << 1,
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
                case CardLogicalStatus.Activated:
                    return "Đã kích hoạt";
                default:
                    return "N/A";
            }
        }
    }
}