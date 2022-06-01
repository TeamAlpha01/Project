using System;
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
        _roleController =  new RoleController(_logger.Object,_roleService.Object);
    }
    [Fact]
    public void ViewRole_ShouldReturnStatusCode200()
    {

        // Arrange
        _roleService.Setup(roleService=>roleService.ViewRoles()).Returns(()=>null);
        
        // Act
        var Result = _roleController.ViewRoles() as ObjectResult;
        

        //Assert
        Assert.Equal(200 ,Result.StatusCode);

    }
    [Fact]
    public void ViewRole_ShouldReturnStatusCode500()
    {

        // Arrange
        _roleService.Setup(roleService=>roleService.ViewRoles()).Throws<Exception>();
        
        // Act
        var Result = _roleController.ViewRoles() as ObjectResult ;

        //Assert
        Assert.Equal(500 ,Result.StatusCode);

    }



}