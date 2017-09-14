using JavaCommunication;
using JavaCommunication.Common;
using sNonResidentComponent.Constants;
using sNonResidentComponent.Model;
using sNonResidentComponent.Model.Old;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sNonResidentComponent.JavaComunication
{
    public class CommunicationOrganizationMg : CommunicationCommon
    {
        private static CommunicationOrganizationMg instance = new CommunicationOrganizationMg();

        public static CommunicationOrganizationMg Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new CommunicationOrganizationMg();
                }
                return instance;
            }
        }

        public CommunicationOrganizationMg() { }

        protected override void BaseURL()
        {
            base.BaseURL();
            _baseUrl += @"organizationmeetingmg";
        }
        /// <summary>
        /// get list org
        ///  2. GET danh sách Org
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public List<OrganizationMg> getOrganization(string session)
        {
            string parameters = Utilites.Instance.Paramater(session);

            try
            {
                return GetDataFromServer(session, NonResidentMethodNames.GET_LISTORGANIZATIONMG_ASC, parameters, new List<OrganizationMg>().GetType()) as List<OrganizationMg>;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// get list org
        ///  2.1  GET danh sách Org  ASC sắp xếp từ a -> z
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public List<OrganizationMg> getOrganization_ASC(string session)
        {
            string parameters = Utilites.Instance.Paramater(session);

            try
            {
                return GetDataFromServer(session, NonResidentMethodNames.GET_LISTORGANIZATIONMG_ASC, parameters, new List<OrganizationMg>().GetType()) as List<OrganizationMg>;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
