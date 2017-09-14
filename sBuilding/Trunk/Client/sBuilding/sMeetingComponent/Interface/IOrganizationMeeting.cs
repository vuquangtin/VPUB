using sMeetingComponent.Model;
using System.Collections.Generic;

namespace sMeetingComponent.Interface
{
    public interface IOrganizationMeeting
    {
        List<OrganizationMeeting> getOrganization(string session);
        List<OrganizationMeeting> getOrganization_ASC(string session);

    }
}
