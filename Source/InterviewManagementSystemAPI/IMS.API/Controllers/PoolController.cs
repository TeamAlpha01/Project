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
        _poolService = poolService;  //DataFactory.PoolDataFactory.GetPoolServiceObject(_logger);
    }

    /// <summary>
    /// This method will be implemented when "Create a New Pool" - Request rises.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /CreateNewPool
    ///     {
    ///        "Location Pool": "Freshers2022",
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response> 
    /// <param name="departmentId">int</param>
    /// <param name="poolName">string</param>
    /// <returns>Returns Success Message or Error Message when Exception occurs in Service layer</returns>

    [HttpPost]
    public IActionResult CreateNewPool(int departmentId, string poolName)
    {
        if (departmentId <= 0 || poolName == null)
            BadRequest("DepartmentId cannot be null or neagtive and Pool Name cannot null");

        try
        {
            return _poolService.CreatePool(departmentId, poolName) ? Ok("Pool Added Successfully") : Problem("Sorry internal error occured");
        }

        catch (ValidationException departmentNotFound)
        {
            _logger.LogInformation($"Pool Service : CreatePool throwed an exception : {departmentNotFound.Message}");
            return BadRequest(departmentNotFound.Message);
        }


        catch (Exception exception)
        {
            _logger.LogInformation($"Pool Service : CreatePool throwed an exception : {exception}");
            return Problem("Sorry some internal error occured");
        }
    }

    /// <summary>
    /// This method will be implemented when "Remove a Pool" - Request rises.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /Remove Pool
    ///     {
    ///        "PoolId": "1",
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response> 
    /// <param name="poolId">int</param>
    /// <returns>Returns Success Message or Error Message when Exception occurs in Service layer</returns>

    [HttpPost]
    public IActionResult RemovePool(int poolId)
    {
        if (poolId <= 0)
            BadRequest("Pool Id cannot be negative or null");
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
            return Problem ("Sorry some internal error occured");
        }

    }

    /// <summary>
    /// This method will be implemented when "Rename a Pool" - Request rises.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /Edit Pool
    ///     {
    ///        "Pool ID": "1",
    ///        "Pool Name" : "Freshers2021",
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response> 
    /// <param name="poolId">int</param>
    /// <param name="poolName">String</param>
    /// <returns>Returns Success Message or Error Message when Exception occurs in Service layer</returns>

    [HttpPut]
    public IActionResult EditPool(int poolId, string poolName)
    {
        if (poolId <= 0 && poolName == null )
            BadRequest("Pool Id cannot be negative or null , Pool Name cannot be null  cannot be negative or null");
        try
        {
            return _poolService.EditPool(poolId, poolName) ? Ok("Pool name changed Successfully") : BadRequest("Sorry internal error occured");

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

    /// <summary>
    /// This method will be implemented when "View Pools" - Request rises.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET / ViewPools
    ///     {
    ///      
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response> 
    /// <param name="departmentId">int</param>
    /// <returns>Returns a list of pools</returns>
    /// 

    [HttpGet]
    public IActionResult ViewPools()
    {
        try
        {
            return Ok(_poolService.ViewPools());
        }
        catch (ValidationException departmentNotFound)
        {
            _logger.LogInformation($"Pool Service :EditPool(int poolId,string poolName): {departmentNotFound.Message}");
            return BadRequest(departmentNotFound.Message);
        }
        catch (Exception exception)
        {
            _logger.LogInformation("Service throwed exception while fetching Pools ", exception);
            return Problem ("Sorry some internal error occured");
        }
    }
    /// <summary>
    /// This method will be implemented when "View PoolsById" - Request rises.
    /// </summary>
    /// <param name="employeeId"></param>
    /// <returns>Returns list of pool based on the given employee Id</returns>
    [HttpGet]
    public IActionResult ViewPoolsByID(int employeeId)
    {
        if (employeeId <= 0)
            BadRequest("Employee Id cannot be null or negative");

        try
        {
            return Ok(_poolService.ViewPoolsByID(employeeId));
        }
        catch (ValidationException employeeNotFound)
        {
            _logger.LogInformation($"Pool Service : ViewPools(employeeID) : {employeeNotFound.Message}");
            return BadRequest(employeeNotFound.Message);

        }
        catch (Exception exception)
        {
            _logger.LogInformation("Service throwed exception while fetching locations ", exception);
            return Problem("Sorry some internal error occured");
        }
    }

    /// <summary>
    /// This method will be implemented when "Add Pool Members" - Request rises.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /AddPoolMembers
    ///     {
    ///        "Employee Id": "1",
    ///        "Pool Id" : "1",
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response> 
    /// <param name="employeeId">int</param>
    /// <param name="poolId">int</param>
    /// <returns>Returns Success Message or Error Message when Exception occurs in Service layer</returns>

    [HttpPost]
    public IActionResult AddPoolMember(int employeeId, int poolId)
    {
        if (employeeId <= 0 && poolId <= 0)
            BadRequest("Employee Id and Pool Id cannot be negative or null");
        try
        {
            if (_poolService.AddPoolMember(employeeId, poolId))
            {
                _mailService.SendEmailAsync(_mailService.AddedEmployeeToPool(employeeId, poolId, Convert.ToInt32(User.FindFirst("UserId").Value)),true);
                return Ok("Pool Member Added Successfully");
            }

            return Problem("Sorry internal error occured");
        }
        catch (ValidationException employeeNotException)
        {
            _logger.LogInformation($"Pool Service :AddPoolMembers(int employeeId,int poolId) {employeeNotException.Message}");
            return BadRequest(employeeNotException.Message);
        }
        catch (MailException mailException)
        {
            _logger.LogInformation($"Pool Controller : AddPoolMembers(int employeeId,int poolId) : {mailException.Message} : {mailException.StackTrace}");
            return Ok("Pool Member Added Successfully but failed to send email");
        }
        catch (Exception exception)
        {
            _logger.LogInformation($"Pool Service : AddPoolMembers throwed an exception : {exception}");
            return Problem("Sorry some internal error occured");
        }
    }

    /// <summary>
    /// This method will be implemented when "Remove Pool Members" - Request rises.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /RemovePoolMembers
    ///     {
    ///        "Pool Member Id": "1",
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response> 
    /// <param name="poolMemberId">int</param>
    /// <returns>Returns Success Message or Error Message when Exception occurs in Service layer</returns>

    [HttpPost]
    public IActionResult RemovePoolMember(int poolMemberId)
    {
        if (poolMemberId <= 0)
            BadRequest("PoolMember Id cannot be negative or null");
        try
        {
            if(_poolService.RemovePoolMember(poolMemberId))
            {
                _mailService.SendEmailAsync(_mailService.RemovedEmployeeFromPool(poolMemberId,Convert.ToInt32(User.FindFirst("UserId").Value)),true);
                return Ok("Pool Member removed  Successfully");
            }
            return Problem("Sorry internal error occured");
        }
        catch (ValidationException poolMemberNotException)
        {
            _logger.LogInformation($"Pool Service :RemovePoolMembers(int poolMemberId): {poolMemberNotException.Message}");
            return BadRequest(poolMemberNotException.Message);
        }
        catch (MailException mailException)
        {
            _logger.LogInformation($"Pool Controller : RemovePoolMembers(int poolMemberId) : {mailException.Message} : {mailException.StackTrace}");
            return Ok("Pool Member removed Successfully but failed to send email");
        }
        catch (Exception exception)
        {
            _logger.LogInformation($"Pool Service : RemovePoolMembers(int poolMemberId) throwed an exception: {exception}");
            return Problem("Sorry some internal error occured");
        }
    }

    /// <summary>
    /// This method will be implemented when "View Pool Members" - Request rises.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /ViewPoolMembers
    ///     {
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response> 
    /// <param name="poolId">int</param>
    /// <returns>Returns a list of pool Members</returns>

    [HttpGet]
    public IActionResult ViewPoolMembers(int poolId)
    {
        if (poolId <= 0)
            BadRequest("Pool Id cannot be null or negative");

        try
        {
            return Ok(_poolService.ViewPoolMembers(poolId));
        }
        catch (ValidationException poolNotFound)
        {
            _logger.LogInformation($"Pool Service : ViewPoolMembers() : {poolNotFound.Message}");
            return BadRequest(poolNotFound.Message);

        }
        catch (Exception exception)
        {
            _logger.LogInformation("Service throwed exception while fetching locations ", exception);
            return Problem("Sorry some internal error occured");
        }
    }




}

