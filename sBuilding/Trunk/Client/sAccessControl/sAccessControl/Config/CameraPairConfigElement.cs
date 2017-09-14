using sAccessControl.Enums;
using System;
using System.Configuration;

namespace sAccessControl.Config
{
    internal class CameraPairConfigElement : ConfigurationElement
    {
        [ConfigurationProperty("enable", DefaultValue = "NO", IsRequired = true)]
        [RegexStringValidator("^(Yes|yEs|yeS|YEs|YeS|yES|YES|yes|No|NO|no)$")]
        private string enable
        {
            get
            {
                return this["enable"].ToString();
            }
            set
            {
                this["enable"] = value;
            }
        }

        public bool Enable
        {
            get
            {
                return enable.ToUpper().Equals("YES");
            }
            set
            {
                string temp = value ? "YES" : "NO";
                if (!enable.ToUpper().Equals(temp))
                {
                    enable = temp;
                }
            }
        }

        [ConfigurationProperty("camera_type", IsRequired = true)]
        [IntegerValidator()]
        public int CameraType
        {
            get
            {
                return (int)this["camera_type"];
            }
            set
            {
                if ((int)this["camera_type"] != value)
                {
                    this["camera_type"] = value;
                }
            }
        }

        [ConfigurationProperty("camera_address", IsRequired = true)]
        public string CameraAddress
        {
            get
            {
                return (string)this["camera_address"];
            }
            set
            {
                if (value == null)
                {
                    value = string.Empty;
                }
                if (!this["camera_address"].Equals(value))
                {
                    this["camera_address"] = value;
                }
            }
        }

        public bool CheckConfigsOK()
        {
            if (!Enum.IsDefined(typeof(CameraConnectionType), CameraType))
            {
                return false;
            }
            return true;
        }
    }
}