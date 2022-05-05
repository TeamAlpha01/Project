
using IMS.Model;
using IMS.DataAccessLayer;
namespace IMS.Service
{
    public class DepartmentService : IDepartmentService
    {
        private IDepartmentDataAccessLayer _departmentDataAccessLayer = DataFactory.DepartmentDataFactory.GetDepartmentDataAccessLayerObject();
        private Department _department = DataFactory.DepartmentDataFactory.GetDepartmentObject();

        /*  
            Returns False when Exception occured in Data Access Layer
            
            Throws ArgumentNullException when Role Name is not passed to this service method
        */
        public bool CreateDepartment(string departmentName)
        {
            if (departmentName == null)
                throw new ArgumentNullException("Department Name is not provided");

            try
            {
                _department.DepartmentName = departmentName;
                return _departmentDataAccessLayer.AddDepartmentToDatabase(_department) ? true : false; // LOG Error in DAL;
            }
            catch (Exception)
            {
                
                // Log "Exception Occured in Data Access Layer"
                return false;
            }
        }

        /*  
            Returns False when Exception occured in Data Access Layer
            
            Throws ArgumentNullException when Role Id is not passed to this service method
        */

        public bool RemoveDepartment(int departmentId)
        {
            if (departmentId == 0)
                throw new ArgumentNullException("Department Id is not provided");

            try
            {
                return _departmentDataAccessLayer.RemoveDepartmentFromDatabase(departmentId) ? true :false; // LOG Error in DAL;
            }
            catch (Exception)
            {
                // Log "Exception Occured in Data Access Layer"
                return false;
            }
        }

        /*  
            Throws Exception when Exception occured in DAL while fetching roles
        */
        public IEnumerable<Department> ViewDepartments()
        {
            try
            {
                IEnumerable<Department> departments = new List<Department>();
                return departments = from department in _departmentDataAccessLayer.GetDepartmentsFromDatabase() where department.IsActive == true select department;
            }
            catch (Exception)
            {
                //Log "Exception occured in DAL while fetching roles"
                throw new Exception();
            }
        }

    }
}