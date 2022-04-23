using Microsoft.EntityFrameworkCore;
using Source.Models;

public class IMSDbContext : DbContext
{
    public DbSet<Role>? Roles {get; set;} 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { 
        optionsBuilder.UseSqlServer(@"Server=ASPIREREN042;Database=InterviewManagementSystem;Trusted_Connection=True;");
    }
}