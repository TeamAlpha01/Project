using Source.Models;
using Source.DataAccessLayer;
using System.Linq;
namespace Source.Service{
    public class RoleService : IRoleService
    {
        public bool CreateRole(string roleName)
        {
            if(roleName!=null)
            {
                Role role = new Role();
                role.RoleName=roleName;
                IRoleDataAccessLayer obj = DataFactory.RoleDataFactory.GetRoleDataAccessLayerObject();
                return obj.AddRoleToDatabase(role);
            }
            else{
                return false;
            }
        }

        public bool RemoveRole(int roleId)
        {
            if(roleId!=null)
            {
                IRoleDataAccessLayer obj = DataFactory.RoleDataFactory.GetRoleDataAccessLayerObject();
                obj.RemoveRoleFromDatabase(roleId);
                return true;
            }
            else{
                return false;
            }
        }

        public List<Role> ViewRoles()
        {
            IRoleDataAccessLayer obj = DataFactory.RoleDataFactory.GetRoleDataAccessLayerObject();
            List<Role> roles = new List<Role>();    
            roles =obj.GetRolesFromDatabase();
            return roles;
        }
        
    }
}