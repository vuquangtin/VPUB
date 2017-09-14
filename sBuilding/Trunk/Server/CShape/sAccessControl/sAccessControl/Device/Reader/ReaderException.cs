using System;
using System.Runtime.Serialization;

namespace sAccessControl.Device.Reader
{
    internal sealed class ReaderException : Exception
    {
        public ReaderException (string message)
            : base(message)
        {
        }

        public ReaderException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public ReaderException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}