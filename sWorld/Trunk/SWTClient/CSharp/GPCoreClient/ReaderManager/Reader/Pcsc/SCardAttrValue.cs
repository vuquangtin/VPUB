using System;

namespace ReaderManager.Pcsc
{
    /// <summary>
    /// Values for AttrId of SCardGetAttrib
    /// </summary>
    public class SCardAttrValue
    {
        private const uint
            SCARD_CLASS_COMMUNICATIONS = 2,
            SCARD_CLASS_PROTOCOL = 3,
            SCARD_CLASS_MECHANICAL = 6,
            SCARD_CLASS_VENDOR_DEFINED = 7,
            SCARD_CLASS_IFD_PROTOCOL = 8,
            SCARD_CLASS_ICC_STATE = 9,
            SCARD_CLASS_SYSTEM = 0x7fff;

        private static UInt32 AttrValue(UInt32 attrClass, UInt32 val)
        {
            return (attrClass << 16) | val;
        }

        public static UInt32 CHANNEL_ID { get { return AttrValue(SCARD_CLASS_COMMUNICATIONS, 0x0110); } }

        public static UInt32 CHARACTERISTICS { get { return AttrValue(SCARD_CLASS_MECHANICAL, 0x0150); } }

        public static UInt32 CURRENT_PROTOCOL_TYPE { get { return AttrValue(SCARD_CLASS_IFD_PROTOCOL, 0x0201); } }

        public static UInt32 DEVICE_UNIT { get { return AttrValue(SCARD_CLASS_SYSTEM, 0x0001); } }
        public static UInt32 DEVICE_FRIENDLY_NAME { get { return AttrValue(SCARD_CLASS_SYSTEM, 0x0003); } }
        public UInt32 DEVICE_SYSTEM_NAME { get { return AttrValue(SCARD_CLASS_SYSTEM, 0x0004); } }

        public static UInt32 ICC_PRESENCE { get { return AttrValue(SCARD_CLASS_ICC_STATE, 0x0300); } }
        public static UInt32 ICC_INTERFACE_STATUS { get { return AttrValue(SCARD_CLASS_ICC_STATE, 0x0301); } }
        public static UInt32 ATR_STRING { get { return AttrValue(SCARD_CLASS_ICC_STATE, 0x0303); } }
        public static UInt32 ICC_TYPE_PER_ATR { get { return AttrValue(SCARD_CLASS_ICC_STATE, 0x0304); } }

        public static UInt32 PROTOCOL_TYPES { get { return AttrValue(SCARD_CLASS_PROTOCOL, 0x0120); } }

        public static UInt32 VENDOR_NAME { get { return AttrValue(SCARD_CLASS_VENDOR_DEFINED, 0x0100); } }
        public static UInt32 VENDOR_IFD_TYPE { get { return AttrValue(SCARD_CLASS_VENDOR_DEFINED, 0x0101); } }
        public static UInt32 VENDOR_IFD_VERSION { get { return AttrValue(SCARD_CLASS_VENDOR_DEFINED, 0x0102); } }
        public static UInt32 VENDOR_IFD_SERIAL_NO { get { return AttrValue(SCARD_CLASS_VENDOR_DEFINED, 0x0103); } }
    }
}
