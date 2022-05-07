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
            if (pool == null)
                throw new ArgumentNullException("Pool can't be empty");
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
            catch(ValidationException createPoolException)
            {
               throw createPoolException;     
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Pool DAL : AddPoolToDatabase(Pool pool)  : {exception.Message}");
                return false;
            }

        }
        public bool RemovePoolFromDatabase(int poolId)
        {
            if ( poolId == 0)
                throw new ArgumentNullException("Pool Id is not provided ");

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
           if(poolId==0 || poolName==null)
            throw new ArgumentNullException("Pool Id is not provided");
            try
            {
                var edit = _db.Pools.Find(poolId);
                 if (edit == null) 
                    throw new ValidationException("No Pool is found with given pool Id");
                
                
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
            catch (Exception exception)
            {
                _logger.LogInformation($"Pool DAL : GetPoolsFromDatabase() : {exception.Message}");
                throw new Exception();
            }

        }
          public bool AddPoolMembersToDatabase(PoolMembers poolMembers)
        {
            if (poolMembers== null)
                throw new ArgumentNullException("PoolMembers can't be empty");
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
        public bool RemovePoolMembersFromDatabase(int poolMemberId)
        {
           if(poolMemberId==0)
            
               throw new ArgumentNullException("Department Id is not provided "); 
            
            try{
                var employee = _db.PoolMembers.Find(poolMemberId);
               
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
        public List<PoolMembers> GetPoolMembersFromDatabase()
        {
            
              
            try
            {
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
            catch (Exception exception)
            {
                _logger.LogInformation($"Pool DAL : GetPoolsFromDatabase() : {exception.Message}");
                throw new Exception();
            }
             
        }
    }
}

       