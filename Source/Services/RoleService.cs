using Source.Models;
using System.Linq;
namespace Source.Service{
    public class RoleService 
    {
        public bool CreateRole(string? roleName)
        {
            if(roleName!=null)
            {
                Role role = new Role();
                role.RoleName=roleName;
                IMSDbContext db = new IMSDbContext();
                db.Roles.Add(role);
                db.SaveChanges();
                return true;
            }
            else{
                return false;
            }
        }

        public bool RemoveRole(int? roleId)
        {
            if(roleId!=null)
            {
                IMSDbContext db = new IMSDbContext();
                db.Roles.Remove(db.Roles.Find(roleId));
                db.SaveChanges();
                return true;
            }
            else{
                return false;
            }
        }

        public List<IRole> ViewRoles()
        {
            IMSDbContext db = new IMSDbContext();
            List<IRole> roles = new List<IRole>();    
            roles = db.Roles.ToList().Cast<IRole>().ToList();    
            return roles;
        }
        
    }
}