using IMS.Models;

namespace IMS.Service{
    public interface IRoleService 
    {
        public  bool CreateRole(Role role );
        public bool RemoveRole(Role role);
        public IEnumerable<Role> ViewRoles();

    }
}