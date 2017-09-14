using JavaCommunication;
using JavaCommunication.Common;
using sTimeKeeping.Constants;
using sTimeKeeping.Model;
using sWorldModel.TransportData;
using System.Collections.Generic;

namespace sTimeKeeping.JavaComunication {
    public class CommunicationTimeKeepingFormTimeKeeping : CommunicationCommon {
        private static CommunicationTimeKeepingFormTimeKeeping instance = new CommunicationTimeKeepingFormTimeKeeping();
        public static CommunicationTimeKeepingFormTimeKeeping Instance {
            get {
                if (null == instance) {
                    instance = new CommunicationTimeKeepingFormTimeKeeping();
                }

                return instance;
            }
        }

        private CommunicationTimeKeepingFormTimeKeeping() { }

        protected override void BaseURL() {
            base.BaseURL();
            _baseUrl += @"timekeepingformtimekeepingmgt";
        }

        public List<ChipPersonalizationCustom> getListChipPersonalizationCustom(string session) {
            string parameters = Utilites.Instance.Paramater(session);
            return GetDataFromServer(session, TimeKeepingMethodNames.GET_LIST_CHIP_PERSONALIZATION_CUSTOM, parameters, new List<ChipPersonalizationCustom>().GetType()) as List<ChipPersonalizationCustom>;
        }

        public List<MemberCustom> getListMemberCustom(string session) {
            string parameters = Utilites.Instance.Paramater(session);
            return GetDataFromServer(session, TimeKeepingMethodNames.GET_LIST_MEMBER_CUSTOM, parameters, new List<MemberCustom>().GetType()) as List<MemberCustom>;
        }
    }
}
