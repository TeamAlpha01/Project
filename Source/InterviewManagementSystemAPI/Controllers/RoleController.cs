using Microsoft.AspNetCore.Mvc;
using Source.Models;
using Source.Service;
namespace Source.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class RoleController : ControllerBase
{

    [HttpPost]
      public bool CreateNewRole(string roleName)
      {
          if(roleName!=null)
          {
            IRoleService roleService = DataFactory.RoleDataFactory.GetRoleServiceObject();
            return roleService.CreateRole(roleName);
          }
          else
          {
              return false;
          }
      }  
    [HttpDelete]
      public bool RemoveRole(int roleId)
      {
          if(roleId!=null)
          {
            IRoleService roleService = DataFactory.RoleDataFactory.GetRoleServiceObject();
            return roleService.RemoveRole(roleId);
          }
          else
          {
              return false;
          }
      }
    [HttpGet]
      public  List<Role> ViewRoles()
      {
          IRoleService roleService = DataFactory.RoleDataFactory.GetRoleServiceObject();
          return roleService.ViewRoles();
      }
       
}
