using IMS.Models;

namespace IMS.Services{
    public interface ILocationServices
    {
        public  bool CreateLocation(string locationName);
        public bool RemoveLocation(int locationId);
        public IEnumerable<Location> ViewLocations();

    }
}