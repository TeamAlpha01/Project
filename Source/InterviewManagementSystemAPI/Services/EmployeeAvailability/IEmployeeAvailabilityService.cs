using IMS.Models;

namespace IMS.Service
{
    public interface IEmployeeAvailabilityService
    {
        public bool SetTimeSlot(EmployeeAvailability employeeAvailability);
    }
}