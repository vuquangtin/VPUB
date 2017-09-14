using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace sAccessControl.Config
{
    public class AccessMessageServiceConfigSection : ConfigurationSection
    {
        private static AccessMessageServiceConfigSection instance = null;
        private static String spath;

        private AccessMessageServiceConfigSection() {
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
            if (config.Sections["accessMessageConfig"] == null)
            {
                instance = new AccessMessageServiceConfigSection();
                config.Sections.Add("accessMessageConfig", instance);
                config.Save(ConfigurationSaveMode.Modified);
            }
            else
            {
                instance = (AccessMessageServiceConfigSection)config.Sections["accessMessageConfig"];
            }
        }
        public static AccessMessageServiceConfigSection Instance
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
            AccessMessageServiceConfigSection section = (AccessMessageServiceConfigSection)config.Sections["accessMessageConfig"];

            section.Ip = this.Ip;
            section.Port = this.Port;

            config.Save(ConfigurationSaveMode.Full);
        }

        [ConfigurationProperty("Ip", DefaultValue = "", IsRequired = true)]
        [StringValidator(InvalidCharacters = "", MinLength = 0, MaxLength = 255)]
        public String Ip
        {
            get
            {
                return (String)this["Ip"];
            }
            set
            {
                this["Ip"] = value;
            }
        }

        [ConfigurationProperty("Port", DefaultValue = "", IsRequired = true)]
        [StringValidator(InvalidCharacters = "", MinLength = 0, MaxLength = 255)]
        public String Port
        {
            get
            {
                return (string)this["Port"];
            }
            set
            {
                this["Port"] = value;
            }
        }
    }
}
