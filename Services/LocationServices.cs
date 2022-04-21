using System;
 public class Location{

 };

public class LocationServices{

    //For Location-Entity
    public void AddLocation(Location location);
    public void RemoveLocation(int locationId);
    public Location ViewLocation(int locationId);
    public List<Location> ViewLocations();
 };
