using IMS.Controllers;
using IMS.DataAccessLayer;
using IMS.Models;
using IMS.Service;
namespace IMS.DataFactory{
    public static class RoleDataFactory
    {
        public static IRoleDataAccessLayer GetRoleDataAccessLayerObject(ILogger logger)
        {
            return new RoleDataAccessLayer(logger);
        }
        public static IRoleService GetRoleServiceObject(ILogger logger)
        {            
            return new RoleService(logger);
        }
        public static Role GetRoleObject()
        {
            return new Role();
        }

    }
}