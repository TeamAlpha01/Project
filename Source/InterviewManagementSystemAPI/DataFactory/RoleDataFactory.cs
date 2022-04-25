using InterviewManagementSystemAPI.DataAccessLayer;
using InterviewManagementSystemAPI.Models;
using InterviewManagementSystemAPI.Service;
namespace InterviewManagementSystemAPI.DataFactory{
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