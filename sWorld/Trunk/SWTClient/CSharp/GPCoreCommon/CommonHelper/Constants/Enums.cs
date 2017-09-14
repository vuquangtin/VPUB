using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonHelper.Constants
{
    public enum CARD_STATUS
    {
        CARD_HAS_MASTER_READED_ONLY = 100,
        CARD_HAS_MASTER_WRITED_ONLY = 101,
        CARD_HAS_MASTER_PARTNER_READED = 102,
        CARD_HAS_MASTER_PARTNER_WRITE = 103,
        CARD_HAS_DATA_READY = 103,
        CARD_HAS_LOG = 200,
    }

    public enum CARD_TYPE : int
    {
        // Card MF 1K chip NXP
        MF_1K = 1,
        // Card MF 1K chip Trung Quốc
        MF_1K_CN = -120,
        // Card MF 4K chip NXP
        MF_4K = 2,

        //desfire card chip NXP
        DESFIRE_CARD = 3,
        DESFIRE_EV1 = 4,
        DESFIRE_EV2 = 5,


    }

    public enum MAGNETIC_INFOR : int
    {
        DEFULT_VALUE = 1,
        NO_DEFULT = 0,

    }

    public class ART
    {
        public static readonly byte[] DESFIRE_EV = new byte[] { 0x3B, 0x81, 0x80, 0x01, 0x80, 0x80 };
    }

    public enum ACTION_ON_CARD :int
    {
        WRITE_MATER_KEY = 1,
        CLEAR_PERSO_DATA = 2,
        CLEAR_EMPTY_CARD =3,
        READ_DATA =4,
        UPADATE_CARD_DATA =5,
        READ_PERSO_DATA = 6
    }

}
