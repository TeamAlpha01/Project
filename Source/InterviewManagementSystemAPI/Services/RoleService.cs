using InterviewManagementSystemAPI.Models;
using InterviewManagementSystemAPI.DataAccessLayer;
using System.Linq;
namespace InterviewManagementSystemAPI.Service{
    public class RoleService : IRoleService
    {
        private IRoleDataAccessLayer _roleDataAccessLayer = DataFactory.RoleDataFactory.GetRoleDataAccessLayerObject();

        public bool CreateRole(string roleName)
        {
            if(roleName!=null)
            {
                var role = DataFactory.RoleDataFactory.GetRoleObject();
                role.RoleName=roleName;
                role.IsActive=true;

                return _roleDataAccessLayer.AddRoleToDatabase(role);
            }
            else{

                return false;
            }
        }

        public bool RemoveRole(int roleId)
        {
            if(roleId!=0)
            {
                _roleDataAccessLayer.RemoveRoleFromDatabase(roleId);
                return true;
            }
            else{
                return false;
            }
        }

        public List<Role> ViewRoles()
        {
            List<Role> roles = new List<Role>();    
            roles = _roleDataAccessLayer.GetRolesFromDatabase();
            return roles;
        }
        
    }
}