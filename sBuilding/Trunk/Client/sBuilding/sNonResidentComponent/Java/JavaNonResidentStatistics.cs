using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sNonResidentComponent.Interface;
using sNonResidentComponent.Model;
using sNonResidentComponent.JavaComunication;
using sNonResidentComponent.Model.CustomObj;
using sNonResidentComponent.Model.CustomObj.Statistic;

namespace sNonResidentComponent.Java
{
    public class JavaNonResidentStatistics : INonResidentStatistics
    {
        private static JavaNonResidentStatistics instance = new JavaNonResidentStatistics();

        public static JavaNonResidentStatistics Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JavaNonResidentStatistics();
                }
                return instance;
            }
        }

        private JavaNonResidentStatistics()
        { }

        public NonResidentStatisticObj getListNonresidentStatisticByDate(string session, int from, int to, String dateIn, String dateIn2)
        {
            return CommunicationNonResidentStatistics.Instance.getListNonresidentStatisticByDate(session, from, to, dateIn, dateIn2);
        }

        public List<NonResidentObj> getListNonresidentByOrgidAndDate(string session, int from, int to, String dateIn, String dateIn2, long orgId)
        {
            return CommunicationNonResidentStatistics.Instance.getListNonresidentByOrgidAndDate(session, from, to, dateIn, dateIn2, orgId);
        }
        public NonResidentStatisticDetailObj getListNonresidentByDate(string session, int from, int to, String dateIn, String dateIn2)
        {
            return CommunicationNonResidentStatistics.Instance.getListNonresidentByDate(session, from, to, dateIn, dateIn2);
        }
        public NonResidentStatisticDetailObj getListNonresidentByDateAndOrgId(string session, int from, int to, String dateIn, String dateIn2, long orgId, long subOrgId, int isPeople)
        {
            return CommunicationNonResidentStatistics.Instance.getListNonresidentByDateAndOrgId(session, from, to, dateIn, dateIn2, orgId, subOrgId, isPeople);
        }
    }

}

