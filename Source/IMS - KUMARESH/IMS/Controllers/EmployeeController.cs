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
    // private IEmployeeService _employee = DataFactory.EmployeeDataFactory.GetEmployeeServiceObject(_logger);


    public IActionResult CreateNewEmployee(Employee employee)
    {
        try
        {
            return Employee.CreateNewEmployee(employee) ? Ok("Role Added Successfully") : Problem("Sorry internal error occured");
        }
        catch(ValidationException employeeNameException)
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
    public IActionResult RemoveEmployee(int employeeId)
    {
         if (employeeId == 0) return BadRequest("Role Id is not provided");

        try
        {
            return employeeService.RemoveEmployee(employeeId) ? Ok("Role Removed Successfully") : BadRequest("Sorry internal error occured");
        }
        catch(ValidationException employeeNotFound)
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
