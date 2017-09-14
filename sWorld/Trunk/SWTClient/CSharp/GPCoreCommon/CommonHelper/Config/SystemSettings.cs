using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace CommonHelper.Config
{
    public class SystemSettings : ConfigurationSection
    {
        private static SystemSettings instance = null;
        private static String spath;

        private SystemSettings() {
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
            if (config.Sections["systemConfig"] == null)
            {
                instance = new SystemSettings();
                config.Sections.Add("systemConfig", instance);
                config.Save(ConfigurationSaveMode.Modified);
            }
            else
            {
                instance = (SystemSettings)config.Sections["systemConfig"];
            }
        }
        public static SystemSettings Instance
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
            SystemSettings section = (SystemSettings)config.Sections["systemConfig"];

            section.Master = this.Master;
            section.Partner = this.Partner;
            section.JavaWebService = this.JavaWebService;
            section.Languages = this.Languages;

            config.Save(ConfigurationSaveMode.Full);
            readSetting();
        }

        [ConfigurationProperty("Master", DefaultValue = "", IsRequired = true)]
        [StringValidator(InvalidCharacters = "", MinLength = 0, MaxLength = 255)]
        public  String Master
        {
            get
            {
                return (String)this["Master"];
            }
            set
            {
                this["Master"] = value;
            }
        }

        [ConfigurationProperty("Partner", DefaultValue = "", IsRequired = true)]
        [StringValidator(InvalidCharacters = "", MinLength = 0, MaxLength = 255)]
        public  String Partner
        {
            get
            {
                return (string)this["Partner"];
            }
            set
            {
                this["Partner"] = value;
            }
        }

        [ConfigurationProperty("OrgCode", DefaultValue = "", IsRequired = false)]
        [StringValidator(InvalidCharacters = "", MinLength = 0, MaxLength = 255)]
        public String OrgCode
        {
            get
            {
                return (string)this["OrgCode"];
            }
            set
            {
                this["OrgCode"] = value;
            }
        }

        [ConfigurationProperty("TypeComm", DefaultValue = "", IsRequired = true)]
        [StringValidator(InvalidCharacters = "", MinLength = 0, MaxLength = 255)]
        public  String TypeComm
        {
            get
            {
                return (String)this["TypeComm"];
            }
            set
            {
                this["TypeComm"] = value;
            }
        }

        [ConfigurationProperty("JavaWebService", DefaultValue = "", IsRequired = true)]
        [StringValidator(InvalidCharacters = "", MinLength = 0, MaxLength = 255)]
        public String JavaWebService
        {
            get
            {
                return (String)this["JavaWebService"];
            }
            set
            {
                this["JavaWebService"] = value;
            }
        }

        [ConfigurationProperty("Languages", DefaultValue = "", IsRequired = true)]
        [StringValidator(InvalidCharacters = "", MinLength = 0, MaxLength = 255)]
        public String Languages
        {
            get
            {
                return (String)this["Languages"];
            }
            set
            {
                this["Languages"] = value;
            }
        }
    }
}
