using Microsoft.AspNetCore.Mvc;
using IMS.Model;
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
    /// Returns OK when role is added successfully or
    /// Returns Badrequest or Problem when exception is occured in the EmployeeService layer.
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
    /// Returns OK when employee is removed successfully or
    /// Returns Badrequest when exception is occured in the EmployeeService layer.
    /// </returns>
    [HttpPatch]
    public IActionResult RemoveEmployee(int employeeId)
    {
        EmployeeValidation.IsEmployeeId(employeeId);

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
    /// Returns list of all employees or
    /// Returns BadRequest when exception is occured in the EmployeeService layer.
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
    /// This method implements when you want to see employees list filtered by department id,
    /// this method calls the ViewEmployeesByDepartment method in servive layer(EmployeeService)
    /// </summary>
    /// <param name="departmentId"></param>
    /// <returns>
    /// Returns list of employees filtered by department or
    /// Returns BadRequest when exception is occured in the EmployeeService layer.
    /// </returns>
    [HttpGet]
    public IActionResult ViewEmployeesByDepartment(int departmentId)
    {
        try
        {
            return Ok(employeeService.ViewEmployeesByDepartment(departmentId));
        }
        catch (Exception exception)
        {
            _logger.LogInformation($"Service throwed exception while fetching roles : {exception}");
            return BadRequest("Sorry some internal error occured");
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult ViewEmployeeByApprovalStatus()
    {
        try
        {
            return Ok(employeeService.ViewEmployeeByApprovalStatus());
        }
        catch (Exception exception)
        {
            _logger.LogInformation($"Service throwed exception while fetching roles : {exception}");
            return BadRequest("Sorry some internal error occured");
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult ViewTACRequest()
    {
        try
        {
            return Ok(employeeService.ViewTACRequest());
        }
        catch (Exception exception)
        {
            _logger.LogInformation($"Service throwed exception while fetching roles : {exception}");
            return BadRequest("Sorry some internal error occured");
        }
    }
}
