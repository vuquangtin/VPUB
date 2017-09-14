using sWorldModel.Filters;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JavaCommunication.Common
{
    class CommunicationManaCosts : CommunicationCommon
    {
        private static CommunicationManaCosts instance = new CommunicationManaCosts();
        public static CommunicationManaCosts Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CommunicationManaCosts();
                }
                return instance;
            }
        }
        public CommunicationManaCosts() { }

        protected override void BaseURL()
        {
            base.BaseURL();
            _baseUrl += @"SaiGonPearls";
        }
        //các hàm xu lý

        #region begin Config Apartment

        public List<ManagerCostApartment> InsertFileExcel(string session, long orgId, List<ManagerCostApartment> lstReturn)
        {
            string parameters = Utilites.Instance.Paramater(session,orgId);
            List<ManagerCostApartment> result = PostDataToServerObject(session, MethodNames.INSERT_FILE_EXCEL, parameters, lstReturn, new List<ManagerCostApartment>().GetType()) as List<ManagerCostApartment>;
            return result;
        }

        public ManagerCostApartment GetManagerCostBySubOrgId(string session, long subOrgId)
        {
            string parameters = Utilites.Instance.Paramater(session, subOrgId);
            ManagerCostApartment result = GetDataFromServer(session, MethodNames.GET_MANAGER_COST_BY_SUBORGID, parameters, new ManagerCostApartment().GetType()) as ManagerCostApartment;
            //if (null == result) throw new Exception();

            return result;
        }

        public List<ManagerCostApartment> GetManagerCostListBySubOrgId(string session, long subOrgId)
        {
            string parameters = Utilites.Instance.Paramater(session, subOrgId);
            List<ManagerCostApartment> result = GetDataFromServer(session, MethodNames.GET_MANAGER_COST_LIST_BY_SUBORGID, parameters, new List<ManagerCostApartment>().GetType()) as List<ManagerCostApartment>;
            //if (null == result) throw new Exception();

            return result;
        }

        #endregion end Config Apartment
    }
}
