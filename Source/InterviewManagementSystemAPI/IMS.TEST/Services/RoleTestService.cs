using System;
using System.ComponentModel.DataAnnotations;
using FluentAssertions;
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
        
        // 1.   Testing CreateRole(string roleName)
        [Theory]
        [InlineData("Software2#$%")]
        [InlineData("So")]
        [InlineData(null)]
        public void CreateRole_ThrowsValidationException_WithInvalidRoleName(string roleName)
        {
            var Result = () => _roleService.CreateRole(roleName);

            Result.Should().Throw<ValidationException>();
        }

        [Fact]
        public void CreateRole_ReturnsTrue_WithValidRoleName()
        {            
            _roleDataAccessLayer.Setup(r=>r.AddRoleToDatabase(It.Is<Role>(r=>r.RoleName == "Software Tester"))).Returns(true);

            var Result = _roleService.CreateRole("Software Tester");
            Result.Should().BeTrue();
        }
        
        [Fact]
        public void CreateRole_ReturnsFalse_WithValidRoleName()
        {            
            _roleDataAccessLayer.Setup(r=>r.AddRoleToDatabase(It.Is<Role>(r=>r.RoleName == "Software Tester"))).Returns(false);

            var Result = _roleService.CreateRole("Software Tester");
            Result.Should().BeFalse();
        }

        [Fact]
        public void CreateRole_ThrowsValidationException_When_DAL_ThrowsValidationException()
        {            
            _roleDataAccessLayer.Setup(r=>r.AddRoleToDatabase(It.Is<Role>(r=>r.RoleName == "Software Tester"))).Throws<ValidationException>();

            var Result = () => _roleService.CreateRole("Software Tester");
            Result.Should().Throw<ValidationException>();
        }
        [Fact]
        public void CreateRole_ReturnFalse_When_DAL_ThrowsException()
        {            
            _roleDataAccessLayer.Setup(r=>r.AddRoleToDatabase(It.Is<Role>(r=>r.RoleName == "Software Tester"))).Throws<Exception>();

            var Result = _roleService.CreateRole("Software Tester");
            Result.Should().BeFalse();
        }
    }
}