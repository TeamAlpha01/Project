using InterviewManagementSystemAPI.Models;
namespace InterviewManagementSystemAPI.DataAccessLayer{
    public interface IRoleDataAccessLayer{
        public bool AddRoleToDatabase(Role role);
         public bool RemoveRoleFromDatabase(int roleId);
         public List<Role> GetRolesFromDatabase();
    }
}