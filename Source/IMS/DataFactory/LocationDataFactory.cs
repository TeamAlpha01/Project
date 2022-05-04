using IMS.DataAccessLayer;
using IMS.Models;
using IMS.Services;
namespace IMS.DataFactory{
    public static class LocationDataFactory
    {
        public static ILocationDataAccessLayer GetLocationDataAccessLayerObject()
        {
            return new LocationDataAccessLayer();
        }
      
         public static Location GetLocationObject()
        {
            return new Location();
        }
        public static ILocationServices GetLocationServiceObject()
        {
            return new LocationService();
        }
    }
}