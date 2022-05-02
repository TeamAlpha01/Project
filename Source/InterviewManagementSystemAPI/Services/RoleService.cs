using InterviewManagementSystemAPI.Models;
using InterviewManagementSystemAPI.DataAccessLayer;
using System.Linq;
namespace InterviewManagementSystemAPI.Service
{
    public class RoleService : IRoleService
    {
        private IRoleDataAccessLayer _roleDataAccessLayer = DataFactory.RoleDataFactory.GetRoleDataAccessLayerObject();
        private Role _role = DataFactory.RoleDataFactory.GetRoleObject();

        /*  
            Returns False when Exception occured in Data Access Layer
            
            Throws ArgumentNullException when Role Name is not passed to this service method
        */
        public bool CreateRole(string roleName)
        {
            if (roleName == null)
                throw new ArgumentNullException("Role Name is not provided");

            try
            {
                _role.RoleName = roleName;
                return _roleDataAccessLayer.AddRoleToDatabase(_role) ? true : false; // LOG Error in DAL;
            }
            catch (Exception)
            {
                // Log "Exception Occured in Data Access Layer"
                return false;
            }
        }

        /*  
            Returns False when Exception occured in Data Access Layer
            
            Throws ArgumentNullException when Role Id is not passed to this service method
        */

        public bool RemoveRole(int roleId)
        {
            if (roleId != 0)
                throw new ArgumentNullException("Role Id is not provided");

            try
            {
                return _roleDataAccessLayer.RemoveRoleFromDatabase(roleId) ? true :false; // LOG Error in DAL;
            }
            catch (Exception)
            {
                // Log "Exception Occured in Data Access Layer"
                return false;
            }
        }

        /*  
            Throws Exception when Exception occured in DAL while fetching roles
        */
        public IEnumerable<Role> ViewRoles()
        {
            try
            {
                IEnumerable<Role> roles = new List<Role>();
                return roles = from role in _roleDataAccessLayer.GetRolesFromDatabase() where role.IsActive == true select role;
            }
            catch (Exception)
            {
                //Log "Exception occured in DAL while fetching roles"
                throw new Exception();
            }
        }

    }
}