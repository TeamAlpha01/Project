using IMS.Models;
using IMS.DataAccessLayer;
using System.ComponentModel.DataAnnotations;
using IMS.Validations;

namespace IMS.Service
{
    public class EmployeeAvailabilityService : IEmployeeAvailabilityService
    {
        private IEmployeeAvailabilityDataAccess _employeeAvailabilityDataAcess;
        private ILogger _logger;

        public EmployeeAvailabilityService(ILogger logger)
        {
            _logger = logger;
            _employeeAvailabilityDataAcess = DataFactory.EmployeeAvailabilityDataFactory.GetEmployeeAvailabilityDataAccessLayerObject(_logger);
        }

        public bool SetTimeSlot(EmployeeAvailability employeeAvailability)
        {
            return _employeeAvailabilityDataAcess.SetTimeSlotToDatabase(employeeAvailability);
            
        }
    }
}