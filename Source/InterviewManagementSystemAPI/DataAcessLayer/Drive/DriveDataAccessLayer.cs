using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
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
                var viewDrive = (from drive in _db.Drives where drive.DriveId == driveId select drive).First();

                return viewDrive != null ? viewDrive : throw new ValidationException("no drive is found");
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Exception on Drive DAL : IsDriveIdValid(driveId) : {exception.Message}");
                throw exception;
            }
        }



        //For Employee Drive Response Entity
        public bool AddResponseToDatabase(EmployeeDriveResponse response)
        {
            if (response == null) throw new ValidationException("Response cannnot be null");

            try
            {
                _db.EmployeeDriveResponse.Add(response);
                _db.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Exception on EmployeeDriveResponse DAL : AddResponseToDatabase(EmployeeDriveResponse response) : {exception.Message}");
                return false;
            }
        }


        public bool UpdateResponseToDatabase(int employeeId, int driveId, int responseType)
        {
            if (driveId <= 0 || employeeId <= 0 || responseType <= 0)
                throw new ValidationException("DriveId or EmployeeId or Response Type is not valid");

            try
            {
                var EmployeeResponse = (from response in _db.EmployeeDriveResponse where response.EmployeeId == employeeId && response.DriveId == driveId select response).First();

                if (EmployeeResponse == null) throw new ValidationException("no response is found with given employee id and drive id");

                EmployeeResponse.ResponseType = responseType;
                _db.EmployeeDriveResponse.Update(EmployeeResponse);
                _db.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Exception on EmployeeDriveResponse DAL : UpdateResponseToDatabase(int employeeId, int driveId, int responseType) : {exception.Message}");
                return false;
            }
        }

        //For Employee Avalability Entity
        public bool SetTimeSlotToDatabase(EmployeeAvailability employeeAvailability)
        {

            //employeeAvailability validation
            try
            {
                _db.EmployeeAvailability.Add(employeeAvailability);
                return true;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Exception on EmployeeDriveResponse DAL : UpdateResponseToDatabase(int employeeId, int driveId, int responseType) : {exception.Message}");
                return false;
            }
        }
        public List<EmployeeAvailability> ViewInterviewsByStatus(bool status)//int employeeId
        {
            try
            {
                return (from interview in _db.EmployeeAvailability.Include(d => d.Drive).Include(a => a.Drive.Location).Include(a => a.Drive.Pool) where interview.IsInterviewCancelled == status && interview.Drive.IsCancelled == false select interview).ToList();
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Exception on EmployeeDriveResponse DAL : UpdateResponseToDatabase(int employeeId, int driveId, int responseType) : {exception.Message}");
                throw exception;
            }
        }

        public bool ScheduleInterview(int employeeAvailabilityId)
        {
            try
            {
                var employeeAvailability = _db.EmployeeAvailability.Find(employeeAvailabilityId);
                if (employeeAvailability == null) throw new ValidationException($"No Employe Availability is Found with employeeAvailabilityId : {employeeAvailabilityId}");

                employeeAvailability.IsInterviewScheduled = true;
                _db.EmployeeAvailability.Update(employeeAvailability);
                _db.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Exception on EmployeeDriveResponse DAL : UpdateResponseToDatabase(int employeeId, int driveId, int responseType) : {exception.Message}");
                return false;
            }
        }
        public bool CancelInterview(int employeeAvailabilityId)
        {
            try
            {
                var employeeAvailability = _db.EmployeeAvailability.Find(employeeAvailabilityId);
                if (employeeAvailability == null) throw new ValidationException($"No Employe Availability is Found with employeeAvailabilityId : {employeeAvailabilityId}");

                employeeAvailability.IsInterviewCancelled = true;
                _db.EmployeeAvailability.Update(employeeAvailability);
                _db.SaveChanges();
                return true;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Exception on EmployeeDriveResponse DAL : UpdateResponseToDatabase(int employeeId, int driveId, int responseType) : {exception.Message}");
                return false;
            }
        }
        public List<EmployeeAvailability> ViewAvailableMembersForDrive(int driveId)
        {
            try
            {
                if (_db.EmployeeAvailability.Find(driveId) == null) throw new ValidationException($"No Drive is Found with driveId : {driveId}");
                return (from availability in _db.EmployeeAvailability.Include(e=>e.Employee) where availability.DriveId==driveId select availability).ToList();
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Exception on EmployeeDriveResponse DAL : UpdateResponseToDatabase(int employeeId, int driveId, int responseType) : {exception.Message}");
                throw exception;
            }
        }
        public int GetResponseCountByStatus(int responseType)// want to filter with Employee ID
        {
            return (from response in _db.EmployeeDriveResponse where response.ResponseType == responseType select response).Count();
        }

        public int GetResponseUtilizationByStatus(bool isUtilized)
        {
            return (from availability in _db.EmployeeAvailability where availability.IsInterviewScheduled == isUtilized select availability).Count();
        }
    }
}


