using IMS.Models;
namespace IMS.DataAccessLayer
{
    public interface IRoleDataAccessLayer
    {
        public bool AddRoleToDatabase(Role role);
        public bool RemoveRoleFromDatabase(int roleId);
        public List<Role> GetRolesFromDatabase();
        public void CheckRoleId(int roleId);
    }
}