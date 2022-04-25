using System;

public class RoleServices
{
    public bool CreateRole(Role role);
    public List<Role> ViewRoles();
    public bool RemoveRole(int roleId);
};