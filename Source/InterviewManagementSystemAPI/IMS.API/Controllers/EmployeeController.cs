using Microsoft.AspNetCore.Mvc;
using IMS.Models;
using IMS.Service;
using IMS.DataFactory;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using IMS.CustomExceptions;

namespace IMS.Controllers;
//[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class EmployeeController : ControllerBase
{
    private readonly ILogger _logger;
    private IEmployeeService _employeeService;
    private IMailService _mailService;

    public EmployeeController(ILogger<EmployeeController> logger,IMailService mailService,IEmployeeService employeeService) //
    {
        _logger = logger;
        _mailService = mailService;
        _employeeService = employeeService;//DataFactory.EmployeeDataFactory.GetEmployeeServiceObject(_logger);
    }

    /// <summary>
    /// This method will implements when you create or register new employee.
    /// </summary>
    ///  <remarks>
    /// Sample request:
    ///
    ///     POST /CreateNewEmployee
    ///     {
    ///        "employeeId": 0,
    ///        "employeeAceNumber": "ACE0001",
    ///        "name": "Prithvi",
    ///        "departmentId": 1,
    ///        "roleId": 2,
    ///        "projectId": 3,
    ///        "emailId": "Prithvi123@gmail.com",
    ///        "password": "string@90182",
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response> 
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
            if(_employeeService.CreateNewEmployee(employee))
            {
                _mailService.SendEmailAsync(_mailService.WelcomeEmployeeMail(employee.EmailId,employee.Name),true);
                return Ok("Account Created Successfully");
            }
            return Problem("Sorry internal error occured");
        }
        catch (ValidationException employeeNameException)
        {
            _logger.LogInformation($"Employee Service : CreateNewEmployee() : {employeeNameException.Message}");
            return BadRequest(employeeNameException.Message);
        }
        catch (MailException mailException)
        {
            _logger.LogInformation($"Employee Controller : CreateNewEmployee() : {mailException.Message} : {mailException.StackTrace}");
            return Ok("Account Cancelled Successfully but failed to send email");
        }
        catch (Exception exception)
        {
            _logger.LogInformation($"Employee Service : CreateNewEmployee throwed an exception : {exception}");
            return Problem("Sorry some internal error occured");
        }
    }
    /// <summary>
    /// This method will implements if Admin wants to remove any Employee.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     PATCH /RemoveEmployee
    ///     {
    ///        "Employee ID": "1",
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
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
            return _employeeService.RemoveEmployee(employeeId) ? Ok("Employee Removed Successfully") : Problem("Sorry internal error occured");
        }
        catch (ValidationException employeeNotFound)
        {
            _logger.LogInformation($"Employee Service : RemoveEmployee() : {employeeNotFound.Message}");
            return BadRequest(employeeNotFound.Message);
        }
        catch (Exception exception)
        {
            _logger.LogInformation($"Employee Service : RemoveEmployee throwed an exception : {exception}");
            return Problem("Sorry some internal error occured");
        }
    }
    /// <summary>
    /// This method will be implemented when Admin want to see all the Employees list.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /ViewEmployees
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    /// <returns>
    /// Return list of all employees or
    /// Return BadRequest when exception occured in the EmployeeService layer.
    /// </returns>
    [HttpGet]
    public IActionResult ViewEmployees()
    {
        try
        {
            return Ok(_employeeService.ViewEmployees());
        }
        catch (Exception exception)
        {
            _logger.LogInformation($"Service throwed exception while fetching roles : {exception}");
            return Problem("Sorry some internal error occured");
        }
    }
    /// <summary>
    /// This method implements when you want see your profile of an Employee.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///     GET/ViewProfile
    ///     {
    ///        "Employee ID": "1",
    ///     }
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
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
            return Ok(_employeeService.ViewProfile(employeeId));
        }
        catch (Exception exception)
        {
            _logger.LogInformation($"Service throwed exception while fetching employees : {exception}");
            return Problem("Sorry some internal error occured");
        }
    }
    /// <summary>
    /// This method implements when you want to see employees list filtered by Department id.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /ViewEmployeesByDepartment
    /// {
    ///        "Department ID": "1",
    ///     }
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
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
            return Ok(_employeeService.ViewEmployeesByDepartment(departmentId));
        }
        catch (ValidationException exception1)
        {
            _logger.LogInformation($"Service throwed exception while fetching roles : {exception1}");
            return BadRequest(exception1.Message);
        }
        catch (Exception exception)
        {
            _logger.LogInformation($"Service throwed exception while fetching employees : {exception}");
            return Problem("Sorry some internal error occured");
        }

    }
    /// <summary>
    /// This method implements when admin want to see their Approval status.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /ViewEmployeesByApprovalStatus
    /// {
    ///        "isAdminAccepted": "1",
    ///     }
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    /// <param name="isAdminAccepted"></param>
    /// <returns>
    /// Return list of employees who are approved or rejected by admin based on isAdminAccepted parameter or
    /// Return Problem when exception occured in the EmployeeService layer.
    /// </returns>
    [HttpGet]
    public IActionResult ViewEmployeeByApprovalStatus(bool isAdminAccepted)
    {
        try
        {
            return Ok(_employeeService.ViewEmployeeByApprovalStatus(isAdminAccepted));
        }
        catch (Exception exception)
        {
            _logger.LogInformation($"Service throwed exception while fetching employees : {exception}");
            return Problem("Sorry some internal error occured");
        }
    }
    /// <summary>
    /// This method implements when admin want to see who has sent a request to Admin.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /ViewEmployeeRequest
    /// 
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    /// <returns>
    /// Return list of employees who has sent a request to admin and doesn't shows a accepted request or 
    /// Return BadRequest when exception occured in the EmployeeService layer.
    /// </returns>
    [HttpGet]
    public IActionResult ViewEmployeeRequest()
    {
        try
        {
            return Ok(_employeeService.ViewEmployeeRequest());
        }
        catch (Exception exception)
        {
            _logger.LogInformation($"Service throwed exception while fetching employees : {exception}");
            return BadRequest("Sorry some internal error occured");
        }
    }
    [HttpPatch]
    public IActionResult RespondEmployeeRequest(int employeeId,bool response)
    {
        try
        {
            return Ok(_employeeService.RespondEmployeeRequest(employeeId,response));
        }
        catch (Exception exception)
        {
            _logger.LogInformation($"Service throwed exception while fetching employees : {exception}");
            return BadRequest("Sorry some internal error occured");
        }
    }
    
}
