using IMS.DataAccessLayer;
using IMS.Models;
using IMS.Service;
namespace IMS.DataFactory{
    public static class EmployeeDriveResponseDataFactory
    {
        public static IEmployeeDriveResponseDataAccess GetEmployeeDriveResponseDataAccessLayerObject(ILogger logger)
        {
            return new EmployeeDriveResponseDataAccess(logger);
        }
        public static IEmployeeDriveResponseService GetEmployeeDriveResponseServiceObject(ILogger logger)
        {
            return new EmployeeDriveResponseService(logger);
        }
        public static EmployeeDriveResponse GetEmployeeDriveResponseObject()
        {
            return new EmployeeDriveResponse();
        }

    }
}