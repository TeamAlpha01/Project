using System.ComponentModel.DataAnnotations;
using IMS.Service;
using Microsoft.AspNetCore.Mvc;

namespace project.Controller;

[ApiController]
  [Route("[controller]/[action]")]
  public class ProjectController : ControllerBase
  {
    private readonly ILogger _logger;
    IDepartmentService departmentService;
    public ProjectController(ILogger<ProjectController> logger)
    {
        _logger = logger;
         departmentService = IMS.DataFactory.DepartmentDataFactory.GetDepartmentServiceObject(_logger);
    }
    /// <summary>
    /// This Method Will Implement When Create New Department Request rises-The Project controller passes the the parameter 
    /// to the Department Service.
    /// </summary>
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
            return departmentService.CreateProject(departmentId,projectName) ? Ok("Project Added Successfully") : Problem("Sorry internal error occured");
        }
        catch (ValidationException projectnameAlreadyExists)
        {
             _logger.LogInformation($"Project Controller : CreateProject(int departmentId,string projectName) : {projectnameAlreadyExists.Message} : {projectnameAlreadyExists.StackTrace}");
            return BadRequest(projectnameAlreadyExists.Message);
        }
        catch (Exception exception)
        {
             _logger.LogInformation($"Project Controller : CreateProject(int departmentId,string projectName) : {exception.Message} : {exception.StackTrace}");
            return BadRequest("Sorry Internal Error occurred");
        }
    }
    /// <summary>
    /// This Method Will Implement When Remove Project Request rises-The Project controller passes the the parameter 
    /// to the Department Service.
    /// </summary>
    /// <param name="projectId">int</param>
    /// <returns>Return Project Removed Successfully message when the project Isctive is set to 0 otherwise return Sorry internal error occured .It returns validation exeption or Exception when exception thrown in service.</returns>
    [HttpPost]
    public IActionResult RemoveProject(int projectId)
    {
        if (projectId <= 0) return BadRequest("Project Id is Should not be zero or less than zero");

        try
        {
            return departmentService.RemoveProject(projectId) ? Ok("Project Removed Successfully") : Problem("Sorry internal error occured");
        }
        catch(ValidationException projectNotFound)
        {
              _logger.LogInformation($"Project Controller : RemoveProject(int projectId) : {projectNotFound.Message} : {projectNotFound.StackTrace}");
            return BadRequest(projectNotFound.Message);

        }
        catch (Exception exception)
        {
             _logger.LogInformation($"Project Controller : RemoveProject(int projectId) : {exception.Message} : {exception.StackTrace}");
            return BadRequest(exception.Message);
        }
    }
    /// <summary>
    /// This Method Will Implement When View Projects Request rises-The Project controller passes the the parameter 
    /// to the Department Service.It validate the department Id .
    /// </summary>
    /// <param name="departmentId">int</param>
    /// <returns>Return List of Projects  otherwise it returns  Exception when exception thrown in service .</returns>
      [HttpGet]
    public IActionResult ViewProjects()
    {
        
        try
        {
            return Ok(departmentService.ViewProjects());
        }
        catch (Exception exception)
        {
            _logger.LogInformation($"Project Controller : ViewProjects() : {exception.Message} : {exception.StackTrace}");
            return BadRequest(exception.Message);
        }
    }
  }