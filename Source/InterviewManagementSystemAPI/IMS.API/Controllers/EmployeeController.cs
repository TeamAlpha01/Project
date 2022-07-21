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

    public EmployeeController(ILogger<EmployeeController> logger, IMailService mailService, IEmployeeService employeeService) //
    {
        _logger = logger;
        _mailService = mailService;
        _employeeService = employeeService;
    }

    /// <summary>
    /// This method is used to register as a new employee
    /// </summary>
    /// <response code="200">If new employee was created</response>
    /// <response code="400">If the item is null or validation exception occurs</response> 
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
            if (_employeeService.CreateNewEmployee(employee))
            {
                //_mailService.SendEmailAsync(_mailService.WelcomeEmployeeMail(employee.EmailId,employee.Name),true);
                return Ok(UtilityService.Response("Account has been created sucessfully. Please wait until you receive a mail from administrator"));
            }
            return Problem("Sorry internal error occured");
        }
        catch (ValidationException employeeNameException)
        {
            _logger.LogError($"Employee Service : CreateNewEmployee(Employee employee) : {employeeNameException.Message}");
            return BadRequest(UtilityService.Response(employeeNameException.Message));
        }
        catch (MailException mailException)
        {
            _logger.LogWarning($"Employee Controller : CreateNewEmployee(Employee employee) : {mailException.Message} : {mailException.StackTrace}");
            return Ok("Account Cancelled Successfully but failed to send email");
        }
        catch (Exception exception)
        {
            _logger.LogError($"Employee Service : CreateNewEmployee throwed an exception : {exception.Message}");
            return Problem("Sorry some internal error occured");
        }
    }
    /// <summary>
    /// This method is used to remove employee
    /// </summary>
    /// <response code="200">If employee was removed successfully</response>
    /// <response code="400">If the item is null or validation exception occurs</response>
    /// <response code="500">If there is problem in server</response>
    /// <param name="employeeId"></param>
    /// <returns>
    /// Return success message when employee removed
    /// Return Badrequest when validation exception or 
    /// Return Problem when some internal error occurred
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
            _logger.LogError($"Employee Service : RemoveEmployee throwed an exception : {exception.Message}");
            return Problem("Sorry some internal error occured");
        }
    }
    /// <summary>
    /// This method is used view list of employees 
    /// </summary>
    /// <response code="200">Returns list of employee</response>
    /// <response code="400">If the item is null</response>
    /// <response code="500">If there is problem in server</response>
    /// <returns>
    /// Return list of all employees or
    /// Return Problem when exception occured in the EmployeeService layer.
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
            _logger.LogError($"Service throwed exception while fetching employees : {exception.Message}");
            return Problem("Sorry some internal error occured");
        }
    }
    /// <summary>
    /// This method is used to view employee profile
    /// </summary>
    /// <response code="200">Returns employee profile</response>
    /// <response code="400">If the item is null or validation exception occurs</response>
    /// <response code="500">If there is problem in server</response>
    /// <param name="employeeId"></param>
    /// <returns>
    /// Return Employee details(profile) or
    /// Return problem when exception occured in the EmployeeService layer.
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
            _logger.LogError($"Service throwed exception while fetching employees : {exception.Message}");
            return Problem("Sorry some internal error occured");
        }
    }
    /// <summary>
    /// This is used to view their profile
    /// </summary>
    /// <returns>
    /// Returns his/her profile or
    /// Returns problem when internal problem occurs
    /// </returns>
    [HttpGet]
    public IActionResult ViewEmployeeProfile()
    {
        try
        {
            int currentUser = Convert.ToInt32(User.FindFirst("UserId")?.Value);
            return Ok(_employeeService.ViewProfile(currentUser));
        }
        catch (Exception exception)
        {
            _logger.LogError($"Service throwed exception while fetching employees : {exception.Message}");
            return Problem("Sorry some internal error occured");
        }
    }
    /// <summary>
    /// This method is used to view list of employees by department
    /// </summary>
    /// <response code="200">Returns list of employees by department</response>
    /// <response code="400">If the item is null or validations exception occurs</response>
    /// <response code="500">If there is problem in server</response>
    /// <param name="departmentId"></param>
    /// <returns>
    /// Return list of employees by department  or
    /// Return BadRequest when validation exception occurs or 
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
            _logger.LogError($"Employee controller:ViewEmployeesByDepartment(int departmentId):{exception1.Message}:{exception1.StackTrace}");
            return BadRequest(exception1.Message);
        }
        catch (Exception exception)
        {
            _logger.LogError($"Service throwed exception while fetching employees : {exception.Message}:{exception.StackTrace}");
            return Problem("Sorry some internal error occured");
        }

    }
    [HttpGet]
    public IActionResult ViewEmployeesByDepartmentForCurrentUser()
    {
        try
        {
            int departmentId = Convert.ToInt32(User.FindFirst("DepartmentId")?.Value);
            return Ok(_employeeService.ViewEmployeesByDepartment(departmentId));
        }
        catch (ValidationException exception1)
        {
            _logger.LogError($"Employee controller:ViewEmployeesByDepartment(int departmentId):{exception1.Message}:{exception1.StackTrace}");
            return BadRequest(exception1.Message);
        }
        catch (Exception exception)
        {
            _logger.LogError($"Service throwed exception while fetching employees : {exception.Message}:{exception.StackTrace}");
            return Problem("Sorry some internal error occured");
        }

    }
    /// <summary>
    /// This method is used to view whether employee is accepted by admin or not
    /// </summary>
    /// <response code="200">Returns list of approved employee</response>
    /// <response code="500">If there is problem in server</response>
    /// <param name="isAdminAccepted"></param>
    /// <returns>Returns list of employees where accepted by admin or
    /// Returns problem when internal error occurs </returns>
    [HttpGet]
    public IActionResult ViewEmployeeByApprovalStatus(bool isAdminAccepted)
    {


        try
        {
            return Ok(_employeeService.ViewEmployeeByApprovalStatus(isAdminAccepted));
        }
        catch (Exception exception)
        {
            _logger.LogError($"Service throwed exception while fetching employees : {exception.Message}");
            return Problem("Sorry some internal error occured");
        }
    }
    /// <summary>
    /// This method is used to view request received from the employee
    /// </summary>
    /// <response code="200">Returns list of request from employee</response>
    /// <response code="500">If there is problem in server</response>
    /// <returns>Returns list of request received from employee or
    /// Returns Problem when internal error occurs
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
            _logger.LogError($"Service throwed exception while fetching employees : {exception.Message}");
            return Problem("Sorry some internal error occured");
        }
    }
    /// <summary>
    /// This method is used to respond request received from employee
    /// </summary>
    /// <param name="employeeId">int</param>
    /// <param name="response">bool</param>
    /// <returns>Returns true after accept/reject request from employee or
    /// Returns bad request when employeeId is null</returns>
    [HttpPatch]
    public IActionResult RespondEmployeeRequest(int employeeId, bool response)
    {
        if (employeeId <= 0)
            return BadRequest("Employee Id cannot be zero or less than zero ");
        try
        {
            if (response)
            {
                return _employeeService.RespondEmployeeRequest(employeeId, response) ? Ok(UtilityService.Response("Employee's request is accepted Successfully")) : Problem("Sorry internal error occured");
            }
            else
            {
                return _employeeService.RespondEmployeeRequest(employeeId, response) ? Ok(UtilityService.Response("Employee's request is rejected.")) : Problem("Sorry internal error occured");

            }
        }
        catch (ValidationException exception)
        {
            _logger.LogError($"Employee Controller:RespondEmployeeRequest(int employeeId,bool response): {exception.Message}");
            return BadRequest(exception.Message);
        }
        catch (Exception exception)
        {
            _logger.LogError($"Service throwed exception while fetching employees : {exception.Message}");
            return Problem("Sorry some internal error occured");
        }
    }

}
