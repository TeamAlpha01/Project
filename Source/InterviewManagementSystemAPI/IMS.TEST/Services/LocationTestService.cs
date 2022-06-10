using System;
using System.ComponentModel.DataAnnotations;
using FluentAssertions;
using IMS.DataAccessLayer;
using IMS.Models;
using IMS.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using UnitTesting.MockData;
using Xunit;
using UnitTesting.Utility;

namespace UnitTesting.ServiceTests
{
    public class locationTestService
    {
        private readonly LocationService _locationService;
        private readonly Mock<ILogger<LocationService>> _logger = new Mock<ILogger<LocationService>>();
        private readonly InterviewManagementSystemDbContext _db ;
        private readonly Mock<ILocationDataAccessLayer> _locationDataAccessLayer = new Mock<ILocationDataAccessLayer>();

        public locationTestService()
        {
            _locationService = new LocationService(_logger.Object, _locationDataAccessLayer.Object);
        }

        //Test for Create Location Method (7 TestCases)

        [Theory]
        [InlineData("#Chennai600025")]
        [InlineData("")]
        [InlineData(null)]
        public void Createlocation_ThrowsValidationException_WithInvalidlocationName(string locationName)
        {
            var Result = () => _locationService.CreateLocation(locationName);

            Result.Should().Throw<ValidationException>();
        }

        [Fact]
        public void Createlocation_ReturnsTrue_WithValidlocationName()
        {            
            _locationDataAccessLayer.Setup(r=>r.AddLocationToDatabase(It.Is<Location>(r=>r.LocationName == "Chennai"))).Returns(true);

            var Result = _locationService.CreateLocation("Chennai");
            Result.Should().BeTrue();
        }
        
        [Fact]
        public void Createlocation_ReturnsFalse_WithValidlocationName()
        {            
            _locationDataAccessLayer.Setup(r=>r.AddLocationToDatabase(It.Is<Location>(r=>r.LocationName == "Chennai"))).Returns(false);

            var Result = _locationService.CreateLocation("Chennai");
            Result.Should().BeFalse();
        }

        [Fact]
        public void Createlocation_ThrowsValidationException_When_DAL_ThrowsValidationException()
        {            
            _locationDataAccessLayer.Setup(r=>r.AddLocationToDatabase(It.Is<Location>(r=>r.LocationName == "Chennai"))).Throws<ValidationException>();

            var Result = () => _locationService.CreateLocation("Chennai");
            Result.Should().Throw<ValidationException>();
        }
        [Fact]
        public void Createlocation_ReturnFalse_When_DAL_ThrowsException()
        {            
            _locationDataAccessLayer.Setup(r=>r.AddLocationToDatabase(It.Is<Location>(r=>r.LocationName == "Chennai"))).Throws<Exception>();

            var Result = _locationService.CreateLocation("Chennai");
            Result.Should().BeFalse();
        }

        //Test for Remove Location Method (6 TestCases)

        [Theory]
        [InlineData(0)]
        public void Removelocation_ThrowsValidationException_WithInvalidlocationId(int locationId)
        {
            var Result = () => _locationService.RemoveLocation(locationId);

            Result.Should().Throw<ValidationException>();
        }

        [Fact]
        public void Removelocation_ReturnsTrue_WithValidlocationId()
        {            
            int locationId = 1;
           _locationDataAccessLayer.Setup(r => r.RemoveLocationFromDatabase(locationId)).Returns(true);
            var Result = _locationService.RemoveLocation(locationId);
            Result.Should().BeTrue();
        }

        [Fact]
        public void Removelocation_ReturnsFalse_WithValidlocationId()
        {            
            int locationId = 1;
           _locationDataAccessLayer.Setup(r => r.RemoveLocationFromDatabase(locationId)).Returns(false);
            var Result = _locationService.RemoveLocation(locationId);
            Result.Should().BeFalse();
        }
        
        [Fact]
        public void Removelocation_ReturnFalse_When_DAL_ThrowsArgumentException()
        {            
            int locationId = 1;
            _locationDataAccessLayer.Setup(r=>r.RemoveLocationFromDatabase(locationId)).Throws<ArgumentException>();
            var Result = _locationService.RemoveLocation(locationId);
            Result.Should().BeFalse();
        }

        [Fact]
        public void Removelocation_ReturnFalse_When_DAL_ThrowsValidationException()
        {            
            int locationId = 1;
            _locationDataAccessLayer.Setup(r=>r.RemoveLocationFromDatabase(locationId)).Throws<ValidationException>();
            var Result = () => _locationService.RemoveLocation(locationId);
            Result.Should().Throw<ValidationException>();
        }

        [Fact]
        public void Removelocation_ReturnFalse_When_DAL_ThrowsException()
        {            
            int locationId = 1;
            _locationDataAccessLayer.Setup(r=>r.RemoveLocationFromDatabase(locationId)).Throws<Exception>();
            var Result = _locationService.RemoveLocation(locationId);
            Result.Should().BeFalse();
        }

        //Test for View Location Method (2 TestCases)

        [Fact]
        public void Viewlocation_ThrowsException_When_DAL_ThrowsException()
        { 
            _locationDataAccessLayer.Setup(r=>r.GetLocationsFromDatabase()).Throws<Exception>();
            var Result = () => _locationService.ViewLocations();
            Result.Should().Throw<Exception>();
        }

        [Fact]
        public void Viewlocation_ShouldReturnListofLocations()
        {
            _locationDataAccessLayer.Setup(LocationDataAccessLayer => LocationDataAccessLayer.GetLocationsFromDatabase()).Returns(() => null);
            var Result = _locationService.ViewLocations();
            Result = null ;
        }
    }
}
 