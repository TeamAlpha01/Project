using System.Collections.Generic;
using IMS.Models;

namespace UnitTesting.MockData
{
    public static class LocationMock
    {
        public static List<Location> GetLocationsMock()
        {
            List<Location> mockLocation = new List<Location>();
            mockLocation.Add( new Location { LocationId = 1, LocationName = "Software Developer" });
            mockLocation.Add( new Location { LocationId = 2, LocationName = "Senior Software Developer" });
            mockLocation.Add( new Location { LocationId = 3, LocationName = "Project Manager" });
            mockLocation.Add( new Location { LocationId = 4, LocationName = "Module Lead" });
            mockLocation.Add( new Location { LocationId = 5, LocationName = "Technical Lead" });
            mockLocation.Add( new Location { LocationId = 6, LocationName = "Software Architect" });
            mockLocation.Add( new Location { LocationId = 7, LocationName = "Delivery Manager" });
            mockLocation.Add( new Location { LocationId = 8, LocationName = "Service Line Owner" });
            mockLocation.Add( new Location { LocationId = 9, LocationName = "Talent" });
            mockLocation.Add( new Location { LocationId = 10,LocationName = "Admin" });
            return mockLocation;
        }

        
    }
}