using Microsoft.EntityFrameworkCore;
using IMS.Models;

namespace IMS.DataAccessLayer
{
    public class InterviewManagementSystemDbContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Drive> Drives { get; set; }
        public DbSet<EmployeeDriveResponse> EmployeeDriveResponse { get; set; }
        public DbSet<EmployeeAvailability> EmployeeAvailability { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Pool> Pools { get; set; }
        public DbSet<PoolMembers> PoolMembers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Project> Projects { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=ASPIREREN032;Database=InterviewManagementSystem;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                        .HasData(
                         new Role { RoleId = 1, RoleName = "Software Developer" },
                         new Role { RoleId = 2, RoleName = "Senior Software Developer" },
                         new Role { RoleId = 3, RoleName = "Project Manager" });
            modelBuilder.Entity<Department>()
                       .HasData(
                        new Department { DepartmentId = 1, DepartmentName = ".NET" },
                        new Department { DepartmentId = 2, DepartmentName = "JAVA" },
                        new Department { DepartmentId = 3, DepartmentName = "ORACLE" });
            modelBuilder.Entity<Project>()
                      .HasData(
                       new Project { ProjectId = 1, ProjectName = "IMS_NET", DepartmentId = 1 },
                       new Project { ProjectId = 2, ProjectName = "IMS_JAVA", DepartmentId = 2 },
                       new Project { ProjectId = 3, ProjectName = "IMS_ORACLE", DepartmentId = 3 }
                       );
            modelBuilder.Entity<Employee>()
                      .HasData(
                       new Employee { EmployeeId = 1, Name = "Prithvi", DepartmentId = 1, EmailId = "prithvi@gmail.com", EmployeeAceNumber = "ACE0001", Password = "Pass@12345", ProjectId = 1, RoleId = 1 },
                       new Employee { EmployeeId = 2, Name = "Vinoth", DepartmentId = 1, EmailId = "vinoth@gmail.com", EmployeeAceNumber = "ACE0002", Password = "Pass@12345", ProjectId = 1, RoleId = 2 },
                       new Employee { EmployeeId = 3, Name = "Sheik", DepartmentId = 1, EmailId = "Sheik@gmail.com", EmployeeAceNumber = "ACE0003", Password = "Pass@12345", ProjectId = 1, RoleId = 3 },
                       new Employee { EmployeeId = 4, Name = "Darshana", DepartmentId = 2, EmailId = "darshana@gmail.com", EmployeeAceNumber = "ACE0004", Password = "Pass@12345", ProjectId = 2, RoleId = 1 },
                       new Employee { EmployeeId = 5, Name = "Aravind", DepartmentId = 2, EmailId = "aravind@gmail.com", EmployeeAceNumber = "ACE0005", Password = "Pass@12345", ProjectId = 2, RoleId = 2 },
                       new Employee { EmployeeId = 6, Name = "Kumaresh", DepartmentId = 2, EmailId = "kumaresh@gmail.com", EmployeeAceNumber = "ACE0006", Password = "Pass@12345", ProjectId = 2, RoleId = 3 },
                       new Employee { EmployeeId = 7, Name = "Gokul", DepartmentId = 3, EmailId = "gokul@gmail.com", EmployeeAceNumber = "ACE0007", Password = "Pass@12345", ProjectId = 3, RoleId = 1 },
                       new Employee { EmployeeId = 8, Name = "Deepika", DepartmentId = 3, EmailId = "deepika@gmail.com", EmployeeAceNumber = "ACE0008", Password = "Pass@12345", ProjectId = 3, RoleId = 2 },
                       new Employee { EmployeeId = 9, Name = "Remuki", DepartmentId = 3, EmailId = "remuki@gmail.com", EmployeeAceNumber = "ACE0009", Password = "Pass@12345", ProjectId = 3, RoleId = 3 }
                       );
        }
    }
}

/*
    NOTE : Change the connection string while using your personal system and also update all migrations.
    
    For Aspire System : Server=ASPIREREN009;Database=InterviewManagementSystem;Trusted_Connection=True;

*/