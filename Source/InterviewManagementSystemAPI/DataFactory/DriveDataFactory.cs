using IMS.DataAccessLayer;
using IMS.Models;
using IMS.Service;
namespace IMS.DataFactory{
    public static class DriveDataFactory
    {
        public static IDriveDataAccessLayer GetDriveDataAccessLayerObject(ILogger logger)
        {
            return new DriveDataAccessLayer(logger);
        }
        public static IDriveService GetDriveServiceObject(ILogger logger)
        {
            return new DriveService(logger);
        }
        public static Drive GetDriveObject()
        {
            return new Drive();
        }

    }
}