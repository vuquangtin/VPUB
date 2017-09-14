using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;

namespace sAccessControl.Config
{
    internal class AccessControlConfigSection : ConfigurationSection
    {
        private static AccessControlConfigSection instance = null;
        private static readonly object lob = new object();

        private static string configFilePath = null;
        private const string SectionName = "accessControl";

        public static AccessControlConfigSection GetInstance()
        {
            if (instance == null)
            {
                lock (lob)
                {
                    if (instance == null)
                    {
                        configFilePath = Assembly.GetEntryAssembly().Location;
                        if (configFilePath.EndsWith(".config", StringComparison.InvariantCultureIgnoreCase))
                        {
                            configFilePath = configFilePath.Remove(configFilePath.Length - 7);
                        }

                        Configuration config = ConfigurationManager.OpenExeConfiguration(configFilePath);

                        if (config.Sections[SectionName] == null)
                        {
                            instance = new AccessControlConfigSection();
                            config.Sections.Add(SectionName, instance);
                            config.Save(ConfigurationSaveMode.Modified);
                        }
                        else
                        {
                            instance = (AccessControlConfigSection)config.Sections[SectionName];
                        }
                    }
                }
            }
            return instance;
        }

        public void Save()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(configFilePath);
            AccessControlConfigSection section = (AccessControlConfigSection)config.Sections[SectionName];

            section.Camera = this.Camera;
            section.Reader = this.Reader;

            config.Save(ConfigurationSaveMode.Modified);
        }

        [ConfigurationProperty("camera", IsRequired = true)]
        public CameraPairConfigElement Camera
        {
            get
            {
                return (CameraPairConfigElement)this["camera"];
            }
            set
            {
                this["camera"] = value;
            }
        }

        [ConfigurationProperty("reader", IsRequired = true)]
        public ReaderConfigElement Reader
        {
            get
            {
                return (ReaderConfigElement)this["reader"];
            }
            set
            {
                this["reader"] = value;
            }
        }
    }
}
