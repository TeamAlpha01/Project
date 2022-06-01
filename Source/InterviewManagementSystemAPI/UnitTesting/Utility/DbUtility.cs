using IMS.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using UnitTesting.MockData;

namespace UnitTesting.Utility
{
    public static class DbUtility
    {
        public static InterviewManagementSystemDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<InterviewManagementSystemDbContext>().UseInMemoryDatabase(databaseName: "Local Db").Options;
            return new InterviewManagementSystemDbContext(options); ;
        }
        public static void SeedInMemoryDb(InterviewManagementSystemDbContext dbContext)
        {
            dbContext.Roles.AddRange(RoleMock.GetRolesMock());
            dbContext.SaveChanges();
        }
    }
    public static class CommanUtility
    {
        public static string Problem{get;} = "Sorry some internal error occured";
    }

}