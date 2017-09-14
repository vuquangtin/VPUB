using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JavaCommunication
{
    public class TYPECOMM
    {
        public const String JAVA = "JAVA";
        public const String TEST = "TEST";
    }

    public enum Status 
    {
        SUCCESS = 0,
        FAILED = 1,
        CANCEL = 2,
        OKIE = 3
    }

    public class StrConst
    {
        public static readonly String SESSIONID = @"sessionid";
    }
}
