using Microsoft.EntityFrameworkCore;
using InterviewManagementSystemAPI.Models;

namespace InterviewManagementSystemAPI.DataAccessLayer{
public class InterviewManagementSystemDbContext : DbContext
{
    public DbSet<Role> Roles {get; set;} 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
        optionsBuilder.UseSqlServer(@"Server=ASPIREREN009;Database=InterviewManagementSystem;Trusted_Connection=True;");
    }
}
}