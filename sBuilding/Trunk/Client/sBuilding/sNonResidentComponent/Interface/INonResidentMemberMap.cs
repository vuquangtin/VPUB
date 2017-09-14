using sNonResidentComponent.Model;
using sNonResidentComponent.Model.CustomObj;
using System.Collections.Generic;

namespace sNonResidentComponent.Interface {
    public interface INonResidentMemberMap {
        NonResidentMemberMap Insert(string session, NonResidentMemberMap nonResMemMap);
        NonResidentMemberMap Update(string session, NonResidentMemberMap nonResMemMap);
        int Delete(string session, long nonMemMapId);
        NonResidentMemberMap Get(string session, long nonMemMapId);
        List<NonResidentMemberMapCustom> GetListAllMemMap(string session, long nonOrgId);
    }
}
