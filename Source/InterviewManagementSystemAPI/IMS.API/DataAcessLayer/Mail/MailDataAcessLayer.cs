using IMS.Models;
using IMS.Service;
using Microsoft.EntityFrameworkCore;

namespace IMS.DataAccessLayer
{
    public class MailDataAccessLayer : IMailDataAccessLayer
    {
        private InterviewManagementSystemDbContext _db;//= DataFactory.DbContextDataFactory.GetInterviewManagementSystemDbContextObject();
        private ILogger<MailService> _logger;

        public MailDataAccessLayer(ILogger<MailService> logger,InterviewManagementSystemDbContext dbContext)
        {
            _logger = logger;
            _db = dbContext;
        }

        public string GetEmployeeEmail(int employeeId)
        {
            try
            {
                return _db.Employees.Find(employeeId).EmailId;
            }
            catch (Exception getEmployeeEmailException)
            {
                _logger.LogError($"Exception on Mail DAL : GetEmployeeEmail(int employeeId) : {getEmployeeEmailException.Message} : {getEmployeeEmailException.StackTrace}");
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
                _logger.LogError($"Exception on Mail DAL :GetEmployeeName(int employeeId) : {getEmployeeNameException.Message} : {getEmployeeNameException.StackTrace}");
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
                _logger.LogError($"Exception on Mail DAL : GetPoolName(int poolId) : {getPoolNameException.Message} : {getPoolNameException.StackTrace}");
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
                _logger.LogError($"Exception on Mail DAL : GetPoolMember(int poolMemberId) : {getPoolMemberException.Message} : {getPoolMemberException.StackTrace}");
                throw getPoolMemberException;
            }
        }

        public List<string> GetEmployeeEmailsByPool(int poolId)
        {
            try
            {
                return (from poolMember in _db.PoolMembers.Include(p => p.Employees) where poolMember.PoolId == poolId select poolMember.Employees.EmailId).ToList();
            }
            catch (Exception getEmployeeEmailsByPoolException)
            {
                _logger.LogError($"Exception on Mail DAL : GetEmployeeEmailsByPool(int poolId) : {getEmployeeEmailsByPoolException.Message} : {getEmployeeEmailsByPoolException.StackTrace}");
                throw getEmployeeEmailsByPoolException;
            }
        }

        public Drive GetDrivebyId(int driveId)
        {
            try
            {
                return _db.Drives.Find(driveId);
            }
            catch (Exception getDrivebyIdException)
            {
                _logger.LogError($"Exception on Mail DAL : GetDrivebyId(int driveId) : {getDrivebyIdException.Message} : {getDrivebyIdException.StackTrace}");
                throw getDrivebyIdException;
            }
        }

        public EmployeeAvailability GetEmployeeAvailability(int employeeAvailabilityId)
        {
            try
            {
                return _db.EmployeeAvailability.Include("Drive").Include("Employee").FirstOrDefault(e=>e.EmployeeAvailabilityId == employeeAvailabilityId);
            }
            catch (Exception getEmployeeAvailabilityException)
            {
                _logger.LogError($"Exception on Mail DAL : GetEmployeeAvailability(int employeeAvailabilityId) : {getEmployeeAvailabilityException.Message} : {getEmployeeAvailabilityException.StackTrace}");
                throw getEmployeeAvailabilityException;
            }
        }
    }
}