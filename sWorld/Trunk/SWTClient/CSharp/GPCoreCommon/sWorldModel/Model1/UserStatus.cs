using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace sWorldModel.Model
{
    /// <summary>
    /// Statuses of user
    /// </summary>
    public enum UserStatus : int
    {
        // Normal status (account is enable)
        NORMAL = 1,

        // Account has been locked
        LOCKED = 1 << 1,

        // Account has been canceled
        CANCELED = 1 << 2,
    }

    public static class UserStatusExtMethod
    {
        /// <summary>
        /// Get list of user statuses
        /// </summary>
        /// <returns></returns>
        public static List<UserStatus> GetUserStatusList()
        {
            return Enum.GetValues(typeof(UserStatus)).Cast<UserStatus>().ToList();
        }

        /// <summary>
        /// Convert an 32-bit integer value to user status
        /// </summary>
        /// <param name="intValue"></param>
        /// <returns></returns>
        public static UserStatus ToUserStatus(int intValue)
        {
            return (UserStatus)intValue;
        }

        /// <summary>
        /// Get name of the specific user status
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public static string GetName(this UserStatus status)
        {
            switch(status)
            {
                case UserStatus.NORMAL:
                    return "Bình thường";
                case UserStatus.LOCKED:
                    return "Đã khóa";
                case UserStatus.CANCELED:
                    return "Đã hủy";
                default:
                    return "N/A";
            }
        }
    }
}
