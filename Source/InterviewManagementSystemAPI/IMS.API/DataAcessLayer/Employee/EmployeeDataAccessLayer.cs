using System.ComponentModel.DataAnnotations;
using IMS.Models;
using IMS.Validations;
using Microsoft.EntityFrameworkCore;

namespace IMS.DataAccessLayer
{
    public class EmployeeDataAccessLayer : IEmployeeDataAccessLayer
    {
        private InterviewManagementSystemDbContext _db;// = DataFactory.DbContextDataFactory.GetInterviewManagementSystemDbContextObject();
        private ILogger _logger;

        public EmployeeDataAccessLayer(ILogger<IEmployeeDataAccessLayer> logger,InterviewManagementSystemDbContext dbContext)
        {
            _logger = logger;
            _db = dbContext;
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
            bool EmployeedetailExists = _db.Employees.Any(x => x.EmployeeAceNumber == employee.EmployeeAceNumber || x.EmailId == employee.EmailId);
            if (EmployeedetailExists)
            {
                throw new ValidationException("Email id or ACE number already exists");
            }
            try
            {
                _db.Employees.Add(employee);
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
                var employee = _db.Employees.Find(employeeId);

                if (employee == null) throw new ValidationException("No Employee is found with given employee Id");

                if (employee.IsActive == false)
                {
                    throw new ValidationException("There is no employee for this employee id");
                }
                else
                {
                    employee.IsActive = false;
                    _db.Employees.Update(employee);
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
                return _db.Employees.Include(d=>d.Department).Include(r=>r.Role).ToList();
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
        /// 
        public Employee ViewProfile(int employeeId)
        {
            EmployeeValidation.IsEmployeeIdValid(employeeId);
            try
            {
                var viewProfile = (_db.Employees.Include(p => p.Project).Include(d => d.Department).Include(p => p.PoolMembers).Include(r => r.Role)).FirstOrDefault(x => x.EmployeeId == employeeId);
                return viewProfile != null ? viewProfile : throw new ValidationException("No Employee is found with given employee Id");
            }
            catch (Exception isEmployeeIdValidException)
            {
                _logger.LogInformation($"Exception on Employee DAL : IsEmployeeIdValid(int employeeId) : {isEmployeeIdValidException.Message} : {isEmployeeIdValidException.StackTrace}");
                throw isEmployeeIdValidException;
            }
        }
        
        public Employee CheckLoginCrendentials(string employeeAceNumber, string password)
        {
            try
            {
                if(!_db.Employees.Any(x => x.EmployeeAceNumber == employeeAceNumber))
                    throw new ValidationException($"No Employee Found With The ACE Number : {employeeAceNumber}");

                if(!_db.Employees.Any(x => x.EmployeeAceNumber == employeeAceNumber && x.Password == password))
                    throw new ValidationException($"Wrong Password!");

                var _employee = GetEmployeesFromDatabase().Where(employee => employee.EmployeeAceNumber == employeeAceNumber).First();
                return _employee;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Exception on Employee DAL : CheckLoginCrendentials(string employeeAceNumber, string password) : {exception.Message}");
                throw exception;
            }
        }

        public List<Employee> ViewEmployeeByDepartment(int departmentId)
        {
            EmployeeValidation.IsDepartmentValid(departmentId);
            try
            {
                var viewEmployeesByDepartment = (_db.Employees.Include(p => p.Project).Include(p => p.Department).Include(p => p.PoolMembers).Include(r => r.Role)).Where(x => x.DepartmentId == departmentId).ToList();
                return viewEmployeesByDepartment != null ? viewEmployeesByDepartment : throw new ValidationException("No Department is found with given department Id");
            }
            catch (Exception IsDepartmentValid)
            {
                _logger.LogInformation($"Exception on Employee DAL : IsDepartmentValid(int departmnet) : {IsDepartmentValid.Message} : {IsDepartmentValid.StackTrace}");
                throw IsDepartmentValid;
            }
        }

        public bool RespondEmployeeRequest(int employeeId, bool response)
        {
            var employee = _db.Employees.Find(employeeId);
            employee.IsAdminResponded=true; 
            employee.IsAdminAccepted=response;
            _db.Employees.Update(employee);
            _db.SaveChanges(); 
            return true;
        }
    }
}
