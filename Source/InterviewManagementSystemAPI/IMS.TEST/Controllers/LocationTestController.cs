using System;
using System.ComponentModel.DataAnnotations;
using FluentAssertions;
using IMS.Controllers;
using IMS.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace UnitTesting.Controllers;

public class LocationControllerTest
{
    private readonly LocationController _locationController;
    private readonly Mock<ILogger<LocationController>> _logger = new Mock<ILogger<LocationController>>();
    private readonly Mock<ILocationServices> _locationService = new Mock<ILocationServices>();

    public LocationControllerTest ()
    {
        _locationController = new LocationController(_logger.Object, _locationService.Object);
    }

    //Test for Create Location Method (5 TestCases)

    [Theory]
    [InlineData(null)]
    public void CreateNewLocation_ShouldReturnStatusCode400_WhenLocationNameIsNull(string locationName)
    {
        var Result = _locationController.CreateNewLocation(locationName) as ObjectResult;
        Result.StatusCode.Should().Be(400);
    }

    [Fact]
    public void CreateNewLocation_ShouldReturnStatusCode200_WithProperLocationName()
    {
        string locationName = "Chennai";
        _locationService.Setup(r => r.CreateLocation(locationName)).Returns(true);

        var Result = _locationController.CreateNewLocation(locationName) as ObjectResult;

        Result.StatusCode.Should().Be(200);
    }

    [Fact]
    public void CreateNewlocation_ShouldReturnStatusCode500_WithProperlocationName()
    {
        string locationName = "Chennai";
        _locationService.Setup(r => r.CreateLocation(locationName)).Returns(false);
        var Result = _locationController.CreateNewLocation(locationName) as ObjectResult;
        Result.StatusCode.Should().Be(500);
    }

    [Fact]
    public void CreateNewlocation_ShouldReturnStatusCode500_WhenServiceThrowsValidationException()
    {
        string locationName = "Chennai";
        _locationService.Setup(r => r.CreateLocation(locationName)).Throws<Exception>();
        var Result = _locationController.CreateNewLocation(locationName) as ObjectResult;
        Result.StatusCode.Should().Be(500);
    }

    [Fact]
    public void CreateNewlocation_ShouldReturnStatusCode500_WhenServiceThrowsException()
    {
        string locationName = "Chennai";
        _locationService.Setup(r => r.CreateLocation(locationName)).Throws<ValidationException>();
        var Result = _locationController.CreateNewLocation(locationName) as ObjectResult;
        Result.StatusCode.Should().Be(400);
    }

    //Test for Remove Location Method (5 TestCases)

    [Theory]
    [InlineData(0)]
    public void RemoveLocation_ShouldReturnStatusCode400_WhenLocationNameIsZero(int locationId)
    {
        var Result = _locationController.RemoveLocation(locationId) as ObjectResult;
        Result.StatusCode.Should().Be(400);
    }

    [Fact]
    public void RemoveLocation_ShouldReturnStatusCode200_WithProperLocationId()
    {
        int locationId = 1;
        _locationService.Setup(r => r.RemoveLocation(locationId)).Returns(true);
        var Result = _locationController.RemoveLocation(locationId) as ObjectResult;
        Result.StatusCode.Should().Be(200);
    }

    [Fact]
    public void Removelocation_ShouldReturnStatusCode500_WithProperlocationId()
    {
        int locationId = 1;
        _locationService.Setup(r => r.RemoveLocation(locationId)).Returns(false);
        var Result = _locationController.RemoveLocation(locationId) as ObjectResult;
        Result.StatusCode.Should().Be(500);
    }

    [Fact]
    public void Removelocation_ShouldReturnStatusCode400_WhenServiceThrowsValidationException()
    {
        int locationId = 1;
        _locationService.Setup(r => r.RemoveLocation(locationId)).Throws<Exception>();
        var Result = _locationController.RemoveLocation(locationId) as ObjectResult;
        Result.StatusCode.Should().Be(400);
    }

    [Fact]
    public void Removelocation_ShouldReturnStatusCode500_WhenServiceThrowsException()
    {
        int locationId = 0;
        _locationService.Setup(r => r.RemoveLocation(locationId)).Throws<ValidationException>();
        var Result = _locationController.RemoveLocation(locationId) as ObjectResult;
        Result.StatusCode.Should().Be(400);
    }

    // Test for View Location Method (2 TestCases)

    [Fact]
    public void Viewlocation_ShouldReturnStatusCode200()
    {
        // Arrange
        _locationService.Setup(locationService => locationService.ViewLocations()).Returns(() => null);
        // Act
        var Result = _locationController.ViewLocations() as ObjectResult;
        //Assert
        Assert.Equal(200, Result.StatusCode);
    }

    [Fact]
    public void ViewRole_ShouldReturnStatusCode500()
    {
        // Arrange
        _locationService.Setup(locationService => locationService.ViewLocations()).Throws<Exception>();
        // Act
        var Result = _locationController.ViewLocations() as ObjectResult;
        //Assert
        Assert.Equal(500, Result.StatusCode);
    }

}