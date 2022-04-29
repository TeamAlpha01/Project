using InterviewManagementSystemAPI.Models;

namespace InterviewManagementSystemAPI.Service{
    public interface IRoleService 
    {
        public  bool CreateRole(string roleName);
        public bool RemoveRole(int roleId);
        public IEnumerable<Role> ViewRoles();

    }
}