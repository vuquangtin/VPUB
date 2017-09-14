using JavaCommunication.Common;
using sWorldCommunication.Interface;
using sWorldModel.Filters;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JavaCommunication.Java
{
    public class JavaManagerCosts : IManagerCosts
    {

        private static JavaManagerCosts instance = new JavaManagerCosts();
        public static JavaManagerCosts Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JavaManagerCosts();
                }
                return instance;
            }
        }
        private JavaManagerCosts()
        {

        }
        //xu ly
        #region begin mana Cost

        public List<ManagerCostApartment> InsertFileExcel(string session, long orgId, List<ManagerCostApartment> lstReturn)
        {
            return CommunicationManaCosts.Instance.InsertFileExcel(session, orgId, lstReturn);
        }

        public ManagerCostApartment GetManagerCostBySubOrgId(string session, long subOrgId)
        {
            return CommunicationManaCosts.Instance.GetManagerCostBySubOrgId(session, subOrgId);
        }

        public List<ManagerCostApartment> GetManagerCostListBySubOrgId(string session, long subOrgId)
        {
            return CommunicationManaCosts.Instance.GetManagerCostListBySubOrgId(session, subOrgId);
        }

        #endregion end mana Cost
    }
}
