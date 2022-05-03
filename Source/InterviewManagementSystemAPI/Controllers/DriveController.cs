using IMS.Models;
using IMS.Service;
using Microsoft.AspNetCore.Mvc;
namespace IMS.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class DriveController : ControllerBase
{
    private readonly ILogger _logger;
    private IDriveService _driveService;
    public DriveController(ILogger<DriveController> logger)
    {
        _logger = logger;
        _driveService = DataFactory.DriveDataFactory.GetDriveServiceObject(logger);
    }
    

    [HttpPost]
    public IActionResult CreateDrive(Drive drive)
    {
        if (ModelState.IsValid)
            return BadRequest("Drive is not valid");
        try
        {
            return _driveService.CreateDrive(drive) ? Ok("Drive Created Successfully") : Problem("controller : Sorry internal error occured");
        }
        catch (Exception exception)
        {
            return Problem(exception.Message);
        }

    }

    [HttpPost]
    public IActionResult CancelDrive(int driveId, int tacId, string reason)
    {
        if (driveId == 0 || tacId == 0 || reason.Length == 0)
            return BadRequest("provide proper driveId, tacId and reason");

        try
        {
            return _driveService.CancelDrive(driveId, tacId, reason) ? Ok("Drive Cancelled Sucessfully") : Problem("controller - cancel drive : Sorry internal error occured");
        }
        catch (Exception exception)
        {
            return Problem(exception.Message);
        }

    }

    [HttpGet]
    public IActionResult ViewTodayDrives()
    {
        try
        {
            return Ok(_driveService.ViewTodayDrives());
        }
        catch (Exception exception)
        {
            return Problem(exception.Message);
        }

    }

    [HttpGet]
    public IActionResult ViewScheduledDrives()
    {
        try
        {
            return Ok(_driveService.ViewScheduledDrives());
        }
        catch (Exception exception)
        {
            return Problem(exception.Message);
        }

    }
    [HttpGet]
    public IActionResult ViewUpcommingDrives()
    {
        try
        {
            return Ok(_driveService.ViewUpcommingDrives());
        }
        catch (Exception exception)
        {
            return Problem(exception.Message);
        }

    }

    [HttpGet]
    public IActionResult ViewAllScheduledDrives()
    {
        try
        {
            return Ok(_driveService.ViewAllScheduledDrives());
        }
        catch (Exception exception)
        {
            return Problem(exception.Message);
        }

    }
    [HttpGet]
    public IActionResult ViewAllCancelledDrives()
    {
        try
        {
            return Ok(_driveService.ViewAllCancelledDrives());
        }
        catch (Exception exception)
        {
            return Problem(exception.Message);
        }

    }
    [HttpGet]
    public IActionResult ViewDashboard(int tacId)
    {
        try
        {
            return Ok(_driveService.ViewDashboard(tacId));
        }
        catch (Exception exception)
        {
            return Problem(exception.Message);
        }

    }


}
