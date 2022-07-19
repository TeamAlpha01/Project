using Microsoft.AspNetCore.Mvc;
using IMS.Models;
using IMS.Validations;
using System.ComponentModel.DataAnnotations;
using IMS.Service;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace IMS.Controllers;

[Authorize]
[ApiController]
[Route("[controller]/[action]")]
public class LocationController : ControllerBase
{
    private readonly ILogger _logger;
    private ILocationServices _locationService;
    public LocationController(ILogger<LocationController> logger, ILocationServices locationServices)
    {
        _logger = logger;
        _locationService = locationServices;
    }

    /// <summary>
    /// This method is used to create new location
    /// </summary>
    /// <response code="200">If new location was created</response>
    /// <response code="400">If the item is null or validation exception occurs</response> 
    /// <param name="location">String</param>
    /// <returns>Returns success message if location was created or 
    /// Returns bad request if validation exception occurs or
    /// Returns problem if some internal error occurs</returns>

    [HttpPost]
    public IActionResult CreateNewLocation(Location location)
    {
        if (location == null || String.IsNullOrEmpty(location.LocationName))
            return BadRequest("Location name is required");

        try
        {
            int currentUser=Convert.ToInt32(User.FindFirst("UserId")?.Value);
            location.AddedBy=currentUser;
            location.UpdatedBy=null;
            return _locationService.CreateLocation(location) ? Ok(UtilityService.Response("Location Added Successfully")) : Problem("Sorry internal error occured");
        }
        catch (ValidationException locationnameAlreadyExists)
        {
            _logger.LogError($"Location Service : CreateNewLocation(string locationName) : {locationnameAlreadyExists.Message}");
            return BadRequest(UtilityService.Response(locationnameAlreadyExists.Message));
        }
        catch (Exception exception)
        {
            _logger.LogError($"Location Service : CreateLocation throwed an exception : {exception}");
            return Problem("Sorry some internal error occured");
        }
    }

    /// <summary>
    /// This method is used to remove location
    /// </summary>
    /// <response code="200">If Location was removed successfully</response>
    /// <response code="400">If the item is null or validation exception occurs</response> 
    /// <response code="500">If there is problem in server </response>
    /// <param name="location">int</param>
    /// <returns>Returns success message if location removed or
    /// Returns Bad request if validation exception occurs or
    /// Returns problem when some internal error occurs</returns>

    [HttpPatch]
    public IActionResult RemoveLocation(Location location)
    {
        if (location.LocationId <= 0)
           return BadRequest("Location id cannot be negative or null");
        try
        {            
            int currentUser=Convert.ToInt32(User.FindFirst("UserId")?.Value);
            location.AddedBy=null;
            location.UpdatedBy=currentUser;
            return _locationService.RemoveLocation(location) ? Ok(UtilityService.Response("Location Removed Successfully")) : Problem("Sorry internal error occured");
        }
        catch (ValidationException locationNotFound)
        {
            _logger.LogError($"Location Service : RemoveLocation(int locationId) : {locationNotFound.Message}");
            return BadRequest(locationNotFound.Message);
        }
        catch (Exception exception)
        {
            _logger.LogError($"Location Service : RemoveLocation throwed an exception : {exception}");
            return Problem("Sorry some internal error occured");
        }

    }
    /// <summary>
    /// This method is used to view list of locations
    /// </summary>
    /// <response code="20o">Returns list of locations</response>
    /// <response code="500">If there is problem in server</response> 
    /// <returns>Returns list of locations or 
    /// Returns problem when some internal error occurs</returns>
    [HttpGet]
    public IActionResult ViewLocations()
    {
        try
        {
            return Ok(_locationService.ViewLocations());
        }
        catch (Exception exception)
        {
            _logger.LogError("Service throwed exception while fetching locations ", exception);
            return Problem("Sorry some internal error occured");
        }
    }

}