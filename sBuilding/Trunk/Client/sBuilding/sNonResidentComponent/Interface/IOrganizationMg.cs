using sNonResidentComponent.Model;
using sNonResidentComponent.Model.Old;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sNonResidentComponent.Interface
{
    public interface IOrganizationMg
    {
        List<OrganizationMg> getOrganization(string session);
        List<OrganizationMg> getOrganization_ASC(string session);

    }
}
