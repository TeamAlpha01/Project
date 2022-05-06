using IMS.Models;
namespace IMS.DataAccessLayer
{
    public interface IPoolDataAccessLayer
    {
        public bool AddPoolToDatabase(Pool pool);
        public bool RemovePoolFromDatabase(int PoolId);


        public bool EditPoolFromDatabase(int PoolId,string PoolName);

        public List<Pool> GetPoolsFromDatabase(int DepartmentId);

        public bool AddPoolMembersToDatabase(PoolMembers poolMembers);
        public bool RemovePoolMembersFromDatabase(int EmployeeId,int PoolId);

        public List<PoolMembers> GetPoolMembersFromDatabase(int PoolId);

    }
}