using InterviewManagementSystemAPI.DataAccessLayer;
using InterviewManagementSystemAPI.Models;
using InterviewManagementSystemAPI.Service;
namespace InterviewManagementSystemAPI.DataFactory{
    public static class DriveDataFactory
    {
        public static IDriveDataAccessLayer GetDriveDataAccessLayerObject()
        {
            return new DriveDataAccessLayer();
        }
        public static IDriveService GetDriveServiceObject()
        {
            return new DriveService();
        }
        public static Drive GetDriveObject()
        {
            return new Drive();
        }

    }
}