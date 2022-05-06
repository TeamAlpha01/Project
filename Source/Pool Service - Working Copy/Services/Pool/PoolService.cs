using IMS.Models;
using IMS.Validations;
using IMS.DataAccessLayer;
using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace IMS.Services
{
    public class PoolService:IPoolService
    {
        private IPoolDataAccessLayer _poolDataAccessLayer;
      
        private readonly ILogger _logger;
        public PoolService(ILogger logger)
        {
            _logger = logger;
            _poolDataAccessLayer = DataFactory.PoolDataFactory.GetPoolDataAccessLayerObject(_logger);
     
      

        public bool CreatePool( int departmentId,string poolName)
        {
    
           private Pool _pool = DataFactory.PoolDataFactory.GetPoolObject(); 
           PoolValidation.IsCreatePoolValid(departmentId,poolName);
            try
            {
                _pool.PoolName = poolName;
                _pool.DepartmentId=departmentId;
                return _poolDataAccessLayer.AddPoolToDatabase(_pool) ? true : false; // LOG Error in DAL;
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

        /*  
            Returns False when Exception occured in Data Access Layer
            
            Throws ArgumentNullException when Pool Id is not passed to this service method
        */

        public bool RemovePool(int poolId)
        {
           PoolValidation.IsRemovePoolValid(poolId);

            try
            {
                return _poolDataAccessLayer.RemovePoolFromDatabase(poolId) ? true :false; // LOG Error in DAL;
            }
            catch (ArgumentException exception)
            {
                _logger.LogInformation($"Pool service : RemoveLocation(int departmentId,int poolId) : {exception.Message}");
                return false;
            }
            catch (ValidationException poolNotFound)
            {
                _logger.LogInformation($"Pool service : RemoveLocation(int departmentId,int poolId) : {poolNotFound.Message}");
                throw poolNotFound;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Pool service : RemoveLocation(int departmentId,int poolId):{exception.Message}");
                return false;
            }
           
        }
        public bool EditPool(int poolId,string poolName)
        {
            PoolValidation.IsEditPoolValid(poolId,poolName);
           

             try
             {
                 return _poolDataAccessLayer.EditPoolFromDatabase(poolId,poolName)?true:false;
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
            PoolValidation.IsVaLidDepartmentId(int departmentId);
            try
            {
                IEnumerable<Pool> Pools = new List<Pool>(departmentId);
                return Pools = from Pool in _poolDataAccessLayer.GetPoolsFromDatabase(departmentId) where Pool.IsActive == true select Pool;
            }
           catch (Exception exception)
            {
                _logger.LogInformation($"Pool Service:ViewPools(int departmentId): {exception.Message}");
                throw new Exception();
            }

        }
    

         public bool AddPoolMembers (int employeeId, int poolId)
        {
            private PoolMembers _poolMembers = DataFactory.PoolDataFactory.GetPoolMembersObject();
            
            try
            {
                _PoolMembers.EmployeeId=employeeId;
                _PoolMembers.PoolId = poolId;
                return _poolDataAccessLayer.AddPoolMembersToDatabase(_PoolMembers) ? true : false; // LOG Error in DAL;
            }
           catch (ArgumentException exception)
            {
                _logger.LogInformation($"Pool service : AddPoolMembers(int employeeId,int poolId) : {exception.Message}");
                return false;
            }
            catch (ValidationException poolMemberNotException)
            {
            _logger.LogInformation($"Pool Service :AddPoolMembers(int employeeId,int poolId) {poolMemberNotException.Message}");
             throw poolMemberNotException;
            }
            
            catch (Exception exception)
            {
                _logger.LogInformation($"Pool service : AddPoolMembers(int employeeId,int poolId) : {exception.Message}");
                return false;
            }
        }

        //     public bool RemovePoolMembers (int EmployeeID, int PoolId)
        // {
        //     if (EmployeeID == 0 || PoolId == 0)
        //         throw new ArgumentNullException("PoolID is not provided");

        //     try
        //     {
                
        //         return _PoolDataAccessLayer.RemovePoolMembersFromDatabase(EmployeeID,PoolId) ? true : false; // LOG Error in DAL;
        //     }
        //     catch (Exception exception)
        //     {
        //         // Log "Exception Occured in Data Access Layer"
        //         return false;
        //     }
        // } 
        // public IEnumerable<PoolMembers> ViewPoolMembers(int PoolId)
        // {
        //     try
        //     {
        //         IEnumerable<PoolMembers> poolMembers = new List<PoolMembers>();
        //         return poolMembers = from PoolMembers in _PoolDataAccessLayer.GetPoolMembersFromDatabase(PoolId) where PoolMembers.IsActive == true select PoolMembers;
        //     }
            
        //     catch (Exception exception)
        //     {
        //         //Log "Exception occured in DAL while fetching Pools"
        //         throw new Exception();
        //     }
        // }



    }
}