using IMS.Models;
namespace IMS.DataAccessLayer
{
    public interface IEmployeeDataAccessLayer
    {
        public bool AddEmployeeToDatabase(Employee employee);
        public bool RemoveEmployeeFromDatabase(int employeeId);
        public List<Employee> GetEmployeesFromDatabase();

        public Employee ViewProfile(int employeeId);

        public List<Employee> ViewEmployeeByDepartment(int departmentId);

        public Employee CheckLoginCrendentials(string employeeAceNumber , string password);
    }
}