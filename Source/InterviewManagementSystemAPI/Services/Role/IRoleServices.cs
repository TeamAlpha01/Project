using IMS.Models;

namespace IMS.Service{
    public interface IRoleService 
    {
        public  bool CreateRole(string roleName);
        public bool RemoveRole(int roleId);
        public IEnumerable<Role> ViewRoles();

    }
}