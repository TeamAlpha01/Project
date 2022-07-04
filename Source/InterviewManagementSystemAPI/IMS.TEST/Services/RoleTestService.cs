using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using FluentAssertions;
using IMS.DataAccessLayer;
using IMS.Models;
using IMS.Service;
using Microsoft.Extensions.Logging;
using Moq;
using UnitTesting.MockData;
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
            _roleDataAccessLayer.Setup(r=>r.AddRoleToDatabase(It.IsAny<Role>())).Returns(true);

            var Result = _roleService.CreateRole("Software Tester");
            Result.Should().BeTrue();
        }
        
        [Fact]
        public void CreateRole_ReturnsFalse_WithValidRoleName()
        {            
            _roleDataAccessLayer.Setup(r=>r.AddRoleToDatabase(It.IsAny<Role>())).Returns(false);

            var Result = _roleService.CreateRole("Software Tester");
            Result.Should().BeFalse();
        }

        [Fact]
        public void CreateRole_ThrowsValidationException_When_DAL_ThrowsValidationException()
        {            
            _roleDataAccessLayer.Setup(r=>r.AddRoleToDatabase(It.IsAny<Role>())).Throws<ValidationException>();

            var Result = () => _roleService.CreateRole("Software Tester");
            Result.Should().Throw<ValidationException>();
        }
        [Fact]
        public void CreateRole_ReturnFalse_When_DAL_ThrowsException()
        {            
            _roleDataAccessLayer.Setup(r=>r.AddRoleToDatabase(It.IsAny<Role>())).Throws<Exception>();

            var Result = _roleService.CreateRole("Software Tester");
            Result.Should().BeFalse();
        }
        [Theory]
        [InlineData(0)]
        public void Removerole_ThrowsValidationException_WithInvalidroleId(int roleId)
        {
            var Result = () => _roleService.RemoveRole(roleId);

            Result.Should().Throw<ValidationException>();
        }
         [Fact]
        public void Removerole_ReturnsTrue_WithValidroleId()
        {            
            int roleId = 1;
           _roleDataAccessLayer.Setup(r => r.RemoveRoleFromDatabase(roleId)).Returns(true);
            var Result = _roleService.RemoveRole(roleId);
            Result.Should().BeTrue();
        }
          [Fact]
        public void Removerole_ReturnsFalse_WithValidroleId()
        {            
            int roleId = 1;
           _roleDataAccessLayer.Setup(r => r.RemoveRoleFromDatabase(roleId)).Returns(false);
            var Result = _roleService.RemoveRole(roleId);
            Result.Should().BeFalse();
        }
          
        [Fact]
        public void Removerole_ReturnFalse_When_DAL_ThrowsArgumentException()
        {            
            int roleId = 1;
            _roleDataAccessLayer.Setup(r=>r.RemoveRoleFromDatabase(roleId)).Throws<ArgumentException>();
            var Result = _roleService.RemoveRole(roleId);
            Result.Should().BeFalse();
        }
         [Fact]
        public void Removerole_ReturnFalse_When_DAL_ThrowsValidationException()
        {            
            int roleId = 1;
            _roleDataAccessLayer.Setup(r=>r.RemoveRoleFromDatabase(roleId)).Throws<ValidationException>();
            var Result = () => _roleService.RemoveRole(roleId);
            Result.Should().Throw<ValidationException>();
        }
          [Fact]
        public void Removerole_ReturnFalse_When_DAL_ThrowsException()
        {            
            int roleId = 1;
            _roleDataAccessLayer.Setup(r=>r.RemoveRoleFromDatabase(roleId)).Throws<Exception>();
            var Result = _roleService.RemoveRole(roleId);
            Result.Should().BeFalse();
        }
          [Fact]
        public void Viewrole_ThrowsException_When_DAL_ThrowsException()
        { 
            _roleDataAccessLayer.Setup(r=>r.GetRolesFromDatabase()).Throws<Exception>();
            var Result = () => _roleService.ViewRoles();
            Result.Should().Throw<Exception>();
        }
        [Fact]
        public void Viewrole_ShouldReturn_ListOfProjects()
        {
            var role=RoleMock.GetRolesMock();
            _roleDataAccessLayer.Setup(v=>v.GetRolesFromDatabase()).Returns(role);
            var Result=_roleService.ViewRoles();
            Assert.Equal(role.Count(),Result.Count());

        }
       


        


    }
}