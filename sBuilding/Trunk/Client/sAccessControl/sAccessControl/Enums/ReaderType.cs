using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sAccessControl.Enums
{
    internal enum ReaderType : int
    {
        HF = 1,
        PCSC = 2,
    }

    internal static class ReaderTypeExt
    {
        public static List<ReaderType> GetReaderTypeList()
        {
            var result = Enum.GetValues(typeof(ReaderType)).Cast<ReaderType>().ToList();
            result.Sort((x, y) => { return string.Compare(x.GetName(), y.GetName()); });
            return result;
        }

        public static string GetName(this ReaderType type)
        {
            switch (type)
            {
                case ReaderType.HF:
                    return "HF Reader";
                case ReaderType.PCSC:
                    return "PCSC Reader";
                default:
                    return string.Empty;
            }
        }
    }
}
