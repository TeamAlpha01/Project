using InterviewManagementSystemAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InterviewManagementSystemAPI.DataAccessLayer{
public class RoleDataAccessLayer : IRoleDataAccessLayer
{
        private InterviewManagementSystemDbContext _db = DataFactory.DbContextDataFactory.GetInterviewManagementSystemDbContextObject();
        public bool AddRoleToDatabase(Role role)
        {
            if(role!=null)
            {
                try{
                    _db.Roles.Add(role);
                    _db.SaveChanges();
                    return true;
                }
                catch(DbUpdateException)
                {
                    return false;
                }
                catch(OperationCanceledException)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool RemoveRoleFromDatabase(int roleId)
        {
            if(roleId!=0)
            { 
                try{
                    var role = _db.Roles.Find(roleId);
                    // db.Roles.Remove(role);
                    role.IsActive=false;
                    _db.Roles.Update(role);
                    _db.SaveChanges();
                    return true;
                }
                catch(OperationCanceledException)
                {
                    return false;
                }
                catch(ArgumentNullException)
                {
                    //The given Role Id doesn't exists
                    return false;
                }
                
            }
            else
            {
                return false;
            }
        }
        public List<Role> GetRolesFromDatabase()
        {
            return _db.Roles.ToList();                   //Cast<IRole>().ToList();
        }

    }
}