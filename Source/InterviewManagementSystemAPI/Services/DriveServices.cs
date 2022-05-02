using InterviewManagementSystemAPI.Models;
using InterviewManagementSystemAPI.DataAccessLayer;

namespace InterviewManagementSystemAPI.Service
{
    public class DriveService : IDriveService
    {
        private IDriveDataAccessLayer _driveDataAccess = DataFactory.DriveDataFactory.GetDriveDataAccessLayerObject();
        public bool CreateDrive(Drive drive)
        {
            if (drive == null)
                throw new ArgumentNullException("Drive object is empty");
            try
            {
                // drive.AddedEmployee=DataFactory.DbContextDataFactory.GetInterviewManagementSystemDbContextObject().Employees.Find(drive.AddedBy);

                // drive.UpdatedEmployee=DataFactory.DbContextDataFactory.GetInterviewManagementSystemDbContextObject().Employees.Find(drive.UpdatedBy);
                
                return _driveDataAccess.AddDriveToDatabase(drive) ? true : false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool CancelDrive(int driveId,int tacId,string reason)
        {
            if (driveId == 0 || tacId == 0 || reason.Length == 0)
                return false;
                
            return _driveDataAccess.CancelDriveFromDatabase(driveId,tacId,reason);
        }

        public List<Drive> ViewTodayDrive(int departmentId, int poolId)
        {
            return _driveDataAccess.ViewTodayDrive(departmentId,poolId);
        }
    }
}