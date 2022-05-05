using System.ComponentModel.DataAnnotations;
using IMS.Models;
using IMS.Service;
using IMS.Validations;
using Microsoft.AspNetCore.Mvc;
namespace IMS.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EmployeeAvailabilityController : ControllerBase
    {
        private readonly ILogger _logger;
        private IEmployeeAvailabilityService _employeeAvailabilityService;
        public EmployeeAvailabilityController(ILogger<DriveController> logger)
        {
            _logger = logger;
            _employeeAvailabilityService = DataFactory.EmployeeAvailabilityDataFactory.GetEmployeeAvailabilityServiceObject(_logger);
        }
        [HttpPost]
        public IActionResult SetTimeSlot(EmployeeAvailability employeeAvailability)
        {
            return  _employeeAvailabilityService.SetTimeSlot(employeeAvailability) ? Ok() : Problem();
        }
    }
}
