using System.ComponentModel.DataAnnotations;
using IMS.Models;
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

        /*  Returns False when Exception occured in Database Connectivity
            
            Throws ArgumentNullException when Role object is not passed 
        */

        public bool AddRoleToDatabase(Role role)
        {
            if (role == null)
                throw new ArgumentNullException("Role object is not provided to DAL");
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



        /*  Returns False when Exception occured in Database Connectivity
            
            Throws ArgumentNullException when Role Id is not passed 
        */
        public bool RemoveRoleFromDatabase(int roleId)
        {
            if (roleId <= 0)
                throw new ArgumentNullException("Role Id is not provided to DAL");

            try
            {
                var role = _db.Roles.Find(roleId);

                if (role == null) throw new ValidationException("No role is found with given role Id");

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

        /*  
            Throws Exception when Exception occured in Database Connectivity
        */
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