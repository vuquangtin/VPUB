using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace CommonHelper.Config
{
    public class MemberTitle : ConfigurationSection
    {
        private static MemberTitle instance = null;
        private static String spath;

        private MemberTitle()
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
            if (config.Sections["MemberTitle"] == null)
            {
                instance = new MemberTitle();
                config.Sections.Add("MemberTitle", instance);
                config.Save(ConfigurationSaveMode.Modified);
            }
            else
            {
                instance = (MemberTitle)config.Sections["MemberTitle"];
            }
        }
        public static MemberTitle Instance
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
            MemberTitle section = (MemberTitle)config.Sections["MemberTitle"];

            section.Values = this.Values;

            config.Save(ConfigurationSaveMode.Full);
        }

        [ConfigurationProperty("Values", DefaultValue = "")]
        [StringValidator(InvalidCharacters = "", MinLength = 0, MaxLength = 255)]
        public String Values
        {
            get
            {
                return (String)this["Values"];
            }
            set
            {
                this["Values"] = value;
            }
        }
    }
}
