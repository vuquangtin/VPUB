using System;
using System.Collections.Generic;
using System.Xml;

namespace CommonHelper.Language
{
    public class LanguageUtils
    {
        #region Private properties

        private SupportedLanguage DEFAULT_LANG = SupportedLanguage.VI;
        private Dictionary<string, string> data = new Dictionary<string, string>();
        private const string LANG_DIR_PATH = "/Lang/";
        private static LanguageUtils instance = null;

        #endregion

        #region Private constructor

        private LanguageUtils()
        {
            //Doc file config, lay ra cau hinh ngon ngu
            SupportedLanguage config = LoadLanguageConfig();

            //Neu config khac voi mac dinh thi goi den file config
            //tuong ung de load du lieu
            if (config != DEFAULT_LANG)
            {
                DEFAULT_LANG = config;
                LoadLanguageData(DEFAULT_LANG);
            }
        }

        #endregion

        #region Private methods

        private SupportedLanguage LoadLanguageConfig()
        {
            //Goi den file cau hinh de load cau hinh ngon ngu ma nguoi dung
            //da chon
            return SupportedLanguage.EN;
        }

        private void LoadLanguageData(SupportedLanguage lang)
        {
            //Lay ra duong dan file chua ngon ngu can chuyen
            string path = System.Windows.Forms.Application.StartupPath
                + LANG_DIR_PATH + SupportedLanguage.EN.ToString() + ".xml";

            //Doc file xml va parse du lieu,
            ParseLanguageXmlFile(path);
        }

        private void ParseLanguageXmlFile(string path)
        {
            // Load file XML
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            // Lấy ra các controls trong ControlList
            XmlNodeList controlList = doc.SelectNodes("ControlList/Control");
            data.Clear();

            //Duyệt để lấy ra node trong control gán vao data
            foreach (XmlNode control in controlList)
            {
                data.Add(control.SelectSingleNode("Id").InnerText,
                    control.SelectSingleNode("Name").InnerText);
            }
        }

        #endregion

        #region Public methods

        public static LanguageUtils GetInstance()
        {
            if (instance == null)
            {
                instance = new LanguageUtils();
            }
            return instance;
        }

        public string GetControlText(string controlId)
        {
            if (data == null)
            {
                throw new ArgumentNullException(controlId);
            }
            else
            {
                if (data.ContainsKey(controlId))
                {
                    return data[controlId];
                }
                else
                {
                    throw new ArgumentNullException(controlId);
                }
            }
        }

        #endregion
    }
}
