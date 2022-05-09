using IMS.Model;
namespace IMS.Service{
    public interface IEmployeeService 
    {
        public  bool CreateNewEmployee(Employee employee);
        public bool RemoveEmployee(int employeeId);
        public IEnumerable<Employee> ViewEmployees();
        public Employee ViewProfile(int employeeId);
        public IEnumerable<Employee> ViewEmployeesByDepartment(int departmentId);
        public IEnumerable<Employee> ViewEmployeeByApprovalStatus(bool isAdminAccepted);
        public IEnumerable<Employee> ViewEmployeeRequest();

    }
}