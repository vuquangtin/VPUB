using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CampusModel.Model
{
    public enum CardType : int
    {
        MF_1K = 1,
        MF_1K_CN = -120,
        MF_4K = 2,
    }

    public static class CardTypeExtMethod
    {
        public static List<CardType> GetCardTypeList()
        {
            return Enum.GetValues(typeof(CardType)).Cast<CardType>().ToList();
        }

        public static CardType ToCardType(int intValue)
        {
            return (CardType)intValue;
        }

        public static string GetName(this CardType type)
        {
            switch (type)
            {
                case CardType.MF_1K_CN:
                    return "Mifare Classic 1K (CN)";
                case CardType.MF_1K:
                    return "Mifare Classic 1K";
                case CardType.MF_4K:
                    return "Mifare Classic 4K";
                default:
                    return "N/A";
            }
        }
    }
}
