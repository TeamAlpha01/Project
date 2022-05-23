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
            foreach (var drive in drives)
            {
                DateTime addedDate = (DateTime)drive.AddedOn;
                if (DateTime.Now >= addedDate.AddDays(5))
                {
                    drive.IsScheduled = true;
                    _db.Drives.Update(drive);
                    _db.SaveChanges();
                }
            }
        }
        public bool AddDriveToDatabase(Drive drive)
        {
            DriveValidation.IsdriveValid(drive);
            if (_db.Drives.Any(d => d.Name == drive.Name && d.PoolId == drive.PoolId && d.IsCancelled == false && d.ToDate >= drive.FromDate)) throw new ValidationException("Drive Name already exists under this pool");
            try
            {
                _db.Drives.Add(drive);
                _db.SaveChanges();
                FillInitialResponseForDrive(drive.DriveId, drive.PoolId);
                return true;
            }
            catch (Exception addDriveToDatabaseException)
            {
                _logger.LogInformation($"Exception on Drive DAL : AddDriveToDatabase(Drive drive) : {addDriveToDatabaseException.Message} : {addDriveToDatabaseException.StackTrace}");
                return false;
            }
        }
        private void FillInitialResponseForDrive(int driveId, int poolId)
        {
            var employees = from employee in _db.PoolMembers where employee.PoolId == poolId select employee.EmployeeId;
            foreach (var employeeId in employees)
            {
                EmployeeDriveResponse initialResponse = new EmployeeDriveResponse()
                {
                    EmployeeId = employeeId,
                    DriveId = driveId,
                    ResponseType = 0
                };
                _db.EmployeeDriveResponse.Add(initialResponse);
            }
            _db.SaveChanges();
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

        // public Drive ViewDrive(int driveId)
        // {
        //     DriveValidation.IsDriveIdValid(driveId);

        //     try
        //     {
        //         var viewDrive = _db.Drives.Find(driveId);    ///use include method
        //         //(from drive in _db.Drives where drive.DriveId == driveId select drive).First()
        //         return viewDrive != null ? viewDrive : throw new ValidationException($"No drive is found with id : {driveId}");
        //     }
        //     catch (Exception isDriveIdValidException)
        //     {
        //         _logger.LogInformation($"Exception on Drive DAL : ViewDrive(int driveId) : {isDriveIdValidException.Message} : {isDriveIdValidException.StackTrace}");
        //         throw isDriveIdValidException;
        //     }
        // }



        //For Employee Drive Response Entity
        public bool AddResponseToDatabase(EmployeeDriveResponse userResponse)
        {
            Validations.EmployeeResponseValidation.IsResponseValid(userResponse);

            try
            {
                if (!_db.Drives.Any(d => d.DriveId == userResponse.DriveId)) throw new ValidationException("Invalid Drive Id");
                if (!_db.Employees.Any(d => d.EmployeeId == userResponse.EmployeeId)) throw new ValidationException("Invalid Employee Id");
                if (_db.EmployeeDriveResponse.Any(r => r.DriveId == userResponse.DriveId && r.EmployeeId == userResponse.EmployeeId && r.ResponseType!=0)) throw new ValidationException("You have already responded to this drive");

                EmployeeDriveResponse newResponse = (from responses in _db.EmployeeDriveResponse where responses.EmployeeId==userResponse.EmployeeId && responses.DriveId == userResponse.DriveId select responses).First();
                newResponse.ResponseType=userResponse.ResponseType;
                
                _db.EmployeeDriveResponse.Update(newResponse);
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

        public bool IsResponded(int employeeId, int driveId)
        {
            try
            {
                return _db.EmployeeDriveResponse.Any(a => a.EmployeeId == employeeId && a.DriveId == driveId);
            }
            catch (ValidationException IsRespondedNotValid)
            {
                _logger.LogInformation($"ValidationException on Drive DAL :  IsResponded(int employeeId, int driveId) : {IsRespondedNotValid.Message} : {IsRespondedNotValid.StackTrace}");
                throw IsRespondedNotValid;
            }
            catch (Exception IsRespondedException)
            {
                _logger.LogInformation($"Exception on Drive DAL : IsResponded(int employeeId, int driveId) : {IsRespondedException.Message} : {IsRespondedException.StackTrace}");
                return false;
            }
        }

        public List<int> GetEmployeePoolIdsFromDatabase(int employeeId)
        {
            Validations.EmployeeValidation.IsEmployeeIdValid(employeeId);
            try
            {
                if (!_db.Employees.Any(e => e.EmployeeId == employeeId))
                    throw new ValidationException($"No Employee Is Found with the id :{employeeId}");

                return (from poolMember in _db.PoolMembers where poolMember.EmployeeId == employeeId select poolMember.PoolId).ToList();
            }
            catch (ValidationException getEmployeePoolIdsFromDatabaseNotValid)
            {
                _logger.LogInformation($"ValidationException on Drive DAL :  GetEmployeePoolIdsFromDatabase(int employeeId) : {getEmployeePoolIdsFromDatabaseNotValid.Message} : {getEmployeePoolIdsFromDatabaseNotValid.StackTrace}");
                throw getEmployeePoolIdsFromDatabaseNotValid;
            }
            catch (Exception getEmployeePoolIdsFromDatabaseException)
            {
                _logger.LogInformation($"Exception on Drive DAL : GetEmployeePoolIdsFromDatabase(int employeeId) : {getEmployeePoolIdsFromDatabaseException.Message} : {getEmployeePoolIdsFromDatabaseException.StackTrace}");
                throw getEmployeePoolIdsFromDatabaseException;
            }
        }

        // public bool UpdateResponseToDatabase(EmployeeDriveResponse response)
        // {
        //     Validations.EmployeeResponseValidation.IsResponseValid(response);

        //     try
        //     {
        //         if (!_db.Drives.Any(d => d.DriveId == response.DriveId)) throw new ValidationException("Invalid Drive Id");
        //         if (!_db.Employees.Any(d => d.EmployeeId == response.EmployeeId)) throw new ValidationException("Invalid Employee Id");
        //         if (!_db.EmployeeDriveResponse.Any(r => r.DriveId == response.DriveId && r.EmployeeId == response.EmployeeId)) throw new ValidationException("No Response Found! Invalid update");


        //         var EmployeeResponse = (from responses in _db.EmployeeDriveResponse where responses.EmployeeId == response.EmployeeId && responses.DriveId == response.DriveId select responses).First();

        //         if (EmployeeResponse == null) throw new ValidationException("no response is found with given employee id and drive id");

        //         EmployeeResponse.ResponseType = response.ResponseType;
        //         _db.EmployeeDriveResponse.Update(EmployeeResponse);
        //         _db.SaveChanges();
        //         return true;
        //     }
        //     catch (ValidationException updateResponseToDatabaseNotValid)
        //     {
        //         _logger.LogInformation($"ValidationException on Drive DAL :  AddResponseToDatabase(EmployeeDriveResponse response) : {updateResponseToDatabaseNotValid.Message} : {updateResponseToDatabaseNotValid.StackTrace}");
        //         throw updateResponseToDatabaseNotValid;
        //     }
        //     catch (Exception updateResponseToDatabaseException)
        //     {
        //         _logger.LogInformation($"Exception on Drive DAL : UpdateResponseToDatabase(int employeeId, int driveId, int responseType) : {updateResponseToDatabaseException.Message} : {updateResponseToDatabaseException.StackTrace}");
        //         return false;
        //     }
        // }

        //For Employee Avalability Entity
        public bool SetTimeSlotToDatabase(EmployeeAvailability employeeAvailability)
        {

            //employeeAvailability validation
            try
            {
                if (_db.EmployeeAvailability.Any(a => a.EmployeeId == employeeAvailability.EmployeeId && a.DriveId == employeeAvailability.DriveId && a.InterviewDate == employeeAvailability.InterviewDate && a.To.TimeOfDay <= employeeAvailability.From.TimeOfDay)) //DateTime.Parse(a.ToTime).TimeOfDay<=DateTime.Parse(employeeAvailability.FromTime).TimeOfDay
                    throw new ValidationException("You have already given your availability in same timing!");


                _db.EmployeeAvailability.Add(employeeAvailability);
                _db.SaveChanges();
                return true;
            }
            catch (ValidationException setTimeSlotNotValid)
            {
                _logger.LogInformation($"Validation Exception on Drive DAL : SetTimeSlotToDatabase(EmployeeAvailability employeeAvailability) : {setTimeSlotNotValid.Message} : {setTimeSlotNotValid.StackTrace}");
                throw setTimeSlotNotValid;
            }
            catch (Exception setTimeSlotToDatabaseException)
            {
                _logger.LogInformation($"Exception on Drive DAL : SetTimeSlotToDatabase(EmployeeAvailability employeeAvailability) : {setTimeSlotToDatabaseException.Message} : {setTimeSlotToDatabaseException.StackTrace}");
                return false;
            }
        }
        public List<EmployeeAvailability> ViewInterviewsByStatus(bool status, int employeeId)//int employeeId filter using auth token
        {
            try
            {
                return (from interview in _db.EmployeeAvailability.Include(d => d.Drive).Include(L => L.Drive.Location).Include(P => P.Drive.Pool) where interview.IsInterviewCancelled == status && interview.Drive.IsCancelled == false && interview.EmployeeId == employeeId select interview).ToList();
            }
            catch (Exception viewInterviewsByStatusException)
            {
                _logger.LogInformation($"Exception on Drive DAL : ViewInterviewsByStatus(bool status) : {viewInterviewsByStatusException.Message}");
                throw viewInterviewsByStatusException;
            }
        }

        public bool ScheduleInterview(int employeeAvailabilityId)
        {
            Validations.EmployeeAvailabilityValidation.IsAvailabilityIdValid(employeeAvailabilityId);

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
            Validations.EmployeeAvailabilityValidation.IsAvailabilityIdValid(employeeAvailabilityId);
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
            Validations.DriveValidation.IsDriveIdValid(driveId);
            try
            {
                if (_db.Drives.Find(driveId) == null) throw new ValidationException($"No Drive is Found with driveId : {driveId}");
                return (from availability in _db.EmployeeAvailability.Include(e => e.Employee).Include(r => r.Employee.Role).Include(d => d.Employee.Department) where availability.DriveId == driveId && availability.IsInterviewScheduled == false select availability).ToList();
            }
            catch (Exception viewAvailableMembersForDriveException)
            {
                _logger.LogInformation($"Exception on Drive DAL : ViewAvailableMembersForDrive(int driveId) : {viewAvailableMembersForDriveException.Message} : {viewAvailableMembersForDriveException.StackTrace}");
                throw viewAvailableMembersForDriveException;
            }
        }
        public int GetResponseCountByStatus(int responseType, int employeeId)// want to filter with Employee ID
        {
            Validations.EmployeeResponseValidation.IsResponseTypeValid(responseType);
            try
            {
                return (from response in _db.EmployeeDriveResponse where response.ResponseType == responseType && response.EmployeeId == employeeId select response).Count();
            }
            catch (Exception getResponseCountByStatusException)
            {
                _logger.LogInformation($"Exception on Drive DAL : GetResponseCountByStatus(int responseType) : {getResponseCountByStatusException.Message} : {getResponseCountByStatusException.StackTrace}");
                throw getResponseCountByStatusException;
            }
        }

        public int GetResponseUtilizationByStatus(bool isUtilized, int employeeId)
        {
            try
            {
                return (from availability in _db.EmployeeAvailability.Include(d => d.Drive) where availability.IsInterviewScheduled == isUtilized && availability.EmployeeId == employeeId && availability.Drive.IsScheduled == true select availability).Count();
            }
            catch (Exception getResponseUtilizationByStatusException)
            {
                _logger.LogInformation($"Exception on Drive DAL : GetResponseUtilizationByStatus(bool isUtilized) : {getResponseUtilizationByStatusException.Message} : {getResponseUtilizationByStatusException.StackTrace}");
                throw getResponseUtilizationByStatusException;
            }
        }
    }
}


