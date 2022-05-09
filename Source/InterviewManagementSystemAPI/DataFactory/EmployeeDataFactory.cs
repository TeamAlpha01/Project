using IMS.Controllers;
using IMS.DataAccessLayer;
using IMS.Models;
using IMS.Service;
namespace IMS.DataFactory
{
    public static class EmployeeDataFactory
    {
        public static IEmployeeDataAccessLayer GetEmployeeDataAccessLayerObject(ILogger logger)
        {
            return new EmployeeDataAccessLayer(logger);
        }
        public static IEmployeeService GetEmployeeServiceObject(ILogger logger)
        {
            return new EmployeeService(logger);
        }
        public static Employee GetEmployeeModelObject()
        {
            return new Employee();
        }
    }
}