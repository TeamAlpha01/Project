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

        //private readonly ILogger _logger = new ILogger<RoleDataAccessLayer>();        
        public bool AddRoleToDatabase(Role role)
        {
            if (role == null)
                throw new ArgumentNullException("Role is not provided");
            try
            {
                _db.Roles.Add(role);
                _db.SaveChanges();
                return true;
            }
            catch (DbUpdateException)
            {
                //LOG   "DB Update Exception Occured"
                return false;
            }
            catch (OperationCanceledException)
            {
                //LOG   "Opreation cancelled exception"
                return false;
            }
            catch (Exception)
            {
                //LOG   "unknown exception occured "
                return false;
            }
        }



        /*  Returns False when Exception occured in Database Connectivity
            
            Throws ArgumentNullException when Role Id is not passed 
        */
        public bool RemoveRoleFromDatabase(int roleId)
        {
            if (roleId == 0)
                throw new ArgumentNullException("Role Id is not provided ");

            try
            {
                var role = _db.Roles.Find(roleId);
                role.IsActive = false;
                _db.Roles.Update(role);
                _db.SaveChanges();
                return true;
            }
            catch (DbUpdateException)
            {
                //LOG   "DB Update Exception Occured"
                return false;
            }
            catch (OperationCanceledException)
            {
                //LOG   "Opreation cancelled exception"
                return false;
            }
            catch (Exception)
            {
                //LOG   "unknown exception occured "
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
            catch (DbUpdateException)
            {
                //LOG   "DB Update Exception Occured"
                throw new DbUpdateException();
            }
            catch (OperationCanceledException)
            {
                //LOG   "Opreation cancelled exception"
                throw new OperationCanceledException();
            }
            catch (Exception)
            {
                //LOG   "unknown exception occured "
                throw new Exception();
            }
        }

    }
}