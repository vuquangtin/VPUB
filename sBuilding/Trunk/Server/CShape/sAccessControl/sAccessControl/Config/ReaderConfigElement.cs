using sAccessControl.Enums;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace sAccessControl.Config
{
    internal class ReaderConfigElement : ConfigurationElement
    {
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
        private string beep_on_tag
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
                return beep_on_tag.ToUpper().Equals("YES");
            }
            set
            {
                string temp = value ? "YES" : "NO";
                if (!temp.Equals(beep_on_tag))
                {
                    beep_on_tag = temp;
                }
            }
        }

        public bool CheckConfigsOK()
        {
            if (!Enum.IsDefined(typeof(ReaderType), Type))
            {
                return false;
            }

            if (Address < 0)
            {
                return false;
            }

            return true;
        }
    }
}
