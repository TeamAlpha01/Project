using Microsoft.AspNetCore.Mvc;
using InterviewManagementSystemAPI.Models;
using InterviewManagementSystemAPI.Service;
using System.Net;

namespace InterviewManagementSystemAPI.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class RoleController : ControllerBase
{

    private readonly ILogger _logger;
    public RoleController(ILogger<RoleController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public IActionResult CreateNewRole(string roleName)
    {
        try
        {
            if (roleName != null)
            {
                IRoleService roleService = DataFactory.RoleDataFactory.GetRoleServiceObject();
                if (roleService.CreateRole(roleName))
                    return Ok("Role Added Successfully");
                else
                    return BadRequest("Sorry internal error occured");
            }
            else
            {
                _logger.LogInformation("Role name was null");
                return BadRequest("Role name is required");
            }
        }
        catch (ArgumentNullException argumentNullException)
        {
            _logger.LogInformation("Service throwed ArgumentException", argumentNullException);
            return BadRequest("Sorry some internal error occured");
        }
        catch (Exception exception)
        {
            _logger.LogInformation("Service throwed exception",exception);
            return BadRequest("Sorry some internal error occured");
        }
    }

    [HttpPost]
    public IActionResult RemoveRole(int roleId)
    {
        try
        {
            if (roleId != 0)
            {
                IRoleService roleService = DataFactory.RoleDataFactory.GetRoleServiceObject();
                if (roleService.RemoveRole(roleId))
                    return Ok("Role Removed Successfully");
                else
                    return BadRequest("Sorry internal error occured");
            }
            else
            {
                return BadRequest("Role Id is required");
            }
        }
        catch (ArgumentException argumentNullException)
        {
            _logger.LogInformation("Service throwed ArgumentException", argumentNullException);
            return BadRequest("Sorry some internal error occured");
        }
        catch (Exception exception)
        {
            _logger.LogInformation("Service throwed exception",exception);
            return BadRequest("Sorry some internal error occured");
        }
    }
    [HttpGet]
    public IActionResult ViewRoles()
    {
        try
        {
            IRoleService roleService = DataFactory.RoleDataFactory.GetRoleServiceObject();
            return Ok(roleService.ViewRoles());
        }
        catch (Exception exception)
        {
            _logger.LogInformation("Service throwed exception while fetching roles ",exception);
            return BadRequest("Sorry some internal error occured");
        }
    }

}
