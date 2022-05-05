using IMS.Models;

namespace IMS.Service
{
    public interface IDriveService
    {
        public bool CreateDrive(Drive drive);
        public bool CancelDrive(int driveId, int employeeId, string Reason);
        public List<Drive> ViewTodayDrives();
        public List<Drive> ViewScheduledDrives();
        public List<Drive> ViewUpcommingDrives();
        public List<Drive> ViewAllScheduledDrives();
        public List<Drive> ViewAllCancelledDrives();
        public List<int> ViewDashboard(int employeeId);  //for all  user : based on the emp role we can seggregate the output
        public Drive ViewDrive(int driveId);


        //For Employee Drive Response Entity
        public bool AddResponse(EmployeeDriveResponse response);
        public bool UpdateResponse(int employeeId, int driveId, int responseType);

        //For Employee Availability Entity
        public bool SetTimeSlot(EmployeeAvailability employeeAvailability);
    }
}