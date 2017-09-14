using sAccessControl.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace sAccessControl.Config
{
    public class LocalConfigsManager
    {
        private static LocalConfigsManager instance = new LocalConfigsManager();
        private Configuration configs = null;

        #region Config keys

        public const string Key_Camera_CachingTime = "Camera_CachingTime";

        #endregion

        #region Config default values

        public const int Def_Camera_CachingTime = 1000;

        #endregion

        #region Config limiting values

        public const int Min_Camera_CachingTime = 0;
        public const int Max_Camera_CachingTime = 2000;

        #endregion

        private LocalConfigsManager()
        {
            configs = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }

        public static LocalConfigsManager Instance
        {
            get
            {
                return instance;
            }
        }

        public int CameraCachingTime
        {
            get
            {
                string cfgVal = configs.AppSettings.Settings[Key_Camera_CachingTime].Value;
                int result;

                if (int.TryParse(cfgVal, out result))
                {
                    if (result >= Min_Camera_CachingTime && result <= Max_Camera_CachingTime)
                    {
                        return result;
                    }
                }

                return Def_Camera_CachingTime;
            }
            set
            {
                if (value < Min_Camera_CachingTime || value > Max_Camera_CachingTime)
                {
                    return;
                }

                string newVal = value.ToString();
                string curVal = configs.AppSettings.Settings[Key_Camera_CachingTime].Value;

                if (curVal == null || !curVal.Equals(newVal, StringComparison.CurrentCultureIgnoreCase))
                {
                    configs.AppSettings.Settings[Key_Camera_CachingTime].Value = newVal;
                }
            }
        }

        /// <summary>
        /// Khi "start without debugging" thì mới lưu được vào file config.
        /// </summary>
        public void Save()
        {
            configs.Save(ConfigurationSaveMode.Full);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
