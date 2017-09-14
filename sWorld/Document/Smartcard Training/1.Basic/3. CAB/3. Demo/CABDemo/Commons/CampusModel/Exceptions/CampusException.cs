using System;
using System.Runtime.Serialization;
using System.Security;

namespace CampusModel.Exceptions
{
    public class CampusException : Exception
    {
        public int Code;
        public new string Source;

        public CampusException(int code, object source)
        {
            Code = code;
            Source = source.ToString();
        }

        private CampusException() : base() { }

        private CampusException(string msg) : base(msg) { }

        [SecuritySafeCritical]
        private CampusException(SerializationInfo info, StreamingContext ctx) : base(info, ctx) { }

        private CampusException(string msg, Exception inner) : base(msg, inner) { }
    }
}
