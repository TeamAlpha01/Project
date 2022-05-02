using InterviewManagementSystemAPI.Models;

namespace InterviewManagementSystemAPI.Service
{
    public interface IDriveService
    {
        public bool CreateDrive(Drive drive);
        public bool CancelDrive(int driveId,int employeeId,string Reason);
        public List<Drive> ViewTodayDrive(int departmentId, int poolId);
        // public List<Drive> ViewUpcommingDrive(int departmentId, int poolId, DateTime driveDate);
        // public List<Drive> ViewScheduledDrive(int departmentId, int poolId, DateTime driveDate);
        // public List<int> ViewDashboard(int employeeId); //for all  user : based on the emp role we can seggregate the output
        // public List<Drive> ViewAllScheduledDrives(int departmentId, int poolId, DateTime driveDate);
        // public List<Drive> ViewAllCancelledDrives(int departmentId, int poolId, DateTime driveDate);


        // //For Interviewer in Drive Enitity

        // public Drive ViewDrive(int driveId);
        // public List<Drive> ViewDriveInvites(int employeeId);
        // public List<Drive> ViewAllInterview(int employeeId);
        // public List<Drive> ViewTodayInterviews(int poolId, DateTime driveDate, int employeeId);
        // public List<Drive> ViewScheduledInterviews(int poolId, DateTime driveDate, int employeeId);
        // public List<Drive> ViewUpcommingInterviews(int poolId, DateTime driveDate, int employeeId);
        // public List<Drive> ViewInterviewStatus(int employeeId, bool IsScheduled, bool IsInterviewCancelled, int ResponseType);

    }
}