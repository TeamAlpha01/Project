using IMS.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
namespace IMS.Controllers;

[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class DepartmentController : ControllerBase
{
    private readonly ILogger _logger;
     private IDepartmentService _departmentService;

    public DepartmentController(ILogger<DepartmentController> logger,IDepartmentService departmentService)
    {
        _logger = logger;
        _departmentService = departmentService; 
    }
    
    /// <summary>
    ///  This Method Will Implement When Create New Department Request rises from the Admin.
    /// </summary>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response> 
    /// <response code="500">If some internal problem arises </response>
    /// <param name="departmentName">String</param>
    /// <returns>Return Department Added Successfully when the department is added in the database otherwise return Sorry internal error occured.It returns validation exception or Exception when exception thrown in service .</returns>
    [HttpPost]
    public IActionResult CreateNewDepartment(string departmentName)
    {
        if (departmentName == null)
            return BadRequest("Department name is required");
        try
        {
            return _departmentService.CreateDepartment(departmentName) ? Ok(UtilityService.Response("Department Added Successfully")) : Problem("Sorry internal error occured");
        }
         catch (ValidationException departmentnotvalid)
        {
            _logger.LogError($"Department Controller : CreateDepartment(string departmentName) : {departmentnotvalid.Message} : {departmentnotvalid.StackTrace}");
            return BadRequest(UtilityService.Response(departmentnotvalid.Message));
        }
        catch (Exception exception)
        {
            _logger.LogError($"Department Controller : CreateDepartment(string departmentName) : {exception.Message} : {exception.StackTrace}");
            return Problem("Sorry some internal error occured");
        }
    }
    /// <summary>
    /// This Method Will Implement When Remove Department Request rises from the Admin
    /// </summary>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response> 
    /// <response code="500">If some internal error thrown from service layer</response>
    /// <param name="departmentId">int</param>
    /// <returns>Return Department Removed Successfully message when project Isctive is set to 0 otherwise return Sorry internal error occured .It returns validation exeption or Exception when exception thrown in service.</returns>
    [HttpPatch]
    public IActionResult RemoveDepartment(int departmentId)
    {
        if (departmentId <= 0) return BadRequest("Department Id  Should not be zero or less than zero");

        try
        {
            return _departmentService.RemoveDepartment(departmentId) ? Ok(UtilityService.Response("Department Removed Successfully")) : Problem("Sorry internal error occured");
        }
        catch (ValidationException departmentExist)
        {
            _logger.LogError($"Department Controller : RemoveDepartment(int departmentId) : {departmentExist.Message}");
            return BadRequest(departmentExist.Message);
        }
        catch (Exception exception)
        {
         _logger.LogError($"Department Controller : RemoveDepartment(int departmentId) : {exception.Message} : {exception.StackTrace}");
           return Problem("Sorry some internal error occured");
        }
    }
    /// <summary>
    /// This Method Will Implement When ViewDepartments Request rises from the Admin
    /// </summary>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response> 
    /// <returns>Return List of Departments  otherwise it returns  Exception when exception thrown in service.</returns>
    [AllowAnonymous]
    [HttpGet]
    public IActionResult ViewDepartments()
    {
        try
        {
            return Ok(_departmentService.ViewDepartments());
        }
        catch (Exception exception)
        {
           _logger.LogError($"Department Controller : ViewDepartment() : {exception.Message} : {exception.StackTrace}");
            return Problem("Sorry some internal error occured");
        }
    }

}
