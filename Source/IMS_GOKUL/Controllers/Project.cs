using System.ComponentModel.DataAnnotations;
using IMS.Service;
using Microsoft.AspNetCore.Mvc;

namespace project.Controller;

[ApiController]
  [Route("[controller]/[action]")]
  public class ProjectController : ControllerBase
  {
    private readonly ILogger _logger;
    IDepartmentService departmentService1;
    public ProjectController(ILogger<ProjectController> logger)
    {
        _logger = logger;
         departmentService1 = IMS.DataFactory.DepartmentDataFactory.GetDepartmentServiceObject(_logger);
    }
    /// <summary>
    /// This Method Will Implement When Create New Department Request rises-The Project controller passes the the parameter 
    /// to the Department Service.
    /// </summary>
    /// <param name="departmentId">int</param>
    /// <param name="projectName">String</param>
    /// <returns>Return Ok or Badrequest otherwise it returns validation exeption or Exception when exception thrown in service.</returns>
 
    [HttpPost]
    public IActionResult CreateNewProject( int departmentId,string projectName)
    {
        if (departmentId <= 0 || projectName == null) 
            return BadRequest("Project name and Department  is required");

        try
        {
            return departmentService1.CreateProject(departmentId,projectName) ? Ok("Project Added Successfully") : BadRequest("Sorry internal error occured");
        }
        catch (ValidationException exception)
        {
             _logger.LogInformation($"Project Controller : CreateProject(int departmentId,string projectName) : {exception.Message} : {exception.StackTrace}");
            return BadRequest(exception.Message);
        }
        catch (Exception exception)
        {
             _logger.LogInformation($"Project Controller : CreateProject(int departmentId,string projectName) : {exception.Message} : {exception.StackTrace}");
            return BadRequest(exception.Message);
        }
    }
    /// <summary>
    /// This Method Will Implement When Remove Project Request rises-The Project controller passes the the parameter 
    /// to the Department Service.
    /// </summary>
    /// <param name="projectId">int</param>
    /// <returns>Return Ok or Badrequest otherwise it returns validation exeption or Exception when exception thrown in service.</returns>
    [HttpPost]
    public IActionResult RemoveProject(int projectId)
    {
        if (projectId <= 0) return BadRequest("Project Id is Should not be zero or less than zero");

        try
        {
            return departmentService1.RemoveProject(projectId) ? Ok("Project Removed Successfully") : BadRequest("Sorry internal error occured");
        }
        catch(ValidationException exception)
        {
              _logger.LogInformation($"Project Controller : RemoveProject(int projectId) : {exception.Message} : {exception.StackTrace}");
            return BadRequest(exception.Message);

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
    /// <returns>Return Ok  otherwise it returns  Exception when exception thrown in service .</returns>
      [HttpGet]
    public IActionResult ViewProjects(int departmentId)
    {
        if (departmentId <= 0) return BadRequest("Department Id  Should not be zero or less than zero");
        try
        {
            return Ok(departmentService1.ViewProjects(departmentId));
        }
        catch (Exception exception)
        {
            _logger.LogInformation($"Project Controller : ViewProjects() : {exception.Message} : {exception.StackTrace}");
            return BadRequest(exception.Message);
        }
    }
  }