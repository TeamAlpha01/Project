using IMS.Models;

namespace IMS.Service
{
    public interface IEmployeeDriveResponseService
    {
        public bool AddResponse(EmployeeDriveResponse response);
        public bool UpdateResponse(int employeeId, int driveId, int responseType);
    }
}