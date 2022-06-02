using IMS.Models;
namespace IMS.Service
{
    public interface IEmployeeService
    {
        public bool CreateNewEmployee(Employee employee);
        public bool RemoveEmployee(int employeeId);
        public IEnumerable<Employee> ViewEmployees();
        public Object ViewProfile(int employeeId);
        public Object ViewEmployeesByDepartment(int DepartmentId);
        public IEnumerable<Employee> ViewEmployeeByApprovalStatus(bool isAdminAccepted);
        public IEnumerable<Employee> ViewEmployeeRequest();
        public bool Login(string employeeAceNumber, string password);

    }
}