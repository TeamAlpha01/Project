using IMS.DataAccessLayer;
using IMS.Controllers;
using IMS.Models;
using IMS.Services;
namespace IMS.DataFactory
{
    public static class LocationDataFactory
    {
        public static ILocationDataAccessLayer GetLocationDataAccessLayerObject(ILogger _logger)
        {
            return new LocationDataAccessLayer(_logger);
        }
        public static ILocationServices GetLocationServiceObject(ILogger _logger)
        {
            return new LocationService(_logger);
        }

        public static Location GetLocationObject()
        {
            return new Location();
        }
    }
}