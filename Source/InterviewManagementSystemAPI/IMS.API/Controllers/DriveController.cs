using System.ComponentModel.DataAnnotations;
using IMS.CustomExceptions;
using IMS.Models;
using IMS.Service;
using IMS.Validations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace IMS.Controllers;


[Authorize]
[ApiController]
[Route("[Controller]/[action]")]
public class DriveController : ControllerBase
{
    private readonly ILogger _logger;
    private IDriveService _driveService;
    private IMailService _mailService;

    public DriveController(ILogger<DriveController> logger, IMailService mailService, IDriveService driveService)
    {
        _logger = logger;
        _mailService = mailService;
        _driveService = driveService;//DataFactory.DriveDataFactory.GetDriveServiceObject(logger);
    }

    /// <summary>
    /// This method is used to create drive
    /// </summary>
    /// <response code="200">If drive was created successfully</response>
    /// <response code="400">If the item is null or validation exception occurs</response> 
    /// <response code="500">If there is problem in server</response>
    /// <param name="drive"></param>
    /// <returns>Returns success message if drive was created or
    /// Returns bad request if validations exception occurs or 
    /// Returns problem if internal error occurs</returns>

    [HttpPost]
    public IActionResult CreateDrive(Drive drive)
    {
        if (drive == null)
            return BadRequest("Drive is Invalid");
        try
        {
            //use authentication and find current user id
            //drive.AddedBy=
            //drive.UpdatedBy=
            if (_driveService.CreateDrive(drive))
            {
                //_mailService.SendEmailAsync(_mailService.DriveInvites(drive, Convert.ToInt32(User.FindFirst("UserId").Value)), false);
                return Ok(UtilityService.Response("Drive Created Successfully"));
            }
            return Problem("Sorry internal error occured");
        }
        catch (ValidationException driveNotValid)
        {
            _logger.LogInformation($"Drive Controller : CreateDrive(Drive drive) : {driveNotValid.Message} : {driveNotValid.StackTrace}");
            return BadRequest(UtilityService.Response(driveNotValid.Message));
        }
        catch (MailException mailException)
        {
            _logger.LogInformation($"Drive Controller : CreateDrive(Drive drive) : {mailException.Message} : {mailException.StackTrace}");
            return Ok("Drive Created Successfully but failed to send email");
        }
        catch (Exception createDriveException)
        {
            _logger.LogInformation($"Drive Controller : CreateDrive(Drive drive) : {createDriveException.Message} : {createDriveException.StackTrace}");
            return Problem("Sorry internal error occured");
        }

    }

    /// <summary>
    /// This method is used to cancel a drive
    /// </summary>
    
    /// <response code="200">If drive was cancelled successfully</response>
    /// <response code="400">If the item is null or validation exception occurs</response> 
    /// <param name="driveId">int</param>
    /// <param name="tacId">int</param>
    /// <param name="reason">string</param>
    /// <returns>Returns success message if drive was cancelled successfully or
    /// Returns Bad request if validtaion exception occurs or
    /// Returns problem if internal error occurs</returns>

    [HttpPatch]
    public IActionResult CancelDrive(int driveId, int tacId, string reason)
    {
        //Tac Id acn be taken using authriozation(remove TacId parameter from controller but not from service and DAL)
        // int TacID = ....
        if (driveId <= 0 || tacId <= 0 || reason.Length <= 0)
            return BadRequest("Provide proper driveId, tacId and reason");

        try
        {
            if (_driveService.CancelDrive(driveId, tacId, reason))
            {
                //_mailService.SendEmailAsync(_mailService.DriveCancelled(driveId, Convert.ToInt32(User.FindFirst("UserId").Value)), false);
                return Ok(UtilityService.Response("Drive Cancelled Sucessfully"));
            }
            return Problem("Sorry internal error occured");
        }
        catch (ValidationException cancelDriveNotValid)
        {
            _logger.LogInformation($"Drive Controller : CancelDrive(int driveId, int tacId, string reason) : {cancelDriveNotValid.Message} : {cancelDriveNotValid.StackTrace}");
            return BadRequest(cancelDriveNotValid.Message);
        }
        catch (MailException mailException)
        {
            _logger.LogInformation($"Drive Controller : CreateDrive(Drive drive) : {mailException.Message} : {mailException.StackTrace}");
            return Ok("Drive Cancelled Successfully but failed to send email");
        }
        catch (Exception cancelDriveException)
        {
            _logger.LogInformation($"Drive Controller : CancelDrive(int driveId, int tacId, string reason) : {cancelDriveException.Message} : {cancelDriveException.StackTrace}");
            return Problem("Sorry internal error occured");
        }

    }

    /// <summary>
    /// This method is used to view today's drives
    /// </summary>
    /// <response code="200">Returns list of today drive</response>
    /// <response code="500">If there is a problem in server</response> 
    /// <returns>Returns list of today drives or
    ///  Returns problem if internal error occurs</returns>

    [HttpGet]
    public IActionResult ViewTodayDrives()
    {
        try
        {
            return Ok(_driveService.ViewTodayDrives());
        }
        catch (Exception viewTodayDrivesException)
        {
            _logger.LogInformation($"Drive Controller : ViewTodayDrives() : {viewTodayDrivesException.Message} : {viewTodayDrivesException.StackTrace}");
            return Problem("Sorry internal error occured");
        }

    }

    /// <summary>
    /// This method invoked by TAC to view the list of Scheduled drives
    /// </summary>
    /// <response code="200">Returns list of scheduled drives</response>
    /// <response code="500">If there is problem in server</response> 
    /// <returns>Returns a list of Scheduled drives or
    /// Returns problem if internal error occurs</returns>

    [HttpGet]
    public IActionResult ViewScheduledDrives()
    {
        try
        {
            return Ok(_driveService.ViewScheduledDrives());
        }
        catch (Exception viewScheduledDrivesException)
        {
            _logger.LogInformation($"Drive Controller : ViewScheduledDrives() : {viewScheduledDrivesException.Message} : {viewScheduledDrivesException.StackTrace}");
            return Problem("Sorry internal error occured");
        }

    }

    /// <summary>
    /// This method invoked by TAC to view the list of Upcoming drives
    /// </summary>
    /// <response code="200">Returns list of upcoming drive</response>
    /// <response code="400">If the item is null</response> 
    /// <returns>Returns a list of Upcoming drives or
    /// Returns problem if internal error occurs</returns>
    [HttpGet]
    public IActionResult ViewUpcomingDrives()
    {
        try
        {
            return Ok(_driveService.ViewUpcomingDrives());
        }
        catch (Exception viewUpcomingDrivesException)
        {
            _logger.LogInformation($"Drive Controller : ViewUpcomingDrives() : {viewUpcomingDrivesException.Message} : {viewUpcomingDrivesException.Message}");
            return Problem("Sorry internal error occured");
        }

    }

    /// <summary>
    /// This method is invoked When the 'ViewNonCancelledDrive' request raises.
    /// </summary>

    /// <response code="200">Returns the newly created item</response>
    /// <response code="400">If the item is null</response> 
    /// <returns>Returns the list of Non Scheduled Drives</returns>

    [HttpGet]
    public IActionResult ViewNonCancelledDrives()
    {
        try
        {
            int tacId = Convert.ToInt32(User.FindFirst("UserId")?.Value);
            return Ok(_driveService.ViewNonCancelledDrives(tacId));
        }
        catch (Exception viewAllScheduledDrivesException)
        {
            _logger.LogInformation($"Drive Controller : ViewAllScheduledDrives() : {viewAllScheduledDrivesException.Message} : {viewAllScheduledDrivesException.StackTrace}");
            return Problem("Sorry internal error occured");
        }

    }
    


    /// <summary>
    /// This method is invoked when the 'View All cancelled drive' request raises.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET/ViewCancelledDrive
    ///     {
    ///       
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response> 
    /// <returns>Returns a list of Cancelled drives</returns>

    [HttpGet]
    public IActionResult ViewAllCancelledDrives()
    {
        try
        {
            int tacId = Convert.ToInt32(User.FindFirst("UserId")?.Value);
            return Ok(_driveService.ViewAllCancelledDrives(tacId));
        }
        catch (Exception viewAllCancelledDrivesException)
        {
            _logger.LogInformation($"Drive Controller : ViewAllCancelledDrives() : {viewAllCancelledDrivesException.Message} : {viewAllCancelledDrivesException.StackTrace} ");
            return Problem("Sorry internal error occured");
        }

    }

    /// <summary>
    /// This method invokes when the 'ViewDrives' request raises
    /// </summary>
    /// <param name="driveId"></param>

    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response> 
    /// <returns>Returns a list of Interview Invites</returns>

    [HttpGet]
    public IActionResult ViewDrive(int driveId)
    {
        if (driveId <= 0)
            return BadRequest($"Provide proper driveId {driveId}");
        try
        {
            return Ok(_driveService.ViewDrive(driveId));
        }
        catch (ValidationException viewDriveNotValid)
        {
            _logger.LogInformation($"Drive Service : ViewDrive(int driveId) : {viewDriveNotValid.Message} : {viewDriveNotValid.StackTrace}");
            return BadRequest(viewDriveNotValid.Message);
        }
        catch (Exception viewDriveException)
        {
            _logger.LogInformation($"Drive Controller : ViewDrive(int driveId) : {viewDriveException.Message} : {viewDriveException.StackTrace}");
            return Problem("Sorry internal error occured");
        }

    }

    /// <summary>
    /// This method invokes when the 'viewInvites' request raises
    /// </summary>
    /// <param name="employeeId"></param>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /ViewInvites
    ///     {
    ///        "Employee Id": "1",
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response> 
    /// <returns>Returns a list of Interview Invites</returns>

    [HttpGet]
    public IActionResult ViewInvites(int employeeId)
    {
        if (employeeId <= 0)
            return BadRequest("provide proper employee Id");
        try
        {
            return Ok(_driveService.ViewDriveInvites(employeeId));
        }
        catch (Exception viewInvitesException)
        {
            _logger.LogInformation($"Drive Controller : ViewInvites(int employeeId) : {viewInvitesException.Message} : {viewInvitesException.StackTrace}");
            return Problem("Sorry internal error occured");
        }
    }
    //
    [HttpGet]
    public IActionResult ViewInvitesByID()
    {
        int currentUser = Convert.ToInt32(User.FindFirst("UserId")?.Value);
        if (currentUser <= 0)
            return BadRequest("provide proper employee Id");
        try
        {
            return Ok(_driveService.ViewDriveInvites(currentUser));
        }
        catch (Exception viewInvitesException)
        {
            _logger.LogInformation($"Drive Controller : ViewInvites(int employeeId) : {viewInvitesException.Message} : {viewInvitesException.StackTrace}");
            return Problem("Sorry internal error occured");
        }
    }

    /// <summary>
    /// This method invokes when a TAC wants to view their dashboard
    /// </summary>
   
    /// <response code="200">Returns dashboard of TAC</response>
    /// <response code="400">If validation exception occurs</response> 
    /// <response code="500">If there is problem in server</response>
   
    /// <returns>Returns the dashboard of TAC</returns>

    [HttpGet]
    public IActionResult ViewDashboard()
    {
        try
        {
            return Ok(_driveService.ViewTACDashboard(Convert.ToInt32(User.FindFirst("UserId")?.Value)));
        }
        catch (ValidationException viewDashboardNotValid)
        {
            _logger.LogInformation($"Drive Service : ViewDashboard(int tacId) : {viewDashboardNotValid.Message} : {viewDashboardNotValid.StackTrace}");
            return BadRequest(viewDashboardNotValid.Message);
        }
        catch (Exception viewDashboardException)
        {
            _logger.LogInformation($"Drive Controller : ViewDashboard(int tacId) : {viewDashboardException.Message} : {viewDashboardException.StackTrace}");
            return Problem("Sorry internal error occured");
        }

    }
    //For Employee Drive Response Entity

    /// <summary>
    /// This method invoked when the employee wants to add aresponse
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /Employee Drive Response
    ///     {
    ///        "Response object": "Response",
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response> 
    /// <param name="response"></param>
    /// <returns>Added a Response</returns>

    [HttpPost]
    public IActionResult AddResponse(EmployeeDriveResponse response)
    {
        if (response == null)
            return BadRequest(UtilityService.Response("Response cannnot be null"));

        try
        {
            response.EmployeeId = Convert.ToInt32(User.FindFirst("UserID")?.Value);
            return _driveService.AddResponse(response) ? Ok(UtilityService.Response("Response added sucessfully")) : Problem("Sorry internal error occured");
        }
        catch (ValidationException addResponseNotValid)
        {
            _logger.LogInformation($"Drive Controller : AddResponse(EmployeeDriveResponse response) : {addResponseNotValid.Message} : {addResponseNotValid.StackTrace}");
            return BadRequest(UtilityService.Response(addResponseNotValid.Message));
        }
        catch (Exception addResponseException)
        {
            _logger.LogInformation($"Drive Controller : AddResponse(EmployeeDriveResponse response) : {addResponseException.Message} : {addResponseException.StackTrace}");
            return Problem("Sorry internal error occured");
        }
    }
    // [HttpPatch]
    // public IActionResult UpdateResponse(EmployeeDriveResponse response)
    // {
    //     if (response == null)
    //         return BadRequest("Response cannnot be null");
    //     try
    //     {
    //         return _driveService.UpdateResponse(response) ? Ok("Response updated sucessfully") : Problem("Sorry internal error occured");
    //     }
    //     catch (ValidationException updateResponseNotValid)
    //     {
    //         _logger.LogInformation($"Drive Controller : UpdateResponse(int employeeId, int driveId, int responseType) : {updateResponseNotValid.Message} : {updateResponseNotValid.StackTrace}");
    //         return BadRequest(updateResponseNotValid.Message);
    //     }
    //     catch (Exception updateResponseException)
    //     {
    //         _logger.LogInformation($"Drive Controller : UpdateResponse(int employeeId, int driveId, int responseType) : {updateResponseException.Message} : {updateResponseException.StackTrace}");
    //         return Problem("Sorry internal error occured");
    //     }
    // }

    /// <summary>
    /// This method is invoked when the interviewer wants to fill the timeslot
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /CreateNewDepartment
    ///     {
    ///        "EmployeeAvailability object": "EmployeeAvailability",
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response> 
    /// <param name="employeeAvailability"></param>
    /// <returns>Filled the timeslot</returns>
    [HttpPost]
    public IActionResult SetTimeSlot(EmployeeAvailability employeeAvailability)
    {
        if (employeeAvailability == null)
            return BadRequest(UtilityService.Response("Invalid employee availability"));
        try
        {
            employeeAvailability.EmployeeId = Convert.ToInt32(User.FindFirst("UserId")?.Value);
            return _driveService.SetTimeSlot(employeeAvailability) ? Ok(UtilityService.Response("Availability recorded sucessfully")) : Problem("Sorry internal error occured");
        }
        catch (ValidationException setTimeSlotNotValid)
        {
            _logger.LogInformation($"Drive Controller : UpdateResponse(int employeeId, int driveId, int responseType) : {setTimeSlotNotValid.Message} : {setTimeSlotNotValid.StackTrace}");
            return BadRequest(UtilityService.Response(setTimeSlotNotValid.Message));
        }
        catch (Exception setTimeSlotException)
        {
            _logger.LogInformation($"Drive Controller : UpdateResponse(int employeeId, int driveId, int responseType) : {setTimeSlotException.Message} : {setTimeSlotException.StackTrace}");
            return Problem("Sorry internal error occured");
        }
    }
    [HttpGet]
    public IActionResult ViewAvailabilty(int driveId)
    {
        try
        {
            int currentUser = Convert.ToInt32(User.FindFirst("UserId")?.Value);
            return Ok(_driveService.ViewAvailabilty(currentUser, driveId));
        }
        catch (Exception exception)
        {
            _logger.LogInformation($"Drive Controller : viewAvailabilty() : {exception.Message} : {exception.StackTrace}");
            return Problem("Sorry internal error occured");
        }

    }

    /// <summary>
    /// This method invoked when the view today's interviews request raise.
    /// </summary>
   
    /// <response code="201">Returs list of today's interview</response>
    /// <response code="500">If there is problem in server </response> 
  
    /// <returns>Returns a list of today's interviews</returns>

    [HttpGet]
    public IActionResult ViewTodaysInterview()
    {
        try
        {
            int currentUser = Convert.ToInt32(User.FindFirst("UserId")?.Value);
            return Ok(_driveService.ViewTodayInterviews(currentUser));
        }
        catch (Exception viewTodaysInterviewException)
        {
            _logger.LogInformation($"Drive Controller : ViewTodaysInterview() : {viewTodaysInterviewException.Message} : {viewTodaysInterviewException.StackTrace}");
            return Problem("Sorry internal error occured");
        }
    }

    /// <summary>
    /// This method is invoked when the 'View Scheduled interviews' request raises
    /// </summary>
    /// <response code="200">Returns list of scheduled interviews</response>
    /// <response code="500">If there is problem in server</response> 
    
    /// <returns>Returns a list of Scheduled Interviews</returns>
    [HttpGet]
    public IActionResult ViewScheduledInterview()
    {
        try
        {
            int currentUser = Convert.ToInt32(User.FindFirst("UserId")?.Value);
            return Ok(_driveService.ViewScheduledInterview(currentUser));
        }
        catch (Exception viewScheduledInterviewException)
        {
            _logger.LogInformation($"Drive Controller : ViewScheduledInterview() : {viewScheduledInterviewException.Message} : {viewScheduledInterviewException.StackTrace}");
            return Problem("Sorry internal error occured");
        }
    }
      [HttpGet]
    public IActionResult ViewCancelledInterview()
    {
        try
        {
            int currentUser = Convert.ToInt32(User.FindFirst("UserId")?.Value);
            return Ok(_driveService.ViewCancelledInterview(currentUser));
        }
        catch (Exception viewScheduledInterviewException)
        {
            _logger.LogInformation($"Drive Controller : ViewCancelledInterview() : {viewScheduledInterviewException.Message} : {viewScheduledInterviewException.StackTrace}");
            return Problem("Sorry internal error occured");
        }
    }


    /// <summary>
    /// This method is implemented when the 'ViewUpcomingInterviews' request raises.
    /// </summary>
    /// <response code="200">Returns list of upcoming interviews</response>
    /// <response code="400">If there is problem in server</response> 
   
    /// <returns>Returns a list of Upcoming Interviews</returns>

    [HttpGet]
    public IActionResult ViewUpcomingInterview()
    {
        try
        {
            int currentUser = Convert.ToInt32(User.FindFirst("UserId")?.Value);
            return Ok(_driveService.ViewUpcomingInterview(currentUser));
        }
        catch (Exception viewUpcomingInterviewException)
        {
            _logger.LogInformation($"Drive Controller : ViewUpcomingInterview() : {viewUpcomingInterviewException.Message} : {viewUpcomingInterviewException.StackTrace}");
            return Problem("Sorry internal error occured");
        }
    }

    /// <summary>
    /// This Method is invoked when 'ViewAllInterviews' request raise
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /ViewAllInterviews
    ///     {
    ///        "Employee Id": "1",
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response> 
    /// <param name="employeeId"></param>
    /// <returns>Returns a list of interviews</returns>

    [HttpGet]
    public IActionResult ViewAllInterview(int employeeId)
    {
        if (employeeId <= 0)
            return BadRequest("provide proper employee Id");
        try
        {
            return Ok(_driveService.ViewAllInterview(employeeId));
        }
        catch (Exception viewAllInterviewException)
        {
            _logger.LogInformation($"Drive Controller : ViewAllInterview() : {viewAllInterviewException.Message} : {viewAllInterviewException.StackTrace} ");
            return Problem("Sorry internal error occured");
        }
    }

    /// <summary>
    /// This method is invoked when 'view scheduled interview' request
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     Patch /ViewScheduledInterview
    ///     {
    ///        "Employeeavailability": "1",
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response> 
    /// <param name="employeeAvailabilityId"></param>
    /// <returns>Returns a list of scheduled interviews</returns>

    [HttpPatch]
    public IActionResult ScheduleInterview(int employeeAvailabilityId)
    {
        if (employeeAvailabilityId <= 0)
            return BadRequest("provide proper employee availability Id");
        try
        {
            if (_driveService.ScheduleInterview(employeeAvailabilityId))
            {
                //_mailService.SendEmailAsync(_mailService.InterviewScheduled(employeeAvailabilityId, Convert.ToInt32(User.FindFirst("UserId").Value)), true);
                return Ok(UtilityService.Response("Interview Scheduled Sucessfully"));
            }
            return Problem("Sorry internal error occured");
        }
        catch (ValidationException scheduleInterviewNotValid)
        {
            _logger.LogInformation($"Drive Controller : ScheduleInterview(int employeeAvailabilityId) : {scheduleInterviewNotValid.Message} : {scheduleInterviewNotValid.StackTrace}");
            return BadRequest(scheduleInterviewNotValid.Message);
        }
        catch (MailException mailException)
        {
            _logger.LogInformation($"Drive Controller : CreateDrive(Drive drive) : {mailException.Message} : {mailException.StackTrace}");
            return Ok("Interview Scheduled Sucessfully but failed to send email");
        }
        catch (Exception scheduleInterviewException)
        {
            _logger.LogInformation($"Drive Controller : ScheduleInterview(int employeeAvailabilityId) : {scheduleInterviewException.Message} : {scheduleInterviewException.StackTrace}");
            return Problem("Sorry internal error occured");
        }
    }

    /// <summary>
    /// This method invokes when the employee needs to cancel the availability 
    /// </summary>
    /// <response code="200">Returns list of canceled interview</response>
    /// <response code="400">If there is validation exception occurs</response>
    /// <response code="500">If there is problem in server</response>
    /// <param name="employeeAvailabilityId"></param>
    /// <param name="cancellationReason"></param>
    /// <param name="comments"></param>
    /// <returns>Returns list of cancelled interview or 
    /// Returns bad request when validtaion exception occurs or
    /// Returns problem if internal error occurs</returns>

    [HttpPatch]
    public IActionResult CancelInterview(int employeeAvailabilityId, string cancellationReason, string? comments)
    {
        if (employeeAvailabilityId <= 0)
            return BadRequest("provide proper driveId, employeeId and responseType");
        try
        {
            if (_driveService.CancelInterview(employeeAvailabilityId, cancellationReason, comments))
            {
                //_mailService.SendEmailAsync(_mailService.InterviewCancelled(employeeAvailabilityId), true);
                return Ok(UtilityService.Response("Availability Cancelled Sucessfully"));
            }
            return Problem("Sorry internal error occured");
        }
        catch (ValidationException CancelInterviewNotValid)
        {
            _logger.LogInformation($"Drive Controller : CancelInterview(int employeeAvailabilityId) : {CancelInterviewNotValid.Message} : {CancelInterviewNotValid.StackTrace}");
            return BadRequest(UtilityService.Response(CancelInterviewNotValid.Message));
        }
        catch (MailException mailException)
        {
            _logger.LogInformation($"Drive Controller : CreateDrive(Drive drive) : {mailException.Message} : {mailException.StackTrace}");
            return Ok("Availability Cancellerd Sucessfully but failed to send email");
        }
        catch (Exception CancelInterviewException)
        {
            _logger.LogInformation($"Drive Controller : CancelInterview(int employeeAvailabilityId) : {CancelInterviewException.Message} : {CancelInterviewException.StackTrace}");
            return Problem("Sorry internal error occured");
        }
    }

    /// <summary>
    /// This method invoked when the list of members available for the particular drive
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /ViewAvailableMembersForDrive
    ///     {
    ///        "DriveId": "1",
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response> 
    /// <param name="driveId"></param>
    /// <returns>Returns a list of available members for the particuler drive</returns>
    [HttpGet]
    public IActionResult ViewAvailableMembersForDrive(int driveId)
    {
        if (driveId <= 0)
            return BadRequest("provide proper driveId");
        try
        {
            return Ok(_driveService.ViewAvailableMembersForDrive(driveId));
        }
        catch (ValidationException viewAvailableMembersForDriveNotValid)
        {
            _logger.LogInformation($"Drive Controller : ViewAvailableMembersForDrive(int driveId) : {viewAvailableMembersForDriveNotValid.Message} : {viewAvailableMembersForDriveNotValid.StackTrace}");
            return BadRequest(viewAvailableMembersForDriveNotValid.Message);
        }
        catch (Exception viewAvailableMembersForDriveException)
        {
            _logger.LogInformation($"Drive Controller : ViewAvailableMembersForDrive(int driveId) : {viewAvailableMembersForDriveException.Message} : {viewAvailableMembersForDriveException.StackTrace}");
            return Problem("Sorry internal error occured");
        }
    }
      [HttpGet]
    public IActionResult ViewEmployeePerformance(DateTime fromDate, DateTime toDate)
    {
        try
        {
            int employeeId = Convert.ToInt32(User.FindFirst("UserId")?.Value);
            int departmentId=Convert.ToInt32(User.FindFirst("DepartmentId")?.Value);

            return Ok(_driveService.ViewEmployeePerformance(employeeId,departmentId, fromDate, toDate));
        }
        catch (ValidationException ViewEmployeeDashboardNotValid)
        {
            _logger.LogInformation($"Drive Controller : ViewEmployeePerformance(DateTime fromDate, DateTime toDate) : {ViewEmployeeDashboardNotValid.Message}");
            return BadRequest(ViewEmployeeDashboardNotValid.Message);
        }
        catch (Exception ViewEmployeeDashboardException)
        {
            _logger.LogInformation($"Drive Controller : ViewEmployeeDashboard(int employeeId) : {ViewEmployeeDashboardException.Message}");
            return Problem("Sorry internal error occured");
        }
    }

 

    /// <summary>
    /// This method invoked when the employee wants to see their dashboard
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /ViewEmployueeDashboard
    ///     {
    ///        "Employee Id": "1",
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response> 
    /// <param name="departmentId"></param>
    /// <param name="fromDate"></param>
    /// <param name="toDate"></param>
    /// <returns>Returns the dashboard of employee</returns>
    [HttpGet]
    public IActionResult ViewEmployeeDashboard(int departmentId, DateTime fromDate, DateTime toDate)
    {
        try
        {
            int employeeId = Convert.ToInt32(User.FindFirst("UserId")?.Value);

            return Ok(_driveService.ViewEmployeeDashboard(employeeId,departmentId, fromDate, toDate));
        }
        catch (ValidationException ViewEmployeeDashboardNotValid)
        {
            _logger.LogInformation($"Drive Controller : ViewEmployeeDashboard(int employeeId) : {ViewEmployeeDashboardNotValid.Message}");
            return BadRequest(ViewEmployeeDashboardNotValid.Message);
        }
        catch (Exception ViewEmployeeDashboardException)
        {
            _logger.LogInformation($"Drive Controller : ViewEmployeeDashboard(int employeeId) : {ViewEmployeeDashboardException.Message}");
            return Problem("Sorry internal error occured");
        }
    }

   /// <summary>
   /// This method is used to view  list of drives
   /// </summary>
   /// <response code="200">Returns list of total drives</response>
    /// <response code="500">If there is problem in server</response> 
   /// <param name="fromDate">DateTime</param>
   /// <param name="toDate">DateTime</param>
   /// <returns>Returns the dashboard of employee</returns>

    [HttpGet]
    public IActionResult ViewTotalDrives(DateTime fromDate, DateTime toDate)
    {
        try
        {
            int employeeId = Convert.ToInt32(User.FindFirst("UserId")?.Value);
            return Ok(_driveService.ViewTotalDrives(employeeId, fromDate, toDate));
        }
        catch (Exception viewTotalDrivesException)
        {
            _logger.LogInformation($"Drive Controller : ViewEmployeeDashboard(int employeeId) : {viewTotalDrivesException.Message}");
            return Problem("Sorry internal error occured");
        }
    }

    /// <summary>
    /// This method invoked when the employee wants to see their Accepted Drive
    /// </summary>
    /// <response code="200">Returns list of accepted drives</response>
    /// <response code="500">If there is problem in server</response>
    /// <param name="fromDate"></param>
    /// <param name="toDate"></param>
    /// <returns>Returns list of accepted drives</returns>

    [HttpGet]
    public IActionResult ViewAcceptedDrives(DateTime fromDate, DateTime toDate)
    {
        try
        {
            int employeeId = Convert.ToInt32(User.FindFirst("UserId")?.Value);
            return Ok(_driveService.ViewAcceptedDrives(employeeId, fromDate, toDate));
        }
        catch (Exception viewAcceptedDrivesException)
        {
            _logger.LogInformation($"Drive Controller : ViewEmployeeDashboard(int employeeId) : {viewAcceptedDrivesException.Message}");
            return Problem("Sorry internal error occured");
        }
    }
    /// <summary>
    /// This method invoked when the employee wants to see their Denied drives
    /// </summary>
    /// <response code="200">If it returns list of denied drives</response>
    /// <response code="500">If there is problem</response> 
    /// <param name="fromDate">DateTime</param>
    /// <param name="toDate">DateTime</param>
    /// <returns>Returns list of denied drives</returns>
    [HttpGet]
    public IActionResult ViewDeniedDrives(DateTime fromDate, DateTime toDate)
    {
        try
        {
            int employeeId = Convert.ToInt32(User.FindFirst("UserId")?.Value);
            return Ok(_driveService.ViewDeniedDrives(employeeId, fromDate, toDate));
        }
        catch (Exception viewDeniedDrivesNotValid)
        {
            _logger.LogInformation($"Drive Controller : ViewDeniedDrives() : {viewDeniedDrivesNotValid.Message}");
            return Problem("Sorry internal error occured");
        }
    }
    /// <summary>
    /// This method invoked when the employee wants to see their Ignored Drives
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /ViewEmployueeDashboard
    ///     {
    ///        "Employee Id": "1",
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response> 
    /// <param name="fromDate"></param>
    /// <param name="toDate"></param>
    /// <returns>Returns the dashboard of employee</returns>


    [HttpGet]
    public IActionResult ViewIgnoredDrives(DateTime fromDate, DateTime toDate)
    {
        try
        {
            int employeeId = Convert.ToInt32(User.FindFirst("UserId")?.Value);
            return Ok(_driveService.ViewIgnoredDrives(employeeId, fromDate, toDate));
        }
        catch (Exception viewIgnoredDrivesNotValid)
        {
            _logger.LogInformation($"Drive Controller : ViewDeniedDrives() : {viewIgnoredDrivesNotValid.Message}");
            return Problem("Sorry internal error occured");
        }
    }

    /// <summary>
    /// This method invoked when the employee wants to see their Utilized Slots
    /// </summary>
  
    /// <response code="200">If it returns list of utilized interviews</response>
    /// <response code="500">If there is problem in server</response> 
    /// <returns>Returns list of utilized interviews or 
    /// Returns problem if some internal problem occurs</returns>

    [HttpGet]
    public IActionResult ViewUtilizedInterviews()
    {
        try
        {
            int employeeId = Convert.ToInt32(User.FindFirst("UserId")?.Value);
            return Ok(_driveService.ViewUtilizedInterviews(employeeId));
        }
        catch (Exception viewUtilizedInterviewsNotValid)
        {
            _logger.LogInformation($"Drive Controller : ViewDeniedDrives() : {viewUtilizedInterviewsNotValid.Message}");
            return Problem("Sorry internal error occured");
        }
    }

    /// <summary>
    /// This method invoked when the employee wants to see their Not Utilized Slots
    /// </summary>
    /// <response code="201">If it returns list of not utilized interviews</response>
    /// <response code="500">If there is problem in server</response> 
  
    /// <returns>Returns list of not utilized interviews </returns>

    [HttpGet]
    public IActionResult ViewNotUtilizedInterviews()
    {

        try
        {
            int employeeId = Convert.ToInt32(User.FindFirst("UserId")?.Value);
            return Ok(_driveService.ViewNotUtilizedInterviews(employeeId));
        }
        catch (Exception viewNotUtilizedInterviewsException)
        {
            _logger.LogInformation($"Drive Controller : ViewDeniedDrives() : {viewNotUtilizedInterviewsException.Message}");
            return Problem("Sorry internal error occured");
        }
    }

    /// <summary>
    /// This method invoked when the employee wants to see their Total Availability
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /ViewEmployueeDashboard
    ///     {
    ///        "Employee Id": "1",
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response> 
  
    /// <returns>Returns the dashboard of employee</returns>

    [HttpGet]
    public IActionResult ViewTotalAvailability()
    {
        try
        {
            int employeeId = Convert.ToInt32(User.FindFirst("UserId")?.Value);
            return Ok(_driveService.ViewTotalAvailability(employeeId));
        }
        catch (Exception viewTotalAvailabilityException)
        {
            _logger.LogInformation($"Drive Controller : ViewDeniedDrives() : {viewTotalAvailabilityException.Message}");
            return Problem("Sorry internal error occured");
        }
    }

    [HttpGet]
    public IActionResult ViewDefaulters(int poolId)
    {
        if (poolId <= 0)
            return BadRequest("provide proper poolId");
        try
        {
            return Ok(_driveService.ViewDefaulters(poolId));
        }
        catch (Exception viewTotalAvailabilityException)
        {
            _logger.LogInformation($"Drive Controller : ViewDeniedDrives() : {viewTotalAvailabilityException.Message}");
            return Problem("Sorry internal error occured");
        }
    }
    
    [HttpGet]
    public IActionResult ViewDriveResponse(int driveId)
    {
        if (driveId <= 0)
        {
            return BadRequest(UtilityService.Response("provide proper driveId"));
        }
        try
        {
            return Ok(_driveService.ViewDriveResponse(driveId));
        }
        catch (Exception ViewDriveResponseException)
        {
            _logger.LogInformation($"Drive Controller : ViewDriveResponseException(driveId) : {ViewDriveResponseException.Message}");
            return Problem("Sorry internal error occured");
        }
    }
    [HttpGet]
    public IActionResult GetDrivesForCurrentUser()
    {
        try
        {
            int departmentId = Convert.ToInt32(User.FindFirst("DepartmentId")?.Value);
            return Ok(_driveService.GetDrivesForCurrentUser(departmentId));
        }
        catch (Exception ViewDriveResponseException)
        {
            _logger.LogInformation($"Drive Controller : ViewDriveResponseException(driveId) : {ViewDriveResponseException.Message}");
            return Problem("Sorry internal error occured");
        }
    }
}
