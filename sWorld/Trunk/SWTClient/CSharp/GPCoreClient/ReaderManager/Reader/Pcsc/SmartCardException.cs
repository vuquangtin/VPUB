using System;

namespace ReaderManager.Pcsc
{
    public class SmartCardException : Exception
    {
        public SmartCardException() : base("Smart card exception") { }

        public SmartCardException(string message) : base(message) { }

        public SmartCardException(string message, Exception inner) : base(message, inner) { }

        public int ErrorCode { get; set; }
        public string Detail { get; set; }

        public SmartCardException(int errCode, string detail)
        {
            this.ErrorCode = errCode;
            this.Detail = detail;
        }
    }
}
