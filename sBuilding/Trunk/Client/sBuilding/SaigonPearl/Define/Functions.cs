using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sBuildingCommunication.Define
{
    [Structured(100)]
    public enum Functions:long
    {
        NULL = 0,
        FUNC_GROUP_DEVICE_DOOR_MGT = 101,
        FUNC_MEMBER_GROUP_MGT = 102,
        FUNC_CONFIG_ACCESS_CONTROLL=103
    }
    public static class FunctionExtMethods
    {
        public static List<Function> GetAll()
        {
            return Enum.GetValues(typeof(Function)).Cast<Function>().ToList();
        }

        public static List<Function> GetModuleList()
        {
            Object[] attributeList = typeof(Function).GetCustomAttributes(typeof(StructuredAttribute), true);

            if (attributeList.Length > 0)
            {
                StructuredAttribute attribute = (StructuredAttribute)attributeList[0];
                long span = attribute.Span;

                List<Function> result = new List<Function>();
                Function[] functions = (Function[])Enum.GetValues(typeof(Function));
                long modIndex;

                foreach (Function f in functions)
                {
                    modIndex = (long)Convert.ChangeType(f, typeof(long));
                    if (f != Function.NULL && (modIndex % span) == 0)
                    {
                        result.Add(f);
                    }
                }
                return result;
            }
            else
            {
                return new List<Function>();
            }
        }

        public static List<Function> GetChildList(this Function parent)
        {
            List<Function> result = new List<Function>();
            Function[] functions = (Function[])Enum.GetValues(typeof(Function));
            Object[] attributeList = typeof(Function).GetCustomAttributes(typeof(StructuredAttribute), true);

            if (attributeList.Length > 0)
            {
                StructuredAttribute attribute = (StructuredAttribute)attributeList[0];
                long span = attribute.Span;
                long parentIndex, childIndex, index;

                foreach (Function f in functions)
                {
                    parentIndex = (long)Convert.ChangeType(parent, typeof(long));
                    childIndex = (long)Convert.ChangeType(f, typeof(long));
                    index = (childIndex / span) * span;
                    if (index == parentIndex && childIndex != parentIndex)
                    {
                        result.Add(f);
                    }
                }
                return result;
            }
            else
            {
                return new List<Function>();
            }
        }

        public static bool IsChildOf(this Function child, Function parent)
        {
            Object[] attributeList = typeof(Function).GetCustomAttributes(typeof(StructuredAttribute), true);

            if (attributeList.Length > 0)
            {
                StructuredAttribute attribute = (StructuredAttribute)attributeList[0];
                long span = attribute.Span;
                long parentIndex = (long)Convert.ChangeType(parent, typeof(long));
                long childIndex = (long)Convert.ChangeType(child, typeof(long));
                long index = (childIndex / span) * span;
                bool res = index == parentIndex && childIndex != parentIndex;
                return res;
            }

            return false;
        }

        public static bool IsParentOf(this Function parent, Function child)
        {
            return child.IsChildOf(parent);
        }

        public static Function GetParent(this Function child)
        {
            Object[] attributeList = typeof(Function).GetCustomAttributes(typeof(StructuredAttribute), true);

            if (attributeList.Length > 0)
            {
                StructuredAttribute attribute = (StructuredAttribute)attributeList[0];
                long span = attribute.Span;
                long childIndex = (long)Convert.ChangeType(child, typeof(long));
                long index = childIndex / span;
                long parentIndex = index * span;
                if (parentIndex == childIndex)
                {
                    return Function.NULL;
                }
                return (Function)(index * span);
            }
            return Function.NULL;
        }

        public static string GetName(this Function function)
        {
            switch (function)
            {
               
                //case Function.MOD_TIMEKEEPING:
                //    return MenuNames.MenuTimeKeeping;
                //case Function.FUNC_TIMEKEEPING:
                //    return MenuNames.MenuTimeLogging;
                //case Function.FUNC_TIME_MANAGER:
                //    return MenuNames.MenuTimeManager;

                default:
                    return "N/A";
            }
        }

        public static string GetDescription(this Functions function)
        {
            switch (function)
            {
                case Functions.FUNC_GROUP_DEVICE_DOOR_MGT:
                    return "Chức năng này cho phép quản lý thiết bị cửa";
                case Functions.FUNC_MEMBER_GROUP_MGT:
                    return "Chức năng này cho phép quản lý nhóm người dùng";
                case Functions.FUNC_CONFIG_ACCESS_CONTROLL:
                    return "Chức năng này cho phép cấu hình cho phép ra vào cửa";
                default:
                    return "N/A";
            }
        }

        public static Functions ToFunction(long longValue)
        {
            return (Functions)longValue;
        }
    }

    [AttributeUsage(AttributeTargets.Enum)]
    public class StructuredAttribute : Attribute
    {
        public long span;

        public long Span
        {
            get { return span; }
            set { span = value; }
        }

        public StructuredAttribute(long span)
        {
            this.span = span;
        }
    }
}
