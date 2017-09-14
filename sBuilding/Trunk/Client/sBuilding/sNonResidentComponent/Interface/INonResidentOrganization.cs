using sNonResidentComponent.Model;
using System.Collections.Generic;

namespace sNonResidentComponent.Interface {
    public interface INonResidentOrganization {
        NonResidentOrganization Insert(string session, NonResidentOrganization nonResOrg);
        NonResidentOrganization Update(string session, NonResidentOrganization nonResOrg);
        int Delete(string session, long nonOrgId);
        NonResidentOrganization Get(string session, long nonOrgId);
        List<NonResidentOrganization> GetListAllOrg(string session, string orgCode);
    }
}
