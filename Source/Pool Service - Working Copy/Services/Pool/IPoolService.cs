using IMS.Models;

namespace IMS.Services{
    public interface IPoolService
    {
        public  bool CreatePool(int departmentId,string poolName);
        public bool RemovePool(int poolId);

        public bool EditPool(int poolId,string poolName);
         public IEnumerable<Pool> ViewPools(int departmentId);
         public bool AddPoolMembers(int employeeId,int poolId);

        public bool RemovePoolMembers(int poolMemberId);
          
        public IEnumerable<PoolMembers> ViewPoolMembers(int poolId);

        

    }
}