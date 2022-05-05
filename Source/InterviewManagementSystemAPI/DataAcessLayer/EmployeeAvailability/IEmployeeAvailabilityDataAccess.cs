using IMS.Models;
namespace IMS.DataAccessLayer{
    public interface IEmployeeAvailabilityDataAccess{
         public bool SetTimeSlotToDatabase(EmployeeAvailability employeeAvailability);
    }
}