using IMS.DataAccessLayer;
using IMS.Models;
using IMS.Service;
namespace IMS.DataFactory{
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