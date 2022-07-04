using System.ComponentModel.DataAnnotations;
using IMS.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Controller; 
[Authorize]
[ApiController]
  [Route("[controller]/[action]")]
  public class ProjectController : ControllerBase
  {
    private readonly ILogger _logger;
    IDepartmentService _departmentService;
    public ProjectController(ILogger<ProjectController> logger,IDepartmentService departmentService)
    {
        _logger = logger;
        _departmentService = departmentService;//IMS.DataFactory.DepartmentDataFactory.GetDepartmentServiceObject(_logger);
    }
    /// <summary>
    /// This Method Will Implement When Create New Department Request rises.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /CreateNewProject
    ///     {
    ///        "Project Name": ".NET_IMS",
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response> 
    /// <param name="departmentId">int</param>
    /// <param name="projectName">String</param>
    /// <returns>Return project added successfully message when the project is added in the database  otherwise  return Sorry internal error occured message .it return  validation exeption or Exception when exception thrown in service.</returns>
 
    [HttpPost]
    public IActionResult CreateNewProject( int departmentId,string projectName)
    {
        if (departmentId <= 0 || projectName == null) 
            return BadRequest("Department Id cannot be null or negative and Pool Name cannot be null");

        try
        {
            return _departmentService.CreateProject(departmentId,projectName) ? Ok(UtilityService.Response("Project Added Successfully")) : Problem("Sorry internal error occured");
        }
        catch (ValidationException projectnameAlreadyExists)
        {
             _logger.LogInformation($"Project Controller : CreateProject(int departmentId,string projectName) : {projectnameAlreadyExists.Message} : {projectnameAlreadyExists.StackTrace}");
            return BadRequest(UtilityService.Response(projectnameAlreadyExists.Message));
        }
        catch (Exception exception)
        {
             _logger.LogInformation($"Project Controller : CreateProject(int departmentId,string projectName) : {exception.Message} : {exception.StackTrace}");
          return Problem("Sorry some internal error occured ");
        }
    }
    /// <summary>
    /// This Method Will Implement When Remove Project Request rises.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /RemoveProject
    ///     {
    ///        "Project ID": "1",
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response> 
        /// <param name="projectId">int</param>
/// <returns>Return Project Removed Successfully message when the project Isctive is set to 0 otherwise return Sorry internal error occured .It returns validation exeption or Exception when exception thrown in service.</returns>
    [HttpPatch]
    public IActionResult RemoveProject(int projectId)
    {
        if (projectId <= 0) return BadRequest("Project Id is Should not be zero or less than zero");

        try
        {
            return _departmentService.RemoveProject(projectId) ? Ok(UtilityService.Response("Project Removed Successfully")) : Problem("Sorry internal error occured");
        }
        catch(ValidationException projectNotFound)
        {
              _logger.LogInformation($"Project Controller : RemoveProject(int projectId) : {projectNotFound.Message} : {projectNotFound.StackTrace}");
            return BadRequest(projectNotFound.Message);

        }
        catch (Exception exception)
        {
             _logger.LogInformation($"Project Controller : RemoveProject(int projectId) : {exception.Message} : {exception.StackTrace}");
            return Problem("Sorry some internal error occured ");
        }
    }
    /// <summary>
    /// This Method Will Implement When View Projects Request rises.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     Get /ViewProjcts
    ///     {
    ///        "Department ID": "1",
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response> 
    /// <param name="departmentId">int</param>
    /// <returns>Return List of Projects  otherwise it returns  Exception when exception thrown in service .</returns>
    [AllowAnonymous]
    [HttpGet]
    public IActionResult ViewProjects()
    {
        
        try
        {
            return Ok(_departmentService.ViewProjects());
        }
        catch (Exception exception)
        {
            _logger.LogInformation($"Project Controller : ViewProjects() : {exception.Message} : {exception.StackTrace}");
            return Problem("Sorry some internal error occured ");
        }
    }
  }