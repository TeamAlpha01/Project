using IMS.Model;

namespace IMS.Service{
    public interface IDepartmentService 
    {
        public  bool CreateDepartment(string departmentName);
        public bool RemoveDepartment(int departmentId);
        public IEnumerable<Department> ViewDepartments();

    }
}