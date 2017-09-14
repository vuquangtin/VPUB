using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace sAccessControl.Config
{
    public class UserLoginConfigSection : ConfigurationSection
    {
        private static UserLoginConfigSection instance = null;
        private static String spath;

        private UserLoginConfigSection() {
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
            if (config.Sections["loginConfig"] == null)
            {
                instance = new UserLoginConfigSection();
                config.Sections.Add("loginConfig", instance);
                config.Save(ConfigurationSaveMode.Modified);
            }
            else
            {
                instance = (UserLoginConfigSection)config.Sections["loginConfig"];
            }
        }
        public static UserLoginConfigSection Instance
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
            UserLoginConfigSection section = (UserLoginConfigSection)config.Sections["loginConfig"];

            section.User = this.User;
            section.Password = this.Password;

            config.Save(ConfigurationSaveMode.Full);
        }

        [ConfigurationProperty("User", DefaultValue = "", IsRequired = true)]
        [StringValidator(InvalidCharacters = "", MinLength = 0, MaxLength = 255)]
        public  String User
        {
            get
            {
                return (String)this["User"];
            }
            set
            {
                this["User"] = value;
            }
        }

        [ConfigurationProperty("Password", DefaultValue = "", IsRequired = true)]
        [StringValidator(InvalidCharacters = "", MinLength = 0, MaxLength = 255)]
        public String Password
        {
            get
            {
                return (string)this["Password"];
            }
            set
            {
                this["Password"] = value;
            }
        }
        
        [ConfigurationProperty("PortReader", DefaultValue = "", IsRequired = true)]
        [StringValidator(InvalidCharacters = "", MinLength = 0, MaxLength = 255)]
        public String PortReader
        {
            get
            {
                return (string)this["PortReader"];
            }
            set
            {
                this["PortReader"] = value;
            }
        }

        [ConfigurationProperty("Number", DefaultValue = "1", IsRequired = true)]
        [StringValidator(InvalidCharacters = "", MinLength = 0, MaxLength = 255)]
        public string Number
        {
            get
            {
                return (string)this["Number"];
            }
            set
            {
                this["Number"] = value;
            }
        }

        [ConfigurationProperty("TimeOpenDoor", DefaultValue = 0, IsRequired = true)]
        [IntegerValidator(MinValue = 0)]
        public int TimeOpenDoor
        {
            get
            {
                return (int)this["TimeOpenDoor"];
            }
            set
            {
                this["TimeOpenDoor"] = value;
            }
        }
        [ConfigurationProperty("Numberrocess", DefaultValue = 0, IsRequired = true)]
        [IntegerValidator(MinValue = 0)]
        public int Numberrocess
        {
            get
            {
                return (int)this["Numberrocess"];
            }
            set
            {
                this["Numberrocess"] = value;
            }
        }
        [ConfigurationProperty("PortMessage", DefaultValue = "", IsRequired = true)]
        [StringValidator(InvalidCharacters = "", MinLength = 0, MaxLength = 255)]
        public String PortMessage
        {
            get
            {
                return (string)this["PortMessage"];
            }
            set
            {
                this["PortMessage"] = value;
            }
        }

        [ConfigurationProperty("UseTimeKeeping", DefaultValue = "false", IsRequired = true)]
        [StringValidator(InvalidCharacters = "", MinLength = 0, MaxLength = 255)]
        public String UseTimeKeeping
        {
            get
            {
                return (string)this["UseTimeKeeping"];
            }
            set
            {
                this["UseTimeKeeping"] = value;
            }
        }
    }
}
