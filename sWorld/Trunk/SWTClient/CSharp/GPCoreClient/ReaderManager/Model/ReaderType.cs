
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReaderManager.Model
{
    public enum ReaderType : int
    {
        PCSC = 1,
        HF = 2,
        MCR02 = 3,
        ICDREC = 4,
    }

    public static class ReaderTypeExt
    {
        public static List<ReaderType> GetReaderTypeList()
        {
            var result = System.Enum.GetValues(typeof(ReaderType)).Cast<ReaderType>().ToList();
            result.Sort((x, y) => { return string.Compare(x.GetName(), y.GetName()); });
            return result;
        }

        public static string GetName(this ReaderType type)
        {
            switch (type)
            {
                //case ReaderType.HF:
                //    return "HF Reader";
                case ReaderType.PCSC:
                    return "PCSC Reader";
                case ReaderType.MCR02:
                    return "MCR02 Reader";
                case ReaderType.ICDREC:
                    return "ICDREC Reader";
                default:
                    return string.Empty;
            }
        }
    }
}
