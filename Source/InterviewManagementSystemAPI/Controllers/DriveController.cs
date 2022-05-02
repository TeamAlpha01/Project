using InterviewManagementSystemAPI.Models;
using InterviewManagementSystemAPI.Service;
using Microsoft.AspNetCore.Mvc;
namespace InterviewManagementSystemAPI.Controllers;

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

        return BadRequest("Drive is not valid");
    }
    
    [HttpPost]
    public IActionResult CancelDrive(int driveId, int tacId, string reason)
    {
        if (driveId == 0 || tacId == 0 || reason.Length == 0)
            return BadRequest("provide proper driveId, tacId and reason");

        return _driveService.CancelDrive(driveId, tacId, reason) ? Ok("Drive Cancelled Sucessfully") : BadRequest("controller - cancel drive : Sorry internal error occured");
    }

    [HttpPost]
    public IActionResult ViewTodayDrives(int departmentId,int poolId)
    {
        return Ok(_driveService.ViewTodayDrive(departmentId,poolId));
    }
}
