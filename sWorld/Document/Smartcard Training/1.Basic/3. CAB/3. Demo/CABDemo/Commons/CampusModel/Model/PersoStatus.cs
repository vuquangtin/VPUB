using System;
using System.Collections.Generic;
using System.Linq;

namespace CampusModel.Model
{
    public enum PersoStatus : int
    {
        Normal = 1 << 1,
        Locked = 1 << 2,
        Canceled = 1 << 3,
        Expired = 1 << 4,
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
                default:
                    return "N/A";
            }
        }
    }
}