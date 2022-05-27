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
        public bool IsResponded(int employeeId, int driveId);
        public List<int > GetEmployeePoolIdsFromDatabase(int employeeId);
        //public bool UpdateResponseToDatabase(EmployeeDriveResponse response);

        //For Employee Availability Entity
        public bool SetTimeSlotToDatabase(EmployeeAvailability employeeAvailability);
        public List<EmployeeAvailability> ViewInterviewsByStatus(bool status, int employeeId);//int employeeId
        public List<EmployeeAvailability> ViewAvailableMembersForDrive(int driveId);
        public bool ScheduleInterview(int employeeAvailabilityId);
        public bool CancelInterview(int employeeAvailabilityId);
        public int GetResponseCountByStatus(int responseType,int employeeId);
        public int GetResponseUtilizationByStatus(bool isUtilized,int employeeId);
    }
}