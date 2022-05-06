using System.ComponentModel.DataAnnotations;
using IMS.Service;
using Microsoft.AspNetCore.Mvc;

namespace project.Controller;

  [ApiController]
  [Route("[controller]/[action]")]
  public class ProjectController : ControllerBase
  {
    private readonly ILogger _logger;
    public ProjectController(ILogger<ProjectController> logger)
    {
        _logger = logger;
    }
    
 IDepartmentService departmentService1 = IMS.DataFactory.DepartmentDataFactory.GetDepartmentServiceObject();
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
             _logger.LogInformation("Department Service : Department throwed an exception", exception);
            return BadRequest("project Name is invalid");
        }
        catch (Exception exception)
        {
            _logger.LogInformation("Pool Service : CreatePool throwed an exception", exception);
            return BadRequest("Sorry some internal error occured");
        }
    }
    [HttpPost]
    public IActionResult RemoveProject(int projectId)
    {
        if (projectId <= 0) return BadRequest("Project Id is not provided");

        try
        {
            return departmentService1.RemoveProject(projectId) ? Ok("Project Removed Successfully") : BadRequest("Sorry internal error occured");
        }
        catch (Exception exception)
        {
            _logger.LogInformation("Project Service : RemoveProject throwed an exception", exception);
            return BadRequest("Sorry some internal error occured");
        }
    }
      [HttpGet]
    public IActionResult ViewProjects(int departmentId)
    {
        try
        {
            return Ok(departmentService1.ViewProjects(departmentId));
        }
        catch (Exception exception)
        {
            _logger.LogInformation("Service throwed exception while fetching roles ", exception);
            return BadRequest("Sorry some internal error occured");
        }
    }
  }