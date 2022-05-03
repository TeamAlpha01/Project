using Microsoft.AspNetCore.Mvc;
using IMS.Models;
using IMS.Service;
using System.Net;

namespace IMS.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class RoleController : ControllerBase
{
    private readonly ILogger _logger;
    public RoleController(ILogger<RoleController> logger)
    {
        _logger = logger;
    }
    IRoleService roleService = DataFactory.RoleDataFactory.GetRoleServiceObject();

    [HttpPost]
    public IActionResult CreateNewRole(string roleName)
    {
        if (roleName == null) 
            return BadRequest("Role name is required");

        try
        {
            return roleService.CreateRole(roleName) ? Ok("Role Added Successfully") : BadRequest("Sorry internal error occured");
        }
        catch (Exception exception)
        {
            _logger.LogInformation("Role Service : CreateRole throwed an exception", exception);
            return BadRequest("Sorry some internal error occured");
        }
    }

    [HttpPost]
    public IActionResult RemoveRole(int roleId)
    {
        if (roleId == 0) return BadRequest("Role Id is not provided");

        try
        {
            return roleService.RemoveRole(roleId) ? Ok("Role Removed Successfully") : BadRequest("Sorry internal error occured");
        }
        catch (Exception exception)
        {
            _logger.LogInformation("Role Service : RemoveRole throwed an exception", exception);
            return BadRequest("Sorry some internal error occured");
        }
    }
    [HttpGet]
    public IActionResult ViewRoles()
    {
        try
        {
            return Ok(roleService.ViewRoles());
        }
        catch (Exception exception)
        {
            _logger.LogInformation("Service throwed exception while fetching roles ", exception);
            return BadRequest("Sorry some internal error occured");
        }
    }

}
