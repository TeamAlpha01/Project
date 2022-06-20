using System.ComponentModel.DataAnnotations;
using System.Linq;
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
            var DbMock = new Mock<InterviewManagementSystemDbContext>();
           //Act
           DbMock.Setup(d=>d.SaveChanges()).Throws<DbUpdateException>();
            var Result = ()=> _roleDataAccessLayer.AddRoleToDatabase(new Role());
            //Assert
            Result.Should().Throw<DbUpdateException>();
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

    public class RoleDataAccessLayerTestForExceptions
    {
       private readonly IRoleDataAccessLayer _roleDataAccessLayer;
        private readonly Mock<ILogger<RoleDataAccessLayer>> _logger = new Mock<ILogger<RoleDataAccessLayer>>();
        
        private readonly Mock<InterviewManagementSystemDbContext> _db = new Mock<InterviewManagementSystemDbContext>(new DbContextOptionsBuilder<InterviewManagementSystemDbContext>().UseInMemoryDatabase(databaseName: "Local Db").Options) ;
        public RoleDataAccessLayerTestForExceptions()
        {
            _roleDataAccessLayer = new RoleDataAccessLayer(_logger.Object,_db.Object);
        }

        [Fact]        
        public void AddRoleToDatabase_ThrowsDbUpdateException()
        {
            _db.Object.Roles.AddRange(RoleMock.GetRolesMock());
            _db.Setup(d=>d.SaveChanges()).Throws<DbUpdateException>();
            var Result = ()=> _roleDataAccessLayer.AddRoleToDatabase(new Role());
            //Assert
            Result.Should().Throw<DbUpdateException>();
        }
 
    }
}