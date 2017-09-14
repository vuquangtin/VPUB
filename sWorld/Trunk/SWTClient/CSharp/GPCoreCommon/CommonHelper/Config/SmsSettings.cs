using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace CommonHelper.Config
{
    public class SmsSettings : ConfigurationSection
    {
        private static SmsSettings instance = null;
        private static String spath;

        private SmsSettings() {
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
            if (config.Sections["smsConfig"] == null)
            {
                instance = new SmsSettings();
                config.Sections.Add("smsConfig", instance);
                config.Save(ConfigurationSaveMode.Modified);
            }
            else
            {
                instance = (SmsSettings)config.Sections["smsConfig"];
            }
        }
        public static SmsSettings Instance
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
            SmsSettings section = (SmsSettings)config.Sections["smsConfig"];

            section.Account = this.Account;
            section.CodeAPI = this.CodeAPI;
            section.From = this.From;
            section.SMSService = this.SMSService;

            config.Save(ConfigurationSaveMode.Full);
        }

        [ConfigurationProperty("Type1", DefaultValue = "", IsRequired = true)]
        [StringValidator(InvalidCharacters = "", MinLength = 0, MaxLength = 255)]
        public String Account
        {
            get
            {
                return (String)this["Type1"];
            }
            set
            {
                this["Type1"] = value;
            }
        }

        [ConfigurationProperty("Type2", DefaultValue = "", IsRequired = true)]
        [StringValidator(InvalidCharacters = "", MinLength = 0, MaxLength = 255)]
        public String CodeAPI
        {
            get
            {
                return (string)this["Type2"];
            }
            set
            {
                this["Type2"] = value;
            }
        }

        [ConfigurationProperty("Type3", DefaultValue = "", IsRequired = true)]
        [StringValidator(InvalidCharacters = "", MinLength = 0, MaxLength = 255)]
        public String From
        {
            get
            {
                return (String)this["Type3"];
            }
            set
            {
                this["Type3"] = value;
            }
        }

        [ConfigurationProperty("SMSService", DefaultValue = "", IsRequired = true)]
        [StringValidator(InvalidCharacters = "", MinLength = 0, MaxLength = 255)]
        public String SMSService
        {
            get
            {
                return (String)this["SMSService"];
            }
            set
            {
                this["SMSService"] = value;
            }
        }
    }
}
