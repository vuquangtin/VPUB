using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sAccessControl.Enums
{
    internal enum DeviceState
    {
        NotUsed,
        Connecting,
        Connected,
        Disconnected,
        DisconnectedByUser,
        IncorrectConfig,
    }
}
