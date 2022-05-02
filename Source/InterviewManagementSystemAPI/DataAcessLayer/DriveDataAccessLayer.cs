using InterviewManagementSystemAPI.Models;

namespace InterviewManagementSystemAPI.DataAccessLayer
{
    public class DriveDataAccessLayer : IDriveDataAccessLayer
    {
        private InterviewManagementSystemDbContext _db = DataFactory.DbContextDataFactory.GetInterviewManagementSystemDbContextObject();
        public bool AddDriveToDatabase(Drive drive)
        {
            if (drive == null)
                throw new ArgumentNullException("Drive object is empty");
            try
            {
                _db.Drives.Add(drive);
                _db.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }
        public bool CancelDriveFromDatabase(int driveId, int tacId, string reason)
        {
            if (driveId == 0 || tacId == 0 || reason.Length == 0)
                return false;

            Drive drive = _db.Drives.Find(driveId);
            drive.IsCancelled = true;
            drive.CancelReason = reason;
            _db.Drives.Update(drive);
            _db.SaveChanges();
            return true;

        }

        public List<Drive> ViewTodayDrive(int departmentId, int poolId)
        {
            if (departmentId == 0 && poolId != 0)
                return (from drive in _db.Drives where (drive.PoolId == poolId && drive.FromDate.Date == System.DateTime.Now.Date) select drive).Cast<Drive>().ToList();
            // if(poolId==0)
            //     return (List<Drive>)(from drive in _db.Drives where drive

            return (from drive in _db.Drives where drive.FromDate.Date == System.DateTime.Now.Date select drive).Cast<Drive>().ToList();

        }
    }
}