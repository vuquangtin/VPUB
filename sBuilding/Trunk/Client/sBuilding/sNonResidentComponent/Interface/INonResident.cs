using sMeetingComponent.Model;
using sNonResidentComponent.Model;
using sNonResidentComponent.Model.CustomObj;
using sNonResidentComponent.Model.CustomObj.Statistic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sNonResidentComponent.Interface
{
    public interface INonResident
    {
        NonResidentObj insertNonResident(string session, NonResidentObj nonResident);
        NonResidentObj checkInOutNonResidentBySerialnumber(string session, string serialnumber);
        int updateNonResidentBySerialnumberAndDateTime(string session, NonResident nonResident);
        NonResident updateInfoNonResident(string session, NonResident nonResident);
    }
}
