using IMS.Models;
using IMS.Validations;
using IMS.DataAccessLayer;
using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace IMS.Service
{
    public class PoolService : IPoolService
    {
        private IPoolDataAccessLayer _poolDataAccessLayer;

        private readonly ILogger _logger;

        public PoolService(ILogger<IPoolService> logger,IPoolDataAccessLayer poolDataAccessLayer)
        {
            _logger = logger;
            _poolDataAccessLayer = poolDataAccessLayer; //DataFactory.PoolDataFactory.GetPoolDataAccessLayerObject(_logger);
        }

        /// <summary>
        /// This method will be implemented when Pool Controller Passes the Pool Name, Pool Id to the service Layer. And controll Shifts to Pool DAL.
        /// </summary>
        /// <param name="departmentId">int</param>
        /// <param name="poolName">string</param>
        /// <returns>Return True or False to the Pool Controller Layer</returns>
        public bool CreatePool(int departmentId, string poolName)

        {
            Pool _pool = DataFactory.PoolDataFactory.GetPoolObject();
            PoolValidation.IsCreatePoolValid(departmentId, poolName);

            try
            {
                _pool.DepartmentId = departmentId;
                _pool.PoolName = poolName;
                return _poolDataAccessLayer.AddPoolToDatabase(_pool) ? true : false;

            }
            catch (ArgumentException exception)
            {
                _logger.LogInformation($"Pool service : CreatePool(int departmentId,string poolName) : {exception.Message}");
                return false;
            }
            catch (ValidationException departmentNotFound)
            {

                _logger.LogInformation($"Pool service : CreatePool(int departmentId,string poolName) : {departmentNotFound.Message}");
                throw departmentNotFound;
            }

            catch (Exception exception)
            {
                _logger.LogInformation($"Pool service : CreatePool(int departmentId,string poolName) : {exception.Message}");
                return false;
            }


        }

        /// <summary>
        ///  This method will be implemented when Pool Controller Passes the Pool Id to the service Layer. And controll Shifts to Pool DAL.
        /// </summary>
        /// <param name="poolId">int</param>
        /// <returns>Return True or False to the Pool Controller Layer</returns>
        public bool RemovePool(int poolId)
        {
            PoolValidation.IsRemovePoolValid(poolId);

            try
            {
                return _poolDataAccessLayer.RemovePoolFromDatabase(poolId) ? true : false; // LOG Error in DAL;
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

        /// <summary>
        ///  This method will be implemented when Pool Controller Passes the Pool Id, Pool name to the service Layer for Renaming the pool. And controll Shifts to Pool DAL.
        /// </summary>
        /// <param name="poolId">int</param>
        /// <param name="poolName">string</param>
        /// <returns>>Return True or False to the Pool Controller Layer</returns>
        public bool EditPool(int poolId, string poolName)
        {
            PoolValidation.IsEditPoolValid(poolId, poolName);


            try
            {
                return _poolDataAccessLayer.EditPoolFromDatabase(poolId, poolName) ? true : false;
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
        

        /// <summary>
        /// This method will be implemented when Pool Controller Passes the Department Id to the service Layer to view all pools. And controll Shifts to Pool DAL.
        /// </summary>
        /// <param name="departmentId">int</param>
        /// <returns></returns>
        public object ViewPools()
        {
            try
            {
                return (from pool in _poolDataAccessLayer.GetPoolsFromDatabase() where pool.IsActive == true select pool).Select(
                    p => new{
                        poolId=p.PoolId,
                        poolName=p.PoolName,
                        departmentId=p.DepartmentId,
                        departmentName=p.department.DepartmentName
                    }
                );
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
        public object ViewPoolsByID(int employeeId)
        {
            try
            {
                 return _poolDataAccessLayer.GetPoolsFromDatabase(employeeId).Select(
                poolMembers=>new
                {
                     employeePool=poolMembers.Pools.PoolName
                    // employeeAceNumber=poolMembers.Employees.EmployeeAceNumber,
                    // employeeName=poolMembers.Employees.Name,
                    // employeeRole=poolMembers.Employees.Role.RoleName


                }
                 );
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
        

        

        /// <summary>
        /// This method will be implemented when Pool Controller Passes the Employee Id, PoolId to the service Layer to add a member to the pool. And controll Shifts to Pool DAL.
        /// </summary>
        /// <param name="employeeId">int</param>
        /// <param name="poolId">int</param>
        /// <returns>Return true or false for the Pool controller</returns>

        public bool AddPoolMember(int employeeId, int poolId)
        {
            PoolMembers _poolMembers = DataFactory.PoolDataFactory.GetPoolMembersObject();
            PoolValidation.IsAddPoolMembersValid(employeeId, poolId);

            try
            {
                _poolMembers.EmployeeId = employeeId;
                _poolMembers.PoolId = poolId;
                return _poolDataAccessLayer.AddPoolMembersToDatabase(_poolMembers) ? true : false; // LOG Error in DAL;
            }
            catch (ArgumentException exception)
            {
                _logger.LogInformation($"Pool service : AddPoolMembers(int employeeId,int poolId) : {exception.Message}");
                return false;
            }
            catch (ValidationException employeeNotFound)
            {
                _logger.LogInformation($"Pool service : AddPoolMembers(int employeeId,int poolId): {employeeNotFound.Message}");
                throw employeeNotFound;
            }


            catch (Exception exception)
            {
                _logger.LogInformation($"Pool service : AddPoolMembers(int employeeId,int poolId) : {exception.Message}");
                return false;
            }

        }

        /// <summary>
        /// This method will be implemented when Pool Controller Passes the Pool Member Id to the service Layer to remove a member to the pool. And controll Shifts to Pool DAL.
        /// </summary>
        /// <param name="poolMemberId">int</param>
        /// <returns>Return true or false for the Pool controller</returns>
        public bool RemovePoolMember(int poolMemberId)
        {
            PoolValidation.IsRemovePoolMembersValid(poolMemberId);

            try
            {
                return _poolDataAccessLayer.RemovePoolMembersFromDatabase(poolMemberId) ? true : false; // LOG Error in DAL;
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

        /// <summary>
        /// This method is implemented when Pool Controller Passes the Pool Id to the service Layer to View all pool members. And controll Shifts to Pool DAL.
        /// </summary>
        /// <param name="poolId">int</param>
        /// <returns></returns>
        /// 
        public Object ViewPoolMembers(int poolId)
        {
            PoolValidation.IsPoolIdValid(poolId);
       
        try
        {
            return _poolDataAccessLayer.GetPoolMembersFromDatabase(poolId).Select(
                poolMembers=>new
                {
                    employeeAceNumber=poolMembers.Employees.EmployeeAceNumber,
                    employeeName=poolMembers.Employees.Name,
                    employeeRole=poolMembers.Employees.Role.RoleName


                }
            );
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













