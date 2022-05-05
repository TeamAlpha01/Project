using IMS.DataAccessLayer;
using IMS.Models;
using IMS.Service;
namespace IMS.DataFactory{
    public static class EmployeeAvailabilityDataFactory
    {
        public static IEmployeeAvailabilityDataAccess GetEmployeeAvailabilityDataAccessLayerObject(ILogger logger)
        {
            return new EmployeeAvailabilityDataAccess(logger);
        }
        public static IEmployeeAvailabilityService GetEmployeeAvailabilityServiceObject(ILogger logger)
        {
            return new EmployeeAvailabilityService(logger);
        }
        public static EmployeeAvailability GetEmployeeDriveResponseObject()
        {
            return new EmployeeAvailability();
        }

    }
}