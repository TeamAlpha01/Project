using Microsoft.AspNetCore.Mvc;
using IMS.Models;
using IMS.Service;
using System.Net;
using System.ComponentModel.DataAnnotations;

namespace IMS.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class RoleController : ControllerBase
{
    private readonly ILogger _logger;
    private IRoleService roleService;
    public RoleController(ILogger<RoleController> logger)
    {
        _logger = logger;
        roleService = DataFactory.RoleDataFactory.GetRoleServiceObject(_logger);
    }

    /// <summary>
    /// This method will be implemented when "Add a new Role" - Request rises. This method Check the null Validation and
    /// then Control shifts to Role Service
    /// </summary>
    /// <param name="roleName">String</param>
    /// <returns>Returns Error Message when Exception occured in Role Service. Succsess Message or Internal Error</returns>
    [HttpPost]
    public IActionResult CreateNewRole(string roleName)
    {
        if(roleName==null)
            BadRequest("Role Name cannot be null");
        try
        {
            return roleService.CreateRole(roleName) ? Ok("Role Added Successfully") : Problem("Sorry internal error occured");
        }
        catch (ValidationException roleNameException)
        {
            _logger.LogInformation($"Role Service : CreateNewRole() : {roleNameException.Message}");
            return BadRequest(roleNameException.Message);
        }
        catch (Exception exception)
        {
            _logger.LogInformation($"Role Service : CreateRole throwed an exception : {exception}");
            return Problem("Sorry some internal error occured");
        }
    }

    /// <summary>
    ///  This method will be implemented when "Remove a new Role" - Request rises. This method Check the null Validation and
    /// then Control shifts to Role Service
    /// </summary>
    /// <param name="roleId">int</param>
    /// <returns>>Returns Error Message when Exception occured in Role Service. Succsess Message or Internal Error</returns>
    /// 
    [HttpPost]
    public IActionResult RemoveRole(int roleId)
    {
        if (roleId == 0) return BadRequest("Role Id is not provided");

        try
        {
            return roleService.RemoveRole(roleId) ? Ok("Role Removed Successfully") : BadRequest("Sorry internal error occured");
        }
        catch (ValidationException roleNotFound)
        {
            _logger.LogInformation($"Role Service : RemoveRole() : {roleNotFound.Message}");
            return BadRequest(roleNotFound.Message);
        }
        catch (Exception exception)
        {
            _logger.LogInformation($"Role Service : RemoveRole throwed an exception : {exception}");
            return BadRequest("Sorry some internal error occured");
        }
    }

    /// <summary>
    /// This method will be implemented when "View Roles" - Request rises.
    /// The Control shifts to Role Service
    /// </summary>
    /// <returns>Returns Error Message when Exception occured in Role Service. Succsess Message or Internal Error</returns>
    [HttpGet]
    public IActionResult ViewRoles()
    {
        try
        {
            return Ok(roleService.ViewRoles());
        }
        catch (Exception exception)
        {
            _logger.LogInformation($"Service throwed exception while fetching roles : {exception}");
            return BadRequest("Sorry some internal error occured");
        }
    }

}
