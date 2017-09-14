using System;

namespace ReaderLibrary
{
	public class ScException : Exception
	{
        [Obsolete]
        private ScException() : base("Smart card exception") { }

        [Obsolete]
        private ScException(string message) : base(message) { }

        [Obsolete]
        private ScException(string message, Exception inner) : base(message, inner) { }

        public int ErrorCode { get; set; }
        public string Detail { get; set; }

        public ScException(int errCode, string detail)
        {
            this.ErrorCode = errCode;
            this.Detail = detail;
        }
	}
}