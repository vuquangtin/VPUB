using sNonResidentComponent.Interface;
using sNonResidentComponent.JavaComunication;
using sNonResidentComponent.Model;
using sNonResidentComponent.Model.CustomObj;
using System.Collections.Generic;

namespace sNonResidentComponent.Java {
    public class JavaNonResidentMemberMap : INonResidentMemberMap {
        private static JavaNonResidentMemberMap instance = new JavaNonResidentMemberMap();
        public static JavaNonResidentMemberMap Instance {
            get {
                if (null == instance) {
                    instance = new JavaNonResidentMemberMap();
                }

                return instance;
            }
        }

        private JavaNonResidentMemberMap() { }

        public NonResidentMemberMap Insert(string session, NonResidentMemberMap nonResMemMap) {
            return CommunicationNonResidentMemberMap.Instance.Insert(session, nonResMemMap);
        }

        public NonResidentMemberMap Update(string session, NonResidentMemberMap nonResMemMap) {
            return CommunicationNonResidentMemberMap.Instance.Update(session, nonResMemMap);
        }

        public int Delete(string session, long nonMemMapId) {
            return CommunicationNonResidentMemberMap.Instance.Delete(session, nonMemMapId);
        }

        public NonResidentMemberMap Get(string session, long nonMemMapId) {
            return CommunicationNonResidentMemberMap.Instance.Get(session, nonMemMapId);
        }

        public List<NonResidentMemberMapCustom> GetListAllMemMap(string session, long nonOrgId) {
            return CommunicationNonResidentMemberMap.Instance.GetListAllMemMap(session, nonOrgId);
        }
    }
}
