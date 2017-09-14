using sTimeKeeping.Interface;
using System.Collections.Generic;
using sTimeKeeping.JavaComunication;
using sTimeKeeping.Model;

namespace sTimeKeeping.Java {
    public class JavaTimeKeepingFormTimeKeeping : ITimeKeepingFormTimeKeeping {
        private static JavaTimeKeepingFormTimeKeeping instance = new JavaTimeKeepingFormTimeKeeping();
        public static JavaTimeKeepingFormTimeKeeping Instance {
            get {
                if (null == instance) {
                    instance = new JavaTimeKeepingFormTimeKeeping();
                }

                return instance;
            }
        }

        private JavaTimeKeepingFormTimeKeeping() { }

        public List<ChipPersonalizationCustom> getListChipPersonalizationCustom(string session) {
            return CommunicationTimeKeepingFormTimeKeeping.Instance.getListChipPersonalizationCustom(session);
        }

        public List<MemberCustom> getListMemberCustom(string session) {
            return CommunicationTimeKeepingFormTimeKeeping.Instance.getListMemberCustom(session);
        }
    }
}
