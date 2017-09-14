using System;
using System.Collections.Generic;
using System.Linq;

namespace sWorldModel.TransportData
{
    public enum CardPhysicalStatus : int
    {
        Normal = 0,
        Broken = 4,
        Lost = 5,
        NotCardSystem = -1
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
            switch (status)
            {
                case CardPhysicalStatus.Normal:
                    return "Nomal";
                case CardPhysicalStatus.Broken:
                    return "Bị hư";
                case CardPhysicalStatus.Lost:
                    return "Bị mất";
                case CardPhysicalStatus.NotCardSystem:
                    return "Thẻ không có trong hệ thống";
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