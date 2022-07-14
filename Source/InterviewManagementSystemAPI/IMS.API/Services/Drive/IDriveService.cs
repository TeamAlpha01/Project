using IMS.Models;

namespace IMS.Service
{
    public interface IDriveService
    {
        public bool CreateDrive(Drive drive);
        public bool CancelDrive(int driveId, int employeeId, string Reason);
        public Object ViewTodayDrives();
        public Object ViewScheduledDrives();
        public Object ViewUpcomingDrives();
        public Object ViewNonCancelledDrives(int tacId);
        public Object ViewAllCancelledDrives(int tacId);
        public Dictionary<string,int> ViewTACDashboard(int employeeId);  
        public Object ViewDrive(int driveId);


        //For Employee Drive Response Entity
        public bool AddResponse(EmployeeDriveResponse response);
        public object ViewDriveInvites(int employeeId);
        
        //public bool UpdateResponse(EmployeeDriveResponse response);
        
        //For Employee Availability Entity
        public bool SetTimeSlot(EmployeeAvailability employeeAvailability);
        public Object ViewAvailabilty(int employeeId,int driveId);

        public Object ViewTodayInterviews(int employeeId);
        public Object ViewScheduledInterview(int employeeId);
        public Object ViewUpcomingInterview(int employeeId);
        public Object ViewAllInterview(int employeeId);
        public bool ScheduleInterview(int employeeAvailabilityId);
        public bool CancelInterview(int employeeAvailabilityId, string cancellationReason, string? comments);
        public Object ViewAvailableMembersForDrive(int driveId);
        public Dictionary<string,int> ViewEmployeeDashboard(int employeeId,int departmentId,DateTime fromDate,DateTime toTime); 
        public Object ViewTotalDrives(int employeeId,DateTime fromDate,DateTime toDate);
        public Object ViewAcceptedDrives(int employeeId,DateTime fromDate,DateTime toDate);
        public Object ViewDeniedDrives(int employeeId,DateTime fromDate,DateTime toDate);
        public Object ViewIgnoredDrives(int employeeId,DateTime fromDate,DateTime toDate);
        public Object ViewUtilizedInterviews(int employeeId);
        public Object ViewNotUtilizedInterviews(int employeeId);
        public Object ViewTotalAvailability(int employeeId);
        public Object ViewDefaulters(int poolId);
        public Object ViewDriveResponse(int driveId);
        
    }
}