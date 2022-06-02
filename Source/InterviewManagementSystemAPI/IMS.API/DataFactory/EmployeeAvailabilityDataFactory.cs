using IMS.DataAccessLayer;
using IMS.Models;
using IMS.Service;
namespace IMS.DataFactory{
    public static class EmployeeAvailabilityDataFactory
    {
        public static EmployeeAvailability GetEmployeeDriveResponseObject()
        {
            return new EmployeeAvailability();
        }

    }
}