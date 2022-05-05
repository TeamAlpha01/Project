using Microsoft.AspNetCore.Mvc;
using IMS.Models;
using IMS.Services;
using System.Net;

namespace IMS.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class PoolController : ControllerBase
{
    private readonly ILogger _logger;
    public PoolController(ILogger<PoolController> logger)
    {
        _logger = logger;
    }
    IPoolService PoolService = DataFactory.PoolDataFactory.GetPoolServiceObject();

    [HttpPost]
    public IActionResult CreateNewPool( int DepartmentId,string PoolName)
    {
        if (DepartmentId == 0 || PoolName == null) 
            return BadRequest("Pool name is required");

        try
        {
            return PoolService.CreatePool(DepartmentId,PoolName) ? Ok("Pool Added Successfully") : BadRequest("Sorry internal error occured");
        }
        catch (Exception exception)
        {
            _logger.LogInformation("Pool Service : CreatePool throwed an exception", exception);
            return BadRequest("Sorry some internal error occured");
        }
    }

    [HttpPost]
    public IActionResult RemovePool(int DepartmentId, int PoolId)
    {
        if (DepartmentId == 0 || PoolId == 0) return BadRequest("Pool Id is not provided");

        try
        {
            return PoolService.RemovePool(DepartmentId,PoolId) ? Ok("Pool Removed Successfully") : BadRequest("Sorry internal error occured");
        }
        catch (Exception exception)
        {
            _logger.LogInformation("Pool Service : RemovePool throwed an exception", exception);
            return BadRequest("Sorry some internal error occured");
        }
    }
    [HttpPut]
    public IActionResult EditPool(int PoolId,string PoolName)
    {
        if(PoolId==0 || PoolName==null) return BadRequest("Pool Id can't be empty");
        try
        {
            return PoolService.EditPool(PoolId,PoolName)?Ok("Pool name changed Successfully") : BadRequest("Sorry internal error occured");

        }
         catch (Exception exception)
        {
            _logger.LogInformation("Pool Service : RemovePool throwed an exception", exception);
            return BadRequest("Sorry some internal error occured");
        }
       
    }


    
    [HttpGet]
    public IActionResult ViewPools(int DepartmentId)
    {
        try
        {
            return Ok(PoolService.ViewPools(DepartmentId));
        }
        catch (Exception exception)
        {
            _logger.LogInformation("Service throwed exception while fetching Pools ", exception);
            return BadRequest("Sorry some internal error occured");
        }
    }

    
    [HttpPost]
    public IActionResult AddPoolMembers(int EmployeeId, int PoolId)
    {
        if (EmployeeId == 0 || PoolId == 0) 
            return BadRequest("Employee Id is required");

        try
        {
            return PoolService.AddPoolMembers(EmployeeId,PoolId) ? Ok("Employee Added Successfully") : BadRequest("Sorry internal error occured");
        }
        catch (Exception exception)
        {
            _logger.LogInformation("Pool Service : Add Employee throwed an exception", exception);
            return BadRequest("Sorry some internal error occured");
        }
    }

    
    [HttpPost]
    public IActionResult RemovePoolMembers(int EmployeeID, int PoolId)
    {
        if (EmployeeID == 0 || PoolId == 0) 
            return BadRequest("Pool Id is required");

        try
        {
            return PoolService.RemovePoolMembers(EmployeeID,PoolId) ? Ok("Employee Removed Successfully") : BadRequest("Sorry internal error occured");
        }
        catch (Exception exception)
        {
            _logger.LogInformation("Pool Service : RemovePoolMembers throwed an exception", exception);
            return BadRequest("Sorry some internal error occured");
        }
    }

    [HttpGet]
    public IActionResult ViewPoolMembers(int PoolId)
    {
        try
        {
            return Ok(PoolService.ViewPoolMembers(PoolId));
        }
        catch (Exception exception)
        {
            _logger.LogInformation("Service throwed exception while fetching Pool Members ", exception);
            return BadRequest("Sorry some internal error occured");
        }
    }

}
