using System.ComponentModel.DataAnnotations;
using IMS.Models;
using IMS.Validations;

namespace IMS.DataAccessLayer
{
    public class DriveDataAccessLayer : IDriveDataAccessLayer
    {
        private InterviewManagementSystemDbContext _db = DataFactory.DbContextDataFactory.GetInterviewManagementSystemDbContextObject();

        private ILogger _logger;
        public DriveDataAccessLayer(ILogger logger)
        {
            _logger = logger;
        }

        public bool AddDriveToDatabase(Drive drive)
        {
            DriveValidation.IsdriveValid(drive);
            try
            {
                _db.Drives.Add(drive);
                _db.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Exception on Drive DAL : AddDriveToDatabase(Drive drive) : {exception.Message}");
                return false;
            }
        }
        public bool CancelDriveFromDatabase(int driveId, int tacId, string reason)
        {
            DriveValidation.IsCancelDriveValid(driveId, tacId, reason);

            try
            {
                Drive drive = _db.Drives.Find(driveId);

                if (drive == null) throw new ValidationException("no drive is found with given drive id");

                drive.IsCancelled = true;
                drive.CancelReason = reason;
                drive.UpdatedBy = tacId;

                _db.Drives.Update(drive);
                _db.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Exception on Drive DAL : AddDriveToDatabase(Drive drive) : {exception.Message}");
                return false;
            }

        }

        public List<Drive> GetDrivesByStatus(bool status)
        {
            try
            {
                return (from drive in _db.Drives where drive.IsCancelled == status select drive).Cast<Drive>().ToList();
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Exception on Drive DAL : AddDriveToDatabase(Drive drive) : {exception.Message}");
                throw exception;
            }
        }

        public Drive ViewDrive(int driveId)
        {
            DriveValidation.IsDriveIdValid(driveId);

            try
            {
                var viewDrive = (Drive)from drive in _db.Drives where drive.DriveId == driveId select drive;

                return viewDrive != null ? viewDrive : throw new ValidationException("no drive is found");
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Exception on Drive DAL : IsDriveIdValid(driveId) : {exception.Message}");
                throw exception;
            }
        }
    }
}


