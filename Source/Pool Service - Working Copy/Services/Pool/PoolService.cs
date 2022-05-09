using IMS.Models;
using IMS.Validations;
using IMS.DataAccessLayer;
using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace IMS.Services
{
    public class PoolService : IPoolService
    {
        private IPoolDataAccessLayer _poolDataAccessLayer;
       
        private readonly ILogger _logger;
        public PoolService(ILogger logger)
        {
            _logger = logger;
             _poolDataAccessLayer= DataFactory.PoolDataFactory.GetPoolDataAccessLayerObject(_logger);
        }
        public bool CreatePool(int departmentId,string poolName)
        
        {
            
            Pool _pool=DataFactory.PoolDataFactory.GetPoolObject();
            PoolValidation.IsCreatePoolValid(departmentId,poolName);

            try
            {
               _pool.DepartmentId=departmentId;
               _pool.PoolName=poolName; 
               return _poolDataAccessLayer.AddPoolToDatabase(_pool) ? true : false;
              
            }
            catch (ArgumentException exception)
            {
                _logger.LogInformation($"Pool service : CreatePool(int departmentId,string poolName) : {exception.Message}");
                return false;
            }
           
          
            catch (Exception exception)
            {
                _logger.LogInformation($"Pool service : CreatePool(int departmentId,string poolName) : {exception.Message}");
                return false;
            }
            

        }
        public bool RemovePool(int poolId)
        {
           PoolValidation.IsRemovePoolValid(poolId);

            try
            {
                return _poolDataAccessLayer.RemovePoolFromDatabase(poolId) ? true :false; // LOG Error in DAL;
            }
            catch (ArgumentException exception)
            {
                _logger.LogInformation($"Pool service : RemovePool(int poolId) : {exception.Message}");
                return false;
            }
            catch (ValidationException poolNotFound)
            {
                _logger.LogInformation($"Pool service : RemovePool(int poolId): {poolNotFound.Message}");
                throw poolNotFound;
            }
             
            catch (Exception exception)
            {
                _logger.LogInformation($"Pool service : RemovePool(int poolId):{exception.Message}");
                return false;
            }
           
        }
         public bool EditPool(int poolId,string poolName)
        {
            PoolValidation.IsEditPoolValid(poolId,poolName);
           

             try
             {
                 return _poolDataAccessLayer.EditPoolFromDatabase(poolId,poolName)? true:false;
             } 
             catch (ArgumentException exception)
            {
                _logger.LogInformation($"Pool service : EditPool(int poolId,string poolName) : {exception.Message}");
                return false;
            }
            catch (ValidationException poolNotFound)
            {
                _logger.LogInformation($"Pool service :EditPool(int poolId,string poolName): {poolNotFound.Message}");
                throw poolNotFound;
            }
              catch (Exception exception)
            {
                _logger.LogInformation($"Pool service : EditPool(int poolId,string poolName):{exception.Message}");
                return false;
            }
           
           

        }
        public IEnumerable<Pool> ViewPools(int departmentId)
        {

          PoolValidation.IsValidDepartmentId(departmentId);
            try
            {
            IEnumerable<Pool> pools = new List<Pool>();
            return pools=from pool in _poolDataAccessLayer.GetPoolsFromDatabase(departmentId) where pool.DepartmentId==departmentId && pool.IsActive == true select pool;
               
            }
            catch (ValidationException departmentNotFound)
            {
                _logger.LogInformation($"Pool service :EditPool(int poolId,string poolName): {departmentNotFound.Message}");
                throw departmentNotFound;
            }
           catch (Exception exception)
            {
                _logger.LogInformation($"Pool Service:ViewPools(int departmentId): {exception.Message}");
                throw new Exception();
            }

        }
         public bool AddPoolMembers (int employeeId, int poolId)
        {
             PoolMembers _poolMembers = DataFactory.PoolDataFactory.GetPoolMembersObject();
             PoolValidation.IsAddPoolMembersValid(employeeId,poolId);
            
            try
            {
                _poolMembers.EmployeeId=employeeId;
                _poolMembers.PoolId = poolId;
                return _poolDataAccessLayer.AddPoolMembersToDatabase(_poolMembers) ? true : false; // LOG Error in DAL;
            }
           catch (ArgumentException exception)
            {
                _logger.LogInformation($"Pool service : AddPoolMembers(int employeeId,int poolId) : {exception.Message}");
                return false;
            }
           
            
            catch (Exception exception)
            {
                _logger.LogInformation($"Pool service : AddPoolMembers(int employeeId,int poolId) : {exception.Message}");
                return false;
            }
        
         }
         public bool RemovePoolMembers(int poolMemberId)
         {
             PoolValidation.IsRemovePoolMembersValid(poolMemberId);

            try
            {
                return _poolDataAccessLayer.RemovePoolFromDatabase(poolMemberId) ? true :false; // LOG Error in DAL;
            }
            catch (ArgumentException exception)
            {
                _logger.LogInformation($"Pool service : RemoveLocation(int departmentId,int poolId) : {exception.Message}");
                return false;
            }
          catch (ValidationException poolMemberNotException)

            {
                _logger.LogInformation($"Pool service : RemoveLocation(int departmentId,int poolId) : {poolMemberNotException.Message}");
                throw poolMemberNotException;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Pool service : RemoveLocation(int departmentId,int poolId):{exception.Message}");
                return false;
            }

         }
       public IEnumerable<PoolMembers> ViewPoolMembers (int poolId)
        {

          PoolValidation.IsValidPoolId(poolId);
            try
            {
            IEnumerable<PoolMembers> poolmembers = new List<PoolMembers>();
            return poolmembers=from poolmember in _poolDataAccessLayer.GetPoolMembersFromDatabase(poolId) where poolmember.PoolId==poolId && pool.Isactive==true select poolmember;
                
            }
             catch (ValidationException poolNotFound)
            {
                _logger.LogInformation($"Pool service :ViewPoolMembers (int poolId): {poolNotFound.Message}");
                throw poolNotFound;
            }

           catch (Exception exception)
            {
                _logger.LogInformation($"Pool Service:ViewPoolMembers(int poolId): {exception.Message}");
                throw new Exception();
            }
        }

    }
}



         
        

    




    

