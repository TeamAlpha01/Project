using IMS.Models;

namespace IMS.Service{
    public interface ILocationServices
    {
        public  bool CreateLocation(string locationName);
        public bool RemoveLocation(int locationId);
        public IEnumerable<Location> ViewLocations();

    }
}