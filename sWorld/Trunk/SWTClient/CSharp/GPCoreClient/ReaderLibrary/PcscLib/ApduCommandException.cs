using System;

namespace ReaderLibrary.PcscLib
{
    public class ApduCommandException : Exception
    {
        public const string
            NOT_VALID_DOCUMENT = "The file is not a valid APDU command document",
            NO_SUCH_COMMAND = "No such APDU command in the document",
            PARAM_LE_FORMAT = "Le parameter format is not correct",
            PARAM_P3_FORMANT = "P3 parameter format is not correct",
            NO_SUCH_SEQUENCE = "No such APDU sequence in the document",
            MISSING_APDU_OR_COMMAND = "An Apdu or a Sequence is missing in this Sequence";

        public ApduCommandException() : base("APDU command exception") { }

        public ApduCommandException(string Message) : base(Message) { }
    }
}
