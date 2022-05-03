using IMS.Models;
using IMS.DataAccessLayer;
using System.ComponentModel.DataAnnotations;

namespace IMS.Service
{
    public class DriveService : IDriveService
    {
        private IDriveDataAccessLayer _driveDataAccess;
        private ILogger logger;

        public DriveService(ILogger logger)
        {
            this.logger = logger;
            _driveDataAccess = DataFactory.DriveDataFactory.GetDriveDataAccessLayerObject(logger);
        }

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
                return (from drive in _driveDataAccess.GetDrivesByStatus(false) where (drive.FromDate.Date <= System.DateTime.Now.Date && drive.ToDate.Date >= System.DateTime.Now.Date) && drive.IsScheduled == true select drive).Cast<Drive>().ToList();
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
                return (from drive in _driveDataAccess.GetDrivesByStatus(false) where drive.FromDate.Date != System.DateTime.Now.Date && drive.IsScheduled == true select drive).Cast<Drive>().ToList();
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
                return (from drive in _driveDataAccess.GetDrivesByStatus(false) where drive.FromDate.Date != System.DateTime.Now.Date && drive.IsScheduled == false select drive).Cast<Drive>().ToList();
            }
            catch (Exception exception)
            {
                throw exception;
            }

        }

        public List<Drive> ViewAllScheduledDrives()
        {
            try
            {
                return (from drive in _driveDataAccess.GetDrivesByStatus(false) select drive).Cast<Drive>().ToList();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public List<Drive> ViewAllCancelledDrives()
        {
            try
            {
                return (from drive in _driveDataAccess.GetDrivesByStatus(true) select drive).Cast<Drive>().ToList();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public List<int> ViewDashboard(int employeeId)
        {
            try
            {
                List<int> DashboardCount = new List<int>();
                DashboardCount.Add((from drive in _driveDataAccess.GetDrivesByStatus(false) where drive.AddedBy==employeeId select drive).Cast<Drive>().ToList().Count());
                DashboardCount.Add((from drive in _driveDataAccess.GetDrivesByStatus(true) where drive.AddedBy==employeeId select drive).Cast<Drive>().ToList().Count());
                return DashboardCount;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public Drive ViewDrive(int driveId)
        {
            if (driveId <= 0)
                throw new ValidationException("driveId is not valid");

            try
            {
                return _driveDataAccess.ViewDrive(driveId);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}


