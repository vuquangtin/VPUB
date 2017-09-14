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
    /// <summary>
    ///  class TimeKeepingTimeConfigFactory
    /// </summary>
    public class TimeKeepingTimeConfigFactory
    {
        private static TimeKeepingTimeConfigFactory instance = new TimeKeepingTimeConfigFactory();
        public static TimeKeepingTimeConfigFactory Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new TimeKeepingTimeConfigFactory();
                }
                return instance;
            }
        }

        private TimeKeepingTimeConfigFactory() 
        { }

        public ITimeKeepingTimeConfig GetChannel()
        {
            switch (SystemSettings.Instance.TypeComm)
            {
                case TYPECOMM.TEST:
                    //return TestApplication.Instance;
                       return null;
                case TYPECOMM.JAVA:
                       return JavaTimeKeepingTimeConfig.Instance;
                default:
                       return JavaTimeKeepingTimeConfig.Instance;
            }
       }    
    }
}
