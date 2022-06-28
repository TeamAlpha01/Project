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
public class PoolControllerTest
{
    private readonly PoolController _poolController;
    private readonly Mock<ILogger<PoolController>> _logger = new Mock<ILogger<PoolController>>();
    private readonly Mock<IPoolService> _poolService = new Mock<IPoolService>();
    private readonly Mock<IMailService> _mailService = new Mock<IMailService>();

    public PoolControllerTest()
    {
        _poolController = new PoolController(_logger.Object,_mailService.Object,_poolService.Object);
    }
  
   

    [Fact]
    public void CreatePool_ShouldReturnStatusCode200_WithProperInputs()
    {
        int departmentId = 1; 
        string poolName = "TestPool";

        _poolService.Setup(r => r.CreatePool(departmentId,poolName)).Returns(true);

        var Result = _poolController.CreateNewPool(departmentId,poolName) as ObjectResult;

        Result.StatusCode.Should().Be(200);
    }

    [Fact]
    public void CreatePool_ShouldReturnStatusCode500_WithImProperInputs()
    {
        int departmentId = 1; 
        string poolName = "TestPool";

        _poolService.Setup(r => r.CreatePool(departmentId,poolName)).Returns(false);

        var Result = _poolController.CreateNewPool(departmentId,poolName) as ObjectResult;

        Result.StatusCode.Should().Be(500);
    }

    [Fact]
    public void CreateNewPool_ShouldReturnStatusCode400_WhenServiceThrowsValidationException()
    {
        int departmentId = 1; 
        string poolName = "TestPool";

        _poolService.Setup(r => r.CreatePool(departmentId,poolName)).Throws<ValidationException>();

        var Result = _poolController.CreateNewPool(departmentId,poolName) as ObjectResult;

        Result.StatusCode.Should().Be(400);
    }

    [Fact]
    public void CreateNewPool_ShouldReturnStatusCode500_WhenServiceThrowsException()
    {
        int departmentId = 1; 
        string poolName = "TestPool";

        _poolService.Setup(r => r.CreatePool(departmentId,poolName)).Throws<Exception>();

        var Result = _poolController.CreateNewPool(departmentId,poolName) as ObjectResult;

        Result.StatusCode.Should().Be(500);
    }

   

    [Fact]
    public void RemovePool_ShouldReturnStatusCode200_WithProperInputs()
    {
        int poolId = 1; 

        _poolService.Setup(r => r.RemovePool(poolId)).Returns(true);

        var Result = _poolController.RemovePool(poolId) as ObjectResult;

        Result.StatusCode.Should().Be(200);
    }

    [Fact]
    public void RemovePool_ShouldReturnStatusCode500_WithImProperInputs()
    {
        int poolId = 1; 

        _poolService.Setup(r => r.RemovePool(poolId)).Returns(false);

        var Result = _poolController.RemovePool(poolId) as ObjectResult;

        Result.StatusCode.Should().Be(500);
    }

    [Fact]
    public void  RemovePool_ShouldReturnStatusCode400_WhenServiceThrowsValidationException()
    {
        int poolId = 1;

        _poolService.Setup(r => r.RemovePool(poolId)).Throws<ValidationException>();

        var Result = _poolController.RemovePool(poolId) as ObjectResult;

        Result.StatusCode.Should().Be(400);
    }

    [Fact]
    public void RemovePool_ShouldReturnStatusCode500_WhenServiceThrowsException()
    {
        int poolId = 1;

        _poolService.Setup(r => r.RemovePool(poolId)).Throws<Exception>();

        var Result = _poolController.RemovePool(poolId) as ObjectResult;

        Result.StatusCode.Should().Be(500);
    }
    [Fact]
    public void EditPool_ShoulReturnBadRequest_WhenPoolIdAndPoolNameIsNull()
    {
        int poolId=0;
        string poolName=null;
        var Result=_poolController.EditPool(poolId,poolName) as ObjectResult;
        Result.StatusCode.Should().Be(400);
    }
    [Fact]
    public void EditPool_ShouldReturnStatus400_WhenServiceThrowsValidationException()
    {
        int poolId=1;
        string poolName="Freshers";
        _poolService.Setup(e=>e.EditPool(poolId,poolName)).Throws<ValidationException>();
        var Result=_poolController.EditPool(poolId,poolName) as ObjectResult;
        Result.StatusCode.Should().Be(400);
    }
    [Fact]
    public void EditPool_ShouldReturnStatusCode500_WhenServiceThrowsException()
    {
        int poolId=1;
        string poolName="Freshers";
        _poolService.Setup(e=>e.EditPool(poolId,poolName)).Throws<Exception>();
        var Result=_poolController.EditPool(poolId,poolName) as ObjectResult;
        Result.StatusCode.Should().Be(400);
     }
     [Fact]
     public void EditPool_ShouldReturnStatusCode200_WithProperInput()
     {
        int poolId=1;
        string poolName="Freshers";
        _poolService.Setup(e=>e.EditPool(poolId,poolName)).Returns(true);
        var Result=_poolController.EditPool(poolId,poolName)as ObjectResult;
        Result.StatusCode.Should().Be(200);
     }
     [Fact]
     public void EditPool_ShouldReturnStatusCode500_withImProperInput()
     {
        int poolId=1;
        string poolName="Freshers";
        _poolService.Setup(e=>e.EditPool(poolId,poolName)).Returns(false);
        var Result=_poolController.EditPool(poolId,poolName)as ObjectResult;
        Result.StatusCode.Should().Be(400);
     }

    [Fact]
    public void Viewpool_ShouldReturnStatusCode200()
    {
        // Arrange
        _poolService.Setup(poolService => poolService.ViewPools()).Returns(new Object());
        // Act
        var Result = _poolController.ViewPools() as ObjectResult;
        //Assert
        Assert.Equal(200, Result.StatusCode);
    }

    [Fact]
    public void Viewpool_ShouldReturnStatusCode400_WhenServiceThrowsValidationException()
    {
        // Arrange
        _poolService.Setup(poolService => poolService.ViewPools()).Throws<ValidationException>();
        // Act
        var Result = _poolController.ViewPools() as ObjectResult;
        //Assert
        Assert.Equal(400, Result.StatusCode);
    }

    [Fact]
    public void Viewpool_ShouldReturnStatusCode500_WhenServiceThrowsException()
    {
        // Arrange
        _poolService.Setup(poolService => poolService.ViewPools()).Throws<Exception>();
        // Act
        var Result = _poolController.ViewPools() as ObjectResult;
        //Assert
        Assert.Equal(500, Result.StatusCode);
    }

    
    // [Fact]
    // public void AddPoolMembers_ShouldReturnStatusCode400_WhenNoProperInputs()
    // {
    //     int poolId = 0; 
    //     int employeeId = 0; 
    //     var Result = _poolController.AddPoolMember(poolId,employeeId) as ObjectResult;
    //     Result.StatusCode.Should().Be(400);
    // }

    // Include Mail Service for Status code 200

    // [Fact]
    // public void AddPoolMember_ShouldReturnStatusCode200_WithProperInputs()
    // {
    //     int poolId = 1; 
    //     int employeeId = 1; 
    //     
    //     _poolService.Setup(r => r.AddPoolMember(poolId,employeeId)).Returns(true);

    //     var Result = _poolController.AddPoolMember(poolId,employeeId) as ObjectResult;

    //     Result.StatusCode.Should().Be(200);
    // }
    [Fact]
    public void AddPoolMember_ShouldReturnStatusCode200_WithProperInputs()
    {
        int poolId=1;
        int employeeId=1;
        _poolService.Setup(p=>p.AddPoolMember(poolId,employeeId)).Returns(true);
        var Result=_poolController.AddPoolMember(poolId,employeeId)as ObjectResult;
        Result.StatusCode.Should().Be(200);

    }

    [Fact]
    public void AddPoolMember_ShouldReturnStatusCode500_WithImProperInputs()
    {
        int poolId = 1; 
        int employeeId = 1; 
        
        _poolService.Setup(r => r.AddPoolMember(poolId,employeeId)).Returns(false);

        var Result = _poolController.AddPoolMember(poolId,employeeId) as ObjectResult;

        Result.StatusCode.Should().Be(500);
    }

    [Fact]
    public void AddPoolMembers_ShouldReturnStatusCode400_WhenServiceThrowsValidationException()
    {
        int poolId = 1; 
        int employeeId = 1; 
        
        _poolService.Setup(r => r.AddPoolMember(poolId,employeeId)).Throws<ValidationException>();

        var Result = _poolController.AddPoolMember(poolId,employeeId) as ObjectResult;

        Result.StatusCode.Should().Be(400);
    }

    // Add one more case for pool cancelled but mail not triggered

    [Fact]
    public void AddPoolMembers_ShouldReturnStatusCode500_WhenServiceThrowsException()
    {
        int poolId = 1; 
        int employeeId = 1; 
        
        _poolService.Setup(r => r.AddPoolMember(poolId,employeeId)).Throws<Exception>();

        var Result = _poolController.AddPoolMember(poolId,employeeId) as ObjectResult;

        Result.StatusCode.Should().Be(500);
    }

   

    // Include Mail Service for Status code 200
    [Theory]
    [InlineData(0)]
    public void RemovePoolMember_ShouldReturnStatusCode400_WhenPoolMemberIdIsZero(int poolMemberId)
    {
    var Result=_poolController.RemovePoolMember(poolMemberId) as ObjectResult;
    Result.StatusCode.Should().Be(400);
    }
    [Fact]
    public void RemovePoolMember_ShouldReturnStatusCode200_WithProperInputs()
    {
        int poolMemberId=1;
        _poolService.Setup(p => p.RemovePoolMember(poolMemberId)).Returns(true);
        var Result=_poolController.RemovePoolMember(poolMemberId)as ObjectResult;
        Result.StatusCode.Should().Be(200);
    }

    [Fact]
    public void RemovePoolMember_ShouldReturnStatusCode500_WithImProperInputs()
    {
        int poolmemberId = 1;
        
        _poolService.Setup(r => r.RemovePoolMember(poolmemberId)).Returns(false);

        var Result = _poolController.RemovePoolMember(poolmemberId) as ObjectResult;

        Result.StatusCode.Should().Be(500);
    }

    [Fact]
    public void RemovePoolMembers_ShouldReturnStatusCode400_WhenServiceThrowsValidationException()
    {
        int poolmemberId = 1; 
        
        _poolService.Setup(r => r.RemovePoolMember(poolmemberId)).Throws<ValidationException>();

        var Result = _poolController.RemovePoolMember(poolmemberId) as ObjectResult;

        Result.StatusCode.Should().Be(400);
    }

    // Add one more case for pool cancelled but mail not triggered

    [Fact]
    public void RemovePoolMembers_ShouldReturnStatusCode500_WhenServiceThrowException()
    {
        int poolmemberId = 1; 
        
        _poolService.Setup(r => r.RemovePoolMember(poolmemberId)).Throws<Exception>();

        var Result = _poolController.RemovePoolMember(poolmemberId) as ObjectResult;

        Result.StatusCode.Should().Be(500);
    }

    [Theory]
    [InlineData(0)]
    public void ViewPoolMembers_ShouldReturnStatusCode400_WhenPoolIdIsNull(int poolId)
    {
     
        var Result = _poolController.ViewPoolMembers(poolId) as ObjectResult;
        Result.StatusCode.Should().Be(400);
    }

    [Fact]
    public void ViewPoolMembers_ShouldReturnStatusCode200_WithProperpoolId()
    {
        int poolId = 1; 

        _poolService.Setup(r => r.ViewPoolMembers(poolId)).Returns(new Object());

        var Result = _poolController.ViewPoolMembers(poolId) as ObjectResult;

        Result.StatusCode.Should().Be(200);
    }
   
    [Fact]
    public void ViewpoolMembers_ShouldReturnStatusCode400_WhenServiceThrowsValidationException()
    {
        int poolId = 1; 

        _poolService.Setup(r => r.ViewPoolMembers(poolId)).Throws<ValidationException>();

        var Result = _poolController.ViewPoolMembers(poolId) as ObjectResult;

        Result.StatusCode.Should().Be(400);
    }

    [Fact]
    public void ViewpoolMembers_ShouldReturnStatusCode500_WhenServiceThrowsException()
    {
        int poolId = 1; 

        _poolService.Setup(r => r.ViewPoolMembers(poolId)).Throws<Exception>();

        var Result = _poolController.ViewPoolMembers(poolId) as ObjectResult;

        Result.StatusCode.Should().Be(500);
    }

}
