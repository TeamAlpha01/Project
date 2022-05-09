using IMS.Models;
namespace IMS.DataAccessLayer
{
    public interface IEmployeeDataAccessLayer
    {
        public bool AddEmployeeToDatabase(Employee employee);
        public bool RemoveEmployeeFromDatabase(int employeeId);
        public List<Employee> GetEmployeesFromDatabase();

        public Employee ViewProfile(int employeeId);
    }
}