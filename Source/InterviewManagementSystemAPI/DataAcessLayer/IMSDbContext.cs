using Microsoft.EntityFrameworkCore;
using IMS.Models;

namespace IMS.DataAccessLayer
{
    public class InterviewManagementSystemDbContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Drive> Drives { get; set; }
        public DbSet<EmployeeDriveResponse> EmployeeDriveResponse{ get; set; }
        public DbSet<EmployeeAvailability> EmployeeAvailability{ get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=ASPIREREN009;Database=InterviewManagementSystem;Trusted_Connection=True;");
        }
    }
}

/*
    NOTE : Change the connection string while using your personal system and also update all migrations.
    
    For Aspire System : Server=ASPIREREN009;Database=InterviewManagementSystem;Trusted_Connection=True;

*/