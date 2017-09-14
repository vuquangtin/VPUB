using System;
using System.Collections.Generic;
using System.Linq;

namespace CampusModel.Model
{
    [Structured(100)]
    public enum Function : long
    {
        NULL = 0,

        MOD_PERSO_MGT = 100,
            FUNC_PERSO_VIEW = 101,
            FUNC_PERSO_CHANGE_STATUS = 103,
            FUNC_PERSO_PERSO_CARD = 104,
            FUNC_PERSO_EXTEND = 105,

        MOD_CARD_MGT = 200,
            FUNC_CARD_VIEW = 201,
            FUNC_CARD_CHANGE_STATUS = 203,
            FUNC_CARD_IMPORT = 204,

        MOD_TEACHER_MGT = 300,
            FUNC_TEACHER_VIEW = 301,

        MOD_STATS = 500,

        MOD_TOOLKIT = 600,
            FUNC_TOOLKIT_CLEAR_DATA = 601,
            FUNC_TOOLKIT_READ_DATA = 602,
            FUNC_TOOLKIT_UPDATE_DATA = 603,
    }

    public static class FunctionExtMethod
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
                case Function.MOD_PERSO_MGT:
                    return "Quản lý lượt phát hành";
                case Function.FUNC_PERSO_VIEW:
                    return "Xem thông tin lượt phát hành";
                case Function.FUNC_PERSO_CHANGE_STATUS:
                    return "Thay đổi trạng thái lượt phát hành";
                case Function.FUNC_PERSO_PERSO_CARD:
                    return "Phát hành thẻ cho giảng viên";
                case Function.FUNC_PERSO_EXTEND:
                    return "Gia hạn lượt phát hành";

                case Function.MOD_CARD_MGT:
                    return "Quản lý thẻ";
                case Function.FUNC_CARD_VIEW:
                    return "Xem thông tin thẻ";
                case Function.FUNC_CARD_CHANGE_STATUS:
                    return "Thay đổi trạng thái của thẻ";
                case Function.FUNC_CARD_IMPORT:
                    return "Nhập thẻ vào hệ thống";

                case Function.MOD_TEACHER_MGT:
                    return "Quản lý giảng viên";
                case Function.FUNC_TEACHER_VIEW:
                    return "Xem thông tin giảng viên";

                case Function.MOD_STATS:
                    return "Xem thống kê";

                case Function.MOD_TOOLKIT:
                    return "Công cụ thẻ";
                case Function.FUNC_TOOLKIT_CLEAR_DATA:
                    return "Xóa dữ liệu trên thẻ";
                case Function.FUNC_TOOLKIT_READ_DATA:
                    return "Đọc dữ liệu trên thẻ";
                case Function.FUNC_TOOLKIT_UPDATE_DATA:
                    return "Cập nhật toàn bộ dữ liệu trên thẻ";

                default:
                    return "N/A";
            }
        }

        public static string GetDescription(this Function function)
        {
            switch (function)
            {
                case Function.MOD_PERSO_MGT:
                    return "Quản lý các lượt phát hành.";
                case Function.FUNC_PERSO_VIEW:
                    return "Chức năng này cho phép người dùng xem danh sách tổng quát tất cả lượt phát hành, lẫn thông tin chi tiết của một lượt phát hành bất kỳ.";
                case Function.FUNC_PERSO_CHANGE_STATUS:
                    return "Chức năng này cho phép người dùng thay đổi trạng thái của các lượt phát hành, như: khóa lượt phát hành, mở khóa lượt phát hành, hủy lượt phát hành.";
                case Function.FUNC_PERSO_PERSO_CARD:
                    return "Chức năng này cho phép người dùng phát hành thẻ cho giảng viên.";

                case Function.MOD_CARD_MGT:
                    return "Quản lý các thẻ đã nhập vào hệ thống.";
                case Function.FUNC_CARD_VIEW:
                    return "Chức năng này cho phép người dùng xem danh sách tổng quát các thẻ hiện có trong hệ thống, lẫn thông tin chi tiết của một thẻ bất kỳ.";
                case Function.FUNC_CARD_CHANGE_STATUS:
                    return "Chức năng này cho phép người dùng thay đổi trạng thái của thẻ, như: đánh dấu/hủy đánh dấu thẻ mất, đánh dấu/hủy đánh dấu thẻ hư.";
                case Function.FUNC_CARD_IMPORT:
                    return "Chức năng này cho phép người dùng nhập thẻ mới vào hệ thống";

                case Function.MOD_TEACHER_MGT:
                    return "Quản lý danh sách giảng viên được tích hợp từ cơ sở dữ liệu của nhà trường.";
                case Function.FUNC_TEACHER_VIEW:
                    return "Chức năng này cho phép người dùng xem danh sách tổng quát các giảng viên, lẫn thông tin chi tiết của một giảng viên bất kỳ.";

                case Function.MOD_STATS:
                    return "Thống kê dữ liệu.";

                case Function.MOD_TOOLKIT:
                    return "Bao gồm các công cụ tương tác với thẻ thông minh.";
                case Function.FUNC_TOOLKIT_CLEAR_DATA:
                    return "Chức năng này cho phép người dùng xóa toàn bộ dữ liệu phát hành trên thẻ.";
                case Function.FUNC_TOOLKIT_READ_DATA:
                    return "Chức năng này cho phép người dùng đọc thông tin giảng viên được lưu trên thẻ.";
                case Function.FUNC_TOOLKIT_UPDATE_DATA:
                    return "Chức năng này cho phép người dùng đồng bộ dữ liệu hiện có trên thẻ với dữ liệu trong hệ thống.";

                default:
                    return "N/A";
            }
        }

        public static Function ToFunction(long longValue)
        {
            return (Function)longValue;
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
