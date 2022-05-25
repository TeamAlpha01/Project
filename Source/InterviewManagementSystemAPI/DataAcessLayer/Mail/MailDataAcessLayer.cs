using IMS.Models;
using IMS.Service;
using Microsoft.EntityFrameworkCore;

namespace IMS.DataAccessLayer
{
    public class MailDataAccessLayer : IMailDataAccessLayer
    {
        private InterviewManagementSystemDbContext _db = DataFactory.DbContextDataFactory.GetInterviewManagementSystemDbContextObject();
        private ILogger<MailService> _logger;

        public MailDataAccessLayer(ILogger<MailService> logger)
        {
            _logger = logger;
        }

        public string GetEmployeeEmail(int employeeId)
        {
            try
            {
                return _db.Employees.Find(employeeId).EmailId;
            }
            catch (Exception getEmployeeEmailException)
            {
                // _logger.LogInformation($"Exception on Drive DAL : AddDriveToDatabase(Drive drive) : {addDriveToDatabaseException.Message} : {addDriveToDatabaseException.StackTrace}");
                throw getEmployeeEmailException;
            }
        }

        public string GetEmployeeName(int employeeId)
        {
            try
            {
                return _db.Employees.Find(employeeId).Name;
            }
            catch (Exception getEmployeeNameException)
            {
                // _logger.LogInformation($"Exception on Drive DAL : AddDriveToDatabase(Drive drive) : {addDriveToDatabaseException.Message} : {addDriveToDatabaseException.StackTrace}");
                throw getEmployeeNameException;
            }
        }

        public string GetPoolName(int poolId)
        {
            try
            {
                return _db.Pools.Find(poolId).PoolName;
            }
            catch (Exception getPoolNameException)
            {
                // _logger.LogInformation($"Exception on Drive DAL : AddDriveToDatabase(Drive drive) : {addDriveToDatabaseException.Message} : {addDriveToDatabaseException.StackTrace}");
                throw getPoolNameException;
            }
        }
        public PoolMembers GetPoolMember(int poolMemberId)
        {
            try
            {
                return _db.PoolMembers.Find(poolMemberId);
            }
            catch (Exception getPoolMemberException)
            {
                // _logger.LogInformation($"Exception on Drive DAL : AddDriveToDatabase(Drive drive) : {addDriveToDatabaseException.Message} : {addDriveToDatabaseException.StackTrace}");
                throw getPoolMemberException;
            }
        }

        public List<string> GetEmployeeEmailsByPool(int poolId)
        {
            return (from poolMember in _db.PoolMembers.Include(p=>p.Employees) where poolMember.PoolId == poolId select poolMember.Employees.EmailId).ToList();
        }
    }
}