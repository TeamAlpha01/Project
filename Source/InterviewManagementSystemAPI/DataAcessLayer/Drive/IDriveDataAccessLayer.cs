using IMS.Models;
namespace IMS.DataAccessLayer
{
    public interface IDriveDataAccessLayer
    {

        public bool AddDriveToDatabase(Drive drive);
        public bool CancelDriveFromDatabase(int driveId, int tacId, string Reason);
        public List<Drive> GetDrivesByStatus(bool status);
        public Drive ViewDrive(int driveId);


        //For Employee Drive Response Entity
        public bool AddResponseToDatabase(EmployeeDriveResponse response);
        public bool UpdateResponseToDatabase(int employeeId, int driveId, int responseType);

        //For Employee Availability Entity
        public bool SetTimeSlotToDatabase(EmployeeAvailability employeeAvailability);
        public List<EmployeeAvailability> ViewInterviewsByStatus(bool status);//int employeeId
        public bool ScheduleInterview(int employeeAvailabilityId);
        public bool CancelInterview(int employeeAvailabilityId);
    }
}