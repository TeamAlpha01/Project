using IMS.Model;
namespace IMS.Service{
    public interface IEmployeeService 
    {
        public  bool CreateNewEmployee(Employee employee);
        public bool RemoveEmployee(int employeeId);
        public IEnumerable<Employee> ViewEmployees();
        public IEnumerable<Employee> ViewEmployeesByDepartment(int departmentId);
        public IEnumerable<Employee> ViewEmployeeByApprovalStatus();
        public IEnumerable<Employee> ViewTACRequest();

    }
}