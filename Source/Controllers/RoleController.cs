using Microsoft.AspNetCore.Mvc;
using Source.Models;
namespace Source.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class RoleController : ControllerBase
{
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
      public  List<IRole> ViewRoles()
      {
          Service.RoleService roleService = new Service.RoleService();
          return roleService.ViewRoles();
      }
       
}
