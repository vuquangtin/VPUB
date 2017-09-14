using sNonResidentComponent.Model;
using System.Collections.Generic;

namespace sNonResidentComponent.Interface {
    public interface INonResidentSubOrganization {
        NonResidentSubOrganization Insert(string session, NonResidentSubOrganization nonResSubOrg);
        NonResidentSubOrganization Update(string session, NonResidentSubOrganization nonResSubOrg);
        int Delete(string session, long nonSubOrgId);
        NonResidentSubOrganization Get(string session, long nonSubOrgId);
        List<NonResidentSubOrganization> GetListAllSubOrg(string session, long nonOrgId);
    }
}
