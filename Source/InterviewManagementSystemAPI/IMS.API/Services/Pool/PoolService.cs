using IMS.Models;
using IMS.Validations;
using IMS.DataAccessLayer;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Diagnostics;
namespace IMS.Service
{
    public class PoolService : IPoolService
    {
        private IPoolDataAccessLayer _poolDataAccessLayer;

        private readonly ILogger _logger;
        
        private readonly Stopwatch _stopwatch = new Stopwatch();
        private bool IsTracingEnabled;

        public PoolService(ILogger<IPoolService> logger,IPoolDataAccessLayer poolDataAccessLayer)
        {
            _logger = logger;
            _poolDataAccessLayer = poolDataAccessLayer; 
        }

        /// <summary>
        /// This method will be implemented when Pool Controller Passes the Pool Name, Pool Id to the service Layer. And controll Shifts to Pool DAL.
        /// </summary>
        /// <param name="departmentId">int</param>
        /// <param name="poolName">string</param>
        /// <returns>Return True or False to the Pool Controller Layer</returns>
        public bool CreatePool(int departmentId, string poolName)

        {
            _stopwatch.Start();
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
                _logger.LogError($"Pool service : CreatePool(int departmentId,string poolName) : {exception.Message}");
                return false;
            }
            catch (ValidationException departmentNotFound)
            {

                _logger.LogError($"Pool service : CreatePool(int departmentId,string poolName) : {departmentNotFound.Message}");
                throw departmentNotFound;
            }

            catch (Exception exception)
            {
                _logger.LogError($"Pool service : CreatePool(int departmentId,string poolName) : {exception.Message}");
                return false;
            }
            
            finally
            {
                _stopwatch.Stop();
                _logger.LogError($"Pool Service Time elapsed for  CreatePool(int departmentId, string poolName) :{_stopwatch.ElapsedMilliseconds}ms");
            }

        }

        /// <summary>
        ///  This method will be implemented when Pool Controller Passes the Pool Id to the service Layer. And controll Shifts to Pool DAL.
        /// </summary>
        /// <param name="poolId">int</param>
        /// <returns>Return True or False to the Pool Controller Layer</returns>
        public bool RemovePool(int poolId)
        {
            _stopwatch.Start();
            PoolValidation.IsRemovePoolValid(poolId);

            try
            {
                return _poolDataAccessLayer.RemovePoolFromDatabase(poolId) ? true : false; // LOG Error in DAL;
            }
            catch (ArgumentException exception)
            {
                _logger.LogError($"Pool service : RemovePool(int poolId) : {exception.Message}");
                return false;
            }
            catch (ValidationException poolNotFound)
            {
                _logger.LogError($"Pool service : RemovePool(int poolId): {poolNotFound.Message}");
                throw poolNotFound;
            }

            catch (Exception exception)
            {
                _logger.LogError($"Pool service : RemovePool(int poolId):{exception.Message}");
                return false;
            }
            
            finally
            {
                _stopwatch.Stop();
                _logger.LogError($"Pool Service Time elapsed for  RemovePool(int poolId) :{_stopwatch.ElapsedMilliseconds}ms");
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
            _stopwatch.Start();
            PoolValidation.IsEditPoolValid(poolId, poolName);


            try
            {
                return _poolDataAccessLayer.EditPoolFromDatabase(poolId, poolName) ? true : false;
            }
            catch (ArgumentException exception)
            {
                _logger.LogError($"Pool service : EditPool(int poolId,string poolName) : {exception.Message}");
                return false;
            }
            catch (ValidationException poolNotFound)
            {
                _logger.LogError($"Pool service :EditPool(int poolId,string poolName): {poolNotFound.Message}");
                throw poolNotFound;
            }
            catch (Exception exception)
            {
                _logger.LogError($"Pool service : EditPool(int poolId,string poolName):{exception.Message}");
                return false;
            }
            
            finally
            {
                _stopwatch.Stop();
                _logger.LogError($"Pool Service Time elapsed for  EditPool(int poolId, string poolName) :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }
        

        /// <summary>
        /// This method will be implemented when Pool Controller Passes the Department Id to the service Layer to view all pools. And controll Shifts to Pool DAL.
        /// </summary>
        /// <returns>Returns list of pools</returns>
        public object ViewPools()
        {
            _stopwatch.Start();
            try
            {
                return _poolDataAccessLayer.GetPoolsFromDatabase().Select(
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
                _logger.LogError($"Pool service :EditPool(int poolId,string poolName): {departmentNotFound.Message}");
                throw departmentNotFound;
            }
            catch (Exception exception)
            {
                _logger.LogError($"Pool Service:ViewPools(int departmentId): {exception.Message}");
                throw new Exception();
            }
            
            finally
            {
                _stopwatch.Stop();
                _logger.LogError($"Pool Service Time elapsed for  ViewPools() :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }
        /// <summary>
        /// /// This method will be implemented when Pool Controller Passes the Employee Id to the service Layer to view pools by employee id. And controll Shifts to Pool DAL.
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns>Returns list of pool by employee id</returns>
        public object ViewPoolsByID(int employeeId)
        {
            _stopwatch.Start();
            try
            {
                 return _poolDataAccessLayer.GetPoolsFromDatabase(employeeId).Select(
                poolMembers=>new
                {
                     employeesUnderPool=poolMembers.Pools!.PoolName,
                     PoolId=poolMembers.Pools.PoolId
                }
               );
            }
            catch (ValidationException departmentNotFound)
            {
                _logger.LogError($"Pool service :EditPool(int poolId,string poolName): {departmentNotFound.Message}");
                throw departmentNotFound;
            }
            catch (Exception exception)
            {
                _logger.LogError($"Pool Service:ViewPools(int departmentId): {exception.Message}");
                throw new Exception();
            }
            
            finally
            {
                _stopwatch.Stop();
                _logger.LogError($"Pool Service Time elapsed for  ViewPoolsByID(int employeeId) :{_stopwatch.ElapsedMilliseconds}ms");
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
            _stopwatch.Start();
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
                _logger.LogError($"Pool service : AddPoolMembers(int employeeId,int poolId) : {exception.Message}");
                return false;
            }
            catch (ValidationException employeeNotFound)
            {
                _logger.LogError($"Pool service : AddPoolMembers(int employeeId,int poolId): {employeeNotFound.Message}");
                throw employeeNotFound;
            }


            catch (Exception exception)
            {
                _logger.LogError($"Pool service : AddPoolMembers(int employeeId,int poolId) : {exception.Message}");
                return false;
            }
            
            finally
            {
                _stopwatch.Stop();
                _logger.LogError($"Pool Service Time elapsed for  AddPoolMember(int employeeId, int poolId) :{_stopwatch.ElapsedMilliseconds}ms");
            }

        }

        /// <summary>
        /// This method will be implemented when Pool Controller Passes the Pool Member Id to the service Layer to remove a member to the pool. And controll Shifts to Pool DAL.
        /// </summary>
        /// <param name="poolMemberId">int</param>
        /// <returns>Return true or false for the Pool controller</returns>
        public bool RemovePoolMember(int poolMemberId)
        {
            _stopwatch.Start();
            PoolValidation.IsRemovePoolMembersValid(poolMemberId);

            try
            {
                return _poolDataAccessLayer.RemovePoolMembersFromDatabase(poolMemberId) ? true : false; // LOG Error in DAL;
            }
            catch (ArgumentException exception)
            {
                _logger.LogError($"Pool service : RemoveLocation(int departmentId,int poolId) : {exception.Message}");
                return false;
            }
            catch (ValidationException poolMemberNotException)

            {
                _logger.LogError($"Pool service : RemoveLocation(int departmentId,int poolId) : {poolMemberNotException.Message}");
                throw poolMemberNotException;
            }
            catch (Exception exception)
            {
                _logger.LogError($"Pool service : RemoveLocation(int departmentId,int poolId):{exception.Message}");
                return false;
            }
            
            finally
            {
                _stopwatch.Stop();
                _logger.LogError($"Pool Service Time elapsed for  RemovePoolMember(int poolMemberId) :{_stopwatch.ElapsedMilliseconds}ms");
            }

        }

        /// <summary>
        /// This method is implemented when Pool Controller Passes the Pool Id to the service Layer to View all pool members. And controll Shifts to Pool DAL.
        /// </summary>
        /// <param name="poolId">int</param>
        /// <returns>Returns list of poolmembers by pool id</returns>
        
        public Object ViewPoolMembers(int poolId)
        {
            _stopwatch.Start();
            PoolValidation.IsPoolIdValid(poolId);
       
        try
        {
            return _poolDataAccessLayer.GetPoolMembersFromDatabase(poolId).Select(
                poolMembers=>new
                {
                    poolId=poolMembers.PoolId,
                    poolMemberId=poolMembers.PoolMembersId,
                    employeeAceNumber=poolMembers.Employees!.EmployeeAceNumber,
                    employeeName=poolMembers.Employees.Name,
                    employeeRole=poolMembers.Employees.Role!.RoleName


                }
            );
        }
        catch (ValidationException poolNotFound)
            {
                _logger.LogError($"Pool service :ViewPoolMembers (int poolId): {poolNotFound.Message}");
                throw poolNotFound;
            }

            catch (Exception exception)
            {
                _logger.LogError($"Pool Service:ViewPoolMembers(int poolId): {exception.Message}");
                throw new Exception();
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogError($"Pool Service Time elapsed for  ViewPoolMembers(int poolId) :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }

    }
}













