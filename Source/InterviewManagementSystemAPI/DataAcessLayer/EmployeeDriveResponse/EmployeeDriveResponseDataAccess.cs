using System.ComponentModel.DataAnnotations;
using IMS.Models;
using Microsoft.EntityFrameworkCore;

namespace IMS.DataAccessLayer
{
    public class EmployeeDriveResponseDataAccess : IEmployeeDriveResponseDataAccess
    {
        private InterviewManagementSystemDbContext _db = DataFactory.DbContextDataFactory.GetInterviewManagementSystemDbContextObject();
        private ILogger _logger;

        public EmployeeDriveResponseDataAccess(ILogger logger)
        {
            _logger = logger;
        }

        public bool AddResponseToDatabase(EmployeeDriveResponse response)
        {
            if (response == null) throw new ValidationException("Response cannnot be null");

            try
            {
                _db.EmployeeDriveResponse.Add(response);
                _db.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Exception on EmployeeDriveResponse DAL : AddResponseToDatabase(EmployeeDriveResponse response) : {exception.Message}");
                return false;
            }
        }

        public bool UpdateResponseToDatabase(int employeeId, int driveId, int responseType)
        {
            if (driveId <= 0 || employeeId <= 0 || responseType <= 0)
                throw new ValidationException("DriveId or EmployeeId or Response Type is not valid");

            try
            {
                var EmployeeResponse = (from response in _db.EmployeeDriveResponse where response.EmployeeId == employeeId && response.DriveId == driveId select response).First();

                if (EmployeeResponse == null) throw new ValidationException("no response is found with given employee id and drive id");

                EmployeeResponse.ResponseType = responseType;
                _db.EmployeeDriveResponse.Update(EmployeeResponse);
                _db.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Exception on EmployeeDriveResponse DAL : UpdateResponseToDatabase(int employeeId, int driveId, int responseType) : {exception.Message}");
                return false;
            }
        }
    }
}


