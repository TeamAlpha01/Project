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
    ///  This Method Will Implement When Create New Department Request rises from the Admin.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /CreateNewDepartment
    ///     {
    ///        "Department Name": ".net",
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response> 
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
    /// This Method Will Implement When Remove Department Request rises from the Admin
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /RemoveDepartment
    ///     {
    ///        "Department ID": "1",
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response> 
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
    /// This Method Will Implement When ViewDepartments Request rises from the Admin
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///     GET /View Department
    ///     {
    ///     
    ///     }
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response> 
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
