using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CommonHelper.Config
{
    public class MasterServerKeySettings : ConfigurationSection
    {
        private static MasterServerKeySettings instance = null;
        private static String spath;

        private MasterServerKeySettings()
        {
        }

        private static void readSetting()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetEntryAssembly();
            spath = assembly.Location;

            if (spath.EndsWith(".config", StringComparison.InvariantCultureIgnoreCase))
            {
                spath = spath.Remove(spath.Length - 7);
            }

            Configuration config = ConfigurationManager.OpenExeConfiguration(spath);
            if (config.Sections["MasterServerKey"] == null)
            {
                instance = new MasterServerKeySettings();
                config.Sections.Add("MasterServerKey", instance);
                config.Save(ConfigurationSaveMode.Modified);
            }
            else
            {
                instance = (MasterServerKeySettings)config.Sections["MasterServerKey"];
            }
        }
        public static MasterServerKeySettings Instance
        {
            get
            {
                if (null == instance)
                    readSetting();

                return instance;
            }
        }

        public void Save()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(spath);
            MasterServerKeySettings section = (MasterServerKeySettings)config.Sections["MasterServerKey"];

            section.Modulus = this.Modulus;
            section.Exponent = this.Exponent;

            config.Save(ConfigurationSaveMode.Full);
        }

        [ConfigurationProperty("Modulus", DefaultValue = "", IsRequired = true)]
        [StringValidator(InvalidCharacters = "", MinLength = 0, MaxLength = 2000)]
        public String Modulus
        {
            get
            {
                return (String)this["Modulus"];
            }
            set
            {
                this["Modulus"] = value;
            }
        }

        [ConfigurationProperty("Exponent", DefaultValue = "", IsRequired = true)]
        [StringValidator(InvalidCharacters = "", MinLength = 0, MaxLength = 2000)]
        public String Exponent
        {
            get
            {
                return (String)this["Exponent"];
            }
            set
            {
                this["Exponent"] = value;
            }
        }
    }
}
