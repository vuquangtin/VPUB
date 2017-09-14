using System;
using System.Runtime.Serialization;
using System.Security;

namespace sWorldModel.Exceptions
{
    public class sWorldException : Exception
    {
        public int Code;
        public new string Source;

        public sWorldException(int code, object source)
        {
            Code = code;
            Source = source.ToString();
        }

        private sWorldException() : base() { }

        private sWorldException(string msg) : base(msg) { }

        [SecuritySafeCritical]
        private sWorldException(SerializationInfo info, StreamingContext ctx) : base(info, ctx) { }

        private sWorldException(string msg, Exception inner) : base(msg, inner) { }
    }
}
