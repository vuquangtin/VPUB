using System;
using System.Collections.Generic;
using System.Linq;

namespace sWorldModel.TransportData
{
    public enum PersoStatus : int
    {
        Normal = 0,
        Locked = 1,
        Canceled = 2,
        Expired = 3,
        NotPerso = 7,
    }

    public static class PersoStatusExtMethod
    {
        public static List<PersoStatus> GetPersoStatusList()
        {
            return Enum.GetValues(typeof(PersoStatus)).Cast<PersoStatus>().ToList();
        }

        public static PersoStatus ToPersoStatus(int intValue)
        {
            return (PersoStatus)intValue;
        }

        public static string GetName(this PersoStatus status)
        {
            switch(status)
            {
                case PersoStatus.Normal:
                    return "Bình thường";
                case PersoStatus.Canceled:
                    return "Đã hủy";
                case PersoStatus.Locked:
                    return "Đã khóa";
                case PersoStatus.Expired:
                    return "Hết hạn";
                case PersoStatus.NotPerso:
                    return "Chưa phát hành";
                default:
                    return "N/A";
            }
        }
    }
}