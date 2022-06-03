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
    private readonly Mock<MailService> _mailService = new Mock<MailService>();
    private readonly Mock<IPoolService> _roleService = new Mock<IPoolService>();
    public PoolControllerTest()
    {
      _poolController=new PoolController(_logger.Object,_mailService.Object,_roleService.Object);
    }
    //Test cases for create pool
    [Theory]
    [InlineData(0,null)]
    

    public void CreateNewPool_ShouldReturnStatusCode400_WhenRoleNameIsEmptyOrNull(int departmentId, string poolName)
    {
        
        var Result = _poolController.CreateNewPool(departmentId,poolName) as ObjectResult;
        
        Result.StatusCode.Should().Be(400);
    }


}
