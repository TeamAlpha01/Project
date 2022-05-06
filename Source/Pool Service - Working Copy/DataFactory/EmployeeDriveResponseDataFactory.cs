using IMS.DataAccessLayer;
using IMS.Models;
using IMS.Service;
namespace IMS.DataFactory{
    public static class EmployeeDriveResponseDataFactory
    {
        
        public static EmployeeDriveResponse GetEmployeeDriveResponseObject()
        {
            return new EmployeeDriveResponse();
        }

    }
}