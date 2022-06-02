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
    public class RoleDataAccessLayerTest
    {
        private readonly IRoleDataAccessLayer _roleDataAccessLayer;
        private readonly Mock<ILogger<RoleDataAccessLayer>> _logger = new Mock<ILogger<RoleDataAccessLayer>>();
        private readonly InterviewManagementSystemDbContext _db ;
        public RoleDataAccessLayerTest()
        {
            _db = DbUtility.GetInMemoryDbContext();
            _roleDataAccessLayer = new RoleDataAccessLayer(_logger.Object,_db);
        }


        [Fact]        
        public void AddRoleToDatabase_ThrowsValidationException()
        {
            //Arrange
            DbUtility.SeedInMemoryDb(_db);
            Role testRole = new Role(){RoleName = "Software Developer",IsActive = true};
            //Act
            var Result = ()=> _roleDataAccessLayer.AddRoleToDatabase(testRole);
            //Assert
            Result.Should().Throw<ValidationException>();
        }

        [Fact]
        public void AddRoleToDatabase_ReturnsTrue()
        {
            //Arrange
            Role testRole = new Role(){RoleId = 12,RoleName = "LocalDb",IsActive = true};
            //Act
            var Result = _roleDataAccessLayer.AddRoleToDatabase(testRole);
            //Assert
            Assert.True(Result);
        }

        [Fact]        
        public void AddRoleToDatabase_ThrowsDbUpdateException()
        {
            //Arrange



            //Act
            var Result = ()=> _roleDataAccessLayer.AddRoleToDatabase(new Role());
            //Assert
            Result.Should().Throw<ValidationException>();
        }


        
        [Fact]
        public void ViewRolesFromDatabase_ReturnsListOfRoles()
        {
            //Arrange
            _db.Roles.AddRange(RoleMock.GetRolesMock());
            _db.SaveChanges();
            var role = RoleMock.GetRolesMock();
            //Act
            var Result = _roleDataAccessLayer.GetRolesFromDatabase();

            //Assert
            Result.Should().BeEquivalentTo(role);
        }
    }
}