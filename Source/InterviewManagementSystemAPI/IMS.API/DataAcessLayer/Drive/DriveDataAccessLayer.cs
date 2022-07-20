using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using IMS.Models;
using IMS.Validations;
using System;
using System.Diagnostics;

namespace IMS.DataAccessLayer
{
    public class DriveDataAccessLayer : IDriveDataAccessLayer
    {
        private InterviewManagementSystemDbContext _db;

        private ILogger _logger;
        private IConfiguration _configuration;

        private readonly Stopwatch _stopwatch = new Stopwatch();
        private bool IsTracingEnabled;

        public DriveDataAccessLayer(ILogger<IDriveDataAccessLayer> logger, InterviewManagementSystemDbContext dbContext, IConfiguration configuration)
        {
            _logger = logger;
            _db = dbContext;
            _configuration = configuration;
            IsTracingEnabled = GetIsTraceEnabledFromConfiguration();
        }
        public bool AddDriveToDatabase(Drive drive)
        {
            _stopwatch.Start();
            DriveValidation.IsdriveValid(drive, _configuration);
            if (_db.Drives!.Any(d => d.Name == drive.Name && d.PoolId == drive.PoolId && d.IsCancelled == false && d.ToDate >= drive.FromDate)) throw new ValidationException("Drive Name already exists under this pool");
            try
            {
                 // _db.Drives!.Add(drive);
                //_db.SaveChanges();
                FillInitialResponseForDrive(drive.DriveId, drive.PoolId);
                return true;
            }
            catch (Exception addDriveToDatabaseException)
            {
                _logger.LogInformation($"Exception on Drive DAL : AddDriveToDatabase(Drive drive) : {addDriveToDatabaseException.Message} : {addDriveToDatabaseException.StackTrace}");
                return false;
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive DAL Time elapsed for AddDriveToDatabase(Drive drive)  :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }
        private void FillInitialResponseForDrive(int driveId, int poolId)
        {
            _stopwatch.Start();
            var employees = from employee in _db.PoolMembers where employee.PoolId == poolId && employee.IsActive==true select employee.EmployeeId;
            foreach (var employeeId in employees)
            {
                EmployeeDriveResponse initialResponse = new EmployeeDriveResponse()
                {
                    EmployeeId = employeeId,
                    DriveId = driveId,
                    ResponseType = 0
                };
                _db.EmployeeDriveResponse!.Add(initialResponse);
            }
            _db.SaveChanges();
        }
        public bool CancelDriveFromDatabase(int driveId, int tacId, string reason)
        {
            _stopwatch.Start();
            DriveValidation.IsCancelDriveValid(driveId, tacId, reason);
            try
            {
                Drive? drive = _db.Drives!.Find(driveId);
                Employee? tac = _db.Employees!.Find(tacId);
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
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive DAL Time elapsed for CancelDriveFromDatabase(int driveId, int tacId, string reason)  :{_stopwatch.ElapsedMilliseconds}ms");
            }

        }
        public List<Drive> GetTodaysDrivesByStatus(bool status)
        {
            _stopwatch.Start();
            try
            {
                return (from drive in _db.Drives!.Include(l => l.Location).Include(p => p.Pool).Include(d => d.Pool!.department) where drive.IsCancelled == status && (drive.FromDate.Date <= System.DateTime.Now.Date && drive.ToDate.Date >= System.DateTime.Now.Date) && drive.IsScheduled == true select drive).ToList();
            }
            catch (Exception getDrivesByStatusException)
            {
                _logger.LogInformation($"Exception on Drive DAL : GetDrivesByStatus(bool status) : {getDrivesByStatusException.Message} : {getDrivesByStatusException.StackTrace}");
                throw;
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive DAL Time elapsed for GetDrivesByStatus(bool status)  :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }
        public List<Drive> GetScheduledDrivesByStatus(bool status)
        {
            _stopwatch.Start();
            try
            {
                return (from drive in _db.Drives!.Include(l => l.Location).Include(p => p.Pool).Include(d => d.Pool!.department) where drive.IsCancelled == status && drive.FromDate.Date > System.DateTime.Now.Date && drive.IsScheduled == true select drive).ToList();
            }
            catch (Exception getDrivesByStatusException)
            {
                _logger.LogInformation($"Exception on Drive DAL : GetDrivesByStatus(bool status) : {getDrivesByStatusException.Message} : {getDrivesByStatusException.StackTrace}");
                throw;
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive DAL Time elapsed for GetDrivesByStatus(bool status)  :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }
        public List<Drive> GetUpcomingDrivesByStatus(bool status)
        {
            _stopwatch.Start();
            try
            {
                return (from drive in _db.Drives!.Include(l => l.Location).Include(p => p.Pool).Include(d => d.Pool!.department) where drive.IsCancelled == status && drive.FromDate.Date != System.DateTime.Now.Date && drive.IsScheduled == false select drive).ToList();
            }
            catch (Exception getDrivesByStatusException)
            {
                _logger.LogInformation($"Exception on Drive DAL : GetDrivesByStatus(bool status) : {getDrivesByStatusException.Message} : {getDrivesByStatusException.StackTrace}");
                throw;
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive DAL Time elapsed for GetDrivesByStatus(bool status)  :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }
        public List<Drive> GetNonCancelledDrivesByStatus(bool status, int tacId)
        {
            _stopwatch.Start();
            try
            {
                return (from drive in _db.Drives!.Include(l => l.Location).Include(p => p.Pool).Include(d => d.Pool!.department) where drive.IsCancelled == status && drive.AddedBy == tacId select drive).ToList();
            }
            catch (Exception getDrivesByStatusException)
            {
                _logger.LogInformation($"Exception on Drive DAL : GetDrivesByStatus(bool status) : {getDrivesByStatusException.Message} : {getDrivesByStatusException.StackTrace}");
                throw;
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive DAL Time elapsed for GetDrivesByStatus(bool status)  :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }
        public List<Drive> GetDriveInviteByStatus(bool status)
        {
            _stopwatch.Start();
            try
            {
                return (from drive in _db.Drives!.Include(l => l.Location).Include(p => p.Pool).Include(d => d.Pool!.department) where drive.IsCancelled == status && drive.FromDate.Date != System.DateTime.Now.Date && drive.IsScheduled == false select drive).OrderByDescending(x => x.FromDate).ToList();
            }
            catch (Exception getDrivesByStatusException)
            {
                _logger.LogInformation($"Exception on Drive DAL : GetDrivesByStatus(bool status) : {getDrivesByStatusException.Message} : {getDrivesByStatusException.StackTrace}");
                throw;
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive DAL Time elapsed for GetDrivesByStatus(bool status)  :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }


        public List<Drive> GetDrivesByStatus(bool status)
        {
            _stopwatch.Start();
            try
            {
                return (from drive in _db.Drives!.Include(l => l.Location).Include(p => p.Pool).Include(d => d.Pool!.department) where drive.IsCancelled == status select drive).ToList();
            }
            catch (Exception getDrivesByStatusException)
            {
                _logger.LogInformation($"Exception on Drive DAL : GetDrivesByStatus(bool status) : {getDrivesByStatusException.Message} : {getDrivesByStatusException.StackTrace}");
                throw;
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive DAL Time elapsed for GetDrivesByStatus(bool status)  :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }

        public Drive ViewDrive(int driveId)
        {
            _stopwatch.Start();
            DriveValidation.IsDriveIdValid(driveId);

            try
            {
                var viewDrive = _db.Drives!.Include(l => l.Location).Include(p => p.Pool).Include(d => d.Pool!.department).Where(d => d.DriveId == driveId).First();
                return viewDrive != null ? viewDrive : throw new ValidationException($"No drive is found with id : {driveId}");
            }
            catch (Exception isDriveIdValidException)
            {
                _logger.LogInformation($"Exception on Drive DAL : ViewDrive(int driveId) : {isDriveIdValidException.Message} : {isDriveIdValidException.StackTrace}");
                throw;
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive DAL Time elapsed for ViewDrive(int driveId)  :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }
        public List<Drive> ViewDrives(List<int> driveIds)
        {
            var test =(from drive in _db.Drives!.Include(l => l.Location).Include(p => p.Pool).Include(d => d.Pool!.department) where driveIds.Contains(drive.DriveId) select drive).ToList();
            return test;
        }

        //For Employee Drive Response Entity
        public bool AddResponseToDatabase(EmployeeDriveResponse userResponse)
        {
            _stopwatch.Start();
            Validations.EmployeeResponseValidation.IsResponseValid(userResponse);

            try
            {
                if (!_db.Drives!.Any(d => d.DriveId == userResponse.DriveId)) throw new ValidationException("Invalid Drive Id");
                if (!_db.Employees!.Any(d => d.EmployeeId == userResponse.EmployeeId)) throw new ValidationException("Invalid Employee Id");
                if (_db.EmployeeDriveResponse!.Any(r => r.DriveId == userResponse.DriveId && r.EmployeeId == userResponse.EmployeeId && r.ResponseType != 0)) throw new ValidationException("You have already responded to this drive");

                EmployeeDriveResponse newResponse = (from responses in _db.EmployeeDriveResponse where responses.EmployeeId == userResponse.EmployeeId && responses.DriveId == userResponse.DriveId select responses).First();
                newResponse.ResponseType = userResponse.ResponseType;

                _db.EmployeeDriveResponse!.Update(newResponse);
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
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive DAL Time elapsed for AddResponseToDatabase(EmployeeDriveResponse userResponse)  :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }

        public List<int> DriveIdForDriveInvites(int employeeId)
        {
            _stopwatch.Start();
            try
            {
                return (from response in _db.EmployeeDriveResponse where response.EmployeeId==employeeId && response.ResponseType==0 select response.DriveId).ToList();
            }
            catch (Exception DriveIdForDriveInvites)
            {
                _logger.LogInformation($"Exception on Drive DAL : IsResponded(int employeeId, int driveId) : {DriveIdForDriveInvites.Message} : {DriveIdForDriveInvites.StackTrace}");
                throw DriveIdForDriveInvites;
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive DAL Time elapsed for IsResponded(int employeeId, int driveId)  :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }
        public bool IsResponded(int employeeId, int driveId)
        {
            _stopwatch.Start();
            try
            {
                return _db.EmployeeDriveResponse!.Any(a => a.EmployeeId == employeeId && a.DriveId == driveId && a.ResponseType != 0);
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
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive DAL Time elapsed for IsResponded(int employeeId, int driveId)  :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }

        public List<int> GetEmployeePoolIdsFromDatabase(int employeeId)
        {
            _stopwatch.Start();
            Validations.EmployeeValidation.IsEmployeeIdValid(employeeId);
            try
            {
                if (!_db.Employees!.Any(e => e.EmployeeId == employeeId))
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
                throw;
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive DAL Time elapsed for GetEmployeePoolIdsFromDatabase(int employeeId)  :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }
        //For Employee Avalability Entity
        public bool SetTimeSlotToDatabase(EmployeeAvailability employeeAvailability)
        {
            _stopwatch.Start();
            Validations.EmployeeAvailabilityValidation.IsAvailabilityValid(employeeAvailability);
            try
            {

                if (_db.EmployeeAvailability!.Any(a => a.EmployeeId == employeeAvailability.EmployeeId
                    && a.DriveId == employeeAvailability.DriveId
                    && a.InterviewDate == employeeAvailability.InterviewDate
                    && (employeeAvailability.From.TimeOfDay >= a.From.TimeOfDay && employeeAvailability.From.TimeOfDay <= a.To.TimeOfDay
                    || employeeAvailability.To.TimeOfDay >= a.From.TimeOfDay && employeeAvailability.To.TimeOfDay <= a.To.TimeOfDay)
                    ))
                    throw new ValidationException("You have already given your availability in same timing!");
                if (_db.EmployeeDriveResponse!.Any(r => r.EmployeeId == employeeAvailability.EmployeeId && r.DriveId == employeeAvailability.DriveId && r.ResponseType == 2))
                    throw new ValidationException("You Cannot Give Availability Because You Have Denied The Drive Invite");
                if (!_db.Drives!.Any(d => d.DriveId == employeeAvailability.DriveId && d.FromDate.Date <= employeeAvailability.InterviewDate.Date && d.ToDate.Date >= employeeAvailability.InterviewDate.Date))
                    throw new ValidationException("Interview Date Is Not Between Drives Date Range, Not Valid");
                if ((employeeAvailability.To - employeeAvailability.From).TotalMinutes != _db.Drives!.Find(employeeAvailability.DriveId)?.SlotTiming)
                    throw new ValidationException("Interview Slot Timing Does Not Match With Drive Slot Period");


                _db.EmployeeAvailability!.Add(employeeAvailability);
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
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive DAL Time elapsed for SetTimeSlotToDatabase(EmployeeAvailability employeeAvailability)  :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }
        public List<EmployeeAvailability> ViewAvailability(int employeeId, int driveId)
        {
            _stopwatch.Start();
            try
            {
                return (from availability in _db.EmployeeAvailability!.Include(d => d.Drive) where availability.EmployeeId == employeeId && availability.DriveId == driveId select availability).ToList();
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Exception on Drive DAL : ViewInterviewsByStatus(bool status) : {exception.Message}");
                throw;
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive DAL Time elapsed for ViewAvailability(int employeeId, int driveId)  :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }
        public List<EmployeeAvailability> ViewTodayInterviewsByStatus(bool status, int employeeId)//int employeeId filter using auth token
        {
            _stopwatch.Start();
            try
            {
                return (from interview in _db.EmployeeAvailability!.Include(d => d.Drive).Include(L => L.Drive!.Location).Include(P => P.Drive!.Pool) where interview.IsInterviewCancelled == status && interview.Drive!.IsCancelled == false && interview.EmployeeId == employeeId && interview.InterviewDate.Date == System.DateTime.Now.Date && interview.IsInterviewScheduled == true select interview).ToList();
            }
            catch (Exception viewInterviewsByStatusException)
            {
                _logger.LogInformation($"Exception on Drive DAL : ViewInterviewsByStatus(bool status) : {viewInterviewsByStatusException.Message}");
                throw;
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive DAL Time elapsed for ViewInterviewsByStatus(bool status, int employeeId)  :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }
        public List<EmployeeAvailability> ViewScheduledInterviewsByStatus(bool status, int employeeId)//int employeeId filter using auth token
        {
            _stopwatch.Start();
            try
            {
                return (from interview in _db.EmployeeAvailability!.Include(d => d.Drive).Include(L => L.Drive!.Location).Include(P => P.Drive!.Pool) where interview.IsInterviewCancelled == status && interview.Drive!.IsCancelled == false && interview.EmployeeId == employeeId && interview.InterviewDate.Date > System.DateTime.Now.Date && interview.IsInterviewScheduled == true select interview).ToList();
            }
            catch (Exception viewInterviewsByStatusException)
            {
                _logger.LogInformation($"Exception on Drive DAL : ViewInterviewsByStatus(bool status) : {viewInterviewsByStatusException.Message}");
                throw;
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive DAL Time elapsed for ViewInterviewsByStatus(bool status, int employeeId)  :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }
        public List<EmployeeAvailability> ViewUpcomingInterviewsByStatus(bool status, int employeeId)//int employeeId filter using auth token
        {
            _stopwatch.Start();
            try
            {
                return (from interview in _db.EmployeeAvailability!.Include(d => d.Drive).Include(L => L.Drive!.Location).Include(P => P.Drive!.Pool) where interview.IsInterviewCancelled == status && interview.Drive!.IsCancelled == false && interview.Drive!.IsScheduled == false && interview.EmployeeId == employeeId && interview.InterviewDate.Date > System.DateTime.Now.Date && interview.IsInterviewScheduled == false select interview).ToList();
            }
            catch (Exception viewInterviewsByStatusException)
            {
                _logger.LogInformation($"Exception on Drive DAL : ViewInterviewsByStatus(bool status) : {viewInterviewsByStatusException.Message}");
                throw;
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive DAL Time elapsed for ViewInterviewsByStatus(bool status, int employeeId)  :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }
        public List<EmployeeAvailability> ViewInterviewsByStatus(bool status, int employeeId)//int employeeId filter using auth token
        {
            _stopwatch.Start();
            try
            {
                return (from interview in _db.EmployeeAvailability!.Include(d => d.Drive).Include(L => L.Drive!.Location).Include(P => P.Drive!.Pool) where interview.IsInterviewCancelled == status && interview.Drive!.IsCancelled == false && interview.EmployeeId == employeeId select interview).ToList();
            }
            catch (Exception viewInterviewsByStatusException)
            {
                _logger.LogInformation($"Exception on Drive DAL : ViewInterviewsByStatus(bool status) : {viewInterviewsByStatusException.Message}");
                throw;
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive DAL Time elapsed for ViewInterviewsByStatus(bool status, int employeeId)  :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }
        public List<EmployeeAvailability> ViewCancelledInterview(bool status, int employeeId)//int employeeId filter using auth token
        {
            try
            {
                return (from interview in _db.EmployeeAvailability!.Include(d => d.Drive).Include(L => L.Drive!.Location).Include(P => P.Drive!.Pool) where interview.IsInterviewCancelled == status && interview.Drive!.IsCancelled == false && interview.EmployeeId == employeeId && interview.InterviewDate.Date > System.DateTime.Now.Date && (interview.IsInterviewScheduled == true || interview.IsInterviewScheduled == false) select interview).ToList();
            }

            catch (Exception viewInterviewsByStatusException)
            {
                _logger.LogInformation($"Exception on Drive DAL : ViewInterviewsByStatus(bool status) : {viewInterviewsByStatusException.Message}");
                throw;
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive DAL Time elapsed for ViewCancelledInterview(bool status, int employeeId)  :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }

        public bool ScheduleInterview(int employeeAvailabilityId)
        {
            _stopwatch.Start();
            Validations.EmployeeAvailabilityValidation.IsAvailabilityIdValid(employeeAvailabilityId);

            try
            {
                var employeeAvailability = _db.EmployeeAvailability!.Find(employeeAvailabilityId);
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
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive DAL Time elapsed for ScheduleInterview(int employeeAvailabilityId)  :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }
        public bool CancelInterview(int employeeAvailabilityId, string cancellationReason, string? comments)
        {
            _stopwatch.Start();
            Validations.EmployeeAvailabilityValidation.IsAvailabilityIdValid(employeeAvailabilityId);
            try
            {
                var employeeAvailability = _db.EmployeeAvailability!.Find(employeeAvailabilityId);
                if (employeeAvailability == null) throw new ValidationException($"No Employe Availability is Found with employeeAvailabilityId : {employeeAvailabilityId}");

                employeeAvailability.IsInterviewCancelled = true;
                employeeAvailability.CancellationReason = cancellationReason;
                employeeAvailability.Comments = comments;
                _db.EmployeeAvailability.Update(employeeAvailability);
                _db.SaveChanges();
                return true;
            }
            catch (Exception cancelInterviewException)
            {
                _logger.LogInformation($"Exception on Drive DAL : CancelInterview(int employeeAvailabilityId) : {cancelInterviewException.Message} : {cancelInterviewException.StackTrace}");
                return false;
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive DAL Time elapsed for CancelInterview(int employeeAvailabilityId, string cancellationReason, string? comments)  :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }
        public List<EmployeeAvailability> ViewAvailableMembersForDrive(int driveId)
        {
            _stopwatch.Start();
            Validations.DriveValidation.IsDriveIdValid(driveId);
            try
            {
                if (_db.Drives!.Find(driveId) == null) throw new ValidationException($"No Drive is Found with driveId : {driveId}");
                return (from availability in _db.EmployeeAvailability!.Include(e => e.Employee).Include(r => r.Employee!.Role).Include(d => d.Employee!.Department) where availability.DriveId == driveId && availability.IsInterviewScheduled == false && availability.IsInterviewCancelled == false select availability).ToList();
            }
            catch (Exception viewAvailableMembersForDriveException)
            {
                _logger.LogInformation($"Exception on Drive DAL : ViewAvailableMembersForDrive(int driveId) : {viewAvailableMembersForDriveException.Message} : {viewAvailableMembersForDriveException.StackTrace}");
                throw;
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive DAL Time elapsed for ViewAvailableMembersForDrive(int driveId)  :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }
        public List<Employee> GetEmployee(int departmentId)
        {
            _stopwatch.Start();
            try
            {

                return (from employee in _db.Employees!.Include(d => d.Role) where employee.DepartmentId == departmentId && employee.IsActive == true select employee).ToList();

            }
            catch (Exception e)
            {
                _logger.LogError($"Drive DAL:GetEmployee(int departmentId):{e.Message} {e.StackTrace}");
                throw;
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive DAL Time elapsed for GetEmployee(int departmentId)  :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }

        public List<EmployeeDriveResponse> GetResponseDetailsByStatus(int responseType, int employeeId, DateTime fromDate, DateTime toDate)// want to filter with Employee ID
        {
            _stopwatch.Start();
            Validations.EmployeeResponseValidation.IsResponseTypeValid(responseType);
            try
            {
                return (from response in _db.EmployeeDriveResponse!.Include("Drive").Include("Drive.Pool").Include("Drive.Location") where response.EmployeeId == employeeId && response.ResponseType == responseType && ((fromDate.Date >= response.Drive!.FromDate.Date && fromDate.Date <= response.Drive!.ToDate.Date  ) || (toDate.Date >= response.Drive!.FromDate.Date && toDate.Date <= response.Drive!.ToDate.Date  )) select response).ToList();
            }
            catch (Exception getResponseCountByStatusException)
            {
                _logger.LogInformation($"Exception on Drive DAL : GetResponseCountByStatus(int responseType) : {getResponseCountByStatusException.Message} : {getResponseCountByStatusException.StackTrace}");
                throw;
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive DAL Time elapsed for GetResponseDetailsByStatus(int responseType, int employeeId, DateTime fromDate, DateTime toDate)  :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }

        public List<EmployeeAvailability> GetResponseUtilizationByStatus(bool isUtilized, int employeeId)
        {
            _stopwatch.Start();
            try
            {
                return (from availability in _db.EmployeeAvailability!.Include("Drive").Include("Drive.Pool").Include("Drive.Location") where availability.IsInterviewScheduled == isUtilized && availability.EmployeeId == employeeId select availability).ToList();
            }
            catch (Exception getResponseUtilizationByStatusException)
            {
                _logger.LogInformation($"Exception on Drive DAL : GetResponseUtilizationByStatus(bool isUtilized) : {getResponseUtilizationByStatusException.Message} : {getResponseUtilizationByStatusException.StackTrace}");
                throw;
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive DAL Time elapsed for GetResponseUtilizationByStatus(bool isUtilized, int employeeId)  :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }
        public List<EmployeeAvailability> GetSlotAvailabilityGiven(int employeeId)
        {
            try
            {
                return (from availability in _db.EmployeeAvailability!.Include("Drive").Include("Drive.Pool").Include("Drive.Location") where availability.EmployeeId == employeeId select availability).ToList();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public object GetDefaulters(int poolId)
        {
            _stopwatch.Start();
            try
            {
                var poolMembers = (from members in _db.PoolMembers where members.PoolId == poolId && members.IsActive == true select members.EmployeeId).ToList();
                List<object> DefaultersList = new List<object>();
                foreach (var members in poolMembers)
                {
                    object employeeId = IsDefaulter(members, poolId);
                    if (employeeId != null)
                        DefaultersList.Add(employeeId);
                }
                return DefaultersList;
            }
            catch (Exception getDefaultersException)
            {
                _logger.LogInformation($"Exception on Drive DAL : GetDefaulters(int poolId) : {getDefaultersException.Message} : {getDefaultersException.StackTrace}");
                throw;
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive DAL Time elapsed for GetDefaulters(int poolId)  :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }
        private object IsDefaulter(int employeeId, int poolId)
        {
            _stopwatch.Start();
            try
            {
                var Drives = (from employee in _db.EmployeeAvailability!.Include(e => e.Drive) where employee.EmployeeId == employeeId && employee.Drive!.PoolId == poolId && employee.IsInterviewScheduled == true && employee.IsInterviewCancelled == false && employee.InterviewDate >= System.DateTime.Now.AddMonths(-1) && employee.InterviewDate <= System.DateTime.Now select employee.InterviewDate).ToList();
                Dictionary<string, int> AttendedDriveCount = new Dictionary<string, int>();
                AttendedDriveCount.Add("WeekdaysCount", 0);
                AttendedDriveCount.Add("WeekendCount", 0);
                foreach (var date in Drives)
                {
                    if (date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday)
                        AttendedDriveCount["WeekendCount"] += 1;
                    else
                        AttendedDriveCount["WeekdaysCount"] += 1;
                }
                if (AttendedDriveCount["WeekendCount"] <= 1 || AttendedDriveCount["WeekdaysCount"] <= 1)
                {
                    var employee = (from employees in _db.Employees!.Include(e => e.Role) where employees.EmployeeId == employeeId select employees)
                    .Select(employee => new
                    {
                        EmployeeId = employee.EmployeeId,
                        EmployeeAceNumber = employee.EmployeeAceNumber,
                        EmployeeName = employee.Name,
                        EmployeeRole = employee.Role!.RoleName
                    });
                    return employee;
                }
                return null!;
            }
            catch (Exception isDefaulterException)
            {
                _logger.LogInformation($"Exception on Drive DAL : isDefaulterException(int employeeId, int poolId) : {isDefaulterException.Message} : {isDefaulterException.StackTrace}");
                throw;
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive DAL Time elapsed for IsDefaulter(int employeeId,int poolId)  :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }

        public List<EmployeeDriveResponse> GetDriveResponse(int driveId)
        {
            _stopwatch.Start();
            DriveValidation.IsDriveIdValid(driveId);
            bool isDriveIdExist = _db.Drives!.Any(x => x.DriveId == driveId);
            if (!isDriveIdExist)
            {
                throw new ValidationException("Drive not found wwith given drive Id");
            }
            try
            {
                return (from driveResponse in _db.EmployeeDriveResponse!.Include(e => e.Employee) where driveResponse.DriveId == driveId select driveResponse).ToList();
            }
            catch (Exception GetDriveResponseException)
            {
                _logger.LogInformation($"Exception on Drive DAL : GetDriveResponse(int driveId) : {GetDriveResponseException.Message} : {GetDriveResponseException.StackTrace}");
                throw;
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive DAL Time elapsed for GetDriveResponse(int driveId)  :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }
        public int GetUtilizationCountByStatus(int driveId, int employeeId, bool status)
        {
            _stopwatch.Start();
            DriveValidation.IsDriveIdValid(driveId);
            bool isDriveIdExist = _db.Drives!.Any(x => x.DriveId == driveId);
            if (!isDriveIdExist)
            {
                throw new ValidationException("Drive not found wwith given drive Id");
            }
            try
            {
                return (from availability in _db.EmployeeAvailability where availability.DriveId == driveId where availability.EmployeeId == employeeId && availability.IsInterviewScheduled == status && availability.IsInterviewCancelled == false select availability).Count();
            }
            catch (Exception GetDriveResponseException)
            {
                _logger.LogInformation($"Exception on Drive DAL : GetDriveResponse(int driveId) : {GetDriveResponseException.Message} : {GetDriveResponseException.StackTrace}");
                throw;
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive DAL Time elapsed for GetDriveResponse(int driveId)  :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }
        public int GetCancelledInterviewCount(int driveId, int employeeId)
        {
            _stopwatch.Start();
            DriveValidation.IsDriveIdValid(driveId);
            bool isDriveIdExist = _db.Drives!.Any(x => x.DriveId == driveId);
            if (!isDriveIdExist)
            {
                throw new ValidationException("Drive not found wwith given drive Id");
            }
            try
            {
                return (from availability in _db.EmployeeAvailability where availability.DriveId == driveId where availability.EmployeeId == employeeId && availability.IsInterviewCancelled == true select availability).Count();
            }
            catch (Exception GetDriveResponseException)
            {
                _logger.LogInformation($"Exception on Drive DAL : GetDriveResponse(int driveId) : {GetDriveResponseException.Message} : {GetDriveResponseException.StackTrace}");
                throw;
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive DAL Time elapsed for GetDriveResponse(int driveId)  :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }

        public Object GetDrivesForCurrentUser(int departmentId)
        {
            _stopwatch.Start();
            DepartmentValidation.IsDepartmentIdValid(departmentId);
            bool isDepartmentIdExist = _db.Departments!.Any(x => x.DepartmentId == departmentId);
            if (!isDepartmentIdExist)
            {
                throw new ValidationException("Department not found wwith given department Id");
            }
            try
            {
                return (from drive in _db.Drives where drive.DepartmentId == departmentId select drive).Select(
                    drive => new
                    {
                        driveId = drive.DriveId,
                        driveName = drive.Name
                    }
                ).ToList();
            }
            catch (ValidationException exception)
            {

                throw exception;
            }
            catch (Exception exception)
            {
                _logger.LogError($"Drive DAL:GetDrivesForCurrentUser(int departmentId):{exception.Message} {exception.StackTrace}");
                throw;
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive DAL Time elapsed for GetDrivesForCurrentUser(int departmentId)  :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }
        public bool GetIsTraceEnabledFromConfiguration()
        {
            try
            {
                var IsTracingEnabled = _configuration["Tracing:IsEnabled"];
                return IsTracingEnabled != null ? Convert.ToBoolean(IsTracingEnabled) : false;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Drive DAL", "GetIsTraceEnabledFromConfiguration()", exception);
                return false;

            }
        }
    }
}


