using System;
using System.Collections.Generic;
using System.Linq;

namespace sWorldModel.Model
{
    public enum HistoryChangedType : int
    {
        Delete = 1,
        Insert = 2,
        Update = 3,
    }

    public static class HistoryChangedTypeExtMethods
    {
        public static string GetAlias(this HistoryChangedType changedType)
        {
            switch (changedType)
            {
                case HistoryChangedType.Delete:
                    return "D";
                case HistoryChangedType.Insert:
                    return "I";
                case HistoryChangedType.Update:
                    return "U";
                default:
                    throw new ArgumentException("Invalid history changed type!");
            }
        }

        public static string GetName(this HistoryChangedType changedType)
        {
            switch (changedType)
            {
                case HistoryChangedType.Delete:
                    return "Xóa Bỏ";
                case HistoryChangedType.Insert:
                    return "Thêm Mới";
                case HistoryChangedType.Update:
                    return "Cập Nhật";
                default:
                    throw new ArgumentException("Invalid history changed type!");
            }
        }

        public static string GetName(string typeAlias)
        {
            switch(typeAlias)
            {
                case "D":
                    return "Xóa Bỏ";
                case "I":
                    return "Thêm Mới";
                case "U":
                    return "Cập Nhật";
                default:
                    return "N/A";
            }
        }

        public static List<HistoryChangedType> GetHistoryChangedTypeList()
        {
            return Enum.GetValues(typeof(HistoryChangedType)).Cast<HistoryChangedType>().ToList();
        }
    }
}
