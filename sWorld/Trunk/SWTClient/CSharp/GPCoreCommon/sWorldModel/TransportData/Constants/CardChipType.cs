using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sWorldModel.TransportData
{
    public enum CardChipType : int
    {
        MF_1K = 1,
        MF_1K_CN = -120,
        MF_4K = 2,
        DESFIRE = 3
    }

    public static class CardTypeExtMethod
    {
        public static List<CardChipType> GetCardTypeList()
        {
            return Enum.GetValues(typeof(CardChipType)).Cast<CardChipType>().ToList();
        }

        public static CardChipType ToCardType(int intValue)
        {
            return (CardChipType)intValue;
        }

        public static string GetName(this CardChipType type)
        {
            switch (type)
            {
                case CardChipType.MF_1K_CN:
                    return "Mifare Classic 1K (CN)";
                case CardChipType.MF_1K:
                    return "Mifare Classic 1K";
                case CardChipType.MF_4K:
                    return "Mifare Classic 4K";
                case CardChipType.DESFIRE:
                    return "Desfire";
                default:
                    return "N/A";
            }
        }
    }
}
