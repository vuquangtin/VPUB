using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace CommonHelper.Config
{
    public class LocalSettings : ConfigurationSection
    {
        private static LocalSettings instance;
        private static string spath;

        private LocalSettings() { }

        public static LocalSettings Instance
        {
            get
            {
                if ((object)instance == null)
                {
                    System.Reflection.Assembly assembly = System.Reflection.Assembly.GetEntryAssembly();
                    spath = assembly.Location;

                    if (spath.EndsWith(".config", StringComparison.InvariantCultureIgnoreCase))
                    {
                        spath = spath.Remove(spath.Length - 7);
                    }
                    Configuration config = ConfigurationManager.OpenExeConfiguration(spath);
                    if (config.Sections["localConfig"] == null)
                    {
                        instance = new LocalSettings();
                        config.Sections.Add("localConfig", instance);
                        config.Save(ConfigurationSaveMode.Modified);
                    }
                    else
                    {
                        instance = (LocalSettings)config.Sections["localConfig"];
                    }
                }
                return instance;
            }
        }

        public void Save()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(spath);
            LocalSettings section = (LocalSettings)config.Sections["localConfig"];

            section.CheckSymbol = this.CheckSymbol;
            section.DateFormat = this.DateFormat;
            section.DateTimeFormat = this.DateTimeFormat;
            section.Language = this.Language;
            section.LastPositionX = this.LastPositionX;
            section.LastPositionY = this.LastPositionY;
            section.LastScreenHeight = this.LastScreenHeight;
            section.LastScreenWidth = this.LastScreenWidth;
            section.RecordsPerPage = this.RecordsPerPage;
            section.TimeFormat = this.TimeFormat;

            section.SubOrgIdCol = this.SubOrgIdCol;
            section.NameHeadApartmentCol = this.NameHeadApartmentCol;
            section.PayManagerCol = this.PayManagerCol;
            section.PayWaterCol = this.PayWaterCol;
            section.DayPayCol = this.DayPayCol;
            section.UpdateTimeCol = this.UpdateTimeCol;
            section.SumMoneyCol = this.SumMoneyCol;

            config.Save(ConfigurationSaveMode.Full);
        }

        [ConfigurationProperty("CheckSymbol", DefaultValue = "•", IsRequired = true)]
        [StringValidator(InvalidCharacters = "", MinLength = 1, MaxLength = 255)]
        public string CheckSymbol
        {
            get
            {
                return (string)this["CheckSymbol"];
            }
            set
            {
                this["CheckSymbol"] = value;
            }
        }

        [ConfigurationProperty("DateFormat", DefaultValue = "dd/MM/yyyy", IsRequired = true)]
        [StringValidator(InvalidCharacters = "", MinLength = 1, MaxLength = 255)]
        public string DateFormat
        {
            get
            {
                return (string)this["DateFormat"];
            }
            set
            {
                this["DateFormat"] = value;
            }
        }

        public string DateFormatRegex
        {
            get
            {
                return "{0:" + DateFormat + "}";
            }
        }

        [ConfigurationProperty("DateTimeFormat", DefaultValue = "HH:mm:ss dd/MM/yyyy", IsRequired = true)]
        [StringValidator(InvalidCharacters = "", MinLength = 1, MaxLength = 255)]
        public string DateTimeFormat
        {
            get
            {
                return (string)this["DateTimeFormat"];
            }
            set
            {
                this["DateTimeFormat"] = value;
            }
        }

        public string DateTimeFormatRegex
        {
            get
            {
                return "{0:" + DateTimeFormat + "}";
            }
        }

        [ConfigurationProperty("Language", DefaultValue = "vi", IsRequired = true)]
        [StringValidator(InvalidCharacters = "~!@#$%^&()[]{}/;'\"|\\", MinLength = 1, MaxLength = 255)]
        public string Language
        {
            get
            {
                return (string)this["Language"];
            }
            set
            {
                this["Language"] = value;
            }
        }

        [ConfigurationProperty("LastPositionX", DefaultValue = 0, IsRequired = true)]
        [IntegerValidator(MinValue = 0)]
        public int LastPositionX
        {
            get
            {
                return (int)this["LastPositionX"];
            }
            set
            {
                this["LastPositionX"] = value;
            }
        }

        [ConfigurationProperty("LastPositionY", DefaultValue = 0, IsRequired = true)]
        [IntegerValidator(MinValue = 0)]
        public int LastPositionY
        {
            get
            {
                return (int)this["LastPositionY"];
            }
            set
            {
                this["LastPositionY"] = value;
            }
        }

        [ConfigurationProperty("LastScreenHeight", DefaultValue = 800, IsRequired = true)]
        [IntegerValidator(MinValue = 1)]
        public int LastScreenHeight
        {
            get
            {
                return (int)this["LastScreenHeight"];
            }
            set
            {
                this["LastScreenHeight"] = value;
            }
        }

        [ConfigurationProperty("LastScreenWidth", DefaultValue = 600, IsRequired = true)]
        [IntegerValidator(MinValue = 1)]
        public int LastScreenWidth
        {
            get
            {
                return (int)this["LastScreenWidth"];
            }
            set
            {
                this["LastScreenWidth"] = value;
            }
        }

        [ConfigurationProperty("RecordsPerPage", DefaultValue = 100, IsRequired = true)]
        [IntegerValidator(MinValue = 0, MaxValue = 1000)]
        public int RecordsPerPage
        {
            get
            {
                return (int)this["RecordsPerPage"];
            }
            set
            {
                this["RecordsPerPage"] = value;
            }
        }

        [ConfigurationProperty("TimeFormat", DefaultValue = "HH/mm/ss", IsRequired = true)]
        [StringValidator(InvalidCharacters = "", MinLength = 1, MaxLength = 255)]
        public string TimeFormat
        {
            get
            {
                return (string)this["TimeFormat"];
            }
            set
            {
                this["TimeFormat"] = value;
            }
        }

        public string TimeFormatRegex
        {
            get
            {
                return "{0:" + TimeFormat + "}";
            }
        }

        #region Config so cot khi import tu file excel



        [ConfigurationProperty("SubOrgIdCol", DefaultValue = 8, IsRequired = true)]
        [IntegerValidator(MinValue = -1, MaxValue = 26)]
        public int SubOrgIdCol
        {
            get
            {
                return (int)this["SubOrgIdCol"];
            }
            set
            {
                this["SubOrgIdCol"] = value;
            }
        }

        [ConfigurationProperty("NameHeadApartmentCol", DefaultValue = 8, IsRequired = true)]
        [IntegerValidator(MinValue = -1, MaxValue = 26)]
        public int NameHeadApartmentCol
        {
            get
            {
                return (int)this["NameHeadApartmentCol"];
            }
            set
            {
                this["NameHeadApartmentCol"] = value;
            }
        }

        [ConfigurationProperty("PayManagerCol", DefaultValue = 8, IsRequired = true)]
        [IntegerValidator(MinValue = -1, MaxValue = 26)]
        public int PayManagerCol
        {
            get
            {
                return (int)this["PayManagerCol"];
            }
            set
            {
                this["PayManagerCol"] = value;
            }
        }

        [ConfigurationProperty("PayWaterCol", DefaultValue = 8, IsRequired = true)]
        [IntegerValidator(MinValue = -1, MaxValue = 26)]
        public int PayWaterCol
        {
            get
            {
                return (int)this["PayWaterCol"];
            }
            set
            {
                this["PayWaterCol"] = value;
            }
        }

        [ConfigurationProperty("DayPayCol", DefaultValue = 8, IsRequired = true)]
        [IntegerValidator(MinValue = -1, MaxValue = 26)]
        public int DayPayCol
        {
            get
            {
                return (int)this["DayPayCol"];
            }
            set
            {
                this["DayPayCol"] = value;
            }
        }

        [ConfigurationProperty("UpdateTimeCol", DefaultValue = 8, IsRequired = true)]
        [IntegerValidator(MinValue = -1, MaxValue = 26)]
        public int UpdateTimeCol
        {
            get
            {
                return (int)this["UpdateTimeCol"];
            }
            set
            {
                this["UpdateTimeCol"] = value;
            }
        }

        [ConfigurationProperty("SumMoneyCol", DefaultValue = 8, IsRequired = true)]
        [IntegerValidator(MinValue = -1, MaxValue = 26)]
        public int SumMoneyCol
        {
            get
            {
                return (int)this["SumMoneyCol"];
            }
            set
            {
                this["SumMoneyCol"] = value;
            }
        }

        [ConfigurationProperty("ApartmentFirstRow", DefaultValue = 8, IsRequired = true)]
        [IntegerValidator(MinValue = 0, MaxValue = 9999)]
        public int ApartmentFirstRow
        {
            get
            {
                return (int)this["ApartmentFirstRow"];
            }
            set
            {
                this["ApartmentFirstRow"] = value;
            }
        }

        #endregion
    }
}
