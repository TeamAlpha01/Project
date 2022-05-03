using IMS.Models;
using IMS.DataAccessLayer;

namespace IMS.Service
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
                return _driveDataAccess.AddDriveToDatabase(drive) ? true : false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool CancelDrive(int driveId, int tacId, string reason)
        {
            if (driveId == 0 || tacId == 0 || reason.Length == 0)
                return false;

            try
            {
                return _driveDataAccess.CancelDriveFromDatabase(driveId, tacId, reason);
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public List<Drive> ViewTodayDrives()
        {
            try
            {
                return (from drive in _driveDataAccess.GetActiveDrives() where (drive.FromDate <= System.DateTime.Now && drive.ToDate >= System.DateTime.Now) && drive.IsScheduled == true select drive).Cast<Drive>().ToList();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            
        }

        public List<Drive> ViewScheduledDrives()
        {
            try
            {
                return (from drive in _driveDataAccess.GetActiveDrives() where drive.FromDate != System.DateTime.Now && drive.IsScheduled == true select drive).Cast<Drive>().ToList();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            
        }

        public List<Drive> ViewUpcommingDrives()
        {
            try
            {
                return (from drive in _driveDataAccess.GetActiveDrives() where drive.FromDate != System.DateTime.Now && drive.IsScheduled == false select drive).Cast<Drive>().ToList();
            }
            catch (Exception exception)
            {
               throw exception;
            }
            
        }
    }
}


