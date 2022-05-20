using Microsoft.AspNetCore.Mvc;
using IMS.Models;
using IMS.Service;
using IMS.DataFactory;
using System.Net;
using System.ComponentModel.DataAnnotations;



namespace IMS.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class TokenController : ControllerBase
{
    // private readonly ILogger _logger;

    // private ITokenService tokenService;
    // public TokenController(ILogger<TokenController> logger)
    // {
    //     _logger = logger;
    //     tokenService = DataFactory.EmployeeDataFactory.GetEmployeeServiceObject(_logger);
    // }
    // public IActionResult AuthToken(string employeeAceNumber, string password)
    // {
    //     try
    //     {
    //         var Result = tokenService.AuthToken(employeeAceNumber,password);
    //         return Ok(Result);
    //     }
    //     catch(ValidationException validationException)
    //     {
    //         _logger.LogInformation($"Token Service : AuthToken() : {validationException.Message}");
    //         return BadRequest(validationException.Message);
    //     }
    //     catch(Exception exception)
    //     {
    //         _logger.LogInformation($"Token Service : AuthToken() : {exception.Message}");
    //         return BadRequest(exception.Message);
    //     }
    // }
}