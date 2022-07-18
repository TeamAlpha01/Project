using IMS.Controllers;
using IMS.DataAccessLayer;
using IMS.Models;
using IMS.Service;
namespace IMS.DataFactory{
    public static class RoleDataFactory
    {
        public static IRoleDataAccessLayer GetRoleDataAccessLayerObject(ILogger<RoleDataAccessLayer> logger,InterviewManagementSystemDbContext dbContext,IConfiguration configuration)
        {
            return new RoleDataAccessLayer(logger,dbContext,configuration);
        }
        public static IRoleService GetRoleServiceObject(ILogger<RoleService> logger,IRoleDataAccessLayer roleDataAccessLayer)
        {            
            return new RoleService(logger,roleDataAccessLayer);
        }
        public static Role GetRoleObject()
        {
            return new Role();
        }

    }
}