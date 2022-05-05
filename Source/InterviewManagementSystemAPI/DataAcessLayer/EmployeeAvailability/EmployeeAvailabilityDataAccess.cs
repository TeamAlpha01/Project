using System.ComponentModel.DataAnnotations;
using IMS.Models;
using Microsoft.EntityFrameworkCore;

namespace IMS.DataAccessLayer
{
    public class EmployeeAvailabilityDataAccess : IEmployeeAvailabilityDataAccess
    {
        private InterviewManagementSystemDbContext _db = DataFactory.DbContextDataFactory.GetInterviewManagementSystemDbContextObject();
        private ILogger _logger;

        public EmployeeAvailabilityDataAccess(ILogger logger)
        {
            _logger = logger;
        }

        public bool SetTimeSlotToDatabase(EmployeeAvailability employeeAvailability)
        {
            _db.EmployeeAvailability.Add(employeeAvailability);
            return true;
        }
    }
}