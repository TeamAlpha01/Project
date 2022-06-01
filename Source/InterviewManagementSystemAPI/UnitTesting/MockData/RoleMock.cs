using System.Collections.Generic;
using IMS.Models;

namespace UnitTesting.MockData
{
    public static class RoleMock
    {
        public static List<Role> GetRolesMock()
        {
            List<Role> mockRole = new List<Role>();
            mockRole.Add( new Role { RoleId = 1, RoleName = "Software Developer" });
            mockRole.Add( new Role { RoleId = 2, RoleName = "Senior Software Developer" });
            mockRole.Add( new Role { RoleId = 3, RoleName = "Project Manager" });
            mockRole.Add( new Role { RoleId = 4, RoleName = "Module Lead" });
            mockRole.Add( new Role { RoleId = 5, RoleName = "Technical Lead" });
            mockRole.Add( new Role { RoleId = 6, RoleName = "Software Architect" });
            mockRole.Add( new Role { RoleId = 7, RoleName = "Delivery Manager" });
            mockRole.Add( new Role { RoleId = 8, RoleName = "Service Line Owner" });
            mockRole.Add( new Role { RoleId = 9, RoleName = "Talent" });
            mockRole.Add( new Role { RoleId = 10, RoleName = " Admin" });
            return mockRole;
        }
    }
}