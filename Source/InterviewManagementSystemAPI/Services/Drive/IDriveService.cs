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
        public Object ViewNonCancelledDrives();
        public Object ViewAllCancelledDrives();
        public Dictionary<string,int> ViewTACDashboard(int employeeId);  
        public Drive ViewDrive(int driveId);


        //For Employee Drive Response Entity
        public bool AddResponse(EmployeeDriveResponse response);
        public bool UpdateResponse(EmployeeDriveResponse response);

        //For Employee Availability Entity
        public bool SetTimeSlot(EmployeeAvailability employeeAvailability);

        public Object ViewTodayInterviews(int employeeId);
        public Object ViewScheduledInterview(int employeeId);
        public Object ViewUpcomingInterview(int employeeId);
        public Object ViewAllInterview(int employeeId);
        public bool ScheduleInterview(int employeeAvailabilityId);
        public bool CancelInterview(int employeeAvailabilityId);
        public Object ViewAvailableMembersForDrive(int driveId);
        public Dictionary<string,int> ViewEmployeeDashboard(int employeeId);  
    }
}