using Microsoft.AspNetCore.Mvc;
using IMS.Models;
using IMS.Service;
using IMS.DataFactory;
using System.Net;
using System.ComponentModel.DataAnnotations;

namespace IMS.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class EmployeeController : ControllerBase
{
    private readonly ILogger _logger;
    private IEmployeeService employeeService;
    public EmployeeController(ILogger<EmployeeController> logger)
    {
        _logger = logger;
        employeeService = DataFactory.EmployeeDataFactory.GetEmployeeServiceObject(_logger);
    }

    /// <summary>
    /// This method will implements when you create or register new employee, this method calls the CreateNewEmployee method 
    /// in servive layer(EmployeeService)
    /// </summary>
    /// <param name="employee"></param>
    /// <returns>
    /// Return OK when role is added successfully or
    /// Return Badrequest or Problem when exception occured in the EmployeeService layer.
    /// </returns>
    [HttpPost]
    public IActionResult CreateNewEmployee(Employee employee)
    {
        try
        {
            return employeeService.CreateNewEmployee(employee) ? Ok("Role Added Successfully") : Problem("Sorry internal error occured");
        }
        catch (ValidationException employeeNameException)
        {
            _logger.LogInformation($"Employee Service : CreateNewEmployee() : {employeeNameException.Message}");
            return BadRequest(employeeNameException.Message);
        }
        catch (Exception exception)
        {
            _logger.LogInformation($"Employee Service : CreateNewEmployee throwed an exception : {exception}");
            return Problem("Sorry some internal error occured");
        }
    }
    /// <summary>
    /// This method will implements if you remove any employee, this method calls the RemoveEmployee method 
    /// in servive layer(EmployeeService)
    /// </summary>
    /// <param name="employeeId"></param>
    /// <returns>
    /// Return OK when employee is removed successfully or
    /// Return Badrequest when exception occured in the EmployeeService layer.
    /// </returns>
    [HttpPatch]
    public IActionResult RemoveEmployee(int employeeId)
    {

        try
        {
            return employeeService.RemoveEmployee(employeeId) ? Ok("Employee Removed Successfully") : BadRequest("Sorry internal error occured");
        }
        catch (ValidationException employeeNotFound)
        {
            _logger.LogInformation($"Employee Service : RemoveEmployee() : {employeeNotFound.Message}");
            return BadRequest(employeeNotFound.Message);
        }
        catch (Exception exception)
        {
            _logger.LogInformation($"Employee Service : RemoveEmployee throwed an exception : {exception}");
            return BadRequest("Sorry some internal error occured");
        }
    }
    /// <summary>
    /// This method implements when you want to see all the employees list, this method calls the ViewEmployees method 
    /// in servive layer(EmployeeService)
    /// </summary>
    /// <returns>
    /// Return list of all employees or
    /// Return BadRequest when exception occured in the EmployeeService layer.
    /// </returns>
    [HttpGet]
    public IActionResult ViewEmployees()
    {
        try
        {
            return Ok(employeeService.ViewEmployees());
        }
        catch (Exception exception)
        {
            _logger.LogInformation($"Service throwed exception while fetching roles : {exception}");
            return BadRequest("Sorry some internal error occured");
        }
    }
    /// <summary>
    /// This method implements when you want see your profile,this method calls the ViewProfile method 
    /// in servive layer(EmployeeService)
    /// </summary>
    /// <param name="employeeId"></param>
    /// <returns>
    /// Return Employee details(profile) or
    /// Return BadRequest when exception occured in the EmployeeService layer.
    /// </returns>
    [HttpGet]
    public IActionResult ViewProfile(int employeeId)
    {
        try
        {
            return Ok(employeeService.ViewProfile(employeeId));
        }
        catch (Exception exception)
        {
            _logger.LogInformation($"Service throwed exception while fetching employees : {exception}");
            return BadRequest("Sorry some internal error occured");
        }
    }
    /// <summary>
    /// This method implements when you want to see employees list filtered by department id,
    /// this method calls the ViewEmployeesByDepartment method in servive layer(EmployeeService)
    /// </summary>
    /// <param name="departmentId"></param>
    /// <returns>
    /// Return list of employees filtered by department id or
    /// Return BadRequest when exception occured in the EmployeeService layer.
    /// </returns>
    [HttpGet]
    public IActionResult ViewEmployeesByDepartment(int departmentId)
    {
        try
        {
            return Ok(employeeService.ViewEmployeesByDepartment(departmentId));
        }
        catch (ValidationException exception1)
        {
            _logger.LogInformation($"Service throwed exception while fetching roles : {exception1}");
            return BadRequest(exception1.Message);
        }
        catch (Exception exception)
        {
            _logger.LogInformation($"Service throwed exception while fetching employees : {exception}");
            return BadRequest("Sorry some internal error occured");
        }

    }
    /// <summary>
    /// This method implements when admin want to see their approval status,
    /// this method calls the ViewEmployeeByApprovalStatus method in servive layer(EmployeeService)
    /// </summary>
    /// <param name="isAdminAccepted"></param>
    /// <returns>
    /// Return list of employees who are approved or rejected by admin based on isAdminAccepted parameter or
    /// Return BadRequest when exception occured in the EmployeeService layer.
    /// </returns>
    [HttpGet]
    public IActionResult ViewEmployeeByApprovalStatus(bool isAdminAccepted)
    {
        try
        {
            return Ok(employeeService.ViewEmployeeByApprovalStatus(isAdminAccepted));
        }
        catch (Exception exception)
        {
            _logger.LogInformation($"Service throwed exception while fetching employees : {exception}");
            return BadRequest("Sorry some internal error occured");
        }
    }
    /// <summary>
    /// This method implements when admin want to see who has sent a request to admin,
    /// this method calls the ViewEmployeeRequest method in servive layer(EmployeeService)
    /// </summary>
    /// <returns>
    /// Return list of employees who has sent a request to admin and doesn't shows a accepted request or 
    /// Return BadRequest when exception occured in the EmployeeService layer.
    /// </returns>
    [HttpGet]
    public IActionResult ViewEmployeeRequest()
    {
        try
        {
            return Ok(employeeService.ViewEmployeeRequest());
        }
        catch (Exception exception)
        {
            _logger.LogInformation($"Service throwed exception while fetching employees : {exception}");
            return BadRequest("Sorry some internal error occured");
        }
    }
    [HttpGet]
    public IActionResult Login(string employeeAceNumber, string password)
    {

        try
        {
            return employeeService.Login(employeeAceNumber, password) ? Ok("Login Successfully") : Problem("Invalid ACE Number or Password");

        }
        catch (Exception exception)
        {
            _logger.LogInformation($"Employee Service : Login throwed an exception : {exception}");
            return Problem("Sorry some internal error occured");
        }
    }
}
