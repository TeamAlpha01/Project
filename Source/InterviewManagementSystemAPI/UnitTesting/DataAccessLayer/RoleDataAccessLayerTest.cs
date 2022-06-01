using IMS.DataAccessLayer;
using IMS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using UnitTesting.MockData;
using Xunit;

namespace UnitTesting.DataAccessLayer
{
    public class RoleDataAccessLayerTest
    {
        private readonly IRoleDataAccessLayer _roleDataAccessLayer;
        private readonly Mock<ILogger<RoleDataAccessLayer>> _logger = new Mock<ILogger<RoleDataAccessLayer>>();
        private readonly InterviewManagementSystemDbContext _db ;//= new InterviewManagementSystemDbContext();
        public RoleDataAccessLayerTest()
        {
            var options = new DbContextOptionsBuilder<InterviewManagementSystemDbContext>().UseInMemoryDatabase(databaseName: "Local Db").Options;

            _db = new InterviewManagementSystemDbContext(options);

            _roleDataAccessLayer = new RoleDataAccessLayer(_logger.Object,_db);
        }

        
        [Fact]
        public void AddRoleToDatabase_ReturnsTrue()
        {
            //Arrange
            _db.Roles.AddRange(RoleMock.GetRolesMock());
            _db.SaveChanges();

            Role testRole = new Role(){RoleId = 12,RoleName = "LocalDb",IsActive = true};

            //Act
            var Result = _roleDataAccessLayer.AddRoleToDatabase(testRole);

            //Assert
            Assert.True(Result);
        }
    }
}