using IMS.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using IMS.Validations;
namespace IMS.DataAccessLayer
{
    public class PoolDataAccessLayer : IPoolDataAccessLayer

    {
        private InterviewManagementSystemDbContext _db; // = DataFactory.DbContextDataFactory.GetInterviewManagementSystemDbContextObject();
        private ILogger _logger;

        public PoolDataAccessLayer(ILogger<IPoolDataAccessLayer> logger,InterviewManagementSystemDbContext dbContext)
        {
            _logger = logger;
            _db = dbContext;
        }

        /// <summary>
        /// This method is implemented when the Service layer shifts the control and parameters to Pool DAL. 
        /// Pool DAL Perform the interaction with Database and Respond to the Add Pool to Database request.
        /// </summary>
        /// <param name="pool">object</param>
        /// <returns>Returns true or Exception message when any misconnection in database</returns>
        public bool AddPoolToDatabase(Pool pool)
        {

            PoolValidation.IsAddPoolValid(pool);
            if (_db.Pools.Any(p => p.PoolName == pool.PoolName && p.DepartmentId == pool.DepartmentId && p.IsActive == true)) throw new ValidationException("Pool Name already exists under this pool");
            try
            {
                var department=_db.Pools.Find(pool.DepartmentId);
                if(department==null)
                    throw new ValidationException("Department not found with the given Department Id");
                if(_db.Pools.Any(p => p.PoolName == pool.PoolName && p.DepartmentId == pool.DepartmentId && p.IsActive == false))
                {
                pool.IsActive = true;
                _db.Pools.Update(pool);
                _db.SaveChanges();
                return true;
                }
                else{
                _db.Pools.Add(pool);
                _db.SaveChanges();
                return true;
                }
            }
            catch (DbUpdateException exception)
            {
                _logger.LogInformation($"Pool DAL : AddPoolToDatabase(Pool pool) : {exception.Message}");
                return false;
            }
            catch (OperationCanceledException exception)
            {
                _logger.LogInformation($"Pool DAL : AddPoolToDatabase(Pool pool) : {exception.Message}");
                return false;
            }
            catch(ValidationException departmentNotFound)
            {
                throw departmentNotFound;
            }

            catch (Exception exception)
            {
                _logger.LogInformation($"Pool DAL : AddPoolToDatabase(Pool pool)  : {exception.Message}");
                return false;
            }

        }

        /// <summary>
        /// This method is implemented when the Service layer shifts the control and parameters to Pool DAL. 
        /// Pool DAL Perform the interaction with Database and Respond to the Remove Pool from Database request.
        /// </summary>
        /// <param name="poolId">int</param>
        /// <returns>Returns true or Exception message when any misconnection in database</returns>
        /// 
        public bool RemovePoolFromDatabase(int poolId)
        {
            PoolValidation.IsValidPoolId(poolId);

            bool isDeletePoolId = _db.Pools.Any(x => x.PoolId == poolId && x.IsActive == false);
            if (isDeletePoolId)
            {
                throw new ValidationException("Pool already deleted");
            }
            try
            {
                
                var Pool = _db.Pools.Find(poolId);
                if (poolId == null)
                    throw new ValidationException("No Pool  is found with given Pool Id");

                Pool.IsActive = false;
                _db.Pools.Update(Pool);
                _db.SaveChanges();
                return true;
            }
            catch (DbUpdateException exception)
            {
                _logger.LogInformation($"Pool DAL : RemovePoolFromDatabase(int departmentId,int poolId) : {exception.Message}");
                return false;
            }
            catch (OperationCanceledException exception)
            {
                _logger.LogInformation($"Pool DAL : RemovePoolFromDatabase(int departmentId,int poolId) : {exception.Message}");
                return false;
            }
            catch (ValidationException poolNotFound)
            {
                throw poolNotFound;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Pool DAL : RemovePoolFromDatabase(int departmentId,int poolId) : {exception.Message}");
                return false;
            }

        }

        /// <summary>
        /// This method is implemented when the Service layer shifts the control and parameters to Pool DAL. 
        /// Pool DAL Perform the interaction with Database and Respond to the Rename a Pool from Database request.
        /// </summary>
        /// <param name="poolId">int</param>
        /// <param name="poolName">string</param>
        /// <returns>Return true or Throws Exception : No pool is found with given Pool Id or The given pool Id is inactive,so unable to rename the pool</returns>
        /// Catches exceptions thorwed by Database if any Misconnections in DB

        public bool EditPoolFromDatabase(int poolId, string poolName)
        {
            PoolValidation.IsEditPoolValid(poolId, poolName);
            try
            {

                var edit = _db.Pools.Find(poolId);
                if (edit == null)
                    throw new ValidationException("No pool is found with given Pool Id");
                else if (edit.IsActive == false)
                    throw new ValidationException("The given pool Id is inactive,so unable to rename the pool");

                edit.PoolName = poolName;
                _db.Pools.Update(edit);
                _db.SaveChanges();
                return true;

            }
            catch (DbUpdateException exception)
            {
                _logger.LogInformation($"Pool DAL : EditPoolFromDatabase(int poolId,string poolName) : {exception.Message}");
                return false;
            }
            catch (OperationCanceledException exception)
            {
                _logger.LogInformation($"Pool DAL : EditPoolFromDatabase(int poolId,string poolName) : {exception.Message}");
                return false;
            }
            catch (ValidationException poolNotFound)
            {
                throw poolNotFound;
            }

            catch (Exception exception)
            {
                _logger.LogInformation($"Pool DAL : EditPoolFromDatabase(int poolId,string poolName) : {exception.Message}");

                return false;
            }


        }

        /// <summary>
        /// This method is implemented when the Service layer shifts the control and parameters to Pool DAL. 
        /// Pool DAL Perform the interaction with Database and Respond to the Get Pools from Database request.
        /// </summary>
        /// <param name="departmentId">int</param>
        /// <returns>Return list of pools from database or Throws Exception : No pool is found with given department Id</returns>
        /// Catches exceptions thorwed by Database if any Misconnections in DB </returns>

        public List<Pool> GetPoolsFromDatabase()
        {

            try
            {
                return _db.Pools.ToList();
            }
            catch (DbUpdateException exception)
            {
                _logger.LogInformation($"Pool DAL : GetPoolsFromDatabase() : {exception.Message}");
                throw new DbUpdateException();
            }
            catch (OperationCanceledException exception)
            {
                _logger.LogInformation($"Pool DAL : GetPoolsFromDatabase() : {exception.Message}");
                throw new OperationCanceledException();
            }
            catch (ValidationException departmentNotFound)
            {
                throw departmentNotFound;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Pool DAL : GetPoolsFromDatabase() : {exception.Message}");
                throw new Exception();
            }
        }

        /// <summary>
        /// This method is implemented when the Service layer shifts the control and parameters to Pool DAL. 
        /// Pool DAL Perform the interaction with Database and Respond to the Add members to Pools request.
        /// </summary>
        /// <param name="poolMembers">object</param>
        /// <returns>Return true or  Catches exceptions thorwed by Database if any Misconnections in DB</returns>
        public bool AddPoolMembersToDatabase(PoolMembers poolMembers)
        {
            PoolValidation.IsAddPoolMemberValid(poolMembers);

            try
            {
                var employee=_db.Employees.Find(poolMembers.EmployeeId);
                var pool =_db.Employees.Find(poolMembers.PoolId);
                if(employee==null || pool==null)
                    throw new ValidationException("Employee or pool not found with the given Employee Id and Pool Id");
                bool poolMemberAlreadyExists = _db.PoolMembers.Any(x => x.EmployeeId == poolMembers.EmployeeId && x.PoolId==poolMembers.PoolId && x.IsActive == true);    
                if(!poolMemberAlreadyExists)
                {
                _db.PoolMembers.Add(poolMembers);
                _db.SaveChanges();
                return true;
                }
                else
                 throw new ValidationException("Pool Member already exists in the given Pool Id");
               

            }
            catch (DbUpdateException exception)
            {
                _logger.LogInformation($"Pool DAL : AddPoolMembersToDatabase(PoolMembers poolMembers) : {exception.Message}");
                return false;
            }
            catch (OperationCanceledException exception)
            {
                _logger.LogInformation($"Pool DAL : AddPoolMembersToDatabase(PoolMembers poolMembers): {exception.Message}");
                return false;
            }
            catch (ValidationException employeeNotFound)
            {
                throw employeeNotFound;
            }

            catch (Exception exception)
            {
                _logger.LogInformation($"Pool DAL : AddPoolMembersToDatabase(PoolMembers poolMembers)  : {exception.Message}");
                return false;
            }


        }

        /// <summary>
        /// This method is implemented when the Service layer shifts the control and parameters to Pool DAL. 
        /// Pool DAL Perform the interaction with Database and Respond to the Remove members to Pools request.
        /// </summary>
        /// <param name="poolMemberId">int</param>
        /// <returns>Return true or  Catches exceptions thorwed by Database if any Misconnections in DB</returns>
        public bool RemovePoolMembersFromDatabase(int poolMemberId)
        {
            PoolValidation.IsRemovePoolMembersValid(poolMemberId);
             bool isPoolMemberId = _db.PoolMembers.Any(x => x.PoolMembersId == poolMemberId && x.IsActive == false);
            if (isPoolMemberId)
            {
                throw new ValidationException("PoolMember already deleted");
            }

            try
            {
                var employee = _db.PoolMembers.Find(poolMemberId);
                if (employee == null)
                    throw new ValidationException("PoolMember not found with the given PoolMember Id");

                employee.IsActive = false;
                _db.PoolMembers.Update(employee);
                _db.SaveChanges();
                return true;
            }
            catch (DbUpdateException exception)
            {
                _logger.LogInformation($"Pool DAL : AddPoolMembersToDatabase(PoolMembers poolMembers) : {exception.Message}");
                return false;
            }
            catch (OperationCanceledException exception)
            {
                _logger.LogInformation($"Pool DAL : AddPoolMembersToDatabase(PoolMembers poolMembers): {exception.Message}");
                return false;
            }
            catch (ValidationException poolMemberNotException)
            {
                throw poolMemberNotException;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Pool DAL : AddPoolMembersToDatabase(PoolMembers poolMembers)  : {exception.Message}");
                return false;
            }


        }

        /// <summary>
        /// This method is implemented when the Service layer shifts the control and parameters to Pool DAL. 
        /// Pool DAL Perform the interaction with Database and Respond to theGet pool members from Database request.
        /// </summary>
        /// <param name="poolId">int</param>
        /// <returns>Return the list of pool members or Throws exception : Pool not found with the given Pool Id
        /// Catches exceptions thorwed by Database if any Misconnections in DB </returns>

        public List<PoolMembers> GetPoolMembersFromDatabase(int poolId)
        {
            try
            {
                return (from poolMember in _db.PoolMembers.Include(e=>e.Employees).Include(r=>r.Employees.Role) where poolMember.PoolId==poolId && poolMember.IsActive ==true select poolMember).ToList();

                //return _db.PoolMembers.ToList();
            }
            catch (DbUpdateException exception)
            {
                _logger.LogInformation($"Pool DAL : GetPoolsFromDatabase() : {exception.Message}");
                throw new DbUpdateException();
            }
            catch (OperationCanceledException exception)
            {
                _logger.LogInformation($"Pool DAL : GetPoolsFromDatabase() : {exception.Message}");
                throw new OperationCanceledException();
            }
            
            catch (Exception exception)
            {
                _logger.LogInformation($"Pool DAL : GetPoolsFromDatabase() : {exception.Message}");
                throw new Exception();
            }

        }
    }
}

