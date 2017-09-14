namespace ReaderLibrary
{
    public class SworldMifareClassicParams
    {
        public const int BLOCK_SIZE = 16;
        public const int SECTOR_DATA_SIZE = 48;
        public const int MANIFEACURE_DATA_LENGHT = 16;
        public const int BASIC_METADTA_LENGTH = 12;
        public const int LICENSE_LENGTH = 128; // 48*3 - 16
        public static int SECTOR_SIZE;

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
