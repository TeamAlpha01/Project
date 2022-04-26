using System;
public class Location
{

};

public class LocationServices
{

    //For Location-Entity
    public bool AddLocation(Location location);
    public bool RemoveLocation(int locationId);
    public List<Location> ViewLocations();
};
