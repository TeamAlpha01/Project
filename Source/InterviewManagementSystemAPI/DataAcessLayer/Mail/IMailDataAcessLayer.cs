using IMS.Models;
namespace IMS.DataAccessLayer
{
    public interface IMailDataAccessLayer
    {
        public string GetEmployeeEmail(int employeeId);
        public string GetEmployeeName(int employeeId);
        public string GetPoolName(int poolId);
        public PoolMembers GetPoolMember(int poolMemberId);
        public List<string> GetEmployeeEmailsByPool(int poolId);
    }
}