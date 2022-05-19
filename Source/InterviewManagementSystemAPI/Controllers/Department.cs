using IMS.Service;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
namespace IMS.Controllers;

    
[ApiController]
[Route("[controller]/[action]")]
public class DepartmentController : ControllerBase
{
    private readonly ILogger _logger;
     IDepartmentService departmentService;

    public DepartmentController(ILogger<DepartmentController> logger)
    {
        _logger = logger;
         departmentService = DataFactory.DepartmentDataFactory.GetDepartmentServiceObject(_logger);
    }
    
/// <summary>
///  This Method Will Implement When Create New Department Request rises-The Department controller passes the  parameter 
/// to the Department Service.Validating Department Name in this method to pass the parameter to service.
/// </summary>
/// <param name="departmentName">String</param>
/// <returns>Return Department Added Successfully when the department is added in the database otherwise return Sorry internal error occured.It returns validation exeption or Exception when exception thrown in service .</returns>
    [HttpPost]
    public IActionResult CreateNewDepartment(string departmentName)
    {
        if (departmentName == null)
            return BadRequest("Department name is required");
        try
        {
            return departmentService.CreateDepartment(departmentName) ? Ok("Department Added Successfully") : Problem("Sorry internal error occured");
        }
         catch (ValidationException departmentnotvalid)
        {
             _logger.LogInformation($"Department Controller : CreateDepartment(string departmentName) : {departmentnotvalid.Message} : {departmentnotvalid.StackTrace}");
            return BadRequest(departmentnotvalid.Message);
        }
        catch (Exception exception)
        {
            _logger.LogInformation($"Department Controller : CreateDepartment(string departmentName) : {exception.Message} : {exception.StackTrace}");
            return BadRequest(exception.Message);
        }
    }
/// <summary>
/// This Method Will Implement When Remove Department Request rises-The Department controller passes the the parameter 
/// to the Department Service.validating Department Id in this method to pass the parameter to service.
/// </summary>
/// <param name="departmentId">int</param>
/// <returns>Return Department Removed Successfully message when project Isctive is set to 0 otherwise return Sorry internal error occured .It returns validation exeption or Exception when exception thrown in service.</returns>
    [HttpPost]
    public IActionResult RemoveDepartment(int departmentId)
    {
        if (departmentId <= 0) return BadRequest("Department Id  Should not be zero or less than zero");

        try
        {
            return departmentService.RemoveDepartment(departmentId) ? Ok("Department Removed Successfully") : Problem("Sorry internal error occured");
        }
        catch (ValidationException departmentNotFound)
        {
            _logger.LogInformation($"Location Service : RemoveLocation(int locationId) : {departmentNotFound.Message}");
            return BadRequest(departmentNotFound.Message);
        }
        catch (Exception exception)
        {
         _logger.LogInformation($"Department Controller : RemoveDepartment(int departmentId) : {exception.Message} : {exception.StackTrace}");
            return BadRequest(exception.Message);
        }
    }
    /// <summary>
    /// This Method Will Implement When ViewDepartments Request rises-The Department controller passes the control 
    /// to the Department Service.
    /// </summary>
    /// <returns>Return List of Departments  otherwise it returns  Exception when exception thrown in service.</returns>
    [HttpGet]
    public IActionResult ViewDepartments()
    {
        try
        {
            return Ok(departmentService.ViewDepartments());
        }
        catch (Exception exception)
        {
           _logger.LogInformation($"Department Controller : ViewDepartment() : {exception.Message} : {exception.StackTrace}");
            return BadRequest(exception.Message);
        }
    }

}
