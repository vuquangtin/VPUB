using System;
using System.Collections.Generic;
using System.Linq;

namespace sNonResidentComponent.Constants {
    public enum FunctionNonResident {
        NULL = 0,
        FUNC_NONRESIDENT = 500,
        FUNC_NONRESIDENT_MANAGECARD = 501,
        FUNC_NONRESIDENT_STATISTIC = 502,
        FUNC_NONRESIDENT_STATISTIC_DETAIL = 503,
        FUNC_NONRESIDENT_MANAGEMEETING = 504,
    }

    public static class FunctionNonResidentExtMethod {
        public static string GetName(this FunctionNonResident function)
        {
            switch (function)
            {
                case FunctionNonResident.FUNC_NONRESIDENT:
                    return NonResidentDefineName.MenuNonResidentItem;
                case FunctionNonResident.FUNC_NONRESIDENT_MANAGECARD:
                    return NonResidentDefineName.MenuManageCardNonResidentItem;
                case FunctionNonResident.FUNC_NONRESIDENT_STATISTIC:
                    return NonResidentDefineName.MenuNonResidentStatisticItem;
                case FunctionNonResident.FUNC_NONRESIDENT_STATISTIC_DETAIL:
                    return NonResidentDefineName.MenuNonResidentStatisticDetailItem;
                case FunctionNonResident.FUNC_NONRESIDENT_MANAGEMEETING:
                    return NonResidentDefineName.MenuManageMeetingItem;
               
                default:
                    return "N/A";
            }
        }

        public static string GetDescription(this FunctionNonResident function)
        {
            switch (function)
            {
                case FunctionNonResident.FUNC_NONRESIDENT:
                    return "Kiểm soát khách vãng lai";
                case FunctionNonResident.FUNC_NONRESIDENT_STATISTIC:
                    return "Thống kê khách vãng lai";
                case FunctionNonResident.FUNC_NONRESIDENT_MANAGECARD:
                    return "Quản lý phát hành thẻ khách vãng lai";
                case FunctionNonResident.FUNC_NONRESIDENT_STATISTIC_DETAIL:
                    return "Thống kê chi tiết khách vãng lai";
                case FunctionNonResident.FUNC_NONRESIDENT_MANAGEMEETING:
                    return "Quản lý cuộc họp nội bộ";
                default:
                    return "N/A";
            }
        }

        public static List<FunctionNonResident> GetAll() {
            return Enum.GetValues(typeof(FunctionNonResident)).Cast<FunctionNonResident>().ToList();
        }

        public static List<FunctionNonResident> GetModuleList() {
            Object[] attributeList = typeof(FunctionNonResident).GetCustomAttributes(typeof(StructuredAttribute), true);

            if (attributeList.Length > 0) {
                StructuredAttribute attribute = (StructuredAttribute) attributeList[0];
                long span = attribute.Span;

                List<FunctionNonResident> result = new List<FunctionNonResident>();
                FunctionNonResident[] functions = (FunctionNonResident[]) Enum.GetValues(typeof(FunctionNonResident));
                long modIndex;

                foreach (FunctionNonResident f in functions) {
                    modIndex = (long) Convert.ChangeType(f, typeof(long));
                    if (f != FunctionNonResident.NULL && (modIndex % span) == 0) {
                        result.Add(f);
                    }
                }
                return result;
            } else {
                return new List<FunctionNonResident>();
            }
        }

        public static List<FunctionNonResident> GetChildList(this FunctionNonResident parent) {
            List<FunctionNonResident> result = new List<FunctionNonResident>();
            FunctionNonResident[] functions = (FunctionNonResident[]) Enum.GetValues(typeof(FunctionNonResident));
            Object[] attributeList = typeof(FunctionNonResident).GetCustomAttributes(typeof(StructuredAttribute), true);

            if (attributeList.Length > 0) {
                StructuredAttribute attribute = (StructuredAttribute) attributeList[0];
                long span = attribute.Span;
                long parentIndex, childIndex, index;

                foreach (FunctionNonResident f in functions) {
                    parentIndex = (long) Convert.ChangeType(parent, typeof(long));
                    childIndex = (long) Convert.ChangeType(f, typeof(long));
                    index = (childIndex / span) * span;
                    if (index == parentIndex && childIndex != parentIndex) {
                        result.Add(f);
                    }
                }
                return result;
            } else {
                return new List<FunctionNonResident>();
            }
        }

        public static bool IsChildOf(this FunctionNonResident child, FunctionNonResident parent) {
            Object[] attributeList = typeof(FunctionNonResident).GetCustomAttributes(typeof(StructuredAttribute), true);

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

        public static bool IsParentOf(this FunctionNonResident parent, FunctionNonResident child) {
            return child.IsChildOf(parent);
        }

        public static FunctionNonResident GetParent(this FunctionNonResident child) {
            Object[] attributeList = typeof(FunctionNonResident).GetCustomAttributes(typeof(StructuredAttribute), true);

            if (attributeList.Length > 0) {
                StructuredAttribute attribute = (StructuredAttribute) attributeList[0];
                long span = attribute.Span;
                long childIndex = (long) Convert.ChangeType(child, typeof(long));
                long index = childIndex / span;
                long parentIndex = index * span;
                if (parentIndex == childIndex) {
                    return FunctionNonResident.NULL;
                }
                return (FunctionNonResident) (index * span);
            }
            return FunctionNonResident.NULL;
        }


        public static FunctionNonResident ToFunction(long longValue) {
            return (FunctionNonResident) longValue;
        }
    }

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
