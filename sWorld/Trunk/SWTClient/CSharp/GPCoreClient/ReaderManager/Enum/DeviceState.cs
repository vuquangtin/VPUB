using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReaderManager.Enum
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

    public enum ACTION_MODE
    {
        WRITE_DATA = 1,
        CLEAR_DATA,
        CLEAR_UP_CARD,
        CLEAR_KEY,
        WRITE_DATA_AND_HEADER,
        WRITE_LICENSE_DATA,
        WRITE_APP_DATA,
        WRITE_KEYA,
        WRITE_KEYB,
        WRITE_KEYA_DEFAULT,
        WRITE_KEYB_DEFAULT,
        READ_DATA,
        WRITE_LICENSE_DATA_TO_DESFIRE,
        CLEAR_APPLICATION_ON_DESFIRE,
        CLEAR_PERSO_ON_DESFIRE,
        CLEAR_ALL_APPLICATION_ON_DESFIRE,
        WRITE_APP_DATA_TO_DESFIRE,
        READ_APPLICATION_DATA_ON_DESFIRE,
        READ_PERSON_DATA_ON_DESFIRE,
        READ_LICENSE_ON_DESFIRE,
        WRITE_SWT_LICENSE_TO_DESFIRE,
        WRITE_PARTNER_LICENSE_TO_DESFIRE,
        READ_HEADER_DATA_ON_DESFIRE,
        WRITE_PERSO_DATA_TO_DESFIRE
    }
    public enum WRITE
    {
      
    }
}
