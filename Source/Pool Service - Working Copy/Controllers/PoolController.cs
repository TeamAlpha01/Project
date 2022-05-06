using Microsoft.AspNetCore.Mvc;
using IMS.Models;
using IMS.Validations;
using System.ComponentModel.DataAnnotations;
using IMS.Services;
using System.Net;

namespace IMS.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class PoolController : ControllerBase
{
    private readonly ILogger _logger;
    private IPoolService _poolService;
    public PoolController(ILogger<PoolController> logger)
    {
        _logger = logger;
        _poolService = DataFactory.PoolDataFactory.GetPoolServiceObject(_logger);
    }
    
    [HttpPost]
    public IActionResult CreateNewPool(int departmentId,string poolName)
    {
        if(departmentId==0 || poolName==null)
            return BadRequest("Department Id or Pool name cannot be null");
        
        try
        {
            return _poolService.CreatePool(departmentId,poolName) ? Ok("Pool Added Successfully") : Problem("Sorry internal error occured");
        }
        catch (ValidationException createPoolException)
        {
            _logger.LogInformation($"Pool Service :CreatePool(int departmentId,poolNae) {createPoolException.Message}");
            return BadRequest(createPoolException.Message);
        }
        catch (Exception exception)
        {
            _logger.LogInformation($"Pool Service : CreatePool throwed an exception : {exception}");
            return Problem("Sorry some internal error occured");
        }
    }

    [HttpPost]
    public IActionResult RemovePool(int poolId)
    {
        if( poolId==0)
            return BadRequest("Pool Id can't be null");

      
        try
        {
            return _poolService.RemovePool(poolId) ? Ok("Pool Removed Successfully") : Problem("Sorry internal error occured");
        }
         catch (ValidationException poolNotFound)
        {
            _logger.LogInformation($"Pool Service : RemoveLocation(int departmentId,int poolId) : {poolNotFound.Message}");
            return BadRequest(poolNotFound.Message);
        }
        catch (Exception exception)
        {
            _logger.LogInformation($"Pool Service : RemoveLocation throwed an exception : {exception}");
            return BadRequest("Sorry some internal error occured");
        }
      
    }
    [HttpPut]
    public IActionResult EditPool(int poolId,string poolName)
   {
                if(poolId==0 || poolName==null) return BadRequest("Pool Id or poolname can't be empty");
      try
        {
             return _poolService.EditPool(poolId,poolName)?Ok("Pool name changed Successfully") : BadRequest("Sorry internal error occured");

         }
          catch (ValidationException poolNotFound)
        {
            _logger.LogInformation($"Pool Service :EditPool(int poolId,string poolName): {poolNotFound.Message}");
            return BadRequest(poolNotFound.Message);
        }
         catch (Exception exception)
       {
            _logger.LogInformation("Pool Service : RemovePool throwed an exception", exception);
            return BadRequest("Sorry some internal error occured");
        }
       
     }
    [HttpGet]
    public IActionResult ViewPools(int departmentId)
    {
        try
        {
            return Ok(_poolService.ViewPools(departmentId));
        }
        catch (Exception exception)
        {
            _logger.LogInformation("Service throwed exception while fetching locations ", exception);
            return BadRequest("Sorry some internal error occured");
        }
    }
    [HttpPost]
    public IActionResult AddPoolMembers(int employeeId,int poolId)
    {
        if(employeeId==0 || poolId==0)
            return BadRequest("Employee Id or Pool Id cannot be null");
        
        try
        {
            return _poolService.AddPoolMembers(employeeId,poolId) ? Ok("Pool Added Successfully") : Problem("Sorry internal error occured");
        }
        catch (ValidationException poolMemberNotException)
        {
            _logger.LogInformation($"Pool Service :AddPoolMembers(int employeeId,int poolId) {poolMemberNotException.Message}");
            return BadRequest(poolMemberNotException.Message);
        }
        catch (Exception exception)
        {
            _logger.LogInformation($"Pool Service : AddPoolMembers throwed an exception : {exception}");
            return Problem("Sorry some internal error occured");
        }
    }


}
    
    