using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sNonResidentComponent.Interface;
using sNonResidentComponent.Model;
using sNonResidentComponent.JavaComunication;
using sMeetingComponent.Model;
using sNonResidentComponent.Model.CustomObj;
using sNonResidentComponent.Model.CustomObj.Statistic;

namespace sNonResidentComponent.Java
{
    public class JavaNonResident : INonResident
    {
        private static JavaNonResident instance = new JavaNonResident();

        public static JavaNonResident Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JavaNonResident();
                }
                return instance;
            }
        }

        private JavaNonResident()
        {
        }

        public NonResidentObj insertNonResident(string session, NonResidentObj nonResident)
        {
            return CommunicationNonResident.Instance.insertNonResident(session, nonResident);
        }

        public int updateNonResidentBySerialnumberAndDateTime(string session, NonResident nonResident)
        {
            return CommunicationNonResident.Instance.updateNonResidentBySerialnumberAndDateTime(session, nonResident);
        }

        public NonResident updateInfoNonResident(string session, NonResident nonResident)
        {
            return CommunicationNonResident.Instance.updateInfoNonResident(session, nonResident);
        }

        public NonResidentObj checkInOutNonResidentBySerialnumber(string session, string serialnumber)
        {
            return CommunicationNonResident.Instance.checkInOutNonResidentBySerialnumber(session, serialnumber);
        }

    }
}
