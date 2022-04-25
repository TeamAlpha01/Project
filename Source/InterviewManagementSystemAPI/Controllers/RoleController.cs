using Microsoft.AspNetCore.Mvc;
using InterviewManagementSystemAPI.Models;
using InterviewManagementSystemAPI.Service;
namespace InterviewManagementSystemAPI.Controllers;

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
    [HttpPost]
      public bool RemoveRole(int roleId)
      {
          if(roleId!=0)
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
