using IMS.Models;

namespace IMS.Service
{
    public interface IDriveService
    {
        public bool CreateDrive(Drive drive);
        public bool CancelDrive(int driveId,int employeeId,string Reason);
        public List<Drive> ViewTodayDrives();
        public List<Drive> ViewScheduledDrives();
        public List<Drive> ViewUpcommingDrives();
        public List<Drive> ViewAllScheduledDrives();
        public List<Drive> ViewAllCancelledDrives();
        public List<int> ViewDashboard(int employeeId);  //for all  user : based on the emp role we can seggregate the output


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