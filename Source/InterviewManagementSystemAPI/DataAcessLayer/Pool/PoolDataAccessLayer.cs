using IMS.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using IMS.Validations;
namespace IMS.DataAccessLayer
{
    public class PoolDataAccessLayer:IPoolDataAccessLayer

    {
        private InterviewManagementSystemDbContext _db = DataFactory.DbContextDataFactory.GetInterviewManagementSystemDbContextObject();
        private ILogger _logger;

        public PoolDataAccessLayer(ILogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// This method is implemented when the Service layer shifts the control and parameters to Pool DAL. 
        /// Pool DAL Perform the interaction with Database and Respond to the Add Pool to Database request.
        /// </summary>
        /// <param name="pool">object</param>
        /// <returns>Returns true or Exception message when any misconnection in database</returns>
        public bool AddPoolToDatabase(Pool pool)
        {
            
            PoolValidation.IsAddPoolValid( pool);    
            try
            {
                _db.Pools.Add(pool);
                _db.SaveChanges();
                return true;
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

            try
            {
                var pool = _db.Pools.Find(poolId);
                
                if (pool == null ) 
                    throw new ValidationException("No Pool is found with given pool Id");
                
                pool.IsActive = false;
                _db.Pools.Update(pool);
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

        public bool EditPoolFromDatabase ( int poolId,string poolName)
        {
            PoolValidation.IsEditPoolValid(poolId,poolName);
            try
            {
                
                var edit = _db.Pools.Find(poolId);
                if(edit == null )
                    throw new ValidationException("No pool is found with given Pool Id");
                else if(edit.IsActive==false)
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

        public List<Pool> GetPoolsFromDatabase(int departmentId)
        {
             
            try
            {
                  var list = _db.Pools.Find(departmentId);
                 if(list == null )
                    throw new ValidationException("No pool is found with given department Id ");
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
                _db.PoolMembers.Add(poolMembers);
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
            
            try{
                var employee = _db.PoolMembers.Find(poolMemberId);
                if(employee==null) 
                    throw new ValidationException("PoolMember not found with the given PoolMember Id");
               
                employee.IsActive=false;
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
            catch(ValidationException poolMemberNotException)
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
         PoolValidation.IsPoolIdValid(poolId) ;  
              
            try
            {
                var member = _db.PoolMembers.Find(poolId);
                if(member==null) 
                    throw new ValidationException("Pool not found with the given Pool Id");
               
            return _db.PoolMembers.ToList();
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
             catch(ValidationException poolNotFound)
            {
               throw poolNotFound;     
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Pool DAL : GetPoolsFromDatabase() : {exception.Message}");
                throw new Exception();
            }
             
        }
    }
}

       