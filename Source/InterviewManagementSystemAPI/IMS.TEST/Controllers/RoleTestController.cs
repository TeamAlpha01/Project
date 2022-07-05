using System;
using System.ComponentModel.DataAnnotations;
using FluentAssertions;
using IMS.Controllers;
using IMS.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using UnitTesting.MockData;
using Xunit;

namespace UnitTesting.Controllers;

public class RoleControllerTest
{
    private readonly RoleController _roleController;
    private readonly Mock<ILogger<RoleController>> _logger = new Mock<ILogger<RoleController>>();
    private readonly Mock<IRoleService> _roleService = new Mock<IRoleService>();
    public RoleControllerTest()
    {
        _roleController = new RoleController(_logger.Object,_roleService.Object);
    }

    // 1.   Testing CreateNewRole()
    [Theory]
    [InlineData(null,true)]
    [InlineData("",true)]
    public void CreateNewRole_ShouldReturnStatusCode400_WhenRoleNameIsEmptyOrNull(string roleName,bool isManagement)
    {
        var Result = _roleController.CreateNewRole(roleName,isManagement) as ObjectResult;
        
        Result.StatusCode.Should().Be(400);
    }
    [Theory]
    [InlineData("Software Developer",true)]
    public void CreateNewRole_ShouldReturnStatusCode200_WithProperRoleName(string roleName,bool isManagement)
    {
      
        _roleService.Setup(r => r.CreateRole(roleName,isManagement)).Returns(true);

        var Result = _roleController.CreateNewRole(roleName,isManagement) as ObjectResult;

        Result.StatusCode.Should().Be(200);
    }

    [Fact]
    public void CreateNewRole_ShouldReturnStatusCode500_WithInvalidRoleName()
    {
        string roleName = "Software Developer";
        bool isManagement=true;
        _roleService.Setup(r => r.CreateRole(roleName,isManagement)).Returns(false);

        var Result = _roleController.CreateNewRole(roleName,isManagement) as ObjectResult;

        Result.StatusCode.Should().Be(500);
    }

    [Fact]
    public void CreateNewRole_ShouldReturnStatusCode400_WhenServiceThrowsValidationException()
    {
        string roleName = "Software Developer2342";
        bool isManagement=true;
        _roleService.Setup(r => r.CreateRole(roleName,isManagement)).Throws<ValidationException>();

        var Result = _roleController.CreateNewRole(roleName,isManagement) as ObjectResult;

        Result.StatusCode.Should().Be(400);
    }
    [Fact]
    public void CreateNewRole_ShouldReturnStatusCode500_WhenServiceThrowsException()
    {
        string roleName = "Software Developer";
        bool isManagement=false;
        _roleService.Setup(r => r.CreateRole(roleName,isManagement)).Throws<Exception>();

        var Result = _roleController.CreateNewRole(roleName,isManagement) as ObjectResult;

        Result.StatusCode.Should().Be(500);
    }


    // 3.   Testing ViewRoles()
    [Fact]
    public void ViewRoles_ShouldReturnStatusCode200()
    {

        var roles=RoleMock.GetRolesMock();
        _roleService.Setup(v=>v.ViewRoles()).Returns(roles);
        
       
        // Act
        var Result = _roleController.ViewRoles() as ObjectResult;
        //Assert
         Assert.Equal(roles,Result?.Value);
    }

    [Fact]
    public void ViewRoles_ShouldReturnServiceThrowsException()
    {
        // Arrange
        _roleService.Setup(roleService => roleService.ViewRoles()).Throws<Exception>();
        // Act
        var Result = _roleController.ViewRoles() as ObjectResult;
        //Assert
        Assert.Equal(500, Result.StatusCode);
    }
}