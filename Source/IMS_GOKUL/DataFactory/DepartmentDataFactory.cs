using IMS.DataAccessLayer;
using IMS.Model;
using IMS.Service;
namespace IMS.DataFactory{
    public static class DepartmentDataFactory
    {
        public static IDepartmentDataAccessLayer GetDepartmentDataAccessLayerObject()
        {
            return new DepartmentDataAccessLayer();
        }
        public static IDepartmentService GetDepartmentServiceObject()
        {            
            return new DepartmentService();
        }
        public static Department GetDepartmentObject()
        {
            return new Department();
        }

    }
}
