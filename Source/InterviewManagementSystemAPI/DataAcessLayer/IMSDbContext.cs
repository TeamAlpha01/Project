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
            optionsBuilder.UseSqlServer(@"Server=ASPIREREN009;Database=InterviewManagementSystem;Trusted_Connection=True;");
        }

        //Seeding Data to DB 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                        .HasData(
                         new Role { RoleId = 1, RoleName = "Software Developer" },
                         new Role { RoleId = 2, RoleName = "Senior Software Developer" },
                         new Role { RoleId = 3, RoleName = "Project Manager" },
                         new Role { RoleId = 4, RoleName = "Module Lead" },
                         new Role { RoleId = 5, RoleName = "Technical Lead" },
                         new Role { RoleId = 6, RoleName = "Software Architect" },
                         new Role { RoleId = 7, RoleName = "Delivery Manager" },
                         new Role { RoleId = 8, RoleName = "Service Line Owner" },
                         new Role { RoleId = 9, RoleName = "Talent Acquisition Coordinatior" },
                         new Role { RoleId = 10, RoleName = "Admin" }
                         );
            modelBuilder.Entity<Department>()
                       .HasData(
                        new Department { DepartmentId = 1, DepartmentName = ".NET" },
                        new Department { DepartmentId = 2, DepartmentName = "JAVA" },
                        new Department { DepartmentId = 3, DepartmentName = "ORACLE" },
                        new Department { DepartmentId = 4, DepartmentName = "Not Applicable" }
                        );
            modelBuilder.Entity<Project>()
                      .HasData(
                       new Project { ProjectId = 1, ProjectName = "IMS_NET", DepartmentId = 1 },
                       new Project { ProjectId = 2, ProjectName = "IMS_JAVA", DepartmentId = 2 },
                       new Project { ProjectId = 3, ProjectName = "IMS_ORACLE", DepartmentId = 3 },
                       new Project { ProjectId = 4, ProjectName = "Not Applicable", DepartmentId = 4 }
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
                       new Employee { EmployeeId = 9, Name = "Remuki", DepartmentId = 3, EmailId = "remuki@gmail.com", EmployeeAceNumber = "ACE0009", Password = "Pass@12345", ProjectId = 3, RoleId = 3 },
                       new Employee { EmployeeId = 10, Name = "Vishnu", DepartmentId = 4, EmailId = "vishnu@gmail.com", EmployeeAceNumber = "ACE0010", Password = "Pass@12345", ProjectId = 4, RoleId = 9 },
                       new Employee { EmployeeId = 11, Name = "Sandhiya", DepartmentId = 4, EmailId = "sandhiya@gmail.com", EmployeeAceNumber = "ACE0011", Password = "Pass@12345", ProjectId = 4, RoleId = 9 },
                       new Employee { EmployeeId = 12, Name = "Mani", DepartmentId = 4, EmailId = "mani@gmail.com", EmployeeAceNumber = "ACE0012", Password = "Pass@12345", ProjectId = 4, RoleId = 10 }
                       );
            modelBuilder.Entity<Location>()
                     .HasData(
                      new Location { LocationId = 1, LocationName = "Chennai", IsActive = true },
                      new Location { LocationId = 2, LocationName = "Bangalore", IsActive = true },
                      new Location { LocationId = 3, LocationName = "Mumbai", IsActive = true },
                      new Location { LocationId = 4, LocationName = "Delhi", IsActive = true },
                      new Location { LocationId = 5, LocationName = "Noida", IsActive = true }
                      );
            modelBuilder.Entity<Pool>()
                    .HasData(
                      new Pool { PoolId=1,PoolName="Fresher .NET",DepartmentId=1,IsActive=true},
                      new Pool { PoolId=2,PoolName="SSE .NET",DepartmentId=1,IsActive=true},
                      new Pool { PoolId=3,PoolName="Fresher JAVA",DepartmentId=2,IsActive=true},
                      new Pool { PoolId=4,PoolName="SSE JAVA",DepartmentId=2,IsActive=true},
                      new Pool { PoolId=5,PoolName="Fresher ORACLE",DepartmentId=3,IsActive=true},                 
                      new Pool { PoolId=6,PoolName="SSE ORACLE",DepartmentId=3,IsActive=true}                 
                      );
            modelBuilder.Entity<PoolMembers>()
                    .HasData(
                      new PoolMembers { PoolMembersId=1,PoolId=1,EmployeeId=1,IsActive=true},
                      new PoolMembers { PoolMembersId=2,PoolId=1,EmployeeId=2,IsActive=true},
                      new PoolMembers { PoolMembersId=3,PoolId=2,EmployeeId=2,IsActive=true},
                      new PoolMembers { PoolMembersId=4,PoolId=2,EmployeeId=3,IsActive=true},

                      new PoolMembers { PoolMembersId=5,PoolId=3,EmployeeId=4,IsActive=true},
                      new PoolMembers { PoolMembersId=6,PoolId=3,EmployeeId=5,IsActive=true},
                      new PoolMembers { PoolMembersId=7,PoolId=4,EmployeeId=5,IsActive=true},
                      new PoolMembers { PoolMembersId=8,PoolId=4,EmployeeId=6,IsActive=true},

                      new PoolMembers { PoolMembersId=9,PoolId=5,EmployeeId=7,IsActive=true},
                      new PoolMembers { PoolMembersId=10,PoolId=5,EmployeeId=8,IsActive=true},
                      new PoolMembers { PoolMembersId=11,PoolId=6,EmployeeId=8,IsActive=true},
                      new PoolMembers { PoolMembersId=12,PoolId=6,EmployeeId=9,IsActive=true}
                      );
            
        }
    }
}

/*
    NOTE : Change the connection string while using your personal system and also update all migrations.
    
    For Aspire System : Server=ASPIREREN009;Database=InterviewManagementSystem;Trusted_Connection=True;

*/