using System;
 public class Location{

 };

public class LocationServices{

    //For Location-Entity
    public void AddLocation(int locationId);
    public void RemoveLocation(int locationId);
    public Location ViewLocations(int locationId);
    public List<Location> ViewLocation();
 };
