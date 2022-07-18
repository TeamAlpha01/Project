using IMS.Models;
using IMS.DataAccessLayer;
using System.ComponentModel.DataAnnotations;
using IMS.Validations;
using System.Diagnostics;

namespace IMS.Service
{
    public class DriveService : IDriveService
    {
        private IDriveDataAccessLayer _driveDataAccess;
        private ILogger _logger;
        private IConfiguration _configuration;
        
        private readonly Stopwatch _stopwatch = new Stopwatch();
        private bool IsTracingEnabled;

        public DriveService(ILogger<DriveService> logger, IDriveDataAccessLayer driveDataAccessLayer, IConfiguration configuration)
        {
            _logger = logger;
            _driveDataAccess = driveDataAccessLayer;
            _configuration = configuration;
            IsTracingEnabled = _driveDataAccess.GetIsTraceEnabledFromConfiguration();
        }

        public bool CreateDrive(Drive drive)
        {
            _stopwatch.Start();
            DriveValidation.IsdriveValid(drive, _configuration);
            try
            {
                return _driveDataAccess.AddDriveToDatabase(drive) ? true : false;
            }
            catch (ValidationException createDriveNotValid)
            {
                _logger.LogInformation($"Drive Service : CreateDrive() : {createDriveNotValid.Message} : {createDriveNotValid.StackTrace}");
                throw createDriveNotValid;
            }
            catch (Exception createDrivexception)
            {
                _logger.LogInformation($"Drive Service : CreateDrive() : {createDrivexception.Message} : {createDrivexception.StackTrace}");
                return false;
            }
            
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive Service Time elapsed for  CreateDrive(Drive drive) :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }
        public bool CancelDrive(int driveId, int tacId, string reason)
        {
            _stopwatch.Start();
            DriveValidation.IsCancelDriveValid(driveId, tacId, reason);

            try
            {
                return _driveDataAccess.CancelDriveFromDatabase(driveId, tacId, reason);
            }
            catch (ValidationException cancelDriveNotValid)
            {
                _logger.LogInformation($"Drive Service : CancelDrive() : {cancelDriveNotValid.Message} : {cancelDriveNotValid.StackTrace}");
                throw cancelDriveNotValid;
            }
            catch (Exception cancelDriveException)
            {
                _logger.LogInformation($"Drive Service : CancelDrive() : {cancelDriveException.Message} : {cancelDriveException.StackTrace}");
                return false;
            }
            
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive Service Time elapsed for  CancelDrive(int driveId, int tacId, string reason) :{_stopwatch.ElapsedMilliseconds}ms");
            }

        }

        public Object ViewTodayDrives()
        {
            _stopwatch.Start();
            try
            {
                return  _driveDataAccess.GetTodaysDrivesByStatus(false)
                .Select(d => new
                {
                    DriveId = d.DriveId,
                    DriveName = d.Name,
                    FromDate = d.FromDate.ToString("yyyy-MM-dd"),
                    ToDate = d.ToDate.ToString("yyyy-MM-dd"),
                    DriveDepartment = d.Pool!.department!.DepartmentName,
                    DriveLocation = d.Location!.LocationName,
                    DrivePool = d.Pool.PoolName,
                    DriveMode = Enum.GetName(typeof(UtilityService.Mode), d.ModeId)
                }
                );
            }
            catch (Exception viewTodayDrivesException)
            {
                _logger.LogInformation($"Drive Service : ViewTodayDrives() : {viewTodayDrivesException.Message} : {viewTodayDrivesException.StackTrace}");
                throw;
            }
            
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive Service Time elapsed for  ViewTodayDrives() :{_stopwatch.ElapsedMilliseconds}ms");
            }

        }

        public Object ViewScheduledDrives()
        {
            _stopwatch.Start();
            try
            {
                return _driveDataAccess.GetScheduledDrivesByStatus(false)
                .Select(d => new
                {
                    DriveId = d.DriveId,
                    DriveName = d.Name,
                    FromDate = d.FromDate.ToString("yyyy-MM-dd"),
                    ToDate = d.ToDate.ToString("yyyy-MM-dd"),
                    DriveDepartment = d.Pool!.department!.DepartmentName,
                    DriveLocation = d.Location!.LocationName,
                    DrivePool = d.Pool.PoolName,
                    DriveMode = Enum.GetName(typeof(UtilityService.Mode), d.ModeId)
                }
                );
            }
            catch (Exception viewScheduledDrivesException)
            {
                _logger.LogInformation($"Drive Service : ViewScheduledDrives() : {viewScheduledDrivesException.Message} : {viewScheduledDrivesException.StackTrace}");
                throw;
            }
            
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive Service Time elapsed for  ViewScheduledDrives() :{_stopwatch.ElapsedMilliseconds}ms");
            }

        }

        public Object ViewUpcomingDrives()
        {
            _stopwatch.Start();
            try
            {
                return  _driveDataAccess.GetUpcomingDrivesByStatus(false) 
                .Select(d => new
                {
                    DriveId = d.DriveId,
                    DriveName = d.Name,
                    FromDate = d.FromDate.ToString("yyyy-MM-dd"),
                    ToDate = d.ToDate.ToString("yyyy-MM-dd"),
                    DriveDepartment = d.Pool!.department!.DepartmentName,
                    DriveLocation = d.Location!.LocationName,

                    DrivePool = d.Pool.PoolName,
                    DriveMode = Enum.GetName(typeof(UtilityService.Mode), d.ModeId)
                }
                );
            }
            catch (Exception viewUpcommingDrivesException)
            {
                _logger.LogInformation($"Drive Service : ViewUpcommingDrives() : {viewUpcommingDrivesException.Message} : {viewUpcommingDrivesException.StackTrace}");
                throw;
            }
            
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive Service Time elapsed for  ViewUpcomingDrives() :{_stopwatch.ElapsedMilliseconds}ms");
            }

        }

        public Object ViewNonCancelledDrives(int tacId)
        {
            _stopwatch.Start();
            try
            {
                return _driveDataAccess.GetNonCancelledDrivesByStatus(false,tacId)
                .Select(d => new
                {
                    DriveId = d.DriveId,
                    DriveName = d.Name,
                    FromDate = d.FromDate.ToString("yyyy-MM-dd"),
                    ToDate = d.ToDate.ToString("yyyy-MM-dd"),
                    DriveDepartment = d.Pool!.department!.DepartmentName,
                    DriveLocation = d.Location!.LocationName,
                    DrivePool = d.Pool.PoolName,
                    DriveMode = Enum.GetName(typeof(UtilityService.Mode), d.ModeId)
                }
                );
            }
            catch (Exception viewAllScheduledDrivesException)
            {
                _logger.LogInformation($"Drive Service : ViewAllScheduledDrives() : {viewAllScheduledDrivesException.Message} : {viewAllScheduledDrivesException.StackTrace}");
                throw;
            }
            
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive Service Time elapsed for  ViewNonCancelledDrives(int tacId) :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }

        public Object ViewAllCancelledDrives(int tacId)
        {
            _stopwatch.Start();
            try
            {
                return  _driveDataAccess.GetNonCancelledDrivesByStatus(true,tacId)
                .Select(d => new
                {
                    DriveId = d.DriveId,
                    DriveName = d.Name,
                    FromDate = d.FromDate.ToString("yyyy-MM-dd"),
                    ToDate = d.ToDate.ToString("yyyy-MM-dd"),
                    DriveDepartment = d.Pool!.department!.DepartmentName,
                    DriveLocation = d.Location!.LocationName,
                    DrivePool = d.Pool.PoolName,
                    DriveMode = Enum.GetName(typeof(UtilityService.Mode), d.ModeId),
                    CancellationReason = d.CancelReason
                }
                );
            }
            catch (Exception viewAllCancelledDrivesException)
            {
                _logger.LogInformation($"Drive Service : ViewAllCancelledDrives() : {viewAllCancelledDrivesException.Message} : {viewAllCancelledDrivesException.StackTrace}");
                throw;
            }
            
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive Service Time elapsed for  ViewAllCancelledDrives(int tacId) :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }

        public Dictionary<string, int> ViewTACDashboard(int employeeId)
        {
            _stopwatch.Start();
            DriveValidation.IsEmployeeIdValid(employeeId);
            try
            {
                var DashboardCount = new Dictionary<string, int>();
                DashboardCount.Add("ScheduledDrives", DriveCountForTacByStatus(false, employeeId));
                DashboardCount.Add("CancelledDrives", DriveCountForTacByStatus(true, employeeId));
                return DashboardCount;
            }
            catch (Exception viewTACDashboardException)
            {
                _logger.LogInformation($"Drive Service : ViewDashboard() : {viewTACDashboardException.Message} : {viewTACDashboardException.StackTrace}");
                throw;
            }
            
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive Service Time elapsed for  ViewTACDashboard(int employeeId) :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }
        private int DriveCountForTacByStatus(bool status,int employeeId)
        {
            
            return  _driveDataAccess.GetNonCancelledDrivesByStatus(status,employeeId).Count();
           
        }

        public Object ViewDrive(int driveId)
        {
            _stopwatch.Start();
            DriveValidation.IsDriveIdValid(driveId);

            try

            {
                var drive = _driveDataAccess.ViewDrive(driveId);
                return new
                {
                    DriveId = drive.DriveId,
                    DriveName = drive.Name,
                    FromDate = drive.FromDate.ToString("yyyy-MM-dd"),
                    ToDate = drive.ToDate.ToString("yyyy-MM-dd"),
                    SlotTiming = drive.SlotTiming,
                    DriveDepartment = drive.Pool!.department!.DepartmentName,
                    DriveLocation = drive.Location!.LocationName,
                    DrivePool = drive.Pool.PoolName,

                    DriveMode = Enum.GetName(typeof(UtilityService.Mode), drive.ModeId)
                }
                ;
            }
            catch (ValidationException viewDriveNotValid)
            {
                _logger.LogInformation($"Drive Service : ViewDrive(int driveId) : {viewDriveNotValid.Message} : {viewDriveNotValid.StackTrace}");
                throw viewDriveNotValid;
            }
            catch (Exception viewDriveException)
            {
                _logger.LogInformation($"Drive Service : ViewDrive(int driveId) : {viewDriveException.Message} : {viewDriveException.StackTrace}");
                throw;
            }
            
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive Service Time elapsed for  ViewDrive(int driveId) :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }

        //For Employee Drive Response Entity
        public bool AddResponse(EmployeeDriveResponse response)
        {
            _stopwatch.Start();
            Validations.EmployeeResponseValidation.IsResponseValid(response);

            try
            {
                response.Drive = null;
                response.Employee = null;
                return _driveDataAccess.AddResponseToDatabase(response) ? true : false;
            }
            catch (ValidationException responseNotValid)
            {
                _logger.LogInformation($"EmployeeDriveResponse Service : AddResponse(EmployeeDriveResponse response) : {responseNotValid.Message}");
                throw responseNotValid;
            }
            catch (Exception viewDriveInvitesException)
            {
                _logger.LogInformation($"EmployeeDriveResponse Service : AddResponse(EmployeeDriveResponse response) : {viewDriveInvitesException.Message}");
                throw;
            }
            
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive Service Time elapsed for  AddResponse(EmployeeDriveResponse response) :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }

        // public bool UpdateResponse(EmployeeDriveResponse response)
        // {
        //     Validations.EmployeeResponseValidation.IsResponseValid(response);
        //     try
        //     {
        //         return _driveDataAccess.UpdateResponseToDatabase(response) ? true : false;
        //     }
        //     catch (ValidationException updateResponseNotValid)
        //     {
        //         _logger.LogInformation($"EmployeeDriveResponse Service : UpdateResponse(int employeeId, int driveId, int responseType) : {updateResponseNotValid.Message}");
        //         throw updateResponseNotValid;
        //     }
        //     catch (Exception exception)
        //     {
        //         _logger.LogInformation($"EmployeeDriveResponse Service : UpdateResponse(int employeeId, int driveId, int responseType) : {exception.Message}");
        //         return false;
        //     }
        // }
        public object ViewDriveInvites(int employeeId)
        {
            _stopwatch.Start();
            Validations.EmployeeValidation.IsEmployeeIdValid(employeeId);
            try
            {
                List<object> driveInvites = new List<object>();
                var employeePoolIds = GetEmployeePoolIds(employeeId);
                var upcomingDrives = _driveDataAccess.GetDriveInviteByStatus(false).
                Select(d => new
                {
                    DriveId = d.DriveId,
                    DriveName = d.Name,

                    FromDate = d.FromDate.ToString("yyyy-MM-dd"),
                    ToDate = d.ToDate.ToString("yyyy-MM-dd"),
                    DriveLocation = d.Location!.LocationName,
                    DrivePool = d.Pool!.PoolName,
                    DriveMode = Enum.GetName(typeof(UtilityService.Mode), d.ModeId),
                    PoolId = d.PoolId,
                    DriveTiming = d.SlotTiming
                }
                    );


                foreach (var drive in upcomingDrives)
                    if (employeePoolIds.Contains(drive.PoolId) && !_driveDataAccess.IsResponded(employeeId, drive.DriveId))
                        driveInvites.Add(drive);

                return driveInvites;
            }
            catch (ValidationException viewDriveInvitesNotValid)
            {
                _logger.LogInformation($"EmployeeDriveResponse Service : ViewDriveInvites(int employeeId) : {viewDriveInvitesNotValid.Message}");
                throw viewDriveInvitesNotValid;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"EmployeeDriveResponse Service : ViewDriveInvites(int employeeId) : {exception.Message}");
                throw;
            }
            
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive Service Time elapsed for  ViewDriveInvites(int employeeId) :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }
        private List<int> GetEmployeePoolIds(int employeeId)
        {
            _stopwatch.Start();
            Validations.EmployeeValidation.IsEmployeeIdValid(employeeId);
            try
            {
                return _driveDataAccess.GetEmployeePoolIdsFromDatabase(employeeId);
            }
            catch (ValidationException getEmployeePoolIdsNotValid)
            {
                _logger.LogInformation($"EmployeeDriveResponse Service :  GetEmployeePoolIds(int employeeId) : {getEmployeePoolIdsNotValid.Message}");
                throw getEmployeePoolIdsNotValid;
            }
            catch (Exception getEmployeePoolIdsException)
            {
                _logger.LogInformation($"EmployeeDriveResponse Service :  GetEmployeePoolIds(int employeeId) : {getEmployeePoolIdsException.Message}");
                throw;
            }
            
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive Service Time elapsed for  GetEmployeePoolIds(int employeeId) :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }

        //For Employee Availability Entity
        public bool SetTimeSlot(EmployeeAvailability employeeAvailability)
        {
            _stopwatch.Start();
            Validations.EmployeeAvailabilityValidation.IsAvailabilityValid(employeeAvailability);
            try
            {
                return _driveDataAccess.SetTimeSlotToDatabase(employeeAvailability);
            }
            catch (ValidationException setTimeSlotNotVlaid)
            {
                _logger.LogInformation($"Drive Service : SetTimeSlot(EmployeeAvailability employeeAvailability) : {setTimeSlotNotVlaid.Message} : {setTimeSlotNotVlaid.StackTrace}");
                throw setTimeSlotNotVlaid;
            }
            catch (Exception setTimeSlotException)
            {
                _logger.LogInformation($"Drive Service :SetTimeSlot(EmployeeAvailability employeeAvailability) : {setTimeSlotException.Message} : {setTimeSlotException.StackTrace}");
                return false;
            }
            
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive Service Time elapsed for  SetTimeSlot(EmployeeAvailability employeeAvailability) :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }
        public Object ViewAvailabilty(int employeeId, int driveId)
        {
            _stopwatch.Start();
            try
            {
                return _driveDataAccess.ViewAvailability(employeeId, driveId).Select(e => new
                {

                    DriveName = e.Drive!.Name,
                    Date = e.InterviewDate,
                    FromTime = e.From,
                    ToTime = e.To
                }
                );
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Drive Service : ViewAvailabilty(int employeeId, int driveId) : {exception.Message} : {exception.StackTrace}");
                throw;
            }
            
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive Service Time elapsed for  ViewAvailabilty(int employeeId, int driveId) :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }
        public Object ViewTodayInterviews(int employeeId)
        {
            _stopwatch.Start();
            try
            {
                return _driveDataAccess.ViewTodayInterviewsByStatus(false, employeeId) 
                .Select(e => new
                {
                    EmployeeAvailabilityId = e.EmployeeAvailabilityId,
                    FromTime = e.From.ToShortTimeString(),
                    ToTime = e.To.ToShortTimeString(),
                    DriveName = e.Drive!.Name,
                    PoolName = e.Drive.Pool!.PoolName,
                    IntervieDate = e.InterviewDate.ToString("yyyy-MM-dd"),
                    Mode = Enum.GetName(typeof(UtilityService.Mode), e.Drive.ModeId),
                    LocationName = e.Drive.Location!.LocationName,
                    Status = e.IsInterviewScheduled
                }
                );//filter by user using authentication  
            }
            catch (Exception viewTodayInterviews)
            {
                _logger.LogInformation($"Drive Service : ViewTodayInterviews() : {viewTodayInterviews.Message} : {viewTodayInterviews.StackTrace}");
                throw;
            }
            
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive Service Time elapsed for  ViewTodayInterviews(int employeeId) :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }
        public Object ViewScheduledInterview(int employeeId)
        {
            _stopwatch.Start();
            try
            {
                return  _driveDataAccess.ViewScheduledInterviewsByStatus(false, employeeId)
                .Select(e => new
                {
                    DriveId = e.DriveId,
                    EmployeeAvailabilityId = e.EmployeeAvailabilityId,
                    FromTime = e.From.ToShortTimeString(),
                    ToTime = e.To.ToShortTimeString(),
                    DriveName = e.Drive!.Name,
                    PoolName = e.Drive.Pool!.PoolName,
                    IntervieDate = e.InterviewDate.ToString("yyyy-MM-dd"),
                    Mode = Enum.GetName(typeof(UtilityService.Mode), e.Drive.ModeId),
                    LocationName = e.Drive.Location!.LocationName,
                    Status = e.IsInterviewScheduled
                }
                );//filter by user using authentication  

            }
            catch (Exception viewScheduledInterviewException)
            {
                _logger.LogInformation($"Drive Service : ViewScheduledInterview() : {viewScheduledInterviewException.Message} : {viewScheduledInterviewException.StackTrace}");
                throw;
            }
            
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive Service Time elapsed for  ViewScheduledInterview(int employeeId) :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }
        public Object ViewCancelledInterview(int employeeId)
        {
            _stopwatch.Start();
            try
            {
                return  _driveDataAccess.ViewCancelledInterview(true, employeeId)
                .Select(e => new
                {
                    EmployeeAvailabilityId = e.EmployeeAvailabilityId,
                    FromTime = e.From.ToShortTimeString(),
                    ToTime = e.To.ToShortTimeString(),
                    DriveName = e.Drive!.Name,
                    PoolName = e.Drive.Pool!.PoolName,
                    IntervieDate = e.InterviewDate.ToString("yyyy-MM-dd"),
                    Mode = Enum.GetName(typeof(UtilityService.Mode), e.Drive.ModeId),
                    LocationName = e.Drive.Location!.LocationName,
                    Status = e.IsInterviewScheduled
                }
                );//filter by user using authentication  

            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Drive Service : ViewCancelledInterview(int employeeId) : {exception.Message} : {exception.StackTrace}");
                throw;
            }
            
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive Service Time elapsed for  ViewCancelledInterview(int employeeId) :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }

        public Object ViewUpcomingInterview(int employeeId)
        {
            _stopwatch.Start();
            try
            {
                return  _driveDataAccess.ViewUpcomingInterviewsByStatus(false, employeeId) 
                .Select(e => new
                {
                    EmployeeAvailabilityId = e.EmployeeAvailabilityId,
                    FromTime = e.From.ToShortTimeString(),
                    ToTime = e.To.ToShortTimeString(),
                    DriveName = e.Drive!.Name,
                    DriveId = e.DriveId,
                    PoolName = e.Drive.Pool!.PoolName,
                    IntervieDate = e.InterviewDate.ToString("yyyy-MM-dd"),
                    Mode = Enum.GetName(typeof(UtilityService.Mode), e.Drive.ModeId),
                    LocationName = e.Drive.Location!.LocationName,
                    Status = e.IsInterviewScheduled
                }
                );//filter by user using authentication  

            }
            catch (Exception viewUpcomingInterview)
            {
                _logger.LogInformation($"Drive Service : ViewUpcomingInterview() : {viewUpcomingInterview.Message} : {viewUpcomingInterview.StackTrace}");
                throw;
            }
            
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive Service Time elapsed for  ViewUpcomingInterview(int employeeId) :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }
        public Object ViewAllInterview(int employeeId)
        {
            _stopwatch.Start();
            try
            {
                return ((from interviews in _driveDataAccess.ViewInterviewsByStatus(false, employeeId) select interviews).Concat((from interviews in _driveDataAccess.ViewInterviewsByStatus(true, employeeId) select interviews)))
                .Select(e => new
                {
                    EmployeeAvailabilityId = e.EmployeeAvailabilityId,
                    DriveName = e.Drive!.Name,
                    PoolName = e.Drive.Pool!.PoolName,
                    IntervieDate = e.InterviewDate.ToString("yyyy-MM-dd"),
                    Mode = Enum.GetName(typeof(UtilityService.Mode), e.Drive.ModeId),
                    LocationName = e.Drive.Location!.LocationName,
                    Status = e.IsInterviewScheduled
                }
                );
            }
            catch (Exception viewAllInterview)
            {
                _logger.LogInformation($"Drive Service : ViewAllInterview() : {viewAllInterview.Message} : {viewAllInterview.StackTrace}");
                throw;
            }
            
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive Service Time elapsed for  ViewAllInterview(int employeeId) :{_stopwatch.ElapsedMilliseconds}ms");
            }

        }

        public bool ScheduleInterview(int employeeAvailabilityId)
        {
            _stopwatch.Start();
            Validations.EmployeeAvailabilityValidation.IsAvailabilityIdValid(employeeAvailabilityId);
            try
            {
                return _driveDataAccess.ScheduleInterview(employeeAvailabilityId);
            }
            catch (ValidationException scheduleInterviewNotVlaid)
            {
                _logger.LogInformation($"Drive Service : ScheduleInterview(int employeeAvailabilityId) : {scheduleInterviewNotVlaid.Message} : {scheduleInterviewNotVlaid.StackTrace}");
                throw scheduleInterviewNotVlaid;
            }
            catch (Exception scheduleInterviewException)
            {
                _logger.LogInformation($"Drive Service : ScheduleInterview(int employeeAvailabilityId) : {scheduleInterviewException.Message} : {scheduleInterviewException.StackTrace}");
                throw;
            }
            
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive Service Time elapsed for  ScheduleInterview(int employeeAvailabilityId) :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }

        public bool CancelInterview(int employeeAvailabilityId, string cancellationReason, string? comments)
        {
            _stopwatch.Start();
            try
            {
                return _driveDataAccess.CancelInterview(employeeAvailabilityId, cancellationReason, comments);
            }
            catch (ValidationException cancelInterviewNotVlaid)
            {
                _logger.LogInformation($"Drive Service : CancelInterview(int employeeAvailabilityId) :{cancelInterviewNotVlaid.Message} : {cancelInterviewNotVlaid.StackTrace}");
                return false;
            }
            catch (Exception cancelInterviewException)
            {
                _logger.LogInformation($"Drive Service : CancelInterview(int employeeAvailabilityId) : {cancelInterviewException.Message} : {cancelInterviewException.StackTrace}");
                return false;
            }
            
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive Service Time elapsed for  CancelInterview(int employeeAvailabilityId, string cancellationReason, string? comments) :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }
        public Object ViewAvailableMembersForDrive(int driveId)
        {
            _stopwatch.Start();
            //Drive Id validation
            try
            {
                return _driveDataAccess.ViewAvailableMembersForDrive(driveId).Select(
                availability => new
                {
                    employeeAvailabilityId = availability.EmployeeAvailabilityId,
                    employeeId = availability.EmployeeId,
                    employeeAceNumber = availability.Employee!.EmployeeAceNumber,
                    employeeName = availability.Employee.Name,
                    employeeDepartment = availability.Employee.Department!.DepartmentName,
                    employeeRole = availability.Employee.Role!.RoleName,
                    employeeSlotDate = availability.InterviewDate.ToShortDateString(),
                    employeeFromTime = availability.From.TimeOfDay.ToString("hh\\:mm"),
                    employeeToTime = availability.To.TimeOfDay.ToString("hh\\:mm")
                }
            );
            }
            catch (ValidationException viewAvailableMembersForDriveNotValid)
            {
                _logger.LogInformation($"Drive Service : ViewAvailableMembersForDrive(int driveId) : {viewAvailableMembersForDriveNotValid.Message} : {viewAvailableMembersForDriveNotValid.StackTrace}");
                return false;
            }
            catch (Exception viewAvailableMembersForDriveException)
            {
                _logger.LogInformation($"Drive Service : ViewAvailableMembersForDrive(int driveId) : {viewAvailableMembersForDriveException.Message} : {viewAvailableMembersForDriveException.StackTrace}");
                return false;
            }
            
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive Service Time elapsed for  ViewAvailableMembersForDrive(int driveId) :{_stopwatch.ElapsedMilliseconds}ms");
            }

        }
        

        public Dictionary<string, int> ViewEmployeeDashboard(int employeeId, DateTime fromDate, DateTime toDate)
        {
            _stopwatch.Start();
            try
            {

                var DashboardCount = new Dictionary<string, int>();

                DashboardCount.Add("AcceptedDrives", _driveDataAccess.GetResponseDetailsByStatus(1, employeeId, fromDate, toDate).Count());
                DashboardCount.Add("DeniedDrives", _driveDataAccess.GetResponseDetailsByStatus(2, employeeId, fromDate, toDate).Count());
                DashboardCount.Add("IgnoredDrives", _driveDataAccess.GetResponseDetailsByStatus(3, employeeId, fromDate, toDate).Count());
                DashboardCount.Add("TotalDrives", DashboardCount["AcceptedDrives"] + DashboardCount["DeniedDrives"] + DashboardCount["IgnoredDrives"]);
                DashboardCount.Add("UtilizedInterviews", _driveDataAccess.GetResponseUtilizationByStatus(true, employeeId).Count());
                DashboardCount.Add("NotUtilizedInterviews", _driveDataAccess.GetResponseUtilizationByStatus(false, employeeId).Count());
                DashboardCount.Add("TotalAvailability", DashboardCount["UtilizedInterviews"] + DashboardCount["NotUtilizedInterviews"]);
                return DashboardCount;
            }
            catch (ValidationException viewEmployeeDashboardNotVlaid)
            {
                _logger.LogInformation($"Drive Service : ViewEmployeeDashboard(int employeeId) : {viewEmployeeDashboardNotVlaid.Message} : {viewEmployeeDashboardNotVlaid.StackTrace}");
                throw viewEmployeeDashboardNotVlaid;
            }
            catch (Exception viewEmployeeDashboardException)
            {
                _logger.LogInformation($"Drive Service : ViewEmployeeDashboard(int employeeId) : {viewEmployeeDashboardException.Message} : {viewEmployeeDashboardException.StackTrace}");
                throw;
            }
            
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive Service Time elapsed for  ViewEmployeeDashboard(int employeeId, int departmentId, DateTime fromDate, DateTime toDate) :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }
        
        public List<object> ViewEmployeePerformance(int employeeId, int departmentId, DateTime fromDate, DateTime toDate)
        {
            _stopwatch.Start();
            try
            {
            List<Employee> employee = _driveDataAccess.GetEmployee(departmentId);

            var count = new Dictionary<string, int>();
            var DashboardCount = new List<Dictionary<string, int>>();

            var ViewEmployeePerformance = new List<object>();
            foreach (var member in employee)
            {
                count = ViewEmployeeDashboard(member.EmployeeId, fromDate, toDate);

                ViewEmployeePerformance.Add(new
                {
                    DashboardCount = count,
                    Employee = new
                {
                    EmployeeName = member.Name,
                    EmployeeACENumber = member.EmployeeAceNumber,
                    EmployeeRole = member.Role!.RoleName
                }
                });


            }
            return ViewEmployeePerformance;
            }
            catch (Exception exception)
            {
 
                _logger.LogError($"Drive service:ViewEmployeePerformance(int employeeId, int departmentId, DateTime fromDate, DateTime toDate):{exception.Message}");
                throw ;
            }
           
           finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive Service Time elapsed for  ViewEmployeePerformance(int employeeId, int departmentId, DateTime fromDate, DateTime toDate) :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }
  

        public Object ViewTotalDrives(int employeeId, DateTime fromDate, DateTime toDate)
        {
            _stopwatch.Start();
            try
            {
                return _driveDataAccess.GetResponseDetailsByStatus(1, employeeId, fromDate, toDate).Concat(_driveDataAccess.GetResponseDetailsByStatus(2, employeeId, fromDate, toDate)).Concat(_driveDataAccess.GetResponseDetailsByStatus(3, employeeId, fromDate, toDate)).Select(d => new
                {
                    EmployeeDriveResponseId = d.ResponseId,
                    DriveName = d.Drive!.Name,
                    FromDate = d.Drive.FromDate.ToString("yyyy-MM-dd"),
                    ToDate = d.Drive.ToDate.ToString("yyyy-MM-dd"),
                    DriveLocation = d.Drive.Location!.LocationName,
                    DrivePool = d.Drive.Pool!.PoolName,
                    DriveMode = Enum.GetName(typeof(UtilityService.Mode), d.Drive.ModeId),
                    Response = Enum.GetName(typeof(UtilityService.ResponseType), d.ResponseType)
                }
                );
            }
            catch (Exception viewTotalDrivesException)
            {
                _logger.LogInformation($"Drive Service : ViewTotalDrives(int employeeId) : {viewTotalDrivesException.Message} : {viewTotalDrivesException.StackTrace}");
                throw ;
            }
            
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive Service Time elapsed for  ViewTotalDrives(int employeeId, DateTime fromDate, DateTime toDate) :{_stopwatch.ElapsedMilliseconds}ms");
            }

        }
        public Object ViewAcceptedDrives(int employeeId, DateTime fromDate, DateTime toDate)
        {
            _stopwatch.Start();
            try
            {
                return _driveDataAccess.GetResponseDetailsByStatus(1, employeeId, fromDate, toDate).Select(d => new
                {
                    EmployeeDriveResponseId = d.ResponseId,
                    DriveName = d.Drive!.Name,
                    FromDate = d.Drive.FromDate.ToString("yyyy-MM-dd"),
                    ToDate = d.Drive.ToDate.ToString("yyyy-MM-dd"),
                    DriveLocation = d.Drive.Location!.LocationName,
                    DrivePool = d.Drive.Pool!.PoolName,
                    DriveMode = Enum.GetName(typeof(UtilityService.Mode), d.Drive.ModeId),
                    Response = Enum.GetName(typeof(UtilityService.ResponseType), d.ResponseType)
                }
                );
            }
            catch (Exception viewAcceptedDrivesException)
            {
                _logger.LogInformation($"Drive Service : ViewAcceptedDrives() : {viewAcceptedDrivesException.Message} : {viewAcceptedDrivesException.StackTrace}");
                throw ;
            }
            
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive Service Time elapsed for  ViewAcceptedDrives(int employeeId, DateTime fromDate, DateTime toDate) :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }
        public Object ViewDeniedDrives(int employeeId, DateTime fromDate, DateTime toDate)
        {
            _stopwatch.Start();
            try
            {
                return _driveDataAccess.GetResponseDetailsByStatus(2, employeeId, fromDate, toDate).Select(d => new
                {
                    EmployeeDriveResponseId = d.ResponseId,
                    DriveName = d.Drive!.Name,
                    FromDate = d.Drive.FromDate.ToString("yyyy-MM-dd"),
                    ToDate = d.Drive.ToDate.ToString("yyyy-MM-dd"),
                    DriveLocation = d.Drive.Location!.LocationName,
                    DrivePool = d.Drive.Pool!.PoolName,
                    DriveMode = Enum.GetName(typeof(UtilityService.Mode), d.Drive.ModeId),
                    Response = Enum.GetName(typeof(UtilityService.ResponseType), d.ResponseType)
                }
                );
            }
            catch (Exception viewDeniedDrivesException)
            {
                _logger.LogInformation($"Drive Service : ViewDeniedDrives() : {viewDeniedDrivesException.Message} : {viewDeniedDrivesException.StackTrace}");
                throw ;
            }
            
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive Service Time elapsed for  ViewDeniedDrives(int employeeId, DateTime fromDate, DateTime toDate) :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }
        public Object ViewIgnoredDrives(int employeeId, DateTime fromDate, DateTime toDate)
        {
            _stopwatch.Start();
            try
            {
                return _driveDataAccess.GetResponseDetailsByStatus(3, employeeId, fromDate, toDate).Select(d => new
                {
                    EmployeeDriveResponseId = d.ResponseId,
                    DriveName = d.Drive!.Name,
                    FromDate = d.Drive.FromDate.ToString("yyyy-MM-dd"),
                    ToDate = d.Drive.ToDate.ToString("yyyy-MM-dd"),
                    DriveLocation = d.Drive.Location!.LocationName,
                    DrivePool = d.Drive.Pool!.PoolName,
                    DriveMode = Enum.GetName(typeof(UtilityService.Mode), d.Drive.ModeId),
                    Response = Enum.GetName(typeof(UtilityService.ResponseType), d.ResponseType)
                }
                );
            }
            catch (Exception viewIgnoredDrivesException)
            {
                _logger.LogInformation($"Drive Service : ViewIgnoredDrives(int employeeId, DateTime fromDate, DateTime toDate) : {viewIgnoredDrivesException.Message} : {viewIgnoredDrivesException.StackTrace}");
                throw ;
            }
            
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive Service Time elapsed for  ViewIgnoredDrives(int employeeId, DateTime fromDate, DateTime toDate) :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }

        public Object ViewUtilizedInterviews(int employeeId)
        {
            _stopwatch.Start();
            try
            {
                return _driveDataAccess.GetResponseUtilizationByStatus(true, employeeId).Select(e => new
                {
                    EmployeeAvailabilityId = e.EmployeeAvailabilityId,
                    DriveName = e.Drive!.Name,
                    PoolName = e.Drive.Pool!.PoolName,
                    InterviewDate = e.InterviewDate.ToString("yyyy-MM-dd"),
                    FromTime = e.From.TimeOfDay,
                    ToTime = e.To.TimeOfDay,
                    Mode = Enum.GetName(typeof(UtilityService.Mode), e.Drive.ModeId),
                    LocationName = e.Drive.Location!.LocationName,
                    Status = e.IsInterviewScheduled
                }
                );
            }
            catch (Exception utilizedInterviewsException)
            {
                _logger.LogInformation($"Drive Service : UtilizedInterviews(int employeeId) : {utilizedInterviewsException.Message} : {utilizedInterviewsException.StackTrace}");
                throw ;
            }
            
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive Service Time elapsed for  ViewUtilizedInterviews(int employeeId) :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }
        public Object ViewNotUtilizedInterviews(int employeeId)
        {
            _stopwatch.Start();
            try
            {
                return _driveDataAccess.GetResponseUtilizationByStatus(false, employeeId).Select(e => new
                {
                    EmployeeAvailabilityId = e.EmployeeAvailabilityId,
                    DriveName = e.Drive!.Name,
                    PoolName = e.Drive.Pool!.PoolName,
                    InterviewDate = e.InterviewDate.ToString("yyyy-MM-dd"),
                    FromTime = e.From.TimeOfDay,
                    ToTime = e.To.TimeOfDay,
                    Mode = Enum.GetName(typeof(UtilityService.Mode), e.Drive.ModeId),
                    LocationName = e.Drive.Location!.LocationName,
                    Status = e.IsInterviewScheduled
                }
                );
            }
            catch (Exception viewNotUtilizedInterviewsException)
            {
                _logger.LogInformation($"Drive Service : ViewNotUtilizedInterviews(int employeeId) : {viewNotUtilizedInterviewsException.Message} : {viewNotUtilizedInterviewsException.StackTrace}");
                throw ;
            }
            
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive Service Time elapsed for  ViewNotUtilizedInterviews(int employeeId) :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }
        public Object ViewTotalAvailability(int employeeId)
        {
            _stopwatch.Start();
            try
            {
                return _driveDataAccess.GetResponseUtilizationByStatus(false, employeeId).Concat(_driveDataAccess.GetResponseUtilizationByStatus(true, employeeId))
                .Select(e => new
                {
                    EmployeeAvailabilityId = e.EmployeeAvailabilityId,
                    DriveName = e.Drive!.Name,
                    PoolName = e.Drive.Pool!.PoolName,
                    InterviewDate = e.InterviewDate.ToString("yyyy-MM-dd"),
                    FromTime = e.From.TimeOfDay,
                    ToTime = e.To.TimeOfDay,
                    Mode = Enum.GetName(typeof(UtilityService.Mode), e.Drive.ModeId),
                    LocationName = e.Drive.Location!.LocationName,
                    Status = e.IsInterviewScheduled
                }
                );
            }
            catch (Exception viewTotalAvailabilityException)
            {
                _logger.LogInformation($"Drive Service : ViewTotalAvailability(int employeeId) : {viewTotalAvailabilityException.Message} : {viewTotalAvailabilityException.StackTrace}");
                throw ;
            }
            
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive Service Time elapsed for  ViewTotalAvailability(int employeeId) :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }

        public Object ViewDefaulters(int poolId)
        {
            _stopwatch.Start();
            try
            {
                return _driveDataAccess.GetDefaulters(poolId);
            }
            catch (Exception viewDefaultersException)
            {
                _logger.LogInformation($"Drive Service : ViewTotalAvailability(int employeeId) : {viewDefaultersException.Message} : {viewDefaultersException.StackTrace}");
                throw;
            }
            
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive Service Time elapsed for  ViewDefaulters(int poolId) :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }

        public Object ViewDriveResponse(int driveId)
        {
            _stopwatch.Start();
            DriveValidation.IsDriveIdValid(driveId);
            try
            {
                return _driveDataAccess.GetDriveResponse(driveId).Select(e => new
                {
                    EmployeeId = e.EmployeeId,
                    EmployeeName = e.Employee!.Name,
                    EmployeeACENumber = e.Employee!.EmployeeAceNumber,

                    ResponseType = Enum.GetName(typeof(UtilityService.ResponseType), e.ResponseType)
                }
                );
            }
            catch (ValidationException driveNotfoundException)
            {
                _logger.LogError($"Drive service:ViewDriveResponse(int driveId):{driveNotfoundException.Message}");
                throw driveNotfoundException;

            }
            catch (Exception ViewDriveResponseException)
            {
                _logger.LogInformation($"Drive Service : ViewDriveResponse(int driveId) : {ViewDriveResponseException.Message} : {ViewDriveResponseException.StackTrace}");
                throw;
            }
            
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive Service Time elapsed for  ViewDriveResponse(int driveId) :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }
        public List<string> GetDrivesForCurrentUser(int departmentId)
        {
            
            _stopwatch.Start();
            DepartmentValidation.IsDepartmentIdValid(departmentId);
            try
            {

                return _driveDataAccess.GetDrivesForCurrentUser(departmentId);
            }
            catch (ValidationException exception)
            {
                _logger.LogError($"Drive service:GetDrivesForCurrentUser(int departmentId):{exception.Message}");
                throw;

            }
            catch (Exception exception)
            {
                _logger.LogError($"Drive service:GetDrivesForCurrentUser(int department):{exception.Message}");
                throw;
            }
            finally
            {
                _stopwatch.Stop();
                _logger.LogInformation($"Drive Service Time elapsed for  GetDrivesForCurrentUser(int departmentId) :{_stopwatch.ElapsedMilliseconds}ms");
            }
        }
    }
}


