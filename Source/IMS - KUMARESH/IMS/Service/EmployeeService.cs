using IMS.Model;
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
        private ILogger _logger;

        public EmployeeService(ILogger logger)
        {
            _logger = logger;
            _employeeDataAccessLayer = DataFactory.EmployeeDataFactory.GetEmployeeDataAccessLayerObject(_logger);
        }

        // private IEmployeeDataAccessLayer _employeeDataAccessLayer = DataFactory.EmployeeDataFactory.GetEmployeeDataAccessLayerObject();


        public bool CreateNewEmployee(Employee employee)
        {
            EmployeeValidation.IsEmployeeValid(employee);

            try
            {
                return _employeeDataAccessLayer.AddEmployeeToDatabase(employee) ? true : false; // LOG Error in DAL;
            }
            catch (ValidationException employeeNotValid)
            {
                _logger.LogInformation($"Employee Service : CreateEmployee() : {employeeNotValid.Message}");
                return false;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Employee Service : CreateEmployee() : {exception.Message}");
                return false;
            }
        }


        public bool RemoveEmployee(int employeeId)
        {
            if (employeeId <= 0)
                throw new ValidationException("Employee Id is not provided");

            try
            {
                return _employeeDataAccessLayer.RemoveEmployeeFromDatabase(employeeId) ? true : false;
            }
            catch (ArgumentException exception)
            {
                _logger.LogInformation($"Employee service : RemoveEmployee(int employeeId) : {exception.Message}");
                return false;
            }
            catch (ValidationException employeeNotFound)
            {
                _logger.LogInformation($"Employee service : CreateEmployee(Employee employee) : {employeeNotFound.Message}");
                return false;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Employee service : RemoveEmployee(int employeeId) : {exception.Message}");
                return false;
            }
        }

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
                return false;
            }
        }
        public IEnumerable<Employee> ViewEmployeesByDepartment(int departmentId)
        {
            try
            {
                IEnumerable<Employee> employees = new List<Employee>();
                return employees = from employee in _employeeDataAccessLayer.GetEmployeesFromDatabase() where employee.DepartmentId == departmentId select employee;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Employee service : RemoveEmployee(int employeeId) : Exception occured in DAL :{exception.Message}");
                return false;
            }
        }

        public IEnumerable<Employee> ViewEmployeeByApprovalStatus()
        {
            try
            {
                IEnumerable<Employee> employees = new List<Employee>();
                return employees = from employee in _employeeDataAccessLayer.GetEmployeesFromDatabase() where employee.IsAdminAccepted == true select employee;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Employee service : RemoveEmployee(int employeeId) : Exception occured in DAL :{exception.Message}");
                return false;
            }
        }


        public IEnumerable<Employee> ViewTACRequest()
        {
            try
            {
                IEnumerable<Employee> employees = new List<Employee>();
                return employees = from employee in _employeeDataAccessLayer.GetEmployeesFromDatabase() where employee.IsAdminAccepted == false && employee.IsAdminResponded == false select employee;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Employee service : RemoveEmployee(int employeeId) : Exception occured in DAL :{exception.Message}");
                return false;
            }
        }
    }
}
