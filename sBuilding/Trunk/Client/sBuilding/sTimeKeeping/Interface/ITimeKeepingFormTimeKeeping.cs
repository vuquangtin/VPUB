using sTimeKeeping.Model;
using System.Collections.Generic;

namespace sTimeKeeping.Interface {
    public interface ITimeKeepingFormTimeKeeping {
        // Interface Form Time Keeping
        List<ChipPersonalizationCustom> getListChipPersonalizationCustom(string session);
        List<MemberCustom> getListMemberCustom(string session);
    }
}
