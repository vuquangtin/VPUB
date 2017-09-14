using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sAccessControl.Device.Reader.Pcsc
{
    /// <summary>
    /// CARD_STATE enumeration, used by the PC/SC function SCardGetStatusChanged
    /// </summary>
    enum CARD_STATE
    {
        UNAWARE = 0x00000000,
        IGNORE = 0x00000001,
        CHANGED = 0x00000002,
        UNKNOWN = 0x00000004,
        UNAVAILABLE = 0x00000008,
        EMPTY = 0x00000010,
        PRESENT = 0x00000020,
        ATRMATCH = 0x00000040,
        EXCLUSIVE = 0x00000080,
        INUSE = 0x00000100,
        MUTE = 0x00000200,
        UNPOWERED = 0x00000400
    }

    /// <summary>
    /// DISCONNECT action enumeration
    /// </summary>
    public enum DISCONNECT
    {
        /// <summary>
        /// Don't do anything special on close
        /// </summary>
        LEAVE,

        /// <summary>
        /// Reset the card on close
        /// </summary>
        RESET,

        /// <summary>
        /// Power down the card on close
        /// </summary>
        UNPOWER,

        /// <summary>
        /// Eject(!) the card on close
        /// </summary>
        EJECT
    }

    public enum PROTOCOL
    {
        /// <summary>
        /// There is no active protocol.
        /// </summary>
        UNDEFINED = 0x00000000,

        /// <summary>
        /// T=0 is the active protocol.
        /// </summary>
        T0 = 0x00000001,

        /// <summary>
        /// T=1 is the active protocol.
        /// </summary>
        T1 = 0x00000002,

        /// <summary>
        /// Raw is the active protocol.
        /// </summary>
        Raw = 0x00010000,

        DEFAULT = unchecked((int)0x80000000),  // Use implicit PTS.

        /// <summary>
        /// T=1 or T=0 can be the active protocol
        /// </summary>
        T0_OR_T1 = T0 | T1
    }

    public class SCardReturnValue
    {
        public const uint SCARD_S_SUCCESS = 0x0;
        public const uint SCARD_E_NO_READERS_AVAILABLE = 0x8010002E;
    }

    public enum SCOPE
    {
        /// <summary>
        /// The context is a user context, and any database operations are performed within the
        /// domain of the user.
        /// </summary>
        USER,

        /// <summary>
        /// The context is that of the current terminal, and any database operations are performed
        /// within the domain of that terminal.  (The calling application must have appropriate
        /// access permissions for any database actions.)
        /// </summary>
        TERMINAL,

        /// <summary>
        /// The context is the system context, and any database operations are performed within the
        /// domain of the system.  (The calling application must have appropriate access
        /// permissions for any database actions.)
        /// </summary>
        SYSTEM
    }

    public enum SHARE_MODE
    {
        /// <summary>
        /// This application is not willing to share this card with other applications.
        /// </summary>
        EXCLUSIVE = 1,

        /// <summary>
        /// This application is willing to share this card with other applications.
        /// </summary>
        SHARED,

        /// <summary>
        /// This application demands direct control of the reader, so it is not available to other applications.
        /// </summary>
        DIRECT
    }
}
