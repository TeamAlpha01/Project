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
        /// <summary>
        /// This method implements when Employee service passes the object to this method,then this method add the employee data to the database.
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>
        /// Return true when the data is added successfully to the database or
        /// Return false when exception is occured in this method.
        /// </returns>
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
        /// <summary>
        /// This method implements when Employee service passes the object to this method,then this method remove the employee data from the database.
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns>
        /// Return true when the data is removed successfully from the database or
        /// Return false when the exception is occured in this method.
        /// </returns>
        public bool RemoveEmployeeFromDatabase(int employeeId)
        {
            EmployeeValidation.IsEmployeeIdValid(employeeId);
            try
            {
                var employee = _db.employees.Find(employeeId);

                if (employee == null) throw new ValidationException("No Employee is found with given employee Id");

                if(employee.IsActive == false)
                {
                   throw new ValidationException("There is no employee for this employee id");
                }
                else
                {
                    employee.IsActive = false;
                    _db.employees.Update(employee);
                    _db.SaveChanges();
                    return true;
                }
                
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
                //return false;
                throw exception;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Employee DAL : RemoveEmployeeFromDatabase(int employeeId) : {exception.Message}");
                return false;
            }
        }
        /// <summary>
        /// This method implements when employee service passes the request to this method,then this method 
        /// </summary>
        /// <returns>
        /// Return list of all employees to the service layer or
        /// Throws an exception when exception is occured in this method.
        /// </returns>
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
        /// <summary>
        /// This method implements when employee service passes the object to this method,then this method shows the employee details based on parameter(employee id).
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns>
        /// Return employee details or
        /// Throws an exception when the exception is occured in this method.
        /// </returns>
        public Employee ViewProfile(int employeeId)
        {
            EmployeeValidation.IsEmployeeIdValid(employeeId);
            try
            {
                var viewProfile = _db.employees.Find(employeeId);
                return viewProfile != null? viewProfile : throw new ValidationException("No Employee is found with given employee Id");
            }
            catch(Exception isEmployeeIdValidException)
            {
                _logger.LogInformation($"Exception on Employee DAL : IsEmployeeIdValid(int employeeId) : {isEmployeeIdValidException.Message} : {isEmployeeIdValidException.StackTrace}");
                throw isEmployeeIdValidException;
            }
        }
    }
}
