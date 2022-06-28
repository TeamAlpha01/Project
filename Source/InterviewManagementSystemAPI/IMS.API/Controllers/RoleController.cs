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
    private IRoleService _roleService;
    public RoleController(ILogger<RoleController> logger,IRoleService roleService)
    {
        _logger = logger;
        _roleService = roleService;//DataFactory.RoleDataFactory.GetRoleServiceObject(_logger);
    }

    /// <summary>
    /// This method will be implemented when "Add a new Role" - Request rises.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /CreateNewRole
    ///     {
    ///        "Role Name": "SSE",
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response> 
    /// <param name="roleName">String</param>
    /// <returns>Returns Error Message when Exception occured in Role Service. Succsess Message or Internal Error</returns>
    [HttpPost]
    public IActionResult CreateNewRole(string roleName)
    {
        if(String.IsNullOrEmpty(roleName))
            return BadRequest("Role Name cannot be null");
        try
        {
            return _roleService.CreateRole(roleName) ? Ok(UitilityService.Response("Role Added Successfully")) : Problem("Sorry internal error occured");
        }
        catch (ValidationException roleNameException)
        {
            _logger.LogInformation($"Role Service : CreateNewRole() : {roleNameException.Message}");
            return BadRequest(UitilityService.Response(roleNameException.Message));
        }
        catch (Exception exception)
        {
            _logger.LogInformation($"Role Service : CreateRole throwed an exception : {exception}");
            return Problem("Sorry some internal error occured");
        }
    }

    /// <summary>
    ///  This method will be implemented when "Remove a new Role" - Request rises.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /Remove Role
    ///     {
    ///        "Role ID": "1",
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response> 
    /// <param name="roleId">int</param>
    /// <returns>>Returns Error Message when Exception occured in Role Service. Succsess Message or Internal Error</returns>
    /// 
    [HttpPatch]
    public IActionResult RemoveRole(int roleId)
    {
        if (roleId == 0) return BadRequest("Role Id is not provided");

        try
        {
            return _roleService.RemoveRole(roleId) ? Ok(UitilityService.Response("Role Removed Successfully")) : BadRequest("Sorry internal error occured");
        }
        catch (ValidationException roleNotFound)
        {
            _logger.LogInformation($"Role Service : RemoveRole() : {roleNotFound.Message}");
            return BadRequest(roleNotFound.Message);
        }
        catch (Exception exception)
        {
            _logger.LogInformation($"Role Service : RemoveRole throwed an exception : {exception.Message}");
            return Problem("Sorry some internal error occured ");
        }
    }

    /// <summary>
    /// This method will be implemented when "View Roles" - Request rises.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /ViewRoles
    ///     {
    ///       
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response> 
    /// <returns>Returns Error Message when Exception occured in Role Service. Succsess Message or Internal Error</returns>
    [HttpGet]
    public IActionResult ViewRoles()
    {
        try
        {
            return Ok(_roleService.ViewRoles());
        }
        catch (Exception exception)
        {
            _logger.LogInformation($"Service throwed exception while fetching roles : {exception}");
            return Problem("Sorry some internal error occured");
        }
    }

}
