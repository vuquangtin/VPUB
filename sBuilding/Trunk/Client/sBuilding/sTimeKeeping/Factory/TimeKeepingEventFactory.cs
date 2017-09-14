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
    ///  class TimeKeepingEventFactory
    /// </summary>
  public  class TimeKeepingEventFactory
    {
          private static TimeKeepingEventFactory instance = new TimeKeepingEventFactory();
        public static TimeKeepingEventFactory Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new TimeKeepingEventFactory();
                }
                return instance;
            }
        }

        private TimeKeepingEventFactory() 
        { }

        public ITimeKeepingEvent GetChannel()
        {
            switch (SystemSettings.Instance.TypeComm)
            {
                case TYPECOMM.TEST:
                    //return TestApplication.Instance;
                       return null;
                case TYPECOMM.JAVA:
                       return JavaTimeKeepingEvent.Instance;
                default:
                       return JavaTimeKeepingEvent.Instance;
            }
       }    
    

    }
}
