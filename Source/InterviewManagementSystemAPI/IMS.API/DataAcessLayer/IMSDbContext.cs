using Microsoft.EntityFrameworkCore;
using IMS.Models;

namespace IMS.DataAccessLayer
{
    public class InterviewManagementSystemDbContext : DbContext
    {
        // public InterviewManagementSystemDbContext()
        // {
        // }

        public InterviewManagementSystemDbContext(DbContextOptions<InterviewManagementSystemDbContext> options) : base(options)
        {
            
        }

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
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseSqlServer(@"Server=DESKTOP-0EL7H73;Database=InterviewManagementSystem;Trusted_Connection=True;");
        //     //DESKTOP-8MEB0VH
        // }

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
                         new Role { RoleId = 9, RoleName = "TAC" },
                         new Role { RoleId = 10, RoleName = "Admin" }
                         );
            modelBuilder.Entity<Department>()
                       .HasData(
                        new Department { DepartmentId = 1, DepartmentName = ".NET" },
                        new Department { DepartmentId = 2, DepartmentName = "JAVA" },
                        new Department { DepartmentId = 3, DepartmentName = "ORACLE" },
                        new Department { DepartmentId = 4, DepartmentName = "LAMP" },
                        new Department { DepartmentId = 5, DepartmentName = "BFS" },
                        new Department { DepartmentId = 6, DepartmentName = "TAC" },
                        new Department { DepartmentId = 7, DepartmentName = "ADMIN" }
                        );
            modelBuilder.Entity<Project>()
                      .HasData(

                       new Project { ProjectId = 1, ProjectName = "Interview_Management_NET", DepartmentId = 1 },
                       new Project { ProjectId = 2, ProjectName = "Employee_Management_NET", DepartmentId = 1 },
                       new Project { ProjectId = 3, ProjectName = "Profile_Management_NET", DepartmentId = 1 },
                       new Project { ProjectId = 4, ProjectName = "Banking_NET", DepartmentId = 1 },

                       new Project { ProjectId = 5, ProjectName = "Interview_Management_JAVA", DepartmentId = 2 },
                       new Project { ProjectId = 6, ProjectName = "Employee_Management_JAVA", DepartmentId = 2 },
                       new Project { ProjectId = 7, ProjectName = "Profile_Management_JAVA", DepartmentId = 2 },
                       new Project { ProjectId = 8, ProjectName = "Banking_JAVA", DepartmentId = 2 },

                       new Project { ProjectId = 9, ProjectName = "Interview_Management_ORACLE", DepartmentId = 3 },
                       new Project { ProjectId = 10, ProjectName = "Employee_Management_ORACLE", DepartmentId = 3 },
                       new Project { ProjectId = 11, ProjectName = "Profile_Management_ORACLE", DepartmentId = 3 },
                       new Project { ProjectId = 12, ProjectName = "Banking_ORACLE", DepartmentId = 3 },

                       new Project { ProjectId = 13, ProjectName = "Interview_Management_LAMP", DepartmentId = 4 },
                       new Project { ProjectId = 14, ProjectName = "Employee_Management_LAMP", DepartmentId = 4 },
                       new Project { ProjectId = 15, ProjectName = "Profile_Management_LAMP", DepartmentId = 4},
                       new Project { ProjectId = 16, ProjectName = "Banking_LAMP", DepartmentId = 4 },

                       new Project { ProjectId = 17, ProjectName = "Interview_Management_BFS", DepartmentId = 5 },
                       new Project { ProjectId = 18, ProjectName = "Employee_Management_BFS", DepartmentId = 5 },
                       new Project { ProjectId = 19, ProjectName = "Profile_Management_BFS", DepartmentId = 5 },
                       new Project { ProjectId = 20, ProjectName = "Banking_BFS", DepartmentId = 5 },
                       new Project { ProjectId = 21, ProjectName = "Not Applicable", DepartmentId = 6 }
                       );
                       
            modelBuilder.Entity<Employee>()
                      .HasData(
                       new Employee { EmployeeId = 1, Name = "Prithvi", DepartmentId = 1, EmailId = "prithvi.palani@aspiresys.com", EmployeeAceNumber = "ACE0001", Password = "Pass@12345", ProjectId = 1, RoleId = 1 },
                       new Employee { EmployeeId = 2, Name = "Vinoth", DepartmentId = 1, EmailId = "vinoth.jayakumar@aspiresys.com", EmployeeAceNumber = "ACE0002", Password = "Pass@12345", ProjectId = 1, RoleId = 2 },
                       new Employee { EmployeeId = 3, Name = "Sheik", DepartmentId = 1, EmailId = "sheik.farid@aspiresys.com", EmployeeAceNumber = "ACE0003", Password = "Pass@12345", ProjectId = 1, RoleId = 3 },
                       new Employee { EmployeeId = 4, Name = "Darshana", DepartmentId = 2, EmailId = "darshana@aspiresys.com", EmployeeAceNumber = "ACE0004", Password = "Pass@12345", ProjectId = 2, RoleId = 1 },
                       new Employee { EmployeeId = 5, Name = "Aravind", DepartmentId = 2, EmailId = "aravind@aspiresys.com", EmployeeAceNumber = "ACE0005", Password = "Pass@12345", ProjectId = 2, RoleId = 2 },
                       new Employee { EmployeeId = 6, Name = "Kumaresh", DepartmentId = 2, EmailId = "kumaresh@aspiresys.com", EmployeeAceNumber = "ACE0006", Password = "Pass@12345", ProjectId = 2, RoleId = 3 },
                       new Employee { EmployeeId = 7, Name = "Gokul", DepartmentId = 3, EmailId = "gokul@aspiresys.com", EmployeeAceNumber = "ACE0007", Password = "Pass@12345", ProjectId = 3, RoleId = 1 },
                       new Employee { EmployeeId = 8, Name = "Deepika", DepartmentId = 3, EmailId = "deepika@aspiresys.com", EmployeeAceNumber = "ACE0008", Password = "Pass@12345", ProjectId = 3, RoleId = 2 },
                       new Employee { EmployeeId = 9, Name = "Remuki", DepartmentId = 3, EmailId = "remuki@aspiresys.com", EmployeeAceNumber = "ACE0009", Password = "Pass@12345", ProjectId = 3, RoleId = 3 },
                       new Employee { EmployeeId = 10, Name = "Vishnu", DepartmentId = 6, EmailId = "vishnu@aspiresys.com", EmployeeAceNumber = "ACE0010", Password = "Pass@12345", ProjectId = 4, RoleId = 9 },
                       new Employee { EmployeeId = 11, Name = "Sandhiya", DepartmentId = 6, EmailId = "sandhiya@aspiresys.com", EmployeeAceNumber = "ACE0011", Password = "Pass@12345", ProjectId = 4, RoleId = 9 },
                       new Employee { EmployeeId = 12, Name = "Mani", DepartmentId = 7, EmailId = "mani@aspiresys.com", EmployeeAceNumber = "ACE0012", Password = "Pass@12345", ProjectId = 4, RoleId = 10 }
                       );
            modelBuilder.Entity<Location>()
                     .HasData(
                      new Location { LocationId = 1, LocationName = "Chennai", IsActive = true },
                      new Location { LocationId = 2, LocationName = "Bangalore", IsActive = true },
                      new Location { LocationId = 3, LocationName = "Mumbai", IsActive = true },
                      new Location { LocationId = 4, LocationName = "Delhi", IsActive = true },
                      new Location { LocationId = 5, LocationName = "Noida", IsActive = true },
                      new Location { LocationId = 6, LocationName = "Hyderabad", IsActive = true },
                      new Location { LocationId = 7, LocationName = "Kochin", IsActive = true },
                      new Location { LocationId = 8, LocationName = "Coimbatore", IsActive = true },
                      new Location { LocationId = 9, LocationName = "Not Applicable", IsActive = true }
                      );
            modelBuilder.Entity<Pool>()
                    .HasData(
                      new Pool { PoolId = 1, PoolName = "Fresher .NET", DepartmentId = 1, IsActive = true },
                      new Pool { PoolId = 2, PoolName = "SSE .NET", DepartmentId = 1, IsActive = true },
                      new Pool { PoolId = 3, PoolName = "SLO .NET", DepartmentId = 1, IsActive = true },

                      new Pool { PoolId = 4, PoolName = "Fresher JAVA", DepartmentId = 2, IsActive = true },
                      new Pool { PoolId = 5, PoolName = "SSE JAVA", DepartmentId = 2, IsActive = true },
                      new Pool { PoolId = 6, PoolName = "SLO JAVA", DepartmentId = 2, IsActive = true },

                      new Pool { PoolId = 7, PoolName = "Fresher ORACLE", DepartmentId = 3, IsActive = true },
                      new Pool { PoolId = 8, PoolName = "SSE ORACLE", DepartmentId = 3, IsActive = true },
                      new Pool { PoolId = 9, PoolName = "SLO ORACLE", DepartmentId = 3, IsActive = true },

                      new Pool { PoolId = 10, PoolName = "Fresher LAMP", DepartmentId = 4, IsActive = true },
                      new Pool { PoolId = 11, PoolName = "SSE LAMP", DepartmentId = 4, IsActive = true },
                      new Pool { PoolId = 12, PoolName = "SLO LAMP", DepartmentId = 4, IsActive = true },

                      new Pool { PoolId = 13, PoolName = "Fresher BFS", DepartmentId = 5, IsActive = true },
                      new Pool { PoolId = 14, PoolName = "SSE BFS", DepartmentId = 5, IsActive = true },
                      new Pool { PoolId = 15, PoolName = "SLO BFS", DepartmentId = 5, IsActive = true }
                      );
            modelBuilder.Entity<PoolMembers>()
                    .HasData(
                      new PoolMembers { PoolMembersId = 1, PoolId = 1, EmployeeId = 1, IsActive = true },
                      new PoolMembers { PoolMembersId = 2, PoolId = 1, EmployeeId = 2, IsActive = true },
                      new PoolMembers { PoolMembersId = 3, PoolId = 2, EmployeeId = 2, IsActive = true },
                      new PoolMembers { PoolMembersId = 4, PoolId = 2, EmployeeId = 3, IsActive = true },

                      new PoolMembers { PoolMembersId = 5, PoolId = 3, EmployeeId = 4, IsActive = true },
                      new PoolMembers { PoolMembersId = 6, PoolId = 3, EmployeeId = 5, IsActive = true },
                      new PoolMembers { PoolMembersId = 7, PoolId = 4, EmployeeId = 5, IsActive = true },
                      new PoolMembers { PoolMembersId = 8, PoolId = 4, EmployeeId = 6, IsActive = true },

                      new PoolMembers { PoolMembersId = 9, PoolId = 5, EmployeeId = 7, IsActive = true }
                      );
                      modelBuilder.Entity<EmployeeDriveResponse>()
                      .HasData(
                        new EmployeeDriveResponse{ResponseId=5,DriveId=1,EmployeeId=1,ResponseType=1 },
                        new EmployeeDriveResponse{ResponseId=6,DriveId=2,EmployeeId=2,ResponseType=2},
                        new EmployeeDriveResponse{ResponseId=3,DriveId=2,EmployeeId=1,ResponseType=1},
                        new EmployeeDriveResponse{ ResponseId=4,DriveId=1,EmployeeId=2,ResponseType=1}
                        

                      );
                      modelBuilder.Entity<EmployeeAvailability>()
                      .HasData(
                        new EmployeeAvailability{EmployeeAvailabilityId=1,DriveId=1,EmployeeId=2,InterviewDate=Convert.ToDateTime("2022-07-05"),IsInterviewScheduled=true,IsInterviewCancelled=false,CancellationReason=null,Comments=null,From=Convert.ToDateTime("2022-07-07 09:00"),To=Convert.ToDateTime("2022-05-07 09:30")},
                        new EmployeeAvailability{EmployeeAvailabilityId=2,DriveId=2,EmployeeId=2,InterviewDate=Convert.ToDateTime("2022-07-05"),IsInterviewScheduled=true,IsInterviewCancelled=false,CancellationReason=null,Comments=null,From=Convert.ToDateTime("2022-05-07 10:00"),To=Convert.ToDateTime("2022-05-07 10:30")},
                        new EmployeeAvailability{EmployeeAvailabilityId=3,DriveId=5,EmployeeId=2,InterviewDate=Convert.ToDateTime("2022-07-06"),IsInterviewScheduled=true,IsInterviewCancelled=false,CancellationReason=null,Comments=null,From=Convert.ToDateTime("2022-05-07 09:00"),To=Convert.ToDateTime("2022-05-07 10:00")},
                        new EmployeeAvailability{EmployeeAvailabilityId=4,DriveId=5,EmployeeId=3,InterviewDate=Convert.ToDateTime("2022-07-07"),IsInterviewScheduled=true,IsInterviewCancelled=true,CancellationReason="For Testing",Comments="Testing comment",From=Convert.ToDateTime("2022-05-07 10:00"),To=Convert.ToDateTime("2022-05-07 11:00")},
                        new EmployeeAvailability{EmployeeAvailabilityId=5,DriveId=6,EmployeeId=2,InterviewDate=Convert.ToDateTime("2022-07-05"),IsInterviewScheduled=true,IsInterviewCancelled=false,CancellationReason=null,Comments=null,From=Convert.ToDateTime("2022-05-07 09:00"),To=Convert.ToDateTime("2022-05-07 09:30")},
                        new EmployeeAvailability{EmployeeAvailabilityId=6,DriveId=6,EmployeeId=3,InterviewDate=Convert.ToDateTime("2022-07-08"),IsInterviewScheduled=true,IsInterviewCancelled=false,CancellationReason=null,Comments=null,From=Convert.ToDateTime("2022-05-07 09:00"),To=Convert.ToDateTime("2022-05-07 09:30")},
                        new EmployeeAvailability{EmployeeAvailabilityId=7,DriveId=7,EmployeeId=2,InterviewDate=Convert.ToDateTime("2022-07-09"),IsInterviewScheduled=true,IsInterviewCancelled=false,CancellationReason=null,Comments=null,From=Convert.ToDateTime("2022-05-07 8:30"),To=Convert.ToDateTime("2022-05-07 09:30")},
                        new EmployeeAvailability{EmployeeAvailabilityId=8,DriveId=7,EmployeeId=2,InterviewDate=Convert.ToDateTime("2022-07-09"),IsInterviewScheduled=true,IsInterviewCancelled=false,CancellationReason=null,Comments=null,From=Convert.ToDateTime(" 2022-05-07 10:00"),To=Convert.ToDateTime("2022-05-07 11:00")},
                        new EmployeeAvailability{EmployeeAvailabilityId=9,DriveId=7,EmployeeId=3,InterviewDate=Convert.ToDateTime("2022-07-09"),IsInterviewScheduled=true,IsInterviewCancelled=false,CancellationReason=null,Comments=null,From=Convert.ToDateTime("2022-05-07 09:00"),To=Convert.ToDateTime("2022-05-07 10:00")},
                        new EmployeeAvailability{EmployeeAvailabilityId=10,DriveId=8,EmployeeId=3,InterviewDate=Convert.ToDateTime("2022-07-08"),IsInterviewScheduled=true,IsInterviewCancelled=false,CancellationReason=null,Comments=null,From=Convert.ToDateTime("2022-05-07 09:30"),To=Convert.ToDateTime("2022-05-07 10:00")},
                        new EmployeeAvailability{EmployeeAvailabilityId=11,DriveId=8,EmployeeId=3,InterviewDate=Convert.ToDateTime("2022-07-08"),IsInterviewScheduled=true,IsInterviewCancelled=false,CancellationReason=null,Comments=null,From=Convert.ToDateTime("2022-05-07 10:30"),To=Convert.ToDateTime("2022-05-07 11:00")},
                        new EmployeeAvailability{EmployeeAvailabilityId=12,DriveId=9,EmployeeId=2,InterviewDate=Convert.ToDateTime("2022-07-07"),IsInterviewScheduled=true,IsInterviewCancelled=false,CancellationReason=null,Comments=null,From=Convert.ToDateTime(" 2022-05-07 09:00"),To=Convert.ToDateTime("2022-05-07 10:00")},
                        new EmployeeAvailability{EmployeeAvailabilityId=13,DriveId=9,EmployeeId=3,InterviewDate=Convert.ToDateTime("2022-07-07"),IsInterviewScheduled=true,IsInterviewCancelled=false,CancellationReason=null,Comments=null,From=Convert.ToDateTime("2022-05-07 09:00"),To=Convert.ToDateTime("2022-05-07 10:00")},
                        new EmployeeAvailability{EmployeeAvailabilityId=14,DriveId=10,EmployeeId=2,InterviewDate=Convert.ToDateTime("2022-05-07"),IsInterviewScheduled=true,IsInterviewCancelled=true,CancellationReason="Testing",Comments="Testing Comment",From=Convert.ToDateTime("2022-05-07 09:00"),To=Convert.ToDateTime("2022-05-07 09:30")},
                        new EmployeeAvailability{EmployeeAvailabilityId=15,DriveId=10,EmployeeId=3,InterviewDate=Convert.ToDateTime("2022-05-07"),IsInterviewScheduled=true,IsInterviewCancelled=false,CancellationReason=null,Comments=null,From=Convert.ToDateTime("2022-05-07 11:00"),To=Convert.ToDateTime("2022-05-07 11:30")},
                        new EmployeeAvailability{EmployeeAvailabilityId=16,DriveId=10,EmployeeId=3,InterviewDate=Convert.ToDateTime("2022-05-07"),IsInterviewScheduled=true,IsInterviewCancelled=false,CancellationReason=null,Comments=null,From=Convert.ToDateTime("2022-05-07 12:00"),To=Convert.ToDateTime("2022-05-07 12:30")},
                        new EmployeeAvailability{EmployeeAvailabilityId=17,DriveId=13,EmployeeId=5,InterviewDate=Convert.ToDateTime("2022-08-12"),IsInterviewScheduled=true,IsInterviewCancelled=false,CancellationReason=null,Comments=null,From=Convert.ToDateTime("2022-05-07 10:00"),To=Convert.ToDateTime("2022-05-07 10:30")},
                        new EmployeeAvailability{EmployeeAvailabilityId=18,DriveId=13,EmployeeId=6,InterviewDate=Convert.ToDateTime("2022-08-13"),IsInterviewScheduled=true,IsInterviewCancelled=false,CancellationReason=null,Comments=null,From=Convert.ToDateTime("2022-05-07 12:00"),To=Convert.ToDateTime("2022-05-07 12:30")},
                        new EmployeeAvailability{EmployeeAvailabilityId=19,DriveId=14,EmployeeId=5,InterviewDate=Convert.ToDateTime("2022-08-07"),IsInterviewScheduled=true,IsInterviewCancelled=false,CancellationReason=null,Comments=null,From=Convert.ToDateTime("2022-05-07 11:00"),To=Convert.ToDateTime("2022-05-07 11:30")},
                        new EmployeeAvailability{EmployeeAvailabilityId=20,DriveId=14,EmployeeId=6,InterviewDate=Convert.ToDateTime("2022-08-07"),IsInterviewScheduled=true,IsInterviewCancelled=false,CancellationReason=null,Comments=null,From=Convert.ToDateTime("2022-05-07 12:00"),To=Convert.ToDateTime("2022-05-07 12:30")},
                        new EmployeeAvailability{EmployeeAvailabilityId=21,DriveId=15,EmployeeId=5,InterviewDate=Convert.ToDateTime("2022-08-10"),IsInterviewScheduled=true,IsInterviewCancelled=false,CancellationReason=null,Comments=null,From=Convert.ToDateTime("2022-05-07 09:00"),To=Convert.ToDateTime("2022-05-07 10:00")},
                        new EmployeeAvailability{EmployeeAvailabilityId=22,DriveId=15,EmployeeId=5,InterviewDate=Convert.ToDateTime("2022-09-11"),IsInterviewScheduled=true,IsInterviewCancelled=false,CancellationReason=null,Comments=null,From=Convert.ToDateTime("2022-05-07 10:00"),To=Convert.ToDateTime("2022-05-07 11:00")},
                        new EmployeeAvailability{EmployeeAvailabilityId=23,DriveId=15,EmployeeId=6,InterviewDate=Convert.ToDateTime("2022-09-11"),IsInterviewScheduled=true,IsInterviewCancelled=false,CancellationReason=null,Comments=null,From=Convert.ToDateTime("2022-05-07 10:00"),To=Convert.ToDateTime("2022-05-07 11:00")},
                        new EmployeeAvailability{EmployeeAvailabilityId=24,DriveId=16,EmployeeId=6,InterviewDate=Convert.ToDateTime("2022-09-15"),IsInterviewScheduled=true,IsInterviewCancelled=false,CancellationReason=null,Comments=null,From=Convert.ToDateTime("2022-05-07 10:00"),To=Convert.ToDateTime("2022-05-07 10:30")},
                        new EmployeeAvailability{EmployeeAvailabilityId=25,DriveId=16,EmployeeId=6,InterviewDate=Convert.ToDateTime("2022-09-16"),IsInterviewScheduled=true,IsInterviewCancelled=false,CancellationReason=null,Comments=null,From=Convert.ToDateTime("2022-05-07 11:00"),To=Convert.ToDateTime("2022-05-07 11:30")}















                        
                      );
             modelBuilder.Entity<Drive>()
                    .HasData( 
                      new Drive {DriveId = 1, Name = "Freshers .Net Drive T", FromDate = System.DateTime.Now, ToDate = System.DateTime.Now.AddDays(1), DepartmentId = 1, PoolId = 1, ModeId = 2, LocationId = 1, IsScheduled = true, IsCancelled = false, CancelReason = null, AddedBy = 10, AddedOn = System.DateTime.Now, UpdatedBy = 9, UpdatedOn =System.DateTime.Now},
                      new Drive {DriveId = 2, Name = "Freshers .Net Drive S", FromDate = System.DateTime.Now.AddDays(3), ToDate = System.DateTime.Now.AddDays(4), DepartmentId = 1, PoolId = 1, ModeId = 2, LocationId = 1, IsScheduled = true, IsCancelled = false, CancelReason = null, AddedBy = 10, AddedOn = System.DateTime.Now, UpdatedBy = 9, UpdatedOn =System.DateTime.Now},
                      new Drive {DriveId = 3, Name = "Freshers .Net Drive U", FromDate = System.DateTime.Now.AddDays(6), ToDate = System.DateTime.Now.AddDays(7), DepartmentId = 1, PoolId = 1, ModeId = 2, LocationId = 1, IsScheduled = false, IsCancelled = false, CancelReason = null, AddedBy = 10, AddedOn = System.DateTime.Now, UpdatedBy = 9, UpdatedOn =System.DateTime.Now},
                      new Drive {DriveId = 4, Name = "Freshers .Net Drive C", FromDate = System.DateTime.Now, ToDate = System.DateTime.Now.AddDays(1), DepartmentId = 1, PoolId = 1, ModeId = 2, LocationId = 1, IsScheduled = true, IsCancelled = true, CancelReason = "Cancelled For Testing", AddedBy = 10, AddedOn = System.DateTime.Now, UpdatedBy = 9, UpdatedOn =System.DateTime.Now},

                      new Drive {DriveId = 5, Name = "SSE .Net Drive T", FromDate = System.DateTime.Now, ToDate = System.DateTime.Now, DepartmentId = 1, PoolId = 2, ModeId = 1, LocationId = 9, IsScheduled = true, IsCancelled = false, CancelReason = null, AddedBy = 10, AddedOn = System.DateTime.Now, UpdatedBy = 9, UpdatedOn =System.DateTime.Now},
                      new Drive {DriveId = 6, Name = "SSE .Net Drive S", FromDate = System.DateTime.Now.AddDays(3), ToDate = System.DateTime.Now, DepartmentId = 1, PoolId = 2, ModeId = 2, LocationId = 3, IsScheduled = true, IsCancelled = false, CancelReason = null, AddedBy = 10, AddedOn = System.DateTime.Now, UpdatedBy = 9, UpdatedOn =System.DateTime.Now},
                      new Drive {DriveId = 7, Name = "SSE .Net Drive U", FromDate = System.DateTime.Now.AddDays(6), ToDate = System.DateTime.Now, DepartmentId = 1, PoolId = 2, ModeId = 1, LocationId = 9, IsScheduled = false, IsCancelled = false, CancelReason = null, AddedBy = 10, AddedOn = System.DateTime.Now, UpdatedBy = 9, UpdatedOn =System.DateTime.Now},
                      new Drive {DriveId = 8, Name = "SSE .Net Drive C", FromDate = System.DateTime.Now, ToDate = System.DateTime.Now, DepartmentId = 1, PoolId = 2, ModeId = 1, LocationId = 9, IsScheduled = true, IsCancelled = true, CancelReason = "Cancelled For Testing", AddedBy = 10, AddedOn = System.DateTime.Now, UpdatedBy = 9, UpdatedOn =System.DateTime.Now},
                      
                      new Drive {DriveId = 9, Name = "SLO .Net Drive T", FromDate = System.DateTime.Now, ToDate = System.DateTime.Now.AddDays(1), DepartmentId = 1, PoolId = 2, ModeId = 1, LocationId = 9, IsScheduled = true, IsCancelled = false, CancelReason = null, AddedBy = 10, AddedOn = System.DateTime.Now, UpdatedBy = 9, UpdatedOn =System.DateTime.Now},
                      new Drive {DriveId = 10, Name = "SLO .Net Drive S", FromDate = System.DateTime.Now.AddDays(3), ToDate = System.DateTime.Now.AddDays(4), DepartmentId = 1, PoolId = 2, ModeId = 2, LocationId = 5, IsScheduled = true, IsCancelled = false, CancelReason = null, AddedBy = 10, AddedOn = System.DateTime.Now, UpdatedBy = 9, UpdatedOn =System.DateTime.Now},
                      new Drive {DriveId = 11, Name = "SLO .Net Drive U", FromDate = System.DateTime.Now.AddDays(6), ToDate = System.DateTime.Now.AddDays(7), DepartmentId = 1, PoolId = 2, ModeId = 2, LocationId = 5, IsScheduled = false, IsCancelled = false, CancelReason = null, AddedBy = 10, AddedOn = System.DateTime.Now, UpdatedBy = 9, UpdatedOn =System.DateTime.Now},
                      new Drive {DriveId = 12, Name = "SLO .Net Drive C", FromDate = System.DateTime.Now, ToDate = System.DateTime.Now.AddDays(1), DepartmentId = 1, PoolId = 2, ModeId = 1, LocationId = 5, IsScheduled = true, IsCancelled = true, CancelReason = "Cancelled For Testing", AddedBy = 10, AddedOn = System.DateTime.Now, UpdatedBy = 9, UpdatedOn =System.DateTime.Now},


                      // JAVA
                      new Drive {DriveId = 13, Name = "Freshers JAVA Drive T", FromDate = System.DateTime.Now, ToDate = System.DateTime.Now.AddDays(1), DepartmentId = 2, PoolId = 4, ModeId = 2, LocationId = 1, IsScheduled = true, IsCancelled = false, CancelReason = null, AddedBy = 10, AddedOn = System.DateTime.Now, UpdatedBy = 9, UpdatedOn =System.DateTime.Now},
                      new Drive {DriveId = 14, Name = "Freshers JAVA Drive S", FromDate = System.DateTime.Now.AddDays(3), ToDate = System.DateTime.Now.AddDays(4), DepartmentId = 2, PoolId = 4, ModeId = 2, LocationId = 1, IsScheduled = true, IsCancelled = false, CancelReason = null, AddedBy = 10, AddedOn = System.DateTime.Now, UpdatedBy = 9, UpdatedOn =System.DateTime.Now},
                      new Drive {DriveId = 15, Name = "Freshers JAVA Drive U", FromDate = System.DateTime.Now.AddDays(6), ToDate = System.DateTime.Now.AddDays(7), DepartmentId = 2, PoolId = 4, ModeId = 2, LocationId = 1, IsScheduled = false, IsCancelled = false, CancelReason = null, AddedBy = 10, AddedOn = System.DateTime.Now, UpdatedBy = 9, UpdatedOn =System.DateTime.Now},
                      new Drive {DriveId = 16, Name = "Freshers JAVA Drive C", FromDate = System.DateTime.Now, ToDate = System.DateTime.Now.AddDays(1), DepartmentId = 2, PoolId = 4, ModeId = 2, LocationId = 1, IsScheduled = true, IsCancelled = true, CancelReason = "Cancelled For Testing", AddedBy = 10, AddedOn = System.DateTime.Now, UpdatedBy = 9, UpdatedOn =System.DateTime.Now},
                      new Drive {DriveId = 17, Name = "SSE JAVA Drive T", FromDate = System.DateTime.Now, ToDate = System.DateTime.Now, DepartmentId = 2, PoolId = 5, ModeId = 1, LocationId = 9, IsScheduled = true, IsCancelled = false, CancelReason = null, AddedBy = 10, AddedOn = System.DateTime.Now, UpdatedBy = 9, UpdatedOn =System.DateTime.Now},
                      new Drive {DriveId = 18, Name = "SSE JAVA Drive S", FromDate = System.DateTime.Now.AddDays(3), ToDate = System.DateTime.Now, DepartmentId = 2, PoolId = 5, ModeId = 2, LocationId = 3, IsScheduled = true, IsCancelled = false, CancelReason = null, AddedBy = 10, AddedOn = System.DateTime.Now, UpdatedBy = 9, UpdatedOn =System.DateTime.Now},
                      new Drive {DriveId = 19, Name = "SSE JAVA Drive U", FromDate = System.DateTime.Now.AddDays(6), ToDate = System.DateTime.Now, DepartmentId = 2, PoolId = 5, ModeId = 1, LocationId = 9, IsScheduled = false, IsCancelled = false, CancelReason = null, AddedBy = 10, AddedOn = System.DateTime.Now, UpdatedBy = 9, UpdatedOn =System.DateTime.Now},
                      new Drive {DriveId = 20, Name = "SSE JAVA Drive C", FromDate = System.DateTime.Now, ToDate = System.DateTime.Now, DepartmentId = 2, PoolId = 5, ModeId = 1, LocationId = 9, IsScheduled = true, IsCancelled = true, CancelReason = "Cancelled For Testing", AddedBy = 10, AddedOn = System.DateTime.Now, UpdatedBy = 9, UpdatedOn =System.DateTime.Now},
                    
                      new Drive {DriveId = 21, Name = "SLO JAVA Drive T", FromDate = System.DateTime.Now, ToDate = System.DateTime.Now.AddDays(1), DepartmentId = 2, PoolId = 6, ModeId = 1, LocationId = 9, IsScheduled = true, IsCancelled = false, CancelReason = null, AddedBy = 10, AddedOn = System.DateTime.Now, UpdatedBy = 9, UpdatedOn =System.DateTime.Now},
                      new Drive {DriveId = 22, Name = "SLO JAVA Drive S", FromDate = System.DateTime.Now.AddDays(3), ToDate = System.DateTime.Now.AddDays(4), DepartmentId = 2, PoolId = 6, ModeId = 2, LocationId = 5, IsScheduled = true, IsCancelled = false, CancelReason = null, AddedBy = 10, AddedOn = System.DateTime.Now, UpdatedBy = 9, UpdatedOn =System.DateTime.Now},
                      new Drive {DriveId = 23, Name = "SLO JAVA Drive U", FromDate = System.DateTime.Now.AddDays(6), ToDate = System.DateTime.Now.AddDays(7), DepartmentId = 2, PoolId = 6, ModeId = 2, LocationId = 5, IsScheduled = false, IsCancelled = false, CancelReason = null, AddedBy = 10, AddedOn = System.DateTime.Now, UpdatedBy = 9, UpdatedOn =System.DateTime.Now},
                      new Drive {DriveId = 24, Name = "SLO JAVA Drive C", FromDate = System.DateTime.Now, ToDate = System.DateTime.Now.AddDays(1), DepartmentId = 2, PoolId = 6, ModeId = 1, LocationId = 5, IsScheduled = true, IsCancelled = true, CancelReason = "Cancelled For Testing", AddedBy = 10, AddedOn = System.DateTime.Now, UpdatedBy = 9, UpdatedOn =System.DateTime.Now}
                      );

            //  modelBuilder.Entity<EmployeeDriveResponse>()
            //         .HasData(
            //           new EmployeeDriveResponse { ResponseId = 1, DriveId = 1, EmployeeId = 1, ResponseType = 1 },
            //           new EmployeeDriveResponse { ResponseId = 2, DriveId = 2, EmployeeId = 2, ResponseType = 1 },
            //           new EmployeeDriveResponse { ResponseId = 3, DriveId = 3, EmployeeId = 3, ResponseType = 0 },
            //           new EmployeeDriveResponse { ResponseId = 4, DriveId = 4, EmployeeId = 4, ResponseType = 1 },

            //           new EmployeeDriveResponse { ResponseId = 5, DriveId = 1, EmployeeId = 5, ResponseType = 0 },
            //           new EmployeeDriveResponse { ResponseId = 6, DriveId = 2, EmployeeId = 6, ResponseType = 1 },
            //           new EmployeeDriveResponse { ResponseId = 7, DriveId = 3, EmployeeId = 7, ResponseType = 1 },
            //           new EmployeeDriveResponse { ResponseId = 8, DriveId = 5, EmployeeId = 4, ResponseType = 1 },

            //           new EmployeeDriveResponse { ResponseId = 9, DriveId = 4, EmployeeId = 5, ResponseType = 1 },
            //           new EmployeeDriveResponse { ResponseId = 10, DriveId = 5, EmployeeId = 2, ResponseType = 1 },
            //           new EmployeeDriveResponse { ResponseId = 11, DriveId = 6, EmployeeId = 1, ResponseType = 1 },
            //           new EmployeeDriveResponse { ResponseId = 12, DriveId = 7, EmployeeId = 3, ResponseType = 0 }
            //           );

        }
    }
}