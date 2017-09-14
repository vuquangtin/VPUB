using System;

namespace CampusModel.Model
{
    public enum OrganizationType
    {
        Department = 1,
        Faculty = 2,
    }

    public static class OrganizationTypeExtMethod
    {
        public static string GetAlias(this OrganizationType type)
        {
            switch(type)
            {
                case OrganizationType.Department:
                    return "D";
                case OrganizationType.Faculty:
                    return "F";
                default:
                    throw new ArgumentException("Invalid organization type!");
            }
        }

        public static OrganizationType ToOrganizationType(string type)
        {
            switch(type)
            {
                case "D":
                    return OrganizationType.Department;
                case "F":
                    return OrganizationType.Faculty;
                default:
                    throw new ArgumentException("Invalid organization type!");
            }
        }
    }
}
