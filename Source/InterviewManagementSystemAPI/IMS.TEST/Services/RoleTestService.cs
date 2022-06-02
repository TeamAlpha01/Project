using System.ComponentModel.DataAnnotations;
using IMS.DataAccessLayer;
using IMS.Models;
using IMS.Service;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace UnitTesting.ServiceTests
{
    public class RoleTestService
    {
        private readonly RoleService _roleService;
        private readonly Mock<ILogger<RoleService>> _logger = new Mock<ILogger<RoleService>>();
        private readonly Mock<IRoleDataAccessLayer> _roleDataAccessLayer = new Mock<IRoleDataAccessLayer>();

        public RoleTestService()
        {
            _roleService = new RoleService(_logger.Object, _roleDataAccessLayer.Object);
        }
        
        
        
        [Theory]
        [InlineData("Software2")]
        public void CreateRole_ReturnsValidationError(string roleName)
        {
            //Assert
            Assert.Throws<ValidationException>(()=>_roleService.CreateRole(roleName));
        }
    }
}