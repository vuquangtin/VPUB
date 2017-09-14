﻿using System.Text;

namespace CommonHelper.Utils
{
    public class EncodingUtils
    {
        public static string UnicodeToVni(string unicodeText)
        {
            StringBuilder result = new StringBuilder(unicodeText);

            int[] ascii = new int[] 
            {
                7845, 7847, 7849, 7851, 7853, 226, 225, 224, 7843, 227,
                7841, 7855, 7857, 7859, 7861, 7863, 259, 250, 249, 7911,
                361, 7909, 7913, 7915, 7917, 7919, 7921, 432, 7871, 7873,
                7875, 7877, 7879, 234, 233, 232, 7867, 7869, 7865, 7889,
                7891, 7893, 7895, 7897, 244, 243, 242, 7887, 245, 7885,
                7899, 7901, 7903, 7905, 7907, 417, 237, 236, 7881, 297,
                7883, 253, 7923, 7927, 7929, 7925, 273, 7844, 7846, 7848,
                7850, 7852, 194, 193, 192, 7842, 195, 7840, 7854, 7856,
                7858, 7860, 7862, 258, 218, 217, 7910, 360, 7908, 7912,
                7914, 7916, 7918, 7920, 431, 7870, 7872, 7874, 7876, 7878,
                202, 201, 200, 7866, 7868, 7864, 7888, 7890, 7892, 7894,
                7896, 212, 211, 210, 7886, 213, 7884, 7898, 7900, 7902,
                7904, 7906, 416, 205, 204, 7880, 296, 7882, 221, 7922,
                7926, 7928, 7924, 272
            };

            string[] vni = new string[]
            {
                "aá", "aà", "aå", "aã", "aä", "aâ", "aù", "aø", "aû", "aõ",
                "aï", "aé", "aè", "aú", "aü", "aë", "aê", "uù", "uø", "uû",
                "uõ", "uï", "öù", "öø", "öû", "öõ", "öï", "ö", "eá", "eà",
                "eå", "eã", "eä", "eâ", "eù", "eø", "eû", "eõ", "eï", "oá",
                "oà", "oå", "oã", "oä", "oâ", "où", "oø", "oû", "oõ", "oï",
                "ôù", "ôø", "ôû", "ôõ", "ôï", "ô", "í", "ì", "æ", "ó",
                "ò", "yù", "yø", "yû", "yõ", "î", "ñ", "AÁ", "AÀ", "AÅ",
                "AÃ", "AÄ", "AÂ", "AÙ", "AØ", "AÛ", "AÕ", "AÏ", "AÉ", "AÈ",
                "AÚ", "AÜ", "AË", "AÊ", "UÙ", "UØ", "UÛ", "UÕ", "UÏ", "ÖÙ",
                "ÖØ", "ÖÛ", "ÖÕ", "ÖÏ", "Ö", "EÁ", "EÀ", "EÅ", "EÃ", "EÄ",
                "EÂ", "EÙ", "EØ", "EÛ", "EÕ", "EÏ", "OÁ", "OÀ", "OÅ", "OÃ",
                "OÄ", "OÂ", "OÙ", "OØ", "OÛ", "OÕ", "OÏ", "ÔÙ", "ÔØ", "ÔÛ",
                "ÔÕ", "ÔÏ", "Ô", "Í", "Ì", "Æ", "Ó", "Ò", "YÙ", "YØ",
                "YÛ", "YÕ", "Î", "Ñ"
            };

            string[] err = new string[]
            {
                "aauø", "aaø", "aaoõ", "auø", "aoõ", "aeù", "aeø", "auuø", "aeâ", "uuø",
                "uoõ", "öoõ", "eoõ", "AAUØ", "AAØ", "AAOÕ", "AUØ", "AOÕ", "AEÙ", "AEØ",
                "AUUØ", "AEÂ", "UUØ", "UOÕ", "ÖOÕ", "EOÕ"
            };

            string[] fix = new string[]
            {
                "aá", "aà", "aã", "aù", "aõ", "aé", "aè", "aú", "aê", "uù",
                "uõ", "öõ", "eõ", "AÁ", "AÀ", "AÃ", "AÙ", "AÕ", "AÉ", "AÈ",
                "AÚ", "AÊ", "UÙ", "UÕ", "ÖÕ", "EÕ"
            };

            for (int i = 0; i <= 133; i++)
            {
                result = result.Replace(char.ConvertFromUtf32(ascii[i]), vni[i]);
            }

            for (int i = 0; i <= 25; i++)
            {
                result = result.Replace(err[i], fix[i]);
            }
            return result.ToString();
        }

        public static string VniToUnicode(string vniText)
        {
            int[] ascii = new int[]
            {
                7845, 7847, 7849, 7851, 7853, 226, 7843, 227, 7841, 7855,
                7857, 7859, 7861, 7863, 259, 250, 249, 7911, 361, 7909,
                7913, 7915, 7917, 7919, 7921, 432, 7871, 7873, 7875, 7877,
                7879, 234, 233, 232, 7867, 7869, 7865, 7889, 7891, 7893,
                7895, 7897, 7887, 245, 7885, 7899, 7901, 7903, 7905, 7907,
                417, 237, 236, 7881, 297, 7883, 253, 7923, 7927, 7929,
                7925, 273, 7844, 7846, 7848, 7850, 7852, 194, 7842, 195,
                7840, 7854, 7856, 7858, 7860, 7862, 258, 218, 217, 7910,
                360, 7908, 7912, 7914, 7916, 7918, 7920, 431, 7870, 7872,
                7874, 7876, 7878, 202, 201, 200, 7866, 7868, 7864, 7888,
                7890, 7892, 7894, 7896, 7886, 213, 7884, 7898, 7900, 7902,
                7904, 7906, 416, 205, 204, 7880, 296, 7882, 221, 7922,
                7926, 7928, 7924, 272, 225, 224, 244, 243, 242, 193,
                192, 212, 211, 210
            };

            string[] vni = new string[]
            {
                "aá", "aà", "aå", "aã", "aä", "aâ", "aû", "aõ", "aï", "aé",
                "aè", "aú", "aü", "aë", "aê", "uù", "uø", "uû", "uõ", "uï",
                "öù", "öø", "öû", "öõ", "öï", "ö", "eá", "eà", "eå", "eã",
                "eä", "eâ", "eù", "eø", "eû", "eõ", "eï", "oá", "oà", "oå",
                "oã", "oä", "oû", "oõ", "oï", "ôù", "ôø", "ôû", "ôõ", "ôï",
                "ô", "í", "ì", "æ", "ó", "ò", "yù", "yø", "yû", "yõ",
                "î", "ñ", "AÁ", "AÀ", "AÅ", "AÃ", "AÄ", "AÂ", "AÛ", "AÕ",
                "AÏ", "AÉ", "AÈ", "AÚ", "AÜ", "AË", "AÊ", "UÙ", "UØ", "UÛ",
                "UÕ", "UÏ", "ÖÙ", "ÖØ", "ÖÛ", "ÖÕ", "ÖÏ", "Ö", "EÁ", "EÀ",
                "EÅ", "EÃ", "EÄ", "EÂ", "EÙ", "EØ", "EÛ", "EÕ", "EÏ", "OÁ",
                "OÀ", "OÅ", "OÃ", "OÄ", "OÛ", "OÕ", "OÏ", "ÔÙ", "ÔØ", "ÔÛ",
                "ÔÕ", "ÔÏ", "Ô", "Í", "Ì", "Æ", "Ó", "Ò", "YÙ", "YØ",
                "YÛ", "YÕ", "Î", "Ñ", "aù", "aø", "oâ", "où", "oø", "AÙ",
                "AØ", "OÂ", "OÙ", "OØ"
            };

            string result = vniText;
            for (int i = 0; i <= 133; i++)
            {
                result = result.Replace(vni[i], char.ConvertFromUtf32(ascii[i]));
            }
            return result;
        }
    }
}