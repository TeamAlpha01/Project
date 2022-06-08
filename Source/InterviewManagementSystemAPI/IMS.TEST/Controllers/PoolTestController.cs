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
  
   //Test cases for create pool
    // [Theory]
    // [InlineData(0,null)]
    

    // public void CreateNewPool_ShouldReturnStatusCode400_WhenRoleNameIsEmptyOrNull(int departmentId, string poolName)
    // {
        
    //     var Result = _poolController.CreateNewPool(departmentId,poolName) as ObjectResult;
        
    //     Result.StatusCode.Should().Be(400);
    // }

    [Theory]
    [InlineData(0)]
    public void RemovePool_ShouldReturnStatusCode400_WhenPoolIdIsZero(int poolId)
    {
        var Result = _poolController.RemovePool(poolId) as ObjectResult;
        Result.StatusCode.Should().Be(400);
    }


}
