using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CommonHelper.Config
{
    public class LicensePartnerKeySettings : ConfigurationSection
    {
        private static LicensePartnerKeySettings instance = null;
        private static String spath;

        private LicensePartnerKeySettings()
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
            if (config.Sections["KeyPartner"] == null)
            {
                instance = new LicensePartnerKeySettings();
                config.Sections.Add("KeyPartner", instance);
                config.Save(ConfigurationSaveMode.Modified);
            }
            else
            {
                instance = (LicensePartnerKeySettings)config.Sections["KeyPartner"];
            }
        }
        public static LicensePartnerKeySettings Instance
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
            LicensePartnerKeySettings section = (LicensePartnerKeySettings)config.Sections["KeyPartner"];

            section.Modulus = this.Modulus;
            section.Exponent = this.Exponent;
            section.ValueKey = this.ValueKey;

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

        [ConfigurationProperty("ValueKey", DefaultValue = "", IsRequired = true)]
        [StringValidator(InvalidCharacters = "", MinLength = 0, MaxLength = 2000)]
        public String ValueKey
        {
            get
            {
                return (String)this["ValueKey"];
            }
            set
            {
                this["ValueKey"] = value;
            }
        }
    }
}
