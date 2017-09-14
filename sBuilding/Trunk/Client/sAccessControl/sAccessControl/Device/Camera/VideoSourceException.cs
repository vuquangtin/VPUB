using System;
using System.Runtime.Serialization;

namespace sAccessControl.Device.Camera
{
    internal class VideoSourceException : Exception
    {
        public VideoSourceException (string message) : base(message)
        {
        }

        public VideoSourceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public VideoSourceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}