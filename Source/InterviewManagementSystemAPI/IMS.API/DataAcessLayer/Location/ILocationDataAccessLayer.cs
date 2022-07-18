using IMS.Models;
namespace IMS.DataAccessLayer
{
    public interface ILocationDataAccessLayer
    
    {
        public bool AddLocationToDatabase(Location location);
        public bool RemoveLocationFromDatabase(int locationId);
        public List<Location> GetLocationsFromDatabase();
        public bool GetIsTraceEnabledFromConfiguration();
    }
}