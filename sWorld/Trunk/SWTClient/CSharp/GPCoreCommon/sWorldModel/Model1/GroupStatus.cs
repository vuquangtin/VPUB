using System;
using System.Collections.Generic;
using System.Linq;

namespace sWorldModel.Model
{
    /// <summary>
    /// Statuses of group
    /// </summary>
    public enum GroupStatus : int
    {
        // Normal status (group is enable)
        Normal = 1,

        // Group has been canceled
        Canceled = 1 << 2,
    }

    public static class GroupStatusExtMethod
    {
        /// <summary>
        /// Get list of group statuses
        /// </summary>
        /// <returns></returns>
        public static List<GroupStatus> GetGroupStatusList()
        {
            return Enum.GetValues(typeof(GroupStatus)).Cast<GroupStatus>().ToList();
        }

        /// <summary>
        /// Convert an 32-bit integer value to group status
        /// </summary>
        /// <param name="intValue"></param>
        /// <returns></returns>
        public static GroupStatus ToGroupStatus(int intValue)
        {
            return (GroupStatus)intValue;
        }

        /// <summary>
        /// Get name of the specific group status
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static string GetName(this GroupStatus status)
        {
            switch (status)
            {
                case GroupStatus.Normal:
                    return "Bình thường";
                case GroupStatus.Canceled:
                    return "Đã hủy";
                default:
                    return "N/A";
            }
        }
    }
}
