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

        public bool EditPoolFromDatabase ( int poolId,string poolName)
        {
            PoolValidation.IsEditPoolValid(poolId,poolName);
            try
            {
                
                var edit = _db.Pools.Find(poolId);
                if(edit == null )
                    throw new ValidationException("No pool is found with given Pool Id");
                else if(edit.IsActive==false)
                    throw new   ValidationException("The given pool Id is inactive,so unable to rename the pool");
                
                
                
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

       