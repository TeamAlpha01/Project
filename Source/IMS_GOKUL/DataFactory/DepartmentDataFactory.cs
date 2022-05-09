using IMS.DataAccessLayer;
using IMS.Model;
using IMS.Service;
namespace IMS.DataFactory{
    public static class DepartmentDataFactory
    {
        public static IDepartmentDataAccessLayer GetDepartmentDataAccessLayerObject(ILogger logger)
        {
            return new DepartmentDataAccessLayer(logger);
        }
        public static IDepartmentService GetDepartmentServiceObject(ILogger logger)
        {            
            return new DepartmentService(logger);
        }
        public static Department GetDepartmentObject()
        {
            return new Department();
        }
         public static Project GetProjectObject()
        {
            return new Project();
        }

    }
}
