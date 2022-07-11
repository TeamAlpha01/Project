using Microsoft.AspNetCore.Mvc;
using IMS.Models;
using IMS.Service;
using IMS.DataFactory;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using IMS.CustomExceptions;

namespace IMS.Controllers;
[Authorize]
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
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response> 
    /// <response code="500">If there is problem in server</response>
    /// <param name="employee"></param>
    /// <returns>
    /// Return OK when role is added successfully or
    /// Return Badrequest or Problem when exception occured in the EmployeeService layer.
    /// </returns>
    [AllowAnonymous]
    [HttpPost]
    public IActionResult CreateNewEmployee(Employee employee)
    {
        try
        {
            if(_employeeService.CreateNewEmployee(employee))
            {
                //_mailService.SendEmailAsync(_mailService.WelcomeEmployeeMail(employee.EmailId,employee.Name),true);
                return Ok(UtilityService.Response("Account has been created sucessfully. Please Wait untill Admin verfies your account"));
            }
            return Problem("Sorry internal error occured");
        }
        catch (ValidationException employeeNameException)
        {
            _logger.LogError($"Employee Service : CreateNewEmployee(Employee employee) : {employeeNameException.Message}");
            return BadRequest(employeeNameException.Message);
        }
        catch (MailException mailException)
        {
            _logger.LogWarning($"Employee Controller : CreateNewEmployee(Employee employee) : {mailException.Message} : {mailException.StackTrace}");
            return Ok("Account Cancelled Successfully but failed to send email");
        }
        catch (Exception exception)
        {
            _logger.LogError($"Employee Service : CreateNewEmployee throwed an exception : {exception}");
            return Problem("Sorry some internal error occured");
        }
    }
    /// <summary>
    /// This method will implements if Admin wants to remove any Employee.
    /// </summary>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    /// <response code="500">If there is problem in server</response>
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
            _logger.LogError($"Employee Service : RemoveEmployee(int employeeId) : {employeeNotFound.Message}");
            return BadRequest(employeeNotFound.Message);
        }
        catch (Exception exception)
        {
            _logger.LogError($"Employee Service : RemoveEmployee throwed an exception : {exception}");
            return Problem("Sorry some internal error occured");
        }
    }
    /// <summary>
    /// This method will be implemented when Admin want to see all the Employees list.
    /// </summary>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    /// <response code="500">If there is problem in server</response>
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
            _logger.LogError($"Service throwed exception while fetching roles : {exception}");
            return Problem("Sorry some internal error occured");
        }
    }
    /// <summary>
    /// This method implements when you want see your profile of an Employee.
    /// </summary>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    /// <response code="500">If there is problem in server</response>
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
            _logger.LogError($"Service throwed exception while fetching employees : {exception}");
            return Problem("Sorry some internal error occured");
        }
    }
    [HttpGet]
    public IActionResult ViewEmployeeProfile()
    {
        try
        {
            int currentUser=Convert.ToInt32(User.FindFirst("UserId").Value);
            return Ok(_employeeService.ViewProfile(currentUser));
        }
        catch (Exception exception)
        {
            _logger.LogError($"Service throwed exception while fetching employees : {exception}");
            return Problem("Sorry some internal error occured");
        }
    }
    /// <summary>
    /// This method implements when you want to see employees list filtered by Department id.
    /// </summary>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    /// <response code="500">If there is problem in server</response>
    /// <param name="departmentId"></param>
    /// <returns>
    /// Return list of employees filtered by department id or
    /// Return BadRequest when exception occured in the EmployeeService layer or 
    /// Return Problem when problem arises in server
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
            _logger.LogError($"Service throwed exception while fetching roles : {exception1}");
            return BadRequest(exception1.Message);
        }
        catch (Exception exception)
        {
            _logger.LogError($"Service throwed exception while fetching employees : {exception}");
            return Problem("Sorry some internal error occured");
        }

    }
    /// <summary>
    /// This method implements when admin want to see their Approval status.
    /// </summary>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    /// <response code="500">If there is problem in server</response>
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
            _logger.LogError($"Service throwed exception while fetching employees : {exception}");
            return Problem("Sorry some internal error occured");
        }
    }
    /// <summary>
    /// This method implements when admin want to see who has sent a request to Admin.
    /// </summary>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    /// <response code="500">If there is problem in server</response>
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
            _logger.LogError($"Service throwed exception while fetching employees : {exception}");
            return BadRequest("Sorry some internal error occured");
        }
    }
    /// <summary>
    /// To respond request received from the employee
    /// </summary>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    /// <response code="500">If there is problem in server</response>
    /// <param name="employeeId"></param>
    /// <param name="response"></param>
    /// <returns>Returns list of request received from the employee or Returns Exception when problem in server</returns>
    [HttpPatch]
    public IActionResult RespondEmployeeRequest(int employeeId,bool response)
    {
        if(employeeId<=0)
            return BadRequest("Employee Id cannot be zero or less than zero ");
        try
        {
            return Ok(_employeeService.RespondEmployeeRequest(employeeId,response));
        }
        catch (Exception exception)
        {
            _logger.LogError($"Service throwed exception while fetching employees : {exception}");
            return Problem("Sorry some internal error occured");
        }
    }
    
}
