using IMS.Models;

namespace IMS.Service
{
    public interface IPoolService
    {
        public bool CreatePool(int departmentId, string poolName);
        public bool RemovePool(int poolId);

        public bool EditPool(int poolId, string poolName,int departmentId);
        public object ViewPools();
        public object ViewPoolsByID(int employeeID);
        public bool AddPoolMember(int employeeId, int poolId);

        public bool RemovePoolMember(int poolMemberId);

        public Object ViewPoolMembers(int PoolId);



    }
}