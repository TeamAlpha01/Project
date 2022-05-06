using Microsoft.EntityFrameworkCore;
using IMS.Model;
namespace IMS.DataAccessLayer
{
    public class  InterviewManagementSystemDbContext : DbContext
    {
        // internal object employees;

        public DbSet<Employee> employees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=ASPIREREN032;Database=InterviewManagementSystem;Trusted_Connection=True;");
        }
    }
}