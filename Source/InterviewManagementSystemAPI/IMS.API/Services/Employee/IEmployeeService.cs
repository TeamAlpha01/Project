using IMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Service
{
    public interface IEmployeeService
    {
        public bool CreateNewEmployee(Employee employee);
        public bool RemoveEmployee(int employeeId);
        public Object ViewEmployees();
        public Object ViewProfile(int employeeId);
        public Object ViewEmployeesByDepartment(int DepartmentId);
        public IEnumerable<Employee> ViewEmployeeByApprovalStatus(bool isAdminAccepted);
        public Object ViewEmployeeRequest();
        public bool Login(string employeeAceNumber, string password);
        public bool RespondEmployeeRequest(int employeeId, bool response);
        public Object AdminDashboard(DateTime fromDate,DateTime toDate);
    }
}