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
    ///  This method is used to create new department
    /// </summary>
    /// <response code="200">If new department was created</response>
    /// <response code="400">If the item is null</response> 
    /// <response code="500">If some internal problem arises </response>
    /// <param name="departmentName">String</param>
    /// <returns>Returns success message when department is added or
    /// Returns Bad request when validation exception occurs or
    /// Returns Problem when internal error occurs </returns>
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
            _logger.LogError("Department Controller : CreateDepartment(string departmentName):{0}:,{1}" , departmentnotvalid.Message ,departmentnotvalid.StackTrace);
            return BadRequest(UtilityService.Response(departmentnotvalid.Message));
        }
        catch (Exception exception)
        {
            _logger.LogError($"Department Controller : CreateDepartment(string departmentName) : {exception.Message} : {exception.StackTrace}");
            return Problem("Sorry some internal error occured");
        }
    }
    /// <summary>
    /// This method is used to remove department,when request rises from admin
    /// </summary>
    /// <response code="200">If department removed successfully</response>
    /// <response code="400">If the item is null</response> 
    /// <response code="500">If there is problem in server</response>
    /// <param name="departmentId">int</param>
    /// <returns>Returns success message when department removed or
    /// Returns bad request when validation exception occurs or
    /// Returns problem when internal problem occurs</returns>
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
    /// This method is used to view list of departments,when request rises from admin
    /// </summary>
    /// <response code="200">Returns list of department</response>
    /// <response code="500">If there is problem in server </response> 
    /// <returns>Returns list of department or
    /// Returns problem when internal problem occurs</returns>
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
