using IMS.Models;

namespace IMS.Service
{
    public interface IDriveService
    {
        public bool CreateDrive(Drive drive);
        public bool CancelDrive(int driveId, int employeeId, string Reason);
        public Object ViewTodayDrives();
        public Object ViewScheduledDrives();
        public Object ViewUpcommingDrives();
        public Object ViewAllScheduledDrives();
        public Object ViewAllCancelledDrives();
        public Dictionary<string,int> ViewTACDashboard(int employeeId);  
        public Drive ViewDrive(int driveId);


        //For Employee Drive Response Entity
        public bool AddResponse(EmployeeDriveResponse response);
        public bool UpdateResponse(int employeeId, int driveId, int responseType);

        //For Employee Availability Entity
        public bool SetTimeSlot(EmployeeAvailability employeeAvailability);

        public Object ViewTodayInterviews();
        public Object ViewScheduledInterview();
        public Object ViewUpcomingInterview();
        public Object ViewAllInterview();
        public bool ScheduleInterview(int employeeAvailabilityId);
        public bool CancelInterview(int employeeAvailabilityId);
        public Object ViewAvailableMembersForDrive(int driveId);
        public Dictionary<string,int> ViewEmployeeDashboard(int employeeId);  
    }
}