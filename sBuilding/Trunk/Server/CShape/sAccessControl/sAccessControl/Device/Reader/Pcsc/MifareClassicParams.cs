using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sAccessControl.Device.Reader.Pcsc
{
    public class MifareClassicParams
    {
        public const int BLOCK_SIZE = 16;
        public const int SECTOR_DATA_SIZE = 48;
        public const int HEADER_POSITION = 3;
        public const int BASIC_METADTA_LENGTH = 12;
        public const int LICENSE_LENGTH = 128;
        public const int SECTOR_SIZE = 48;

        public static int DetermineDataSectorCapacity(byte sectorNumber)
        {
            if (sectorNumber == 0)
            {
                return 32;
            }
            else if (sectorNumber <= 31)
            {
                return 48;
            }
            else
            {
                return 240;
            }
        }
    }
}
