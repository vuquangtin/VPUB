using sWorldModel.Filters;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sWorldCommunication.Interface
{
    public interface IManagerCosts
    {
        #region begin manager costs

        //Excel
        List<ManagerCostApartment> InsertFileExcel(string session, long orgId, List<ManagerCostApartment> lstReturn);

        ManagerCostApartment GetManagerCostBySubOrgId(string session, long subOrgId);
        List<ManagerCostApartment> GetManagerCostListBySubOrgId(string session, long subOrgId);

        #endregion end manager costs
    }
}
