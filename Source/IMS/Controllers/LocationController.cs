using Microsoft.AspNetCore.Mvc;
using IMS.Models;
using IMS.Validations;
using IMS.Services;
using System.Net;

namespace IMS.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class LocationController : ControllerBase
{
    private readonly ILogger _logger;
    private ILocationServices locationService;
    public LocationController(ILogger<LocationController> logger)
    {
        _logger = logger;
        locationService = DataFactory.LocationDataFactory.GetLocationServiceObject(_logger);
    }
    
    [HttpPost]
    public IActionResult CreateNewLocation(string locationName)
    {
      
        if (locationName == null) 
            return BadRequest("Location name is required");

        try
        {
            return locationService.CreateLocation(locationName) ? Ok("Location Added Successfully") : Problem("Sorry internal error occured");
        }
        catch(ValidationException locationNameException)
        {
            _logger.LogInformation($"Location Service : CreateLocation() : {locationNameException.Message}");
            return BadRequest(locationNameException.Message);
        }
        catch (Exception exception)
        {
            _logger.LogInformation($"Location Service : CreateLocation throwed an exception : {exception}");
            return Problem("Sorry some internal error occured");
        }
    }

    [HttpPost]
    public IActionResult RemoveLocation(int locationId)
    {
        if (locationId == 0) return BadRequest("Location Id is not provided");

        try
        {
            return locationService.RemoveLocation(locationId) ? Ok("Location Removed Successfully") : BadRequest("Sorry internal error occured");
        }
        catch (Exception exception)
        {
            _logger.LogInformation("Location Service : RemoveLocation throwed an exception", exception);
            return BadRequest("Sorry some internal error occured");
        }
    }
    [HttpGet]
    public IActionResult ViewLocations()
    {
        try
        {
            return Ok(locationService.ViewLocations());
        }
        catch (Exception exception)
        {
            _logger.LogInformation("Service throwed exception while fetching roles ", exception);
            return BadRequest("Sorry some internal error occured");
        }
    }

}