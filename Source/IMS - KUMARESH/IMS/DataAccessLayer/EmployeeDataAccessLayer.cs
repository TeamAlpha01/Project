using System.ComponentModel.DataAnnotations;
using IMS.Model;
using IMS.Validations;
using Microsoft.EntityFrameworkCore;

namespace IMS.DataAccessLayer
{
    public class EmployeeDataAccessLayer : IEmployeeDataAccessLayer
    {
        private InterviewManagementSystemDbContext _db = DataFactory.DbContextDataFactory.GetInterviewManagementSystemDbContextObject();
        private ILogger _logger;

        public EmployeeDataAccessLayer(ILogger logger)
        {
            _logger = logger;
        }
        public bool AddEmployeeToDatabase(Employee employee)
        {
            EmployeeValidation.IsEmployeeValid(employee);
            try
            {
                _db.employees.Add(employee);
                _db.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Exception on Employee DAL : AddEmployeeToDatabase(Employee employee) : {exception.Message}");
                return false;
            }
        }
        public bool RemoveEmployeeFromDatabase(int employeeId)
        {
            if (employeeId <= 0)
                throw new ArgumentNullException("Employee Id is not provided to DAL");

            try
            {
                var employee = _db.employees.Find(employeeId);

                if (employee == null) throw new ValidationException("No Employee is found with given employee Id");

                employee.IsActive = false;
                _db.employees.Update(employee);
                _db.SaveChanges();
                return true;
            }
            catch (DbUpdateException exception)
            {
                _logger.LogInformation($"Employee DAL : RemoveEmployeeFromDatabase(int employeeId) : {exception.Message}");
                return false;
            }
            catch (OperationCanceledException exception)
            {
                _logger.LogInformation($"Employee DAL : RemoveEmployeeFromDatabase(int employeeId) : {exception.Message}");
                return false;
            }
            catch (ValidationException exception)
            {
                _logger.LogInformation($"Employee DAL : RemoveEmployeeFromDatabase(int employeeId) : {exception.Message}");
                return false;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Employee DAL : RemoveEmployeeFromDatabase(int employeeId) : {exception.Message}");
                return false;
            }
        }

        public List<Employee> GetEmployeesFromDatabase()
        {
           try
            {
                _logger.LogInformation("logger DAL");
                return _db.employees.ToList();
            }
            catch (DbUpdateException exception)
            {
                _logger.LogInformation($"Employee DAL : GetEmployeesFromDatabase() : {exception.Message}");
                throw new DbUpdateException();
            }
            catch (OperationCanceledException exception)
            {
                _logger.LogInformation($"Employee DAL : GetEmployeesFromDatabase() : {exception.Message}");
                throw new OperationCanceledException();
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Employee DAL : GetEmployeesFromDatabase() : {exception.Message}");
                 throw new Exception();
            }
        }
    }
}
