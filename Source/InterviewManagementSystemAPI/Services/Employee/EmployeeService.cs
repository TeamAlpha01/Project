using IMS.Models;
using IMS.DataAccessLayer;
using IMS.Validations;
using IMS.DataFactory;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Service
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeDataAccessLayer _employeeDataAccessLayer;
        private IDepartmentDataAccessLayer _departmentDataAccessLayer;
        private IRoleDataAccessLayer _roleDataAccessLayer;
        private ILogger _logger;

        public EmployeeService(ILogger logger)
        {
            _logger = logger;
            _employeeDataAccessLayer = DataFactory.EmployeeDataFactory.GetEmployeeDataAccessLayerObject(_logger);
            _departmentDataAccessLayer = DataFactory.DepartmentDataFactory.GetDepartmentDataAccessLayerObject(_logger);
            _roleDataAccessLayer = DataFactory.RoleDataFactory.GetRoleDataAccessLayerObject(_logger);
        }

        /// <summary>
        /// This method will implemented when EmployeeController passes the request to this method,then this method calls the AddEmployeeToDatabase method in DAL.
        /// </summary>
        /// <param name="employee"></param>
        /// <returns>
        /// Returns true when role is added successfully in DAL or
        /// Returns false when exception occured in AddEmployeeToDatabase method in DAL or
        /// Throws an exception when error is occuren in this method
        /// </returns>

        public bool CreateNewEmployee(Employee employee)
        {
            EmployeeValidation.IsEmployeeValid(employee);
            _departmentDataAccessLayer.CheckDepartmentId(employee.DepartmentId);
            _roleDataAccessLayer.CheckRoleId(employee.RoleId);
            _departmentDataAccessLayer.CheckProjectId(employee.ProjectId);
            try
            {
                return _employeeDataAccessLayer.AddEmployeeToDatabase(employee) ? true : false; // LOG Error in DAL;
            }
            catch (ValidationException employeeNotValid)
            {
                _logger.LogInformation($"Employee Service : CreateEmployee() : {employeeNotValid.Message}");
                throw employeeNotValid;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Employee Service : CreateEmployee() : {exception.Message}");
                throw exception;
            }
        }

        /// <summary>
        /// This method will be implemented when EmployeeController passes the request to this method,then this method calls the RemoveEmployeeFromDatabase method in DAL.
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns>
        /// Returns true when role is removed successfully in DAL or
        /// Returns false when exception occured in RemoveEmployeeFromDatabase method in DAL or
        /// Throws an exception when error is occuren in this method.
        /// </returns>

        public bool RemoveEmployee(int employeeId)
        {
            // if (employeeId <= 0)
            //     throw new ValidationException("Employee Id is not provided");

            EmployeeValidation.IsEmployeeIdValid(employeeId);

            try
            {
                return _employeeDataAccessLayer.RemoveEmployeeFromDatabase(employeeId) ? true : false;
            }
            catch (ArgumentException exception)
            {
                _logger.LogInformation($"Employee service : RemoveEmployee(int employeeId) : {exception.Message}");
                throw exception;
            }
            catch (ValidationException employeeNotFound)
            {
                _logger.LogInformation($"Employee service : CreateEmployee(Employee employee) : {employeeNotFound.Message}");
                throw employeeNotFound;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Employee service : RemoveEmployee(int employeeId) : {exception.Message}");
                throw exception;
            }
        }
        /// <summary>
        /// This method will implemented when EmployeeController passes the request to this method,then this method calls the GetEmployeesFromDatabase method in DAL.
        /// </summary>
        /// <returns>
        /// Returns list of all employees who are in "IsActive==true" or
        /// Throws an exception when exception is occured in GetEmployeesFromDatabase method in DAL.
        /// </returns>
        public IEnumerable<Employee> ViewEmployees()
        {
            try
            {
                IEnumerable<Employee> employees = new List<Employee>();
                return employees = from employee in _employeeDataAccessLayer.GetEmployeesFromDatabase() where employee.IsActive == true select employee;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Employee service : RemoveEmployee(int employeeId) : Exception occured in DAL :{exception.Message}");
                throw new Exception();
            }
        }
        /// <summary>
        /// This method implements when EmployeeController passes the request to this method,then this method calls ViewProfile method in DAL.
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns>
        /// Return Employee details or
        /// Throws an exception when exception is occured in ViewProfile method in DAL. 
        /// </returns>

        public object ViewProfile(int employeeId)
        {
            EmployeeValidation.IsEmployeeIdValid(employeeId);
            try
            {
                var _employee = _employeeDataAccessLayer.ViewProfile(employeeId);
                return new
                {
                    EmployeeACEId = _employee.EmployeeAceNumber,
                    EmployeeName = _employee.Name,
                    EmployeeDepartment = _employee.Department.DepartmentName,
                    EmployeeProject = _employee.Project.ProjectName,
                    EmployeeRole = _employee.Role.RoleName,
                    EmployeeEmailID = _employee.EmailId
                    //EmployeePoolName = _employee.PoolMembers.Pools.PoolName,
                };
            }
            catch (ValidationException viewEmployeeNotValid)
            {
                _logger.LogInformation($"Employee Service : ViewProfile(int employeeId) : {viewEmployeeNotValid.Message} : {viewEmployeeNotValid.StackTrace}");
                throw viewEmployeeNotValid;
            }
            catch (Exception viewEmployeeException)
            {
                _logger.LogInformation($"Drive Service : ViewProfile(int employeeId) : {viewEmployeeException.Message} : {viewEmployeeException.StackTrace}");
                throw viewEmployeeException;
            }
        }
        /// <summary>
        /// This method will implemented when EmployeeController passes the request to this method,then this method calls the GetEmployeesFromDatabase method in DAL.
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns>
        /// Returns list of employees who's departmentId matches in database table department id or
        /// Throws an exception when exception is occured in GetEmployeesFromDatabase method in DAL.
        /// </returns>
        public object ViewEmployeesByDepartment(int departmentId)
        {
            EmployeeValidation.IsDepartmentValid(departmentId);
            _departmentDataAccessLayer.CheckDepartmentId(departmentId);

            try
            {
                IEnumerable<Employee> employees = new List<Employee>();
                return employees = (from employee in _employeeDataAccessLayer.ViewEmployeeByDepartment(departmentId) where employee.DepartmentId == departmentId select employee);
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Employee service : RemoveEmployee(int employeeId) : Exception occured in DAL :{exception.Message}");
                throw new Exception();
            }

            // try
            // {
            //     IEnumerable<Employee> employees = new List<Employee>();
            //     return employees = from employee in _employeeDataAccessLayer.GetEmployeesFromDatabase() where employee.DepartmentId == departmentId select employee;
            // }
            // catch (Exception exception)
            // {
            //     _logger.LogInformation($"Employee service : RemoveEmployee(int employeeId) : Exception occured in DAL :{exception.Message}");
            //     throw new Exception();
            // }

        }

        /// <summary>
        /// This method implements when EmployeeController passes the request to this method,then this method calls the ViewEmployeeByApprovalStatus method in DAL.
        /// </summary>
        /// <param name="isAdminAccepted"></param>
        /// <returns>
        /// Return list of employees who are approved or rejected by admin based on isAdminAccepted parameter or
        /// Throws an exception when exception is occured in GetEmployeesFromDatabase method in DAL.
        /// </returns>
        public IEnumerable<Employee> ViewEmployeeByApprovalStatus(bool isAdminAccepted)
        {
            try
            {
                IEnumerable<Employee> employees = new List<Employee>();
                return employees = from employee in _employeeDataAccessLayer.GetEmployeesFromDatabase() where employee.IsAdminAccepted == isAdminAccepted select employee;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Employee service : ViewEmployeeByApprovalStatus : Exception occured in DAL :{exception.Message}");
                throw new Exception();
            }
        }
        /// <summary>
        /// This method implements when EmployeeController passes the request to this method,then this method calls the ViewEmployeeRequest method in DAL.
        /// </summary>
        /// <returns>
        /// Return list of employees who has sent a request to admin and doesn't shows a accepted request or 
        /// Throws an exception when exception is occured in GetEmployeesFromDatabase method in DAL.
        /// </returns>

        public IEnumerable<Employee> ViewEmployeeRequest()
        {
            try
            {
                IEnumerable<Employee> employees = new List<Employee>();
                return employees = from employee in _employeeDataAccessLayer.GetEmployeesFromDatabase() where employee.IsAdminAccepted == false && employee.IsAdminResponded == false select employee;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Employee service : ViewTACRequest : Exception occured in DAL :{exception.Message}");
                throw new Exception();
            }
        }
        public bool Login(string employeeAceNumber, string password)
        {
            try
            {
                return true;// _employeeDataAccessLayer.CheckLoginCrendentials(employeeAceNumber, password) ? true : false;

            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Employee DAL : CheckLoginCredentails throwed an exception : {exception.Message}");
                throw exception;
            }
        }
    }
}