using Source.DataAccessLayer;
namespace Source.DataFactory{
    public static class DbContextDataFactory{
        public static InterviewManagementSystemDbContext GetInterviewManagementSystemDbContextObject()
        {
            return new InterviewManagementSystemDbContext();
        }
    }
}