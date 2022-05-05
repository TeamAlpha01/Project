using IMS.Models;
using IMS.DataAccessLayer;
using System.ComponentModel.DataAnnotations;
using IMS.Validations;

namespace IMS.Service
{
    public class DriveService : IDriveService
    {
        private IDriveDataAccessLayer _driveDataAccess;
        private ILogger _logger;

        public DriveService(ILogger logger)
        {
            _logger = logger;
            _driveDataAccess = DataFactory.DriveDataFactory.GetDriveDataAccessLayerObject(logger);
        }

        public bool CreateDrive(Drive drive)
        {
            DriveValidation.IsdriveValid(drive);

            try
            {
                return _driveDataAccess.AddDriveToDatabase(drive) ? true : false;
            }
            catch (ValidationException driveNotValid)
            {
                _logger.LogInformation($"Drive Service : CreateDrive() : {driveNotValid.Message}");
                return false;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Drive Service : CreateDrive() : {exception.Message}");
                return false;
            }
        }
        public bool CancelDrive(int driveId, int tacId, string reason)
        {
            DriveValidation.IsCancelDriveValid(driveId, tacId, reason);

            try
            {
                return _driveDataAccess.CancelDriveFromDatabase(driveId, tacId, reason);
            }
            catch (ValidationException cancelDriveNotValid)
            {
                _logger.LogInformation($"Drive Service : CancelDrive() : {cancelDriveNotValid.Message}");
                return false;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Drive Service : CancelDrive() : {exception.Message}");
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
                _logger.LogInformation($"Drive Service : ViewTodayDrives() : {exception.Message}");
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
                _logger.LogInformation($"Drive Service : ViewScheduledDrives() : {exception.Message}");
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
                _logger.LogInformation($"Drive Service : ViewUpcommingDrives() : {exception.Message}");
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
                _logger.LogInformation($"Drive Service : ViewAllScheduledDrives() : {exception.Message}");
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
                _logger.LogInformation($"Drive Service : ViewAllCancelledDrives() : {exception.Message}");
                throw exception;
            }
        }

        public List<int> ViewDashboard(int employeeId)
        {
            DriveValidation.IsEmployeeIdValid(employeeId);
            try
            {
                List<int> DashboardCount = new List<int>();
                DashboardCount.Add((from drive in _driveDataAccess.GetDrivesByStatus(false) where drive.AddedBy == employeeId select drive).Cast<Drive>().ToList().Count());
                DashboardCount.Add((from drive in _driveDataAccess.GetDrivesByStatus(true) where drive.AddedBy == employeeId select drive).Cast<Drive>().ToList().Count());
                return DashboardCount;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Drive Service : ViewDashboard() : {exception.Message}");
                throw exception;
            }
        }

        public Drive ViewDrive(int driveId)
        {
            DriveValidation.IsDriveIdValid(driveId);

            try
            {
                return _driveDataAccess.ViewDrive(driveId);
            }
            catch (ValidationException driveIdNotValid)
            {
                _logger.LogInformation($"Drive Service : ViewDrive() : {driveIdNotValid.Message}");
                throw driveIdNotValid;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Drive Service : ViewDrive() : {exception.Message}");
                throw exception;
            }
        }

         //For Employee Drive Response Entity
        public bool AddResponse(EmployeeDriveResponse response)
        {
            if (response == null) throw new ValidationException("Response cannnot be null");

            try
            {
                return _driveDataAccess.AddResponseToDatabase(response) ? true : false;
            }
            catch (ValidationException responseNotValid)
            {
                _logger.LogInformation($"EmployeeDriveResponse Service : AddResponse(EmployeeDriveResponse response) : {responseNotValid.Message}");
                return false;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"EmployeeDriveResponse Service : AddResponse(EmployeeDriveResponse response) : {exception.Message}");
                return false;
            }
        }

        public bool UpdateResponse(int employeeId, int driveId, int responseType)
        {
            if (driveId <= 0 || employeeId <= 0 || responseType <= 0) throw new ValidationException("DriveId or EmployeeId or Response Type is not valid");

            try
            {
                return _driveDataAccess.UpdateResponseToDatabase(employeeId, driveId, responseType) ? true : false;
            }
            catch (ValidationException updateResponseNotValid)
            {
                _logger.LogInformation($"EmployeeDriveResponse Service : UpdateResponse(int employeeId, int driveId, int responseType) : {updateResponseNotValid.Message}");
                return false;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"EmployeeDriveResponse Service : UpdateResponse(int employeeId, int driveId, int responseType) : {exception.Message}");
                return false;
            }
        }

        //For Employee Availability Entity
         public bool SetTimeSlot(EmployeeAvailability employeeAvailability)
        {
            return _driveDataAccess.SetTimeSlotToDatabase(employeeAvailability);
            
        }
    }
}


