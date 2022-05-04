using System.ComponentModel.DataAnnotations;
using IMS.Models;
using IMS.Service;
using IMS.Validations;
using Microsoft.AspNetCore.Mvc;
namespace IMS.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EmployeeDriveResponseController : ControllerBase
    {
        private readonly ILogger _logger;
        private IEmployeeDriveResponseService _employeeDriveResponseService;
        public EmployeeDriveResponseController(ILogger<DriveController> logger)
        {
            _logger = logger;
            _employeeDriveResponseService = DataFactory.EmployeeDriveResponseDataFactory.GetEmployeeDriveResponseServiceObject(logger);
        }


        [HttpPost]
        public IActionResult AddResponse(EmployeeDriveResponse response)
        {
            if (response == null) return BadRequest("Response cannnot be null");

            try
            {
                return _employeeDriveResponseService.AddResponse(response) ? Ok("Response added sucessfully") : Problem("Sorry internal error occured");
            }
            catch (ValidationException responseNotValid)
            {
                _logger.LogInformation($"Drive Controller : AddResponse(EmployeeDriveResponse response) : {responseNotValid.Message}");
                return BadRequest(responseNotValid.Message);
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Drive Controller : AddResponse(EmployeeDriveResponse response) : {exception.Message}");
                return Problem("Sorry internal error occured");
            }
        }
        [HttpPost]
        public IActionResult UpdateResponse(int employeeId, int driveId, int responseType)
        {
            if (driveId <= 0 || employeeId <= 0 || responseType <= 0)
                return BadRequest("provide proper driveId, employeeId and responseType");
            try
            {
                return _employeeDriveResponseService.UpdateResponse(employeeId, driveId, responseType) ? Ok("Response updated sucessfully") : Problem("Sorry internal error occured");
            }
            catch (ValidationException updateResponseNotValid)
            {
                _logger.LogInformation($"Drive Controller : UpdateResponse(int employeeId, int driveId, int responseType) : {updateResponseNotValid.Message}");
                return BadRequest(updateResponseNotValid.Message);
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"Drive Controller : UpdateResponse(int employeeId, int driveId, int responseType) : {exception.Message}");
                return Problem("Sorry internal error occured");
            }
        }
    }

}