using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace CommonHelper.Config
{
    public class ReaderSettings : ConfigurationSection
    {
        private static ReaderSettings instance = null;
        private static String spath = string.Empty;

        private ReaderSettings()
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
            if (config.Sections["readerConfig"] == null)
            {
                instance = new ReaderSettings();
                config.Sections.Add("readerConfig", instance);
                config.Save(ConfigurationSaveMode.Modified);
            }
            else
            {
                instance = (ReaderSettings)config.Sections["readerConfig"];
            }
        }
        public static ReaderSettings Instance
        {
            get
            {
                if (null == instance)
                    readSetting();

                return instance;
            }
            set { }
        }

        public void Save()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(spath);
            ReaderSettings section = (ReaderSettings)config.Sections["readerConfig"];

            section.Type = this.Type;
            section.Address = this.Address;
            section.BeepOnTag = this.BeepOnTag;
            section.MCRPort = this.MCRPort;

            config.Save(ConfigurationSaveMode.Full);
        }

        [ConfigurationProperty("type", IsRequired = true)]
        [IntegerValidator()]
        public int Type
        {
            get
            {
                return (int)this["type"];
            }
            set
            {
                if ((int)this["type"] != value)
                {
                    this["type"] = value;
                }
            }
        }

        [ConfigurationProperty("address", IsRequired = true)]
        [IntegerValidator()]
        public int Address
        {
            get
            {
                return (int)this["address"];
            }
            set
            {
                if ((int)this["address"] != value)
                {
                    this["address"] = value;
                }
            }
        }

        [ConfigurationProperty("beep_on_tag", DefaultValue = "YES", IsRequired = true)]
        [RegexStringValidator("^(Yes|yEs|yeS|YEs|YeS|yES|YES|yes|No|NO|no)$")]
        private string BeepOnTag
        {
            get
            {
                return this["beep_on_tag"].ToString();
            }
            set
            {
                this["beep_on_tag"] = value;
            }
        }

        public bool BeepOnTagDetected
        {
            get
            {
                return BeepOnTag.ToUpper().Equals("YES");
            }
            set
            {
                string temp = value ? "YES" : "NO";
                if (!temp.Equals(BeepOnTag))
                {
                    BeepOnTag = temp;
                }
            }
        }

        [ConfigurationProperty("MCRPort", DefaultValue = 0, IsRequired = true)]
        [IntegerValidator(MinValue = 0)]
        public int MCRPort
        {
            get
            {
                return (int)this["MCRPort"];
            }
            set
            {
                this["MCRPort"] = value;
            }
        }
    }
}
