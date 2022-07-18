using IMS.Models;
using IMS.DataAccessLayer;
using IMS.Validations;
using IMS.DataFactory;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IMS.Service
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeDataAccessLayer _employeeDataAccessLayer;
        private IDepartmentDataAccessLayer _departmentDataAccessLayer;
        private IRoleDataAccessLayer _roleDataAccessLayer;
        private ILogger _logger;
        
        private readonly Stopwatch _stopwatch = new Stopwatch();
         private bool IsTracingEnabled;

        public EmployeeService(ILogger<IEmployeeService> logger, IEmployeeDataAccessLayer employeeDataAccessLayer, IDepartmentDataAccessLayer departmentDataAccessLayer, IRoleDataAccessLayer roleDataAccessLayer)
        {
            _logger = logger;
            _employeeDataAccessLayer = employeeDataAccessLayer;//DataFactory.EmployeeDataFactory.GetEmployeeDataAccessLayerObject(_logger);
            _departmentDataAccessLayer = departmentDataAccessLayer; //DataFactory.DepartmentDataFactory.GetDepartmentDataAccessLayerObject(_logger);
            _roleDataAccessLayer = roleDataAccessLayer;//DataFactory.RoleDataFactory.GetRoleDataAccessLayerObject(_logger);
            IsTracingEnabled = _employeeDataAccessLayer.GetIsTraceEnabledFromConfiguration();
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
            _stopwatch.Start();
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
                _logger.LogError($"Employee Service : CreateEmployee() : {employeeNotValid.Message}");
                throw employeeNotValid;
            }
            catch (Exception exception)
            {
                _logger.LogError($"Employee Service : CreateEmployee() : {exception.Message}");
                throw ;
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Employee Service Time elapsed for  CreateNewEmployee(Employee employee) :{_stopwatch.ElapsedMilliseconds}ms");
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
            _stopwatch.Start();
            // if (employeeId <= 0)
            //     throw new ValidationException("Employee Id is not provided");

            EmployeeValidation.IsEmployeeIdValid(employeeId);

            try
            {
                return _employeeDataAccessLayer.RemoveEmployeeFromDatabase(employeeId) ? true : false;
            }
            catch (ArgumentException exception)
            {
                _logger.LogError($"Employee service : RemoveEmployee(int employeeId) : {exception.Message}");
                throw exception;
            }
            catch (ValidationException employeeNotFound)
            {
                _logger.LogError($"Employee service : CreateEmployee(Employee employee) : {employeeNotFound.Message}");
                throw employeeNotFound;
            }
            catch (Exception exception)
            {
                _logger.LogError($"Employee service : RemoveEmployee(int employeeId) : {exception.Message}");
                throw ;
            }
            
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Employee Service Time elapsed for RemoveEmployee(int employeeId)  :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }
        /// <summary>
        /// This method will implemented when EmployeeController passes the request to this method,then this method calls the GetEmployeesFromDatabase method in DAL.
        /// </summary>
        /// <returns>
        /// Returns list of all employees who are in "IsActive==true" or
        /// Throws an exception when exception is occured in GetEmployeesFromDatabase method in DAL.
        /// </returns>
        public Object ViewEmployees()
        {
            _stopwatch.Start();
            try
            {
                return  _employeeDataAccessLayer.GetEmployeesFromDatabase().
                Select(
                    employee => new{
                        employeeId=employee.EmployeeId,
                        employeeName=employee.Name,
                        employeeAceNumber=employee.EmployeeAceNumber,
                        employeeDepartmentName=employee.Department!.DepartmentName,
                        employeeProjectName=employee.Project!.ProjectName,
                        employeeRoleName=employee.Role!.RoleName,
                    }
                );
            }
            catch (Exception exception)
            {   
                _logger.LogError($"Employee service : RemoveEmployee(int employeeId) : Exception occured in DAL :{exception.Message}");
                throw new Exception();
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Employee Service Time elapsed for  ViewEmployees() :{_stopwatch.ElapsedMilliseconds}ms");
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
            _stopwatch.Start();
            EmployeeValidation.IsEmployeeIdValid(employeeId);
            try
            {
                var _employee = _employeeDataAccessLayer.ViewProfile(employeeId);
                return new
                {
                    EmployeeACEId = _employee.EmployeeAceNumber,
                    EmployeeName = _employee.Name,
                    EmployeeDepartment = _employee.Department!.DepartmentName,
                    EmployeeProject = _employee.Project!.ProjectName,
                    EmployeeRole = _employee.Role!.RoleName,
                    EmployeeEmailID = _employee.EmailId
                    //EmployeePoolName = _employee.PoolMembers.Pools.PoolName,
                };
            }
            catch (ValidationException viewEmployeeNotValid)
            {
                _logger.LogError($"Employee Service : ViewProfile(int employeeId) : {viewEmployeeNotValid.Message} : {viewEmployeeNotValid.StackTrace}");
                throw viewEmployeeNotValid;
            }
            catch (Exception viewEmployeeException)
            {
                _logger.LogError($"Employee Service : ViewProfile(int employeeId) : {viewEmployeeException.Message} : {viewEmployeeException.StackTrace}");
                throw ;
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Employee Service Time elapsed for  ViewProfile(int employeeId) :{_stopwatch.ElapsedMilliseconds}ms");
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
        public Object ViewEmployeesByDepartment(int departmentId)
        {
            _stopwatch.Start();
            EmployeeValidation.IsDepartmentValid(departmentId);
            _departmentDataAccessLayer.CheckDepartmentId(departmentId);

            try
            {
                List<Object> employees = new List<Object>();
                var employee = _employeeDataAccessLayer.ViewEmployeeByDepartment(departmentId)
                .Select(e => new
                {
                    EmployeeACEId = e.EmployeeAceNumber,
                    EmployeeName = e.Name,
                    EmployeeDepartment = e.Department!.DepartmentName,
                    EmployeeProject = e.Project!.ProjectName,
                    EmployeeRole = e.Role!.RoleName,
                    EmployeeEmailID = e.EmailId

                }
                );
                foreach (var item in employee)
                {
                    employees.Add(item);
                }
                return employees;
            }
            catch (Exception exception)
            {
                _logger.LogError($"Employee service : ViewEmployeesByDepartment(int employeeId) : Exception occured in DAL :{exception.Message}");
                throw new Exception();
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Employee Service Time elapsed for ViewEmployeesByDepartment(int departmentId) :{_stopwatch.ElapsedMilliseconds}ms");
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
            _stopwatch.Start();
            try
            {
                IEnumerable<Employee> employees = new List<Employee>();
                return employees = _employeeDataAccessLayer.GetApprovedEmployessFromDatabase(isAdminAccepted);
            }
            catch (Exception exception)
            {
                _logger.LogError($"Employee service : ViewEmployeeByApprovalStatus : Exception occured in DAL :{exception.Message}");
                throw new Exception();
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Employee Service Time elapsed for  ViewEmployeeByApprovalStatus(bool isAdminAccepted) :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }
        /// <summary>
        /// This method implements when EmployeeController passes the request to this method,then this method calls the ViewEmployeeRequest method in DAL.
        /// </summary>
        /// <returns>
        /// Return list of employees who has sent a request to admin and doesn't shows a accepted request or 
        /// Throws an exception when exception is occured in GetEmployeesFromDatabase method in DAL.
        /// </returns>

        public object ViewEmployeeRequest()
        {
            _stopwatch.Start();
            try
            {
                return  _employeeDataAccessLayer.GetEmployeesRequestFromDatabase()
                .Select(
                    e => new{
                        employeeId = e.EmployeeId,
                        employeeAceNumber = e.EmployeeAceNumber,
                        employeeName = e.Name,
                        employeeDepartment= e.Department!.DepartmentName,
                        employeeRole=e.Role!.RoleName
                    } 
                );
            }
            catch (Exception exception)
            {
                _logger.LogError($"Employee service : ViewTACRequest : Exception occured in DAL :{exception.Message}");
                throw new Exception();
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Employee Service Time elapsed for  ViewEmployeeRequest() :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }
        public bool Login(string employeeAceNumber, string password)
        {
            _stopwatch.Start();
            try
            {
                return true;

            }
            catch (Exception exception)
            {
                _logger.LogError($"Employee DAL : CheckLoginCredentails throwed an exception : {exception.Message}");
                throw;
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Employee Service Time elapsed for Login(string employeeAceNumber, string password)  :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }

        public bool RespondEmployeeRequest(int employeeId, bool response)
        {
            _stopwatch.Start();
            EmployeeValidation.IsEmployeeIdValid(employeeId);
            try
            {
                return _employeeDataAccessLayer.RespondEmployeeRequest(employeeId,response);
            } 
            catch (ValidationException exception)
            {
                _logger.LogError($"Employee service:RespondEmployeeRequest(int employeeId,bool response) : {exception.Message}");
                throw exception;
            }
            catch (Exception exception)
            {
                _logger.LogError($"Employee DAL : CheckLoginCredentails throwed an exception : {exception.Message}");
                throw ;
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Employee Service Time elapsed for  RespondEmployeeRequest(int employeeId, bool response) :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }
    }
}