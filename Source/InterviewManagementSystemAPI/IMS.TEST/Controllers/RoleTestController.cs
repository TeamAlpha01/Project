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

public class RoleControllerTest
{
    private readonly RoleController _roleController;
    private readonly Mock<ILogger<RoleController>> _logger = new Mock<ILogger<RoleController>>();
    private readonly Mock<IRoleService> _roleService = new Mock<IRoleService>();
    public RoleControllerTest()
    {
        _roleController = new RoleController(_logger.Object, _roleService.Object);
    }


    // 1.   Testing CreateNewRole()
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void CreateNewRole_ShouldReturnStatusCode400_WhenRoleNameIsEmptyOrNull(string roleName)
    {
        var Result = _roleController.CreateNewRole(roleName) as ObjectResult;
        
        Result.StatusCode.Should().Be(400);
    }

    [Fact]
    public void CreateNewRole_ShouldReturnStatusCode200_WithProperRoleName()
    {
        string roleName = "Software Developer";
        _roleService.Setup(r => r.CreateRole(roleName)).Returns(true);

        var Result = _roleController.CreateNewRole(roleName) as ObjectResult;

        Result.StatusCode.Should().Be(200);
    }

    [Fact]
    public void CreateNewRole_ShouldReturnStatusCode500_WithProperRoleName()
    {
        string roleName = "Software Developer";
        _roleService.Setup(r => r.CreateRole(roleName)).Returns(false);

        var Result = _roleController.CreateNewRole(roleName) as ObjectResult;

        Result.StatusCode.Should().Be(500);
    }

    [Fact]
    public void CreateNewRole_ShouldReturnStatusCode400_WhenServiceThrowsValidationException()
    {
        string roleName = "Software Developer2342";
        _roleService.Setup(r => r.CreateRole(roleName)).Throws<ValidationException>();

        var Result = _roleController.CreateNewRole(roleName) as ObjectResult;

        Result.StatusCode.Should().Be(400);
    }
    [Fact]
    public void CreateNewRole_ShouldReturnStatusCode500_WhenServiceThrowsException()
    {
        string roleName = "Software Developer";
        _roleService.Setup(r => r.CreateRole(roleName)).Throws<Exception>();

        var Result = _roleController.CreateNewRole(roleName) as ObjectResult;

        Result.StatusCode.Should().Be(500);
    }


    // 3.   Testing ViewRoles()
    [Fact]
    public void ViewRoles_ShouldReturnStatusCode200()
    {

        // Arrange
        _roleService.Setup(roleService => roleService.ViewRoles()).Returns(() => null);
        // Act
        var Result = _roleController.ViewRoles() as ObjectResult;
        //Assert
        Assert.Equal(200, Result.StatusCode);
    }

    [Fact]
    public void ViewRoles_ShouldReturnStatusCode500()
    {
        // Arrange
        _roleService.Setup(roleService => roleService.ViewRoles()).Throws<Exception>();
        // Act
        var Result = _roleController.ViewRoles() as ObjectResult;
        //Assert
        Assert.Equal(500, Result.StatusCode);
    }
}