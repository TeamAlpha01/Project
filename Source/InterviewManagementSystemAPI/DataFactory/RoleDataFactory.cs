using Source.DataAccessLayer;
using Source.Service;
namespace Source.DataFactory{
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
    }
}