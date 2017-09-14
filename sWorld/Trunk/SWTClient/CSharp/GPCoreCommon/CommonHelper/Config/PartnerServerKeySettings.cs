using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CommonHelper.Config
{
    public class PartnerServerKeySettings : ConfigurationSection
    {
        private static PartnerServerKeySettings instance = null;
        private static String spath;

        private PartnerServerKeySettings()
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
            if (config.Sections["PartnerServerKey"] == null)
            {
                instance = new PartnerServerKeySettings();
                config.Sections.Add("PartnerServerKey", instance);
                config.Save(ConfigurationSaveMode.Modified);
            }
            else
            {
                instance = (PartnerServerKeySettings)config.Sections["PartnerServerKey"];
            }
        }

        public static PartnerServerKeySettings Instance
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
            PartnerServerKeySettings section = (PartnerServerKeySettings)config.Sections["PartnerServerKey"];

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
