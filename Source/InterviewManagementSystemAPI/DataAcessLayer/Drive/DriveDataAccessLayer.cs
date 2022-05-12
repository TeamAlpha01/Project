using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using IMS.Models;
using IMS.Validations;
using System;

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
        public void CloseDriveResponse()
        {
            var drives = _db.Drives.ToList();
            foreach (var d in drives)
            {
                var da = (DateTime)d.AddedOn;
                if (DateTime.Now >= da.AddDays(5))
                {
                    d.IsScheduled = true;
                    _db.Drives.Update(d);
                    _db.SaveChanges();
                }
            }

        }
        public bool AddDriveToDatabase(Drive drive)
        {
            DriveValidation.IsdriveValid(drive);
            if(_db.Drives.Any(d=>d.Name==drive.Name && d.PoolId==drive.PoolId))throw new ValidationException("Drive Name already exists under this pool");
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
                Employee? tac = _db.Employees.Find(tacId);
                if (drive == null) throw new ValidationException($"No drive is found with given drive id : {driveId}");
                if (tac == null) throw new ValidationException($"No employee is found with given tac id : {tacId}");
                if (drive.IsCancelled == true) throw new ValidationException($"drive is already cancelled : {driveId}");

                drive.IsCancelled = true;
                drive.CancelReason = reason;
                drive.UpdatedBy = tacId;

                _db.Drives.Update(drive);
                _db.SaveChanges();
                return true;
            }
            catch (ValidationException cancelDriveNotValid)
            {
                _logger.LogInformation($"ValidationException on Drive DAL : CancelDriveFromDatabase(int driveId, int tacId, string reason) : {cancelDriveNotValid.Message} : {cancelDriveNotValid.StackTrace}");
                throw cancelDriveNotValid;
            }
            catch (Exception cancelDriveFromDatabaseException)
            {
                _logger.LogInformation($"Exception on Drive DAL : CancelDriveFromDatabase(int driveId, int tacId, string reason) : {cancelDriveFromDatabaseException.Message} : {cancelDriveFromDatabaseException.StackTrace}");
                return false;
            }

        }

        public List<Drive> GetDrivesByStatus(bool status)
        {
            CloseDriveResponse();
            try
            {
                return (from drive in _db.Drives.Include(l => l.Location).Include(p => p.Pool).Include(d => d.Pool.department) where drive.IsCancelled == status select drive).ToList();
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
                return viewDrive != null ? viewDrive : throw new ValidationException($"No drive is found with id : {driveId}");
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
            Validation.EmployeeResponseValidation.IsResponseValid(response);

            try
            {
                if(_db.EmployeeDriveResponse.Any(r=>r.DriveId==response.DriveId && r.EmployeeId==response.EmployeeId)) throw new ValidationException("You have already responded to this drive");
                _db.EmployeeDriveResponse.Add(response);
                _db.SaveChanges();
                return true;
            }
            catch (ValidationException addResponseToDatabaseNotValid)
            {
                _logger.LogInformation($"ValidationException on Drive DAL :  AddResponseToDatabase(EmployeeDriveResponse response) : {addResponseToDatabaseNotValid.Message} : {addResponseToDatabaseNotValid.StackTrace}");
                throw addResponseToDatabaseNotValid;
            }
            catch (Exception addResponseToDatabaseException)
            {
                _logger.LogInformation($"Exception on Drive DAL : AddResponseToDatabase(EmployeeDriveResponse response) : {addResponseToDatabaseException.Message} : {addResponseToDatabaseException.StackTrace}");
                return false;
            }
        }


        public bool UpdateResponseToDatabase(EmployeeDriveResponse response)
        {
            Validation.EmployeeResponseValidation.IsResponseValid(response);

            try
            {
                var EmployeeResponse = (from responses in _db.EmployeeDriveResponse where responses.EmployeeId == response.EmployeeId && responses.DriveId == response.DriveId select response).First();

                if (EmployeeResponse == null) throw new ValidationException("no response is found with given employee id and drive id");

                EmployeeResponse.ResponseType = response.ResponseType;
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


