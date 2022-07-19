using Microsoft.AspNetCore.Mvc;
using IMS.Models;
using IMS.Service;
using System.Net;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

namespace IMS.Controllers;

[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class RoleController : ControllerBase
{
    private readonly ILogger _logger;
    private IRoleService _roleService;
    public RoleController(ILogger<RoleController> logger,IRoleService roleService)
    {
        _logger = logger;
        _roleService = roleService;
    }

    /// <summary>
    /// This method used to create new role
    /// </summary>
    /// <response code="200">If new role is created</response>
    /// <response code="400">If the item is null or validation exception occurs</response> 
    /// <response code="500">If there is problem in server</response>
    /// <param name="role">String</param>
   
    /// <returns>Returns Error Message when Exception occured in Role Service. Succsess Message or Internal Error</returns>
    
    [HttpPost]
    public IActionResult CreateNewRole(Role role)
    {
        if(String.IsNullOrEmpty(role.RoleName))
            return BadRequest("Role Name cannot be null");
        try
        {
            role.AddedBy= Convert.ToInt32(User.FindFirst("UserId")?.Value);
            role.AddedOn=DateTime.Now;
            return _roleService.CreateRole(role) ? Ok(UtilityService.Response("Role Added Successfully")) : Problem("Sorry internal error occured");
        }
        catch (ValidationException roleNameException)
        {
            _logger.LogError($"Role Service : CreateNewRole() : {roleNameException.Message}");
            return BadRequest(UtilityService.Response(roleNameException.Message));
        }
        catch (Exception exception)
        {
            _logger.LogError($"Role Service : CreateRole throwed an exception : {exception}");
            return Problem("Sorry some internal error occured");
        }
    }

    /// <summary>
    ///  This method is used to remove a role
    /// </summary>
    /// <response code="200">If role was created</response>
    /// <response code="400">If the item is null or validtaion exception occurs</response> 
    /// <param name="role">int</param>
    /// <returns>Returns success message  when role was created or 
    /// Returns bad request when validation exception occurs or
    /// Returns problem if internal error occurs</returns>
  
   [HttpPatch]
    public IActionResult RemoveRole(Role role)
    {
        if (role.RoleId == 0) return BadRequest("Role Id is not provided");

        try
        {
            role.UpdatedBy= Convert.ToInt32(User.FindFirst("UserId")?.Value);
            role.UpdatedOn=DateTime.Now;
            return _roleService.RemoveRole(role) ? Ok(UtilityService.Response("Role Removed Successfully")) : BadRequest("Sorry internal error occured");
        }
        catch (ValidationException roleNotFound)
        {
            _logger.LogError($"Role Service : RemoveRole() : {roleNotFound.Message}");
            return BadRequest(roleNotFound.Message);
        }
        catch (Exception exception)
        {
            _logger.LogError($"Role Service : RemoveRole throwed an exception : {exception.Message}");
            return Problem("Sorry some internal error occured ");
        }
    }

    /// <summary>
    /// This method is used to view list of roles
    /// </summary>
    /// <response code="200">If it returns list of roles</response>
    /// <response code="500">If there is problem in server</response> 
    /// <returns>Returns list of role or 
    /// Returns problem if some internal error occurs</returns>
    [AllowAnonymous]
    [HttpGet]
    public IActionResult ViewRoles()
    {
        try
        {
            return Ok(_roleService.ViewRoles());
        }
        catch (Exception exception)
        {
            _logger.LogError($"Service throwed exception while fetching roles : {exception}");
            return Problem("Sorry some internal error occured");
        }
    }

}
