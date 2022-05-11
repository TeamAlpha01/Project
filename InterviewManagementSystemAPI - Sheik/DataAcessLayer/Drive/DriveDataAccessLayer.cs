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
            catch (Exception addDriveToDatabaseException)
            {
                _logger.LogInformation($"Exception on Drive DAL : AddDriveToDatabase(Drive drive) : {addDriveToDatabaseException.Message} : {addDriveToDatabaseException.StackTrace}");
                return false;
            }
        }
        public bool CancelDriveFromDatabase(int driveId, int tacId, string reason)
        {
            DriveValidation.IsCancelDriveValid(driveId, tacId, reason);

            try
            {
                Drive? drive = _db.Drives.Find(driveId);

                if (drive == null) throw new ValidationException($"No drive is found with given drive id : {driveId}");

                drive.IsCancelled = true;
                drive.CancelReason = reason;
                drive.UpdatedBy = tacId;

                _db.Drives.Update(drive);
                _db.SaveChanges();
                return true;
            }
            catch (Exception cancelDriveFromDatabaseException)
            {
                _logger.LogInformation($"Exception on Drive DAL : CancelDriveFromDatabase(int driveId, int tacId, string reason) : {cancelDriveFromDatabaseException.Message} : {cancelDriveFromDatabaseException.StackTrace}");
                return false;
            }

        }

        public List<Drive> GetDrivesByStatus(bool status)
        {
            try
            {
                return (from drive in _db.Drives.Include(l=>l.Location).Include(p=>p.Pool).Include(d=>d.Pool.department) where drive.IsCancelled == status select drive).ToList();
            }
            catch (Exception getDrivesByStatusException)
            {
                _logger.LogInformation($"Exception on Drive DAL : GetDrivesByStatus(bool status) : {getDrivesByStatusException.Message} : {getDrivesByStatusException.StackTrace}");
                throw getDrivesByStatusException;
            }
        }

        public Drive ViewDrive(int driveId)
        {
            DriveValidation.IsDriveIdValid(driveId);

            try
            {
                var viewDrive = _db.Drives.Find(driveId);    ///use include method
                //(from drive in _db.Drives where drive.DriveId == driveId select drive).First()
                return viewDrive != null ? viewDrive : throw new ValidationException("No drive is found");
            }
            catch (Exception isDriveIdValidException)
            {
                _logger.LogInformation($"Exception on Drive DAL : ViewDrive(int driveId) : {isDriveIdValidException.Message} : {isDriveIdValidException.StackTrace}");
                throw isDriveIdValidException;
            }
        }



        //For Employee Drive Response Entity
        public bool AddResponseToDatabase(EmployeeDriveResponse response)
        {
            //response validation Class

            try
            {
                _db.EmployeeDriveResponse.Add(response);
                _db.SaveChanges();
                return true;
            }
            catch (Exception addResponseToDatabaseException)
            {
                _logger.LogInformation($"Exception on Drive DAL : AddResponseToDatabase(EmployeeDriveResponse response) : {addResponseToDatabaseException.Message} : {addResponseToDatabaseException.StackTrace}");
                return false;
            }
        }


        public bool UpdateResponseToDatabase(int employeeId, int driveId, int responseType)
        {
            //validation

            try
            {
                var EmployeeResponse = (from response in _db.EmployeeDriveResponse where response.EmployeeId == employeeId && response.DriveId == driveId select response).First();

                if (EmployeeResponse == null) throw new ValidationException("no response is found with given employee id and drive id");

                EmployeeResponse.ResponseType = responseType;
                _db.EmployeeDriveResponse.Update(EmployeeResponse);
                _db.SaveChanges();
                return true;
            }
            catch (Exception updateResponseToDatabaseException)
            {
                _logger.LogInformation($"Exception on Drive DAL : UpdateResponseToDatabase(int employeeId, int driveId, int responseType) : {updateResponseToDatabaseException.Message} : {updateResponseToDatabaseException.StackTrace}");
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
                _db.SaveChanges();
                return true;
            }
            catch (Exception setTimeSlotToDatabaseException)
            {
                _logger.LogInformation($"Exception on Drive DAL : SetTimeSlotToDatabase(EmployeeAvailability employeeAvailability) : {setTimeSlotToDatabaseException.Message} : {setTimeSlotToDatabaseException.StackTrace}");
                return false;
            }
        }
        public List<EmployeeAvailability> ViewInterviewsByStatus(bool status)//int employeeId
        {
            try
            {
                return (from interview in _db.EmployeeAvailability.Include(d => d.Drive).Include(L => L.Drive.Location).Include(P => P.Drive.Pool) where interview.IsInterviewCancelled == status && interview.Drive.IsCancelled == false select interview).ToList();
            }
            catch (Exception viewInterviewsByStatusException)
            {
                _logger.LogInformation($"Exception on Drive DAL : ViewInterviewsByStatus(bool status) : {viewInterviewsByStatusException.Message}");
                throw viewInterviewsByStatusException;
            }
        }

        public bool ScheduleInterview(int employeeAvailabilityId)
        {
            //validation

            try
            {
                var employeeAvailability = _db.EmployeeAvailability.Find(employeeAvailabilityId);
                if (employeeAvailability == null) throw new ValidationException($"No Employe Availability is Found with employeeAvailabilityId : {employeeAvailabilityId}");

                employeeAvailability.IsInterviewScheduled = true;
                _db.EmployeeAvailability.Update(employeeAvailability);
                _db.SaveChanges();
                return true;
            }
            catch (Exception scheduleInterviewException)
            {
                _logger.LogInformation($"Exception on Drive DAL : ScheduleInterview(int employeeAvailabilityId) : {scheduleInterviewException.Message} : {scheduleInterviewException.StackTrace}");
                return false;
            }
        }
        public bool CancelInterview(int employeeAvailabilityId)
        {
            //validation
            try
            {
                var employeeAvailability = _db.EmployeeAvailability.Find(employeeAvailabilityId);
                if (employeeAvailability == null) throw new ValidationException($"No Employe Availability is Found with employeeAvailabilityId : {employeeAvailabilityId}");

                employeeAvailability.IsInterviewCancelled = true;
                _db.EmployeeAvailability.Update(employeeAvailability);
                _db.SaveChanges();
                return true;
            }
            catch (Exception cancelInterviewException)
            {
                _logger.LogInformation($"Exception on Drive DAL : CancelInterview(int employeeAvailabilityId) : {cancelInterviewException.Message} : {cancelInterviewException.StackTrace}");
                return false;
            }
        }
        public List<EmployeeAvailability> ViewAvailableMembersForDrive(int driveId)
        {
            try
            {
                if (_db.Drives.Find(driveId) == null) throw new ValidationException($"No Drive is Found with driveId : {driveId}");
                return (from availability in _db.EmployeeAvailability.Include(e => e.Employee) where availability.DriveId == driveId && availability.IsInterviewScheduled == false select availability).ToList();
            }
            catch (Exception viewAvailableMembersForDriveException)
            {
                _logger.LogInformation($"Exception on Drive DAL : ViewAvailableMembersForDrive(int driveId) : {viewAvailableMembersForDriveException.Message} : {viewAvailableMembersForDriveException.StackTrace}");
                throw viewAvailableMembersForDriveException;
            }
        }
        public int GetResponseCountByStatus(int responseType)// want to filter with Employee ID
        {
            try
            {
                return (from response in _db.EmployeeDriveResponse where response.ResponseType == responseType select response).Count();
            }
            catch (Exception getResponseCountByStatusException)
            {
                _logger.LogInformation($"Exception on Drive DAL : GetResponseCountByStatus(int responseType) : {getResponseCountByStatusException.Message} : {getResponseCountByStatusException.StackTrace}");
                throw getResponseCountByStatusException;
            }
        }

        public int GetResponseUtilizationByStatus(bool isUtilized)
        {
            try
            {
                return (from availability in _db.EmployeeAvailability where availability.IsInterviewScheduled == isUtilized select availability).Count();
            }
            catch (Exception getResponseUtilizationByStatusException)
            {
                _logger.LogInformation($"Exception on Drive DAL : GetResponseUtilizationByStatus(bool isUtilized) : {getResponseUtilizationByStatusException.Message} : {getResponseUtilizationByStatusException.StackTrace}");
                throw getResponseUtilizationByStatusException;
            }
        }
    }
}


