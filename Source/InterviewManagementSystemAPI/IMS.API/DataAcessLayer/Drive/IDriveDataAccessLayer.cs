using IMS.Models;
namespace IMS.DataAccessLayer
{
    public interface IDriveDataAccessLayer
    {

        public bool AddDriveToDatabase(Drive drive);
        public bool CancelDriveFromDatabase(int driveId, int tacId, string Reason);
        public List<Drive> GetDrivesByStatus(bool status);
        public List<Drive> GetTodaysDrivesByStatus(bool status);
        public List<Drive> GetScheduledDrivesByStatus(bool status);
        public List<Drive> GetUpcomingDrivesByStatus(bool status);
        public List<Drive> GetNonCancelledDrivesByStatus(bool status, int tacId);
        public List<Drive> GetDriveInviteByStatus(bool status);
        public Drive ViewDrive(int driveId);
        public List<Drive> ViewDrives(List<int> driveIds);


        //For Employee Drive Response Entity
        public bool AddResponseToDatabase(EmployeeDriveResponse response);
        public List<int> DriveIdForDriveInvites(int employeeId);

        public bool IsResponded(int employeeId, int driveId);
        public List<int> GetEmployeePoolIdsFromDatabase(int employeeId);
        //public bool UpdateResponseToDatabase(EmployeeDriveResponse response);

        //For Employee Availability Entity
        public bool SetTimeSlotToDatabase(EmployeeAvailability employeeAvailability);
        public List<EmployeeAvailability> ViewAvailability(int employeeId, int driveId);
        public List<EmployeeAvailability> ViewTodayInterviewsByStatus(bool status, int employeeId);
        public List<EmployeeAvailability> ViewScheduledInterviewsByStatus(bool status, int employeeId);
        public List<EmployeeAvailability> ViewUpcomingInterviewsByStatus(bool status, int employeeId);
        public List<EmployeeAvailability> ViewInterviewsByStatus(bool status, int employeeId);//int employeeId
        public List<EmployeeAvailability> ViewAvailableMembersForDrive(int driveId);
        public List<EmployeeAvailability> GetSlotAvailabilityGiven(int employeeId);
        public bool ScheduleInterview(int employeeAvailabilityId);
        public bool CancelInterview(int employeeAvailabilityId, string cancellationReason, string? comments);
        public List<Employee> GetEmployee(int departmentId);
        public List<EmployeeDriveResponse> GetResponseDetailsByStatus(int responseType, int employeeId, DateTime fromDate, DateTime toDate);
        public List<EmployeeAvailability> GetResponseUtilizationByStatus(bool isUtilized, int employeeId);
        public object GetDefaulters(int poolId);
        public List<EmployeeDriveResponse> GetDriveResponse(int driveId);
        public int GetUtilizationCountByStatus(int driveId, int employeeId, bool status);
        public int GetCancelledInterviewCount(int driveId, int employeeId);
        public List<EmployeeAvailability> ViewCancelledInterview(bool status, int employeeId);
        public Object GetDrivesForCurrentUser(int departmentId);
        public bool GetIsTraceEnabledFromConfiguration();
    }
}