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
        public Object ViewEmployeeRequest();
        public bool Login(string employeeAceNumber, string password);
        public bool RespondEmployeeRequest(int employeeId, bool response);
    }
}