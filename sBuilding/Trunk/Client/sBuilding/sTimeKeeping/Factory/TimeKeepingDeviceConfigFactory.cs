using CommonHelper.Config;
using JavaCommunication;
using sTimeKeeping.Interface;
using sTimeKeeping.Java;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sTimeKeeping.Factory
{
  public  class TimeKeepingDeviceConfigFactory
    {
        private static TimeKeepingDeviceConfigFactory instance = new TimeKeepingDeviceConfigFactory();
        public static TimeKeepingDeviceConfigFactory Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new TimeKeepingDeviceConfigFactory();
                }
                return instance;
            }
        }

        private TimeKeepingDeviceConfigFactory() 
        { }

    public ITimeKeepingDeviceConfig GetChannel()
        {
            switch (SystemSettings.Instance.TypeComm)
            {
                case TYPECOMM.TEST:
                    //return TestApplication.Instance;
                       return null;
                case TYPECOMM.JAVA:
                       return JavaTimeKeepingDeviceConfig.Instance;
                default:
                       return JavaTimeKeepingDeviceConfig.Instance;
            }
       }    
    }
}
