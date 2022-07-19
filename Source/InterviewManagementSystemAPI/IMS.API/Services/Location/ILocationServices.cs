using IMS.Models;

namespace IMS.Service{
    public interface ILocationServices
    {
        public  bool CreateLocation(Location location);
        public bool RemoveLocation(Location location);
        public IEnumerable<Location> ViewLocations();

    }
}