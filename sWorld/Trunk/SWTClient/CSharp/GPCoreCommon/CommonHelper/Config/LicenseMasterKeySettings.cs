using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CommonHelper.Config
{
    public class LicenseMasterKeySettings : ConfigurationSection
    {
        private static LicenseMasterKeySettings instance = null;
        private static String spath;

        private LicenseMasterKeySettings()
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
            if (config.Sections["KeyMaster"] == null)
            {
                instance = new LicenseMasterKeySettings();
                config.Sections.Add("KeyMaster", instance);
                config.Save(ConfigurationSaveMode.Modified);
            }
            else
            {
                instance = (LicenseMasterKeySettings)config.Sections["KeyMaster"];
            }
        }
        public static LicenseMasterKeySettings Instance
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
            LicenseMasterKeySettings section = (LicenseMasterKeySettings)config.Sections["KeyMaster"];

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
