using InterviewManagementSystemAPI.DataAccessLayer;
namespace InterviewManagementSystemAPI.DataFactory{
    public static class DbContextDataFactory{
        public static InterviewManagementSystemDbContext GetInterviewManagementSystemDbContextObject()
        {
            return new InterviewManagementSystemDbContext();
        }
    }
}