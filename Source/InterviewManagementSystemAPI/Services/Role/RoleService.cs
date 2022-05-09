using IMS.Models;
using IMS.DataAccessLayer;
using IMS.Validations;
using System.Linq;
using IMS.Controllers;
using System.ComponentModel.DataAnnotations;

namespace IMS.Service
{
    public class RoleService : IRoleService
    {
        private IRoleDataAccessLayer _roleDataAccessLayer;
        private Role _role = DataFactory.RoleDataFactory.GetRoleObject();
        private readonly ILogger _logger;
        public RoleService(ILogger logger)
        {
            _logger = logger;
            _roleDataAccessLayer = DataFactory.RoleDataFactory.GetRoleDataAccessLayerObject(_logger);
        }

        /// <summary>
        /// This method will be implemented when Role Controller Passes the Role Name to the service Layer. And controll Shifts to Role DAL.
        /// </summary>
        /// <param name="roleName">String</param>
        /// <returns> Returns False when Exception occured in Data Access Layer. Throws ArgumentNullException when Role Name is not passed to this service method</returns>
        
        public bool CreateRole(string roleName)
        {
            if (!RoleValidation.IsRoleValid(roleName))
                throw new ValidationException("Role Name is not valid");

            try
            {
                _role.RoleName = roleName;
                return _roleDataAccessLayer.AddRoleToDatabase(_role) ? true : false; // LOG Error in DAL;
            }
            catch (ArgumentException exception)
            {
                _logger.LogInformation($"Role service : RemoveRole(int roleId) : {exception.Message}");
                return false;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Role service : CreateRole(string roleName) : {exception.Message}");
                return false;
            }
        }

        /// <summary>
        /// This method will be implemented when Role Controller Passes the Role id to the service Layer. And controll Shifts to Role DAL.
        /// </summary>
        /// <param name="roleId">int</param>
        /// <returns> Returns False when Exception occured in Data Access Layer. Throws ArgumentNullException when Role Id is not passed to this service method</returns>


        public bool RemoveRole(int roleId)
        {
            if (roleId <= 0)
                throw new ValidationException("Role Id is not provided");

            try
            {
                return _roleDataAccessLayer.RemoveRoleFromDatabase(roleId) ? true : false;
            }
            catch (ArgumentException exception)
            {
                _logger.LogInformation($"Role service : RemoveRole(int roleId) : {exception.Message}");
                return false;
            }
            catch (ValidationException roleNotFound)
            {
                _logger.LogInformation($"Role service : CreateRole(string roleName) : {roleNotFound.Message}");
                throw roleNotFound;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Role service : RemoveRole(int roleId) : {exception.Message}");
                return false;
            }
        }

        /// <summary>
        /// This method will be implemented when "View all Role" - Request raise . And control Shifts to Role DAL.
        /// </summary>
        /// <returns> Throws Exception when Exception occured in DAL while fetching roles</returns>
        public IEnumerable<Role> ViewRoles()
        {
            try
            {
                IEnumerable<Role> roles = new List<Role>();
                return roles = from role in _roleDataAccessLayer.GetRolesFromDatabase() where role.IsActive == true select role;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Role service : RemoveRole(int roleId) : Exception occured in DAL :{exception.Message}");
                throw new Exception();
            }
        }
    }
}