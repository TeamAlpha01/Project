using Microsoft.AspNetCore.Mvc;
using IMS.Models;
using IMS.Validations;
using System.ComponentModel.DataAnnotations;
using IMS.Service;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using IMS.CustomExceptions;

namespace IMS.Controllers;

[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class PoolController : ControllerBase
{
    private readonly ILogger _logger;
    private IPoolService _poolService;
    private IMailService _mailService;
    public PoolController(ILogger<PoolController> logger, IMailService mailService,IPoolService poolService)
    {
        _logger = logger;
        _mailService = mailService;
        _poolService = poolService;  
    }

    /// <summary>
    /// This method is used to create new pool
    /// </summary>
    /// <response code="200">If new pool was created</response>
    /// <response code="400">If the item is null or validation exception occurs</response>
    /// <response code="500">If there is problem in server</response>
    /// <param name="departmentId">int</param>
    /// <param name="poolName">string</param>
    /// <returns>Returns success message if new pool was created
    /// Returns bad request if validation exception occcurs</returns>

    [HttpPost]
    public IActionResult CreateNewPool(int departmentId, string poolName)
    {
        if (departmentId <= 0 || poolName == null)
            BadRequest("DepartmentId cannot be null or neagtive and Pool Name cannot null");

        try
        {
            return _poolService.CreatePool(departmentId, poolName) ? Ok(UtilityService.Response("Pool Added Successfully")) : Problem("Sorry internal error occured");
        }

        catch (ValidationException departmentNotFound)
        {
            _logger.LogError($"Pool Service : CreatePool throwed an exception : {departmentNotFound.Message}");
            return BadRequest(UtilityService.Response(departmentNotFound.Message));
        }


        catch (Exception exception)
        {
            _logger.LogInformation($"Pool Service : CreatePool throwed an exception : {exception.Message}");
            return Problem("Sorry some internal error occured");
        }
    }

    /// <summary>
    /// This method is used to remove pool
    /// </summary>
    /// <response code="200">If pool removed successfully</response>
    /// <response code="400">If the item is null or validation exception occurs</response> 
    /// <response code="500">If there is problem in server</response>
    /// <param name="poolId">int</param>
    /// <returns>Returns Success Message if pool was removed or
    /// Returns Badrequest if validation exception occurs
    /// Retursn problem if some internal error occurs</returns>

    [HttpPost]
    public IActionResult RemovePool(int poolId)
    {
        if (poolId <= 0)
            BadRequest("Pool Id cannot be negative or null");
        try
        {
            return _poolService.RemovePool(poolId) ? Ok(UtilityService.Response("Pool Removed Successfully")) : Problem("Sorry internal error occured");
        }
        catch (ValidationException poolNotFound)
        {
            _logger.LogError($"Pool Service : RemovePool(int poolId) : {poolNotFound.Message}");
            return BadRequest(poolNotFound.Message);
        }
        catch (Exception exception)
        {
            _logger.LogError($"Pool Service : RemoveLocation throwed an exception : {exception}");
            return Problem ("Sorry some internal error occured");
        }

    }

    /// <summary>
    /// This method is used to rename a pool 
    /// </summary>
    /// <response code="200">If pool was successfully renamed</response>
    /// <response code="400">If the item is null or validation exception occurs</response> 
    /// <response code="500">If there is problem in server</response>
    /// <param name="poolId">int</param>
    /// <param name="poolName">String</param>
    /// <returns>Returns Success Message if pool was renamed or 
    /// Returns bad request if validation exception occurs or
    /// Returns problem if some internal error occurs</returns>

    [HttpPut]
    public IActionResult EditPool(int poolId, string poolName)
    {
        if (poolId <= 0 && poolName == null )
            return BadRequest("Pool Id cannot be negative or null , Pool Name cannot be null  cannot be negative or null");
        try
        {
            return _poolService.EditPool(poolId, poolName) ? Ok(UtilityService.Response("Pool name changed Successfully")) : Problem("Sorry internal error occured");

        }
        catch (ValidationException poolNotFound)
        {
            _logger.LogError($"Pool Service :EditPool(int poolId,string poolName): {poolNotFound.Message}");
            return BadRequest(poolNotFound.Message);
        }

        catch (Exception exception)
        {
            _logger.LogError("Pool Service : RemovePool throwed an exception", exception);
            return Problem("Sorry some internal error occured");
        }

    }

    /// <summary>
    /// This method is used to view list of pools
    /// </summary>
    /// <response code="200">Returns the newly created item</response>
    /// <response code="400">If the item is null</response> 
    /// <response code="500">If there is problem in server</response>
    /// <returns>Returns a list of pools or 
    /// Returns bad request when validation exception occurs or
    /// Returns problem when some internal error occurs</returns>
    

    [HttpGet]
    public IActionResult ViewPools()
    {
        try
        {
            return Ok(_poolService.ViewPools());
        }
        catch (ValidationException departmentNotFound)
        {
            _logger.LogError($"Pool Service :EditPool(int poolId,string poolName): {departmentNotFound.Message}");
            return BadRequest(departmentNotFound.Message);
        }
        catch (Exception exception)
        {
            _logger.LogError("Service throwed exception while fetching Pools ", exception);
            return Problem ("Sorry some internal error occured");
        }
    }
    /// <summary>
    /// This method is used view list of pools for a cuurent user
    /// </summary>
    /// <response code="200">Returns pool by Id</response>
    /// <response code="400">Returns bad request when validation exception occurs </response>
    /// <response code="500">If there is problem in server</response>
    /// <returns>Returns list of pool based on employee id or
    /// Returns bad request when validation exception occurs or
    /// Returnns problem when intrenal error occurs</returns>
    [HttpGet]
    public IActionResult ViewPoolsByID()
    {

        try
        {
            int employeeId=Convert.ToInt32(User.FindFirst("UserID").Value);
            return Ok(_poolService.ViewPoolsByID(employeeId));
        }
        catch (ValidationException employeeNotFound)
        {
            _logger.LogError($"Pool Service : ViewPools(employeeID) : {employeeNotFound.Message}");
            return BadRequest(employeeNotFound.Message);

        }
        catch (Exception exception)
        {
            _logger.LogError("Service throwed exception while fetching locations ", exception);
            return Problem("Sorry some internal error occured");
        }
    }

    /// <summary>
    /// This method is used to add a pool member
    /// </summary>
    /// <response code="200">If pool member is added sucessfully</response>
    /// <response code="400">If the item is null or validation exception occurs</response> 
    /// <response code="500">If problem occurs in server</response>
    /// <param name="employeeId">int</param>
    /// <param name="poolId">int</param>
    /// <returns>Returns Success message when pool member added or 
    /// Returns bad request when validation exception occurs
    /// Rerurns problem when internal error occurs</returns>

    [HttpPost]
    public IActionResult AddPoolMember(int employeeId, int poolId)
    {
        if (employeeId <= 0 && poolId <= 0)
            BadRequest("Employee Id and Pool Id cannot be negative or null");
        try
        {
            if (_poolService.AddPoolMember(employeeId, poolId))
            {
                //_mailService.SendEmailAsync(_mailService.AddedEmployeeToPool(employeeId, poolId, Convert.ToInt32(User.FindFirst("UserId").Value)),true);
                return Ok(UtilityService.Response("Pool Member Added Successfully"));
            }

            return Problem("Sorry internal error occured");
        }
        catch (ValidationException employeeNotException)
        {
            _logger.LogError($"Pool Service :AddPoolMembers(int employeeId,int poolId) {employeeNotException.Message}");
            return BadRequest(UtilityService.Response(employeeNotException.Message));
        }
        catch (MailException mailException)
        {
            _logger.LogWarning($"Pool Controller : AddPoolMembers(int employeeId,int poolId) : {mailException.Message} : {mailException.StackTrace}");
            return Ok("Pool Member Added Successfully but failed to send email");
        }
        catch (Exception exception)
        {
            _logger.LogError($"Pool Service : AddPoolMembers throwed an exception : {exception}");
            return Problem("Sorry some internal error occured");
        }
    }

    /// <summary>
    /// This method is used to remove a pool member from a pool
    /// </summary>
    /// <response code="200">If pool member removed successfully</response>
    /// <response code="400">If the item is null or validation exception occurs</response> 
    /// <param name="poolMemberId">int</param>
    /// <returns>Returns Success Message or Error Message when Exception occurs in Service layer</returns>

    [HttpPost]
    public IActionResult RemovePoolMember(int poolMemberId)
    {
        if (poolMemberId <= 0)
            return BadRequest("PoolMember Id cannot be negative or null");
        try
        {
            if(_poolService.RemovePoolMember(poolMemberId))
            {
                //_mailService.SendEmailAsync(_mailService.RemovedEmployeeFromPool(poolMemberId,Convert.ToInt32(User.FindFirst("UserId").Value)),true);
                return Ok(UtilityService.Response("Pool Member removed  Successfully"));
            }
            return Problem("Sorry internal error occured");
        }
        catch (ValidationException poolMemberNotException)
        {
            _logger.LogError($"Pool Service :RemovePoolMembers(int poolMemberId): {poolMemberNotException.Message}");
            return BadRequest(UtilityService.Response(poolMemberNotException.Message));
        }
        catch (MailException mailException)
        {
            _logger.LogWarning($"Pool Controller : RemovePoolMembers(int poolMemberId) : {mailException.Message} : {mailException.StackTrace}");
            return Ok("Pool Member removed Successfully but failed to send email");
        }
        catch (Exception exception)
        {
            _logger.LogError($"Pool Service : RemovePoolMembers(int poolMemberId) throwed an exception: {exception}");
            return Problem("Sorry some internal error occured");
        }
    }

    /// <summary>
    /// This method is used to view list of pool members by pool id
    /// </summary>
    /// <response code="200">Returns list of pool members</response>
    /// <response code="400">If the item is null or validation exception occurs</response> 
    /// <param name="poolId">int</param>
    /// <returns>Returns a list of pool Members or 
    /// Returns bad request when validation exception occurs or
    /// Returns problem when some internal error occurs</returns>

    [HttpGet]
    public IActionResult ViewPoolMembers(int poolId)
    {
        if (poolId <= 0)
           return BadRequest("Pool Id cannot be null or negative");

        try
        {
            return Ok(_poolService.ViewPoolMembers(poolId));
        }
        catch (ValidationException poolNotFound)
        {
            _logger.LogError($"Pool Service : ViewPoolMembers() : {poolNotFound.Message}");
            return BadRequest(poolNotFound.Message);

        }
        catch (Exception exception)
        {
            _logger.LogError("Service throwed exception while fetching locations ", exception);
            return Problem("Sorry some internal error occured");
        }
    }




}

