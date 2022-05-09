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
                return false;
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
                return false;
            }
            catch (Exception cancelDriveException)
            {
                _logger.LogInformation($"Drive Service : CancelDrive() : {cancelDriveException.Message} : {cancelDriveException.StackTrace}");
                return false;
            }

        }

        public List<Drive> ViewTodayDrives()
        {
            try
            {
                return (from drive in _driveDataAccess.GetDrivesByStatus(false) where (drive.FromDate.Date <= System.DateTime.Now.Date && drive.ToDate.Date >= System.DateTime.Now.Date) && drive.IsScheduled == true select drive).ToList();
            }
            catch (Exception viewTodayDrivesException)
            {
                _logger.LogInformation($"Drive Service : ViewTodayDrives() : {viewTodayDrivesException.Message} : {viewTodayDrivesException.StackTrace}");
                throw viewTodayDrivesException;
            }

        }

        public List<Drive> ViewScheduledDrives()
        {
            try
            {
                return (from drive in _driveDataAccess.GetDrivesByStatus(false) where drive.FromDate.Date != System.DateTime.Now.Date && drive.IsScheduled == true select drive).ToList();
            }
            catch (Exception viewScheduledDrivesException)
            {
                _logger.LogInformation($"Drive Service : ViewScheduledDrives() : {viewScheduledDrivesException.Message} : {viewScheduledDrivesException.StackTrace}");
                throw viewScheduledDrivesException;
            }

        }

        public List<Drive> ViewUpcommingDrives()
        {
            try
            {
                return (from drive in _driveDataAccess.GetDrivesByStatus(false) where drive.FromDate.Date != System.DateTime.Now.Date && drive.IsScheduled == false select drive).ToList();
            }
            catch (Exception viewUpcommingDrivesException)
            {
                _logger.LogInformation($"Drive Service : ViewUpcommingDrives() : {viewUpcommingDrivesException.Message} : {viewUpcommingDrivesException.StackTrace}");
                throw viewUpcommingDrivesException;
            }

        }

        public List<Drive> ViewAllScheduledDrives()
        {
            try
            {
                return (from drive in _driveDataAccess.GetDrivesByStatus(false) select drive).ToList();
            }
            catch (Exception viewAllScheduledDrivesException)
            {
                _logger.LogInformation($"Drive Service : ViewAllScheduledDrives() : {viewAllScheduledDrivesException.Message} : {viewAllScheduledDrivesException.StackTrace}");
                throw viewAllScheduledDrivesException;
            }
        }

        public List<Drive> ViewAllCancelledDrives()
        {
            try
            {
                return (from drive in _driveDataAccess.GetDrivesByStatus(true) select drive).ToList();
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
            catch (Exception exception)
            {
                _logger.LogInformation($"Drive Service : ViewDashboard() : {exception.Message}");
                throw exception;
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
            catch (Exception exception)
            {
                _logger.LogInformation($"Drive Service : ViewDashboard() : {exception.Message}");
                throw exception;
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
            catch (Exception exception)
            {
                _logger.LogInformation($"Drive Service : ViewDashboard() : {exception.Message}");
                throw exception;
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
            catch (Exception exception)
            {
                _logger.LogInformation($"Drive Service : ViewDashboard() : {exception.Message}");
                throw exception;
            }

        }

        public bool ScheduleInterview(int employeeAvailabilityId)
        {
            try
            {
                return _driveDataAccess.ScheduleInterview(employeeAvailabilityId);
            }
            catch (ValidationException employeeAvailabilityNotVlaid)
            {
                _logger.LogInformation($"Drive Service : CancelDrive() : {employeeAvailabilityNotVlaid.Message}");
                throw employeeAvailabilityNotVlaid;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Drive Service : CancelDrive() : {exception.Message}");
                throw exception;
            }
        }

        public bool CancelInterview(int employeeAvailabilityId)
        {
            try
            {
                return _driveDataAccess.CancelInterview(employeeAvailabilityId);
            }
            catch (ValidationException employeeAvailabilityNotVlaid)
            {
                _logger.LogInformation($"Drive Service : CancelDrive() : {employeeAvailabilityNotVlaid.Message}");
                return false;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Drive Service : CancelDrive() : {exception.Message}");
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
            catch (ValidationException employeeAvailabilityNotVlaid)
            {
                _logger.LogInformation($"Drive Service : CancelDrive() : {employeeAvailabilityNotVlaid.Message}");
                return false;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Drive Service : CancelDrive() : {exception.Message}");
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
            catch (ValidationException employeeAvailabilityNotVlaid)
            {
                _logger.LogInformation($"Drive Service : CancelDrive() : {employeeAvailabilityNotVlaid.Message}");
                throw employeeAvailabilityNotVlaid;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Drive Service : CancelDrive() : {exception.Message}");
                throw exception;
            }
        }
    }
}


