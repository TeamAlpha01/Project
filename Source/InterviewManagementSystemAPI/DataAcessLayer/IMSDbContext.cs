using Microsoft.EntityFrameworkCore;
using InterviewManagementSystemAPI.Models;

namespace InterviewManagementSystemAPI.DataAccessLayer{
public class InterviewManagementSystemDbContext : DbContext
{
    public DbSet<Role> Roles {get; set;} 
    public DbSet<Employee> Employees {get; set;} 
    public DbSet<Drive> Drives {get; set;} 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
        optionsBuilder.UseSqlServer(@"Server=DESKTOP-0EL7H73;Database=InterviewManagementSystem;Trusted_Connection=True;");
    }
}
}

/*
    NOTE : Change the connection string while using your personal system and also update all migrations.
    
    For Aspire System : Server=ASPIREREN009;Database=InterviewManagementSystem;Trusted_Connection=True;

*/