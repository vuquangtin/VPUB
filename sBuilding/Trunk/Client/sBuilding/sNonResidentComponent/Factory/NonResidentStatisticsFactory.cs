using CommonHelper.Config;
using JavaCommunication;
using sNonResidentComponent.Interface;
using sNonResidentComponent.Java;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sNonResidentComponent.Factory
{
    public class NonResidentStatisticsFactory
    {
        private static NonResidentStatisticsFactory instance = new NonResidentStatisticsFactory();

        public static NonResidentStatisticsFactory Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new NonResidentStatisticsFactory();
                }
                return instance;
            }
        }

        private NonResidentStatisticsFactory()
        { }

        public INonResidentStatistics GetChannel()
        {
            switch (SystemSettings.Instance.TypeComm)
            {
                case TYPECOMM.TEST:
                    return null;
                case TYPECOMM.JAVA:
                    return JavaNonResidentStatistics.Instance;
                default:
                    return JavaNonResidentStatistics.Instance;
            }
        }
    }
}
