using System.ComponentModel.DataAnnotations;
using IMS.Models;
using IMS.Service;
using IMS.Validations;
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
        try
        {
            return _driveService.CreateDrive(drive) ? Ok("Drive Created Successfully") : Problem("Sorry internal error occured");
        }
        catch (ValidationException driveException)
        {
            _logger.LogInformation($"Drive Controller : CreateDrive(Drive drive) : {driveException.Message}");
            return BadRequest(driveException.Message);
        }
        catch (Exception exception)
        {
            _logger.LogInformation($"Drive Controller : CreateDrive(Drive drive) : {exception.Message}");
            return Problem("Sorry internal error occured");
        }

    }

    [HttpPost]
    public IActionResult CancelDrive(int driveId, int tacId, string reason)
    {
        if (driveId == 0 || tacId == 0 || reason.Length == 0)
            return BadRequest("provide proper driveId, tacId and reason");

        try
        {
            return _driveService.CancelDrive(driveId, tacId, reason) ? Ok("Drive Cancelled Sucessfully") : Problem("Sorry internal error occured");
        }
        catch (ValidationException cancelDriveException)
        {
            _logger.LogInformation($"Drive Service : CancelDrive(int driveId, int tacId, string reason) : {cancelDriveException.Message}");
            return BadRequest(cancelDriveException.Message);
        }
        catch (Exception exception)
        {
            _logger.LogInformation($"Drive Controller : CancelDrive(int driveId, int tacId, string reason) : {exception.Message}");
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
        catch (Exception exception)
        {
            _logger.LogInformation($"Drive Controller : ViewTodayDrives() : {exception.Message}");
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
        catch (Exception exception)
        {
            _logger.LogInformation($"Drive Controller : ViewScheduledDrives() : {exception.Message}");
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
        catch (Exception exception)
        {
            _logger.LogInformation($"Drive Controller : ViewUpcommingDrives() : {exception.Message}");
            return Problem("Sorry internal error occured");
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
            _logger.LogInformation($"Drive Controller : ViewAllScheduledDrives() : {exception.Message}");
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
        catch (Exception exception)
        {
            _logger.LogInformation($"Drive Controller : ViewAllCancelledDrives() : {exception.Message}");
            return Problem("Sorry internal error occured");
        }

    }
    [HttpGet]
    public IActionResult ViewDrive(int driveId)
    {
        try
        {
            return Ok(_driveService.ViewDrive(driveId));
        }
        catch (ValidationException driveException)
        {
            _logger.LogInformation($"Drive Service : ViewDrive(int driveId) : {driveException.Message}");
            return BadRequest(driveException.Message);
        }
        catch (Exception exception)
        {
           _logger.LogInformation($"Drive Controller : ViewDrive(int driveId) : {exception.Message}");
            return Problem("Sorry internal error occured");
        }

    }
    [HttpGet]
    public IActionResult ViewDashboard(int tacId)
    {
        try
        {
            return Ok(_driveService.ViewDashboard(tacId));
        }
        catch (ValidationException driveException)
        {
            _logger.LogInformation($"Drive Service : ViewDashboard(int tacId) : {driveException.Message}");
            return BadRequest(driveException.Message);
        }
        catch (Exception exception)
        {
            _logger.LogInformation($"Drive Controller : ViewDashboard(int tacId) : {exception.Message}");
            return Problem("Sorry internal error occured");
        }

    }


}
