using System;
using System.Runtime.Serialization;

namespace ScanComponent {
    internal class ScanException : Exception {
        public ScanException(string message) : base(message) {
        }

        public ScanException(string message, Exception innerException) : base(message, innerException) {
        }

        public ScanException(SerializationInfo info, StreamingContext context) : base(info, context) {
        }
    }
}
