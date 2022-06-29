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
        _locationService = locationServices;// DataFactory.LocationDataFactory.GetLocationServiceObject(_logger);
    }

    /// <summary>
    /// This method will be implemented when "Add a new Locatioon" - Request rises.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /CreateNewLocation
    ///     {
    ///        "Location Name": "Chennai",
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response> 
    /// <param name="locationName">String</param>
    /// <returns> Returns Error Message when Exception occured in Location Service. Succsess Message or Internal Error</returns>

    [HttpPost]
    public IActionResult CreateNewLocation(string locationName)
    {
        if (locationName == null)
            return BadRequest("Location name is required");

        try
        {
            return _locationService.CreateLocation(locationName) ? Ok(UitilityService.Response("Location Added Successfully")) : Problem("Sorry internal error occured");
        }
        catch (ValidationException locationnameAlreadyExists)
        {
            _logger.LogInformation($"Location Service : CreateNewLocation(string locationName) : {locationnameAlreadyExists.Message}");
            return BadRequest(UitilityService.Response(locationnameAlreadyExists.Message));
        }
        catch (Exception exception)
        {
            _logger.LogInformation($"Location Service : CreateLocation throwed an exception : {exception}");
            return Problem("Sorry some internal error occured");
        }
    }

    /// <summary>
    /// This method will be implemented when "Remove a Location" - Request rises.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /RemoveLocation
    ///     {
    ///        "Location Id": "1",
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response> 
    /// <param name="locationId">int</param>
    /// <returns>Returns Error Message when Exception occured in Location Service. Succsess Message or Internal Error</returns>

    [HttpPatch]
    public IActionResult RemoveLocation(int locationId)
    {
        if (locationId <= 0)
           return BadRequest("Location id cannot be negative or null");
        try
        {            
            return _locationService.RemoveLocation(locationId) ? Ok(UitilityService.Response("Location Removed Successfully")) : Problem("Sorry internal error occured");
        }
        catch (ValidationException locationNotFound)
        {
            _logger.LogInformation($"Location Service : RemoveLocation(int locationId) : {locationNotFound.Message}");
            return BadRequest(locationNotFound.Message);
        }
        catch (Exception exception)
        {
            _logger.LogInformation($"Location Service : RemoveLocation throwed an exception : {exception}");
            return Problem("Sorry some internal error occured");
        }

    }
    /// <summary>
    /// This method will be implemented when "View all Location" - Request rises
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET /ViewLocation
    ///     {
    ///        
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response> 
    /// <returns>Returns Error Message when Exception occured in Location Service. A list contains All locations or Error Message</returns>
    [HttpGet]
    public IActionResult ViewLocations()
    {
        try
        {
            return Ok(_locationService.ViewLocations());
        }
        catch (Exception exception)
        {
            _logger.LogInformation("Service throwed exception while fetching locations ", exception);
            return Problem("Sorry some internal error occured");
        }
    }

}