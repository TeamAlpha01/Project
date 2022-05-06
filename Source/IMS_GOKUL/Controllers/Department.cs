using IMS.Service;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
namespace IMS.Controllers;

    
[ApiController]
[Route("[controller]/[action]")]
public class DeparmentController : ControllerBase
{
    private readonly ILogger _logger;
     IDepartmentService departmentService;

    public DeparmentController(ILogger<DeparmentController> logger)
    {
        _logger = logger;
         departmentService = DataFactory.DepartmentDataFactory.GetDepartmentServiceObject(_logger);
    }
    

    [HttpPost]
    public IActionResult CreateNewDeparment(string departmentName)
    {
        if (departmentName == null)
            return BadRequest("Department name is required");

        try
        {
            return departmentService.CreateDepartment(departmentName) ? Ok("Department Added Successfully") : BadRequest("Sorry internal error occured");
        }
         catch (ValidationException exception)
        {
             _logger.LogInformation($"Department Controller : CreateDepartment(string departmentName) : {exception.Message} : {exception.StackTrace}");
            return BadRequest("Department Name is invalid");
        }
        catch (Exception exception)
        {
            _logger.LogInformation($"Department Controller : CreateDepartment(string departmentName) : {exception.Message} : {exception.StackTrace}");
            return BadRequest("Sorry some internal error occured");
        }
       
    }

    [HttpPost]
    public IActionResult RemoveDepartment(int departmentId)
    {
        if (departmentId == 0) return BadRequest("Department Id is not provided");

        try
        {
            return departmentService.RemoveDepartment(departmentId) ? Ok("Department Removed Successfully") : BadRequest("Sorry internal error occured");
        }
        catch (Exception exception)
        {
         _logger.LogInformation($"Department Controller : RemoveDepartment(int departmentId) : {exception.Message} : {exception.StackTrace}");
            return BadRequest("Sorry some internal error occured");
        }
    }
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
            return BadRequest("Sorry some internal error occured");
        }
    }

}
