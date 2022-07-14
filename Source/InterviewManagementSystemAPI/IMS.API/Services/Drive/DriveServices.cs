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
        private IConfiguration _configuration;

        public DriveService(ILogger<DriveService> logger, IDriveDataAccessLayer driveDataAccessLayer, IConfiguration configuration)
        {
            _logger = logger;
            _driveDataAccess = driveDataAccessLayer;
            _configuration = configuration;
        }

        public bool CreateDrive(Drive drive)
        {
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
                _logger.LogInformation($"Drive Service : CancelDrive() : {cancelDriveNotValid.Message} : {cancelDriveNotValid.StackTrace}");
                throw cancelDriveNotValid;
            }
            catch (Exception cancelDriveException)
            {
                _logger.LogInformation($"Drive Service : CancelDrive() : {cancelDriveException.Message} : {cancelDriveException.StackTrace}");
                return false;
            }

        }

        public Object ViewTodayDrives()
        {
            try
            {
                return (from drive in _driveDataAccess.GetDrivesByStatus(false) where (drive.FromDate.Date <= System.DateTime.Now.Date && drive.ToDate.Date >= System.DateTime.Now.Date) && drive.IsScheduled == true select drive).ToList()
                .Select(d => new
                {
                    DriveId = d.DriveId,
                    DriveName = d.Name,
                    FromDate = d.FromDate.ToString("yyyy-MM-dd"),
                    ToDate = d.ToDate.ToString("yyyy-MM-dd"),
                    DriveDepartment = d.Pool!.department.DepartmentName,
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

        }

        public Object ViewScheduledDrives()
        {
            try
            {
                return (from drive in _driveDataAccess.GetDrivesByStatus(false) where drive.FromDate.Date > System.DateTime.Now.Date && drive.IsScheduled == true select drive).ToList()
                .Select(d => new
                {
                    DriveId = d.DriveId,
                    DriveName = d.Name,
                    FromDate = d.FromDate.ToString("yyyy-MM-dd"),
                    ToDate = d.ToDate.ToString("yyyy-MM-dd"),
                    DriveDepartment = d.Pool!.department.DepartmentName,
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

        }

        public Object ViewUpcomingDrives()
        {
            try
            {
                return (from drive in _driveDataAccess.GetDrivesByStatus(false) where drive.FromDate.Date != System.DateTime.Now.Date && drive.IsScheduled == false select drive).ToList()
                .Select(d => new
                {
                    DriveId = d.DriveId,
                    DriveName = d.Name,
                    FromDate = d.FromDate.ToString("yyyy-MM-dd"),
                    ToDate = d.ToDate.ToString("yyyy-MM-dd"),
                    DriveDepartment = d.Pool!.department.DepartmentName,
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

        }

        public Object ViewNonCancelledDrives(int tacId)
        {
            try
            {
                return (from drive in _driveDataAccess.GetDrivesByStatus(false).Where(d => d.AddedBy == tacId) select drive).ToList()
                .Select(d => new
                {
                    DriveId = d.DriveId,
                    DriveName = d.Name,
                    FromDate = d.FromDate.ToString("yyyy-MM-dd"),
                    ToDate = d.ToDate.ToString("yyyy-MM-dd"),
                    DriveDepartment = d.Pool!.department.DepartmentName,
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
        }

        public Object ViewAllCancelledDrives(int tacId)
        {
            try
            {
                return (from drive in _driveDataAccess.GetDrivesByStatus(true).Where(d => d.AddedBy == tacId) select drive).ToList()
                .Select(d => new
                {
                    DriveId = d.DriveId,
                    DriveName = d.Name,
                    FromDate = d.FromDate.ToString("yyyy-MM-dd"),
                    ToDate = d.ToDate.ToString("yyyy-MM-dd"),
                    DriveDepartment = d.Pool!.department.DepartmentName,
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
                throw ;
            }
        }

        public Dictionary<string, int> ViewTACDashboard(int employeeId)
        {
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
        }
        private int DriveCountForTacByStatus(bool status, int employeeId)
        {
            return (from drive in _driveDataAccess.GetDrivesByStatus(status) where drive.AddedBy == employeeId select drive).Count();
        }

        public Object ViewDrive(int driveId)
        {
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
                    SlotTiming=drive.SlotTiming,
                    DriveDepartment = drive.Pool!.department.DepartmentName,
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
                throw ;
            }
        }

        //For Employee Drive Response Entity
        public bool AddResponse(EmployeeDriveResponse response)
        {
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
            Validations.EmployeeValidation.IsEmployeeIdValid(employeeId);
            try
            {
                List<object> driveInvites = new List<object>();
                var employeePoolIds = GetEmployeePoolIds(employeeId);
                var upcomingDrives = (from drive in _driveDataAccess.GetDrivesByStatus(false) where drive.FromDate.Date != System.DateTime.Now.Date && drive.IsScheduled == false select drive).
                Select(d => new
                {
                    DriveId = d.DriveId,
                    DriveName = d.Name,
                    FromDate = d.FromDate.ToString("yyyy-MM-dd"),
                    ToDate = d.ToDate.ToString("yyyy-MM-dd"),
                    DriveLocation = d.Location!.LocationName,
                    DrivePool = d.Pool!.PoolName,
                    DriveMode = Enum.GetName(typeof(UtilityService.Mode),d.ModeId),
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
                _logger.LogInformation($"EmployeeDriveResponse Service : AddResponse(EmployeeDriveResponse response) : {exception.Message}");
                throw;
            }
        }
        private List<int> GetEmployeePoolIds(int employeeId)
        {
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
        }

        //For Employee Availability Entity
        public bool SetTimeSlot(EmployeeAvailability employeeAvailability)
        {
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
        }
        public Object ViewAvailabilty(int employeeId, int driveId)
        {
            try
            {
                return _driveDataAccess.ViewAvailability(employeeId, driveId).Select(e => new
                {
          
                    DriveName=e.Drive!.Name,
                    Date=e.InterviewDate,
                    FromTime=e.From,
                    ToTime=e.To
                }
                );
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Drive Service : ViewAvailability(employeeId) : {exception.Message} : {exception.StackTrace}");
                throw;
            }
        }
        public Object ViewTodayInterviews(int employeeId)
        {
            try
            {
                return (from interviews in _driveDataAccess.ViewInterviewsByStatus(false, employeeId) where interviews.InterviewDate.Date == System.DateTime.Now.Date && interviews.IsInterviewScheduled == true select interviews)
                .Select(e => new
                {
                    EmployeeAvailabilityId = e.EmployeeAvailabilityId,
                    FromTime=e.From.ToShortTimeString(),
                    ToTime=e.To.ToShortTimeString(),
                    DriveName = e.Drive!.Name,
                    PoolName = e.Drive.Pool!.PoolName,
                    IntervieDate = e.InterviewDate.ToString("yyyy-MM-dd"),
                    Mode = Enum.GetName(typeof(UtilityService.Mode),e.Drive.ModeId),
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
        }
        public Object ViewScheduledInterview(int employeeId)
        {
            try
            {
                return (from interviews in _driveDataAccess.ViewInterviewsByStatus(false, employeeId) where interviews.InterviewDate.Date > System.DateTime.Now.Date && interviews.IsInterviewScheduled == true select interviews)
                .Select(e => new
                {
                    EmployeeAvailabilityId = e.EmployeeAvailabilityId,
                    FromTime=e.From.ToShortTimeString(),
                    ToTime=e.To.ToShortTimeString(),
                    DriveName = e.Drive!.Name,
                    PoolName = e.Drive.Pool!.PoolName,
                    IntervieDate = e.InterviewDate.ToString("yyyy-MM-dd"),
                    Mode = Enum.GetName(typeof(UtilityService.Mode),e.Drive.ModeId),
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
        }
        public Object ViewCancelledInterview(int employeeId)
        {
            try
            {
                return (from interviews in _driveDataAccess.ViewCancelledInterview(true, employeeId) where interviews.InterviewDate.Date > System.DateTime.Now.Date && interviews.IsInterviewScheduled == true select interviews)
                .Select(e => new
                {
                    EmployeeAvailabilityId = e.EmployeeAvailabilityId,
                    FromTime=e.From.ToShortTimeString(),
                    ToTime=e.To.ToShortTimeString(),
                    DriveName = e.Drive!.Name,
                    PoolName = e.Drive.Pool!.PoolName,
                    IntervieDate = e.InterviewDate.ToString("yyyy-MM-dd"),
                    Mode = Enum.GetName(typeof(UtilityService.Mode),e.Drive.ModeId),
                    LocationName = e.Drive.Location!.LocationName,
                    Status = e.IsInterviewScheduled
                }
                );//filter by user using authentication  

            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Drive Service : ViewScheduledInterview() : {exception.Message} : {exception.StackTrace}");
                throw;
            }
        }
        
        public Object ViewUpcomingInterview(int employeeId)
        {
            try
            {
                return (from interviews in _driveDataAccess.ViewInterviewsByStatus(false, employeeId) where interviews.InterviewDate.Date > System.DateTime.Now.Date && interviews.IsInterviewScheduled == false select interviews)
                .Select(e => new
                {
                    EmployeeAvailabilityId = e.EmployeeAvailabilityId,
                    FromTime=e.From.ToShortTimeString(),
                    ToTime=e.To.ToShortTimeString(),
                    DriveName = e.Drive!.Name,
                    DriveId=e.DriveId,
                    PoolName = e.Drive.Pool!.PoolName,
                    IntervieDate = e.InterviewDate.ToString("yyyy-MM-dd"),
                    Mode = Enum.GetName(typeof(UtilityService.Mode),e.Drive.ModeId),
                    LocationName = e.Drive.Location!.LocationName,
                    Status = e.IsInterviewScheduled
                }
                );//filter by user using authentication  

            }
            catch (Exception viewUpcomingInterview)
            {
                _logger.LogInformation($"Drive Service : ViewUpcomingInterview() : {viewUpcomingInterview.Message} : {viewUpcomingInterview.StackTrace}");
                throw ;
            }
        }
        public Object ViewAllInterview(int employeeId)
        {
            try
            {
                return ((from interviews in _driveDataAccess.ViewInterviewsByStatus(false, employeeId) select interviews).Concat((from interviews in _driveDataAccess.ViewInterviewsByStatus(true, employeeId) select interviews)))
                .Select(e => new
                {
                    EmployeeAvailabilityId = e.EmployeeAvailabilityId,
                    DriveName = e.Drive!.Name,
                    PoolName = e.Drive.Pool!.PoolName,
                    IntervieDate = e.InterviewDate.ToString("yyyy-MM-dd"),
                    Mode = Enum.GetName(typeof(UtilityService.Mode),e.Drive.ModeId),
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

        }

        public bool ScheduleInterview(int employeeAvailabilityId)
        {
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
        }

        public bool CancelInterview(int employeeAvailabilityId, string cancellationReason, string? comments)
        {
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
        }
        public Object ViewAvailableMembersForDrive(int driveId)
        {
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
                    employeeSlotDate=availability.InterviewDate.ToShortDateString(),
                    employeeFromTime = availability.From.TimeOfDay.ToString("hh\\:mm") ,
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

        }
         public Object ViewEmployees(int departmentId)
        {
            try
            {
               
               return _driveDataAccess.GetEmployee(departmentId);
              
            }
            catch (Exception viewDefaultersException)
            {
                _logger.LogInformation($"Drive Service : ViewEmployees(int departmentId) : {viewDefaultersException.Message} : {viewDefaultersException.StackTrace}");
                throw;
            }
        }

        public Dictionary<string, int> ViewEmployeeDashboard(int employeeId,int departmentId, DateTime fromDate, DateTime toDate)
        {
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
                throw ;
            }
        }
        public List<Dictionary<string,int>>ViewEmployeePerformance(int employeeId,int departmentId,DateTime fromDate,DateTime toDate)
        {
            var employee=GetEmployee(departmentId);
          
            var count=new Dictionary<string,int>();
            var DashboardCount=new List<Dictionary<string,int>>();
            

            foreach(var member in employee)
            {
                count=ViewEmployeeDashboard(member, departmentId,fromDate,toDate);
               DashboardCount.Add(count);
             
            }
              return DashboardCount;

        }
         private List<int>  GetEmployee(int departmentId)
        { 
            try
            {
                return _driveDataAccess.GetEmployee(departmentId);
            }
            catch (ValidationException exception)
            {
                _logger.LogInformation($"Drive Service :  GetEmployee(int departmentId) : {exception.Message}");
                throw exception;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Drive Service :  GetEmployeePoolIds(int departmentId) : {exception.Message}");
                throw;
            }
        }

        public Object ViewTotalDrives(int employeeId, DateTime fromDate, DateTime toDate)
        {
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
                    DriveMode = Enum.GetName(typeof(UtilityService.Mode),d.Drive.ModeId),
                    Response =  Enum.GetName(typeof(UtilityService.ResponseType),d.ResponseType)
                }
                );
            }
            catch (Exception viewTotalDrivesException)
            {
                _logger.LogInformation($"Drive Service : ViewTotalDrives(int employeeId) : {viewTotalDrivesException.Message} : {viewTotalDrivesException.StackTrace}");
                throw viewTotalDrivesException;
            }

        }
        public Object ViewAcceptedDrives(int employeeId, DateTime fromDate, DateTime toDate)
        {
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
                    DriveMode = Enum.GetName(typeof(UtilityService.Mode),d.Drive.ModeId),
                    Response = Enum.GetName(typeof(UtilityService.ResponseType),d.ResponseType)
                }
                );
            }
            catch (Exception viewAcceptedDrivesException)
            {
                _logger.LogInformation($"Drive Service : ViewAcceptedDrives() : {viewAcceptedDrivesException.Message} : {viewAcceptedDrivesException.StackTrace}");
                throw viewAcceptedDrivesException;
            }
        }
        public Object ViewDeniedDrives(int employeeId, DateTime fromDate, DateTime toDate)
        {
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
                    DriveMode = Enum.GetName(typeof(UtilityService.Mode),d.Drive.ModeId),
                    Response = Enum.GetName(typeof(UtilityService.ResponseType),d.ResponseType)
                }
                );
            }
            catch (Exception viewDeniedDrivesException)
            {
                _logger.LogInformation($"Drive Service : ViewDeniedDrives() : {viewDeniedDrivesException.Message} : {viewDeniedDrivesException.StackTrace}");
                throw viewDeniedDrivesException;
            }
        }
        public Object ViewIgnoredDrives(int employeeId, DateTime fromDate, DateTime toDate)
        {
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
                    DriveMode = Enum.GetName(typeof(UtilityService.Mode),d.Drive.ModeId),
                    Response =Enum.GetName(typeof(UtilityService.ResponseType),d.ResponseType)
                }
                );
            }
            catch (Exception viewIgnoredDrivesException)
            {
                _logger.LogInformation($"Drive Service : ViewDeniedDrives() : {viewIgnoredDrivesException.Message} : {viewIgnoredDrivesException.StackTrace}");
                throw viewIgnoredDrivesException;
            }
        }

        public Object ViewUtilizedInterviews(int employeeId)
        {
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
                    Mode = Enum.GetName(typeof(UtilityService.Mode),e.Drive.ModeId),
                    LocationName = e.Drive.Location!.LocationName,
                    Status = e.IsInterviewScheduled
                }
                );
            }
            catch (Exception utilizedInterviewsException)
            {
                _logger.LogInformation($"Drive Service : UtilizedInterviews(int employeeId) : {utilizedInterviewsException.Message} : {utilizedInterviewsException.StackTrace}");
                throw utilizedInterviewsException;
            }
        }
        public Object ViewNotUtilizedInterviews(int employeeId)
        {
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
                    Mode = Enum.GetName(typeof(UtilityService.Mode),e.Drive.ModeId),
                    LocationName = e.Drive.Location!.LocationName,
                    Status = e.IsInterviewScheduled
                }
                );
            }
            catch (Exception viewNotUtilizedInterviewsException)
            {
                _logger.LogInformation($"Drive Service : ViewNotUtilizedInterviews(int employeeId) : {viewNotUtilizedInterviewsException.Message} : {viewNotUtilizedInterviewsException.StackTrace}");
                throw viewNotUtilizedInterviewsException;
            }
        }
        public Object ViewTotalAvailability(int employeeId)
        {
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
                    Mode = Enum.GetName(typeof(UtilityService.Mode),e.Drive.ModeId),
                    LocationName = e.Drive.Location!.LocationName,
                    Status = e.IsInterviewScheduled
                }
                );
            }
            catch (Exception viewTotalAvailabilityException)
            {
                _logger.LogInformation($"Drive Service : ViewTotalAvailability(int employeeId) : {viewTotalAvailabilityException.Message} : {viewTotalAvailabilityException.StackTrace}");
                throw viewTotalAvailabilityException;
            }
        }

        public Object ViewDefaulters(int poolId)
        {
            try
            {
                return _driveDataAccess.GetDefaulters(poolId);
            }
            catch (Exception viewDefaultersException)
            {
                _logger.LogInformation($"Drive Service : ViewTotalAvailability(int employeeId) : {viewDefaultersException.Message} : {viewDefaultersException.StackTrace}");
                throw;
            }
        }

        public Object ViewDriveResponse(int driveId)
        {
            try
            {
                return _driveDataAccess.GetDriveResponse(driveId).Select(e => new
                {
                    EmployeeId= e.EmployeeId,
                    EmployeeName=e.Employee!.Name,
                    EmployeeACENumber=e.Employee!.EmployeeAceNumber,

                    ResponseType=Enum.GetName(typeof(UtilityService.ResponseType), e.ResponseType)
                }
                );
            }
            catch (Exception ViewDriveResponseException)
            {
                _logger.LogInformation($"Drive Service : ViewDriveResponse(int driveId) : {ViewDriveResponseException.Message} : {ViewDriveResponseException.StackTrace}");
                throw;
            }
        }
        public List<string> GetDrivesForCurrentUser(int departmentId)
        {
            
            return _driveDataAccess.GetDrivesForCurrentUser(departmentId);;
        }
    }
}


