using JavaCommunication;
using JavaCommunication.Common;
using sMeetingComponent.Constants;
using sMeetingComponent.Model;
using System;
using System.Collections.Generic;

namespace sMeetingComponent.JavaComunication
{
    public class CommunicationOrganizationMeeting : CommunicationCommon
    {
        private static CommunicationOrganizationMeeting instance = new CommunicationOrganizationMeeting();

        public static CommunicationOrganizationMeeting Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new CommunicationOrganizationMeeting();
                }
                return instance;
            }
        }

        public CommunicationOrganizationMeeting() { }

        protected override void BaseURL()
        {
            base.BaseURL();
            _baseUrl += @"organizationmeetingmg";
        }

        /// <summary>
        /// 6: lấy thông tin đơn vị
        /// GET LIST ORG
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public List<OrganizationMeeting> getOrganization(string session)
        {
            string parameters = Utilites.Instance.Paramater(session);
            try
            {
                return GetDataFromServer(session, MeetingMethodNames.GET_LISTORGANIZATIONMG, parameters, new List<OrganizationMeeting>().GetType()) as List<OrganizationMeeting>;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        ///  //6.1 GET danh sách Org ASC sắp xếp từ a -> z
        /// GET LIST ORG
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public List<OrganizationMeeting> getOrganization_ASC(string session)
        {
            string parameters = Utilites.Instance.Paramater(session);
            try
            {
                return GetDataFromServer(session, MeetingMethodNames.GET_LISTORGANIZATIONMG_ASC, parameters, new List<OrganizationMeeting>().GetType()) as List<OrganizationMeeting>;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
