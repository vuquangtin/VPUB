using CommonHelper.Config;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Windows.Forms;

namespace CommonHelper.Utils
{
    public class ResoucreLanguagesUtils
    {
        private static ResoucreLanguagesUtils instance = new ResoucreLanguagesUtils();
        public static ResoucreLanguagesUtils Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ResoucreLanguagesUtils();
                }
                return instance;
            }
        }

        private CultureInfo culture;

        public ResoucreLanguagesUtils()
        {
            culture = new CultureInfo(SystemSettings.Instance.Languages);
        }

        public void SetResoucreLanguages(Control.ControlCollection controlList, ResourceManager rm)
        {
            foreach (Control c in controlList)
            {
                try
                {
                    c.Text = rm.GetString(c.Name, culture);
                }
                catch (Exception ex)
                {

                }

                if (c.Controls != null && c.Controls.Count > 0)
                    SetResoucreLanguages(c.Controls, rm);
            }
        }

        public string GetResoucreLanguages(ResourceManager rm, string keyName) 
        {
            try 
            {
                return rm.GetString(keyName, culture);
            }
            catch(Exception ex)
            {
                return "LanguagesError";
            }
        }
        public void Refresh()
        {
            culture = new CultureInfo(SystemSettings.Instance.Languages);
        }
    }
}
