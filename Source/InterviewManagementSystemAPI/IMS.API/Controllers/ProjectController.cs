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
    /// This method is used to create new project
    /// </summary>
    /// <response code="200">If project is created successfully</response>
    /// <response code="400">If the item is null or validation exception occurs</response> 
    /// <response code="500">If there is problem in server</response>
    /// <param name="departmentId">int</param>
    /// <param name="projectName">String</param>
    /// <returns>Returns success message when project added or
    /// Returns bad request when validation exception occurs or
    /// Retuurns problem when internal problem occurs </returns>
 
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
             _logger.LogError($"Project Controller : CreateProject(int departmentId,string projectName) : {projectnameAlreadyExists.Message} : {projectnameAlreadyExists.StackTrace}");
            return BadRequest(UtilityService.Response(projectnameAlreadyExists.Message));
        }
        catch (Exception exception)
        {
             _logger.LogError($"Project Controller : CreateProject(int departmentId,string projectName) : {exception.Message} : {exception.StackTrace}");
          return Problem("Sorry some internal error occured ");
        }
    }
    /// <summary>
    /// This method is used to remove project
    /// </summary>
    /// <remarks>
    /// <response code="200">If project was removed successfully</response>
    /// <response code="400">If the item is null or validation exception oocurs</response> 
    /// <response code="500">If there is problem in server</response>
    /// <param name="projectId">int</param>
    /// <returns>Return success message if project removed or
    /// Returns bad request when validation exception occurs or
    /// Returns problem if some internal error occurs</returns>
    
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
              _logger.LogError($"Project Controller : RemoveProject(int projectId) : {projectNotFound.Message} : {projectNotFound.StackTrace}");
            return BadRequest(projectNotFound.Message);

        }
        catch (Exception exception)
        {
             _logger.LogError($"Project Controller : RemoveProject(int projectId) : {exception.Message} : {exception.StackTrace}");
            return Problem("Sorry some internal error occured ");
        }
    }
    /// <summary>
    /// This method is used to view list of projects
    /// </summary>
    /// <response code="200">Returns list of projects</response>
    /// <response code="400">If the item is null or validation exception occurs</response> 
    /// <returns>Return List of Projects or
    /// Returns problem if internal error occurs</returns>
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
            _logger.LogError($"Project Controller : ViewProjects() : {exception.Message} : {exception.StackTrace}");
            return Problem("Sorry some internal error occured ");
        }
    }
  }