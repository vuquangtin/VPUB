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
    /// class TimeKeepingShiftFactory
    /// </summary>
    public class TimeKeepingShiftFactory
    {
        private static TimeKeepingShiftFactory instance = new TimeKeepingShiftFactory();
        public static TimeKeepingShiftFactory Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new TimeKeepingShiftFactory();
                }
                return instance;
            }
        }

        private TimeKeepingShiftFactory() 
        { }

        public ITimeKeepingShift GetChannel()
        {
            switch (SystemSettings.Instance.TypeComm)
            {
                case TYPECOMM.TEST:
                    //return TestApplication.Instance;
                       return null;
                case TYPECOMM.JAVA:
                       return JavaTimeKeepingShift.Instance;
                default:
                       return JavaTimeKeepingShift.Instance;
            }
       }    
    
    }
}
