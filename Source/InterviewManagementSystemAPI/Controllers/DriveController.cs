using System.ComponentModel.DataAnnotations;
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
    private MailService _mailService;
    public DriveController(ILogger<DriveController> logger,MailService mailService)
    {
        _logger = logger;
        _mailService = mailService;
        _driveService = DataFactory.DriveDataFactory.GetDriveServiceObject(logger);
    }


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
            if(_driveService.CreateDrive(drive))
            {
                _mailService.SendEmailAsync(_mailService.DriveInvites(drive,Convert.ToInt32(User.FindFirst("UserId").Value)),false);
                return Ok("Drive Created Successfully");
            }
            return Problem("Sorry internal error occured");
        }
        catch (ValidationException driveNotValid)
        {
            _logger.LogInformation($"Drive Controller : CreateDrive(Drive drive) : {driveNotValid.Message} : {driveNotValid.StackTrace}");
            return BadRequest(driveNotValid.Message);
        }
        catch (Exception createDriveException)
        {
            _logger.LogInformation($"Drive Controller : CreateDrive(Drive drive) : {createDriveException.Message} : {createDriveException.StackTrace}");
            return Problem("Sorry internal error occured");
        }

    }

    [HttpPatch]
    public IActionResult CancelDrive(int driveId, int tacId, string reason)
    {
        //Tac Id acn be taken using authriozation(remove TacId parameter from controller but not from service and DAL)
        // int TacID = ....
        if (driveId <= 0 || tacId <= 0 || reason.Length <= 0)
            return BadRequest("Provide proper driveId, tacId and reason");

        try
        {
            return _driveService.CancelDrive(driveId, tacId, reason) ? Ok("Drive Cancelled Sucessfully") : Problem("Sorry internal error occured");
        }
        catch (ValidationException cancelDriveNotValid)
        {
            _logger.LogInformation($"Drive Controller : CancelDrive(int driveId, int tacId, string reason) : {cancelDriveNotValid.Message} : {cancelDriveNotValid.StackTrace}");
            return BadRequest(cancelDriveNotValid.Message);
        }
        catch (Exception cancelDriveException)
        {
            _logger.LogInformation($"Drive Controller : CancelDrive(int driveId, int tacId, string reason) : {cancelDriveException.Message} : {cancelDriveException.StackTrace}");
            return Problem("Sorry internal error occured");
        }

    }

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
    [HttpGet]
    public IActionResult ViewUpcommingDrives()
    {
        try
        {
            return Ok(_driveService.ViewUpcommingDrives());
        }
        catch (Exception viewUpcommingDrivesException)
        {
            _logger.LogInformation($"Drive Controller : ViewUpcommingDrives() : {viewUpcommingDrivesException.Message} : {viewUpcommingDrivesException.Message}");
            return Problem("Sorry internal error occured");
        }

    }

    [HttpGet]
    public IActionResult ViewNonCancelledDrives()
    {
        try
        {
            return Ok(_driveService.ViewNonCancelledDrives());
        }
        catch (Exception viewAllScheduledDrivesException)
        {
            _logger.LogInformation($"Drive Controller : ViewAllScheduledDrives() : {viewAllScheduledDrivesException.Message} : {viewAllScheduledDrivesException.StackTrace}");
            return Problem("Sorry internal error occured");
        }

    }
    [HttpGet]
    public IActionResult ViewAllCancelledDrives()
    {
        try
        {
            return Ok(_driveService.ViewAllCancelledDrives());
        }
        catch (Exception viewAllCancelledDrivesException)
        {
            _logger.LogInformation($"Drive Controller : ViewAllCancelledDrives() : {viewAllCancelledDrivesException.Message} : {viewAllCancelledDrivesException.StackTrace} ");
            return Problem("Sorry internal error occured");
        }

    }
    // [HttpGet]
    // public IActionResult ViewDrive(int driveId)
    // {
    //     if (driveId <= 0)
    //         return BadRequest($"Provide proper driveId {driveId}");
    //     try
    //     {
    //         return Ok(_driveService.ViewDrive(driveId));
    //     }
    //     catch (ValidationException viewDriveNotValid)
    //     {
    //         _logger.LogInformation($"Drive Service : ViewDrive(int driveId) : {viewDriveNotValid.Message} : {viewDriveNotValid.StackTrace}");
    //         return BadRequest(viewDriveNotValid.Message);
    //     }
    //     catch (Exception viewDriveException)
    //     {
    //         _logger.LogInformation($"Drive Controller : ViewDrive(int driveId) : {viewDriveException.Message} : {viewDriveException.StackTrace}");
    //         return Problem("Sorry internal error occured");
    //     }

    // }
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

    [HttpGet]
    public IActionResult ViewDashboard(int tacId)
    {
        if (tacId <= 0)
            return BadRequest($"Provide proper Tac Id {tacId}");
        try
        {
            return Ok(_driveService.ViewTACDashboard(tacId));
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
    [HttpPost]
    public IActionResult AddResponse(EmployeeDriveResponse response)
    {
        if (response == null)
            return BadRequest("Response cannnot be null");

        try
        {
            return _driveService.AddResponse(response) ? Ok("Response added sucessfully") : Problem("Sorry internal error occured");
        }
        catch (ValidationException addResponseNotValid)
        {
            _logger.LogInformation($"Drive Controller : AddResponse(EmployeeDriveResponse response) : {addResponseNotValid.Message} : {addResponseNotValid.StackTrace}");
            return BadRequest(addResponseNotValid.Message);
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
    [HttpPost]
    public IActionResult SetTimeSlot(EmployeeAvailability employeeAvailability)
    {
        if (employeeAvailability == null)
            return BadRequest("Invalid employee availability");
        try
        {
            return _driveService.SetTimeSlot(employeeAvailability) ? Ok("Availability recorded sucessfully") : Problem("Sorry internal error occured");
        }
        catch (ValidationException setTimeSlotNotValid)
        {
            _logger.LogInformation($"Drive Controller : UpdateResponse(int employeeId, int driveId, int responseType) : {setTimeSlotNotValid.Message} : {setTimeSlotNotValid.StackTrace}");
            return BadRequest(setTimeSlotNotValid.Message);
        }
        catch (Exception setTimeSlotException)
        {
            _logger.LogInformation($"Drive Controller : UpdateResponse(int employeeId, int driveId, int responseType) : {setTimeSlotException.Message} : {setTimeSlotException.StackTrace}");
            return Problem("Sorry internal error occured");
        }
    }
    [HttpGet]
    public IActionResult ViewTodaysInterview(int employeeId)
    {
        if (employeeId <= 0)
            return BadRequest("provide proper employee Id");
        try
        {
            return Ok(_driveService.ViewTodayInterviews(employeeId));
        }
        catch (Exception viewTodaysInterviewException)
        {
            _logger.LogInformation($"Drive Controller : ViewTodaysInterview() : {viewTodaysInterviewException.Message} : {viewTodaysInterviewException.StackTrace}");
            return Problem("Sorry internal error occured");
        }
    }
    [HttpGet]
    public IActionResult ViewScheduledInterview(int employeeId)
    {
        if (employeeId <= 0)
            return BadRequest("provide proper employee Id");
        try
        {
            return Ok(_driveService.ViewScheduledInterview(employeeId));
        }
        catch (Exception viewScheduledInterviewException)
        {
            _logger.LogInformation($"Drive Controller : ViewScheduledInterview() : {viewScheduledInterviewException.Message} : {viewScheduledInterviewException.StackTrace}");
            return Problem("Sorry internal error occured");
        }
    }
    [HttpGet]
    public IActionResult ViewUpcomingInterview(int employeeId)
    {
        if (employeeId <= 0)
            return BadRequest("provide proper employee Id");
        try
        {
            return Ok(_driveService.ViewUpcomingInterview(employeeId));
        }
        catch (Exception viewUpcomingInterviewException)
        {
            _logger.LogInformation($"Drive Controller : ViewUpcomingInterview() : {viewUpcomingInterviewException.Message} : {viewUpcomingInterviewException.StackTrace}");
            return Problem("Sorry internal error occured");
        }
    }
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

    [HttpPatch]
    public IActionResult ScheduleInterview(int employeeAvailabilityId)
    {
        if (employeeAvailabilityId <= 0)
            return BadRequest("provide proper employee availability Id");
        try
        {
            return Ok(_driveService.ScheduleInterview(employeeAvailabilityId));
        }
        catch (ValidationException scheduleInterviewNotValid)
        {
            _logger.LogInformation($"Drive Controller : ScheduleInterview(int employeeAvailabilityId) : {scheduleInterviewNotValid.Message} : {scheduleInterviewNotValid.StackTrace}");
            return BadRequest(scheduleInterviewNotValid.Message);
        }
        catch (Exception scheduleInterviewException)
        {
            _logger.LogInformation($"Drive Controller : ScheduleInterview(int employeeAvailabilityId) : {scheduleInterviewException.Message} : {scheduleInterviewException.StackTrace}");
            return Problem("Sorry internal error occured");
        }
    }
    [HttpPatch]
    public IActionResult CancelInterview(int employeeAvailabilityId)
    {
        if (employeeAvailabilityId <= 0)
            return BadRequest("provide proper driveId, employeeId and responseType");
        try
        {
            return Ok(_driveService.CancelInterview(employeeAvailabilityId));
        }
        catch (ValidationException CancelInterviewNotValid)
        {
            _logger.LogInformation($"Drive Controller : CancelInterview(int employeeAvailabilityId) : {CancelInterviewNotValid.Message} : {CancelInterviewNotValid.StackTrace}");
            return BadRequest(CancelInterviewNotValid.Message);
        }
        catch (Exception CancelInterviewException)
        {
            _logger.LogInformation($"Drive Controller : CancelInterview(int employeeAvailabilityId) : {CancelInterviewException.Message} : {CancelInterviewException.StackTrace}");
            return Problem("Sorry internal error occured");
        }
    }
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
    public IActionResult ViewEmployeeDashboard(int employeeId)
    {
        if (employeeId <= 0)
            return BadRequest("provide proper employeeId");
        try
        {
            return Ok(_driveService.ViewEmployeeDashboard(employeeId));
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

}
