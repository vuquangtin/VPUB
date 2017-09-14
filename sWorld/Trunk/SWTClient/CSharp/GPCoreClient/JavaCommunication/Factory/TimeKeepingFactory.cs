using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sWorldCommunication.Interface;
using CommonHelper.Config;
using JavaCommunication.Java;
using sWorldCommunication;

namespace JavaCommunication.Factory
{
  public class TimeKeepingFactory
    {
        private static TimeKeepingFactory instance = new TimeKeepingFactory();
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
