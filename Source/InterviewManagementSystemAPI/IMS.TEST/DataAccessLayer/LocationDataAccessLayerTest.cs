using System.ComponentModel.DataAnnotations;
using FluentAssertions;
using IMS.DataAccessLayer;
using IMS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using UnitTesting.MockData;
using UnitTesting.Utility;
using Xunit;

namespace UnitTesting.DataAccessLayer
{
    public class LocationDataAccessLayerTest
    {
        private readonly ILocationDataAccessLayer _locationDataAccessLayer;
        private readonly Mock<ILogger<LocationDataAccessLayer>> _logger = new Mock<ILogger<LocationDataAccessLayer>>();
        private readonly InterviewManagementSystemDbContext _db ;
        public LocationDataAccessLayerTest()
        {
            _db = DbUtility.GetInMemoryDbContext();
            _locationDataAccessLayer = new LocationDataAccessLayer(_logger.Object,_db);
        }

        [Fact]        
        public void AddLocationToDatabase_ThrowsValidationException()
        {
            //Arrange
            DbUtility.SeedInMemoryDb(_db);
            Location testlocation = new Location(){LocationName = "Chennai",IsActive = true};
            //Act
            var Result = ()=> _locationDataAccessLayer.AddLocationToDatabase(testlocation);
            //Assert
            Result.Should().Throw<ValidationException>();
        }

        [Fact]
        public void AddLocationToDatabase_ReturnsTrue()
        {
            //Arrange
            Location testlocation = new Location(){LocationId= 1,LocationName = "Chennai",IsActive = true};
            //Act
            var Result = _locationDataAccessLayer.AddLocationToDatabase(testlocation);
            //Assert
            Assert.True(Result);
        }

        // [Fact]        
        // public void AddLocationToDatabase_ThrowsDbUpdateException()
        // {
        //     //Arrange
        //     Location testlocation = new Location(){LocationName = "Chennai",IsActive = true};
        //     //Act
        //     var Result = ()=> _locationDataAccessLayer.AddLocationToDatabase(testlocation);
        //     //Assert
        //     Result.Should().Throw<ValidationException>();
        // }

        [Fact]
        public void ViewLocationFromDatabase_ReturnsListOfRoles()
        {
            //Arrange
            _db.Locations.AddRange(LocationMock.GetLocationsMock());
            _db.SaveChanges();
            var location = LocationMock.GetLocationsMock();
            //Act
            var Result = _locationDataAccessLayer.GetLocationsFromDatabase();

            //Assert
            Result.Should().BeEquivalentTo(location);
        }

    }
}
