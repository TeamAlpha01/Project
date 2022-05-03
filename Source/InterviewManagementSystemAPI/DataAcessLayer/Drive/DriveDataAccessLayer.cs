using IMS.Models;

namespace IMS.DataAccessLayer
{
    public class DriveDataAccessLayer : IDriveDataAccessLayer
    {
        private InterviewManagementSystemDbContext _db = DataFactory.DbContextDataFactory.GetInterviewManagementSystemDbContextObject();
        
        private ILogger logger;
        public DriveDataAccessLayer(ILogger logger)
        {
            this.logger = logger;
        }

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

        public List<Drive> GetDrivesByStatus(bool status)
        {
            return (from drive in _db.Drives where drive.IsCancelled == status select drive).Cast<Drive>().ToList();
        }

    }
}