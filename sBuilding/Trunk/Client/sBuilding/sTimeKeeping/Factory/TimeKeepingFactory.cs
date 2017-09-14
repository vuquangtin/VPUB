using CommonHelper.Config;
using JavaCommunication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sTimeKeeping.Model
{
    /// <summary>
    /// class TimeKeepingFactory
    /// </summary>
   public class TimeKeepingFactory
    { private static TimeKeepingFactory instance = new TimeKeepingFactory();
        public static TimeKeepingFactory Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new TimeKeepingFactory();
                }
                return instance;
            }
        }

        private TimeKeepingFactory() 
        { }

    public ITimeKeeping GetChannel()
        {
            switch (SystemSettings.Instance.TypeComm)
            {
                case TYPECOMM.TEST:
                    //return TestApplication.Instance;
                       return null;
                case TYPECOMM.JAVA:
                       return JavaTimeKeeping.Instance;
                default:
                       return JavaTimeKeeping.Instance;
            }
       }    
    }

}
