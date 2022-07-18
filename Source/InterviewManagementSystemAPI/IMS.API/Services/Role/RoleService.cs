using IMS.Models;
using IMS.DataAccessLayer;
using IMS.Validations;
using System.Linq;
using IMS.Controllers;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace IMS.Service
{
    public class RoleService : IRoleService
    {
        private IRoleDataAccessLayer _roleDataAccessLayer;
        private readonly ILogger _logger;
        private bool IsTracingEnabled;
        private readonly Stopwatch _stopwatch = new Stopwatch();
        public RoleService(ILogger<RoleService> logger,IRoleDataAccessLayer roleDataAccessLayer)
        {
            _logger = logger;
            _roleDataAccessLayer = roleDataAccessLayer;// DataFactory.RoleDataFactory.GetRoleDataAccessLayerObject(_logger);
            IsTracingEnabled = _roleDataAccessLayer.GetIsTraceEnabledFromConfiguration();
        }

        /// <summary>
        /// This method will be implemented when Role Controller Passes the Role Name to the service Layer. And controll Shifts to Role DAL.
        /// </summary>
        /// <param name="roleName">String</param>
        /// <param name="isManagement">bool</param>
        /// <returns> Returns False when Exception occured in Data Access Layer. Throws ArgumentNullException when Role Name is not passed to this service method</returns>
        
        public bool CreateRole(string roleName,bool isManagement)
        {
            _stopwatch.Start();
            RoleValidation.IsRoleNameValid(roleName);

            try
            {
                Role _role = DataFactory.RoleDataFactory.GetRoleObject();
                _role.RoleName = roleName;
                _role.IsManagement=isManagement;
                return _roleDataAccessLayer.AddRoleToDatabase(_role) ? true : false; // LOG Error in DAL;
            }
            catch (ValidationException roleNameValidException)
            {
                _logger.LogError($"Role service : CreateRole(string roleName) : {roleNameValidException.Message}");
                throw roleNameValidException;
            }
            catch (Exception roleNameException)
            {
                _logger.LogError($"Role service : CreateRole(string roleName) : {roleNameException.Message}");
                return false;
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Role Service Time elapsed for  CreateRole(string roleName,bool isManagement) :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }

        /// <summary>
        /// This method will be implemented when Role Controller Passes the Role id to the service Layer. And controll Shifts to Role DAL.
        /// </summary>
        /// <param name="roleId">int</param>
        /// <returns> Returns False when Exception occured in Data Access Layer. Throws ArgumentNullException when Role Id is not passed to this service method</returns>


        public bool RemoveRole(int roleId)
        {
            _stopwatch.Start();
            if (roleId <= 0)
                throw new ValidationException("Role Id is not provided");

            try
            {
                return _roleDataAccessLayer.RemoveRoleFromDatabase(roleId) ? true : false;
            }
            catch (ArgumentException exception)
            {
                _logger.LogError($"Role service : RemoveRole(int roleId) : {exception.Message}");
                return false;
            }
            catch (ValidationException roleNotFound)
            {
                _logger.LogError($"Role service : CreateRole(string roleName) : {roleNotFound.Message}");
                throw roleNotFound;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Role service : RemoveRole(int roleId) : {exception.Message}");
                return false;
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogError($"Role Service Time elapsed for  RemoveRole(int roleId) :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }

        /// <summary>
        /// This method will be implemented when "View all Role" - Request raise . And control Shifts to Role DAL.
        /// </summary>
        /// <returns> Throws Exception when Exception occured in DAL while fetching roles</returns>
        public IEnumerable<Role> ViewRoles()
        {
            _stopwatch.Start();
            try
            {
                IEnumerable<Role> roles = new List<Role>();
                return roles =  _roleDataAccessLayer.GetRolesFromDatabase();
            }
            catch (Exception exception)
            {
                _logger.LogError($"Role service : RemoveRole(int roleId) : Exception occured in DAL :{exception.Message}");
                throw new Exception();
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Role Service Time elapsed for  ViewRoles(int roleId) :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }
    }
}