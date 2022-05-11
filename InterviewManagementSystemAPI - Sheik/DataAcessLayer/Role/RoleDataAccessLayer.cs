using System.ComponentModel.DataAnnotations;
using IMS.Models;
using IMS.Validations;
using Microsoft.EntityFrameworkCore;

namespace IMS.DataAccessLayer
{
    public class RoleDataAccessLayer : IRoleDataAccessLayer
    {
        private InterviewManagementSystemDbContext _db = DataFactory.DbContextDataFactory.GetInterviewManagementSystemDbContextObject();
        private ILogger _logger;

        public RoleDataAccessLayer(ILogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// This method is implemented when the Service layer shifts the control to Role DAL. 
        /// Role DAL Perform the interaction with Database and Respond to the Add Role to Database request.
        /// </summary>
        /// <param name="role">Object</param>
        /// <returns>Returns False when Exception occured in Database Connectivity . Throws ArgumentNullException when Role object is not passed </returns>

        public bool AddRoleToDatabase(Role role)
        {
            RoleValidation.IsRoleValid(role);
            bool roleNameExists = _db.Roles.Any(x => x.RoleName == role.RoleName && x.IsActive == true);
            if (roleNameExists)
            {
                throw new ValidationException("Role already exist");
            }
           
            try
            {
                _db.Roles.Add(role);
                _db.SaveChanges();
                return true;
            }
            catch (DbUpdateException exception)
            {
                _logger.LogInformation($"Role DAL : AddRoleToDatabase(Role role) : {exception.Message}");
                return false;
            }
            catch (OperationCanceledException exception)
            {
                _logger.LogInformation($"Role DAL : AddRoleToDatabase(Role role) : {exception.Message}");
                return false;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Role DAL : AddRoleToDatabase(Role role) : {exception.Message}");
                return false;
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
            bool isDeleteroleId = _db.Roles.Any(x =>x.RoleId==roleId && x.IsActive == false);
            if (isDeleteroleId)
            {
                throw new ValidationException("Role does not exists");
            }
            try
            {
                var role = _db.Roles.Find(roleId);
                if (roleId == 0) throw new ValidationException("No role found in given ID");
                role.IsActive = false;
                _db.Roles.Update(role);
                _db.SaveChanges();
                return true;
            }
            catch (DbUpdateException exception)
            {
                _logger.LogInformation($"Role DAL : RemoveRoleFromDatabase(int roleId) : {exception.Message}");
                return false;
            }
            catch (OperationCanceledException exception)
            {
                _logger.LogInformation($"Role DAL : RemoveRoleFromDatabase(int roleId) : {exception.Message}");
                return false;
            }
            catch (ValidationException roleNotFound)
            {
                throw roleNotFound;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Role DAL : RemoveRoleFromDatabase(int roleId) : {exception.Message}");
                return false;
            }

        }

        /// <summary>
        ///  This method is implemented when the Service layer shifts the control to Role DAL to View all Roles. 
        /// Role DAL Perform the interaction with Database and Respond to the view all Role request.
        /// </summary>
        /// <returns>Throws Exception when Exception occured in Database Connectivity</returns>
        
        public List<Role> GetRolesFromDatabase()
        {
            try
            {
                _logger.LogInformation("logger DAL");
                return _db.Roles.ToList();
            }
            catch (DbUpdateException exception)
            {
                _logger.LogInformation($"Role DAL : GetRolesFromDatabase() : {exception.Message}");
                throw new DbUpdateException();
            }
            catch (OperationCanceledException exception)
            {
                _logger.LogInformation($"Role DAL : GetRolesFromDatabase() : {exception.Message}");
                throw new OperationCanceledException();
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Role DAL : GetRolesFromDatabase() : {exception.Message}");
                throw new Exception();
            }
        }

    }
}