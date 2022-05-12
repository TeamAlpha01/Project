using IMS.DataAccessLayer;
using IMS.Models;
using IMS.Services;
namespace IMS.DataFactory{
    public static class PoolDataFactory
    {
        public static IPoolDataAccessLayer GetPoolDataAccessLayerObject(ILogger _logger)
        {
            return new PoolDataAccessLayer(_logger);
        }
        public static IPoolService GetPoolServiceObject(ILogger _logger)
        {
             return new PoolService(_logger);
           
        }
        public static Pool GetPoolObject()
        {
            return new Pool();
        }
        
        public static PoolMembers GetPoolMembersObject()
        {
            return new PoolMembers();
        }

    }
}