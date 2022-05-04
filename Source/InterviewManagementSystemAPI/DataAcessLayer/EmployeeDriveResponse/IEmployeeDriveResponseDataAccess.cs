using IMS.Models;
namespace IMS.DataAccessLayer{
    public interface IEmployeeDriveResponseDataAccess{
         public bool AddResponseToDatabase(EmployeeDriveResponse response);
         public bool UpdateResponseToDatabase(int employeeId, int driveId, int responseType);
    }
}