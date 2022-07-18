using IMS.Models;
using IMS.Service;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace IMS.DataAccessLayer
{
    public class MailDataAccessLayer : IMailDataAccessLayer
    {
        private InterviewManagementSystemDbContext _db;//= DataFactory.DbContextDataFactory.GetInterviewManagementSystemDbContextObject();
        private ILogger<MailService> _logger;
        
        private readonly Stopwatch _stopwatch = new Stopwatch();
       

        public MailDataAccessLayer(ILogger<MailService> logger,InterviewManagementSystemDbContext dbContext)
        {
            _logger = logger;
            _db = dbContext;
        }

        public string GetEmployeeEmail(int employeeId)
        {
            _stopwatch.Start();
            try
            {
                return _db.Employees!.Find(employeeId)!.EmailId!;
            }
            catch (Exception getEmployeeEmailException)
            {
                _logger.LogError($"Exception on Mail DAL : GetEmployeeEmail(int employeeId) : {getEmployeeEmailException.Message} : {getEmployeeEmailException.StackTrace}");
                throw ;
            }
            
            finally
            {
                _stopwatch.Stop();
                _logger.LogError($"Mail DAL Time elapsed for GetEmployeeEmail(int employeeId)  :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }

        public string GetEmployeeName(int employeeId)
        {
            _stopwatch.Start();
            try
            {
                return _db.Employees!.Find(employeeId)!.Name!;
            }
            catch (Exception getEmployeeNameException)
            {
                _logger.LogError($"Exception on Mail DAL :GetEmployeeName(int employeeId) : {getEmployeeNameException.Message} : {getEmployeeNameException.StackTrace}");
                throw ;
            }
            
            finally
            {
                _stopwatch.Stop();
                _logger.LogError($"Mail DAL Time elapsed for GetEmployeeName(int employeeId)  :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }

        public string GetPoolName(int poolId)
        {
            _stopwatch.Start();
            try
            {
                return _db.Pools!.Find(poolId)!.PoolName!;
            }
            catch (Exception getPoolNameException)
            {
                _logger.LogError($"Exception on Mail DAL : GetPoolName(int poolId) : {getPoolNameException.Message} : {getPoolNameException.StackTrace}");
                throw ;
            }
            
            finally
            {
                _stopwatch.Stop();
                _logger.LogError($"Mail DAL Time elapsed for GetPoolName(int poolId)  :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }
        public PoolMembers? GetPoolMember(int poolMemberId)
        {
            _stopwatch.Start();
            try
            {
                return _db.PoolMembers!.Find(poolMemberId);
            }
            catch (Exception getPoolMemberException)
            {
                _logger.LogError($"Exception on Mail DAL : GetPoolMember(int poolMemberId) : {getPoolMemberException.Message} : {getPoolMemberException.StackTrace}");
                throw;
            }
            
            finally
            {
                _stopwatch.Stop();
                _logger.LogError($"Mail DAL Time elapsed for GetPoolMember(int poolMemberId) :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }

        public List<string> GetEmployeeEmailsByPool(int poolId)
        {
            _stopwatch.Start();
            try
            {
                return (from poolMember in _db.PoolMembers!.Include(p => p.Employees) where poolMember.PoolId == poolId select poolMember.Employees!.EmailId).ToList();
            }
            catch (Exception getEmployeeEmailsByPoolException)
            {
                _logger.LogError($"Exception on Mail DAL : GetEmployeeEmailsByPool(int poolId) : {getEmployeeEmailsByPoolException.Message} : {getEmployeeEmailsByPoolException.StackTrace}");
                throw;
            }
            
            finally
            {
                _stopwatch.Stop();
                _logger.LogError($"Mail DAL Time elapsed for GetEmployeeEmailsByPool(int poolId)  :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }

        public Drive? GetDrivebyId(int driveId)
        {
            _stopwatch.Start();
            try
            {
                return _db.Drives!.Find(driveId);
            }
            catch (Exception getDrivebyIdException)
            {
                _logger.LogError($"Exception on Mail DAL : GetDrivebyId(int driveId) : {getDrivebyIdException.Message} : {getDrivebyIdException.StackTrace}");
                throw;
            }
            
            finally
            {
                _stopwatch.Stop();
                _logger.LogError($"Mail DAL Time elapsed for GetDrivebyId(int driveId)  :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }

        public EmployeeAvailability? GetEmployeeAvailability(int employeeAvailabilityId)
        {
            _stopwatch.Start();
            try
            {
                return _db.EmployeeAvailability!.Include("Drive").Include("Employee").FirstOrDefault(e=>e.EmployeeAvailabilityId == employeeAvailabilityId);
            }
            catch (Exception getEmployeeAvailabilityException)
            {
                _logger.LogError($"Exception on Mail DAL : GetEmployeeAvailability(int employeeAvailabilityId) : {getEmployeeAvailabilityException.Message} : {getEmployeeAvailabilityException.StackTrace}");
                throw;
            }
            
            finally
            {
                _stopwatch.Stop();
                _logger.LogError($"Mail DAL Time elapsed for GetEmployeeAvailability(int employeeAvailabilityId)  :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }
    }
}