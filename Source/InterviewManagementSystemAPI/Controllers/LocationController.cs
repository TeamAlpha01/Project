using Microsoft.AspNetCore.Mvc;
using IMS.Models;
using IMS.Validations;
using System.ComponentModel.DataAnnotations;
using IMS.Services;
using System.Net;

namespace IMS.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class LocationController : ControllerBase
{
    private readonly ILogger _logger;
    private ILocationServices _locationService;
    public LocationController(ILogger<LocationController> logger)
    {
        _logger = logger;
        _locationService = DataFactory.LocationDataFactory.GetLocationServiceObject(_logger);
    }

    /// <summary>
    /// This method will be implemented when "Add a new Locatioon" - Request rises. This method Check the null Validation and
    /// then Control shifts to Location Service. 
    /// </summary>
    /// <param name="locationName">String</param>
    /// <returns> Returns Error Message when Exception occured in Location Service. Succsess Message or Internal Error</returns>
    
    [HttpPost]
    public IActionResult CreateNewLocation(string locationName)
    {
        if(locationName==null)
            return BadRequest("Location name is required");
        /*****************  parameter validation required  *****************/
        try
        {
            return _locationService.CreateLocation(locationName) ? Ok("Location Added Successfully") : Problem("Sorry internal error occured");
        }
        catch (ValidationException locationNameException)
        {
            _logger.LogInformation($"Location Service : CreateNewLocation() : {locationNameException.Message}");
            return BadRequest(locationNameException.Message);
        }
        catch (Exception exception)
        {
            _logger.LogInformation($"Location Service : CreateLocation throwed an exception : {exception}");
            return Problem("Sorry some internal error occured");
        }
    }

    /// <summary>
    /// This method will be implemented when "Remove a Location" - Request rises. This method Check the null Validation and
    /// then Control shifts to Location Service.
    /// </summary>
    /// <param name="locationId">int</param>
    /// <returns>Returns Error Message when Exception occured in Location Service. Succsess Message or Internal Error</returns>

    [HttpPost]
    public IActionResult RemoveLocation(int locationId)
    {
        if(locationId == 0)
            return BadRequest("Location Id can't be null");

        /*****************  parameter validation required  *****************/
        try
        {
            return _locationService.RemoveLocation(locationId) ? Ok("Location Removed Successfully") : Problem("Sorry internal error occured");
        }
         catch (ValidationException locationNotFound)
        {
            _logger.LogInformation($"Location Service : RemoveLocation() : {locationNotFound.Message}");
            return BadRequest(locationNotFound.Message);
        }
        catch (Exception exception)
        {
            _logger.LogInformation($"Location Service : RemoveLocation throwed an exception : {exception}");
            return BadRequest("Sorry some internal error occured");
        }
      
    }
    /// <summary>
    /// This method will be implemented when "View all Location" - Request rises
    /// </summary>
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
            return BadRequest("Sorry some internal error occured");
        }
    }

}