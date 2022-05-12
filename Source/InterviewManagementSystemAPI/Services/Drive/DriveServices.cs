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
                .Select(d=>new{
                    DriveId=d.DriveId,
                    DriveName=d.Name,
                    FromDate=d.FromDate.ToString("yyyy-MM-dd"),
                    ToDate=d.ToDate.ToString("yyyy-MM-dd"),
                    DriveDepartment=d.Pool.department.DepartmentName,
                    DriveLocation=d.Location.LocationName,
                    DrivePool=d.Pool.PoolName,
                    DriveMode=d.ModeId
                }
                );
            }
            catch (Exception viewTodayDrivesException)
            {
                _logger.LogInformation($"Drive Service : ViewTodayDrives() : {viewTodayDrivesException.Message} : {viewTodayDrivesException.StackTrace}");
                throw viewTodayDrivesException;
            }

        }

        public Object ViewScheduledDrives()
        {
            try
            {
                return (from drive in _driveDataAccess.GetDrivesByStatus(false) where drive.FromDate.Date > System.DateTime.Now.Date && drive.IsScheduled == true select drive).ToList()
                .Select(d=>new{
                    DriveId=d.DriveId,
                    DriveName=d.Name,
                    FromDate=d.FromDate.ToString("yyyy-MM-dd"),
                    ToDate=d.ToDate.ToString("yyyy-MM-dd"),
                    DriveDepartment=d.Pool.department.DepartmentName,
                    DriveLocation=d.Location.LocationName,
                    DrivePool=d.Pool.PoolName,
                    DriveMode=d.ModeId
                }
                );
            }
            catch (Exception viewScheduledDrivesException)
            {
                _logger.LogInformation($"Drive Service : ViewScheduledDrives() : {viewScheduledDrivesException.Message} : {viewScheduledDrivesException.StackTrace}");
                throw viewScheduledDrivesException;
            }

        }

        public Object ViewUpcommingDrives()
        {
            try
            {
                return (from drive in _driveDataAccess.GetDrivesByStatus(false) where drive.FromDate.Date != System.DateTime.Now.Date && drive.IsScheduled == false select drive).ToList()
                .Select(d=>new{
                    DriveId=d.DriveId,
                    DriveName=d.Name,
                    FromDate=d.FromDate.ToString("yyyy-MM-dd"),
                    ToDate=d.ToDate.ToString("yyyy-MM-dd"),
                    DriveDepartment=d.Pool.department.DepartmentName,
                    DriveLocation=d.Location.LocationName,
                    DrivePool=d.Pool.PoolName,
                    DriveMode=d.ModeId
                }
                );
            }
            catch (Exception viewUpcommingDrivesException)
            {
                _logger.LogInformation($"Drive Service : ViewUpcommingDrives() : {viewUpcommingDrivesException.Message} : {viewUpcommingDrivesException.StackTrace}");
                throw viewUpcommingDrivesException;
            }

        }

        public Object ViewNonCancelledDrives()
        {
            try
            {
                return (from drive in _driveDataAccess.GetDrivesByStatus(false) select drive).ToList()
                .Select(d=>new{
                    DriveId=d.DriveId,
                    DriveName=d.Name,
                    FromDate=d.FromDate.ToString("yyyy-MM-dd"),
                    ToDate=d.ToDate.ToString("yyyy-MM-dd"),
                    DriveDepartment=d.Pool.department.DepartmentName,
                    DriveLocation=d.Location.LocationName,
                    DrivePool=d.Pool.PoolName,
                    DriveMode=d.ModeId
                }
                );
            }
            catch (Exception viewAllScheduledDrivesException)
            {
                _logger.LogInformation($"Drive Service : ViewAllScheduledDrives() : {viewAllScheduledDrivesException.Message} : {viewAllScheduledDrivesException.StackTrace}");
                throw viewAllScheduledDrivesException;
            }
        }

        public Object ViewAllCancelledDrives()
        {
            try
            {
                return (from drive in _driveDataAccess.GetDrivesByStatus(true) select drive).ToList()
                .Select(d=>new{
                    DriveId=d.DriveId,
                    DriveName=d.Name,
                    FromDate=d.FromDate.ToString("yyyy-MM-dd"),
                    ToDate=d.ToDate.ToString("yyyy-MM-dd"),
                    DriveDepartment=d.Pool.department.DepartmentName,
                    DriveLocation=d.Location.LocationName,
                    DrivePool=d.Pool.PoolName,
                    DriveMode=d.ModeId
                }
                );
            }
            catch (Exception viewAllCancelledDrivesException)
            {
                _logger.LogInformation($"Drive Service : ViewAllCancelledDrives() : {viewAllCancelledDrivesException.Message} : {viewAllCancelledDrivesException.StackTrace}");
                throw viewAllCancelledDrivesException;
            }
        }

        public Dictionary<string, int> ViewTACDashboard(int employeeId)
        {
            DriveValidation.IsEmployeeIdValid(employeeId);
            try
            {
                var DashboardCount = new Dictionary<string, int>();
                DashboardCount.Add("Scheduled Drives", DriveCountForTacByStatus(false, employeeId));
                DashboardCount.Add("Cancelled Drives", DriveCountForTacByStatus(true, employeeId));
                return DashboardCount;
            }
            catch (Exception viewTACDashboardException)
            {
                _logger.LogInformation($"Drive Service : ViewDashboard() : {viewTACDashboardException.Message} : {viewTACDashboardException.StackTrace}");
                throw viewTACDashboardException;
            }
        }
        private int DriveCountForTacByStatus(bool status, int employeeId)
        {
            return (from drive in _driveDataAccess.GetDrivesByStatus(status) where drive.AddedBy == employeeId select drive).Count();
        }

        public Drive ViewDrive(int driveId)
        {
            DriveValidation.IsDriveIdValid(driveId);

            try
            {
                return _driveDataAccess.ViewDrive(driveId);
            }
            catch (ValidationException viewDriveNotValid)
            {
                _logger.LogInformation($"Drive Service : ViewDrive(int driveId) : {viewDriveNotValid.Message} : {viewDriveNotValid.StackTrace}");
                throw viewDriveNotValid;
            }
            catch (Exception viewDriveException)
            {
                _logger.LogInformation($"Drive Service : ViewDrive(int driveId) : {viewDriveException.Message} : {viewDriveException.StackTrace}");
                throw viewDriveException;
            }
        }

        //For Employee Drive Response Entity
        public bool AddResponse(EmployeeDriveResponse response)
        {
            Validation.EmployeeResponseValidation.IsResponseValid(response);

            try
            {
                response.Drive=null;
                response.Employee=null;
                return _driveDataAccess.AddResponseToDatabase(response) ? true : false;
            }
            catch (ValidationException responseNotValid)
            {
                _logger.LogInformation($"EmployeeDriveResponse Service : AddResponse(EmployeeDriveResponse response) : {responseNotValid.Message}");
                throw responseNotValid;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"EmployeeDriveResponse Service : AddResponse(EmployeeDriveResponse response) : {exception.Message}");
                return false;
            }
        }

        public bool UpdateResponse(EmployeeDriveResponse response )
        {
            Validation.EmployeeResponseValidation.IsResponseValid(response);
            try
            {
                return _driveDataAccess.UpdateResponseToDatabase(response) ? true : false;
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
            // employeeAvailability Validation Class
            try
            {
                return _driveDataAccess.SetTimeSlotToDatabase(employeeAvailability);
            }
            catch (ValidationException employeeAvailabilityNotVlaid)
            {
                _logger.LogInformation($"Drive Service : SetTimeSlot(EmployeeAvailability employeeAvailability) : {employeeAvailabilityNotVlaid.Message} : {employeeAvailabilityNotVlaid.StackTrace}");
                return false;
            }
            catch (Exception setTimeSlotException)
            {
                _logger.LogInformation($"Drive Service :SetTimeSlot(EmployeeAvailability employeeAvailability) : {setTimeSlotException.Message} : {setTimeSlotException.StackTrace}");
                return false;
            }
        }
        public Object ViewTodayInterviews()
        {
            try
            {
                return (from interviews in _driveDataAccess.ViewInterviewsByStatus(false) where interviews.InterviewDate.Date == System.DateTime.Now.Date && interviews.IsInterviewScheduled == true select interviews)
                .Select(e => new
                {
                    EmployeeAvailabilityId = e.EmployeeAvailabilityId,
                    DriveName = e.Drive.Name,
                    PoolName = e.Drive.Pool.PoolName,
                    IntervieDate = e.InterviewDate,
                    Mode = "Online",
                    LocationName = e.Drive.Location.LocationName,
                    Status = e.IsInterviewScheduled
                }
                );//filter by user using authentication  
            }
            catch (Exception viewTodayInterviews)
            {
                _logger.LogInformation($"Drive Service : ViewTodayInterviews() : {viewTodayInterviews.Message} : {viewTodayInterviews.StackTrace}");
                throw viewTodayInterviews;
            }
        }
        public Object ViewScheduledInterview()
        {
            try
            {
                return (from interviews in _driveDataAccess.ViewInterviewsByStatus(false) where interviews.InterviewDate.Date > System.DateTime.Now.Date && interviews.IsInterviewScheduled == true select interviews)
                .Select(e => new
                {
                    EmployeeAvailabilityId = e.EmployeeAvailabilityId,
                    DriveName = e.Drive.Name,
                    PoolName = e.Drive.Pool.PoolName,
                    IntervieDate = e.InterviewDate,
                    Mode = "Online",
                    LocationName = e.Drive.Location.LocationName,
                    Status = e.IsInterviewScheduled
                }
                );//filter by user using authentication  

            }
            catch (Exception viewScheduledInterviewException)
            {
                _logger.LogInformation($"Drive Service : ViewScheduledInterview() : {viewScheduledInterviewException.Message} : {viewScheduledInterviewException.StackTrace}");
                throw viewScheduledInterviewException;
            }
        }
        public Object ViewUpcomingInterview()
        {
            try
            {
                return (from interviews in _driveDataAccess.ViewInterviewsByStatus(false) where interviews.InterviewDate.Date > System.DateTime.Now.Date && interviews.IsInterviewScheduled == false select interviews)
                .Select(e => new
                {
                    EmployeeAvailabilityId = e.EmployeeAvailabilityId,
                    DriveName = e.Drive.Name,
                    PoolName = e.Drive.Pool.PoolName,
                    IntervieDate = e.InterviewDate,
                    Mode = "Online",
                    LocationName = e.Drive.Location.LocationName,
                    Status = e.IsInterviewScheduled
                }
                );//filter by user using authentication  

            }
            catch (Exception viewUpcomingInterview)
            {
                _logger.LogInformation($"Drive Service : ViewUpcomingInterview() : {viewUpcomingInterview.Message} : {viewUpcomingInterview.StackTrace}");
                throw viewUpcomingInterview;
            }
        }
        public Object ViewAllInterview()
        {
            try
            {
                return ((from interviews in _driveDataAccess.ViewInterviewsByStatus(false) select interviews).Concat((from interviews in _driveDataAccess.ViewInterviewsByStatus(true) select interviews)))
                .Select(e => new
                {
                    EmployeeAvailabilityId = e.EmployeeAvailabilityId,
                    DriveName = e.Drive.Name,
                    PoolName = e.Drive.Pool.PoolName,
                    IntervieDate = e.InterviewDate,
                    Mode = "Online",
                    LocationName = e.Drive.Location.LocationName,
                    Status = e.IsInterviewScheduled
                }
                );
            }
            catch (Exception viewAllInterview)
            {
                _logger.LogInformation($"Drive Service : ViewAllInterview() : {viewAllInterview.Message} : {viewAllInterview.StackTrace}");
                throw viewAllInterview;
            }

        }

        public bool ScheduleInterview(int employeeAvailabilityId)
        {
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
                throw scheduleInterviewException;
            }
        }

        public bool CancelInterview(int employeeAvailabilityId)
        {
            try
            {
                return _driveDataAccess.CancelInterview(employeeAvailabilityId);
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
                    employeeId = availability.EmployeeId,
                    employeeAceNumber = "ACE0034",
                    emplyeeName = availability.Employee.Name,
                    employeeDepartment = ".NET",
                    employeeRole = "Software Engineer" //ACE ,DEPT NAME,ROLE
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

        public Dictionary<string, int> ViewEmployeeDashboard(int employeeId)
        {
            try
            {
                var DashboardCount = new Dictionary<string, int>();
                DashboardCount.Add("Accepted Interviews", _driveDataAccess.GetResponseCountByStatus(1));
                DashboardCount.Add("Denied Interviews", _driveDataAccess.GetResponseCountByStatus(2));
                DashboardCount.Add("Ignored Interviews", _driveDataAccess.GetResponseCountByStatus(3));
                DashboardCount.Add("Utilized Interviews", _driveDataAccess.GetResponseUtilizationByStatus(true));
                DashboardCount.Add("Not Utilized Interviews", _driveDataAccess.GetResponseUtilizationByStatus(false));
                DashboardCount.Add("Total Interviews", DashboardCount["Accepted Interviews"] + DashboardCount["Denied Interviews"] + DashboardCount["Ignored Interviews"]);
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
                throw viewEmployeeDashboardException;
            }
        }
    }
}


