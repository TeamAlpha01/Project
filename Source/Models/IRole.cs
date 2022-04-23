namespace Source.Models
{
    public interface IRole{
        public int RoleId{get; set;}
        public string RoleName  { get; set; }
        public bool IsActive { get; set; }

        // public bool CreateRole(string roleName);        
        // public bool RemoveRole(int roleId);        
        // public List<IRole> ViewRoles();        
    } 
}