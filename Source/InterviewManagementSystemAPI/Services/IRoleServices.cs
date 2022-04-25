using Source.Models;

namespace Source.Service{
    public interface IRoleService 
    {
        public  bool CreateRole(string roleName);
        public bool RemoveRole(int roleId);
        public List<Role> ViewRoles();

    }
}