using IMS.Models;

namespace IMS.Service
{
    public interface IPoolService
    {
        public bool CreatePool(Pool pool);
        public bool RemovePool(Pool pool);

        public bool EditPool(Pool pool );
        public object ViewPools();
        public object ViewPoolsByID(int employeeID);
        public bool AddPoolMember(PoolMembers poolMembers);

        public bool RemovePoolMember(int poolMemberId);

        public Object ViewPoolMembers(int PoolId);



    }
}