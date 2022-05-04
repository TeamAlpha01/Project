using Microsoft.EntityFrameworkCore;
using IMS.Models;

namespace IMS.DataAccessLayer{
public class LocationContext : DbContext
{
    public DbSet<Location> Locations {get; set;} 
    public DbSet<Department> Departments {get; set;} 
    public DbSet<Pool> Pools {get; set;} 
    public DbSet<PoolMembers> PoolMembers {get; set;} 
    public DbSet<Employee> Employees {get; set;} 


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
        optionsBuilder.UseSqlServer(@"Server=ASPIREREN025;Database=InterviewManagementSystem;Trusted_Connection=True;");
    }
}
}


