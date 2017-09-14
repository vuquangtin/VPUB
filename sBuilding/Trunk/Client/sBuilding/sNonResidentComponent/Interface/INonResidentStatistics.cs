using sNonResidentComponent.Model;
using sNonResidentComponent.Model.CustomObj;
using sNonResidentComponent.Model.CustomObj.Statistic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sNonResidentComponent.Interface
{
    public interface INonResidentStatistics
    {
        NonResidentStatisticObj getListNonresidentStatisticByDate(string session, int from, int to, String dateIn, String dateIn2);
        List<NonResidentObj> getListNonresidentByOrgidAndDate(string session, int from, int to, String dateIn, String dateIn2, long orgId);
        NonResidentStatisticDetailObj getListNonresidentByDate(string session, int from, int to, String dateIn, String dateIn2);
        NonResidentStatisticDetailObj getListNonresidentByDateAndOrgId(string session, int from, int to, String dateIn, String dateIn2, long orgId, long subOrgId, int isPeople);

    }
}
