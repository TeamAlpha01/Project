using Source.Models;


namespace Source.DataAccessLayer{
public class RoleDataAccessLayer : IRoleDataAccessLayer
{
        public bool AddRoleToDatabase(Role role)
        {
            if(role!=null)
            {
                var db = DataFactory.DbContextDataFactory.GetInterviewManagementSystemDbContextObject();
                db.Roles.Add(role);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool RemoveRoleFromDatabase(int roleId)
        {
            if(roleId!=null)
            { 
                var db = DataFactory.DbContextDataFactory.GetInterviewManagementSystemDbContextObject();
                db.Roles.Remove(db.Roles.Find(roleId));
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<Role> GetRolesFromDatabase()
        {
            var db = DataFactory.DbContextDataFactory.GetInterviewManagementSystemDbContextObject();
            return db.Roles.ToList();                   //Cast<IRole>().ToList();
        }

    }
}