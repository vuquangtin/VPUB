using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace CommonHelper.Config
{
    public class GroupSettings : ConfigurationSection
    {
        private static GroupSettings instance = null;
        private static String spath;

        private GroupSettings()
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
            if (config.Sections["groupConfig"] == null)
            {
                instance = new GroupSettings();
                config.Sections.Add("groupConfig", instance);
                config.Save(ConfigurationSaveMode.Modified);
            }
            else
            {
                instance = (GroupSettings)config.Sections["groupConfig"];
            }
        }
        public static GroupSettings Instance
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
            GroupSettings section = (GroupSettings)config.Sections["groupConfig"];

            section.Group = this.Group;
            section.MemberContact = this.MemberContact;

            config.Save(ConfigurationSaveMode.Full);
        }

        [ConfigurationProperty("Group", DefaultValue = "", IsRequired = true)]
        [StringValidator(InvalidCharacters = "", MinLength = 0, MaxLength = 255)]
        public String Group
        {
            get
            {
                return (String)this["Group"];
            }
            set
            {
                this["Group"] = value;
            }
        }

        [ConfigurationProperty("MemberContact", DefaultValue = "", IsRequired = true)]
        [StringValidator(InvalidCharacters = "", MinLength = 0, MaxLength = 255)]
        public String MemberContact
        {
            get
            {
                return (String)this["MemberContact"];
            }
            set
            {
                this["MemberContact"] = value;
            }
        }
    }
}
