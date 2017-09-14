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
    ///  class TimeKeepingUserTimeConfigFactory
    /// </summary>
    public class TimeKeepingUserTimeConfigFactory
    { private static TimeKeepingUserTimeConfigFactory instance = new TimeKeepingUserTimeConfigFactory();
        public static TimeKeepingUserTimeConfigFactory Instance {
            get {
                if (null == instance) {
                    instance = new TimeKeepingUserTimeConfigFactory();
                }

                return instance;
            }
        }

        private TimeKeepingUserTimeConfigFactory()
        {

        }

        public ITimeKeepingUserTimeConfig GetChannel()
        {
            switch (SystemSettings.Instance.TypeComm) {
                case TYPECOMM.TEST:
                    return null;
                case TYPECOMM.JAVA:
                    return JavaTimeKeepingUserTimeConfig.Instance;
                default:
                    return JavaTimeKeepingUserTimeConfig.Instance;
            }
        }
    }
}
