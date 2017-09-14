using System;
using System.Collections.Generic;
using System.Linq;

namespace sTimeKeeping.Constants {
    /// <summary>
    /// enum FunctionTimeKeeping 
    /// </summary>
    public enum FunctionTimeKeeping {
        NULL = 0,
        MOD_TIMEKEEPING = 500,
        FUNC_TIMEKEEPING_DEVICE_CONFIG = 501,
        FUNC_TIMEKEEPING_TIME_CONFIG = 502,
        FUNC_TIMEKEEPING_USER_TIME_CONFIG = 503,
        FUNC_USER_STATISTIC = 504,
        FUNC_MONTH_STATISTIC = 505,
        FUNC_DATE_STATISTIC = 506,
        FUNC_TIME_EVENT = 507,
        FUNC_TIMEKEEPING_HOLIDAY_CONFIG = 508,
        FUNC_TIMEKEEPING_GENERAL_CONFIG = 509,
        FUNC_TIMEKEEPING_DAY_OFF_CONFIG = 510,
        //FUNC_FORM_TIMEKEEPING = xxx,      // Đóng code để sau này có cần màn hình cảm ứng riêng
        FUNC_TIMEKEEPING_WITHOUT_CARD = 511
    }

    /// <summary>
    /// class FunctionTimeKeepingExtMethod 
    /// </summary>
    public static class FunctionTimeKeepingExtMethod {
        public static List<FunctionTimeKeeping> GetAll() {
            return Enum.GetValues(typeof(FunctionTimeKeeping)).Cast<FunctionTimeKeeping>().ToList();
        }

        public static List<FunctionTimeKeeping> GetModuleList() {
            Object[] attributeList = typeof(FunctionTimeKeeping).GetCustomAttributes(typeof(StructuredAttribute), true);

            if (attributeList.Length > 0) {
                StructuredAttribute attribute = (StructuredAttribute) attributeList[0];
                long span = attribute.Span;

                List<FunctionTimeKeeping> result = new List<FunctionTimeKeeping>();
                FunctionTimeKeeping[] functions = (FunctionTimeKeeping[]) Enum.GetValues(typeof(FunctionTimeKeeping));
                long modIndex;

                foreach (FunctionTimeKeeping f in functions) {
                    modIndex = (long) Convert.ChangeType(f, typeof(long));
                    if (f != FunctionTimeKeeping.NULL && (modIndex % span) == 0) {
                        result.Add(f);
                    }
                }
                return result;
            } else {
                return new List<FunctionTimeKeeping>();
            }
        }

        public static List<FunctionTimeKeeping> GetChildList(this FunctionTimeKeeping parent) {
            List<FunctionTimeKeeping> result = new List<FunctionTimeKeeping>();
            FunctionTimeKeeping[] functions = (FunctionTimeKeeping[])Enum.GetValues(typeof(FunctionTimeKeeping));
            Object[] attributeList = typeof(FunctionTimeKeeping).GetCustomAttributes(typeof(StructuredAttribute), true);

            if (attributeList.Length > 0) {
                StructuredAttribute attribute = (StructuredAttribute) attributeList[0];
                long span = attribute.Span;
                long parentIndex, childIndex, index;

                foreach (FunctionTimeKeeping f in functions) {
                    parentIndex = (long) Convert.ChangeType(parent, typeof(long));
                    childIndex = (long) Convert.ChangeType(f, typeof(long));
                    index = (childIndex / span) * span;
                    if (index == parentIndex && childIndex != parentIndex) {
                        result.Add(f);
                    }
                }
                return result;
            } else {
                return new List<FunctionTimeKeeping>();
            }
        }

        public static bool IsChildOf(this FunctionTimeKeeping child, FunctionTimeKeeping parent) {
            Object[] attributeList = typeof(FunctionTimeKeeping).GetCustomAttributes(typeof(StructuredAttribute), true);

            if (attributeList.Length > 0) {
                StructuredAttribute attribute = (StructuredAttribute) attributeList[0];
                long span = attribute.Span;
                long parentIndex = (long) Convert.ChangeType(parent, typeof(long));
                long childIndex = (long) Convert.ChangeType(child, typeof(long));
                long index = (childIndex / span) * span;
                bool res = index == parentIndex && childIndex != parentIndex;
                return res;
            }

            return false;
        }

        public static bool IsParentOf(this FunctionTimeKeeping parent, FunctionTimeKeeping child) {
            return child.IsChildOf(parent);
        }

        public static FunctionTimeKeeping GetParent(this FunctionTimeKeeping child) {
            Object[] attributeList = typeof(FunctionTimeKeeping).GetCustomAttributes(typeof(StructuredAttribute), true);

            if (attributeList.Length > 0) {
                StructuredAttribute attribute = (StructuredAttribute) attributeList[0];
                long span = attribute.Span;
                long childIndex = (long) Convert.ChangeType(child, typeof(long));
                long index = childIndex / span;
                long parentIndex = index * span;
                if (parentIndex == childIndex) {
                    return FunctionTimeKeeping.NULL;
                }
                return (FunctionTimeKeeping) (index * span);
            }
            return FunctionTimeKeeping.NULL;
        }

        public static string GetName(this FunctionTimeKeeping function) {
            switch (function) {
                case FunctionTimeKeeping.MOD_TIMEKEEPING:
                    return DefineName.MenuTimeKeeping;
                case FunctionTimeKeeping.FUNC_TIMEKEEPING_DEVICE_CONFIG:
                    return DefineName.MenuDeviceConfig;
                case FunctionTimeKeeping.FUNC_TIMEKEEPING_TIME_CONFIG:
                    return DefineName.MenuTimeConfig;
                case FunctionTimeKeeping.FUNC_TIMEKEEPING_USER_TIME_CONFIG:
                    return DefineName.MenuUserTimeConfig;
                case FunctionTimeKeeping.FUNC_TIME_EVENT:
                    return DefineName.MenuTimeEvent;
                case FunctionTimeKeeping.FUNC_USER_STATISTIC:
                    return DefineName.MenuUserStatistic;
                case FunctionTimeKeeping.FUNC_MONTH_STATISTIC:
                    return DefineName.MenuMonthStatistic;
                case FunctionTimeKeeping.FUNC_DATE_STATISTIC:
                    return DefineName.MenuDateStatistic;
                case FunctionTimeKeeping.FUNC_TIMEKEEPING_HOLIDAY_CONFIG:
                    return DefineName.MenuHolidayConfig;
                case FunctionTimeKeeping.FUNC_TIMEKEEPING_GENERAL_CONFIG:
                    return DefineName.MenuGeneralConfig;
                case FunctionTimeKeeping.FUNC_TIMEKEEPING_DAY_OFF_CONFIG:
                    return DefineName.MenuDayOffConfig;
                //case FunctionTimeKeeping.FUNC_FORM_TIMEKEEPING:
                //    return DefineName.MenuFormTimeKeeping;        // Đóng code để sau này có cần màn hình cảm ứng riêng
                case FunctionTimeKeeping.FUNC_TIMEKEEPING_WITHOUT_CARD:
                    return DefineName.MenuTimeKeepingWithoutCard;
                default:
                    return "N/A";
            }
        }

        public static string GetDescription(this FunctionTimeKeeping function) {
            switch (function) {
                case FunctionTimeKeeping.MOD_TIMEKEEPING:
                    return "Chấm công";
                case FunctionTimeKeeping.FUNC_TIMEKEEPING_DEVICE_CONFIG:
                    return "Chức năng này cho phép người dùng cấu hình thiết bị chấm công.";
                case FunctionTimeKeeping.FUNC_TIMEKEEPING_TIME_CONFIG:
                    return "Chức năng này cho phép người dùng cấu hình thời gian chấm công";
                case FunctionTimeKeeping.FUNC_TIMEKEEPING_USER_TIME_CONFIG:
                    return "Chức năng này cho phép người dùng cấu hình thời gian chấm công cho từng người";
                case FunctionTimeKeeping.FUNC_TIME_EVENT:
                    return "Chức năng này cho phép người dùng quản lý sự kiện chấm công";
                case FunctionTimeKeeping.FUNC_MONTH_STATISTIC:
                    return "Chức năng này dùng để thống kê theo thiết bị";
                case FunctionTimeKeeping.FUNC_USER_STATISTIC:
                    return "Chức năng này dùng để thống kê theo thành viên";
                case FunctionTimeKeeping.FUNC_TIMEKEEPING_HOLIDAY_CONFIG:
                    return "Chức năng này cho phép người dùng cấu hình ngày lễ";
                case FunctionTimeKeeping.FUNC_TIMEKEEPING_GENERAL_CONFIG:
                    return "Chức năng này cho phép người dùng cấu hình màu";
                case FunctionTimeKeeping.FUNC_TIMEKEEPING_DAY_OFF_CONFIG:
                    return "Chức năng này cho phép người dùng cấu hình ngày nghỉ";
                //case FunctionTimeKeeping.FUNC_FORM_TIMEKEEPING:       // Đóng code để sau này có cần màn hình cảm ứng riêng
                //    return "Chức năng này dùng để chấm công màn hình cảm ứng";
                case FunctionTimeKeeping.FUNC_TIMEKEEPING_WITHOUT_CARD:
                    return "Chức năng này dùng để chấm công khi quên thẻ";
                default:
                    return "N/A";
            }
        }

        public static FunctionTimeKeeping ToFunction(long longValue) {
            return (FunctionTimeKeeping) longValue;
        }
    }

    /// <summary>
    /// class StructuredAttribute : Attribute 
    /// </summary>
    [AttributeUsage(AttributeTargets.Enum)]
    public class StructuredAttribute : Attribute {
        public long span;

        public long Span {
            get { return span; }
            set { span = value; }
        }

        public StructuredAttribute(long span) {
            this.span = span;
        }
    }
}
