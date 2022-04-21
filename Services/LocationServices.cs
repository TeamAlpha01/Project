using System;
 public class Location{

 };

public class LocationServices{

    //For Location-Entity
    public void AddLocation(int locationId);
    public void RemoveLocation(int locationId);
    public Location ViewLocations();
    public List<Location> ViewLocation(int locationId);
 };
