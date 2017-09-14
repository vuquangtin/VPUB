using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace CommonHelper.Config
{
    public class JavaWebServicesSettings : ConfigurationSection
    {
        private static JavaWebServicesSettings instance;
        //private static string spath;

        public JavaWebServicesSettings() { }

        public static JavaWebServicesSettings Instance
        {
            get
            {
                if ((object)instance == null)
                {
                    // Create a custom configuration section.
                    instance = new JavaWebServicesSettings();

                    // Get the current configuration file.
                    System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                    // Add the custom section to the application 
                    // configuration file. 
                    if (config.Sections["webServiceConfig"] == null)
                    {
                        config.Sections.Add("webServiceConfig", instance);
                    }

                    // Save the application configuration file.
                    instance.SectionInformation.ForceSave = true;
                    config.Save(ConfigurationSaveMode.Modified);
                }
                return instance;
            }
        }

        [ConfigurationProperty("service", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(JavaWebServiceCollection),
            AddItemName = "add",
            ClearItemsName = "clear",
            RemoveItemName = "remove")]
        public JavaWebServiceCollection Services
        {
            get
            {
                JavaWebServiceCollection masterCollection =
                    (JavaWebServiceCollection)base["service"];
                return masterCollection;
            }
        }

        public List<JavaWebServiceElement> GetJavaWebService()
        {
            JavaWebServicesSettings masterSection = ConfigurationManager.GetSection("javaWebServiceConfig") as JavaWebServicesSettings;
            List<JavaWebServiceElement> masterCodeList = new List<JavaWebServiceElement>();
            foreach (JavaWebServiceElement marter in masterSection.Services)
            {
                masterCodeList.Add(marter);
            }
            return masterCodeList.ToList();
        }
    }

    public class JavaWebServiceCollection : ConfigurationElementCollection
    {
        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.AddRemoveClearMap;
            }
        }

        public JavaWebServiceElement this[int index]
        {
            get { return (JavaWebServiceElement)BaseGet(index); }
            set
            {
                if (BaseGet(index) != null)
                    BaseRemoveAt(index);
                BaseAdd(index, value);
            }
        }

        public void Add(JavaWebServiceElement element)
        {
            BaseAdd(element);
        }

        public void Clear()
        {
            BaseClear();
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new JavaWebServiceElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((JavaWebServiceElement)element).Key;
        }

        public void Remove(JavaWebServiceElement element)
        {
            BaseRemove(element.Key);
        }

        public void Remove(string name)
        {
            BaseRemove(name);
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }
    }

    public class JavaWebServiceElement : ConfigurationElement
    {
        public JavaWebServiceElement() { }

        public JavaWebServiceElement(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }

        [ConfigurationProperty("Key", IsRequired = true, DefaultValue = "Untitled")]
        public string Key
        {
            get { return (string)this["Key"]; }
            set { this["Key"] = value; }
        }

        [ConfigurationProperty("Value", IsRequired = true, DefaultValue = "Untitled")]
        public string Value
        {
            get { return (string)this["Value"]; }
            set { this["Value"] = value; }
        }
    }
}
