using IMS.DataAccessLayer;
using IMS.Models;
using IMS.Service;
namespace IMS.DataFactory{
    public static class RoleDataFactory
    {
        public static IRoleDataAccessLayer GetRoleDataAccessLayerObject()
        {
            return new RoleDataAccessLayer();
        }
        public static IRoleService GetRoleServiceObject()
        {            
            return new RoleService();
        }
        public static Role GetRoleObject()
        {
            return new Role();
        }

    }
}