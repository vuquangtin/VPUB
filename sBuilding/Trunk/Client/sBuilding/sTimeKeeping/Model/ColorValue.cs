using CommonHelper.Utils;
using System.Resources;

namespace sTimeKeeping.Model {
    // Quy định màu
    public enum ColorValueName : long {
        red = 1,
        pink = 2,
        purple = 3,
        deep_purple = 4,
        indigo = 5,
        blue = 6,
        cyan = 7,
        teal = 8,
        green = 9,
        yellow = 10,
        amber = 11,
        orange = 12,
        deep_orange = 13,
        brown = 14,
        white = 15,
        black
    }
    class ColorValue {
        public static string getColorValue(ColorValueName colorId) {
            switch (colorId) {
                case ColorValueName.red:
                    return "#F44336";
                case ColorValueName.pink:
                    return "#E91E63";
                case ColorValueName.purple:
                    return "#9C27B0";
                case ColorValueName.deep_purple:
                    return "#673AB7";
                case ColorValueName.indigo:
                    return "#3F51B5";
                case ColorValueName.blue:
                    return "#2196F3";
                case ColorValueName.cyan:
                    return "#00BCD4";
                case ColorValueName.teal:
                    return "#009688";
                case ColorValueName.green:
                    return "#4CAF50";
                case ColorValueName.yellow:
                    return "#FFEB3B";
                case ColorValueName.amber:
                    return "#FFC107";
                case ColorValueName.orange:
                    return "#FF9800";
                case ColorValueName.deep_orange:
                    return "#FF5722";
                case ColorValueName.brown:
                    return "#795548";
                case ColorValueName.white:
                    return "#FFFFFF";
                case ColorValueName.black:
                    return "#000000";
                default:
                    return "#FFFFFF";
            }
        }

        public static string getColorName(ColorValueName colorId, ResourceManager rm) {
            switch (colorId) {
                case ColorValueName.red:
                    return getLanguage("red", rm);
                case ColorValueName.pink:
                    return getLanguage("pink", rm);
                case ColorValueName.purple:
                    return getLanguage("purple", rm);
                case ColorValueName.deep_purple:
                    return getLanguage("deep_purple", rm);
                case ColorValueName.indigo:
                    return getLanguage("indigo", rm);
                case ColorValueName.blue:
                    return getLanguage("blue", rm);
                case ColorValueName.cyan:
                    return getLanguage("cyan", rm);
                case ColorValueName.teal:
                    return getLanguage("teal", rm);
                case ColorValueName.green:
                    return getLanguage("green", rm);
                case ColorValueName.yellow:
                    return getLanguage("yellow", rm);
                case ColorValueName.amber:
                    return getLanguage("amber", rm);
                case ColorValueName.orange:
                    return getLanguage("orange", rm);
                case ColorValueName.deep_orange:
                    return getLanguage("deep_orange", rm);
                case ColorValueName.brown:
                    return getLanguage("brown", rm);
                case ColorValueName.white:
                    return getLanguage("white", rm);
                default:
                    return getLanguage("white", rm);
            }
        }

        public static string getLanguage(string key, ResourceManager rm) {
            string strValue = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, key);
            return strValue;
        }
    }
}
