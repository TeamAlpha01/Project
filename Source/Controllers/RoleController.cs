using Microsoft.AspNetCore.Mvc;
using Source.Models;
namespace Source.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class RoleController : ControllerBase
{

    [HttpPost]
      public bool CreateNewRole(string? roleName)
      {
          if(roleName!=null)
          {
            Service.RoleService roleService = new Service.RoleService();
            return roleService.CreateRole(roleName);
          }
          else
          {
              return false;
          }
      }  
    [HttpDelete]
      public bool RemoveRole(int? roleId)
      {
          if(roleId!=null)
          {
            Service.RoleService roleService = new Service.RoleService();
            return roleService.RemoveRole(roleId);
          }
          else
          {
              return false;
          }
      }
    [HttpGet]
      public  List<IRole> ViewRoles()
      {
          Service.RoleService roleService = new Service.RoleService();
          return roleService.ViewRoles();
      }
       
}
