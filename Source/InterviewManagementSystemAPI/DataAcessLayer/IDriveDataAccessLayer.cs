using InterviewManagementSystemAPI.Models;
namespace InterviewManagementSystemAPI.DataAccessLayer
{
    public interface IDriveDataAccessLayer
    {

        public bool AddDriveToDatabase(Drive drive);
        public bool CancelDriveFromDatabase(int driveId,int tacId,string Reason);
        public List<Drive> ViewTodayDrive(int departmentId, int poolId);
    }
}