using System.ComponentModel.DataAnnotations;
using IMS.Models;
using IMS.Validations;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace IMS.DataAccessLayer
{
    public class RoleDataAccessLayer : IRoleDataAccessLayer
    {
        private InterviewManagementSystemDbContext _db;
        private ILogger _logger;
        private IConfiguration _configuration;
        private readonly Stopwatch _stopwatch = new Stopwatch();
     

        public RoleDataAccessLayer(ILogger<RoleDataAccessLayer> logger,InterviewManagementSystemDbContext dbContext,IConfiguration configuration)
        {
            _logger = logger;
            _db = dbContext;
            _configuration = configuration;
            IsTracingEnabled = GetIsTraceEnabledFromConfiguration();
        }

        /// <summary>
        /// This method is implemented when the Service layer shifts the control to Role DAL. 
        /// Role DAL Perform the interaction with Database and Respond to the Add Role to Database request.
        /// </summary>
        /// <param name="role">Object</param>
        /// <returns>Returns False when Exception occured in Database Connectivity . Throws ArgumentNullException when Role object is not passed </returns>

        public bool AddRoleToDatabase(Role role)
        {
             _stopwatch.Start();
            RoleValidation.IsRoleValid(role);
            bool roleNameExists = _db.Roles!.Any(x => x.RoleName == role.RoleName && x.IsActive == true);
            if (roleNameExists)
            {
                throw new ValidationException("Role already exist");
            }

            try
            {
                _db.Roles!.Add(role);
                _db.SaveChanges();
                return true;
            }
            catch (DbUpdateException exception)
            {
                _logger.LogError($"Role DAL : AddRoleToDatabase(Role role) : {exception.Message}");
                return false;
            }
            catch (OperationCanceledException exception)
            {
                _logger.LogError($"Role DAL : AddRoleToDatabase(Role role) : {exception.Message}");
                return false;
            }
            catch (Exception exception)
            {
                _logger.LogError($"Role DAL : AddRoleToDatabase(Role role) : {exception.Message}");
                return false;
            }
             finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Role DAL Time elapsed for  AddRoleToDatabase(Role role) :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }

        /// <summary>
        /// This method is implemented when the Service layer shifts the control to Role DAL. 
        /// Role DAL Perform the interaction with Database and Respond to the Remove Role from Database request.
        /// </summary>
        /// <param name="roleId">int</param>
        /// <returns>  Returns False when Exception occured in Database Connectivity . Throws ArgumentNullException when Role Id is not passed </returns>
        public bool RemoveRoleFromDatabase(int roleId)
        {
             _stopwatch.Start();
            // if (roleId <= 0)
            //     throw new ArgumentNullException("Role Id is not provided to DAL");
            try
            {
                var role = _db.Roles!.Find(roleId);
                if (role!.IsActive == false)
                {
                    throw new ValidationException("There is no employee for this role id");
                }
                else
                {
                    role.IsActive = false;
                    _db.Roles.Update(role);
                    _db.SaveChanges();
                    return true;
                }
            }
            // try
            // {
            //     var role = _db.Roles.Find(roleId);

            //     if (role == null) throw new ValidationException("No role is found with given role Id");

            //     role.IsActive = false;
            //     _db.Roles.Update(role);
            //     _db.SaveChanges();
            //     return true;
            // }
            catch (DbUpdateException exception)
            {
                _logger.LogError($"Role DAL : RemoveRoleFromDatabase(int roleId) : {exception.Message}");
                return false;
            }
            catch (OperationCanceledException exception)
            {
                _logger.LogError($"Role DAL : RemoveRoleFromDatabase(int roleId) : {exception.Message}");
                return false;
            }
            catch (ValidationException roleNotFound)
            {
                throw roleNotFound;
            }
            catch (Exception exception)
            {
                _logger.LogError($"Role DAL : RemoveRoleFromDatabase(int roleId) : {exception.Message}");
                return false;
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Role DAL Time elapsed for  RemoveRoleFromDatabase(int roleId) :{_stopwatch.ElapsedMilliseconds}ms");
            }

        }

        /// <summary>
        ///  This method is implemented when the Service layer shifts the control to Role DAL to View all Roles. 
        /// Role DAL Perform the interaction with Database and Respond to the view all Role request.
        /// </summary>
        /// <returns>Throws Exception when Exception occured in Database Connectivity</returns>

        public List<Role> GetRolesFromDatabase()
        {
             _stopwatch.Start();
            try
            {
                _logger.LogError("logger DAL");
                return (from role in _db.Roles where role.IsActive == true select role).ToList();
            }
            catch (DbUpdateException exception)
            {
                _logger.LogError($"Role DAL : GetRolesFromDatabase() : {exception.Message}");
                throw new DbUpdateException();
            }
            catch (OperationCanceledException exception)
            {
                _logger.LogError($"Role DAL : GetRolesFromDatabase() : {exception.Message}");
                throw new OperationCanceledException();
            }
            catch (Exception exception)
            {
                _logger.LogError($"Role DAL : GetRolesFromDatabase() : {exception.Message}");
                throw new Exception();
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Role DAL Time elapsed for  GetRolesFromDatabase() :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }

        public void CheckRoleId(int roleId)
        {
             _stopwatch.Start();
            if(!_db.Roles!.Any(x => x.RoleId == roleId)) 
                throw new ValidationException("Role was not found");
            /**finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Role DAL Time elapsed for  AddRoleToDatabase(Role role) :{_stopwatch.ElapsedMilliseconds}ms");
            }**/
        }
        
      public bool GetIsTraceEnabledFromConfiguration()
        {
            try
            {
                var IsTracingEnabled = _configuration["Tracing:IsEnabled"];
                return IsTracingEnabled != null ? Convert.ToBoolean(IsTracingEnabled) : false;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Role DAL", "GetIsTraceEnabledFromConfiguration()", exception);
                return false;
            
        }

    }
}