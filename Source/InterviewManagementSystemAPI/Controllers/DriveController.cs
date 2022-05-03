using IMS.Models;
using IMS.Service;
using Microsoft.AspNetCore.Mvc;
namespace IMS.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class DriveController : ControllerBase
{
    private readonly ILogger _logger;
    public DriveController(ILogger<DriveController> logger)
    {
        _logger = logger;
    }
    private IDriveService _driveService = DataFactory.DriveDataFactory.GetDriveServiceObject();

    [HttpPost]
    public IActionResult CreateDrive(Drive drive)
    {
        if (ModelState.IsValid)
            return _driveService.CreateDrive(drive) ? Ok("Drive Created Successfully") : BadRequest("controller : Sorry internal error occured");

        try
        {
            return BadRequest("Drive is not valid");
        }
        catch (Exception)
        {
            return BadRequest();
        }

    }

    [HttpPost]
    public IActionResult CancelDrive(int driveId, int tacId, string reason)
    {
        if (driveId == 0 || tacId == 0 || reason.Length == 0)
            return BadRequest("provide proper driveId, tacId and reason");

        try
        {
            return _driveService.CancelDrive(driveId, tacId, reason) ? Ok("Drive Cancelled Sucessfully") : BadRequest("controller - cancel drive : Sorry internal error occured");
        }
        catch (Exception)
        {
            return BadRequest();
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
            return BadRequest();
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
            return BadRequest();
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
            return BadRequest();
        }

    }

}
