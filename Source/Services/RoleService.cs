using Source.Models;

namespace Source.Service{
    public class RoleService 
    {
        public bool CreateRole(string? roleName)
        {
            if(roleName!=null)
            {
                return true;
            }
            else{
                return false;
            }
        }

        public bool RemoveRole(int? roleId)
        {
            if(roleId!=null)
            {
                return true;
            }
            else{
                return false;
            }
        }

        public List<IRole> ViewRoles()
        {
            IRole role = new Role();
            List<IRole> roles = new List<IRole>();
            roles.Add(role);
            return roles;
        }
        
    }
}