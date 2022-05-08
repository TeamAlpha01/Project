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
        PoolValidation.IsCreatePoolValid(departmentId,poolName);
        
        try
        {
            return _poolService.CreatePool(departmentId,poolName) ? Ok("Pool Added Successfully") : Problem("Sorry internal error occured");
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
        PoolValidation.IsRemovePoolValid(poolId);

      
        try
        {
            return _poolService.RemovePool(poolId) ? Ok("Pool Removed Successfully") : Problem("Sorry internal error occured");
        }
         catch (ValidationException poolNotFound)
        {
            _logger.LogInformation($"Pool Service : RemovePool(int poolId) : {poolNotFound.Message}");
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
         PoolValidation.IsEditPoolValid(poolId,poolName);       
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
        PoolValidation.IsValidDepartmentId(departmentId);

        try
        {
            return Ok(_poolService.ViewPools(departmentId));
        }
          catch (ValidationException departmentNotFound)
        {
            _logger.LogInformation($"Pool Service :EditPool(int poolId,string poolName): {departmentNotFound.Message}");
            return BadRequest(departmentNotFound.Message);
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
        PoolValidation.IsAddPoolMembersValid(employeeId,poolId);
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
    [HttpPost]
    public IActionResult RemovePoolMembers(int poolMemberId)
    {
         PoolValidation.IsRemovePoolMembersValid(poolMemberId);
        try
        {
            return _poolService.RemovePoolMembers(poolMemberId) ? Ok("Pool Member removed  Successfully") : Problem("Sorry internal error occured");
        }
        catch (ValidationException poolMemberNotException)
        {
            _logger.LogInformation($"Pool Service :RemovePoolMembers(int poolMemberId): {poolMemberNotException.Message}");
            return BadRequest(poolMemberNotException.Message);
        }
        catch (Exception exception)
        {
            _logger.LogInformation($"Pool Service : RemovePoolMembers(int poolMemberId) throwed an exception: {exception}");
            return Problem("Sorry some internal error occured");
        }
    }
    [HttpGet]
    public IActionResult ViewPoolMembers(int poolId)
    {
         PoolValidation.IsValidPoolId(poolId);
        try
        {
            return Ok(_poolService.ViewPoolMembers(poolId));
        }
        catch (ValidationException poolNotFound)
        {
            _logger.LogInformation($"Pool Service : ViewPoolMembers(poolId) : {poolNotFound.Message}");
            return BadRequest(poolNotFound.Message);
      
        }
        catch (Exception exception)
        {
            _logger.LogInformation("Service throwed exception while fetching locations ", exception);
            return BadRequest("Sorry some internal error occured");
        }
    }



}
    
    