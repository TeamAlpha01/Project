using IMS.DataAccessLayer;
namespace IMS.DataFactory
{
    public static class DbContextDataFactory
    {
        public static InterviewManagementSystemDbContext GetInterviewManagementSystemDbContextObject()
        {
            return new InterviewManagementSystemDbContext();
        }
    }
}