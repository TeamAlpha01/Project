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
            
            if ( _db.Employees.Any(x => x.EmployeeAceNumber == employee.EmployeeAceNumber ))throw new ValidationException("ACE number already exists");
            if ( _db.Employees.Any(x => x.EmailId == employee.EmailId))throw new ValidationException("Email id  already exists");
            
            try
            {
                _db.Employees.Add(employee);
                _db.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                _logger.LogError($"Exception on Employee DAL : AddEmployeeToDatabase(Employee employee) : {exception.Message}");
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
                _logger.LogError($"Employee DAL : RemoveEmployeeFromDatabase(int employeeId) : {exception.Message}");
                return false;
            }
            catch (OperationCanceledException exception)
            {
                _logger.LogError($"Employee DAL : RemoveEmployeeFromDatabase(int employeeId) : {exception.Message}");
                return false;
            }
            catch (ValidationException exception)
            {
                _logger.LogError($"Employee DAL : RemoveEmployeeFromDatabase(int employeeId) : {exception.Message}");
            
                throw exception;
            }
            catch (Exception exception)
            {
                _logger.LogError($"Employee DAL : RemoveEmployeeFromDatabase(int employeeId) : {exception.Message}");
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
        public List<Employee> GetApprovedEmployessFromDatabase(bool isAdminAccepted)
        {
            try
            {
                return (from employee in _db.Employees  where employee.IsActive == true && employee.IsAdminAccepted == isAdminAccepted select employee).ToList();
            }
           catch (DbUpdateException exception)
            {
                _logger.LogError($"Employee DAL : GetApprovedEmployessFromDatabase(bool isAdminAccepted) : {exception.Message}");
                throw new DbUpdateException();
            }
            catch (OperationCanceledException exception)
            {
                _logger.LogError($"Employee DAL : GetApprovedEmployessFromDatabase(bool isAdminAccepted) : {exception.Message}");
                throw new OperationCanceledException();
            }
            catch (Exception exception)
            {
                _logger.LogError($"Employee DAL : GetApprovedEmployessFromDatabase(bool isAdminAccepted) : {exception.Message}");
                throw new Exception();
            }

        }
        public List<Employee> GetEmployeesRequestFromDatabase()
        {
            try
            {
                return (from employee in _db.Employees.Include(d=>d.Department).Include(r=>r.Role).Include(p=>p.Project)  where employee.IsActive == true  && employee.IsAdminAccepted == false && employee.IsAdminResponded == false select employee).ToList();
            }
            catch (DbUpdateException exception)
            {
                _logger.LogError($"Employee DAL : GetEmployeesFromDatabase() : {exception.Message}");
                throw new DbUpdateException();
            }
            catch (OperationCanceledException exception)
            {
                _logger.LogError($"Employee DAL : GetEmployeesFromDatabase() : {exception.Message}");
                throw new OperationCanceledException();
            }
            catch (Exception exception)
            {
                _logger.LogError($"Employee DAL : GetEmployeesFromDatabase() : {exception.Message}");
                throw new Exception();
            }
        }

        public List<Employee> GetEmployeesFromDatabase()
        {
            try
            {
                return  _db.Employees.Include(d=>d.Department).Include(r=>r.Role).Include(p=>p.Project).ToList();;


            }
               catch (DbUpdateException exception)
            {
                _logger.LogError($"Employee DAL : GetEmployeesFromDatabase() : {exception.Message}");
                throw new DbUpdateException();
            }
            catch (OperationCanceledException exception)
            {
                _logger.LogError($"Employee DAL : GetEmployeesFromDatabase() : {exception.Message}");
                throw new OperationCanceledException();
            }
            catch (Exception exception)
            {
                _logger.LogError($"Employee DAL : GetEmployeesFromDatabase() : {exception.Message}");
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
                _logger.LogError($"Exception on Employee DAL : IsEmployeeIdValid(int employeeId) : {isEmployeeIdValidException.Message} : {isEmployeeIdValidException.StackTrace}");
                throw;
            }
        }
        
        public Employee CheckLoginCrendentials(string employeeMail, string password)
        {
            try
            {
                if(!_db.Employees.Any(x => x.EmailId == employeeMail))
                    throw new ValidationException($"No employee found With given mail id : {employeeMail}");

                if(!_db.Employees.Any(x => x.EmailId == employeeMail && x.Password == password))
                    throw new ValidationException($"Invalid credentials");

                if(!_db.Employees.Any(x => x.EmailId == employeeMail && x.Password == password && x.IsActive==true))
                    throw new ValidationException($"Your account has been deactivated! Please Contact Adminstrator");
                if(!_db.Employees.Any(x =>x.EmailId == employeeMail && x.Password == password && x.IsAdminAccepted==true))
                    throw new ValidationException($"Wait untill you receive a mail!");
                var _employee = GetEmployeesFromDatabase().Where(employee => employee.EmailId == employeeMail).First();
                return _employee;
            }
            catch (Exception exception)
            {
                _logger.LogError($"Exception on Employee DAL : CheckLoginCrendentials(string employeeAceNumber, string password) : {exception.Message}");
                throw;
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
                _logger.LogError($"Exception on Employee DAL : IsDepartmentValid(int departmnet) : {IsDepartmentValid.Message} : {IsDepartmentValid.StackTrace}");
                throw;
            }
        }

        public bool RespondEmployeeRequest(int employeeId, bool response)
        {
            EmployeeValidation.IsEmployeeIdValid(employeeId);
            try
            {
                if(!_db.Employees.Any(x => x.EmployeeId ==employeeId ))
                    throw new ValidationException($"No Employee Found With the given employee id : {employeeId}");
                var employee = _db.Employees.Find(employeeId);
                employee!.IsAdminResponded=true; 
                employee.IsAdminAccepted=response;
                _db.Employees.Update(employee);
                _db.SaveChanges(); 
                return true;
            }
            catch (ValidationException exception)
            {
                _logger.LogError($"Employee DAL:RespondEmployeeRequest(int employee,bool response):{exception.Message}");
                throw exception;
            }
            catch(Exception exception)
            {
                _logger.LogError($"Employee DAL:ResponsEmployeeRequest(int emloyeeId,bool response):{exception.Message}");
                return false;
            }
            
        }
    }
}
