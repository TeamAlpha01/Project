using InterviewManagementSystemAPI.Models;
using InterviewManagementSystemAPI.DataAccessLayer;
using System.Linq;
namespace InterviewManagementSystemAPI.Service
{
    public class RoleService : IRoleService
    {
        private IRoleDataAccessLayer _roleDataAccessLayer = DataFactory.RoleDataFactory.GetRoleDataAccessLayerObject();

        /*  
            Returns False when Exception occured in Data Access Layer
            
            Throws ArgumentNullException when Role Name is not passed to this service method
        */
        public bool CreateRole(string roleName)
        {
            if (roleName != null)
            {
                try
                {
                    var role = DataFactory.RoleDataFactory.GetRoleObject();
                    role.RoleName = roleName;
                    role.IsActive = true;

                    if (_roleDataAccessLayer.AddRoleToDatabase(role))
                    {
                        return true;
                    }
                    else
                    {
                        // LOG Error in DAL
                        return false;
                    }
                }
                catch (ArgumentNullException)
                {
                    //Log Role object is not provided  to DAL
                    return false;
                }
                catch (Exception)
                {
                    // Log "Exception Occured in Data Access Layer"
                    return false;
                }
            }
            else
            {

                throw new ArgumentNullException("Role Name is not provided");
            }
        }
        /*  
            Returns False when Exception occured in Data Access Layer
            
            Throws ArgumentNullException when Role Id is not passed to this service method
        */

        public bool RemoveRole(int roleId)
        {
            if (roleId != 0)
            {
                try
                {
                    if (_roleDataAccessLayer.RemoveRoleFromDatabase(roleId))
                    {
                        return true;
                    }
                    else
                    {
                        // LOG Error in DAL
                        return false;
                    }
                }
                catch (ArgumentNullException)
                {
                    //Log Role id is not provided  to DAL
                    return false;
                }
                catch (Exception)
                {
                    // Log "Exception Occured in Data Access Layer"
                    return false;
                }
            }
            else
            {
                throw new ArgumentNullException("Role Id is not provided");
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
                roles = from role in _roleDataAccessLayer.GetRolesFromDatabase() where role.IsActive == true select role;
                return roles;
            }
            catch (Exception)
            {
                //Log "Exception occured in DAL while fetching roles"
                throw new Exception();
            }
        }

    }
}