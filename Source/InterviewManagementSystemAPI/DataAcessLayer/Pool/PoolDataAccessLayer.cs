using IMS.Models;
using Microsoft.EntityFrameworkCore;
namespace IMS.DataAccessLayer
{
    public class PoolDataAccessLayer:IPoolDataAccessLayer

    {
        private InterviewManagementSystemDbContext _db = DataFactory.DbContextDataFactory.GetInterviewManagementSystemDbContextObject();
        public bool AddPoolToDatabase(Pool pool)
        {
            if (pool== null)
                throw new ArgumentNullException("Pool can't be empty");
            try
            {
                _db.Pools.Add(pool);
                _db.SaveChanges();
                return true;
            }
            catch (DbUpdateException)
            {
                //LOG   "DB Update Exception Occured"
                return false;
            }
            catch (OperationCanceledException)
            {
                //LOG   "Opreation cancelled exception"
                return false;
            }
            catch (Exception)
            {
                //LOG   "unknown exception occured "
                return false;
            }


        }
        public bool RemovePoolFromDatabase(int DepartmentId,int PoolId)
        {
            if (DepartmentId==0 || PoolId == 0)
                throw new ArgumentNullException("Pool Id is not provided ");

            try
            {
                var pool = _db.Pools.Find(PoolId);
                
                pool.IsActive = false;
                _db.Pools.Update(pool);
                _db.SaveChanges();
                return true;
            }
            catch (DbUpdateException)
            {
                //LOG   "DB Update Exception Occured"
                return false;
            }
            catch (OperationCanceledException)
            {
                //LOG   "Opreation cancelled exception"
                return false;
            }
            catch (Exception)
            {
                //LOG   "unknown exception occured "
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
                
                edit.PoolName = poolName;
                _db.Pools.Update(edit);
                _db.SaveChanges();
                return true;

            }
             catch (DbUpdateException)
            {
                //LOG   "DB Update Exception Occured"
                return false;
            }
            catch (OperationCanceledException)
            {
                //LOG   "Opreation cancelled exception"
                return false;
            }
            catch (Exception)
            {
                //LOG   "unknown exception occured "
                return false;
            }
            
        }
        

        public List<Pool> GetPoolsFromDatabase(int DepartmentId)
        {
             if (DepartmentId == 0)
                throw new ArgumentNullException("Department Id is not provided ");
            try
            {
                return _db.Pools.ToList();
            }
            catch (DbUpdateException)
            {
                //LOG   "DB Update Exception Occured"
                throw new DbUpdateException();
            }
            catch (OperationCanceledException)
            {
                //LOG   "Opreation cancelled exception"
                throw new OperationCanceledException();
            }
            catch (Exception)
            {
                //LOG   "unknown exception occured "
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
            catch (DbUpdateException)
            {
                //LOG   "DB Update Exception Occured"
                return false;
            }
            catch (OperationCanceledException)
            {
                //LOG   "Opreation cancelled exception"
                return false;
            }
            catch (Exception)
            {
                //LOG   "unknown exception occured "
                return false;
            }


        }
        public bool RemovePoolMembersFromDatabase(int EmployeeId,int PoolId)
        {
            if(EmployeeId==0 || PoolId==0)
            
               throw new ArgumentNullException("Department Id is not provided "); 
            
            try{
                 var employee = (from emp in _db.PoolMembers where emp.EmployeeId==EmployeeId && emp.PoolId == PoolId select emp).First();
                //var employee=_db.PoolMembers.Find(EmployeeId,PoolId);
                employee.IsActive=false;
                _db.PoolMembers.Update(employee);
                _db.SaveChanges();
                return true;
            }
              
            catch (DbUpdateException)
            {
                //LOG   "DB Update Exception Occured"
                return false;
            }
            catch (OperationCanceledException)
            {
                //LOG   "Opreation cancelled exception"
                return false;
            }
            catch (Exception)
            {
                //LOG   "unknown exception occured "
                return false;
            }
       
        }
        public List<PoolMembers> GetPoolMembersFromDatabase(int PoolId)
        {
            if (PoolId == 0)
                throw new ArgumentNullException("Department Id is not provided ");
            try
            {
                return _db.PoolMembers.ToList();
            }
            catch (DbUpdateException)
            {
                //LOG   "DB Update Exception Occured"
                throw new DbUpdateException();
            }
            catch (OperationCanceledException)
            {
                //LOG   "Opreation cancelled exception"
                throw new OperationCanceledException();
            }
            catch (Exception)
            {
                //LOG   "unknown exception occured "
                throw new Exception();
            }
             
        }






    }
}

       